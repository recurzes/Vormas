using System;
using System.Windows.Forms;
using Vormas.Models;

namespace Vormas.Forms
{
    public partial class DriverLicenseForm : Form
    {
        public DriverLicense License { get; private set; }
        
        public DriverLicenseForm()
        {
            InitializeComponent();
        }

        public DriverLicenseForm(DriverLicense existingLicense) : this()
        {
            if (existingLicense != null)
            {
                License = existingLicense;
                txtLicenseNumber.Text = existingLicense.LicenseNumber;
                dtpIssueDate.Value = existingLicense.IssueDate;
                dtpExpiryDate.Value = existingLicense.ExpiryDate;
                txtIssuingCountry.Text = existingLicense.IssuingCountry;
                txtIssuingStateProvince.Text = existingLicense.IssuingStateProvince;
                chkIsInternational.Checked = existingLicense.IsInternational;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            License = new DriverLicense
            {
                LicenseNumber = txtLicenseNumber.Text,
                IssueDate = dtpIssueDate.Value,
                ExpiryDate = dtpExpiryDate.Value,
                IssuingCountry = txtIssuingCountry.Text,
                IssuingStateProvince = txtIssuingStateProvince.Text,
                IsInternational = chkIsInternational.Checked
            };

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }
        
        // Helper
        private void ClearInputs()
        {
            License = new DriverLicense();
            txtIssuingCountry.Text = "";
            txtLicenseNumber.Text = "";
            txtIssuingStateProvince.Text = "";
            dtpIssueDate.Value = DateTime.Now;
            dtpExpiryDate.Value = DateTime.Now;
            chkIsInternational.Checked = false;
        }
    }
}