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
        private readonly BindingSource _bindingSource;

        public VehicleForm(IVehicleService service)
        {
            InitializeComponent();

            _service = service ?? throw new ArgumentNullException(nameof(service));
            _bindingSource = new BindingSource();

            _selectedVehicle = new Vehicle();
            ConfigureGrid();
            InitializeData();
        }


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
                LoadCategories(vehicles);
                _bindingSource.DataSource = vehicles;
                dgvVehicles.DataSource = _bindingSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"Error loading vehicles: {ex.Message}", @"Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadCategories(List<Vehicle> vehicles)
        {
            foreach (Vehicle vehicle in vehicles)
            {
                switch (vehicle.CategoryId)
                {
                    case "1":
                        vehicle.CategoryId = "Hatchback";
                        break;
                    case "2":
                        vehicle.CategoryId = "Sedan";
                        break;
                    case "3":
                        vehicle.CategoryId = "SUV";
                        break;
                    case "4":
                        vehicle.CategoryId = "Pickup";
                        break;
                    case "5":
                        vehicle.CategoryId = "Van/Minibus";
                        break;
                }
            }
        }

        private void ConfigureGrid()
        {
            dgvVehicles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVehicles.MultiSelect = false;
            dgvVehicles.ReadOnly = true;
            dgvVehicles.AutoGenerateColumns = false;
            
            dgvVehicles.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "VehicleCode", HeaderText = @"Vehicle Code", Width = 80 });
            dgvVehicles.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "VehicleId", HeaderText = @"ID", Width = 40 });
            dgvVehicles.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Make", HeaderText = @"Make" });
            dgvVehicles.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Model", HeaderText = @"Model" });
            dgvVehicles.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Year", HeaderText = @"Year", Width = 50 });
            dgvVehicles.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "CategoryId", HeaderText = @"CategoryId" });
            dgvVehicles.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Odometer", HeaderText = @"Current Mileage" });
            dgvVehicles.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Status", HeaderText = @"Status" });
            // dgvVehicles.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DailyRate", HeaderText = @"Daily Rate", DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" } });
            
            dgvVehicles.SelectionChanged += DgvVehicles_SelectionChanged;
        }

        private void VehicleForm_Load(object sender, EventArgs e)
        {
        }

        private void SetCategories(IEnumerable<string> categories)
        {
            cmbCategory.DataSource = categories;
        }

        private void SetStatuses(IEnumerable<string> statuses)
        {
            cmbStatus.DataSource = statuses;
        }

        private void DgvVehicles_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvVehicles.CurrentRow?.DataBoundItem is Vehicle vehicle)
            {
                PopulateFields(vehicle);
            }
        }

        private void PopulateFields(Vehicle vehicle)
        {
            _selectedVehicle = vehicle;
            txtVehicleCode.Text = vehicle.VehicleCode;
            txtMake.Text = vehicle.Make;
            txtModel.Text = vehicle.Model;
            txtYear.Text = vehicle.Year.ToString();
            txtColor.Text = vehicle.Color;
            txtLicensePlate.Text = vehicle.LicensePlate;
            txtVin.Text = vehicle.VIN;
            cmbCategory.SelectedItem = vehicle.CategoryId;
            cmbTransmission.SelectedItem = vehicle.Transmission;
            cmbFuelType.SelectedItem = vehicle.FuelType;
            txtSeatingCapacity.Text = vehicle.SeatingCapacity.ToString();
            txtCurrentMileage.Text = vehicle.Odometer.ToString();
            cmbStatus.SelectedItem = vehicle.Status;
            
            pbVehicleImage.Image?.Dispose();
            pbVehicleImage.Image = null;

            if (!string.IsNullOrEmpty(vehicle.ImagePath))
            {
                string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, vehicle.ImagePath);
                if (File.Exists(fullPath))
                {
                    try 
                    {
                        using (var stream = new FileStream(fullPath, FileMode.Open, FileAccess.Read))
                        {
                            pbVehicleImage.Image = Image.FromStream(stream);
                        }
                    }
                    catch (Exception) { /* Handle or ignore loading errors */ }
                }
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
            if (!int.TryParse(txtSeatingCapacity.Text, out int capacity)) { MessageBox.Show(@"Invalid Capacity"); return; }
            if (!int.TryParse(txtCurrentMileage.Text, out int currentMileage)) { MessageBox.Show(@"Invalid Current Mileage"); return; }

            _selectedVehicle.VehicleCode = txtVehicleCode.Text;
            _selectedVehicle.Make = txtMake.Text;
            _selectedVehicle.Model = txtModel.Text;
            _selectedVehicle.Year = year;
            _selectedVehicle.Color = txtColor.Text;
            _selectedVehicle.LicensePlate = txtLicensePlate.Text;
            _selectedVehicle.VIN = txtVin.Text;
            _selectedVehicle.CategoryId = cmbCategory.SelectedItem?.ToString();
            _selectedVehicle.Transmission = cmbTransmission.SelectedItem?.ToString();
            _selectedVehicle.FuelType = cmbFuelType.SelectedItem?.ToString();
            _selectedVehicle.SeatingCapacity = capacity;
            _selectedVehicle.Odometer = currentMileage;
            _selectedVehicle.Status = cmbStatus.SelectedItem?.ToString();

            // Handle Image Saving
            if (pbVehicleImage.Tag is string sourcePath && File.Exists(sourcePath))
            {
                try
                {
                    string imagesDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "Vehicles");
                    if (!Directory.Exists(imagesDir))
                    {
                        Directory.CreateDirectory(imagesDir);
                    }

                    string extension = Path.GetExtension(sourcePath);
                    string newFileName = $"{Guid.NewGuid()}{extension}";
                    string destPath = Path.Combine(imagesDir, newFileName);

                    File.Copy(sourcePath, destPath, true);
                    
                    // Save relative path
                    _selectedVehicle.ImagePath = Path.Combine("Images", "Vehicles", newFileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($@"Error saving image: {ex.Message}", @"Error");
                    return; 
                }
            }

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
            if (_selectedVehicle.VehicleId <= 0) return;
            if (MessageBox.Show(@"Are you sure you want to delete this vehicle?", @"Confirm Delete",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
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

        private void ClearInputs()
        {
            _selectedVehicle = new Vehicle();
            txtVehicleCode.Text = "";
            txtMake.Text = "";
            txtModel.Text = "";
            txtYear.Text = "";
            txtColor.Text = "";
            txtLicensePlate.Text = "";
            txtVin.Text = "";
            cmbCategory.SelectedIndex = -1;
            cmbTransmission.SelectedIndex = -1;
            cmbFuelType.SelectedIndex = -1;
            txtSeatingCapacity.Text = "";
            txtCurrentMileage.Text = "";
            cmbStatus.SelectedIndex = -1;
            
            pbVehicleImage.Image?.Dispose();
            pbVehicleImage.Image = null;
            pbVehicleImage.Tag = null;
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void btnBrowseImage_Click_1(object sender, EventArgs e)
        {
            if (ofdImage.ShowDialog() != DialogResult.OK) return;
            try
            {
                string filePath = ofdImage.FileName;
                // Load without locking the file
                using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    pbVehicleImage.Image = Image.FromStream(stream);
                }
                pbVehicleImage.Tag = filePath; 
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"Error loading image: {ex.Message}");
            }
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            SearchVehicles(txtSearch.Text);
        }

        private void SearchVehicles(string query)
        {
            var allVehicles = _service.GetAllVehicles();

            if (string.IsNullOrWhiteSpace(query))
            {
                _bindingSource.DataSource = allVehicles;
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
