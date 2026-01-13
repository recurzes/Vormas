using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Vormas.Interfaces;
using Vormas.Models;
using Vormas.Navigation;

namespace Vormas.Forms
{
    public partial class ReturnForm : PageControl
    {
        private readonly IRentalService _rentalService;
        private readonly IDamageClaimsService _damageClaimsService;
        private readonly ISessionService _sessionService;
        private readonly IBillingService _billingService;
        private readonly INavigationService _navigationService;
        private readonly BindingSource _rentalBindingSource;
        private readonly BindingSource _damageBindingSource;
        private Rental _selectedRental;
        private readonly List<DamageClaimRequest> _pendingDamageClaims = new List<DamageClaimRequest>();
        
        private const decimal MaxDailyMileage = 200.00m;
        private const int LateReturnGraceMinutes = 30;
        
        public ReturnForm(IRentalService rentalService, IDamageClaimsService damageClaimsService, ISessionService sessionService, IBillingService billingService, INavigationService navigationService)
        {
            InitializeComponent();
            
            _rentalService = rentalService ?? throw new ArgumentNullException(nameof(rentalService));
            _damageClaimsService = damageClaimsService ?? throw new ArgumentNullException(nameof(damageClaimsService));
            _sessionService = sessionService ?? throw new ArgumentNullException(nameof(sessionService));
            _billingService = billingService ?? throw new ArgumentNullException(nameof(billingService));
            _navigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));
            _rentalBindingSource = new BindingSource();
            _damageBindingSource = new BindingSource();

