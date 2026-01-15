using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
        private DriverLicense _existingLicense;
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
            ConfigureRentalHistoryGrid();
            InitializeData();
            ApplyModernStyling();
        }

        private void dgvCustomers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCustomers.CurrentRow?.DataBoundItem is Customer customer)
            {
                PopulateFields(customer);
                CheckDriverLicenseExists(customer.CustomerId);
                LoadCustomerHistory(customer.CustomerId);
            }
        }

        private void CheckDriverLicenseExists(int customerId)
        {
            try
            {
                _existingLicense = _service.GetDriverLicenseByCustomerId(customerId);
                if (_existingLicense != null)
                {
                    btnDriversLicense.Text = @"Edit Driver's License";
                    lblLicenseStatus.Text = $@"License: {_existingLicense.LicenseNumber}";
                }
                else
                {
                    btnDriversLicense.Text = @"Add Driver's License";
                    lblLicenseStatus.Text = "";
                }
            }
            catch (Exception ex)
            {
                _existingLicense = null;
                btnDriversLicense.Text = @"Add Driver's License";
                lblLicenseStatus.Text = "";
            }
        }

        private void btnDrivingRecords_Click(object sender, EventArgs e)
        {
            if (_selectedCustomer == null || _selectedCustomer.CustomerId == 0)
            {
                MessageBox.Show(@"Please select a customer first.", @"Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            using var form = new DrivingRecordForm(_service, _selectedCustomer.CustomerId, $"{_selectedCustomer.FirstName} {_selectedCustomer.LastName}");
            form.ShowDialog();
            LoadCustomerHistory(_selectedCustomer.CustomerId);
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
            _selectedCustomer.DateOfBirth = dtpBirthdate.Value;
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
            _selectedCustomer.ImagePathMain = pbCustomerImage.Tag as string ?? _selectedCustomer.ImagePathMain;

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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var searchText = txtSearch.Text.Trim().ToLower();
            if (string.IsNullOrWhiteSpace(searchText))
            {
                _bindingSource.Filter = null;
                LoadCustomers();
                return;
            }

            // Client-side filtering
            if (_bindingSource.DataSource is List<Customer> customers)
            {
                var filtered = customers.Where(c => 
                    c.CustomerId.ToString().Contains(searchText) ||
                    (c.FirstName?.ToLower().Contains(searchText) ?? false) ||
                    (c.LastName?.ToLower().Contains(searchText) ?? false)
                ).ToList();
                
                dgvCustomers.DataSource = filtered;
            }
        }

        // Helpers
        private void ConfigureGrid()
        {
            dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomers.MultiSelect = false;
            dgvCustomers.ReadOnly = true;
            dgvCustomers.AutoGenerateColumns = false;

            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "CustomerId", HeaderText = @"ID", Width = 50 });
            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "FirstName", HeaderText = @"First Name", Width = 100 });
            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "LastName", HeaderText = @"Last Name", Width = 100 });

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
            dtpBirthdate.Value = _selectedCustomer.DateOfBirth;
            txtEmergencyContactName.Text = _selectedCustomer.EmergencyContactName;
            txtEmergencyContactPhone.Text = _selectedCustomer.EmergencyContactPhone;
            var customerTypeItem = ((IEnumerable<CustomerTypeItem>)cmbCustomerType.DataSource)
                ?.FirstOrDefault(ct => ct.Value == _selectedCustomer.CustomerType.ToString());
            cmbCustomerType.SelectedItem = customerTypeItem;
            chkIsBlacklisted.Checked = _selectedCustomer.IsBlacklisted;
            
            if (!string.IsNullOrEmpty(customer.ImagePathMain) && File.Exists(customer.ImagePathMain))
            {
                pbCustomerImage.Image = Image.FromFile(customer.ImagePathMain);
            }
            else
            {
                pbCustomerImage.Image = null;
            }
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
            _existingLicense = null;
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
            pbCustomerImage.Image = null;
            btnDriversLicense.Text = @"Add Driver's License";
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
            using var licenseForm = _existingLicense != null 
                ? new DriverLicenseForm(_existingLicense) 
                : new DriverLicenseForm();
            
            if (licenseForm.ShowDialog() != DialogResult.OK) return;
            
            _pendingLicense = licenseForm.License;
            if (_existingLicense != null)
            {
                _pendingLicense.CustomerId = _existingLicense.CustomerId;
            }
            lblLicenseStatus.Text = $@"License: {_pendingLicense.LicenseNumber}";
        }

        private void btnBrowseImage_Click(object sender, EventArgs e)
        {
            if (ofdImage.ShowDialog() != DialogResult.OK) return;
            try
            {
                string filePath = ofdImage.FileName;
                pbCustomerImage.Image = Image.FromFile(filePath);
                pbCustomerImage.Tag = filePath; // Store path in Tag
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"Error loading image: {ex.Message}");
            }
        }

        private void ConfigureRentalHistoryGrid()
        {
            dgvRentalHistory.AutoGenerateColumns = false;
            dgvRentalHistory.Columns.Clear();
            dgvRentalHistory.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "RentalId", HeaderText = @"Rental ID", Width = 70 });
            dgvRentalHistory.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "VehicleInfo", HeaderText = @"Vehicle", Width = 180 });
            dgvRentalHistory.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "PickupDate", HeaderText = @"Pickup", Width = 120 });
            dgvRentalHistory.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "ReturnDate", HeaderText = @"Return", Width = 120 });
            dgvRentalHistory.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "Status", HeaderText = @"Status", Width = 80 });
            dgvRentalHistory.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "TotalAmount", HeaderText = @"Amount", Width = 100 });
            dgvRentalHistory.Columns.Add(new DataGridViewCheckBoxColumn
                { DataPropertyName = "WasLate", HeaderText = @"Late", Width = 50 });
            dgvRentalHistory.Columns.Add(new DataGridViewCheckBoxColumn
                { DataPropertyName = "HasDamage", HeaderText = @"Damage", Width = 60 });
        }

        private void LoadCustomerHistory(int customerId)
        {
            try
            {
                var history = _service.GetCustomerHistory(customerId);
                

                dgvRentalHistory.DataSource = history.RentalHistory;

                // Center align checkbox columns
                if (dgvRentalHistory.Columns["Late"] != null)
                {
                    dgvRentalHistory.Columns["Late"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvRentalHistory.Columns["Late"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                if (dgvRentalHistory.Columns["Damage"] != null)
                {
                    dgvRentalHistory.Columns["Damage"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvRentalHistory.Columns["Damage"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
            catch
            {
                dgvRentalHistory.DataSource = null;
            }
        }
        private void ApplyModernStyling()
        {
            // Main Colors
            var primaryColor = Color.FromArgb(0, 120, 215);
            var backgroundColor = Color.White;
            var textFont = new Font("Segoe UI", 10F);

            this.BackColor = backgroundColor;
            this.Font = textFont;

            // Buttons
            foreach (var btn in new[] { btnSave, btnSearch, btnBrowseImage, btnDriversLicense, btnDrivingRecords, btnClear, btnDelete })
            {
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.Cursor = Cursors.Hand;
                btn.Height = 35;
            }

            btnSave.BackColor = primaryColor;
            btnSave.ForeColor = Color.White;
            
            btnSearch.BackColor = primaryColor;
            btnSearch.ForeColor = Color.White;

            btnBrowseImage.BackColor = Color.FromArgb(240, 240, 240);
            btnBrowseImage.ForeColor = Color.Black;

            // Delete - Red
            btnDelete.BackColor = Color.IndianRed;
            btnDelete.ForeColor = Color.White;

            // New (Clear) - Green
            btnClear.BackColor = Color.SeaGreen;
            btnClear.ForeColor = Color.White;

            // Grids
            ConfigureModernGrid(dgvCustomers);
            ConfigureModernGrid(dgvRentalHistory);
            
            // TextBoxes
            foreach(Control c in pnlSearch.Controls) if(c is TextBox t) t.Height = 25;
        }

        private void ConfigureModernGrid(DataGridView grid)
        {
            grid.BackgroundColor = Color.White;
            grid.BorderStyle = BorderStyle.None;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.EnableHeadersVisualStyles = false;

            // Header Style
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.DimGray;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(245, 245, 245);
            grid.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.DimGray;
            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            // Row Style
            var rowStyle = new DataGridViewCellStyle();
            rowStyle.BackColor = Color.White;
            rowStyle.ForeColor = Color.Black;
            rowStyle.SelectionBackColor = Color.FromArgb(0, 120, 215); // Primary Blue
            rowStyle.SelectionForeColor = Color.White; // Force White Text
            rowStyle.Font = new Font("Segoe UI", 10F);

            grid.DefaultCellStyle = rowStyle;
            grid.RowsDefaultCellStyle = rowStyle;
            
            // Ensure alternating rows don't override the selection color
            grid.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 120, 215);
            grid.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.White;

            grid.RowHeadersVisible = false;
            grid.RowTemplate.Height = 40;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}