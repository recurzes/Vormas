using System;
using System.Linq;
using System.Windows.Forms;
using Vormas.Models;
using Vormas.Navigation;
using Vormas.Services;
using Vormas.Interfaces;

namespace Vormas.Forms
{
    public partial class RentalForm : PageControl
    {
        private readonly IRentalService _rentalService;
        private readonly IReservationService _reservationService;
        private readonly IVehicleService _vehicleService;
        private Reservation _selectedReservation;

        public RentalForm(IRentalService rentalService, IReservationService reservationService, IVehicleService vehicleService)
        {
            InitializeComponent();
            _rentalService = rentalService ?? throw new ArgumentNullException(nameof(rentalService));
            _reservationService = reservationService ?? throw new ArgumentNullException(nameof(reservationService));
            _vehicleService = vehicleService ?? throw new ArgumentNullException(nameof(vehicleService));
            
            LoadReservations();
        }

        private void LoadReservations()
        {
            try
            {
                var reservations = _reservationService.GetReservations()
                                                      .Where(r => r.Status == "Pending")
                                                      .ToList();
                
                var displayList = reservations.Select(r => new 
                { 
                    r.ReservationId,
                    Display = $"#{r.ReservationId} - {r.CustomerName} ({r.StartDate:d} to {r.EndDate:d})" 
                }).ToList();

                cmbReservation.DataSource = displayList;
                cmbReservation.DisplayMember = "Display";
                cmbReservation.ValueMember = "ReservationId";
                cmbReservation.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"Error loading reservations: {ex.Message}");
            }
        }

        private void cmbReservation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbReservation.SelectedValue is int rId)
            {
                var reservations = _reservationService.GetReservations(); 
                // Inefficient to get all again, but ok for now or caching. 
                // Better: find in the list we loaded, but we lost scope. 
                // Just fetching by ID would be better if Service supported it.
                // Assuming first match in 'reservations' local var if we had it.
                // I'll just re-fetch to keep it simple or filter the list again.
                _selectedReservation = reservations.FirstOrDefault(r => r.ReservationId == rId);

                if (_selectedReservation != null)
                {
                    txtCustomerDetails.Text = _selectedReservation.CustomerName;
                    txtVehicleDetails.Text = _selectedReservation.VehicleModel;
                    
                    // Fetch Current Mileage from Vehicle
                    var vehicle = _vehicleService.GetVehicleById(_selectedReservation.VehicleId);
                    if (vehicle != null)
                    {
                        txtMileage.Text = vehicle.Odometer.ToString();
                    }
                }
            }
        }

        private void btnStartRental_Click(object sender, EventArgs e)
        {
            if (_selectedReservation == null)
            {
                MessageBox.Show(@"Please select a reservation.");
                return;
            }

            if (!int.TryParse(txtMileage.Text, out int startMileage))
            {
                MessageBox.Show(@"Invalid Mileage.");
                return;
            }

            try
            {
                var rental = new Rental
                {
                    ReservationId = _selectedReservation.ReservationId,
                    VehicleId = _selectedReservation.VehicleId,
                    CustomerId = _selectedReservation.CustomerId,
                    ActualStartDate = DateTime.Now,
                    StartMileage = startMileage
                };

                _rentalService.CreateRental(rental);
                
                MessageBox.Show(@"Rental started successfully! Vehicle marked as Rented.", @"Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                // Clear and refresh
                txtCustomerDetails.Text = "";
                txtVehicleDetails.Text = "";
                txtMileage.Text = "";
                LoadReservations();
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"Error starting rental: {ex.Message}", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