            ConfigureGrid();
            ConfigureDamageGrid();
            LoadData();
            LoadDamageTypes();
        }
        
        private void ConfigureGrid()
        {
            dgvRentals.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRentals.MultiSelect = false;
            dgvRentals.ReadOnly = true;
            dgvRentals.AutoGenerateColumns = false;

            dgvRentals.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "RentalId", HeaderText = @"ID", Width = 50 });
            dgvRentals.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "CustomerName", HeaderText = @"Customer", Width = 150 });
            dgvRentals.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "VehicleCode", HeaderText = @"Vehicle", Width = 80 });
            dgvRentals.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "VehicleDescription", HeaderText = @"Description", Width = 120 });
            dgvRentals.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "PickupDateTime", HeaderText = @"Pickup Date", Width = 120 });
            dgvRentals.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "ExpectedReturnDateTime", HeaderText = @"Expected Return", Width = 120 });
            dgvRentals.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "DepositAmount", HeaderText = @"Deposit", Width = 70 });

            dgvRentals.SelectionChanged += DgvRentals_SelectionChanged;
        }

        private void ConfigureDamageGrid()
        {
            dgvDamages.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDamages.MultiSelect = false;
            dgvDamages.ReadOnly = true;
            dgvDamages.AutoGenerateColumns = false;

            dgvDamages.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "DamageDescription", HeaderText = @"Damage Type", Width = 150 });
            dgvDamages.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "Severity", HeaderText = @"Severity", Width = 70 });
            dgvDamages.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "EstimatedCost", HeaderText = @"Est. Cost", Width = 70 });
        }

        private void DgvRentals_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRentals.CurrentRow?.DataBoundItem is Rental rental)
            {
                _selectedRental = rental;
                numOdometer.Minimum = rental.PickupOdometer ?? 0;
                numOdometer.Value = rental.PickupOdometer ?? 0;
                
                DisplayPickupCondition(rental);
                
                CalculateMetrics();
                
                _pendingDamageClaims.Clear();
                RefreshDamageGrid();
            }
        }

        private void DisplayPickupCondition(Rental rental)
        {
            lblPickupInfo.Text = $@"PICKUP CONDITION - Date: {rental.PickupDateTime:yyyy-MM-dd HH:mm}";
            lblPickupOdometer.Text = $@"Odometer: {rental.PickupOdometer:N2} km";
            lblPickupFuel.Text = $@"Fuel: {rental.PickupFuelLevel:P0}";
            lblPickupClean.Text = rental.PickupIsClean == true ? "Clean" : "Not Clean";
            lblPickupSmoked.Text = rental.PickupIsSmokedIn == true ? "Smoked In" : "No Smoking";
            lblPickupAccessories.Text = rental.PickupAccessoriesOk == true ? "Accessories OK" : "Accessories Issue";
            
            lblPickupClean.ForeColor = rental.PickupIsClean == true ? Color.Green : Color.OrangeRed;
            lblPickupSmoked.ForeColor = rental.PickupIsSmokedIn == true ? Color.OrangeRed : Color.Green;
            lblPickupAccessories.ForeColor = rental.PickupAccessoriesOk == true ? Color.Green : Color.OrangeRed;
        }

        private void CalculateMetrics()
        {
            if (_selectedRental == null || _selectedRental.PickupDateTime == null) return;

            var pickupDate = _selectedRental.PickupDateTime;
            var returnDate = dtpReturnDate.Value;
            var duration = returnDate - pickupDate;
            int days = (int)Math.Ceiling(duration.TotalDays);
            int hours = (int)duration.TotalHours % 24;

            lblDuration.Text = string.Format(@"Duration: {0} day(s), {1} hr(s)", days, hours);

            decimal pickupOdo = _selectedRental.PickupOdometer ?? 0;
            decimal returnOdo = numOdometer.Value;
            decimal mileageTraveled = returnOdo - pickupOdo;

            lblMileage.Text = string.Format(@"Mileage: {0:N2} km", mileageTraveled);

            decimal allowedMileage = days * MaxDailyMileage;
            decimal overage = mileageTraveled - allowedMileage;

            if (overage > 0)
            {
                lblMileageOverage.Text = string.Format(@"OVERAGE: {0:N2} km over limit ({1:N0} km allowed)", overage, allowedMileage);
                lblMileageOverage.ForeColor = Color.OrangeRed;
                lblMileageOverage.Visible = true;
            }
            else
            {
                lblMileageOverage.Text = string.Format(@"Within limit ({0:N0}/{1:N0} km)", mileageTraveled, allowedMileage);
                lblMileageOverage.ForeColor = Color.Green;
                lblMileageOverage.Visible = true;
            }

            CheckLateReturn(returnDate);
        }

        private void CheckLateReturn(DateTime returnDate)
        {
            if (_selectedRental?.ExpectedReturnDateTime == null)
            {
                lblLateReturn.Visible = false;
                return;
            }

            var expectedReturn = _selectedRental.ExpectedReturnDateTime.Value;
            var gracePeriod = expectedReturn.AddMinutes(LateReturnGraceMinutes);

            if (returnDate > gracePeriod)
            {
                var lateBy = returnDate - expectedReturn;
                int lateHours = (int)lateBy.TotalHours;
                int lateMins = lateBy.Minutes;

                lblLateReturn.Text = string.Format(@"LATE RETURN: {0}h {1}m overdue", lateHours, lateMins);
                lblLateReturn.ForeColor = Color.Red;
                lblLateReturn.Visible = true;
            }
            else if (returnDate > expectedReturn)
            {
                lblLateReturn.Text = string.Format(@"Within grace period ({0} min)", LateReturnGraceMinutes);
                lblLateReturn.ForeColor = Color.Orange;
                lblLateReturn.Visible = true;
            }
            else
            {
                lblLateReturn.Text = @"On-time return";
                lblLateReturn.ForeColor = Color.Green;
                lblLateReturn.Visible = true;
            }
        }

        private void numOdometer_ValueChanged(object sender, EventArgs e)
        {
            CalculateMetrics();
        }

        private void dtpReturnDate_ValueChanged(object sender, EventArgs e)
        {
            CalculateMetrics();
        }

        private void chkExpectedToday_CheckedChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var rentals = _rentalService.GetActiveRentals();
                
                if (chkExpectedToday.Checked)
                {
                    var today = DateTime.Today;
                    var filtered = new List<Rental>();
                    foreach (var r in rentals)
                    {
                        if (r.ExpectedReturnDateTime?.Date == today)
                        {
                            filtered.Add(r);
                        }
                    }
                    rentals = filtered;
                }
                
                _rentalBindingSource.DataSource = rentals;
                dgvRentals.DataSource = _rentalBindingSource;

                dtpReturnDate.Value = DateTime.Now;
                numFuelLevel.Value = 1.00m;
                chkIsClean.Checked = true;
                chkAccessoriesOk.Checked = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"Error loading data: {ex.Message}", @"Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDamageTypes()
        {
            try
            {
                var damageTypes = _damageClaimsService.GetAvailableDamageTypes();
                cmbDamageType.DataSource = damageTypes;
                cmbDamageType.DisplayMember = "Description";
                cmbDamageType.ValueMember = "DamageId";
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"Error loading damage types: {ex.Message}", @"Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddDamage_Click(object sender, EventArgs e)
        {
            if (_selectedRental == null)
            {
                MessageBox.Show(@"Please select a rental first.", @"Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbDamageType.SelectedValue == null)
            {
                MessageBox.Show(@"Please select a damage type.", @"Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedDamageType = cmbDamageType.SelectedItem as DamageTypes;
            var claim = new DamageClaimRequest
            {
                RentalId = _selectedRental.RentalId,
                DamageId = (int)cmbDamageType.SelectedValue,
                ReportedByUserId = _sessionService.CurrentUser.UserId,
                PhotoPath = txtDamagePhotoPath.Text,
                InitialChargeAmount = selectedDamageType?.EstimatedRepairCost ?? 0
            };

            _pendingDamageClaims.Add(claim);
            RefreshDamageGrid();
            
            cmbDamageType.SelectedIndex = -1;
            txtDamagePhotoPath.Text = "";
        }

        private void RefreshDamageGrid()
        {
            var displayList = new List<dynamic>();
            foreach (var claim in _pendingDamageClaims)
            {
                var damageType = (cmbDamageType.DataSource as List<DamageTypes>)?.Find(d => d.DamageId == claim.DamageId);
                displayList.Add(new
                {
                    DamageDescription = damageType?.Description ?? "Unknown",
                    Severity = damageType?.Severity ?? "Unknown",
                    EstimatedCost = claim.InitialChargeAmount
                });
            }
            _damageBindingSource.DataSource = displayList;
            dgvDamages.DataSource = _damageBindingSource;
            lblDamageCount.Text = $@"Damages: {_pendingDamageClaims.Count}";
        }

        private void btnRemoveDamage_Click(object sender, EventArgs e)
        {
            if (dgvDamages.CurrentRow != null && dgvDamages.CurrentRow.Index >= 0 && dgvDamages.CurrentRow.Index < _pendingDamageClaims.Count)
            {
                _pendingDamageClaims.RemoveAt(dgvDamages.CurrentRow.Index);
                RefreshDamageGrid();
            }
        }

        private void btnBrowsePhoto_Click(object sender, EventArgs e)
        {
            using var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = @"Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            openFileDialog.Title = @"Select Damage Photo";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtDamagePhotoPath.Text = openFileDialog.FileName;
            }
        }

        private void btnCompleteRental_Click(object sender, EventArgs e)
        {
            if (_selectedRental == null)
            {
                MessageBox.Show(@"Please select an active rental.", @"Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (numOdometer.Value < (_selectedRental.PickupOdometer ?? 0))
            {
                MessageBox.Show(@"Return odometer cannot be less than pickup odometer.", @"Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtpReturnDate.Value < _selectedRental.PickupDateTime)
            {
                MessageBox.Show(@"Return date cannot be before pickup date.", @"Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (HasWarnings())
            {
                var result = MessageBox.Show(
                    @"There are warnings (late return or mileage overage). Do you want to proceed?",
                    @"Confirm",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                    
                if (result != DialogResult.Yes)
                    return;
            }

            try
            {
                foreach (var damageClaim in _pendingDamageClaims)
                {
                    _damageClaimsService.AddDamageClaim(damageClaim);
                }

                var request = new RentalReturnRequest
                {
                    RentalId = _selectedRental.RentalId,
                    ReturnDateTime = dtpReturnDate.Value,
                    ReturnOdometer = numOdometer.Value,
                    ReturnFuelLevel = numFuelLevel.Value,
                    ReturnAgentId = _sessionService.CurrentUser.UserId,
                    IsSmokedIn = chkIsSmokedIn.Checked,
                    IsClean = chkIsClean.Checked,
                    AccessoriesOk = chkAccessoriesOk.Checked,
                    InspectionNotes = txtNotes.Text
                };

                _rentalService.CompleteRental(request);
                
                int completedRentalId = _selectedRental.RentalId;

                string damageMsg = _pendingDamageClaims.Count > 0 
                    ? $"\n{_pendingDamageClaims.Count} damage claim(s) submitted for review." 
                    : "";
                
                
                var viewInvoiceResult = MessageBox.Show(
                    $@"Rental completed successfully!{damageMsg}\n\nWould you like to view and print the invoice now?",
                    @"Rental Completed",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                LoadData();
                ClearForm();
                
                if (viewInvoiceResult == DialogResult.Yes)
                {
                    try
                    {
                        _billingService.GenerateInvoice(completedRentalId, _sessionService.CurrentUser.UserId);
                    }
                    catch { /* Invoice may already exist */ }
                    
                    _navigationService.Navigate(Routes.Billing, completedRentalId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"Error completing rental: {ex.Message}", @"Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool HasWarnings()
        {
            if (_selectedRental?.ExpectedReturnDateTime != null)
            {
                var gracePeriod = _selectedRental.ExpectedReturnDateTime.Value.AddMinutes(LateReturnGraceMinutes);
                if (dtpReturnDate.Value > gracePeriod)
                    return true;
            }
            
            decimal pickupOdo = _selectedRental?.PickupOdometer ?? 0;
            decimal returnOdo = numOdometer.Value;
            decimal mileageTraveled = returnOdo - pickupOdo;
            
            var duration = dtpReturnDate.Value - _selectedRental.PickupDateTime;
            int days = (int)Math.Ceiling(duration.TotalDays);
            decimal allowedMileage = days * MaxDailyMileage;
            
            return mileageTraveled > allowedMileage;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            dgvRentals.ClearSelection();
            _selectedRental = null;
            _pendingDamageClaims.Clear();
            dtpReturnDate.Value = DateTime.Now;
            numOdometer.Minimum = 0;
            numOdometer.Value = 0;
            numFuelLevel.Value = 1.00m;
            chkIsSmokedIn.Checked = false;
            chkIsClean.Checked = true;
            chkAccessoriesOk.Checked = true;
            txtNotes.Text = "";
            
            lblPickupInfo.Text = "";
            lblPickupOdometer.Text = "";
            lblPickupFuel.Text = "";
            lblPickupClean.Text = "";
            lblPickupSmoked.Text = "";
            lblPickupAccessories.Text = "";
            
            lblDuration.Text = "";
            lblMileage.Text = "";
            lblMileageOverage.Text = "";
            lblLateReturn.Text = "";
            lblMileageOverage.Visible = false;
            lblLateReturn.Visible = false;
            
            cmbDamageType.SelectedIndex = -1;
            txtDamagePhotoPath.Text = "";
            RefreshDamageGrid();
        }
    }
}

