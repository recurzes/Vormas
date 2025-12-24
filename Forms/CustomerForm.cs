using System;
using System.Windows.Forms;
using Vormas.Interfaces;
using Vormas.Models;
using Vormas.Navigation;

namespace Vormas.Forms
{
    public partial class CustomerForm : PageControl
    {
        private DriverLicense _pendingLicense;
        private readonly ICustomerService _service;
        private Customer _selectedCustomer;
        private readonly BindingSource _bindingSource;
        public CustomerForm(ICustomerService service)
        {
            InitializeComponent();

            _service = service ?? throw new ArgumentNullException(nameof(service));
            _bindingSource = new BindingSource();

            _selectedCustomer = new Customer();
            
            ConfigureGrid();
        }

        private void ConfigureGrid()
        {
            dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomers.MultiSelect = false;
            dgvCustomers.ReadOnly = true;
            dgvCustomers.AutoGenerateColumns = false;

            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "CustomerId", HeaderText = @"Customer Id", Width = 60 });
            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "FirstName", HeaderText = @"First Name", Width = 60 });
            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "LastName", HeaderText = @"Last Name", Width = 60 });
            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Address", HeaderText = @"Address", Width = 60 });
            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Email", HeaderText = @"Email", Width = 60 });
            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Phone", HeaderText = @"Phone", Width = 60 });
            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "BirthDate", HeaderText = @"Birth Date", Width = 60 });
            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "CustomerType", HeaderText = @"Customer Type", Width = 60 });
            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "EmergencyContactName", HeaderText = @"Emergency Contact Name", Width = 80 });
            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "EmergencyContactPhone", HeaderText = @"Emergency Contact Phone", Width = 80 });
            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "IsBlacklisted", HeaderText = @"Blacklisted", Width = 60 });

            dgvCustomers.SelectionChanged += dgvCustomers_SelectionChanged;
        }


        private void dgvCustomers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCustomers.CurrentRow?.DataBoundItem is Customer customer)
            {
                PopulateFields(customer);
            }
        }

        private void PopulateFields(Customer customer)
        {
            _selectedCustomer = customer;
            txtFirstName.Text = _selectedCustomer.FirstName;
            txtLastName.Text = _selectedCustomer.LastName;
            txtAddress.Text = _selectedCustomer.Address;
            txtEmail.Text = _selectedCustomer.Email;
            txtPhone.Text = _selectedCustomer.Phone;
            dtpBirthdate.Value = _selectedCustomer.BirthDate;
            txtEmergencyContactName.Text = _selectedCustomer.EmergencyContactName;
            txtEmergencyContactPhone.Text = _selectedCustomer.EmergencyContactPhone;
            cmbCustomerType.SelectedItem = _selectedCustomer.CustomerType;
            chkIsBlacklisted.Checked = _selectedCustomer.IsBlacklisted;
        }

        private void InitializeData()
        {
            if (_service == null) return;
            
        }

        private void btnDriversLicense_Click(object sender, EventArgs e)
        {
            using (var licenseForm = new DriverLicenseForm())
            {
                if (licenseForm.ShowDialog() == DialogResult.OK)
                {
                    _pendingLicense = licenseForm.License;
                    lblLicenseStatus.Text = $@"License: {_pendingLicense.LicenseNumber}";
                }
            }
        }
    }
}