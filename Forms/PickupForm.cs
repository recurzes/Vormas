using System;
using System.Windows.Forms;
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

            ConfigureGrid();
            LoadData();
        }

        private void ConfigureGrid()
        {
            dgvVehicles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVehicles.MultiSelect = false;
            dgvVehicles.ReadOnly = true;
            dgvVehicles.AutoGenerateColumns = false;

            dgvVehicles.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "VehicleCode", HeaderText = @"Code", Width = 70 });
            dgvVehicles.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "Make", HeaderText = @"Make", Width = 80 });
            dgvVehicles.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "Model", HeaderText = @"Model", Width = 80 });
            dgvVehicles.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "Year", HeaderText = @"Year", Width = 50 });
            dgvVehicles.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "Color", HeaderText = @"Color", Width = 60 });
            dgvVehicles.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "LicensePlate", HeaderText = @"Plate", Width = 80 });
            dgvVehicles.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "Transmission", HeaderText = @"Trans.", Width = 70 });
            dgvVehicles.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "Odometer", HeaderText = @"Odometer", Width = 80 });

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
                // Load eligible customers
                var customers = _rentalService.GetEligibleCustomers();
                cmbCustomer.DataSource = customers.Select(c => new
                {
                    c.CustomerId,
                    DisplayName = $"{c.FirstName} {c.LastName} ({c.Phone})"
                }).ToList();
                cmbCustomer.DisplayMember = "DisplayName";
                cmbCustomer.ValueMember = "CustomerId";

                // Load available vehicles
                var vehicles = _rentalService.GetAvailableVehicles();
                _vehicleBindingSource.DataSource = vehicles;
                dgvVehicles.DataSource = _vehicleBindingSource;

                // Set defaults
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
                var request = new RentalPickupRequest
                {
                    CustomerId = (int)cmbCustomer.SelectedValue,
                    VehicleId = _selectedVehicle.VehicleId,
                    PickupDateTime = dtpPickupDate.Value,
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

                LoadData(); // Refresh vehicle list
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
        }
    }
}