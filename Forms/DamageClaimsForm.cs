using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Vormas.Interfaces;
using Vormas.Models;
using Vormas.Navigation;

namespace Vormas.Forms
{
    public partial class DamageClaimsForm : PageControl
    {
        private readonly IDamageClaimsService _service;
        private readonly ISessionService _sessionService;
        private DamageReports _selectedReport;
        private readonly BindingSource _bindingSource;

        public DamageClaimsForm(IDamageClaimsService service, ISessionService sessionService)
        {
            InitializeComponent();

            _service = service ?? throw new ArgumentNullException(nameof(service));
            _sessionService = sessionService ?? throw new ArgumentNullException(nameof(sessionService));
            _bindingSource = new BindingSource();
            _selectedReport = null;

            ConfigureGrid();
            InitializeStatusFilter();
            InitializeData();
            WireUpEvents();
        }

        private void WireUpEvents()
        {
            dgvDamageClaims.SelectionChanged += DgvDamageClaims_SelectionChanged;
            btnSearch.Click += BtnSearch_Click;
            btnApprove.Click += BtnApprove_Click;
            btnReject.Click += BtnReject_Click;
            btnClear.Click += BtnClear_Click;
            cmbStatusFilter.SelectedIndexChanged += CmbStatusFilter_SelectedIndexChanged;
        }

