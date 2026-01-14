using System.ComponentModel;

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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.grpCustomer = new System.Windows.Forms.GroupBox();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.grpDateRange = new System.Windows.Forms.GroupBox();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.grpVehicle = new System.Windows.Forms.GroupBox();
            this.lblSelectedVehicle = new System.Windows.Forms.Label();
            this.dgvVehicles = new System.Windows.Forms.DataGridView();
            this.grpDetails = new System.Windows.Forms.GroupBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.btnCreateReservation = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.grpCustomer.SuspendLayout();
            this.grpDateRange.SuspendLayout();
            this.grpVehicle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehicles)).BeginInit();
            this.grpDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(17, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(209, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Create Reservation";
            // 
            // grpCustomer
            // 
            this.grpCustomer.Controls.Add(this.cmbCustomer);
            this.grpCustomer.Controls.Add(this.lblCustomer);
            this.grpCustomer.Location = new System.Drawing.Point(17, 50);
            this.grpCustomer.Name = "grpCustomer";
            this.grpCustomer.Size = new System.Drawing.Size(320, 61);
            this.grpCustomer.TabIndex = 1;
            this.grpCustomer.TabStop = false;
            this.grpCustomer.Text = "Step 1: Select Customer";
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(86, 24);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(220, 21);
            this.cmbCustomer.TabIndex = 1;
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(13, 27);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(54, 13);
            this.lblCustomer.TabIndex = 0;
            this.lblCustomer.Text = "Customer:";
            // 
            // grpDateRange
            // 
            this.grpDateRange.Controls.Add(this.dtpEndDate);
            this.grpDateRange.Controls.Add(this.lblEndDate);
            this.grpDateRange.Controls.Add(this.dtpStartDate);
            this.grpDateRange.Controls.Add(this.lblStartDate);
            this.grpDateRange.Location = new System.Drawing.Point(350, 50);
            this.grpDateRange.Name = "grpDateRange";
            this.grpDateRange.Size = new System.Drawing.Size(320, 61);
            this.grpDateRange.TabIndex = 2;
            this.grpDateRange.TabStop = false;
            this.grpDateRange.Text = "Step 2: Select Dates";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(200, 24);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(110, 20);
            this.dtpEndDate.TabIndex = 3;
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(170, 27);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(23, 13);
            this.lblEndDate.TabIndex = 2;
            this.lblEndDate.Text = "To:";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(50, 24);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(110, 20);
            this.dtpStartDate.TabIndex = 1;
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(13, 27);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(33, 13);
            this.lblStartDate.TabIndex = 0;
            this.lblStartDate.Text = "From:";
            // 
            // grpVehicle
            // 
            this.grpVehicle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.grpVehicle.Controls.Add(this.lblSelectedVehicle);
            this.grpVehicle.Controls.Add(this.dgvVehicles);
            this.grpVehicle.Location = new System.Drawing.Point(17, 119);
            this.grpVehicle.Name = "grpVehicle";
            this.grpVehicle.Size = new System.Drawing.Size(653, 180);
            this.grpVehicle.TabIndex = 3;
            this.grpVehicle.TabStop = false;
            this.grpVehicle.Text = "Step 3: Select Vehicle";
            // 
            // lblSelectedVehicle
            // 
            this.lblSelectedVehicle.AutoSize = true;
            this.lblSelectedVehicle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSelectedVehicle.Location = new System.Drawing.Point(13, 155);
            this.lblSelectedVehicle.Name = "lblSelectedVehicle";
            this.lblSelectedVehicle.Size = new System.Drawing.Size(116, 15);
            this.lblSelectedVehicle.TabIndex = 1;
            this.lblSelectedVehicle.Text = "No vehicle selected";
            // 
            // dgvVehicles
            // 
            this.dgvVehicles.AllowUserToAddRows = false;
            this.dgvVehicles.AllowUserToDeleteRows = false;
            this.dgvVehicles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvVehicles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVehicles.Location = new System.Drawing.Point(13, 19);
            this.dgvVehicles.Name = "dgvVehicles";
            this.dgvVehicles.RowTemplate.Height = 25;
            this.dgvVehicles.Size = new System.Drawing.Size(627, 130);
            this.dgvVehicles.TabIndex = 0;
            // 
            // grpDetails
            // 
            this.grpDetails.Controls.Add(this.txtNotes);
            this.grpDetails.Controls.Add(this.lblNotes);
            this.grpDetails.Location = new System.Drawing.Point(17, 305);
            this.grpDetails.Name = "grpDetails";
            this.grpDetails.Size = new System.Drawing.Size(400, 100);
            this.grpDetails.TabIndex = 4;
            this.grpDetails.TabStop = false;
            this.grpDetails.Text = "Step 4: Additional Details (Optional)";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(13, 40);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(370, 50);
            this.txtNotes.TabIndex = 1;
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(13, 22);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(38, 13);
            this.lblNotes.TabIndex = 0;
            this.lblNotes.Text = "Notes:";
            // 
            // btnCreateReservation
            // 
            this.btnCreateReservation.BackColor = System.Drawing.Color.ForestGreen;
            this.btnCreateReservation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateReservation.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCreateReservation.ForeColor = System.Drawing.Color.White;
            this.btnCreateReservation.Location = new System.Drawing.Point(429, 423);
            this.btnCreateReservation.Name = "btnCreateReservation";
            this.btnCreateReservation.Size = new System.Drawing.Size(150, 35);
            this.btnCreateReservation.TabIndex = 5;
            this.btnCreateReservation.Text = "Create Reservation";
            this.btnCreateReservation.UseVisualStyleBackColor = false;
            this.btnCreateReservation.Click += new System.EventHandler(this.btnCreateReservation_Click);
            // 
            // btnClear
            // 
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Location = new System.Drawing.Point(585, 423);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(84, 35);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Location = new System.Drawing.Point(339, 423);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(84, 35);
            this.btnRefresh.TabIndex = 7;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // ReservationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnCreateReservation);
            this.Controls.Add(this.grpDetails);
            this.Controls.Add(this.grpVehicle);
            this.Controls.Add(this.grpDateRange);
            this.Controls.Add(this.grpCustomer);
            this.Controls.Add(this.lblTitle);
            this.Name = "ReservationForm";
            this.Size = new System.Drawing.Size(686, 490);
            this.grpCustomer.ResumeLayout(false);
            this.grpCustomer.PerformLayout();
            this.grpDateRange.ResumeLayout(false);
            this.grpDateRange.PerformLayout();
            this.grpVehicle.ResumeLayout(false);
            this.grpVehicle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehicles)).EndInit();
            this.grpDetails.ResumeLayout(false);
            this.grpDetails.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpCustomer;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.GroupBox grpDateRange;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.GroupBox grpVehicle;
        private System.Windows.Forms.Label lblSelectedVehicle;
        private System.Windows.Forms.DataGridView dgvVehicles;
        private System.Windows.Forms.GroupBox grpDetails;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.Button btnCreateReservation;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnRefresh;

        #endregion
    }
}
