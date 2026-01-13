namespace Vormas.Forms
{
    partial class MaintenanceForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.titleLabel = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.grpWorkOrder = new System.Windows.Forms.GroupBox();
            this.tlpContent = new System.Windows.Forms.TableLayoutPanel();
            this.inputPanel = new System.Windows.Forms.Panel();
            this.cmbPriority = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbVehicles = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblScope = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.grpLogistics = new System.Windows.Forms.GroupBox();
            this.tlpLogistics = new System.Windows.Forms.TableLayoutPanel();
            this.lblVendor = new System.Windows.Forms.Label();
            this.txtVendor = new System.Windows.Forms.TextBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblCost = new System.Windows.Forms.Label();
            this.txtCost = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblStatusPill = new System.Windows.Forms.Label();
            this.footerPanel = new System.Windows.Forms.Panel();
            this.btnFix = new System.Windows.Forms.Button();
            this.btnLog = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            this.grpWorkOrder.SuspendLayout();
            this.tlpContent.SuspendLayout();
            this.inputPanel.SuspendLayout();
            this.grpLogistics.SuspendLayout();
            this.tlpLogistics.SuspendLayout();
            this.footerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(0, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Padding = new System.Windows.Forms.Padding(20, 20, 20, 10);
            this.titleLabel.Size = new System.Drawing.Size(189, 60);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "New Ticket";
            // 
            // mainPanel
            // 
            this.mainPanel.AutoScroll = true;
            this.mainPanel.Controls.Add(this.grpWorkOrder);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.mainPanel.Location = new System.Drawing.Point(0, 60);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(620, 310);
            this.mainPanel.TabIndex = 1;
            // 
            // grpWorkOrder
            // 
            this.grpWorkOrder.AutoSize = true;
            this.grpWorkOrder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grpWorkOrder.Controls.Add(this.tlpContent);
            this.grpWorkOrder.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpWorkOrder.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpWorkOrder.Location = new System.Drawing.Point(20, 0);
            this.grpWorkOrder.Name = "grpWorkOrder";
            this.grpWorkOrder.Padding = new System.Windows.Forms.Padding(10);
            this.grpWorkOrder.Size = new System.Drawing.Size(580, 425);
            this.grpWorkOrder.TabIndex = 0;
            this.grpWorkOrder.TabStop = false;
            this.grpWorkOrder.Text = "Ticket Details";
            // 
            // tlpContent
            // 
            this.tlpContent.AutoSize = true;
            this.tlpContent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpContent.ColumnCount = 1;
            this.tlpContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpContent.Controls.Add(this.inputPanel, 0, 0);
            this.tlpContent.Controls.Add(this.lblScope, 0, 1);
            this.tlpContent.Controls.Add(this.txtDescription, 0, 2);
            this.tlpContent.Controls.Add(this.grpLogistics, 0, 3);
            this.tlpContent.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpContent.Location = new System.Drawing.Point(10, 28);
            this.tlpContent.Name = "tlpContent";
            this.tlpContent.RowCount = 4;
            this.tlpContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F)); // Header
            this.tlpContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F)); // Scope Label
            this.tlpContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F)); // Description (Fixed Large)
            this.tlpContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 130F)); // Logistics
            this.tlpContent.Size = new System.Drawing.Size(560, 415);
            this.tlpContent.TabIndex = 0;
            // 
            // inputPanel
            // 
            this.inputPanel.Controls.Add(this.cmbPriority);
            this.inputPanel.Controls.Add(this.label4);
            this.inputPanel.Controls.Add(this.cmbVehicles);
            this.inputPanel.Controls.Add(this.label1);
            this.inputPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inputPanel.Location = new System.Drawing.Point(3, 3);
            this.inputPanel.Name = "inputPanel";
            this.inputPanel.Size = new System.Drawing.Size(554, 54);
            this.inputPanel.TabIndex = 0;
            // 
            // cmbPriority
            // 
            this.cmbPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPriority.FormattingEnabled = true;
            this.cmbPriority.Items.AddRange(new object[] { "Routine", "Urgent", "Critical" });
            this.cmbPriority.Location = new System.Drawing.Point(300, 23);
            this.cmbPriority.Name = "cmbPriority";
            this.cmbPriority.Size = new System.Drawing.Size(200, 25);
            this.cmbPriority.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(300, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "PRIORITY LEVEL";
            // 
            // cmbVehicles
            // 
            this.cmbVehicles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVehicles.FormattingEnabled = true;
            this.cmbVehicles.Location = new System.Drawing.Point(3, 23);
            this.cmbVehicles.Name = "cmbVehicles";
            this.cmbVehicles.Size = new System.Drawing.Size(280, 25);
            this.cmbVehicles.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "SELECT VEHICLE";
            // 
            // lblScope
            // 
            this.lblScope.AutoSize = true;
            this.lblScope.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblScope.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblScope.ForeColor = System.Drawing.Color.DimGray;
            this.lblScope.Location = new System.Drawing.Point(3, 72);
            this.lblScope.Name = "lblScope";
            this.lblScope.Size = new System.Drawing.Size(554, 13);
            this.lblScope.TabIndex = 1;
            this.lblScope.Text = "SCOPE OF WORK / TECHNICAL NOTES";
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDescription.Location = new System.Drawing.Point(3, 88);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(554, 51);
            this.txtDescription.TabIndex = 2;
            // 
            // grpLogistics
            // 
            this.grpLogistics.Controls.Add(this.tlpLogistics);
            this.grpLogistics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpLogistics.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.grpLogistics.Location = new System.Drawing.Point(3, 145);
            this.grpLogistics.Name = "grpLogistics";
            this.grpLogistics.Size = new System.Drawing.Size(554, 124);
            this.grpLogistics.TabIndex = 3;
            this.grpLogistics.TabStop = false;
            this.grpLogistics.Text = "Work Order Logistics";
            // 
            // tlpLogistics
            // 
            this.tlpLogistics.ColumnCount = 2;
            this.tlpLogistics.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpLogistics.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpLogistics.Controls.Add(this.lblVendor, 0, 0);
            this.tlpLogistics.Controls.Add(this.txtVendor, 0, 1);
            this.tlpLogistics.Controls.Add(this.lblDate, 1, 0);
            this.tlpLogistics.Controls.Add(this.dtpDate, 1, 1);
            this.tlpLogistics.Controls.Add(this.lblCost, 0, 2);
            this.tlpLogistics.Controls.Add(this.txtCost, 0, 3);
            this.tlpLogistics.Controls.Add(this.lblStatus, 1, 2);
            this.tlpLogistics.Controls.Add(this.lblStatusPill, 1, 3);
            this.tlpLogistics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLogistics.Location = new System.Drawing.Point(3, 19);
            this.tlpLogistics.Name = "tlpLogistics";
            this.tlpLogistics.RowCount = 4;
            this.tlpLogistics.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpLogistics.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpLogistics.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpLogistics.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpLogistics.Size = new System.Drawing.Size(548, 102);
            this.tlpLogistics.TabIndex = 0;
            // 
            // lblVendor
            // 
            this.lblVendor.AutoSize = true;
            this.lblVendor.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblVendor.ForeColor = System.Drawing.Color.Gray;
            this.lblVendor.Name = "lblVendor";
            this.lblVendor.Text = "ASSIGNED VENDOR";
            // 
            // txtVendor
            // 
            this.txtVendor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtVendor.Location = new System.Drawing.Point(3, 23);
            this.txtVendor.Name = "txtVendor";
            this.txtVendor.Size = new System.Drawing.Size(268, 23);
            this.txtVendor.TabIndex = 2;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblDate.ForeColor = System.Drawing.Color.Gray;
            this.lblDate.Name = "lblDate";
            this.lblDate.Text = "EST. COMPLETION";
            // 
            // dtpDate
            // 
            this.dtpDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(277, 23);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(268, 23);
            this.dtpDate.TabIndex = 3;
            // 
            // lblCost
            // 
            this.lblCost.AutoSize = true;
            this.lblCost.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblCost.ForeColor = System.Drawing.Color.Gray;
            this.lblCost.Name = "lblCost";
            this.lblCost.Text = "PROJECTED COST (PESO)";
            // 
            // txtCost
            // 
            this.txtCost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCost.Location = new System.Drawing.Point(3, 73);
            this.txtCost.Name = "txtCost";
            this.txtCost.Size = new System.Drawing.Size(268, 23);
            this.txtCost.TabIndex = 4;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblStatus.ForeColor = System.Drawing.Color.Gray;
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Text = "STATUS PREVIEW";
            // 
            // lblStatusPill
            // 
            this.lblStatusPill.AutoSize = true;
            this.lblStatusPill.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.lblStatusPill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatusPill.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStatusPill.ForeColor = System.Drawing.Color.Orange;
            this.lblStatusPill.Location = new System.Drawing.Point(277, 73);
            this.lblStatusPill.Margin = new System.Windows.Forms.Padding(3);
            this.lblStatusPill.Name = "lblStatusPill";
            this.lblStatusPill.Size = new System.Drawing.Size(268, 24);
            this.lblStatusPill.TabIndex = 5;
            this.lblStatusPill.Text = "IN SHOP (PENDING)";
            this.lblStatusPill.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // footerPanel
            // 
            this.footerPanel.Controls.Add(this.btnFix);
            this.footerPanel.Controls.Add(this.btnLog);
            this.footerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footerPanel.Location = new System.Drawing.Point(0, 370);
            this.footerPanel.Name = "footerPanel";
            this.footerPanel.Padding = new System.Windows.Forms.Padding(20);
            this.footerPanel.Size = new System.Drawing.Size(620, 80);
            this.footerPanel.TabIndex = 2;
            // 
            // btnFix
            // 
            this.btnFix.BackColor = System.Drawing.Color.White;
            this.btnFix.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFix.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnFix.Location = new System.Drawing.Point(400, 26);
            this.btnFix.Name = "btnFix";
            this.btnFix.Size = new System.Drawing.Size(175, 25);
            this.btnFix.TabIndex = 3;
            this.btnFix.Text = "Mark Complete (Dev)";
            this.btnFix.UseVisualStyleBackColor = false;
            this.btnFix.Click += new System.EventHandler(this.btnFix_Click);
            // 
            // btnLog
            // 
            this.btnLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLog.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLog.ForeColor = System.Drawing.Color.White;
            this.btnLog.Location = new System.Drawing.Point(25, 20);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(350, 40);
            this.btnLog.TabIndex = 2;
            this.btnLog.Text = "CREATE SERVICE TICKET";
            this.btnLog.UseVisualStyleBackColor = false;
            this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
            // 
            // MaintenanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.footerPanel);
            this.Controls.Add(this.titleLabel);
            this.mainPanel.BringToFront();
            this.Name = "MaintenanceForm";
            this.Size = new System.Drawing.Size(620, 650);
            this.mainPanel.ResumeLayout(false);
            this.grpWorkOrder.ResumeLayout(false);
            this.grpWorkOrder.PerformLayout();
            this.tlpContent.ResumeLayout(false);
            this.tlpContent.PerformLayout();
            this.inputPanel.ResumeLayout(false);
            this.inputPanel.PerformLayout();
            this.grpLogistics.ResumeLayout(false);
            this.tlpLogistics.ResumeLayout(false);
            this.tlpLogistics.PerformLayout();
            this.footerPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.GroupBox grpWorkOrder;
        private System.Windows.Forms.TableLayoutPanel tlpContent;
        private System.Windows.Forms.Panel inputPanel;
        private System.Windows.Forms.ComboBox cmbPriority;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbVehicles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblScope;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.GroupBox grpLogistics;
        private System.Windows.Forms.TableLayoutPanel tlpLogistics;
        private System.Windows.Forms.Label lblVendor;
        private System.Windows.Forms.TextBox txtVendor;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblCost;
        private System.Windows.Forms.TextBox txtCost;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblStatusPill;
        private System.Windows.Forms.Panel footerPanel;
        private System.Windows.Forms.Button btnLog;
        private System.Windows.Forms.Button btnFix;
    }
}
