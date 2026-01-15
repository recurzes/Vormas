using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
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
        private List<VehicleFeature> _allFeatures;
        private List<string> _currentImages;

        public VehicleForm(IVehicleService service)
        {
            InitializeComponent();

            _service = service ?? throw new ArgumentNullException(nameof(service));
            _bindingSource = new BindingSource();
            _currentImages = new List<string>();

            _selectedVehicle = new Vehicle();
            SetupRedesignedLayout();
            ConfigureGrid();
            InitializeData();
        }

        private void SetupRedesignedLayout()
        {
            // === MAIN LAYOUT ===
            // Clear existing controls from panels
            pnlInputs.Controls.Clear();
            Controls.Remove(pnlTop);
            
            // Configure Left Panel (Fixed Width, Form Side)
            pnlInputs.Width = 380;
            pnlInputs.Dock = DockStyle.Left;
            pnlInputs.Padding = new Padding(10);
            pnlInputs.AutoScroll = false;
            pnlInputs.BackColor = Color.White;

            // Configure Right Panel (Grid - Fill remaining space)
            dgvVehicles.Dock = DockStyle.Fill;
            dgvVehicles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Separator line
            var separator = new Panel { Width = 1, Dock = DockStyle.Left, BackColor = Color.FromArgb(220, 220, 220) };

            // === BUTTON PANEL (Bottom of Left Panel) ===
            var buttonPanel = new Panel { Dock = DockStyle.Bottom, Height = 50, Padding = new Padding(0, 10, 0, 0) };
            ConfigureButtons(buttonPanel);
            pnlInputs.Controls.Add(buttonPanel);

            // === SCROLLABLE FORM AREA ===
            var scrollPanel = new Panel { Dock = DockStyle.Fill, AutoScroll = true, Padding = new Padding(0) };

            // === GROUP E: Images (Fixed Size) ===
            var grpImages = CreateGroupBox("Vehicle Image", 150);
            
            // Picture box with fixed size
            pbVehicleImage.Size = new Size(180, 95);
            pbVehicleImage.Location = new Point(10, 20);
            pbVehicleImage.SizeMode = PictureBoxSizeMode.Zoom;
            pbVehicleImage.BorderStyle = BorderStyle.FixedSingle;
            
            // Buttons beside picture box
            btnAddImage.Size = new Size(90, 28);
            btnAddImage.Location = new Point(200, 30);
            btnAddImage.Text = "Add Image";
            
            btnRemoveImage.Size = new Size(90, 28);
            btnRemoveImage.Location = new Point(200, 65);
            btnRemoveImage.Text = "Remove";
            
            grpImages.Controls.AddRange(new Control[] { pbVehicleImage, btnAddImage, btnRemoveImage });
            scrollPanel.Controls.Add(grpImages);

            // === GROUP D: Features ===
            var grpFeatures = CreateGroupBox("Features", 110);
            clbFeatures.Dock = DockStyle.Fill;
            clbFeatures.MultiColumn = true;
            clbFeatures.ColumnWidth = 140;
            grpFeatures.Controls.Add(clbFeatures);
            scrollPanel.Controls.Add(grpFeatures);

            // === GROUP C: Specifications ===
            var grpSpecs = CreateGroupBox("Specifications", 140);
            var specsTable = CreateFieldTable(4);
            AddFieldRow(specsTable, 0, "Seats:", txtSeatingCapacity);
            AddFieldRow(specsTable, 1, "Cargo (L):", txtCargoCapacity);
            AddFieldRow(specsTable, 2, "Mileage:", txtCurrentMileage);
            AddFieldRow(specsTable, 3, "Status:", cmbStatus);
            grpSpecs.Controls.Add(specsTable);
            scrollPanel.Controls.Add(grpSpecs);

            // === GROUP B: Registration & Technical ===
            var grpTech = CreateGroupBox("Registration & Technical", 165);
            var techTable = CreateFieldTable(5);
            AddFieldRow(techTable, 0, "Plate:", txtLicensePlate);
            AddFieldRow(techTable, 1, "VIN:", txtVin);
            AddFieldRow(techTable, 2, "Category:", cmbCategory);
            AddFieldRow(techTable, 3, "Trans:", cmbTransmission);
            AddFieldRow(techTable, 4, "Fuel:", cmbFuelType);
            grpTech.Controls.Add(techTable);
            scrollPanel.Controls.Add(grpTech);

            // === GROUP A: Vehicle Identification (Top) ===
            var grpId = CreateGroupBox("Vehicle Identification", 140);
            var idTable = CreateFieldTable(4);
            AddFieldRow(idTable, 0, "Code:", txtVehicleCode);
            AddFieldRow(idTable, 1, "Make:", txtMake);
            AddFieldRow(idTable, 2, "Model:", txtModel);
            
            // Year and Color on same row
            var yearColorPanel = new Panel { Dock = DockStyle.Fill };
            txtYear.Width = 60; txtYear.Location = new Point(0, 0);
            var lblColorInline = new Label { Text = "Color:", Width = 40, Location = new Point(70, 3), Font = new Font("Segoe UI", 9F, FontStyle.Regular) };
            txtColor.Width = 70; txtColor.Location = new Point(110, 0);
            yearColorPanel.Controls.AddRange(new Control[] { txtYear, lblColorInline, txtColor });
            AddFieldRow(idTable, 3, "Year:", yearColorPanel);
            
            grpId.Controls.Add(idTable);
            scrollPanel.Controls.Add(grpId);

            // === SEARCH BAR WITH BUTTON (Top of Left Panel) ===
            var searchPanel = new Panel { Dock = DockStyle.Top, Height = 40, Padding = new Padding(0, 5, 0, 5) };
            
            txtSearch.Size = new Size(260, 25);
            txtSearch.Location = new Point(0, 5);
            txtSearch.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            
            btnSearch.Size = new Size(70, 25);
            btnSearch.Location = new Point(265, 5);
            btnSearch.Text = "Search";
            btnSearch.Click += (s, e) => SearchVehicles(txtSearch.Text);
            
            // Also search on Enter key
            txtSearch.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) SearchVehicles(txtSearch.Text); };
            
            searchPanel.Controls.Add(txtSearch);
            searchPanel.Controls.Add(btnSearch);
            
            pnlInputs.Controls.Add(scrollPanel);
            pnlInputs.Controls.Add(searchPanel);

            // === RIGHT PANEL (Search + Grid) ===
            var rightPanel = new Panel { Dock = DockStyle.Fill, Padding = new Padding(10) };
            rightPanel.Controls.Add(dgvVehicles);
            
            // Reassemble form
            Controls.Clear();
            Controls.Add(rightPanel);
            Controls.Add(separator);
            Controls.Add(pnlInputs);
        }

        private GroupBox CreateGroupBox(string title, int height)
        {
            return new GroupBox
            {
                Text = title,
                Dock = DockStyle.Top,
                Height = height,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Padding = new Padding(8),
                Margin = new Padding(0, 0, 0, 8)
            };
        }

        private TableLayoutPanel CreateFieldTable(int rows)
        {
            var table = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = rows,
                Padding = new Padding(0)
            };
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            for (int i = 0; i < rows; i++)
                table.RowStyles.Add(new RowStyle(SizeType.Absolute, 28));
            return table;
        }

        private void AddFieldRow(TableLayoutPanel table, int row, string labelText, Control input)
        {
            var lbl = new Label
            {
                Text = labelText,
                TextAlign = ContentAlignment.MiddleRight,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 9F, FontStyle.Regular)
            };
            input.Dock = DockStyle.Fill;
            input.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            table.Controls.Add(lbl, 0, row);
            table.Controls.Add(input, 1, row);
        }

        private void ConfigureButtons(Panel buttonPanel)
        {
            btnSave.Size = new Size(70, 32);
            btnSave.BackColor = ColorTranslator.FromHtml("#007ACC");
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;

            btnDelete.Size = new Size(70, 32);
            btnDelete.BackColor = ColorTranslator.FromHtml("#D9534F");
            btnDelete.ForeColor = Color.White;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnRetire.Size = new Size(70, 32);
            btnRetire.BackColor = Color.DarkOrange;
            btnRetire.ForeColor = Color.White;
            btnRetire.FlatStyle = FlatStyle.Flat;

            btnClear.Size = new Size(70, 32);
            btnClear.BackColor = ColorTranslator.FromHtml("#E0E0E0");
            btnClear.ForeColor = Color.Black;
            btnClear.FlatStyle = FlatStyle.Flat;

            var btnFlow = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false
            };
            btnFlow.Controls.AddRange(new Control[] { btnSave, btnDelete, btnRetire, btnClear });
            buttonPanel.Controls.Add(btnFlow);
        }


        private void InitializeData()
        {
            if (_service == null) return;
            
            SetCategories(_service.GetVehicleCategories());
            SetStatuses(_service.GetVehicleStatuses());
            LoadFeatures();
            
            LoadVehicles();
        }

        private void LoadFeatures()
        {
            _allFeatures = _service.GetAllFeatures();
            clbFeatures.Items.Clear();
            foreach (var feature in _allFeatures)
            {
                clbFeatures.Items.Add(feature.Name, false);
            }
        }

        private void LoadVehicles()
        {
            try
            {
                var vehicles = _service.GetAllVehicles();
                LoadCategories(vehicles);
                _bindingSource.DataSource = vehicles;
                dgvVehicles.DataSource = _bindingSource;
                _bindingSource.ResetBindings(false);
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
            
            dgvVehicles.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "VehicleCode", HeaderText = @"Vehicle Code", Width = 80 });
            dgvVehicles.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "VehicleId", HeaderText = @"ID", Width = 40 });
            dgvVehicles.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Make", HeaderText = @"Make" });
            dgvVehicles.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Model", HeaderText = @"Model" });
            dgvVehicles.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Year", HeaderText = @"Year", Width = 50 });
            dgvVehicles.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "CategoryName", HeaderText = @"Category" });
            dgvVehicles.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Odometer", HeaderText = @"Mileage" });
            dgvVehicles.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Status", HeaderText = @"Status" });
            
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
            
            // Use FindStringExact for reliable dropdown selection
            int categoryIndex = cmbCategory.FindStringExact(vehicle.CategoryId);
            if (categoryIndex == -1 && !string.IsNullOrEmpty(vehicle.CategoryName))
                categoryIndex = cmbCategory.FindStringExact(vehicle.CategoryName);
                
            cmbCategory.SelectedIndex = categoryIndex >= 0 ? categoryIndex : 0;
            
            int transIndex = cmbTransmission.FindStringExact(vehicle.Transmission);
            cmbTransmission.SelectedIndex = transIndex >= 0 ? transIndex : 0;
            
            int fuelIndex = cmbFuelType.FindStringExact(vehicle.FuelType);
            cmbFuelType.SelectedIndex = fuelIndex >= 0 ? fuelIndex : 0;
            
            txtSeatingCapacity.Text = vehicle.SeatingCapacity.ToString();
            txtCurrentMileage.Text = vehicle.Odometer.ToString();
            txtCargoCapacity.Text = vehicle.CargoCapacity.ToString();
            txtFuelEfficiency.Text = vehicle.FuelEfficiency.ToString();
            
            int statusIndex = cmbStatus.FindStringExact(vehicle.Status);
            cmbStatus.SelectedIndex = statusIndex >= 0 ? statusIndex : 0;
            
            if (!string.IsNullOrEmpty(vehicle.ImagePath) && File.Exists(vehicle.ImagePath))
            {
                 pbVehicleImage.Image = Image.FromFile(vehicle.ImagePath);
            }
            else
            {
                pbVehicleImage.Image = null;
            }

            LoadVehicleFeatures(vehicle.VehicleId);
            LoadVehicleImages(vehicle.VehicleId);
        }

        private void LoadVehicleFeatures(int vehicleId)
        {
            var selectedIds = _service.GetVehicleFeatureIds(vehicleId);
            for (int i = 0; i < clbFeatures.Items.Count; i++)
            {
                var feature = _allFeatures[i];
                clbFeatures.SetItemChecked(i, selectedIds.Contains(feature.FeatureId));
            }
        }

        private void LoadVehicleImages(int vehicleId)
        {
            _currentImages = _service.GetVehicleImages(vehicleId);
            lstImages.Items.Clear();
            foreach (var img in _currentImages)
            {
                lstImages.Items.Add(Path.GetFileName(img));
            }
        }
        
        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMake.Text) || string.IsNullOrWhiteSpace(txtModel.Text))
            {
                MessageBox.Show(@"Make and Model are required.", @"Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbCategory.SelectedIndex < 0)
            {
                MessageBox.Show(@"Please select a Category.", @"Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbStatus.SelectedIndex < 0)
            {
                MessageBox.Show(@"Please select a Status.", @"Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtYear.Text, out int year)) { MessageBox.Show(@"Invalid Year"); return; }
            if (!int.TryParse(txtSeatingCapacity.Text, out int capacity)) { MessageBox.Show(@"Invalid Capacity"); return; }
            if (!int.TryParse(txtCurrentMileage.Text, out int currentMileage)) { MessageBox.Show(@"Invalid Current Mileage"); return; }
            decimal.TryParse(txtCargoCapacity.Text, out decimal cargoCapacity);
            decimal.TryParse(txtFuelEfficiency.Text, out decimal fuelEfficiency);

            _selectedVehicle.VehicleCode = txtVehicleCode.Text;
            _selectedVehicle.Make = txtMake.Text;
            _selectedVehicle.Model = txtModel.Text;
            _selectedVehicle.Year = year;
            _selectedVehicle.Color = txtColor.Text;
            _selectedVehicle.LicensePlate = txtLicensePlate.Text;
            _selectedVehicle.VIN = txtVin.Text;
            _selectedVehicle.CategoryId = GetCategoryId(cmbCategory.SelectedItem?.ToString());
            _selectedVehicle.Transmission = cmbTransmission.SelectedItem?.ToString();
            _selectedVehicle.FuelType = cmbFuelType.SelectedItem?.ToString();
            _selectedVehicle.SeatingCapacity = capacity;
            _selectedVehicle.Odometer = currentMileage;
            _selectedVehicle.CargoCapacity = cargoCapacity;
            _selectedVehicle.FuelEfficiency = fuelEfficiency;
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
                    SaveVehicleFeatures(_selectedVehicle.VehicleId);
                    SaveVehicleImages(_selectedVehicle.VehicleId);
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

        private void SaveVehicleFeatures(int vehicleId)
        {
            var selectedFeatureIds = new List<int>();
            for (int i = 0; i < clbFeatures.Items.Count; i++)
            {
                if (clbFeatures.GetItemChecked(i))
                {
                    selectedFeatureIds.Add(_allFeatures[i].FeatureId);
                }
            }
            _service.SaveVehicleFeatures(vehicleId, selectedFeatureIds);
        }

        private void SaveVehicleImages(int vehicleId)
        {
            _service.SaveVehicleImages(vehicleId, _currentImages);
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



        private void btnRetire_Click(object sender, EventArgs e)
        {
            if (_selectedVehicle.VehicleId <= 0) return;
            if (MessageBox.Show(@"Are you sure you want to retire this vehicle?", @"Confirm Retire",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            try
            {
                _service.RetireVehicle(_selectedVehicle.VehicleId);
                LoadVehicles();
                ClearInputs();
                MessageBox.Show(@"Vehicle retired successfully.", @"Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"Error retiring vehicle: {ex.Message}", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            txtCargoCapacity.Text = "";
            txtFuelEfficiency.Text = "";
            cmbStatus.SelectedIndex = -1;
            pbVehicleImage.Image = null;
            _currentImages.Clear();
            lstImages.Items.Clear();
            for (int i = 0; i < clbFeatures.Items.Count; i++)
            {
                clbFeatures.SetItemChecked(i, false);
            }
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
                pbVehicleImage.Image = Image.FromFile(filePath);
                pbVehicleImage.Tag = filePath;
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"Error loading image: {ex.Message}");
            }
        }

        private void btnAddImage_Click(object sender, EventArgs e)
        {
            if (ofdImage.ShowDialog() != DialogResult.OK) return;
            string filePath = ofdImage.FileName;
            _currentImages.Add(filePath);
            
            // Display the image in the picture box
            try
            {
                pbVehicleImage.Image = Image.FromFile(filePath);
                pbVehicleImage.Tag = filePath;
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"Error loading image: {ex.Message}");
            }
        }

        private void btnRemoveImage_Click(object sender, EventArgs e)
        {
            if (pbVehicleImage.Image != null)
            {
                pbVehicleImage.Image = null;
                pbVehicleImage.Tag = null;
                _currentImages.Clear();
            }
        }

        private void lstImages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstImages.SelectedIndex >= 0 && lstImages.SelectedIndex < _currentImages.Count)
            {
                var imgPath = _currentImages[lstImages.SelectedIndex];
                if (File.Exists(imgPath))
                {
                    pbVehicleImage.Image = Image.FromFile(imgPath);
                }
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

        private void LoadCategories(List<Vehicle> vehicles)
        {
            foreach (Vehicle vehicle in vehicles)
            {
                // Ensure we handle IDs robustly (trim whitespace)
                string catId = vehicle.CategoryId?.Trim();
                switch (catId)
                {
                    case "1": vehicle.CategoryName = "Hatchback"; break;
                    case "2": vehicle.CategoryName = "Sedan"; break;
                    case "3": vehicle.CategoryName = "SUV"; break;
                    case "4": vehicle.CategoryName = "Pickup"; break;
                    case "5": vehicle.CategoryName = "Van/Minibus"; break;
                    default: 
                        // If it's seemingly a valid name, leave it. If null, use ID or fallback.
                        // If CategoryId is already a Name (legacy save), propagate it to CategoryName
                        vehicle.CategoryName = catId; 
                        break;
                }
            }
        }

        private string GetCategoryId(string categoryName)
        {
            if (string.IsNullOrWhiteSpace(categoryName)) return "Hatchback"; // Default Safe Value

            // The Stored Procedure expects the Category NAME (e.g. "Hatchback") for lookup, NOT the ID.
            // So we ensure we return a valid Name.

            string cleanedName = categoryName.Trim();
            
            // Map IDs to Names (in case an ID is passed)
            switch (cleanedName)
            {
                case "1": return "Hatchback";
                case "2": return "Sedan";
                case "3": return "SUV";
                case "4": return "Pickup";
                case "5": return "Van/Minibus";
            }
            
            // If it's already a name, return it (normalized if needed, but Title Case is standard)
            // We could validate against known list, but simply returning the trimmed name 
            // covers 99% of cases including the correct one.
            
            return cleanedName;
        }
}
}