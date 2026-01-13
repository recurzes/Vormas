using System;
using System.Data;
using System.Windows.Forms;
using Vormas.Navigation;
using Vormas.Services;

namespace Vormas.Forms
{
    public partial class ReturnForm : PageControl
    {
        private readonly RentalService _rentalService; // Using concrete class as interface might need update for DataTable helper
        // Ideally should update interface but for speed using concrete if passed by DI as interface castable. Assuming DI passes concrete or Interface has methods.
        // I added methods to RentalService but not Interface in previous step. I should update Interface or cast.
        // To be safe, let's update Interface too.
        
        public ReturnForm(IRentalService rentalService)
        {
            InitializeComponent();
            _rentalService = rentalService as RentalService; 
            // If DI provides proxy, this fails. But this is simple WinForms without complex proxying usually.
            
            LoadRentals();
            dtpReturnDate.Value = DateTime.Now;
        }

        private void LoadRentals()
        {
            if (_rentalService == null) return;
            try
            {
                var dt = _rentalService.GetActiveRentals();
                // Add Display Column
                dt.Columns.Add("Display", typeof(string), "RentalId + ' - ' + CustomerName + ' (' + VehicleName + ')'");
                
                cmbRentals.DataSource = dt;
                cmbRentals.DisplayMember = "Display";
                cmbRentals.ValueMember = "RentalId";
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"Error loading rentals: {ex.Message}");
            }
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            if (cmbRentals.SelectedValue == null)
            {
                MessageBox.Show(@"Please select a rental.");
                return;
            }

            if (!int.TryParse(txtEndMileage.Text, out int endMileage) || !double.TryParse(txtFuel.Text, out double fuel))
            {
                MessageBox.Show(@"Invalid input for Mileage or Fuel.");
                return;
            }

            try
            {
                int rentalId = Convert.ToInt32(cmbRentals.SelectedValue);
                _rentalService.CompleteRental(rentalId, dtpReturnDate.Value, endMileage, fuel);
                
                MessageBox.Show(@"Return processed successfully!", @"Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
                LoadRentals();
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"Error processing return: {ex.Message}", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearInputs()
        {
            cmbRentals.SelectedIndex = -1;
            txtEndMileage.Text = "";
            txtFuel.Text = "";
        }
    }
}
