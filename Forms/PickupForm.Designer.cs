using System.ComponentModel;

namespace Vormas.Forms
{
    partial class PickupForm
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
            this.btnClear = new System.Windows.Forms.Button();
            this.chkIsSmokedIn = new System.Windows.Forms.CheckBox();
            this.chkIsClean = new System.Windows.Forms.CheckBox();
            this.chkAccessoriesOk = new System.Windows.Forms.CheckBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.grpInspection = new System.Windows.Forms.GroupBox();
            this.dtpPickupDate = new System.Windows.Forms.DateTimePicker();
            this.lblPickupDate = new System.Windows.Forms.Label();
            this.numOdometer = new System.Windows.Forms.NumericUpDown();
            this.lblOdometer = new System.Windows.Forms.Label();
            this.numFuelLevel = new System.Windows.Forms.NumericUpDown();
            this.lblFuelLevel = new System.Windows.Forms.Label();
            this.numDeposit = new System.Windows.Forms.NumericUpDown();
            this.lblDeposit = new System.Windows.Forms.Label();
            this.dtpExpectedReturn = new System.Windows.Forms.DateTimePicker();
            this.lblExpectedReturn = new System.Windows.Forms.Label();
            this.grpRentalDetails = new System.Windows.Forms.GroupBox();
            this.dgvVehicles = new System.Windows.Forms.DataGridView();
            this.grpVehicle = new System.Windows.Forms.GroupBox();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.btnStartRental = new System.Windows.Forms.Button();
            this.grpCustomer = new System.Windows.Forms.GroupBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.grpInspection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOdometer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFuelLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDeposit)).BeginInit();
            this.grpRentalDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehicles)).BeginInit();
            this.grpVehicle.SuspendLayout();
            this.grpCustomer.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClear
            // 
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Location = new System.Drawing.Point(583, 418);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(86, 35);
            this.btnClear.TabIndex = 13;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // chkIsSmokedIn
            // 
            this.chkIsSmokedIn.AutoSize = true;
            this.chkIsSmokedIn.Location = new System.Drawing.Point(13, 22);
            this.chkIsSmokedIn.Name = "chkIsSmokedIn";
            this.chkIsSmokedIn.Size = new System.Drawing.Size(88, 17);
            this.chkIsSmokedIn.TabIndex = 0;
            this.chkIsSmokedIn.Text = "Is Smoked In";
            this.chkIsSmokedIn.UseVisualStyleBackColor = true;
            // 
            // chkIsClean
            // 
            this.chkIsClean.AutoSize = true;
            this.chkIsClean.Checked = true;
            this.chkIsClean.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsClean.Location = new System.Drawing.Point(111, 22);
            this.chkIsClean.Name = "chkIsClean";
            this.chkIsClean.Size = new System.Drawing.Size(64, 17);
            this.chkIsClean.TabIndex = 1;
            this.chkIsClean.Text = "Is Clean";
            this.chkIsClean.UseVisualStyleBackColor = true;
            // 
            // chkAccessoriesOk
            // 
            this.chkAccessoriesOk.AutoSize = true;
            this.chkAccessoriesOk.Checked = true;
            this.chkAccessoriesOk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAccessoriesOk.Location = new System.Drawing.Point(189, 22);
            this.chkAccessoriesOk.Name = "chkAccessoriesOk";
            this.chkAccessoriesOk.Size = new System.Drawing.Size(101, 17);
            this.chkAccessoriesOk.TabIndex = 2;
            this.chkAccessoriesOk.Text = "Accessories OK";
            this.chkAccessoriesOk.UseVisualStyleBackColor = true;
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(13, 61);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(266, 53);
            this.txtNotes.TabIndex = 4;
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(13, 45);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(38, 13);
            this.lblNotes.TabIndex = 3;
            this.lblNotes.Text = "Notes:";
            // 
            // grpInspection
            // 
            this.grpInspection.Controls.Add(this.chkIsSmokedIn);
            this.grpInspection.Controls.Add(this.chkIsClean);
            this.grpInspection.Controls.Add(this.chkAccessoriesOk);
            this.grpInspection.Controls.Add(this.txtNotes);
            this.grpInspection.Controls.Add(this.lblNotes);
            this.grpInspection.Location = new System.Drawing.Point(377, 284);
            this.grpInspection.Name = "grpInspection";
            this.grpInspection.Size = new System.Drawing.Size(291, 121);
            this.grpInspection.TabIndex = 11;
            this.grpInspection.TabStop = false;
            this.grpInspection.Text = "Vehicle Inspection";
            // 
            // dtpPickupDate
            // 
            this.dtpPickupDate.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpPickupDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPickupDate.Location = new System.Drawing.Point(103, 22);
            this.dtpPickupDate.Name = "dtpPickupDate";
            this.dtpPickupDate.Size = new System.Drawing.Size(138, 20);
            this.dtpPickupDate.TabIndex = 1;
            // 
            // lblPickupDate
            // 
            this.lblPickupDate.AutoSize = true;
            this.lblPickupDate.Location = new System.Drawing.Point(13, 24);
            this.lblPickupDate.Name = "lblPickupDate";
            this.lblPickupDate.Size = new System.Drawing.Size(69, 13);
            this.lblPickupDate.TabIndex = 0;
            this.lblPickupDate.Text = "Pickup Date:";
            // 
            // numOdometer
            // 
            this.numOdometer.DecimalPlaces = 2;
            this.numOdometer.Location = new System.Drawing.Point(103, 48);
            this.numOdometer.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            this.numOdometer.Name = "numOdometer";
            this.numOdometer.Size = new System.Drawing.Size(103, 20);
            this.numOdometer.TabIndex = 3;
            // 
            // lblOdometer
            // 
            this.lblOdometer.AutoSize = true;
            this.lblOdometer.Location = new System.Drawing.Point(13, 50);
            this.lblOdometer.Name = "lblOdometer";
            this.lblOdometer.Size = new System.Drawing.Size(56, 13);
            this.lblOdometer.TabIndex = 2;
            this.lblOdometer.Text = "Odometer:";
            // 
            // numFuelLevel
            // 
            this.numFuelLevel.DecimalPlaces = 2;
            this.numFuelLevel.Increment = new decimal(new int[] { 25, 0, 0, 131072 });
            this.numFuelLevel.Location = new System.Drawing.Point(103, 74);
            this.numFuelLevel.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numFuelLevel.Name = "numFuelLevel";
            this.numFuelLevel.Size = new System.Drawing.Size(69, 20);
            this.numFuelLevel.TabIndex = 5;
            this.numFuelLevel.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblFuelLevel
            // 
            this.lblFuelLevel.AutoSize = true;
            this.lblFuelLevel.Location = new System.Drawing.Point(13, 76);
            this.lblFuelLevel.Name = "lblFuelLevel";
            this.lblFuelLevel.Size = new System.Drawing.Size(83, 13);
            this.lblFuelLevel.TabIndex = 4;
            this.lblFuelLevel.Text = "Fuel Level (0-1):";
            // 
            // numDeposit
            // 
            this.numDeposit.DecimalPlaces = 2;
            this.numDeposit.Location = new System.Drawing.Point(103, 100);
            this.numDeposit.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            this.numDeposit.Name = "numDeposit";
            this.numDeposit.Size = new System.Drawing.Size(103, 20);
            this.numDeposit.TabIndex = 7;
            this.numDeposit.Value = new decimal(new int[] { 5000, 0, 0, 0 });
            // 
            // lblDeposit
            // 
            this.lblDeposit.AutoSize = true;
            this.lblDeposit.Location = new System.Drawing.Point(13, 102);
            this.lblDeposit.Name = "lblDeposit";
            this.lblDeposit.Size = new System.Drawing.Size(46, 13);
            this.lblDeposit.TabIndex = 6;
            this.lblDeposit.Text = "Deposit:";
            // 
            // dtpExpectedReturn
            // 
            this.dtpExpectedReturn.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpExpectedReturn.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpExpectedReturn.Location = new System.Drawing.Point(103, 126);
            this.dtpExpectedReturn.Name = "dtpExpectedReturn";
            this.dtpExpectedReturn.Size = new System.Drawing.Size(138, 20);
            this.dtpExpectedReturn.TabIndex = 9;
            this.dtpExpectedReturn.Value = System.DateTime.Now.AddDays(1);
            // 
            // lblExpectedReturn
            // 
            this.lblExpectedReturn.AutoSize = true;
            this.lblExpectedReturn.Location = new System.Drawing.Point(13, 128);
            this.lblExpectedReturn.Name = "lblExpectedReturn";
            this.lblExpectedReturn.Size = new System.Drawing.Size(88, 13);
            this.lblExpectedReturn.TabIndex = 8;
            this.lblExpectedReturn.Text = "Expected Return:";
            // 
            // grpRentalDetails
            // 
            this.grpRentalDetails.Controls.Add(this.dtpPickupDate);
            this.grpRentalDetails.Controls.Add(this.lblPickupDate);
            this.grpRentalDetails.Controls.Add(this.numOdometer);
            this.grpRentalDetails.Controls.Add(this.lblOdometer);
            this.grpRentalDetails.Controls.Add(this.numFuelLevel);
            this.grpRentalDetails.Controls.Add(this.lblFuelLevel);
            this.grpRentalDetails.Controls.Add(this.numDeposit);
            this.grpRentalDetails.Controls.Add(this.lblDeposit);
            this.grpRentalDetails.Controls.Add(this.dtpExpectedReturn);
            this.grpRentalDetails.Controls.Add(this.lblExpectedReturn);
            this.grpRentalDetails.Location = new System.Drawing.Point(17, 284);
            this.grpRentalDetails.Name = "grpRentalDetails";
            this.grpRentalDetails.Size = new System.Drawing.Size(343, 155);
            this.grpRentalDetails.TabIndex = 10;
            this.grpRentalDetails.TabStop = false;
            this.grpRentalDetails.Text = "Rental Details";
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
            this.dgvVehicles.Size = new System.Drawing.Size(626, 126);
            this.dgvVehicles.TabIndex = 0;
            // 
            // grpVehicle
            // 
            this.grpVehicle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.grpVehicle.Controls.Add(this.dgvVehicles);
            this.grpVehicle.Location = new System.Drawing.Point(17, 119);
            this.grpVehicle.Name = "grpVehicle";
            this.grpVehicle.Size = new System.Drawing.Size(651, 156);
            this.grpVehicle.TabIndex = 9;
            this.grpVehicle.TabStop = false;
            this.grpVehicle.Text = "Available Vehicles";
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(86, 24);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(241, 21);
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
            // btnStartRental
            // 
            this.btnStartRental.BackColor = System.Drawing.Color.ForestGreen;
            this.btnStartRental.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartRental.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnStartRental.ForeColor = System.Drawing.Color.White;
            this.btnStartRental.Location = new System.Drawing.Point(463, 418);
            this.btnStartRental.Name = "btnStartRental";
            this.btnStartRental.Size = new System.Drawing.Size(111, 35);
            this.btnStartRental.TabIndex = 12;
            this.btnStartRental.Text = "Start Rental";
            this.btnStartRental.UseVisualStyleBackColor = false;
            this.btnStartRental.Click += new System.EventHandler(this.btnStartRental_Click);
            // 
            // grpCustomer
            // 
            this.grpCustomer.Controls.Add(this.cmbCustomer);
            this.grpCustomer.Controls.Add(this.lblCustomer);
            this.grpCustomer.Location = new System.Drawing.Point(17, 50);
            this.grpCustomer.Name = "grpCustomer";
            this.grpCustomer.Size = new System.Drawing.Size(343, 61);
            this.grpCustomer.TabIndex = 8;
            this.grpCustomer.TabStop = false;
            this.grpCustomer.Text = "Customer Selection";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(17, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(163, 30);
            this.lblTitle.TabIndex = 7;
            this.lblTitle.Text = "Vehicle Pickup";
            // 
            // PickupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.grpInspection);
            this.Controls.Add(this.grpRentalDetails);
            this.Controls.Add(this.grpVehicle);
            this.Controls.Add(this.btnStartRental);
            this.Controls.Add(this.grpCustomer);
            this.Controls.Add(this.lblTitle);
            this.Name = "PickupForm";
            this.Size = new System.Drawing.Size(686, 468);
            this.grpInspection.ResumeLayout(false);
            this.grpInspection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOdometer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFuelLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDeposit)).EndInit();
            this.grpRentalDetails.ResumeLayout(false);
            this.grpRentalDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehicles)).EndInit();
            this.grpVehicle.ResumeLayout(false);
            this.grpCustomer.ResumeLayout(false);
            this.grpCustomer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.CheckBox chkIsSmokedIn;
        private System.Windows.Forms.CheckBox chkIsClean;
        private System.Windows.Forms.CheckBox chkAccessoriesOk;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.GroupBox grpInspection;
        private System.Windows.Forms.DateTimePicker dtpPickupDate;
        private System.Windows.Forms.Label lblPickupDate;
        private System.Windows.Forms.NumericUpDown numOdometer;
        private System.Windows.Forms.Label lblOdometer;
        private System.Windows.Forms.NumericUpDown numFuelLevel;
        private System.Windows.Forms.Label lblFuelLevel;
        private System.Windows.Forms.NumericUpDown numDeposit;
        private System.Windows.Forms.Label lblDeposit;
        private System.Windows.Forms.DateTimePicker dtpExpectedReturn;
        private System.Windows.Forms.Label lblExpectedReturn;
        private System.Windows.Forms.GroupBox grpRentalDetails;
        private System.Windows.Forms.DataGridView dgvVehicles;
        private System.Windows.Forms.GroupBox grpVehicle;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Button btnStartRental;
        private System.Windows.Forms.GroupBox grpCustomer;
        private System.Windows.Forms.Label lblTitle;

        #endregion
    }
}