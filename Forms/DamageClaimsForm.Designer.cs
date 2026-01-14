using System.ComponentModel;

namespace Vormas.Forms
{
    partial class DamageClaimsForm
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.cmbStatusFilter = new System.Windows.Forms.ComboBox();
            this.lblStatusFilter = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.pnlInputs = new System.Windows.Forms.Panel();
            this.grpActions = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnReject = new System.Windows.Forms.Button();
            this.btnApprove = new System.Windows.Forms.Button();
            this.grpCharge = new System.Windows.Forms.GroupBox();
            this.txtChargeAmount = new System.Windows.Forms.TextBox();
            this.lblChargeAmount = new System.Windows.Forms.Label();
            this.grpDamagePhoto = new System.Windows.Forms.GroupBox();
            this.pbDamagePhoto = new System.Windows.Forms.PictureBox();
            this.grpDamageInfo = new System.Windows.Forms.GroupBox();
            this.txtEstimatedCost = new System.Windows.Forms.TextBox();
            this.lblEstimatedCost = new System.Windows.Forms.Label();
            this.txtDamageSeverity = new System.Windows.Forms.TextBox();
            this.lblDamageSeverity = new System.Windows.Forms.Label();
            this.txtDamageDescription = new System.Windows.Forms.TextBox();
            this.lblDamageDescription = new System.Windows.Forms.Label();
            this.grpRentalInfo = new System.Windows.Forms.GroupBox();
            this.txtCreatedAt = new System.Windows.Forms.TextBox();
            this.lblCreatedAt = new System.Windows.Forms.Label();
            this.txtReportedBy = new System.Windows.Forms.TextBox();
            this.lblReportedBy = new System.Windows.Forms.Label();
            this.txtVehicleInfo = new System.Windows.Forms.TextBox();
            this.lblVehicleInfo = new System.Windows.Forms.Label();
            this.grpCustomerInfo = new System.Windows.Forms.GroupBox();
            this.txtCustomerEmail = new System.Windows.Forms.TextBox();
            this.lblCustomerEmail = new System.Windows.Forms.Label();
            this.txtCustomerPhone = new System.Windows.Forms.TextBox();
            this.lblCustomerPhone = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.txtDamageReportId = new System.Windows.Forms.TextBox();
            this.lblDamageReportId = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.dgvDamageClaims = new System.Windows.Forms.DataGridView();
            this.pnlTop.SuspendLayout();
            this.pnlInputs.SuspendLayout();
            this.grpActions.SuspendLayout();
            this.grpCharge.SuspendLayout();
            this.grpDamagePhoto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDamagePhoto)).BeginInit();
            this.grpDamageInfo.SuspendLayout();
            this.grpRentalInfo.SuspendLayout();
            this.grpCustomerInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDamageClaims)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.cmbStatusFilter);
            this.pnlTop.Controls.Add(this.lblStatusFilter);
            this.pnlTop.Controls.Add(this.btnSearch);
            this.pnlTop.Controls.Add(this.txtSearch);
            this.pnlTop.Controls.Add(this.lblSearch);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1333, 60);
            this.pnlTop.TabIndex = 0;
            // 
            // cmbStatusFilter
            // 
            this.cmbStatusFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatusFilter.FormattingEnabled = true;
            this.cmbStatusFilter.Location = new System.Drawing.Point(520, 19);
            this.cmbStatusFilter.Name = "cmbStatusFilter";
            this.cmbStatusFilter.Size = new System.Drawing.Size(150, 21);
            this.cmbStatusFilter.TabIndex = 4;
            // 
            // lblStatusFilter
            // 
            this.lblStatusFilter.AutoSize = true;
            this.lblStatusFilter.Location = new System.Drawing.Point(435, 22);
            this.lblStatusFilter.Name = "lblStatusFilter";
            this.lblStatusFilter.Size = new System.Drawing.Size(79, 13);
            this.lblStatusFilter.TabIndex = 3;
            this.lblStatusFilter.Text = "Filter by Status:";
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
            // pnlInputs
            // 
            this.pnlInputs.AutoScroll = true;
            this.pnlInputs.Controls.Add(this.grpActions);
            this.pnlInputs.Controls.Add(this.grpCharge);
            this.pnlInputs.Controls.Add(this.grpDamagePhoto);
            this.pnlInputs.Controls.Add(this.grpDamageInfo);
            this.pnlInputs.Controls.Add(this.grpRentalInfo);
            this.pnlInputs.Controls.Add(this.grpCustomerInfo);
            this.pnlInputs.Controls.Add(this.txtDamageReportId);
            this.pnlInputs.Controls.Add(this.lblDamageReportId);
            this.pnlInputs.Controls.Add(this.txtStatus);
            this.pnlInputs.Controls.Add(this.lblStatus);
            this.pnlInputs.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlInputs.Location = new System.Drawing.Point(0, 60);
            this.pnlInputs.Name = "pnlInputs";
            this.pnlInputs.Size = new System.Drawing.Size(463, 735);
            this.pnlInputs.TabIndex = 1;
            // 
            // grpActions
            // 
            this.grpActions.Controls.Add(this.btnClear);
            this.grpActions.Controls.Add(this.btnReject);
            this.grpActions.Controls.Add(this.btnApprove);
            this.grpActions.Location = new System.Drawing.Point(66, 544);
            this.grpActions.Name = "grpActions";
            this.grpActions.Size = new System.Drawing.Size(340, 50);
            this.grpActions.TabIndex = 9;
            this.grpActions.TabStop = false;
            this.grpActions.Text = "Actions";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(230, 18);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(90, 25);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // btnReject
            // 
            this.btnReject.BackColor = System.Drawing.Color.IndianRed;
            this.btnReject.ForeColor = System.Drawing.Color.White;
            this.btnReject.Location = new System.Drawing.Point(120, 18);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(90, 25);
            this.btnReject.TabIndex = 1;
            this.btnReject.Text = "Reject";
            this.btnReject.UseVisualStyleBackColor = false;
            // 
            // btnApprove
            // 
            this.btnApprove.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnApprove.ForeColor = System.Drawing.Color.White;
            this.btnApprove.Location = new System.Drawing.Point(15, 18);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(90, 25);
            this.btnApprove.TabIndex = 0;
            this.btnApprove.Text = "Approve";
            this.btnApprove.UseVisualStyleBackColor = false;
            // 
            // grpCharge
            // 
            this.grpCharge.Controls.Add(this.txtChargeAmount);
            this.grpCharge.Controls.Add(this.lblChargeAmount);
            this.grpCharge.Location = new System.Drawing.Point(66, 489);
            this.grpCharge.Name = "grpCharge";
            this.grpCharge.Size = new System.Drawing.Size(340, 50);
            this.grpCharge.TabIndex = 8;
            this.grpCharge.TabStop = false;
            this.grpCharge.Text = "Charge to Customer";
            // 
            // txtChargeAmount
            // 
            this.txtChargeAmount.Location = new System.Drawing.Point(120, 19);
            this.txtChargeAmount.Name = "txtChargeAmount";
            this.txtChargeAmount.Size = new System.Drawing.Size(200, 20);
            this.txtChargeAmount.TabIndex = 1;
            // 
            // lblChargeAmount
            // 
            this.lblChargeAmount.AutoSize = true;
            this.lblChargeAmount.Location = new System.Drawing.Point(15, 22);
            this.lblChargeAmount.Name = "lblChargeAmount";
            this.lblChargeAmount.Size = new System.Drawing.Size(95, 13);
            this.lblChargeAmount.TabIndex = 0;
            this.lblChargeAmount.Text = "Amount to Charge:";
            // 
            // grpDamagePhoto
            // 
            this.grpDamagePhoto.Controls.Add(this.pbDamagePhoto);
            this.grpDamagePhoto.Location = new System.Drawing.Point(66, 379);
            this.grpDamagePhoto.Name = "grpDamagePhoto";
            this.grpDamagePhoto.Size = new System.Drawing.Size(340, 105);
            this.grpDamagePhoto.TabIndex = 7;
            this.grpDamagePhoto.TabStop = false;
            this.grpDamagePhoto.Text = "Damage Photo";
            // 
            // pbDamagePhoto
            // 
            this.pbDamagePhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbDamagePhoto.Location = new System.Drawing.Point(15, 18);
            this.pbDamagePhoto.Name = "pbDamagePhoto";
            this.pbDamagePhoto.Size = new System.Drawing.Size(310, 80);
            this.pbDamagePhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbDamagePhoto.TabIndex = 0;
            this.pbDamagePhoto.TabStop = false;
            // 
            // grpDamageInfo
            // 
            this.grpDamageInfo.Controls.Add(this.txtEstimatedCost);
            this.grpDamageInfo.Controls.Add(this.lblEstimatedCost);
            this.grpDamageInfo.Controls.Add(this.txtDamageSeverity);
            this.grpDamageInfo.Controls.Add(this.lblDamageSeverity);
            this.grpDamageInfo.Controls.Add(this.txtDamageDescription);
            this.grpDamageInfo.Controls.Add(this.lblDamageDescription);
            this.grpDamageInfo.Location = new System.Drawing.Point(66, 274);
            this.grpDamageInfo.Name = "grpDamageInfo";
            this.grpDamageInfo.Size = new System.Drawing.Size(340, 100);
            this.grpDamageInfo.TabIndex = 6;
            this.grpDamageInfo.TabStop = false;
            this.grpDamageInfo.Text = "Damage Information";
            // 
            // txtEstimatedCost
            // 
            this.txtEstimatedCost.Location = new System.Drawing.Point(120, 71);
            this.txtEstimatedCost.Name = "txtEstimatedCost";
            this.txtEstimatedCost.ReadOnly = true;
            this.txtEstimatedCost.Size = new System.Drawing.Size(200, 20);
            this.txtEstimatedCost.TabIndex = 5;
            // 
            // lblEstimatedCost
            // 
            this.lblEstimatedCost.AutoSize = true;
            this.lblEstimatedCost.Location = new System.Drawing.Point(15, 74);
            this.lblEstimatedCost.Name = "lblEstimatedCost";
            this.lblEstimatedCost.Size = new System.Drawing.Size(80, 13);
            this.lblEstimatedCost.TabIndex = 4;
            this.lblEstimatedCost.Text = "Estimated Cost:";
            // 
            // txtDamageSeverity
            // 
            this.txtDamageSeverity.Location = new System.Drawing.Point(120, 45);
            this.txtDamageSeverity.Name = "txtDamageSeverity";
            this.txtDamageSeverity.ReadOnly = true;
            this.txtDamageSeverity.Size = new System.Drawing.Size(200, 20);
            this.txtDamageSeverity.TabIndex = 3;
            // 
            // lblDamageSeverity
            // 
            this.lblDamageSeverity.AutoSize = true;
            this.lblDamageSeverity.Location = new System.Drawing.Point(15, 48);
            this.lblDamageSeverity.Name = "lblDamageSeverity";
            this.lblDamageSeverity.Size = new System.Drawing.Size(48, 13);
            this.lblDamageSeverity.TabIndex = 2;
            this.lblDamageSeverity.Text = "Severity:";
            // 
            // txtDamageDescription
            // 
            this.txtDamageDescription.Location = new System.Drawing.Point(120, 19);
            this.txtDamageDescription.Name = "txtDamageDescription";
            this.txtDamageDescription.ReadOnly = true;
            this.txtDamageDescription.Size = new System.Drawing.Size(200, 20);
            this.txtDamageDescription.TabIndex = 1;
            // 
            // lblDamageDescription
            // 
            this.lblDamageDescription.AutoSize = true;
            this.lblDamageDescription.Location = new System.Drawing.Point(15, 22);
            this.lblDamageDescription.Name = "lblDamageDescription";
            this.lblDamageDescription.Size = new System.Drawing.Size(63, 13);
            this.lblDamageDescription.TabIndex = 0;
            this.lblDamageDescription.Text = "Description:";
            // 
            // grpRentalInfo
            // 
            this.grpRentalInfo.Controls.Add(this.txtCreatedAt);
            this.grpRentalInfo.Controls.Add(this.lblCreatedAt);
            this.grpRentalInfo.Controls.Add(this.txtReportedBy);
            this.grpRentalInfo.Controls.Add(this.lblReportedBy);
            this.grpRentalInfo.Controls.Add(this.txtVehicleInfo);
            this.grpRentalInfo.Controls.Add(this.lblVehicleInfo);
            this.grpRentalInfo.Location = new System.Drawing.Point(66, 169);
            this.grpRentalInfo.Name = "grpRentalInfo";
            this.grpRentalInfo.Size = new System.Drawing.Size(340, 100);
            this.grpRentalInfo.TabIndex = 5;
            this.grpRentalInfo.TabStop = false;
            this.grpRentalInfo.Text = "Rental Information";
            // 
            // txtCreatedAt
            // 
            this.txtCreatedAt.Location = new System.Drawing.Point(120, 71);
            this.txtCreatedAt.Name = "txtCreatedAt";
            this.txtCreatedAt.ReadOnly = true;
            this.txtCreatedAt.Size = new System.Drawing.Size(200, 20);
            this.txtCreatedAt.TabIndex = 5;
            // 
            // lblCreatedAt
            // 
            this.lblCreatedAt.AutoSize = true;
            this.lblCreatedAt.Location = new System.Drawing.Point(15, 74);
            this.lblCreatedAt.Name = "lblCreatedAt";
            this.lblCreatedAt.Size = new System.Drawing.Size(80, 13);
            this.lblCreatedAt.TabIndex = 4;
            this.lblCreatedAt.Text = "Date Reported:";
            // 
            // txtReportedBy
            // 
            this.txtReportedBy.Location = new System.Drawing.Point(120, 45);
            this.txtReportedBy.Name = "txtReportedBy";
            this.txtReportedBy.ReadOnly = true;
            this.txtReportedBy.Size = new System.Drawing.Size(200, 20);
            this.txtReportedBy.TabIndex = 3;
            // 
            // lblReportedBy
            // 
            this.lblReportedBy.AutoSize = true;
            this.lblReportedBy.Location = new System.Drawing.Point(15, 48);
            this.lblReportedBy.Name = "lblReportedBy";
            this.lblReportedBy.Size = new System.Drawing.Size(69, 13);
            this.lblReportedBy.TabIndex = 2;
            this.lblReportedBy.Text = "Reported By:";
            // 
            // txtVehicleInfo
            // 
            this.txtVehicleInfo.Location = new System.Drawing.Point(120, 19);
            this.txtVehicleInfo.Name = "txtVehicleInfo";
            this.txtVehicleInfo.ReadOnly = true;
            this.txtVehicleInfo.Size = new System.Drawing.Size(200, 20);
            this.txtVehicleInfo.TabIndex = 1;
            // 
            // lblVehicleInfo
            // 
            this.lblVehicleInfo.AutoSize = true;
            this.lblVehicleInfo.Location = new System.Drawing.Point(15, 22);
            this.lblVehicleInfo.Name = "lblVehicleInfo";
            this.lblVehicleInfo.Size = new System.Drawing.Size(45, 13);
            this.lblVehicleInfo.TabIndex = 0;
            this.lblVehicleInfo.Text = "Vehicle:";
            // 
            // grpCustomerInfo
            // 
            this.grpCustomerInfo.Controls.Add(this.txtCustomerEmail);
            this.grpCustomerInfo.Controls.Add(this.lblCustomerEmail);
            this.grpCustomerInfo.Controls.Add(this.txtCustomerPhone);
            this.grpCustomerInfo.Controls.Add(this.lblCustomerPhone);
            this.grpCustomerInfo.Controls.Add(this.txtCustomerName);
            this.grpCustomerInfo.Controls.Add(this.lblCustomerName);
            this.grpCustomerInfo.Location = new System.Drawing.Point(66, 64);
            this.grpCustomerInfo.Name = "grpCustomerInfo";
            this.grpCustomerInfo.Size = new System.Drawing.Size(340, 100);
            this.grpCustomerInfo.TabIndex = 4;
            this.grpCustomerInfo.TabStop = false;
            this.grpCustomerInfo.Text = "Customer Information";
            // 
            // txtCustomerEmail
            // 
            this.txtCustomerEmail.Location = new System.Drawing.Point(120, 71);
            this.txtCustomerEmail.Name = "txtCustomerEmail";
            this.txtCustomerEmail.ReadOnly = true;
            this.txtCustomerEmail.Size = new System.Drawing.Size(200, 20);
            this.txtCustomerEmail.TabIndex = 5;
            // 
            // lblCustomerEmail
            // 
            this.lblCustomerEmail.AutoSize = true;
            this.lblCustomerEmail.Location = new System.Drawing.Point(15, 74);
            this.lblCustomerEmail.Name = "lblCustomerEmail";
            this.lblCustomerEmail.Size = new System.Drawing.Size(35, 13);
            this.lblCustomerEmail.TabIndex = 4;
            this.lblCustomerEmail.Text = "Email:";
            // 
            // txtCustomerPhone
            // 
            this.txtCustomerPhone.Location = new System.Drawing.Point(120, 45);
            this.txtCustomerPhone.Name = "txtCustomerPhone";
            this.txtCustomerPhone.ReadOnly = true;
            this.txtCustomerPhone.Size = new System.Drawing.Size(200, 20);
            this.txtCustomerPhone.TabIndex = 3;
            // 
            // lblCustomerPhone
            // 
            this.lblCustomerPhone.AutoSize = true;
            this.lblCustomerPhone.Location = new System.Drawing.Point(15, 48);
            this.lblCustomerPhone.Name = "lblCustomerPhone";
            this.lblCustomerPhone.Size = new System.Drawing.Size(41, 13);
            this.lblCustomerPhone.TabIndex = 2;
            this.lblCustomerPhone.Text = "Phone:";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(120, 19);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.ReadOnly = true;
            this.txtCustomerName.Size = new System.Drawing.Size(200, 20);
            this.txtCustomerName.TabIndex = 1;
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Location = new System.Drawing.Point(15, 22);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(38, 13);
            this.lblCustomerName.TabIndex = 0;
            this.lblCustomerName.Text = "Name:";
            // 
            // txtDamageReportId
            // 
            this.txtDamageReportId.Location = new System.Drawing.Point(136, 34);
            this.txtDamageReportId.Name = "txtDamageReportId";
            this.txtDamageReportId.ReadOnly = true;
            this.txtDamageReportId.Size = new System.Drawing.Size(80, 20);
            this.txtDamageReportId.TabIndex = 1;
            // 
            // lblDamageReportId
            // 
            this.lblDamageReportId.AutoSize = true;
            this.lblDamageReportId.Location = new System.Drawing.Point(66, 37);
            this.lblDamageReportId.Name = "lblDamageReportId";
            this.lblDamageReportId.Size = new System.Drawing.Size(56, 13);
            this.lblDamageReportId.TabIndex = 0;
            this.lblDamageReportId.Text = "Report ID:";
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(286, 34);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(120, 20);
            this.txtStatus.TabIndex = 3;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(236, 37);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(40, 13);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Status:";
            // 
            // dgvDamageClaims
            // 
            this.dgvDamageClaims.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDamageClaims.Dock = System.Windows.Forms.DockStyle.Right;
            this.dgvDamageClaims.Location = new System.Drawing.Point(529, 60);
            this.dgvDamageClaims.Name = "dgvDamageClaims";
            this.dgvDamageClaims.Size = new System.Drawing.Size(804, 735);
            this.dgvDamageClaims.TabIndex = 2;
            // 
            // DamageClaimsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvDamageClaims);
            this.Controls.Add(this.pnlInputs);
            this.Controls.Add(this.pnlTop);
            this.Name = "DamageClaimsForm";
            this.Size = new System.Drawing.Size(1333, 795);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlInputs.ResumeLayout(false);
            this.pnlInputs.PerformLayout();
            this.grpActions.ResumeLayout(false);
            this.grpCharge.ResumeLayout(false);
            this.grpCharge.PerformLayout();
            this.grpDamagePhoto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbDamagePhoto)).EndInit();
            this.grpDamageInfo.ResumeLayout(false);
            this.grpDamageInfo.PerformLayout();
            this.grpRentalInfo.ResumeLayout(false);
            this.grpRentalInfo.PerformLayout();
            this.grpCustomerInfo.ResumeLayout(false);
            this.grpCustomerInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDamageClaims)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView dgvDamageClaims;

        // Top Panel - Search and Filter
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.ComboBox cmbStatusFilter;
        private System.Windows.Forms.Label lblStatusFilter;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;

        // Left Panel - Details
        private System.Windows.Forms.Panel pnlInputs;
        
        // Report ID and Status
        private System.Windows.Forms.TextBox txtDamageReportId;
        private System.Windows.Forms.Label lblDamageReportId;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label lblStatus;
        
        // Customer Info Group
        private System.Windows.Forms.GroupBox grpCustomerInfo;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.TextBox txtCustomerPhone;
        private System.Windows.Forms.Label lblCustomerPhone;
        private System.Windows.Forms.TextBox txtCustomerEmail;
        private System.Windows.Forms.Label lblCustomerEmail;
        
        // Rental Info Group
        private System.Windows.Forms.GroupBox grpRentalInfo;
        private System.Windows.Forms.TextBox txtVehicleInfo;
        private System.Windows.Forms.Label lblVehicleInfo;
        private System.Windows.Forms.TextBox txtReportedBy;
        private System.Windows.Forms.Label lblReportedBy;
        private System.Windows.Forms.TextBox txtCreatedAt;
        private System.Windows.Forms.Label lblCreatedAt;
        
        // Damage Info Group
        private System.Windows.Forms.GroupBox grpDamageInfo;
        private System.Windows.Forms.TextBox txtDamageDescription;
        private System.Windows.Forms.Label lblDamageDescription;
        private System.Windows.Forms.TextBox txtDamageSeverity;
        private System.Windows.Forms.Label lblDamageSeverity;
        private System.Windows.Forms.TextBox txtEstimatedCost;
        private System.Windows.Forms.Label lblEstimatedCost;
        
        // Damage Photo Group
        private System.Windows.Forms.GroupBox grpDamagePhoto;
        private System.Windows.Forms.PictureBox pbDamagePhoto;
        
        // Charge Group
        private System.Windows.Forms.GroupBox grpCharge;
        private System.Windows.Forms.TextBox txtChargeAmount;
        private System.Windows.Forms.Label lblChargeAmount;
        
        // Actions Group
        private System.Windows.Forms.GroupBox grpActions;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.Button btnClear;

        #endregion
    }
}