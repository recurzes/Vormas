using System;
using System.Windows.Forms;
using Vormas.Interfaces;
using Vormas.Models;
using Vormas.Navigation;

namespace Vormas.Forms
{
    public partial class RateConfigurationForm : PageControl
    {
        private readonly IRateConfigurationService _rateConfigService;
        private RateConfigurations _selectedRateConfig;
        private readonly BindingSource _bindingSource;

        public RateConfigurationForm(IRateConfigurationService rateConfigService)
        {
            InitializeComponent();

            _bindingSource = new BindingSource();
            _rateConfigService = rateConfigService ?? throw new ArgumentNullException(nameof(rateConfigService));
            _selectedRateConfig = new RateConfigurations();

            InitializeData();
        }

        private void InitializeData()
        {
            if (_rateConfigService == null) return;

            ConfigureGrid();
            LoadRateConfigs();
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
            dgvRateConfigs.AutoGenerateColumns = false;

            dgvRateConfigs.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "RateConfigId", HeaderText = @"Rate Config Id", Width = 80 });
            dgvRateConfigs.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "CategoryId", HeaderText = @"CategoryId", Width = 40 });
            dgvRateConfigs.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "DailyRate", HeaderText = @"Daily Rate" });
            dgvRateConfigs.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "WeeklyRate", HeaderText = @"Weekly Rate" });
            dgvRateConfigs.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "MonthlyRate", HeaderText = @"Monthly Rate" });
            dgvRateConfigs.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "HourlyRate", HeaderText = @"Hourly Rate" });
            dgvRateConfigs.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "EffectiveFrom", HeaderText = @"Effective From" });
            dgvRateConfigs.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "EffectiveTo", HeaderText = @"Effective To", Width = 50 });
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
            cmbCategory.SelectedItem = rateConfigurations.CategoryId;
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

                if (!int.TryParse(cmbCategory.SelectedItem.ToString(), out int categoryId))
                {
                    MessageBox.Show(@"Please select a valid category", @"Validation Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

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
                // Note: You'll need to add DeleteRateConfiguration method to IRateConfigurationService interface
                // _rateConfigService.DeleteRateConfiguration(_selectedRateConfig.RateConfigId);
                MessageBox.Show(@"Delete method not yet implemented in service", @"Info", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
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