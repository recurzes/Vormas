using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

namespace Vormas.Forms
{
    partial class ReservationForm
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

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.layoutMain = new System.Windows.Forms.TableLayoutPanel();
            this.pnlConfig = new System.Windows.Forms.Panel();
            this.grpConfig = new System.Windows.Forms.GroupBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.lblDateRange = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();

            this.lblNotes = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.grpVehicle = new System.Windows.Forms.GroupBox();
            this.dgvVehicles = new System.Windows.Forms.DataGridView();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblSummary = new System.Windows.Forms.Label();
            this.btnCreateReservation = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            
            this.layoutMain.SuspendLayout();
            this.pnlConfig.SuspendLayout();
            this.grpConfig.SuspendLayout();
            this.grpVehicle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehicles)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // layoutMain
            // 
            this.layoutMain.ColumnCount = 2;
            this.layoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F)); // Left Config
            this.layoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F)); // Right Grid
            this.layoutMain.Controls.Add(this.lblTitle, 0, 0);
            this.layoutMain.Controls.Add(this.pnlConfig, 0, 1);
            this.layoutMain.Controls.Add(this.grpVehicle, 1, 1);
            this.layoutMain.Controls.Add(this.pnlFooter, 0, 2);
            this.layoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutMain.Location = new System.Drawing.Point(0, 0);
            this.layoutMain.Name = "layoutMain";
            this.layoutMain.RowCount = 3;
            this.layoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F)); // Title
            this.layoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F)); // Content
            this.layoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F)); // Footer
            this.layoutMain.Size = new System.Drawing.Size(900, 600);
            this.layoutMain.Padding = new System.Windows.Forms.Padding(10);
            this.layoutMain.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.layoutMain.SetColumnSpan(this.lblTitle, 2);
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(13, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(209, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Create Reservation";
            // 
            // pnlConfig
            // 
            this.pnlConfig.Controls.Add(this.grpConfig);
            this.pnlConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlConfig.Location = new System.Drawing.Point(13, 63);
            this.pnlConfig.Name = "pnlConfig";
            this.pnlConfig.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.pnlConfig.Size = new System.Drawing.Size(294, 464);
            this.pnlConfig.TabIndex = 1;
            // 
            // grpConfig
            // 
            this.grpConfig.Controls.Add(this.lblCustomer);
            this.grpConfig.Controls.Add(this.cmbCustomer);
            this.grpConfig.Controls.Add(this.lblDateRange);
            this.grpConfig.Controls.Add(this.lblFrom);
            this.grpConfig.Controls.Add(this.dtpStartDate);
            this.grpConfig.Controls.Add(this.lblTo);
            this.grpConfig.Controls.Add(this.dtpEndDate);
            this.grpConfig.Controls.Add(this.lblNotes);
            this.grpConfig.Controls.Add(this.txtNotes);
            this.grpConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpConfig.Location = new System.Drawing.Point(0, 0);
            this.grpConfig.Name = "grpConfig";
            this.grpConfig.Size = new System.Drawing.Size(284, 464);
            this.grpConfig.TabIndex = 0;
            this.grpConfig.TabStop = false;
            this.grpConfig.Text = "Reservation Settings";
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(15, 30);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(95, 13);
            this.lblCustomer.TabIndex = 0;
            this.lblCustomer.Text = "Select Customer:";
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(15, 46);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(250, 21);
            this.cmbCustomer.TabIndex = 1;
            // 
            // lblDateRange
            // 
            this.lblDateRange.AutoSize = true;
            this.lblDateRange.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDateRange.Location = new System.Drawing.Point(15, 85);
            this.lblDateRange.Name = "lblDateRange";
            this.lblDateRange.Size = new System.Drawing.Size(120, 15);
            this.lblDateRange.TabIndex = 2;
            this.lblDateRange.Text = "Rental Date Range";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(15, 110);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(37, 13);
            this.lblFrom.TabIndex = 3;
            this.lblFrom.Text = "From:";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpStartDate.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(15, 126);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(250, 20);
            this.dtpStartDate.TabIndex = 4;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(15, 160);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(23, 13);
            this.lblTo.TabIndex = 5;
            this.lblTo.Text = "To:";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpEndDate.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(15, 176);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(250, 20);
            this.dtpEndDate.TabIndex = 6;

            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(15, 260);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(96, 13);
            this.lblNotes.TabIndex = 8;
            this.lblNotes.Text = "Additional Notes:";
            // 
            // txtNotes
            // 
            this.txtNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNotes.Location = new System.Drawing.Point(15, 276);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(250, 160);
            this.txtNotes.TabIndex = 9;
            // 
            // grpVehicle
            // 
            this.grpVehicle.Controls.Add(this.dgvVehicles);
            this.grpVehicle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpVehicle.Location = new System.Drawing.Point(313, 63);
            this.grpVehicle.Name = "grpVehicle";
            this.grpVehicle.Padding = new System.Windows.Forms.Padding(10);
            this.grpVehicle.Size = new System.Drawing.Size(574, 464);
            this.grpVehicle.TabIndex = 2;
            this.grpVehicle.TabStop = false;
            this.grpVehicle.Text = "Available Vehicles (Select One)";
            // 
            // dgvVehicles
            // 
            this.dgvVehicles.AllowUserToAddRows = false;
            this.dgvVehicles.AllowUserToDeleteRows = false;
            this.dgvVehicles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVehicles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVehicles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVehicles.Location = new System.Drawing.Point(10, 23);
            this.dgvVehicles.MultiSelect = false;
            this.dgvVehicles.Name = "dgvVehicles";
            this.dgvVehicles.ReadOnly = true;
            this.dgvVehicles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVehicles.Size = new System.Drawing.Size(554, 431);
            this.dgvVehicles.TabIndex = 0;
            // 
            // pnlFooter
            // 
            this.layoutMain.SetColumnSpan(this.pnlFooter, 2);
            this.pnlFooter.Controls.Add(this.btnCreateReservation);
            this.pnlFooter.Controls.Add(this.btnClear);
            this.pnlFooter.Controls.Add(this.lblSummary);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFooter.Location = new System.Drawing.Point(13, 533);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(874, 54);
            this.pnlFooter.TabIndex = 3;
            // 
            // lblSummary
            // 
            this.lblSummary.AutoSize = true;
            this.lblSummary.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSummary.ForeColor = System.Drawing.Color.DimGray;
            this.lblSummary.Location = new System.Drawing.Point(10, 18);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Size = new System.Drawing.Size(250, 19);
            this.lblSummary.TabIndex = 0;
            this.lblSummary.Text = "Booking Summary: No vehicle selected";
            // 
            // btnCreateReservation
            // 
            this.btnCreateReservation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateReservation.Location = new System.Drawing.Point(700, 10);
            this.btnCreateReservation.Name = "btnCreateReservation";
            this.btnCreateReservation.Size = new System.Drawing.Size(160, 35);
            this.btnCreateReservation.TabIndex = 1;
            this.btnCreateReservation.Text = "Create Reservation";
            this.btnCreateReservation.UseVisualStyleBackColor = true;
            this.btnCreateReservation.Click += new System.EventHandler(this.btnCreateReservation_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(590, 10);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 35);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // ReservationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutMain);
            this.Name = "ReservationForm";
            this.Size = new System.Drawing.Size(900, 600);
            this.layoutMain.ResumeLayout(false);
            this.layoutMain.PerformLayout();
            this.pnlConfig.ResumeLayout(false);
            this.grpConfig.ResumeLayout(false);
            this.grpConfig.PerformLayout();
            this.grpVehicle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehicles)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        // Layout
        private System.Windows.Forms.TableLayoutPanel layoutMain;
        private System.Windows.Forms.Panel pnlConfig;
        private System.Windows.Forms.GroupBox grpConfig;
        private System.Windows.Forms.GroupBox grpVehicle;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblTitle;

        // Config Controls
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.Label lblDateRange;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtpEndDate;

        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.TextBox txtNotes;

        // Vehicle Grid
        private System.Windows.Forms.DataGridView dgvVehicles;

        // Footer
        private System.Windows.Forms.Label lblSummary;
        private System.Windows.Forms.Button btnCreateReservation;
        private System.Windows.Forms.Button btnClear;
    }
}
