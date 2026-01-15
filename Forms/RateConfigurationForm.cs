using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Vormas.Interfaces;
using Vormas.Models;
using Vormas.Navigation;

namespace Vormas.Forms
{
    public partial class RateConfigurationForm : PageControl
    {
        private readonly IRateConfigurationService _rateConfigService;
        private readonly IVehicleService _vehicleService;
        private RateConfigurations _selectedRateConfig;
        private readonly BindingSource _bindingSource;

        public RateConfigurationForm(IRateConfigurationService rateConfigService, IVehicleService vehicleService)
        {
            InitializeComponent();

            _bindingSource = new BindingSource();
            _rateConfigService = rateConfigService ?? throw new ArgumentNullException(nameof(rateConfigService));
            _vehicleService = vehicleService ?? throw new ArgumentNullException(nameof(vehicleService));
            _selectedRateConfig = new RateConfigurations();

            InitializeData();

            // Apply styles
            btnSave.BackColor = Helpers.DesignTokens.PrimaryButton;
            btnDelete.BackColor = Helpers.DesignTokens.DestructiveButton;
            btnClear.BackColor = Helpers.DesignTokens.NeutralButton;
        }

        private void InitializeData()
        {
            if (_rateConfigService == null) return;

            LoadCategories();
            ConfigureGrid();
            LoadRateConfigs();
        }
        
        private class CategoryOption
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public override string ToString()
            {
                return Name;
            }
        }

