using System;
using System.Windows.Forms;
using System.Linq;
using Vormas.Interfaces;
using Vormas.Models;
using Vormas.Navigation;

namespace Vormas.Forms
{
    public partial class ReservationForm : PageControl
    {
        private readonly IReservationService _reservationService;
        private readonly ISessionService _sessionService;
        private readonly BindingSource _vehicleBindingSource;
        private Vehicle _selectedVehicle;

        public ReservationForm(IReservationService reservationService, ISessionService sessionService)
        {
            InitializeComponent();
            _reservationService = reservationService ?? throw new ArgumentNullException(nameof(reservationService));
            _sessionService = sessionService ?? throw new ArgumentNullException(nameof(sessionService));
            _vehicleBindingSource = new BindingSource();

            ConfigureGrid();
            LoadData();
            SetupEventHandlers();
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
                { DataPropertyName = "SeatingCapacity", HeaderText = @"Seats", Width = 50 });

            dgvVehicles.SelectionChanged += DgvVehicles_SelectionChanged;
        }

        private void SetupEventHandlers()
        {
            dtpStartDate.ValueChanged += DateRange_ValueChanged;
            dtpEndDate.ValueChanged += DateRange_ValueChanged;
        }

        private void DgvVehicles_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvVehicles.CurrentRow?.DataBoundItem is Vehicle vehicle)
            {
                _selectedVehicle = vehicle;
                UpdateVehicleInfo();
            }
        }

        private void UpdateVehicleInfo()
        {
            if (_selectedVehicle != null)
            {
                lblSelectedVehicle.Text = $@"Selected: {_selectedVehicle.Make} {_selectedVehicle.Model} ({_selectedVehicle.VehicleCode})";
            }
            else
            {
                lblSelectedVehicle.Text = @"No vehicle selected";
            }
        }

        private void DateRange_ValueChanged(object sender, EventArgs e)
        {
            if (dtpStartDate.Value >= dtpEndDate.Value)
            {
                dtpEndDate.Value = dtpStartDate.Value.AddDays(1);
            }
            RefreshAvailableVehicles();
        }

        private void LoadData()
        {
            try
            {
                var customers = _reservationService.GetEligibleCustomers();
                cmbCustomer.DataSource = customers.Select(c => new
                {
                    c.CustomerId,
                    DisplayName = $"{c.FirstName} {c.LastName} ({c.Phone})"
                }).ToList();
                cmbCustomer.DisplayMember = "DisplayName";
                cmbCustomer.ValueMember = "CustomerId";

                dtpStartDate.Value = DateTime.Now.AddDays(1);
                dtpEndDate.Value = DateTime.Now.AddDays(2);

                RefreshAvailableVehicles();
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"Error loading data: {ex.Message}", @"Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshAvailableVehicles()
        {
            try
            {
                var vehicles = _reservationService.GetVehiclesForDateRange(
                    dtpStartDate.Value, dtpEndDate.Value);
                _vehicleBindingSource.DataSource = vehicles;
                dgvVehicles.DataSource = _vehicleBindingSource;
                _selectedVehicle = null;
                UpdateVehicleInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"Error loading vehicles: {ex.Message}", @"Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCreateReservation_Click(object sender, EventArgs e)
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

            if (dtpStartDate.Value >= dtpEndDate.Value)
            {
                MessageBox.Show(@"End date must be after start date.", @"Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtpStartDate.Value < DateTime.Now)
            {
                MessageBox.Show(@"Start date must be in the future.", @"Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var request = new ReservationRequest
                {
                    CustomerId = (int)cmbCustomer.SelectedValue,
                    VehicleId = _selectedVehicle.VehicleId,
                    StartDateTime = dtpStartDate.Value,
                    EndDateTime = dtpEndDate.Value,
                    CreatedByUserId = _sessionService.CurrentUser.UserId,
                    Notes = txtNotes.Text
                };

                int reservationId = _reservationService.CreateReservation(request);

                MessageBox.Show($@"Reservation created successfully! Reservation ID: {reservationId}",
                    @"Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearForm();
                RefreshAvailableVehicles();
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"Error creating reservation: {ex.Message}", @"Error",
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
            dtpStartDate.Value = DateTime.Now.AddDays(1);
            dtpEndDate.Value = DateTime.Now.AddDays(2);
            txtNotes.Text = "";
            UpdateVehicleInfo();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshAvailableVehicles();
        }
    }
}
