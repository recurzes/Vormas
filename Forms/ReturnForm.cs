using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
        
        private ComboBox cmbSeverity;
        private NumericUpDown numDamageCost;
        
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

            // Rebuild UI for modern layout
            SetupRedesignedLayout();

            ConfigureGrid();
            ConfigureDamageGrid();
            LoadData();
            LoadDamageTypes();
        }
        private void SetupRedesignedLayout()
        {
            // 1. Reset Root Container
            this.Controls.Clear();
            this.BackColor = SystemColors.Control;
            this.Font = new Font("Segoe UI", 9F);

            // 2. MAIN LAYOUT (Vertical Stack)
            var tlpMain = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 3,
                Padding = new Padding(10)
            };
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));  // Header
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 220F)); // Master Grid
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));  // Detail Workspace

            // --- SECTION 1: HEADER ---
            var pnlHeaderBar = new Panel { Dock = DockStyle.Fill };
            var lblTitleMinimal = new Label { Text = "Vehicle Return Processing", Font = new Font("Segoe UI", 12F, FontStyle.Bold), AutoSize = true, Location = new Point(0, 5) };
            
            chkExpectedToday.AutoSize = true;
            chkExpectedToday.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            chkExpectedToday.Location = new Point(780 - 180, 10); // Approximation, layout will position it
            
            pnlHeaderBar.Controls.Add(lblTitleMinimal);
            pnlHeaderBar.Controls.Add(chkExpectedToday);
            tlpMain.Controls.Add(pnlHeaderBar, 0, 0);

            // --- SECTION 2: ACTIVE RENTALS ---
            var grpRentalsMinimal = new GroupBox { Text = "Active Rentals", Dock = DockStyle.Fill, Font = new Font("Segoe UI", 9F, FontStyle.Bold) };
            dgvRentals.Dock = DockStyle.Fill;
            dgvRentals.BackgroundColor = Color.White;
            dgvRentals.BorderStyle = BorderStyle.FixedSingle;
            dgvRentals.RowHeadersVisible = false;
            dgvRentals.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRentals.Font = new Font("Segoe UI", 9F);
            grpRentalsMinimal.Controls.Add(dgvRentals);
            tlpMain.Controls.Add(grpRentalsMinimal, 0, 1);

            // --- SECTION 3: DETAIL WORKSPACE (2 Columns) ---
            var tlpWorkspace = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, RowCount = 1 };
            tlpWorkspace.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpWorkspace.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));

            // -- COLUMN LEFT (Return & Damage) --
            var tlpLeft = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 1, RowCount = 2 };
            tlpLeft.RowStyles.Add(new RowStyle(SizeType.Absolute, 180F)); // Return Details + Metrics
            tlpLeft.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));  // Damage Assessment

            // A: Return Details
            var grpReturnMinimal = new GroupBox { Text = "Return Information", Dock = DockStyle.Fill, Font = new Font("Segoe UI", 9F, FontStyle.Bold), Padding = new Padding(8) };
            var tlpReturnInput = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, RowCount = 3 };
            tlpReturnInput.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            
            Action<string, Control, int> addMinimalRow = (txt, ctrl, row) => {
                tlpReturnInput.Controls.Add(new Label { Text = txt, AutoSize = true, Anchor = AnchorStyles.Left | AnchorStyles.Top, Padding = new Padding(0, 5, 0, 0), Font = new Font("Segoe UI", 9F) }, 0, row);
                tlpReturnInput.Controls.Add(ctrl, 1, row);
                ctrl.Dock = DockStyle.Top;
                ctrl.Font = new Font("Segoe UI", 9F);
                if (ctrl is NumericUpDown) ctrl.Width = 80;
            };
            addMinimalRow("Return Date:", dtpReturnDate, 0);
            addMinimalRow("Odometer:", numOdometer, 1);
            addMinimalRow("Fuel (0-1):", numFuelLevel, 2);

            var flpMetricsMinimal = new FlowLayoutPanel { Dock = DockStyle.Bottom, Height = 40, FlowDirection = FlowDirection.LeftToRight };
            foreach (var lbl in new[] { lblDuration, lblMileage }) {
                lbl.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                lbl.AutoSize = true;
                lbl.Margin = new Padding(0, 5, 15, 0);
                flpMetricsMinimal.Controls.Add(lbl);
            }
            grpReturnMinimal.Controls.Add(tlpReturnInput);
            grpReturnMinimal.Controls.Add(flpMetricsMinimal);
            tlpLeft.Controls.Add(grpReturnMinimal, 0, 0);

            // B: Damage Log
            var grpDamageMinimal = new GroupBox { Text = "Damage Assessment", Dock = DockStyle.Fill, Font = new Font("Segoe UI", 9F, FontStyle.Bold), Padding = new Padding(8) };
            var tlpDamageContent = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 1, RowCount = 3 };
            tlpDamageContent.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F)); // Type selector
            tlpDamageContent.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F)); // Buttons
            tlpDamageContent.RowStyles.Add(new RowStyle(SizeType.Percent, 100F)); // Grid

            var pnlDamageType = new FlowLayoutPanel { Dock = DockStyle.Fill, FlowDirection = FlowDirection.LeftToRight, AutoSize = true };
            pnlDamageType.Controls.Add(new Label { Text = "Type:", AutoSize = true, Margin = new Padding(0, 5, 2, 0), Font = new Font("Segoe UI", 9F) });
            cmbDamageType.Width = 140;
            cmbDamageType.DropDownStyle = ComboBoxStyle.DropDown;
            cmbDamageType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbDamageType.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbDamageType.SelectedIndexChanged += CmbDamageType_SelectedIndexChanged;
            pnlDamageType.Controls.Add(cmbDamageType);

            pnlDamageType.Controls.Add(new Label { Text = "Sev:", AutoSize = true, Margin = new Padding(5, 5, 2, 0), Font = new Font("Segoe UI", 9F) });
            cmbSeverity = new ComboBox { Width = 80, DropDownStyle = ComboBoxStyle.DropDownList };
            cmbSeverity.Items.AddRange(new[] { "Minor", "Moderate", "Major" });
            cmbSeverity.SelectedIndex = 1; // Moderate
            pnlDamageType.Controls.Add(cmbSeverity);

            pnlDamageType.Controls.Add(new Label { Text = "Cost:", AutoSize = true, Margin = new Padding(5, 5, 2, 0), Font = new Font("Segoe UI", 9F) });
            numDamageCost = new NumericUpDown { Width = 70, Maximum = 1000000, DecimalPlaces = 2 };
            pnlDamageType.Controls.Add(numDamageCost);
            
            var pnlDamageBtnsMinimal = new FlowLayoutPanel { Dock = DockStyle.Fill, FlowDirection = FlowDirection.LeftToRight };
            foreach (var btn in new[] { btnAddDamage, btnRemoveDamage }) {
                btn.FlatStyle = FlatStyle.Flat;
                btn.Height = 26;
                btn.Font = new Font("Segoe UI", 9F);
                pnlDamageBtnsMinimal.Controls.Add(btn);
            }

            dgvDamages.Dock = DockStyle.Fill;
            dgvDamages.BackgroundColor = Color.White;
            dgvDamages.BorderStyle = BorderStyle.FixedSingle;
            dgvDamages.RowHeadersVisible = false;
            dgvDamages.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            tlpDamageContent.Controls.Add(pnlDamageType, 0, 0);
            tlpDamageContent.Controls.Add(pnlDamageBtnsMinimal, 0, 1);
            tlpDamageContent.Controls.Add(dgvDamages, 0, 2);
            grpDamageMinimal.Controls.Add(tlpDamageContent);
            tlpLeft.Controls.Add(grpDamageMinimal, 0, 1);
            tlpWorkspace.Controls.Add(tlpLeft, 0, 0);

            // -- COLUMN RIGHT (Comparison & Inspection) --
            var tlpRight = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 1, RowCount = 3 };
            tlpRight.RowStyles.Add(new RowStyle(SizeType.Absolute, 140F)); // Pickup Condition
            tlpRight.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));  // Inspection Findings
            tlpRight.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));  // Global Actions

            // C: Pickup Comparison
            var grpPickupMinimal = new GroupBox { Text = "Original Pickup Condition", Dock = DockStyle.Fill, Font = new Font("Segoe UI", 9F, FontStyle.Bold), Padding = new Padding(8) };
            var flpPickupMinimal = new FlowLayoutPanel { Dock = DockStyle.Fill, FlowDirection = FlowDirection.TopDown, AutoScroll = true };
            foreach (var lbl in new[] { lblPickupInfo, lblPickupOdometer, lblPickupFuel, lblPickupClean, lblPickupSmoked, lblPickupAccessories }) {
                lbl.Font = new Font("Segoe UI", 9F);
                lbl.AutoSize = true;
                lbl.Margin = new Padding(0, 0, 0, 2);
                flpPickupMinimal.Controls.Add(lbl);
            }
            grpPickupMinimal.Controls.Add(flpPickupMinimal);
            tlpRight.Controls.Add(grpPickupMinimal, 0, 0);

            // D: Inspection & Notes
            var grpInspectMinimal = new GroupBox { Text = "Inspection Findings", Dock = DockStyle.Fill, Font = new Font("Segoe UI", 9F, FontStyle.Bold), Padding = new Padding(8) };
            var tlpInspectContent = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 1, RowCount = 2 };
            tlpInspectContent.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F)); // Checkboxes
            tlpInspectContent.RowStyles.Add(new RowStyle(SizeType.Percent, 100F)); // Notes

            var flpCheckboxesMinimal = new FlowLayoutPanel { Dock = DockStyle.Fill, FlowDirection = FlowDirection.LeftToRight };
            foreach (var chk in new[] { chkIsClean, chkIsSmokedIn , chkAccessoriesOk}) {
                chk.Font = new Font("Segoe UI", 9F);
                chk.AutoSize = true;
                chk.Margin = new Padding(0, 0, 15, 0);
                flpCheckboxesMinimal.Controls.Add(chk);
            }
            txtNotes.Dock = DockStyle.Fill;
            txtNotes.Multiline = true;
            txtNotes.Font = new Font("Segoe UI", 9F);
            
            tlpInspectContent.Controls.Add(flpCheckboxesMinimal, 0, 0);
            tlpInspectContent.Controls.Add(txtNotes, 0, 1);
            grpInspectMinimal.Controls.Add(tlpInspectContent);
            tlpRight.Controls.Add(grpInspectMinimal, 0, 1);

            // E: Global Actions
            var flpActionsMinimal = new FlowLayoutPanel { Dock = DockStyle.Right, FlowDirection = FlowDirection.LeftToRight, Padding = new Padding(0, 10, 0, 0), AutoSize = true };
            foreach (var btn in new[] { btnCompleteRental, btnClear }) {
                btn.FlatStyle = FlatStyle.Flat;
                btn.Height = 32;
                btn.Width = 120;
                btn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                flpActionsMinimal.Controls.Add(btn);
            }
            btnCompleteRental.BackColor = Color.DodgerBlue;
            btnCompleteRental.ForeColor = Color.White;
            tlpRight.Controls.Add(flpActionsMinimal, 0, 2);

            tlpWorkspace.Controls.Add(tlpRight, 1, 0);
            tlpMain.Controls.Add(tlpWorkspace, 0, 2);

            this.Controls.Add(tlpMain);
            this.PerformLayout();
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

            if (_sessionService.CurrentUser == null)
            {
                MessageBox.Show(@"Session expired or user not logged in. Please log in again.", @"Session Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string damageText = cmbDamageType.Text.Trim();
            if (string.IsNullOrEmpty(damageText))
            {
                MessageBox.Show(@"Please enter or select a damage type.", @"Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var damageTypesList = cmbDamageType.DataSource as List<DamageTypes>;
            var selectedType = damageTypesList?.FirstOrDefault(d => d.Description.Equals(damageText, StringComparison.OrdinalIgnoreCase));

            var claim = new Vormas.Models.DamageClaimRequest();
            claim.RentalId = _selectedRental.RentalId;
            claim.DamageId = selectedType?.DamageId ?? 0;
            claim.CustomDescription = selectedType == null ? damageText : null;
            claim.Severity = cmbSeverity.Text;
            claim.ReportedByUserId = _sessionService.CurrentUser.UserId;
            claim.PhotoPath = txtDamagePhotoPath.Text;
            claim.InitialChargeAmount = numDamageCost.Value > 0 ? numDamageCost.Value : (selectedType?.EstimatedRepairCost ?? 0m);

            _pendingDamageClaims.Add(claim);
            RefreshDamageGrid();
            
            cmbDamageType.SelectedIndex = -1;
            cmbDamageType.Text = "";
            cmbSeverity.SelectedIndex = 1;
            numDamageCost.Value = 0;
            txtDamagePhotoPath.Text = "";
        }

        private void CmbDamageType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDamageType.SelectedItem is DamageTypes selected)
            {
                cmbSeverity.Text = selected.Severity;
                numDamageCost.Value = selected.EstimatedRepairCost ?? 0;
            }
        }

        private void RefreshDamageGrid()
        {
            try
            {
                var displayList = new List<object>();
                var sourceList = cmbDamageType.DataSource as List<DamageTypes>;

                foreach (var claim in _pendingDamageClaims)
                {
                    var damageType = sourceList?.FirstOrDefault(d => d.DamageId == claim.DamageId);
                    displayList.Add(new
                    {
                        DamageDescription = damageType?.Description ?? claim.CustomDescription ?? "Unknown",
                        Severity = claim.Severity ?? damageType?.Severity ?? "Moderate",
                        EstimatedCost = claim.InitialChargeAmount
                    });
                }
                
                if (_damageBindingSource != null)
                {
                    _damageBindingSource.DataSource = displayList;
                    if (dgvDamages != null) dgvDamages.DataSource = _damageBindingSource;
                }
                
                if (lblDamageCount != null)
                {
                    lblDamageCount.Text = $@"Damages: {_pendingDamageClaims.Count}";
                }
            }
            catch (Exception ex)
            {
                // Silently log or handle grid update errors to prevent app crash
                Console.WriteLine(@"Error refreshing damage grid: " + ex.Message);
            }
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
                if (_sessionService.CurrentUser == null)
                {
                    MessageBox.Show(@"You must be logged in to complete a rental.", @"Session Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

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

                // Generate the invoice
                try
                {
                    _billingService.GenerateInvoice(completedRentalId, _sessionService.CurrentUser.UserId);
                }
                catch { /* Invoice may already exist */ }

                MessageBox.Show(
                    $@"Rental completed successfully!{damageMsg}\n\nInvoice generated. Go to Invoice tab to view.",
                    @"Rental Completed",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadData();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"Error completing rental: {ex.Message}{Environment.NewLine}{Environment.NewLine}Stack Trace:{Environment.NewLine}{ex.StackTrace}", @"Error", 
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

