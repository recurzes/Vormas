using System;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using Vormas.Interfaces;
using Vormas.Models;
using Vormas.Navigation;

namespace Vormas.Forms
{
    public partial class PickupForm : PageControl
    {
        private readonly IRentalService _rentalService;
        private readonly ISessionService _sessionService;
        private readonly BindingSource _vehicleBindingSource;
        private Vehicle _selectedVehicle;

        public PickupForm(IRentalService rentalService, ISessionService sessionService)
        {
            InitializeComponent();
            _rentalService = rentalService ?? throw new ArgumentNullException(nameof(rentalService));
            _sessionService = sessionService ?? throw new ArgumentNullException(nameof(sessionService));
            _vehicleBindingSource = new BindingSource();

            _vehicleBindingSource = new BindingSource();

            ConfigureGrid();
            ApplyModernStyling();
            LoadData();
        }

        private void ConfigureGrid()
        {
            dgvVehicles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVehicles.MultiSelect = false;
            dgvVehicles.ReadOnly = true;
            dgvVehicles.AutoGenerateColumns = false;
            dgvVehicles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVehicles.RowHeadersVisible = false;
            dgvVehicles.BackgroundColor = Color.White;
            dgvVehicles.BorderStyle = BorderStyle.None;

            dgvVehicles.Columns.Clear();
            dgvVehicles.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "VehicleCode", HeaderText = "Code", FillWeight = 15 });
            dgvVehicles.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Make", HeaderText = "Make", FillWeight = 20 });
            dgvVehicles.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Model", HeaderText = "Model", FillWeight = 20 });
            dgvVehicles.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Year", HeaderText = "Year", FillWeight = 10 });
            dgvVehicles.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Color", HeaderText = "Color", FillWeight = 15 });
            dgvVehicles.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "LicensePlate", HeaderText = "Plate", FillWeight = 20 });
            dgvVehicles.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Odometer", HeaderText = "Odometer", FillWeight = 15 });

            dgvVehicles.SelectionChanged += DgvVehicles_SelectionChanged;
        }

        private void DgvVehicles_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvVehicles.CurrentRow?.DataBoundItem is Vehicle vehicle)
            {
                _selectedVehicle = vehicle;
                numOdometer.Value = (decimal)vehicle.Odometer;
            }
        }

        private void LoadData()
        {
            try
            {
                var customers = _rentalService.GetEligibleCustomers();
                cmbCustomer.DataSource = customers.Select(c => new
                {
                    c.CustomerId,
                    DisplayName = $"{c.FirstName} {c.LastName} ({c.Phone})"
                }).ToList();
                cmbCustomer.DisplayMember = "DisplayName";
                cmbCustomer.ValueMember = "CustomerId";
                
                var vehicles = _rentalService.GetAvailableVehicles();
                _vehicleBindingSource.DataSource = vehicles;
                dgvVehicles.DataSource = _vehicleBindingSource;
                
                dtpPickupDate.Value = DateTime.Now;
                numFuelLevel.Value = 1.00m;
                numDeposit.Value = 5000.00m;
                chkIsClean.Checked = true;
                chkAccessoriesOk.Checked = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"Error loading data: {ex.Message}", @"Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnStartRental_Click(object sender, EventArgs e)
        {
            if (cmbCustomer.SelectedValue == null)
            {
                MessageBox.Show(@"Please select a customer.", @"Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_selectedVehicle == null)
            {
                MessageBox.Show(@"Please select a vehicle.", @"Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (_sessionService.CurrentUser == null)
                {
                    MessageBox.Show(@"You must be logged in to start a rental.", @"Session Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var request = new RentalPickupRequest
                {
                    CustomerId = (int)cmbCustomer.SelectedValue,
                    VehicleId = _selectedVehicle.VehicleId,
                    PickupDateTime = dtpPickupDate.Value,
                    ExpectedReturnDateTime = dtpExpectedReturn.Value,
                    PickupOdometer = numOdometer.Value,
                    PickupFuelLevel = numFuelLevel.Value,
                    PickupAgentId = _sessionService.CurrentUser.UserId,
                    DepositAmount = numDeposit.Value,
                    IsSmokedIn = chkIsSmokedIn.Checked,
                    IsClean = chkIsClean.Checked,
                    AccessoriesOk = chkAccessoriesOk.Checked,
                    InspectionNotes = txtNotes.Text
                };

                int rentalId = _rentalService.StartRental(request);

                MessageBox.Show($@"Rental started successfully! Rental ID: {rentalId}",
                    @"Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadData();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"Error starting rental: {ex.Message}", @"Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            cmbCustomer.SelectedIndex = -1;
            dgvVehicles.ClearSelection();
            _selectedVehicle = null;
            dtpPickupDate.Value = DateTime.Now;
            numOdometer.Value = 0;
            numFuelLevel.Value = 1.00m;
            numDeposit.Value = 5000.00m;
            chkIsSmokedIn.Checked = false;
            chkIsClean.Checked = true;
            chkAccessoriesOk.Checked = true;
            txtNotes.Text = "";
            dtpExpectedReturn.Value = DateTime.Now.AddDays(1);
        }

        private void ApplyModernStyling()
        {
            // Colors
            var primaryBlue = Color.FromArgb(0, 120, 215);
            var successGreen = Color.SeaGreen;
            var deleteRed = Color.IndianRed;
            var textFont = new Font("Segoe UI", 10F);
            var headerFont = new Font("Segoe UI", 12F, FontStyle.Bold);

            // Form
            this.BackColor = Color.White;
            this.Font = textFont;

            // GroupBoxes
            foreach (Control c in this.Controls)
            {
                if (c is GroupBox gb) gb.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            }

            // Buttons
            btnStartRental.FlatStyle = FlatStyle.Flat;
            btnStartRental.BackColor = successGreen;
            btnStartRental.ForeColor = Color.White;
            btnStartRental.FlatAppearance.BorderSize = 0;
            btnStartRental.Cursor = Cursors.Hand;
            btnStartRental.Height = 35;

            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.BackColor = Color.DimGray;
            btnClear.ForeColor = Color.White;
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.Cursor = Cursors.Hand;
            btnClear.Height = 35;

            // Grid Headers
            dgvVehicles.EnableHeadersVisualStyles = false;
            dgvVehicles.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            dgvVehicles.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvVehicles.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvVehicles.DefaultCellStyle.SelectionBackColor = primaryBlue;
            dgvVehicles.DefaultCellStyle.SelectionForeColor = Color.White;
        }
    }
}