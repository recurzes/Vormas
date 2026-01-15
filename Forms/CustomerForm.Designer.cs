using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Vormas.Forms
{
    partial class CustomerForm
    {
        private IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.dgvCustomers = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.tcDetails = new System.Windows.Forms.TabControl();
            this.tabProfile = new System.Windows.Forms.TabPage();
            this.pnlActions = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.grpEmergency = new System.Windows.Forms.GroupBox();
            this.txtEmergencyContactPhone = new System.Windows.Forms.TextBox();
            this.lblEmergencyPhone = new System.Windows.Forms.Label();
            this.txtEmergencyContactName = new System.Windows.Forms.TextBox();
            this.lblEmergencyName = new System.Windows.Forms.Label();
            this.grpContact = new System.Windows.Forms.GroupBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.grpPersonal = new System.Windows.Forms.GroupBox();
            this.lblCustomerType = new System.Windows.Forms.Label();
            this.cmbCustomerType = new System.Windows.Forms.ComboBox();
            this.dtpBirthdate = new System.Windows.Forms.DateTimePicker();
            this.lblBirthDate = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.grpIdentity = new System.Windows.Forms.GroupBox();
            this.btnDrivingRecords = new System.Windows.Forms.Button();
            this.lblLicenseStatus = new System.Windows.Forms.Label();
            this.btnDriversLicense = new System.Windows.Forms.Button();
            this.chkIsBlacklisted = new System.Windows.Forms.CheckBox();
            this.btnBrowseImage = new System.Windows.Forms.Button();
            this.pbCustomerImage = new System.Windows.Forms.PictureBox();
            this.tabHistory = new System.Windows.Forms.TabPage();
            this.dgvRentalHistory = new System.Windows.Forms.DataGridView();
            this.ofdImage = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.tcDetails.SuspendLayout();
            this.tabProfile.SuspendLayout();
            this.pnlActions.SuspendLayout();
            this.grpEmergency.SuspendLayout();
            this.grpContact.SuspendLayout();
            this.grpPersonal.SuspendLayout();
            this.grpIdentity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCustomerImage)).BeginInit();
            this.tabHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRentalHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCustomers
            // 
            this.dgvCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCustomers.Location = new System.Drawing.Point(10, 60);
            this.dgvCustomers.Name = "dgvCustomers";
            this.dgvCustomers.Size = new System.Drawing.Size(330, 480);
            this.dgvCustomers.TabIndex = 1;
            this.dgvCustomers.SelectionChanged += new System.EventHandler(this.dgvCustomers_SelectionChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvCustomers);
            this.splitContainer1.Panel1.Controls.Add(this.pnlSearch);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(10);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tcDetails);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(10);
            this.splitContainer1.Size = new System.Drawing.Size(1046, 620);
            this.splitContainer1.SplitterDistance = 350;
            this.splitContainer1.TabIndex = 0;
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.btnSearch);
            this.pnlSearch.Controls.Add(this.txtSearch);
            this.pnlSearch.Controls.Add(this.lblSearch);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Location = new System.Drawing.Point(10, 10);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(330, 50);
            this.pnlSearch.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(245, 13);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 25);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(60, 15);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(179, 20);
            this.txtSearch.TabIndex = 1;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(10, 18);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(44, 13);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Search:";
            // 
            // tcDetails
            // 
            this.tcDetails.Controls.Add(this.tabProfile);
            this.tcDetails.Controls.Add(this.tabHistory);
            this.tcDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcDetails.Location = new System.Drawing.Point(10, 10);
            this.tcDetails.Name = "tcDetails";
            this.tcDetails.SelectedIndex = 0;
            this.tcDetails.Size = new System.Drawing.Size(672, 600);
            this.tcDetails.TabIndex = 0;
            // 
            // tabProfile
            // 
            this.tabProfile.AutoScroll = true;
            this.tabProfile.BackColor = System.Drawing.Color.White;
            this.tabProfile.Controls.Add(this.pnlActions);
            this.tabProfile.Controls.Add(this.grpEmergency);
            this.tabProfile.Controls.Add(this.grpContact);
            this.tabProfile.Controls.Add(this.grpPersonal);
            this.tabProfile.Controls.Add(this.grpIdentity);
            this.tabProfile.Location = new System.Drawing.Point(4, 22);
            this.tabProfile.Name = "tabProfile";
            this.tabProfile.Padding = new System.Windows.Forms.Padding(15);
            this.tabProfile.Size = new System.Drawing.Size(664, 574);
            this.tabProfile.TabIndex = 0;
            this.tabProfile.Text = "Profile Details";
            // 
            // pnlActions
            // 
            this.pnlActions.Controls.Add(this.btnDelete);
            this.pnlActions.Controls.Add(this.btnClear);
            this.pnlActions.Controls.Add(this.btnSave);
            this.pnlActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlActions.Location = new System.Drawing.Point(15, 509);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Size = new System.Drawing.Size(634, 50);
            this.pnlActions.TabIndex = 4;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.BackColor = System.Drawing.Color.IndianRed;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(469, 10);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 30);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Location = new System.Drawing.Point(550, 10);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 30);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "New Customer";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(388, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 30);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // grpEmergency
            // 
            this.grpEmergency.Controls.Add(this.txtEmergencyContactPhone);
            this.grpEmergency.Controls.Add(this.lblEmergencyPhone);
            this.grpEmergency.Controls.Add(this.txtEmergencyContactName);
            this.grpEmergency.Controls.Add(this.lblEmergencyName);
            this.grpEmergency.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpEmergency.Location = new System.Drawing.Point(15, 350);
            this.grpEmergency.Name = "grpEmergency";
            this.grpEmergency.Size = new System.Drawing.Size(634, 100);
            this.grpEmergency.TabIndex = 3;
            this.grpEmergency.TabStop = false;
            this.grpEmergency.Text = "Emergency Contact";
            // 
            // txtEmergencyContactPhone
            // 
            this.txtEmergencyContactPhone.Location = new System.Drawing.Point(130, 60);
            this.txtEmergencyContactPhone.Name = "txtEmergencyContactPhone";
            this.txtEmergencyContactPhone.Size = new System.Drawing.Size(200, 20);
            this.txtEmergencyContactPhone.TabIndex = 3;
            // 
            // lblEmergencyPhone
            // 
            this.lblEmergencyPhone.AutoSize = true;
            this.lblEmergencyPhone.Location = new System.Drawing.Point(20, 63);
            this.lblEmergencyPhone.Name = "lblEmergencyPhone";
            this.lblEmergencyPhone.Size = new System.Drawing.Size(41, 13);
            this.lblEmergencyPhone.TabIndex = 2;
            this.lblEmergencyPhone.Text = "Phone:";
            // 
            // txtEmergencyContactName
            // 
            this.txtEmergencyContactName.Location = new System.Drawing.Point(130, 30);
            this.txtEmergencyContactName.Name = "txtEmergencyContactName";
            this.txtEmergencyContactName.Size = new System.Drawing.Size(200, 20);
            this.txtEmergencyContactName.TabIndex = 1;
            // 
            // lblEmergencyName
            // 
            this.lblEmergencyName.AutoSize = true;
            this.lblEmergencyName.Location = new System.Drawing.Point(20, 33);
            this.lblEmergencyName.Name = "lblEmergencyName";
            this.lblEmergencyName.Size = new System.Drawing.Size(38, 13);
            this.lblEmergencyName.TabIndex = 0;
            this.lblEmergencyName.Text = "Name:";
            // 
            // grpContact
            // 
            this.grpContact.Controls.Add(this.txtPhone);
            this.grpContact.Controls.Add(this.lblPhone);
            this.grpContact.Controls.Add(this.txtEmail);
            this.grpContact.Controls.Add(this.lblEmail);
            this.grpContact.Controls.Add(this.txtAddress);
            this.grpContact.Controls.Add(this.lblAddress);
            this.grpContact.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpContact.Location = new System.Drawing.Point(15, 200);
            this.grpContact.Name = "grpContact";
            this.grpContact.Size = new System.Drawing.Size(634, 150);
            this.grpContact.TabIndex = 2;
            this.grpContact.TabStop = false;
            this.grpContact.Text = "Contact Details";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(100, 100);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(200, 20);
            this.txtPhone.TabIndex = 5;
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(20, 103);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(41, 13);
            this.lblPhone.TabIndex = 4;
            this.lblPhone.Text = "Phone:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(100, 70);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(250, 20);
            this.txtEmail.TabIndex = 3;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(20, 73);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(35, 13);
            this.lblEmail.TabIndex = 2;
            this.lblEmail.Text = "Email:";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(100, 30);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(350, 34);
            this.txtAddress.TabIndex = 1;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(20, 33);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(48, 13);
            this.lblAddress.TabIndex = 0;
            this.lblAddress.Text = "Address:";
            // 
            // grpPersonal
            // 
            this.grpPersonal.Controls.Add(this.lblCustomerType);
            this.grpPersonal.Controls.Add(this.cmbCustomerType);
            this.grpPersonal.Controls.Add(this.dtpBirthdate);
            this.grpPersonal.Controls.Add(this.lblBirthDate);
            this.grpPersonal.Controls.Add(this.txtLastName);
            this.grpPersonal.Controls.Add(this.lblLastName);
            this.grpPersonal.Controls.Add(this.txtFirstName);
            this.grpPersonal.Controls.Add(this.lblFirstName);
            this.grpPersonal.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpPersonal.Location = new System.Drawing.Point(15, 15);
            this.grpPersonal.Name = "grpPersonal";
            this.grpPersonal.Size = new System.Drawing.Size(634, 185);
            this.grpPersonal.TabIndex = 1;
            this.grpPersonal.TabStop = false;
            this.grpPersonal.Text = "Personal Information";
            // 
            // lblCustomerType
            // 
            this.lblCustomerType.AutoSize = true;
            this.lblCustomerType.Location = new System.Drawing.Point(20, 133);
            this.lblCustomerType.Name = "lblCustomerType";
            this.lblCustomerType.Size = new System.Drawing.Size(81, 13);
            this.lblCustomerType.TabIndex = 7;
            this.lblCustomerType.Text = "Customer Type:";
            // 
            // cmbCustomerType
            // 
            this.cmbCustomerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomerType.FormattingEnabled = true;
            this.cmbCustomerType.Items.AddRange(new object[] { "Individual", "Corporate", "Frequent", "Blacklisted" });
            this.cmbCustomerType.Location = new System.Drawing.Point(120, 130);
            this.cmbCustomerType.Name = "cmbCustomerType";
            this.cmbCustomerType.Size = new System.Drawing.Size(200, 21);
            this.cmbCustomerType.TabIndex = 6;
            // 
            // dtpBirthdate
            // 
            this.dtpBirthdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBirthdate.Location = new System.Drawing.Point(120, 100);
            this.dtpBirthdate.Name = "dtpBirthdate";
            this.dtpBirthdate.Size = new System.Drawing.Size(200, 20);
            this.dtpBirthdate.TabIndex = 5;
            // 
            // lblBirthDate
            // 
            this.lblBirthDate.AutoSize = true;
            this.lblBirthDate.Location = new System.Drawing.Point(20, 103);
            this.lblBirthDate.Name = "lblBirthDate";
            this.lblBirthDate.Size = new System.Drawing.Size(69, 13);
            this.lblBirthDate.TabIndex = 4;
            this.lblBirthDate.Text = "Date of Birth:";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(120, 60);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(200, 20);
            this.txtLastName.TabIndex = 3;
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(20, 63);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(61, 13);
            this.lblLastName.TabIndex = 2;
            this.lblLastName.Text = "Last Name:";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(120, 30);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(200, 20);
            this.txtFirstName.TabIndex = 1;
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(20, 33);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(60, 13);
            this.lblFirstName.TabIndex = 0;
            this.lblFirstName.Text = "First Name:";
            // 
            // grpIdentity
            // 
            this.grpIdentity.Controls.Add(this.btnDrivingRecords);
            this.grpIdentity.Controls.Add(this.lblLicenseStatus);
            this.grpIdentity.Controls.Add(this.btnDriversLicense);
            this.grpIdentity.Controls.Add(this.chkIsBlacklisted);
            this.grpIdentity.Controls.Add(this.btnBrowseImage);
            this.grpIdentity.Controls.Add(this.pbCustomerImage);
            this.grpIdentity.Dock = System.Windows.Forms.DockStyle.Right;
            this.grpIdentity.Location = new System.Drawing.Point(444, 15);
            this.grpIdentity.Name = "grpIdentity";
            this.grpIdentity.Size = new System.Drawing.Size(205, 544);
            this.grpIdentity.TabIndex = 0;
            this.grpIdentity.TabStop = false;
            this.grpIdentity.Text = "Identity";
            this.grpIdentity.Visible = true;
            // 
            // btnDrivingRecords
            // 
            this.btnDrivingRecords.Location = new System.Drawing.Point(35, 250);
            this.btnDrivingRecords.Name = "btnDrivingRecords";
            this.btnDrivingRecords.Size = new System.Drawing.Size(130, 23);
            this.btnDrivingRecords.TabIndex = 5;
            this.btnDrivingRecords.Text = "Driving Records";
            this.btnDrivingRecords.UseVisualStyleBackColor = true;
            this.btnDrivingRecords.Click += new System.EventHandler(this.btnDrivingRecords_Click);
            // 
            // lblLicenseStatus
            // 
            this.lblLicenseStatus.Location = new System.Drawing.Point(32, 220);
            this.lblLicenseStatus.Name = "lblLicenseStatus";
            this.lblLicenseStatus.Size = new System.Drawing.Size(133, 23);
            this.lblLicenseStatus.TabIndex = 4;
            this.lblLicenseStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDriversLicense
            // 
            this.btnDriversLicense.Location = new System.Drawing.Point(35, 190);
            this.btnDriversLicense.Name = "btnDriversLicense";
            this.btnDriversLicense.Size = new System.Drawing.Size(130, 23);
            this.btnDriversLicense.TabIndex = 3;
            this.btnDriversLicense.Text = "Driver's License";
            this.btnDriversLicense.UseVisualStyleBackColor = true;
            this.btnDriversLicense.Click += new System.EventHandler(this.btnDriversLicense_Click);
            // 
            // chkIsBlacklisted
            // 
            this.chkIsBlacklisted.AutoSize = true;
            this.chkIsBlacklisted.Location = new System.Drawing.Point(60, 160);
            this.chkIsBlacklisted.Name = "chkIsBlacklisted";
            this.chkIsBlacklisted.Size = new System.Drawing.Size(79, 17);
            this.chkIsBlacklisted.TabIndex = 2;
            this.chkIsBlacklisted.Text = "Blacklisted";
            this.chkIsBlacklisted.UseVisualStyleBackColor = true;
            // 
            // btnBrowseImage
            // 
            this.btnBrowseImage.Location = new System.Drawing.Point(50, 130);
            this.btnBrowseImage.Name = "btnBrowseImage";
            this.btnBrowseImage.Size = new System.Drawing.Size(100, 23);
            this.btnBrowseImage.TabIndex = 1;
            this.btnBrowseImage.Text = "Change Photo";
            this.btnBrowseImage.UseVisualStyleBackColor = true;
            this.btnBrowseImage.Click += new System.EventHandler(this.btnBrowseImage_Click);
            // 
            // pbCustomerImage
            // 
            this.pbCustomerImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbCustomerImage.Location = new System.Drawing.Point(40, 20);
            this.pbCustomerImage.Name = "pbCustomerImage";
            this.pbCustomerImage.Size = new System.Drawing.Size(120, 100);
            this.pbCustomerImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCustomerImage.TabIndex = 0;
            this.pbCustomerImage.TabStop = false;
            // 
            // tabHistory
            // 
            this.tabHistory.Controls.Add(this.dgvRentalHistory);
            this.tabHistory.Location = new System.Drawing.Point(4, 22);
            this.tabHistory.Name = "tabHistory";
            this.tabHistory.Padding = new System.Windows.Forms.Padding(3);
            this.tabHistory.Size = new System.Drawing.Size(664, 574);
            this.tabHistory.TabIndex = 1;
            this.tabHistory.Text = "Rental History";
            this.tabHistory.UseVisualStyleBackColor = true;
            // 
            // dgvRentalHistory
            // 
            this.dgvRentalHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRentalHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRentalHistory.Location = new System.Drawing.Point(3, 53);
            this.dgvRentalHistory.Name = "dgvRentalHistory";
            this.dgvRentalHistory.ReadOnly = true;
            this.dgvRentalHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRentalHistory.Size = new System.Drawing.Size(658, 518);
            this.dgvRentalHistory.TabIndex = 1;
            // 
            // CustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "CustomerForm";
            this.Size = new System.Drawing.Size(1046, 620);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.tcDetails.ResumeLayout(false);
            this.tabProfile.ResumeLayout(false);
            this.pnlActions.ResumeLayout(false);
            this.grpEmergency.ResumeLayout(false);
            this.grpEmergency.PerformLayout();
            this.grpContact.ResumeLayout(false);
            this.grpContact.PerformLayout();
            this.grpPersonal.ResumeLayout(false);
            this.grpPersonal.PerformLayout();
            this.grpIdentity.ResumeLayout(false);
            this.grpIdentity.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCustomerImage)).EndInit();
            this.tabHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRentalHistory)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        // Controls
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvCustomers;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblSearch;
        
        private System.Windows.Forms.TabControl tcDetails;
        private System.Windows.Forms.TabPage tabProfile;
        private System.Windows.Forms.TabPage tabHistory;

        
        // Groups
        private System.Windows.Forms.GroupBox grpPersonal;
        private System.Windows.Forms.GroupBox grpContact;
        private System.Windows.Forms.GroupBox grpEmergency;
        private System.Windows.Forms.GroupBox grpIdentity;
        private System.Windows.Forms.Panel pnlActions;
        
        // Personal Fields
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.DateTimePicker dtpBirthdate;
        private System.Windows.Forms.Label lblBirthDate;
        private System.Windows.Forms.ComboBox cmbCustomerType;
        private System.Windows.Forms.Label lblCustomerType;
        
        // Contact Fields
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblPhone;
        
        // Emergency Fields
        private System.Windows.Forms.TextBox txtEmergencyContactName;
        private System.Windows.Forms.Label lblEmergencyName;
        private System.Windows.Forms.TextBox txtEmergencyContactPhone;
        private System.Windows.Forms.Label lblEmergencyPhone;
        
        // Identity Fields
        private System.Windows.Forms.PictureBox pbCustomerImage;
        private System.Windows.Forms.Button btnBrowseImage;
        private System.Windows.Forms.CheckBox chkIsBlacklisted;
        private System.Windows.Forms.Button btnDriversLicense;
        private System.Windows.Forms.Label lblLicenseStatus;
        private System.Windows.Forms.Button btnDrivingRecords;
        
        // Actions
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        
        // History
        private System.Windows.Forms.DataGridView dgvRentalHistory;

        
        private System.Windows.Forms.OpenFileDialog ofdImage;
    }
}