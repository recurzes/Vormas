using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Vormas.Database;
using Vormas.Interfaces;
using Vormas.Models;
using Vormas.Services;

namespace Vormas.Forms
{
    public partial class ReservationForm : Form
    {
        private readonly IReservationService _reservationService;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly ICustomerManager _customerManager;
        
        // Caching list to calculate costs, etc.
        private List<Vehicle> _allVehicles;

        public ReservationForm(IReservationService reservationService, IVehicleRepository vehicleRepository, ICustomerManager customerManager)
        {
            InitializeComponent();
            
            _reservationService = reservationService ?? throw new ArgumentNullException(nameof(reservationService));
            _vehicleRepository = vehicleRepository ?? throw new ArgumentNullException(nameof(vehicleRepository));
            _customerManager = customerManager ?? throw new ArgumentNullException(nameof(customerManager));

            Load += ReservationForm_Load;
            btnCheckAvailability.Click += BtnCheckAvailability_Click;
            btnCreateReservation.Click += BtnCreateReservation_Click;
            comboVehicles.SelectedIndexChanged += ComboVehicles_SelectedIndexChanged;
            dtpStartDate.ValueChanged += DateChanged;
            dtpEndDate.ValueChanged += DateChanged;
        }

        // Default constructor for designer support or simple testing if needed (optional, but safer to force DI)
        // public ReservationForm() : this(new ReservationService(new ReservationDbContext()), new VehicleDbContext(), new CustomerManager(new CustomerDbContext())) { }

        private void ReservationForm_Load(object sender, EventArgs e)
        {
            LoadVehicles();
            LoadCustomers();
            
            // Set some defaults
            dtpStartDate.Value = DateTime.Now;
            dtpEndDate.Value = DateTime.Now.AddDays(1);
        }

        private void LoadVehicles()
        {
            try
            {
                _allVehicles = _vehicleRepository.GetAllVehicles();
                // Filter only available/active vehicles if needed, but per requirements we check dates primarily.
                // Binding to ComboBox
                comboVehicles.DataSource = _allVehicles;
                comboVehicles.DisplayMember = "Make"; // Display Make + Model ideally
                // Let's format the display
                comboVehicles.Format += (s, e) => 
                {
                    if (e.ListItem is Vehicle v)
                    {
                        e.Value = $"{v.Make} {v.Model} ({v.LicensePlate})";
                    }
                };
                comboVehicles.ValueMember = "VehicleId";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading vehicles: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCustomers()
        {
            try
            {
                var customers = _customerManager.GetALlCustomers();
                comboCustomers.DataSource = customers;
                comboCustomers.DisplayMember = "FirstName"; // Use Full Mame if available, or formatting
                 comboCustomers.Format += (s, e) => 
                {
                    if (e.ListItem is Customer c)
                    {
                        e.Value = $"{c.FirstName} {c.LastName}";
                    }
                };
                comboCustomers.ValueMember = "CustomerId";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading customers: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DateChanged(object sender, EventArgs e)
        {
            // Reset availability status when dates change
            lblAvailabilityStatus.Text = "CHECK NEEDED";
            lblAvailabilityStatus.ForeColor = Color.Orange;
            btnCreateReservation.Enabled = false;
            CalculateEstimatedCost();
        }

        private void ComboVehicles_SelectedIndexChanged(object sender, EventArgs e)
        {
             // Reset availability status when vehicle changes
            lblAvailabilityStatus.Text = "CHECK NEEDED";
            lblAvailabilityStatus.ForeColor = Color.Orange;
            btnCreateReservation.Enabled = false;
            CalculateEstimatedCost();
        }

        private void CalculateEstimatedCost()
        {
            if (comboVehicles.SelectedItem is Vehicle selectedVehicle && dtpStartDate.Value < dtpEndDate.Value)
            {
                TimeSpan duration = dtpEndDate.Value.Date - dtpStartDate.Value.Date;
                int days = (int)Math.Ceiling(duration.TotalDays);
                if (days < 1) days = 1;

                decimal cost = days * selectedVehicle.DailyRate;
                lblTotalCostValue.Text = cost.ToString("C");
            }
            else
            {
                 lblTotalCostValue.Text = "$0.00";
            }
        }

        private void BtnCheckAvailability_Click(object sender, EventArgs e)
        {
            if (comboVehicles.SelectedItem == null)
            {
                MessageBox.Show("Please select a vehicle.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var vehicle = (Vehicle)comboVehicles.SelectedItem;
                
              
                var repo = new ReservationDbContext();
                bool available = repo.CheckVehicleAvailability(vehicle.VehicleId, dtpStartDate.Value, dtpEndDate.Value);

                if (available)
                {
                    lblAvailabilityStatus.Text = "AVAILABLE";
                    lblAvailabilityStatus.ForeColor = Color.Green;
                    btnCreateReservation.Enabled = true;
                }
                else
                {
                    lblAvailabilityStatus.Text = "UNAVAILABLE";
                    lblAvailabilityStatus.ForeColor = Color.Red;
                    btnCreateReservation.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking availability: {ex.Message}");
            }
        }

        private void BtnCreateReservation_Click(object sender, EventArgs e)
        {
             if (comboVehicles.SelectedItem == null || comboCustomers.SelectedItem == null)
            {
                MessageBox.Show("Please select both a vehicle and a customer.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Vehicle vehicle = (Vehicle)comboVehicles.SelectedItem;
                Customer customer = (Customer)comboCustomers.SelectedItem;
                
                // Calculate Cost
                 TimeSpan duration = dtpEndDate.Value.Date - dtpStartDate.Value.Date;
                int days = (int)Math.Ceiling(duration.TotalDays);
                if (days < 1) days = 1;
                decimal totalCost = days * vehicle.DailyRate;

                var reservation = new Reservation
                {
                    VehicleId = vehicle.VehicleId,
                    CustomerId = customer.CustomerId,
                    StartDate = dtpStartDate.Value,
                    EndDate = dtpEndDate.Value,
                    TotalCost = totalCost,
                    CreatedBy = 1 // Hardcoded User ID for now, as Auth wasn't in scope/passed
                };

                _reservationService.CreateReservation(reservation);
                
                MessageBox.Show("Reservation created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to create reservation: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
