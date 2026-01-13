using System;
using System.Data;
using System.Windows.Forms;
using Vormas.Navigation;
using Vormas.Services;

namespace Vormas.Forms
{
    public partial class BillingForm : PageControl
    {
        private readonly IRentalService _rentalService;
        private int _selectedRentalId = -1;

        public BillingForm(IRentalService rentalService)
        {
            InitializeComponent();
            _rentalService = rentalService ?? throw new ArgumentNullException(nameof(rentalService));
            LoadUnpaidInvoices();
        }

        private void LoadUnpaidInvoices()
        {
            try
            {
                var dt = _rentalService.GetUnpaidRentals();
                dgvInvoices.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"Error loading invoices: {ex.Message}");
            }
        }

        private void dgvInvoices_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvInvoices.CurrentRow != null)
            {
                _selectedRentalId = Convert.ToInt32(dgvInvoices.CurrentRow.Cells["RentalId"].Value);
                decimal balance = Convert.ToDecimal(dgvInvoices.CurrentRow.Cells["BalanceDue"].Value);
                txtAmount.Text = balance.ToString("F2");
            }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (_selectedRentalId < 0)
            {
                MessageBox.Show(@"Please select a rental/invoice.");
                return;
            }

            if (!decimal.TryParse(txtAmount.Text, out decimal amount) || amount <= 0)
            {
                MessageBox.Show(@"Invalid amount.");
                return;
            }
            
            if (cmbMethod.SelectedIndex == -1)
            {
                MessageBox.Show(@"Select payment method.");
                return;
            }

            try
            {
                _rentalService.ProcessPayment(_selectedRentalId, amount, cmbMethod.SelectedItem.ToString());
                MessageBox.Show(@"Payment processed successfully.");
                LoadUnpaidInvoices();
                txtAmount.Text = "";
                _selectedRentalId = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"Error processing payment: {ex.Message}");
            }
        }
    }
}
