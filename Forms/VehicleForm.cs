using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Vormas.Database;
using Vormas.Interfaces;
using Vormas.Models;
using Vormas.Navigation;
using Vormas.Services;

namespace Vormas.Forms
{
    public partial class VehicleForm : PageControl
    {
        private readonly IVehicleService _service;
        private Vehicle _selectedVehicle;
        private BindingSource _bindingSource;

        public VehicleForm(IVehicleService service)
        {
            InitializeComponent();

            _service = service ?? throw new ArgumentNullException(nameof(service));
            _bindingSource = new BindingSource();

            _selectedVehicle = new Vehicle();
            ConfigureGrid();
            InitializeData();
        }
        
        public VehicleForm(): this(null) {}

        private void InitializeData()
        {
            if (_service == null) return;
            
            SetCategories(_service.GetVehicleCategories());
            SetStatuses(_service.GetVehicleStatuses());
            
            LoadVehicles();
        }

        private void LoadVehicles()
        {
            try
            {
                var vehicles = _service.GetAllVehicles();
                _bindingSource.DataSource = vehicles;
                dgvVehicles.DataSource = _bindingSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"Error loading vehicles: {ex.Message}", @"Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ConfigureGrid()
        {
            dgvVehicles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVehicles.MultiSelect = false;
            dgvVehicles.ReadOnly = true;
            dgvVehicles.AutoGenerateColumns = false;
            
            dgvVehicles.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "VehicleId", HeaderText = @"ID", Width = 40 });
            dgvVehicles.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Make", HeaderText = @"Make" });
            dgvVehicles.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Model", HeaderText = @"Model" });
            dgvVehicles.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Year", HeaderText = @"Year", Width = 50 });
            dgvVehicles.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Category", HeaderText = @"Category" });
            dgvVehicles.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Status", HeaderText = @"Status" });
            dgvVehicles.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DailyRate", HeaderText = @"Daily Rate", DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" } });
            
            dgvVehicles.SelectionChanged += DgvVehicles_SelectionChanged;
        }

        private void VehicleForm_Load(object sender, EventArgs e)
        {
        }

        public void SetCategories(IEnumerable<string> categories)
        {
            cmbCategory.DataSource = categories;
        }

        public void SetStatuses(IEnumerable<string> statuses)
        {
            cmbStatus.DataSource = statuses;
        }

        private void DgvVehicles_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvVehicles.CurrentRow != null)
            {
                var vehicle = dgvVehicles.CurrentRow.DataBoundItem as Vehicle;
                if (vehicle != null)
                {
                    PopulateFields(vehicle);
                }
            }
        }

        private void PopulateFields(Vehicle vehicle)
        {
            _selectedVehicle = vehicle;
            txtMake.Text = vehicle.Make;
            txtModel.Text = vehicle.Model;
            txtYear.Text = vehicle.Year.ToString();
            txtColor.Text = vehicle.Color;
            txtLicensePlate.Text = vehicle.LicensePlate;
            txtVin.Text = vehicle.VIN;
            cmbCategory.SelectedItem = vehicle.Category;
            cmbTransmission.SelectedItem = vehicle.Transmission;
            cmbFuelType.SelectedItem = vehicle.FuelType;
            txtSeatingCapacity.Text = vehicle.SeatingCapacity.ToString();
            txtDailyRate.Text = vehicle.DailyRate.ToString();
            cmbStatus.SelectedItem = vehicle.Status;
            
            if (!string.IsNullOrEmpty(vehicle.ImagePath) && File.Exists(vehicle.ImagePath))
            {
                 pbVehicleImage.Image = Image.FromFile(vehicle.ImagePath);
            }
            else
            {
                pbVehicleImage.Image = null;
            }
        }
        
        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMake.Text) || string.IsNullOrWhiteSpace(txtModel.Text))
            {
                MessageBox.Show(@"Make and Model are required.", @"Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtYear.Text, out int year)) { MessageBox.Show(@"Invalid Year"); return; }
            if (!decimal.TryParse(txtDailyRate.Text, out decimal rate)) { MessageBox.Show(@"Invalid Rate"); return; }
            if (!int.TryParse(txtSeatingCapacity.Text, out int capacity)) { MessageBox.Show(@"Invalid Capacity"); return; }

            _selectedVehicle.Make = txtMake.Text;
            _selectedVehicle.Model = txtModel.Text;
            _selectedVehicle.Year = year;
            _selectedVehicle.Color = txtColor.Text;
            _selectedVehicle.LicensePlate = txtLicensePlate.Text;
            _selectedVehicle.VIN = txtVin.Text;
            _selectedVehicle.Category = cmbCategory.SelectedItem?.ToString();
            _selectedVehicle.Transmission = cmbTransmission.SelectedItem?.ToString();
            _selectedVehicle.FuelType = cmbFuelType.SelectedItem?.ToString();
            _selectedVehicle.SeatingCapacity = capacity;
            _selectedVehicle.DailyRate = rate;
            _selectedVehicle.Status = cmbStatus.SelectedItem?.ToString();
            _selectedVehicle.ImagePath = pbVehicleImage.Tag as string ?? _selectedVehicle.ImagePath;

            try
            {
                if (_selectedVehicle.VehicleId == 0)
                {
                    _service.AddVehicle(_selectedVehicle);
                    MessageBox.Show(@"Vehicle added successfully.", @"Success", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    _service.UpdateVehicle(_selectedVehicle);
                    MessageBox.Show(@"Vehicle updated successfully.", @"Success", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }

                LoadVehicles();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"Error saving vehicle: {ex.Message}", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (_selectedVehicle.VehicleId > 0)
            {
                if (MessageBox.Show(@"Are you sure you want to delete this vehicle?", @"Confirm Delete",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        _service.DeleteVehicle(_selectedVehicle.VehicleId);
                        LoadVehicles();
                        ClearInputs();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($@"Error deleting vehicle: {ex.Message}", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        public void ClearInputs()
        {
            _selectedVehicle = new Vehicle(); 
            txtModel.Text = "";
            txtYear.Text = "";
            txtColor.Text = "";
            txtLicensePlate.Text = "";
            txtVin.Text = "";
            cmbCategory.SelectedIndex = -1;
            cmbTransmission.SelectedIndex = -1;
            cmbFuelType.SelectedIndex = -1;
            txtSeatingCapacity.Text = "";
            txtDailyRate.Text = "";
            cmbStatus.SelectedIndex = -1;
            pbVehicleImage.Image = null;
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void btnBrowseImage_Click_1(object sender, EventArgs e)
        {
            
            if (ofdImage.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string filePath = ofdImage.FileName;
                    pbVehicleImage.Image = Image.FromFile(filePath);
                    pbVehicleImage.Tag = filePath; // Store path in Tag
                }
                catch (Exception ex)
                {
                    MessageBox.Show($@"Error loading image: {ex.Message}");
                }
            }
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            SearchVehicles(txtSearch.Text);
        }

        private void SearchVehicles(string query)
        {
            if (_bindingSource.DataSource is List<Vehicle> allVehicles)
            {
                if (string.IsNullOrWhiteSpace(query))
                {
                    _bindingSource.DataSource = _service.GetAllVehicles();
                }
                else
                {
                    var filtered = allVehicles.FindAll(v => 
                        (v.Make != null && v.Make.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0) ||
                        (v.Model != null && v.Model.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0) ||
                        (v.LicensePlate != null && v.LicensePlate.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0));
                    _bindingSource.DataSource = filtered;
                }
                _bindingSource.ResetBindings(false);
            }
        }
 

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
        }

        private void pbVehicleImage_Click(object sender, EventArgs e)
        {
        }

        private void dgvVehicles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cmbTransmission_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