        private void LoadCategories()
        {
            try
            {
                var categories = _vehicleService.GetVehicleCategories().ToList();
                var options = new List<CategoryOption>();
                for (int i = 0; i < categories.Count; i++)
                {
                    options.Add(new CategoryOption { Id = i + 1, Name = categories[i] });
                }

                cmbCategory.DataSource = options;
                cmbCategory.DisplayMember = "Name";
                cmbCategory.ValueMember = "Id";
                cmbCategory.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"Error loading categories: {ex.Message}", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRateConfigs()
        {
            try
            {
                var rateConfigurations = _rateConfigService.GetAllRateConfigurations();
                _bindingSource.DataSource = rateConfigurations;
                dgvRateConfigs.DataSource = _bindingSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"Error loading Rate Configs: {ex.Message}", @"Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ConfigureGrid()
        {
            dgvRateConfigs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRateConfigs.MultiSelect = false;
            dgvRateConfigs.ReadOnly = true;
            dgvRateConfigs.AllowUserToAddRows = false;
            dgvRateConfigs.AutoGenerateColumns = false;
            dgvRateConfigs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvRateConfigs.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "RateConfigId", HeaderText = @"ID", FillWeight = 20, MinimumWidth = 30 });
            
            // We want to show Category Name in the grid, but the model has ID.
            // Ideally we'd map this, but for now let's keep showing ID or try to map if possible.
            // Since we only have ID in model, we'll stick to ID for now in the grid, or we could add a formatting handler.
            dgvRateConfigs.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "CategoryId", HeaderText = @"Category ID", FillWeight = 20, MinimumWidth = 30 });
                
            dgvRateConfigs.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DailyRate", HeaderText = @"Daily", FillWeight = 40,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "F2" }
            });
            dgvRateConfigs.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "WeeklyRate", HeaderText = @"Weekly", FillWeight = 40,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "F2" }
            });
            dgvRateConfigs.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MonthlyRate", HeaderText = @"Monthly", FillWeight = 40,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "F2" }
            });
            dgvRateConfigs.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "HourlyRate", HeaderText = @"Hourly", FillWeight = 40,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "F2" }
            });
            dgvRateConfigs.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "EffectiveFrom", HeaderText = @"From", FillWeight = 40,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "d" }
            });
            dgvRateConfigs.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "EffectiveTo", HeaderText = @"To", FillWeight = 40,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "d" }
            });
            
            dgvRateConfigs.CellFormatting += DgvRateConfigs_CellFormatting;
        }

        private void DgvRateConfigs_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvRateConfigs.Columns[e.ColumnIndex].DataPropertyName == "CategoryId" && e.Value != null)
            {
                if (int.TryParse(e.Value.ToString(), out int catId))
                {
                    // Map ID back to name for display
                    if (cmbCategory.DataSource is List<CategoryOption> options)
                    {
                        var match = options.FirstOrDefault(o => o.Id == catId);
                        if (match != null)
                        {
                            e.Value = match.Name;
                            e.FormattingApplied = true;
                        }
                    }
                }
            }
        }

        private void dgvRateConfigs_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRateConfigs.CurrentRow?.DataBoundItem is RateConfigurations rateConfigurations)
            {
                PopulateFields(rateConfigurations);
            }
        }

        private void PopulateFields(RateConfigurations rateConfigurations)
        {
            _selectedRateConfig = rateConfigurations;
            cmbCategory.SelectedValue = rateConfigurations.CategoryId;
            
            txtDailyRate.Text =
                rateConfigurations.DailyRate.ToString(System.Globalization.CultureInfo.InvariantCulture);
            txtWeeklyRate.Text =
                rateConfigurations.WeeklyRate.ToString(System.Globalization.CultureInfo.InvariantCulture);
            txtMonthlyRate.Text =
                rateConfigurations.MonthlyRate.ToString(System.Globalization.CultureInfo.InvariantCulture);
            txtHourlyRate.Text =
                rateConfigurations.HourlyRate.ToString(System.Globalization.CultureInfo.InvariantCulture);
            dtpEffectiveFrom.Value = rateConfigurations.EffectiveFrom;
            dtpEffectiveTo.Value = rateConfigurations.EffectiveTo ?? DateTime.Now;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbCategory.SelectedItem == null ||
                    string.IsNullOrWhiteSpace(txtDailyRate.Text) ||
                    string.IsNullOrWhiteSpace(txtWeeklyRate.Text) ||
                    string.IsNullOrWhiteSpace(txtMonthlyRate.Text) ||
                    string.IsNullOrWhiteSpace(txtHourlyRate.Text))
                {
                    MessageBox.Show(@"Please fill in all fields", @"Validation Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(txtDailyRate.Text, System.Globalization.NumberStyles.Any,
                        System.Globalization.CultureInfo.InvariantCulture, out decimal dailyRate) ||
                    !decimal.TryParse(txtWeeklyRate.Text, System.Globalization.NumberStyles.Any,
                        System.Globalization.CultureInfo.InvariantCulture, out decimal weeklyRate) ||
                    !decimal.TryParse(txtMonthlyRate.Text, System.Globalization.NumberStyles.Any,
                        System.Globalization.CultureInfo.InvariantCulture, out decimal monthlyRate) ||
                    !decimal.TryParse(txtHourlyRate.Text, System.Globalization.NumberStyles.Any,
                        System.Globalization.CultureInfo.InvariantCulture, out decimal hourlyRate))
                {
                    MessageBox.Show(@"Invalid rate format", @"Validation Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                if (dtpEffectiveFrom.Value > dtpEffectiveTo.Value)
                {
                    MessageBox.Show(@"Effective From date cannot be after Effective To date", @"Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                int categoryId = (int)cmbCategory.SelectedValue;

                _selectedRateConfig.CategoryId = categoryId;
                _selectedRateConfig.DailyRate = dailyRate;
                _selectedRateConfig.WeeklyRate = weeklyRate;
                _selectedRateConfig.MonthlyRate = monthlyRate;
                _selectedRateConfig.HourlyRate = hourlyRate;
                _selectedRateConfig.EffectiveFrom = dtpEffectiveFrom.Value;
                _selectedRateConfig.EffectiveTo = dtpEffectiveTo.Value;

                try
                {
                    if (_selectedRateConfig.RateConfigId == 0)
                    {
                        _rateConfigService.AddRateConfiguration(_selectedRateConfig);
                        MessageBox.Show(@"Rate configuration added successfully.", @"Success", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    else
                    {
                        var result = _rateConfigService.UpdateRateConfigurations(_selectedRateConfig);
                        MessageBox.Show($@"Rate configuration updated successfully. {result}", @"Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    LoadRateConfigs();
                    ClearInputs();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($@"Error saving rate configuration: {ex.Message}", @"Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"An error occurred: {ex.Message}", @"Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedRateConfig.RateConfigId <= 0) return;
            if (MessageBox.Show(@"Are you sure you want to delete this rate configuration?", @"Confirm Delete",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            try
            {
                _rateConfigService.DeleteRateConfiguration(_selectedRateConfig.RateConfigId);
                LoadRateConfigs();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"Error deleting rate configuration: {ex.Message}", @"Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void ClearInputs()
        {
            _selectedRateConfig = new RateConfigurations();
            cmbCategory.SelectedIndex = -1;
            txtDailyRate.Text = "";
            txtWeeklyRate.Text = "";
            txtMonthlyRate.Text = "";
            txtHourlyRate.Text = "";
            dtpEffectiveFrom.Value = DateTime.Now;
            dtpEffectiveTo.Value = DateTime.Now;
        }

        private void SearchRateConfigs(string query)
        {
            var allRateConfigs = _rateConfigService.GetAllRateConfigurations();
            if (string.IsNullOrWhiteSpace(query))
            {
                _bindingSource.DataSource = allRateConfigs;
            }
            else
            {
                var filtered = allRateConfigs.FindAll(r =>
                    r.CategoryId.ToString(System.Globalization.CultureInfo.InvariantCulture)
                        .IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    r.DailyRate.ToString(System.Globalization.CultureInfo.InvariantCulture)
                        .IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    r.WeeklyRate.ToString(System.Globalization.CultureInfo.InvariantCulture)
                        .IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    r.MonthlyRate.ToString(System.Globalization.CultureInfo.InvariantCulture)
                        .IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    r.HourlyRate.ToString(System.Globalization.CultureInfo.InvariantCulture)
                        .IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0);
                _bindingSource.DataSource = filtered;
            }

            _bindingSource.ResetBindings(false);
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            SearchRateConfigs(txtSearch.Text);
        }
    }
}