using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Vormas.Interfaces;
using Vormas.Models;

namespace Vormas.Forms
{
    public partial class DrivingRecordForm : Form
    {
        private readonly ICustomerService _service;
        private readonly int _customerId;
        private readonly BindingSource _bindingSource;

        public DrivingRecordForm(ICustomerService service, int customerId, string customerName)
        {
            InitializeComponent();
            _service = service;
            _customerId = customerId;
            _bindingSource = new BindingSource();
            Text = $@"Driving Records - {customerName}";
            ConfigureGrid();
            LoadRecords();
        }

        private void ConfigureGrid()
        {
            dgvRecords.AutoGenerateColumns = false;
            dgvRecords.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRecords.MultiSelect = false;
            dgvRecords.ReadOnly = true;

            dgvRecords.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "RecordId", HeaderText = @"ID", Width = 50 });
            dgvRecords.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "ViolationDate", HeaderText = @"Date", Width = 100 });
            dgvRecords.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "ViolationType", HeaderText = @"Type", Width = 120 });
            dgvRecords.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "Description", HeaderText = @"Description", Width = 200 });
            dgvRecords.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "FineAmount", HeaderText = @"Fine", Width = 80 });
            dgvRecords.Columns.Add(new DataGridViewCheckBoxColumn
                { DataPropertyName = "IsMajorViolation", HeaderText = @"Major", Width = 60 });
            dgvRecords.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "IssuingAuthority", HeaderText = @"Authority", Width = 150 });
        }

        private void LoadRecords()
        {
            try
            {
                var records = _service.GetDrivingRecords(_customerId);
                _bindingSource.DataSource = records;
                dgvRecords.DataSource = _bindingSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"Error loading records: {ex.Message}", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbViolationType.Text))
            {
                MessageBox.Show(@"Please select a violation type.", @"Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var record = new DrivingRecord
            {
                CustomerId = _customerId,
                ViolationDate = dtpViolationDate.Value,
                ViolationType = cmbViolationType.Text,
                Description = txtDescription.Text,
                FineAmount = numFineAmount.Value,
                IsMajorViolation = chkMajor.Checked,
                IssuingAuthority = txtAuthority.Text
            };

            try
            {
                _service.AddDrivingRecord(record);
                MessageBox.Show(@"Record added successfully.", @"Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
                LoadRecords();
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"Error adding record: {ex.Message}", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearInputs()
        {
            dtpViolationDate.Value = DateTime.Today;
            cmbViolationType.SelectedIndex = -1;
            txtDescription.Text = "";
            numFineAmount.Value = 0;
            chkMajor.Checked = false;
            txtAuthority.Text = "";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
