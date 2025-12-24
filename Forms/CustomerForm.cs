using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Vormas.Interfaces;
using Vormas.Models;
using Vormas.Navigation;
using Vormas.Services;

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
            InitializeData();
        }

        private void dgvCustomers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCustomers.CurrentRow?.DataBoundItem is Customer customer)
            {
                PopulateFields(customer);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) || string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show(@"First Name and Last Name are required.", @"Validation Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            _selectedCustomer.FirstName = txtFirstName.Text;
            _selectedCustomer.LastName = txtLastName.Text;
            _selectedCustomer.BirthDate = dtpBirthdate.Value;
            _selectedCustomer.Address = txtAddress.Text;
            _selectedCustomer.Email = txtEmail.Text;
            _selectedCustomer.Phone = txtPhone.Text;
            if (cmbCustomerType.SelectedItem is CustomerTypeItem selectedType &&
                Enum.TryParse<CustomerType>(selectedType.Value, out var customerType))
            {
                _selectedCustomer.CustomerType = customerType;
            }
            else
            {
                MessageBox.Show(@"Please select a valid customer type.", @"Validation Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            _selectedCustomer.EmergencyContactName = txtEmergencyContactName.Text;
            _selectedCustomer.EmergencyContactPhone = txtEmergencyContactPhone.Text;
            _selectedCustomer.IsBlacklisted = chkIsBlacklisted.Checked;

            try
            {
                if (_selectedCustomer.CustomerId == 0)
                {
                    _service.CreateCustomer(_selectedCustomer, _pendingLicense);
                    MessageBox.Show(@"Customer added successfully.", @"Success", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    _service.UpdateCustomer(_selectedCustomer, _pendingLicense);
                    MessageBox.Show(@"Customer updated successfully.", @"Success", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }

                LoadCustomers();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"Error saving customer: {ex.Message}", @"Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedCustomer.CustomerId <= 0) return;
            if (MessageBox.Show(@"Are you sure you want to delete this customer?", @"Confirm Delete",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

            try
            {
                _service.DeleteCustomer(_selectedCustomer.CustomerId);
                MessageBox.Show(@"Customer deleted successfully.", @"Success", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                LoadCustomers();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"Error deleting customer: {ex.Message}", @"Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        // Helpers
        private void ConfigureGrid()
        {
            dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomers.MultiSelect = false;
            dgvCustomers.ReadOnly = true;
            dgvCustomers.AutoGenerateColumns = false;

            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "CustomerId", HeaderText = @"Customer Id", Width = 60 });
            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "FirstName", HeaderText = @"First Name", Width = 60 });
            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "LastName", HeaderText = @"Last Name", Width = 60 });
            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "Address", HeaderText = @"Address", Width = 60 });
            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "Email", HeaderText = @"Email", Width = 60 });
            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "Phone", HeaderText = @"Phone", Width = 60 });
            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "BirthDate", HeaderText = @"Birth Date", Width = 60 });
            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "CustomerType", HeaderText = @"Customer Type", Width = 60 });
            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "EmergencyContactName", HeaderText = @"Emergency Contact Name", Width = 80 });
            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "EmergencyContactPhone", HeaderText = @"Emergency Contact Phone", Width = 80 });
            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "IsBlacklisted", HeaderText = @"Blacklisted", Width = 60 });

            dgvCustomers.SelectionChanged += dgvCustomers_SelectionChanged;
        }

        private void PopulateFields(Customer customer)
        {
            _selectedCustomer = customer;
            txtFirstName.Text = _selectedCustomer.FirstName;
            txtLastName.Text = _selectedCustomer.LastName;
            txtAddress.Text = _selectedCustomer.Address;
            txtEmail.Text = _selectedCustomer.Email;
            txtPhone.Text = _selectedCustomer.Phone;
            dtpBirthdate.Value = _selectedCustomer.BirthDate > dtpBirthdate.MinDate 
                ? _selectedCustomer.BirthDate 
                : DateTime.Today;
            txtEmergencyContactName.Text = _selectedCustomer.EmergencyContactName;
            txtEmergencyContactPhone.Text = _selectedCustomer.EmergencyContactPhone;
            var customerTypeItem = ((IEnumerable<CustomerTypeItem>)cmbCustomerType.DataSource)
                ?.FirstOrDefault(ct => ct.Value == _selectedCustomer.CustomerType.ToString());
            cmbCustomerType.SelectedItem = customerTypeItem;
            chkIsBlacklisted.Checked = _selectedCustomer.IsBlacklisted;
        }

        private void InitializeData()
        {
            if (_service == null) return;
            SetCustomerTypes(_service.GetCustomerTypes());

            LoadCustomers();
        }

        private void ClearInputs()
        {
            _selectedCustomer = new Customer();
            _pendingLicense = null;
            txtFirstName.Text = "";
            txtLastName.Text = "";
            dtpBirthdate.Value = DateTime.Now;
            txtAddress.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            cmbCustomerType.SelectedIndex = -1;
            txtEmergencyContactName.Text = "";
            txtEmergencyContactPhone.Text = "";
            chkIsBlacklisted.Checked = false;
            lblLicenseStatus.Text = "";
        }

        private void LoadCustomers()
        {
            try
            {
                var customers = _service.GetAll();
                _bindingSource.DataSource = customers;
                dgvCustomers.DataSource = _bindingSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"Error loading customers: {ex.Message}", @"Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void SetCustomerTypes(IEnumerable<CustomerTypeItem> customerTypes)
        {
            cmbCustomerType.DataSource = customerTypes;
            cmbCustomerType.DisplayMember = "Text";
            cmbCustomerType.ValueMember = "Value";
        }

        private void btnDriversLicense_Click(object sender, EventArgs e)
        {
            using var licenseForm = new DriverLicenseForm();
            if (licenseForm.ShowDialog() != DialogResult.OK) return;
            _pendingLicense = licenseForm.License;
            lblLicenseStatus.Text = $@"License: {_pendingLicense.LicenseNumber}";
        }
    }
}