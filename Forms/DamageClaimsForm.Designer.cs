namespace Vormas.Forms
{
    partial class DamageClaimsForm
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.grpEvidence = new System.Windows.Forms.GroupBox();
            this.pbDamagePhoto = new System.Windows.Forms.PictureBox();
            this.grpDamage = new System.Windows.Forms.GroupBox();
            this.txtEstimatedCost = new System.Windows.Forms.TextBox();
            this.lblEstimatedCost = new System.Windows.Forms.Label();
            this.txtDamageSeverity = new System.Windows.Forms.TextBox();
            this.lblDamageSeverity = new System.Windows.Forms.Label();
            this.txtDamageDescription = new System.Windows.Forms.TextBox();
            this.lblDamageDescription = new System.Windows.Forms.Label();
            this.grpRental = new System.Windows.Forms.GroupBox();
            this.txtCreatedAt = new System.Windows.Forms.TextBox();
            this.lblCreatedAt = new System.Windows.Forms.Label();
            this.txtReportedBy = new System.Windows.Forms.TextBox();
            this.lblReportedBy = new System.Windows.Forms.Label();
            this.txtVehicleInfo = new System.Windows.Forms.TextBox();
            this.lblVehicleInfo = new System.Windows.Forms.Label();
            this.grpCustomer = new System.Windows.Forms.GroupBox();
            this.txtCustomerEmail = new System.Windows.Forms.TextBox();
            this.lblCustomerEmail = new System.Windows.Forms.Label();
            this.txtCustomerPhone = new System.Windows.Forms.TextBox();
            this.lblCustomerPhone = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.grpMeta = new System.Windows.Forms.GroupBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtDamageReportId = new System.Windows.Forms.TextBox();
            this.lblDamageReportId = new System.Windows.Forms.Label();
            this.pnlActions = new System.Windows.Forms.Panel();
            this.txtChargeAmount = new System.Windows.Forms.TextBox();
            this.lblChargeAmount = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnReject = new System.Windows.Forms.Button();
            this.btnApprove = new System.Windows.Forms.Button();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.cmbStatusFilter = new System.Windows.Forms.ComboBox();
            this.lblStatusFilter = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.dgvDamageClaims = new System.Windows.Forms.DataGridView();
            this.pnlLeft.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.grpEvidence.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDamagePhoto)).BeginInit();
            this.grpDamage.SuspendLayout();
            this.grpRental.SuspendLayout();
            this.grpCustomer.SuspendLayout();
            this.grpMeta.SuspendLayout();
            this.pnlActions.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDamageClaims)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.SystemColors.Control;
            this.pnlLeft.Controls.Add(this.pnlContent);
            this.pnlLeft.Controls.Add(this.pnlActions);
            this.pnlLeft.Controls.Add(this.pnlTop);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(15);
            this.pnlLeft.Size = new System.Drawing.Size(350, 795);
            this.pnlLeft.TabIndex = 0;
            // 
            // pnlContent
            // 
            this.pnlContent.AutoScroll = true;
            this.pnlContent.Controls.Add(this.grpEvidence);
            this.pnlContent.Controls.Add(this.grpDamage);
            this.pnlContent.Controls.Add(this.grpRental);
            this.pnlContent.Controls.Add(this.grpCustomer);
            this.pnlContent.Controls.Add(this.grpMeta);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(15, 80);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(320, 600);
            this.pnlContent.TabIndex = 2;
            // 
            // grpEvidence
            // 
            this.grpEvidence.Controls.Add(this.pbDamagePhoto);
            this.grpEvidence.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpEvidence.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpEvidence.Location = new System.Drawing.Point(0, 480);
            this.grpEvidence.Name = "grpEvidence";
            this.grpEvidence.Size = new System.Drawing.Size(303, 230);
            this.grpEvidence.TabIndex = 4;
            this.grpEvidence.TabStop = false;
            this.grpEvidence.Text = "Evidence";
            // 
            // pbDamagePhoto
            // 
            this.pbDamagePhoto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbDamagePhoto.Location = new System.Drawing.Point(3, 19);
            this.pbDamagePhoto.Name = "pbDamagePhoto";
            this.pbDamagePhoto.Size = new System.Drawing.Size(297, 208);
            this.pbDamagePhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbDamagePhoto.TabIndex = 0;
            this.pbDamagePhoto.TabStop = false;
            // 
            // grpDamage
            // 
            this.grpDamage.Controls.Add(this.txtEstimatedCost);
            this.grpDamage.Controls.Add(this.lblEstimatedCost);
            this.grpDamage.Controls.Add(this.txtDamageSeverity);
            this.grpDamage.Controls.Add(this.lblDamageSeverity);
            this.grpDamage.Controls.Add(this.txtDamageDescription);
            this.grpDamage.Controls.Add(this.lblDamageDescription);
            this.grpDamage.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpDamage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpDamage.Location = new System.Drawing.Point(0, 350);
            this.grpDamage.Name = "grpDamage";
            this.grpDamage.Size = new System.Drawing.Size(303, 130);
            this.grpDamage.TabIndex = 3;
            this.grpDamage.TabStop = false;
            this.grpDamage.Text = "Damage Details";
            // 
            // txtEstimatedCost
            // 
            this.txtEstimatedCost.BackColor = System.Drawing.SystemColors.Control;
            this.txtEstimatedCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEstimatedCost.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtEstimatedCost.Location = new System.Drawing.Point(100, 95);
            this.txtEstimatedCost.Name = "txtEstimatedCost";
            this.txtEstimatedCost.ReadOnly = true;
            this.txtEstimatedCost.Size = new System.Drawing.Size(190, 23);
            this.txtEstimatedCost.TabIndex = 5;
            // 
            // lblEstimatedCost
            // 
            this.lblEstimatedCost.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEstimatedCost.Location = new System.Drawing.Point(10, 95);
            this.lblEstimatedCost.Name = "lblEstimatedCost";
            this.lblEstimatedCost.Size = new System.Drawing.Size(80, 23);
            this.lblEstimatedCost.TabIndex = 4;
            this.lblEstimatedCost.Text = "Est. Cost:";
            this.lblEstimatedCost.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDamageSeverity
            // 
            this.txtDamageSeverity.BackColor = System.Drawing.SystemColors.Control;
            this.txtDamageSeverity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDamageSeverity.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDamageSeverity.Location = new System.Drawing.Point(100, 60);
            this.txtDamageSeverity.Name = "txtDamageSeverity";
            this.txtDamageSeverity.ReadOnly = true;
            this.txtDamageSeverity.Size = new System.Drawing.Size(190, 23);
            this.txtDamageSeverity.TabIndex = 3;
            // 
            // lblDamageSeverity
            // 
            this.lblDamageSeverity.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDamageSeverity.Location = new System.Drawing.Point(10, 60);
            this.lblDamageSeverity.Name = "lblDamageSeverity";
            this.lblDamageSeverity.Size = new System.Drawing.Size(80, 23);
            this.lblDamageSeverity.TabIndex = 2;
            this.lblDamageSeverity.Text = "Severity:";
            this.lblDamageSeverity.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDamageDescription
            // 
            this.txtDamageDescription.BackColor = System.Drawing.SystemColors.Control;
            this.txtDamageDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDamageDescription.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDamageDescription.Location = new System.Drawing.Point(100, 25);
            this.txtDamageDescription.Name = "txtDamageDescription";
            this.txtDamageDescription.ReadOnly = true;
            this.txtDamageDescription.Size = new System.Drawing.Size(190, 23);
            this.txtDamageDescription.TabIndex = 1;
            // 
            // lblDamageDescription
            // 
            this.lblDamageDescription.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDamageDescription.Location = new System.Drawing.Point(10, 25);
            this.lblDamageDescription.Name = "lblDamageDescription";
            this.lblDamageDescription.Size = new System.Drawing.Size(80, 23);
            this.lblDamageDescription.TabIndex = 0;
            this.lblDamageDescription.Text = "Description:";
            this.lblDamageDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpRental
            // 
            this.grpRental.Controls.Add(this.txtCreatedAt);
            this.grpRental.Controls.Add(this.lblCreatedAt);
            this.grpRental.Controls.Add(this.txtReportedBy);
            this.grpRental.Controls.Add(this.lblReportedBy);
            this.grpRental.Controls.Add(this.txtVehicleInfo);
            this.grpRental.Controls.Add(this.lblVehicleInfo);
            this.grpRental.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpRental.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpRental.Location = new System.Drawing.Point(0, 220);
            this.grpRental.Name = "grpRental";
            this.grpRental.Size = new System.Drawing.Size(303, 130);
            this.grpRental.TabIndex = 2;
            this.grpRental.TabStop = false;
            this.grpRental.Text = "Rental Context";
            // 
            // txtCreatedAt
            // 
            this.txtCreatedAt.BackColor = System.Drawing.SystemColors.Control;
            this.txtCreatedAt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCreatedAt.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCreatedAt.Location = new System.Drawing.Point(100, 95);
            this.txtCreatedAt.Name = "txtCreatedAt";
            this.txtCreatedAt.ReadOnly = true;
            this.txtCreatedAt.Size = new System.Drawing.Size(190, 23);
            this.txtCreatedAt.TabIndex = 5;
            // 
            // lblCreatedAt
            // 
            this.lblCreatedAt.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCreatedAt.Location = new System.Drawing.Point(10, 95);
            this.lblCreatedAt.Name = "lblCreatedAt";
            this.lblCreatedAt.Size = new System.Drawing.Size(80, 23);
            this.lblCreatedAt.TabIndex = 4;
            this.lblCreatedAt.Text = "Date:";
            this.lblCreatedAt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtReportedBy
            // 
            this.txtReportedBy.BackColor = System.Drawing.SystemColors.Control;
            this.txtReportedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReportedBy.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtReportedBy.Location = new System.Drawing.Point(100, 60);
            this.txtReportedBy.Name = "txtReportedBy";
            this.txtReportedBy.ReadOnly = true;
            this.txtReportedBy.Size = new System.Drawing.Size(190, 23);
            this.txtReportedBy.TabIndex = 3;
            // 
            // lblReportedBy
            // 
            this.lblReportedBy.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblReportedBy.Location = new System.Drawing.Point(10, 60);
            this.lblReportedBy.Name = "lblReportedBy";
            this.lblReportedBy.Size = new System.Drawing.Size(80, 23);
            this.lblReportedBy.TabIndex = 2;
            this.lblReportedBy.Text = "Reported By:";
            this.lblReportedBy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtVehicleInfo
            // 
            this.txtVehicleInfo.BackColor = System.Drawing.SystemColors.Control;
            this.txtVehicleInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVehicleInfo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtVehicleInfo.Location = new System.Drawing.Point(100, 25);
            this.txtVehicleInfo.Name = "txtVehicleInfo";
            this.txtVehicleInfo.ReadOnly = true;
            this.txtVehicleInfo.Size = new System.Drawing.Size(190, 23);
            this.txtVehicleInfo.TabIndex = 1;
            // 
            // lblVehicleInfo
            // 
            this.lblVehicleInfo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblVehicleInfo.Location = new System.Drawing.Point(10, 25);
            this.lblVehicleInfo.Name = "lblVehicleInfo";
            this.lblVehicleInfo.Size = new System.Drawing.Size(80, 23);
            this.lblVehicleInfo.TabIndex = 0;
            this.lblVehicleInfo.Text = "Vehicle:";
            this.lblVehicleInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpCustomer
            // 
            this.grpCustomer.Controls.Add(this.txtCustomerEmail);
            this.grpCustomer.Controls.Add(this.lblCustomerEmail);
            this.grpCustomer.Controls.Add(this.txtCustomerPhone);
            this.grpCustomer.Controls.Add(this.lblCustomerPhone);
            this.grpCustomer.Controls.Add(this.txtCustomerName);
            this.grpCustomer.Controls.Add(this.lblCustomerName);
            this.grpCustomer.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpCustomer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpCustomer.Location = new System.Drawing.Point(0, 90);
            this.grpCustomer.Name = "grpCustomer";
            this.grpCustomer.Size = new System.Drawing.Size(303, 130);
            this.grpCustomer.TabIndex = 1;
            this.grpCustomer.TabStop = false;
            this.grpCustomer.Text = "Customer Info";
            // 
            // txtCustomerEmail
            // 
            this.txtCustomerEmail.BackColor = System.Drawing.SystemColors.Control;
            this.txtCustomerEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerEmail.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCustomerEmail.Location = new System.Drawing.Point(100, 95);
            this.txtCustomerEmail.Name = "txtCustomerEmail";
            this.txtCustomerEmail.ReadOnly = true;
            this.txtCustomerEmail.Size = new System.Drawing.Size(190, 23);
            this.txtCustomerEmail.TabIndex = 5;
            // 
            // lblCustomerEmail
            // 
            this.lblCustomerEmail.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCustomerEmail.Location = new System.Drawing.Point(10, 95);
            this.lblCustomerEmail.Name = "lblCustomerEmail";
            this.lblCustomerEmail.Size = new System.Drawing.Size(80, 23);
            this.lblCustomerEmail.TabIndex = 4;
            this.lblCustomerEmail.Text = "Email:";
            this.lblCustomerEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCustomerPhone
            // 
            this.txtCustomerPhone.BackColor = System.Drawing.SystemColors.Control;
            this.txtCustomerPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerPhone.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCustomerPhone.Location = new System.Drawing.Point(100, 60);
            this.txtCustomerPhone.Name = "txtCustomerPhone";
            this.txtCustomerPhone.ReadOnly = true;
            this.txtCustomerPhone.Size = new System.Drawing.Size(190, 23);
            this.txtCustomerPhone.TabIndex = 3;
            // 
            // lblCustomerPhone
            // 
            this.lblCustomerPhone.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCustomerPhone.Location = new System.Drawing.Point(10, 60);
            this.lblCustomerPhone.Name = "lblCustomerPhone";
            this.lblCustomerPhone.Size = new System.Drawing.Size(80, 23);
            this.lblCustomerPhone.TabIndex = 2;
            this.lblCustomerPhone.Text = "Phone:";
            this.lblCustomerPhone.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.BackColor = System.Drawing.SystemColors.Control;
            this.txtCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCustomerName.Location = new System.Drawing.Point(100, 25);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.ReadOnly = true;
            this.txtCustomerName.Size = new System.Drawing.Size(190, 23);
            this.txtCustomerName.TabIndex = 1;
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCustomerName.Location = new System.Drawing.Point(10, 25);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(80, 23);
            this.lblCustomerName.TabIndex = 0;
            this.lblCustomerName.Text = "Name:";
            this.lblCustomerName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpMeta
            // 
            this.grpMeta.Controls.Add(this.txtStatus);
            this.grpMeta.Controls.Add(this.lblStatus);
            this.grpMeta.Controls.Add(this.txtDamageReportId);
            this.grpMeta.Controls.Add(this.lblDamageReportId);
            this.grpMeta.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpMeta.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpMeta.Location = new System.Drawing.Point(0, 0);
            this.grpMeta.Name = "grpMeta";
            this.grpMeta.Size = new System.Drawing.Size(303, 90);
            this.grpMeta.TabIndex = 0;
            this.grpMeta.TabStop = false;
            this.grpMeta.Text = "Report Meta";
            // 
            // txtStatus
            // 
            this.txtStatus.BackColor = System.Drawing.SystemColors.Control;
            this.txtStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtStatus.Location = new System.Drawing.Point(100, 55);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(190, 23);
            this.txtStatus.TabIndex = 3;
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStatus.Location = new System.Drawing.Point(10, 55);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(80, 23);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Status:";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDamageReportId
            // 
            this.txtDamageReportId.BackColor = System.Drawing.SystemColors.Control;
            this.txtDamageReportId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDamageReportId.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDamageReportId.Location = new System.Drawing.Point(100, 25);
            this.txtDamageReportId.Name = "txtDamageReportId";
            this.txtDamageReportId.ReadOnly = true;
            this.txtDamageReportId.Size = new System.Drawing.Size(190, 23);
            this.txtDamageReportId.TabIndex = 1;
            // 
            // lblDamageReportId
            // 
            this.lblDamageReportId.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDamageReportId.Location = new System.Drawing.Point(10, 25);
            this.lblDamageReportId.Name = "lblDamageReportId";
            this.lblDamageReportId.Size = new System.Drawing.Size(80, 23);
            this.lblDamageReportId.TabIndex = 0;
            this.lblDamageReportId.Text = "Report ID:";
            this.lblDamageReportId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlActions
            // 
            this.pnlActions.Controls.Add(this.txtChargeAmount);
            this.pnlActions.Controls.Add(this.lblChargeAmount);
            this.pnlActions.Controls.Add(this.btnClear);
            this.pnlActions.Controls.Add(this.btnReject);
            this.pnlActions.Controls.Add(this.btnApprove);
            this.pnlActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlActions.Location = new System.Drawing.Point(15, 680);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Size = new System.Drawing.Size(320, 100);
            this.pnlActions.TabIndex = 1;
            // 
            // txtChargeAmount
            // 
            this.txtChargeAmount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.txtChargeAmount.Location = new System.Drawing.Point(125, 10);
            this.txtChargeAmount.Name = "txtChargeAmount";
            this.txtChargeAmount.Size = new System.Drawing.Size(185, 25);
            this.txtChargeAmount.TabIndex = 4;
            // 
            // lblChargeAmount
            // 
            this.lblChargeAmount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblChargeAmount.Location = new System.Drawing.Point(5, 10);
            this.lblChargeAmount.Name = "lblChargeAmount";
            this.lblChargeAmount.Size = new System.Drawing.Size(115, 25);
            this.lblChargeAmount.TabIndex = 3;
            this.lblChargeAmount.Text = "Amount to Charge:";
            this.lblChargeAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(230, 50);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(80, 40);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // btnReject
            // 
            this.btnReject.BackColor = System.Drawing.Color.IndianRed;
            this.btnReject.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnReject.ForeColor = System.Drawing.Color.White;
            this.btnReject.Location = new System.Drawing.Point(120, 50);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(100, 40);
            this.btnReject.TabIndex = 1;
            this.btnReject.Text = "Reject";
            this.btnReject.UseVisualStyleBackColor = false;
            this.btnReject.Click += new System.EventHandler(this.BtnReject_Click);
            // 
            // btnApprove
            // 
            this.btnApprove.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnApprove.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnApprove.ForeColor = System.Drawing.Color.White;
            this.btnApprove.Location = new System.Drawing.Point(10, 50);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(100, 40);
            this.btnApprove.TabIndex = 0;
            this.btnApprove.Text = "Approve";
            this.btnApprove.UseVisualStyleBackColor = false;
            this.btnApprove.Click += new System.EventHandler(this.BtnApprove_Click);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.cmbStatusFilter);
            this.pnlTop.Controls.Add(this.lblStatusFilter);
            this.pnlTop.Controls.Add(this.btnSearch);
            this.pnlTop.Controls.Add(this.txtSearch);
            this.pnlTop.Controls.Add(this.lblSearch);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(15, 15);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(320, 65);
            this.pnlTop.TabIndex = 0;
            // 
            // cmbStatusFilter
            // 
            this.cmbStatusFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatusFilter.FormattingEnabled = true;
            this.cmbStatusFilter.Location = new System.Drawing.Point(100, 36);
            this.cmbStatusFilter.Name = "cmbStatusFilter";
            this.cmbStatusFilter.Size = new System.Drawing.Size(210, 21);
            this.cmbStatusFilter.TabIndex = 4;
            // 
            // lblStatusFilter
            // 
            this.lblStatusFilter.AutoSize = true;
            this.lblStatusFilter.Location = new System.Drawing.Point(10, 39);
            this.lblStatusFilter.Name = "lblStatusFilter";
            this.lblStatusFilter.Size = new System.Drawing.Size(79, 13);
            this.lblStatusFilter.TabIndex = 3;
            this.lblStatusFilter.Text = "Filter by Status:";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(235, 8);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(60, 10);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(160, 20);
            this.txtSearch.TabIndex = 1;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(10, 13);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(44, 13);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Search:";
            // 
            // dgvDamageClaims
            // 
            this.dgvDamageClaims.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDamageClaims.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDamageClaims.Location = new System.Drawing.Point(350, 0);
            this.dgvDamageClaims.Name = "dgvDamageClaims";
            this.dgvDamageClaims.Size = new System.Drawing.Size(983, 795);
            this.dgvDamageClaims.TabIndex = 1;
            // 
            // DamageClaimsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvDamageClaims);
            this.Controls.Add(this.pnlLeft);
            this.Name = "DamageClaimsForm";
            this.Size = new System.Drawing.Size(1333, 795);
            this.pnlLeft.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.grpEvidence.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbDamagePhoto)).EndInit();
            this.grpDamage.ResumeLayout(false);
            this.grpDamage.PerformLayout();
            this.grpRental.ResumeLayout(false);
            this.grpRental.PerformLayout();
            this.grpCustomer.ResumeLayout(false);
            this.grpCustomer.PerformLayout();
            this.grpMeta.ResumeLayout(false);
            this.grpMeta.PerformLayout();
            this.pnlActions.ResumeLayout(false);
            this.pnlActions.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDamageClaims)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        // Layout Containers
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlActions;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.DataGridView dgvDamageClaims;

        // GroupBoxes
        private System.Windows.Forms.GroupBox grpMeta;
        private System.Windows.Forms.GroupBox grpCustomer;
        private System.Windows.Forms.GroupBox grpRental;
        private System.Windows.Forms.GroupBox grpDamage;
        private System.Windows.Forms.GroupBox grpEvidence;
        
        // Search & Filter
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblStatusFilter;
        private System.Windows.Forms.ComboBox cmbStatusFilter;

        // Actions
        private System.Windows.Forms.Label lblChargeAmount;
        private System.Windows.Forms.TextBox txtChargeAmount;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.Button btnClear;

        // Content Fields
        private System.Windows.Forms.Label lblDamageReportId;
        private System.Windows.Forms.TextBox txtDamageReportId;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtStatus;
        
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label lblCustomerPhone;
        private System.Windows.Forms.TextBox txtCustomerPhone;
        private System.Windows.Forms.Label lblCustomerEmail;
        private System.Windows.Forms.TextBox txtCustomerEmail;
        
        private System.Windows.Forms.Label lblVehicleInfo;
        private System.Windows.Forms.TextBox txtVehicleInfo;
        private System.Windows.Forms.Label lblReportedBy;
        private System.Windows.Forms.TextBox txtReportedBy;
        private System.Windows.Forms.Label lblCreatedAt;
        private System.Windows.Forms.TextBox txtCreatedAt;
        
        private System.Windows.Forms.Label lblDamageDescription;
        private System.Windows.Forms.TextBox txtDamageDescription;
        private System.Windows.Forms.Label lblDamageSeverity;
        private System.Windows.Forms.TextBox txtDamageSeverity;
        private System.Windows.Forms.Label lblEstimatedCost;
        private System.Windows.Forms.TextBox txtEstimatedCost;
        
        private System.Windows.Forms.PictureBox pbDamagePhoto;
    }
}