        private void ConfigureGrid()
        {
            dgvDamageClaims.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDamageClaims.MultiSelect = false;
            dgvDamageClaims.ReadOnly = true;
            dgvDamageClaims.AutoGenerateColumns = false;

            dgvDamageClaims.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "DamageReportId", HeaderText = @"ID", Width = 40 });
            dgvDamageClaims.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "CustomerName", HeaderText = @"Customer", Width = 120 });
            dgvDamageClaims.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "VehicleInfo", HeaderText = @"Vehicle", Width = 150 });
            dgvDamageClaims.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "DamageDescription", HeaderText = @"Damage", Width = 120 });
            dgvDamageClaims.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "Severity", HeaderText = @"Severity", Width = 70 });
            dgvDamageClaims.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "EstimatedRepairCost", HeaderText = @"Est. Cost", Width = 70,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            });
            dgvDamageClaims.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "Status", HeaderText = @"Status", Width = 90 });
            dgvDamageClaims.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CreatedAt", HeaderText = @"Reported", Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "yyyy-MM-dd" }
            });
        }

        private void InitializeStatusFilter()
        {
            cmbStatusFilter.Items.Clear();
            cmbStatusFilter.Items.Add("All");
            cmbStatusFilter.Items.Add("PendingApproval");
            cmbStatusFilter.Items.Add("Approved");
            cmbStatusFilter.Items.Add("Rejected");
            cmbStatusFilter.SelectedIndex = 0;
        }

        private void InitializeData()
        {
            if (_service == null) return;
            LoadDamageClaims();
        }

        private void LoadDamageClaims()
        {
            try
            {
                string statusFilter = null;
                if (cmbStatusFilter.SelectedItem != null && cmbStatusFilter.SelectedItem.ToString() != "All")
                {
                    statusFilter = cmbStatusFilter.SelectedItem.ToString();
                }

                var claims = _service.GetALlDamageClaims(statusFilter);
                _bindingSource.DataSource = claims;
                dgvDamageClaims.DataSource = _bindingSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"Error loading damage claims: {ex.Message}", @"Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void DgvDamageClaims_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDamageClaims.CurrentRow?.DataBoundItem is DamageReports report)
            {
                PopulateFields(report);
            }
        }

        private void PopulateFields(DamageReports report)
        {
            _selectedReport = report;


            txtDamageReportId.Text = report.DamageReportId.ToString();
            txtStatus.Text = report.Status;


            txtCustomerName.Text = report.CustomerName ?? "";
            txtCustomerPhone.Text = "";
            txtCustomerEmail.Text = "";


            txtVehicleInfo.Text = report.VehicleInfo;
            txtReportedBy.Text = report.ReportedByName;
            txtCreatedAt.Text = report.CreatedAt.ToString("yyyy-MM-dd HH:mm");


            txtDamageDescription.Text = report.DamageDescription ?? "";
            txtDamageSeverity.Text = report.DamageSeverity;
            txtEstimatedCost.Text = report.EstimatedRepairCost?.ToString("C2") ?? "";


            if (report.ChargeToCustomerAmount > 0)
            {
                txtChargeAmount.Text = report.ChargeToCustomerAmount.ToString("F2");
            }
            else if (report.EstimatedRepairCost.HasValue)
            {
                txtChargeAmount.Text = report.EstimatedRepairCost.Value.ToString("F2");
            }
            else
            {
                txtChargeAmount.Text = "0.00";
            }


            LoadDamagePhoto(report.PhotoPath);


            UpdateButtonStates(report.Status);
        }

        private void LoadDamagePhoto(string photoPath)
        {
            pbDamagePhoto.Image?.Dispose();
            pbDamagePhoto.Image = null;

            if (!string.IsNullOrEmpty(photoPath) && File.Exists(photoPath))
            {
                try
                {
                    pbDamagePhoto.Image = Image.FromFile(photoPath);
                }
                catch
                {
                    // Silently fail if image can't be loaded
                }
            }
        }

        private void UpdateButtonStates(string status)
        {
            bool isPending = status == "PendingApproval";
            btnApprove.Enabled = isPending;
            btnReject.Enabled = isPending;
            txtChargeAmount.ReadOnly = !isPending;
        }

        private void ClearInputs()
        {
            _selectedReport = null;

            txtDamageReportId.Text = "";
            txtStatus.Text = "";
            txtCustomerName.Text = "";
            txtCustomerPhone.Text = "";
            txtCustomerEmail.Text = "";
            txtVehicleInfo.Text = "";
            txtReportedBy.Text = "";
            txtCreatedAt.Text = "";
            txtDamageDescription.Text = "";
            txtDamageSeverity.Text = "";
            txtEstimatedCost.Text = "";
            txtChargeAmount.Text = "";

            pbDamagePhoto.Image?.Dispose();
            pbDamagePhoto.Image = null;

            btnApprove.Enabled = false;
            btnReject.Enabled = false;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            SearchClaims(txtSearch.Text);
        }

        private void SearchClaims(string query)
        {
            try
            {
                string statusFilter = null;
                if (cmbStatusFilter.SelectedItem != null && cmbStatusFilter.SelectedItem.ToString() != "All")
                {
                    statusFilter = cmbStatusFilter.SelectedItem.ToString();
                }

                var allClaims = _service.GetALlDamageClaims(statusFilter);

                if (string.IsNullOrWhiteSpace(query))
                {
                    _bindingSource.DataSource = allClaims;
                }
                else
                {
                    var filtered = allClaims.FindAll(c =>
                        (c.CustomerName != null &&
                         c.CustomerName.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0) ||
                        (c.VehicleInfo != null &&
                         c.VehicleInfo.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0) ||
                        (c.DamageDescription != null &&
                         c.DamageDescription.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0));
                    _bindingSource.DataSource = filtered;
                }

                _bindingSource.ResetBindings(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"Error searching claims: {ex.Message}", @"Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void CmbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDamageClaims();
        }

        private void BtnApprove_Click(object sender, EventArgs e)
        {
            if (_selectedReport == null)
            {
                MessageBox.Show(@"Please select a damage claim to approve.", @"No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtChargeAmount.Text, out decimal chargeAmount) || chargeAmount < 0)
            {
                MessageBox.Show(@"Please enter a valid charge amount.", @"Invalid Amount",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show(
                $@"Approve this damage claim and charge {chargeAmount:C2} to the customer?",
                @"Confirm Approval", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return;

            try
            {
                int currentUserId = _sessionService.CurrentUser?.UserId ?? 0;
                _service.ApproveDamageReport(_selectedReport.DamageReportId, chargeAmount, currentUserId);

                MessageBox.Show(@"Damage claim approved successfully.", @"Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadDamageClaims();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"Error approving claim: {ex.Message}", @"Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnReject_Click(object sender, EventArgs e)
        {
            if (_selectedReport == null)
            {
                MessageBox.Show(@"Please select a damage claim to reject.", @"No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show(
                @"Are you sure you want to reject this damage claim?",
                @"Confirm Rejection", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return;

            try
            {
                int currentUserId = _sessionService.CurrentUser?.UserId ?? 0;
                _service.RejectDamageReport(_selectedReport.DamageReportId, currentUserId);

                MessageBox.Show(@"Damage claim rejected.", @"Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadDamageClaims();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"Error rejecting claim: {ex.Message}", @"Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
            dgvDamageClaims.ClearSelection();
        }
    }
}