using System;
using System.Collections.Generic;
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
        private readonly BindingSource _rentalBindingSource;
        private readonly BindingSource _damageBindingSource;
        private Rental _selectedRental;
        private readonly List<DamageClaimRequest> _pendingDamageClaims = new List<DamageClaimRequest>();
        
        public ReturnForm(IRentalService rentalService, IDamageClaimsService damageClaimsService, ISessionService sessionService)
        {
            InitializeComponent();
            
            _rentalService = rentalService ?? throw new ArgumentNullException(nameof(rentalService));
            _damageClaimsService = damageClaimsService ?? throw new ArgumentNullException(nameof(damageClaimsService));
            _sessionService = sessionService ?? throw new ArgumentNullException(nameof(sessionService));
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
                { DataPropertyName = "VehicleDescription", HeaderText = @"Description", Width = 150 });
            dgvRentals.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "PickupDateTime", HeaderText = @"Pickup Date", Width = 130 });
            dgvRentals.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "PickupOdometer", HeaderText = @"Pickup Odo", Width = 90 });
            dgvRentals.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "DepositAmount", HeaderText = @"Deposit", Width = 80 });

            dgvRentals.SelectionChanged += DgvRentals_SelectionChanged;
        }

        private void ConfigureDamageGrid()
        {
            dgvDamages.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDamages.MultiSelect = false;
            dgvDamages.ReadOnly = true;
            dgvDamages.AutoGenerateColumns = false;

            dgvDamages.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "DamageDescription", HeaderText = @"Damage Type", Width = 200 });
            dgvDamages.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "Severity", HeaderText = @"Severity", Width = 80 });
            dgvDamages.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "EstimatedCost", HeaderText = @"Est. Cost", Width = 80 });
        }

        private void DgvRentals_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRentals.CurrentRow?.DataBoundItem is Rental rental)
            {
                _selectedRental = rental;
                numOdometer.Minimum = rental.PickupOdometer ?? 0;
                numOdometer.Value = rental.PickupOdometer ?? 0;
                lblPickupInfo.Text = $@"Pickup: {rental.PickupDateTime:yyyy-MM-dd HH:mm} | Odo: {rental.PickupOdometer:N2} | Fuel: {rental.PickupFuelLevel:P0}";
                
                _pendingDamageClaims.Clear();
                RefreshDamageGrid();
            }
        }

        private void LoadData()
        {
            try
            {
                var rentals = _rentalService.GetActiveRentals();
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

                string damageMsg = _pendingDamageClaims.Count > 0 
                    ? $"\n{_pendingDamageClaims.Count} damage claim(s) submitted for review." 
                    : "";
                MessageBox.Show($@"Rental completed successfully!{damageMsg}", 
                    @"Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadData();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"Error completing rental: {ex.Message}", @"Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            cmbDamageType.SelectedIndex = -1;
            txtDamagePhotoPath.Text = "";
            RefreshDamageGrid();
        }
    }
}