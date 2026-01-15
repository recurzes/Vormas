using System;
using System.Windows.Forms;
using System.Drawing;
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
            ApplyModernStyling();
            LoadData();
            SetupEventHandlers();
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
            
            // Uniform font styling (matching other grids)
            var headerFont = new Font("Segoe UI", 9F, FontStyle.Regular);
            var cellFont = new Font("Segoe UI", 9F, FontStyle.Regular);
            
            dgvVehicles.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                Font = headerFont,
                BackColor = Color.FromArgb(240, 240, 240),
                ForeColor = Color.Black,
                Alignment = DataGridViewContentAlignment.MiddleLeft
            };
            dgvVehicles.DefaultCellStyle = new DataGridViewCellStyle
            {
                Font = cellFont,
                BackColor = Color.White,
                ForeColor = Color.Black,
                SelectionBackColor = Color.FromArgb(0, 120, 215),
                SelectionForeColor = Color.White
            };
            dgvVehicles.EnableHeadersVisualStyles = false;

            dgvVehicles.Columns.Clear();
            dgvVehicles.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "VehicleCode", HeaderText = "Code", FillWeight = 15 });
            dgvVehicles.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Make", HeaderText = "Make", FillWeight = 20 });
            dgvVehicles.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Model", HeaderText = "Model", FillWeight = 20 });
            dgvVehicles.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Year", HeaderText = "Year", FillWeight = 10 });
            dgvVehicles.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Color", HeaderText = "Color", FillWeight = 15 });
            dgvVehicles.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "LicensePlate", HeaderText = "Plate", FillWeight = 20 });
            dgvVehicles.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SeatingCapacity", HeaderText = "Seats", FillWeight = 10 });
            dgvVehicles.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Transmission", HeaderText = "Trans", FillWeight = 15 });

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
                var customerName = cmbCustomer.Text;
                lblSummary.Text = $@"Booking Summary: {_selectedVehicle.Make} {_selectedVehicle.Model} ({_selectedVehicle.VehicleCode}) | {customerName}";
                lblSummary.ForeColor = Color.ForestGreen;
            }
            else
            {
                lblSummary.Text = @"Booking Summary: No vehicle selected";
                lblSummary.ForeColor = Color.DimGray;
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
                _vehicleBindingSource.ResetBindings(false);
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
                if (_sessionService.CurrentUser == null)
                {
                    MessageBox.Show(@"User session not found. Please log in again.", @"Authentication Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

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



        private void ApplyModernStyling()
        {
            // Colors
            var primaryBlue = Color.FromArgb(0, 120, 215);
            var successGreen = Color.ForestGreen;
            var deleteRed = Color.IndianRed;
            var textFont = new Font("Segoe UI", 10F);
            var headerFont = new Font("Segoe UI", 12F, FontStyle.Bold);

            // Form
            this.BackColor = Color.White;
            this.Font = textFont;

            // Titles
            lblTitle.ForeColor = Color.Black; 
            
            // GroupBoxes
            grpConfig.Font = new Font("Segoe UI", 10F);
            grpVehicle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            // Inputs
            dtpStartDate.Font = textFont;
            dtpEndDate.Font = textFont;
            cmbCustomer.Font = textFont;
            txtNotes.BorderStyle = BorderStyle.FixedSingle;

            // Buttons
            btnCreateReservation.FlatStyle = FlatStyle.Flat;
            btnCreateReservation.BackColor = successGreen;
            btnCreateReservation.ForeColor = Color.White;
            btnCreateReservation.FlatAppearance.BorderSize = 0;
            btnCreateReservation.Cursor = Cursors.Hand;
            btnCreateReservation.Height = 35;



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
