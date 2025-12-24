using System.ComponentModel;

namespace Vormas.Forms
{
    partial class CustomerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvCustomers = new System.Windows.Forms.DataGridView();
            this.pnlInputs = new System.Windows.Forms.Panel();
            this.lblLicenseStatus = new System.Windows.Forms.Label();
            this.btnDriversLicense = new System.Windows.Forms.Button();
            this.txtEmergencyContactPhone = new System.Windows.Forms.TextBox();
            this.chkIsBlacklisted = new System.Windows.Forms.CheckBox();
            this.txtEmergencyContactName = new System.Windows.Forms.TextBox();
            this.dtpBirthdate = new System.Windows.Forms.DateTimePicker();
            this.lblSeatingCapacity = new System.Windows.Forms.Label();
            this.lblFuelType = new System.Windows.Forms.Label();
            this.lblTransmission = new System.Windows.Forms.Label();
            this.cmbCustomerType = new System.Windows.Forms.ComboBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblVin = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblLicensePlate = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblColor = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblModel = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblMake = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
            this.pnlInputs.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCustomers
            // 
            this.dgvCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomers.Dock = System.Windows.Forms.DockStyle.Right;
            this.dgvCustomers.Location = new System.Drawing.Point(386, 60);
            this.dgvCustomers.Name = "dgvCustomers";
            this.dgvCustomers.Size = new System.Drawing.Size(634, 393);
            this.dgvCustomers.TabIndex = 4;
            this.dgvCustomers.SelectionChanged += new System.EventHandler(this.dgvCustomers_SelectionChanged);
            // 
            // pnlInputs
            // 
            this.pnlInputs.AutoScroll = true;
            this.pnlInputs.Controls.Add(this.lblLicenseStatus);
            this.pnlInputs.Controls.Add(this.btnDriversLicense);
            this.pnlInputs.Controls.Add(this.txtEmergencyContactPhone);
            this.pnlInputs.Controls.Add(this.chkIsBlacklisted);
            this.pnlInputs.Controls.Add(this.txtEmergencyContactName);
            this.pnlInputs.Controls.Add(this.dtpBirthdate);
            this.pnlInputs.Controls.Add(this.lblSeatingCapacity);
            this.pnlInputs.Controls.Add(this.lblFuelType);
            this.pnlInputs.Controls.Add(this.lblTransmission);
            this.pnlInputs.Controls.Add(this.cmbCustomerType);
            this.pnlInputs.Controls.Add(this.lblCategory);
            this.pnlInputs.Controls.Add(this.txtPhone);
            this.pnlInputs.Controls.Add(this.lblVin);
            this.pnlInputs.Controls.Add(this.txtEmail);
            this.pnlInputs.Controls.Add(this.lblLicensePlate);
            this.pnlInputs.Controls.Add(this.txtAddress);
            this.pnlInputs.Controls.Add(this.lblColor);
            this.pnlInputs.Controls.Add(this.lblYear);
            this.pnlInputs.Controls.Add(this.txtLastName);
            this.pnlInputs.Controls.Add(this.lblModel);
            this.pnlInputs.Controls.Add(this.txtFirstName);
            this.pnlInputs.Controls.Add(this.lblMake);
            this.pnlInputs.Controls.Add(this.btnClear);
            this.pnlInputs.Controls.Add(this.btnDelete);
            this.pnlInputs.Controls.Add(this.btnSave);
            this.pnlInputs.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlInputs.Location = new System.Drawing.Point(0, 60);
            this.pnlInputs.Name = "pnlInputs";
            this.pnlInputs.Size = new System.Drawing.Size(375, 393);
            this.pnlInputs.TabIndex = 3;
            // 
            // lblLicenseStatus
            // 
            this.lblLicenseStatus.Location = new System.Drawing.Point(198, 265);
            this.lblLicenseStatus.Name = "lblLicenseStatus";
            this.lblLicenseStatus.Size = new System.Drawing.Size(100, 23);
            this.lblLicenseStatus.TabIndex = 33;
            this.lblLicenseStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDriversLicense
            // 
            this.btnDriversLicense.Location = new System.Drawing.Point(10, 265);
            this.btnDriversLicense.Name = "btnDriversLicense";
            this.btnDriversLicense.Size = new System.Drawing.Size(134, 22);
            this.btnDriversLicense.TabIndex = 32;
            this.btnDriversLicense.Text = "Add Driver\'s License";
            this.btnDriversLicense.UseVisualStyleBackColor = true;
            this.btnDriversLicense.Click += new System.EventHandler(this.btnDriversLicense_Click);
            // 
            // txtEmergencyContactPhone
            // 
            this.txtEmergencyContactPhone.Location = new System.Drawing.Point(158, 208);
            this.txtEmergencyContactPhone.Name = "txtEmergencyContactPhone";
            this.txtEmergencyContactPhone.Size = new System.Drawing.Size(200, 20);
            this.txtEmergencyContactPhone.TabIndex = 31;
            // 
            // chkIsBlacklisted
            // 
            this.chkIsBlacklisted.Location = new System.Drawing.Point(158, 233);
            this.chkIsBlacklisted.Name = "chkIsBlacklisted";
            this.chkIsBlacklisted.Size = new System.Drawing.Size(104, 24);
            this.chkIsBlacklisted.TabIndex = 30;
            this.chkIsBlacklisted.UseVisualStyleBackColor = true;
            // 
            // txtEmergencyContactName
            // 
            this.txtEmergencyContactName.Location = new System.Drawing.Point(158, 184);
            this.txtEmergencyContactName.Name = "txtEmergencyContactName";
            this.txtEmergencyContactName.Size = new System.Drawing.Size(200, 20);
            this.txtEmergencyContactName.TabIndex = 29;
            // 
            // dtpBirthdate
            // 
            this.dtpBirthdate.Location = new System.Drawing.Point(158, 60);
            this.dtpBirthdate.Name = "dtpBirthdate";
            this.dtpBirthdate.Size = new System.Drawing.Size(200, 20);
            this.dtpBirthdate.TabIndex = 28;
            // 
            // lblSeatingCapacity
            // 
            this.lblSeatingCapacity.AutoSize = true;
            this.lblSeatingCapacity.Location = new System.Drawing.Point(10, 236);
            this.lblSeatingCapacity.Name = "lblSeatingCapacity";
            this.lblSeatingCapacity.Size = new System.Drawing.Size(69, 13);
            this.lblSeatingCapacity.TabIndex = 17;
            this.lblSeatingCapacity.Text = "Is Blacklisted";
            // 
            // lblFuelType
            // 
            this.lblFuelType.AutoSize = true;
            this.lblFuelType.Location = new System.Drawing.Point(10, 211);
            this.lblFuelType.Name = "lblFuelType";
            this.lblFuelType.Size = new System.Drawing.Size(137, 13);
            this.lblFuelType.TabIndex = 15;
            this.lblFuelType.Text = "Emergency Contact Phone:";
            // 
            // lblTransmission
            // 
            this.lblTransmission.AutoSize = true;
            this.lblTransmission.Location = new System.Drawing.Point(10, 187);
            this.lblTransmission.Name = "lblTransmission";
            this.lblTransmission.Size = new System.Drawing.Size(134, 13);
            this.lblTransmission.TabIndex = 13;
            this.lblTransmission.Text = "Emergency Contact Name:";
            // 
            // cmbCustomerType
            // 
            this.cmbCustomerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomerType.FormattingEnabled = true;
            this.cmbCustomerType.Items.AddRange(new object[] { "Hatchback ", "Sedan", "SUV ", "Pickup ", "Van/Minibus " });
            this.cmbCustomerType.Location = new System.Drawing.Point(158, 160);
            this.cmbCustomerType.Name = "cmbCustomerType";
            this.cmbCustomerType.Size = new System.Drawing.Size(200, 21);
            this.cmbCustomerType.TabIndex = 12;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(10, 163);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(81, 13);
            this.lblCategory.TabIndex = 11;
            this.lblCategory.Text = "Customer Type:";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(158, 136);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(200, 20);
            this.txtPhone.TabIndex = 10;
            // 
            // lblVin
            // 
            this.lblVin.AutoSize = true;
            this.lblVin.Location = new System.Drawing.Point(10, 139);
            this.lblVin.Name = "lblVin";
            this.lblVin.Size = new System.Drawing.Size(41, 13);
            this.lblVin.TabIndex = 9;
            this.lblVin.Text = "Phone:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(158, 112);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(200, 20);
            this.txtEmail.TabIndex = 8;
            // 
            // lblLicensePlate
            // 
            this.lblLicensePlate.AutoSize = true;
            this.lblLicensePlate.Location = new System.Drawing.Point(10, 115);
            this.lblLicensePlate.Name = "lblLicensePlate";
            this.lblLicensePlate.Size = new System.Drawing.Size(35, 13);
            this.lblLicensePlate.TabIndex = 7;
            this.lblLicensePlate.Text = "Email:";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(158, 86);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(200, 20);
            this.txtAddress.TabIndex = 6;
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Location = new System.Drawing.Point(11, 89);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(48, 13);
            this.lblColor.TabIndex = 5;
            this.lblColor.Text = "Address:";
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(10, 60);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(69, 13);
            this.lblYear.TabIndex = 3;
            this.lblYear.Text = "Date of Birth:";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(158, 33);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(200, 20);
            this.txtLastName.TabIndex = 2;
            // 
            // lblModel
            // 
            this.lblModel.AutoSize = true;
            this.lblModel.Location = new System.Drawing.Point(10, 36);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(61, 13);
            this.lblModel.TabIndex = 1;
            this.lblModel.Text = "Last Name:";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(158, 9);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(200, 20);
            this.txtFirstName.TabIndex = 0;
            // 
            // lblMake
            // 
            this.lblMake.AutoSize = true;
            this.lblMake.Location = new System.Drawing.Point(10, 12);
            this.lblMake.Name = "lblMake";
            this.lblMake.Size = new System.Drawing.Size(60, 13);
            this.lblMake.TabIndex = 0;
            this.lblMake.Text = "First Name:";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(245, 332);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 30);
            this.btnClear.TabIndex = 27;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.IndianRed;
            this.btnDelete.Location = new System.Drawing.Point(135, 332);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 30);
            this.btnDelete.TabIndex = 26;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSave.Location = new System.Drawing.Point(25, 332);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 30);
            this.btnSave.TabIndex = 25;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.btnSearch);
            this.pnlTop.Controls.Add(this.txtSearch);
            this.pnlTop.Controls.Add(this.lblSearch);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1020, 60);
            this.pnlTop.TabIndex = 5;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(340, 18);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(60, 20);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(260, 20);
            this.txtSearch.TabIndex = 1;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(10, 23);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(44, 13);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Search:";
            // 
            // CustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvCustomers);
            this.Controls.Add(this.pnlInputs);
            this.Controls.Add(this.pnlTop);
            this.Name = "CustomerForm";
            this.Size = new System.Drawing.Size(1020, 453);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            this.pnlInputs.ResumeLayout(false);
            this.pnlInputs.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblLicenseStatus;

        private System.Windows.Forms.Button btnDriversLicense;

        private System.Windows.Forms.TextBox txtEmergencyContactPhone;

        private System.Windows.Forms.TextBox txtEmergencyContactName;
        private System.Windows.Forms.CheckBox chkIsBlacklisted;

        private System.Windows.Forms.DateTimePicker dtpBirthdate;

        private System.Windows.Forms.DataGridView dgvCustomers;
        private System.Windows.Forms.Panel pnlInputs;
        private System.Windows.Forms.Label lblSeatingCapacity;
        private System.Windows.Forms.Label lblFuelType;
        private System.Windows.Forms.Label lblTransmission;
        private System.Windows.Forms.ComboBox cmbCustomerType;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblVin;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblLicensePlate;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblMake;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;

        #endregion
    }
}