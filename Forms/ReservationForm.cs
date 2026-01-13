using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Vormas.Models;
using Vormas.Navigation;
using Vormas.Services;
using Vormas.Interfaces;

namespace Vormas.Forms
{
    public partial class ReservationForm : PageControl
    {
        private readonly IReservationService _reservationService;
        private readonly IVehicleService _vehicleService;
        private readonly ICustomerService _customerService;

        public ReservationForm(IReservationService reservationService, IVehicleService vehicleService, ICustomerService customerService)
        {
            InitializeComponent();
            _reservationService = reservationService ?? throw new ArgumentNullException(nameof(reservationService));
            _vehicleService = vehicleService ?? throw new ArgumentNullException(nameof(vehicleService));
            _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
            
            LoadData();
        }

        private void LoadData()
        {
            LoadCustomers();
            LoadVehicles();
            LoadReservations();
            
            // Defatuls
            dtpStartDate.Value = DateTime.Today;
            dtpEndDate.Value = DateTime.Today.AddDays(1);
        }

        private void LoadCustomers()
        {
            try
            {
                var customers = _customerService.GetAll();
                cmbCustomer.DataSource = customers;
                cmbCustomer.DisplayMember = "FullName"; // Assuming Customer has FullName property or we make one
                cmbCustomer.ValueMember = "CustomerId";
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"Error loading customers: {ex.Message}");
            }
        }

        private void LoadVehicles()
        {
            try
            {
                var vehicles = _vehicleService.GetAllVehicles();
                // Filter only Available? Or show all and check availability later.
                // Generally better to show all so user can choose.
                
                // Need a better display string
                var displayList = vehicles.Select(v => new { 
                    v.VehicleId, 
                    Display = $"{v.Make} {v.Model} ({v.LicensePlate})" 
                }).ToList();

                cmbVehicle.DataSource = displayList;
                cmbVehicle.DisplayMember = "Display";
                cmbVehicle.ValueMember = "VehicleId";
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"Error loading vehicles: {ex.Message}");
            }
        }

        private void LoadReservations()
        {
            try
            {
                var reservations = _reservationService.GetReservations();
                dgvReservations.DataSource = reservations;
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"Error loading reservations: {ex.Message}");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbCustomer.SelectedValue == null)
            {
                MessageBox.Show(@"Please select a customer.");
                return;
            }
            if (cmbVehicle.SelectedValue == null)
            {
                MessageBox.Show(@"Please select a vehicle.");
                return;
            }
            
            if (dtpEndDate.Value < dtpStartDate.Value)
            {
                MessageBox.Show(@"End Date cannot be before Start Date.");
                return;
            }

            if (dtpStartDate.Value.Date < DateTime.Today)
            {
                MessageBox.Show(@"Start Date cannot be in the past.");
                return;
            }

            int customerId = (int)cmbCustomer.SelectedValue;
            int vehicleId = (int)cmbVehicle.SelectedValue;

            try
            {
                bool available = _reservationService.IsVehicleAvailable(vehicleId, dtpStartDate.Value, dtpEndDate.Value);
                if (!available)
                {
                    MessageBox.Show(@"Selected vehicle is not available for these dates.");
                    return;
                }

                var reservation = new Reservation
                {
                    CustomerId = customerId,
                    VehicleId = vehicleId,
                    StartDate = dtpStartDate.Value,
                    EndDate = dtpEndDate.Value,
                    Status = "Pending"
                };

                _reservationService.CreateReservation(reservation);
                MessageBox.Show(@"Reservation created successfully.");
                LoadReservations();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"Error processing reservation: {ex.Message}");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void ClearInputs()
        {
            cmbCustomer.SelectedIndex = -1;
            cmbVehicle.SelectedIndex = -1;
            dtpStartDate.Value = DateTime.Today;
            dtpEndDate.Value = DateTime.Today.AddDays(1);
        }
    }
}
