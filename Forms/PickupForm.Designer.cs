using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

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
            this.layoutMain = new System.Windows.Forms.TableLayoutPanel();
            this.grpCustomer = new System.Windows.Forms.GroupBox();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.grpVehicle = new System.Windows.Forms.GroupBox();
            this.dgvVehicles = new System.Windows.Forms.DataGridView();
            this.pnlTransaction = new System.Windows.Forms.TableLayoutPanel();
            this.grpRentalDetails = new System.Windows.Forms.GroupBox();
            this.layoutRentalDetails = new System.Windows.Forms.TableLayoutPanel();
            this.lblPickupDate = new System.Windows.Forms.Label();
            this.dtpPickupDate = new System.Windows.Forms.DateTimePicker();
            this.lblExpectedReturn = new System.Windows.Forms.Label();
            this.dtpExpectedReturn = new System.Windows.Forms.DateTimePicker();
            this.lblOdometer = new System.Windows.Forms.Label();
            this.numOdometer = new System.Windows.Forms.NumericUpDown();
            this.lblFuelLevel = new System.Windows.Forms.Label();
            this.numFuelLevel = new System.Windows.Forms.NumericUpDown();
            this.lblDeposit = new System.Windows.Forms.Label();
            this.numDeposit = new System.Windows.Forms.NumericUpDown();
            this.grpInspection = new System.Windows.Forms.GroupBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.pnlCheckBoxes = new System.Windows.Forms.FlowLayoutPanel();
            this.chkIsSmokedIn = new System.Windows.Forms.CheckBox();
            this.chkIsClean = new System.Windows.Forms.CheckBox();
            this.chkAccessoriesOk = new System.Windows.Forms.CheckBox();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnStartRental = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.layoutMain.SuspendLayout();
            this.grpCustomer.SuspendLayout();
            this.grpVehicle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehicles)).BeginInit();
            this.pnlTransaction.SuspendLayout();
            this.grpRentalDetails.SuspendLayout();
            this.layoutRentalDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOdometer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFuelLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDeposit)).BeginInit();
            this.grpInspection.SuspendLayout();
            this.pnlCheckBoxes.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // layoutMain
            // 
            this.layoutMain.ColumnCount = 1;
            this.layoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutMain.Controls.Add(this.lblTitle, 0, 0);
            this.layoutMain.Controls.Add(this.grpCustomer, 0, 1);
            this.layoutMain.Controls.Add(this.grpVehicle, 0, 2);
            this.layoutMain.Controls.Add(this.pnlTransaction, 0, 3);
            this.layoutMain.Controls.Add(this.pnlFooter, 0, 4);
            this.layoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutMain.Location = new System.Drawing.Point(0, 0);
            this.layoutMain.Name = "layoutMain";
            this.layoutMain.Padding = new System.Windows.Forms.Padding(10);
            this.layoutMain.RowCount = 5;
            this.layoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F)); // Title
            this.layoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F)); // Customer
            this.layoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F)); // Vehicle
            this.layoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F)); // Details
            this.layoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F)); // Footer
            this.layoutMain.Size = new System.Drawing.Size(900, 600);
            this.layoutMain.TabIndex = 0;
            //
            // lblTitle
            //
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(13, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(163, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Vehicle Pickup";
            // 
            // grpCustomer
            // 
            this.grpCustomer.Controls.Add(this.cmbCustomer);
            this.grpCustomer.Controls.Add(this.lblCustomer);
            this.grpCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCustomer.Location = new System.Drawing.Point(13, 53);
            this.grpCustomer.Name = "grpCustomer";
            this.grpCustomer.Padding = new System.Windows.Forms.Padding(10);
            this.grpCustomer.Size = new System.Drawing.Size(874, 64);
            this.grpCustomer.TabIndex = 1;
            this.grpCustomer.TabStop = false;
            this.grpCustomer.Text = "Customer Selection";
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(85, 25);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(776, 21);
            this.cmbCustomer.TabIndex = 1;
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(13, 28);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(54, 13);
            this.lblCustomer.TabIndex = 0;
            this.lblCustomer.Text = "Customer:";
            // 
            // grpVehicle
            // 
            this.grpVehicle.Controls.Add(this.dgvVehicles);
            this.grpVehicle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpVehicle.Location = new System.Drawing.Point(13, 123);
            this.grpVehicle.Name = "grpVehicle";
            this.grpVehicle.Padding = new System.Windows.Forms.Padding(10);
            this.grpVehicle.Size = new System.Drawing.Size(874, 252);
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
            this.dgvVehicles.Size = new System.Drawing.Size(854, 219);
            this.dgvVehicles.TabIndex = 0;
            // 
            // pnlTransaction
            // 
            this.pnlTransaction.ColumnCount = 2;
            this.pnlTransaction.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlTransaction.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlTransaction.Controls.Add(this.grpRentalDetails, 0, 0);
            this.pnlTransaction.Controls.Add(this.grpInspection, 1, 0);
            this.pnlTransaction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTransaction.Location = new System.Drawing.Point(13, 381);
            this.pnlTransaction.Name = "pnlTransaction";
            this.pnlTransaction.RowCount = 1;
            this.pnlTransaction.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlTransaction.Size = new System.Drawing.Size(874, 166);
            this.pnlTransaction.TabIndex = 3;
            // 
            // grpRentalDetails
            // 
            this.grpRentalDetails.Controls.Add(this.layoutRentalDetails);
            this.grpRentalDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpRentalDetails.Location = new System.Drawing.Point(3, 3);
            this.grpRentalDetails.Name = "grpRentalDetails";
            this.grpRentalDetails.Padding = new System.Windows.Forms.Padding(5);
            this.grpRentalDetails.Size = new System.Drawing.Size(431, 160);
            this.grpRentalDetails.TabIndex = 0;
            this.grpRentalDetails.TabStop = false;
            this.grpRentalDetails.Text = "Transaction Details";
            // 
            // layoutRentalDetails
            // 
            this.layoutRentalDetails.ColumnCount = 2;
            this.layoutRentalDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.layoutRentalDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutRentalDetails.Controls.Add(this.lblPickupDate, 0, 0);
            this.layoutRentalDetails.Controls.Add(this.dtpPickupDate, 1, 0);
            this.layoutRentalDetails.Controls.Add(this.lblExpectedReturn, 0, 1);
            this.layoutRentalDetails.Controls.Add(this.dtpExpectedReturn, 1, 1);
            this.layoutRentalDetails.Controls.Add(this.lblOdometer, 0, 2);
            this.layoutRentalDetails.Controls.Add(this.numOdometer, 1, 2);
            this.layoutRentalDetails.Controls.Add(this.lblFuelLevel, 0, 3);
            this.layoutRentalDetails.Controls.Add(this.numFuelLevel, 1, 3);
            this.layoutRentalDetails.Controls.Add(this.lblDeposit, 0, 4);
            this.layoutRentalDetails.Controls.Add(this.numDeposit, 1, 4);
            this.layoutRentalDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutRentalDetails.Location = new System.Drawing.Point(5, 18);
            this.layoutRentalDetails.Name = "layoutRentalDetails";
            this.layoutRentalDetails.RowCount = 6;
            this.layoutRentalDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutRentalDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutRentalDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutRentalDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutRentalDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutRentalDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutRentalDetails.Size = new System.Drawing.Size(421, 137);
            this.layoutRentalDetails.TabIndex = 0;
            // 
            // lblPickupDate
            // 
            this.lblPickupDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPickupDate.AutoSize = true;
            this.lblPickupDate.Location = new System.Drawing.Point(3, 7);
            this.lblPickupDate.Name = "lblPickupDate";
            this.lblPickupDate.Size = new System.Drawing.Size(69, 13);
            this.lblPickupDate.TabIndex = 0;
            this.lblPickupDate.Text = "Pickup Date:";
            // 
            // dtpPickupDate
            // 
            this.dtpPickupDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpPickupDate.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpPickupDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPickupDate.Location = new System.Drawing.Point(123, 4);
            this.dtpPickupDate.Name = "dtpPickupDate";
            this.dtpPickupDate.Size = new System.Drawing.Size(295, 20);
            this.dtpPickupDate.TabIndex = 1;
            // 
            // lblExpectedReturn
            // 
            this.lblExpectedReturn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblExpectedReturn.AutoSize = true;
            this.lblExpectedReturn.Location = new System.Drawing.Point(3, 35);
            this.lblExpectedReturn.Name = "lblExpectedReturn";
            this.lblExpectedReturn.Size = new System.Drawing.Size(88, 13);
            this.lblExpectedReturn.TabIndex = 2;
            this.lblExpectedReturn.Text = "Expected Return:";
            // 
            // dtpExpectedReturn
            // 
            this.dtpExpectedReturn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpExpectedReturn.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpExpectedReturn.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpExpectedReturn.Location = new System.Drawing.Point(123, 32);
            this.dtpExpectedReturn.Name = "dtpExpectedReturn";
            this.dtpExpectedReturn.Size = new System.Drawing.Size(295, 20);
            this.dtpExpectedReturn.TabIndex = 3;
            // 
            // lblOdometer
            // 
            this.lblOdometer.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblOdometer.AutoSize = true;
            this.lblOdometer.Location = new System.Drawing.Point(3, 63);
            this.lblOdometer.Name = "lblOdometer";
            this.lblOdometer.Size = new System.Drawing.Size(56, 13);
            this.lblOdometer.TabIndex = 4;
            this.lblOdometer.Text = "Odometer:";
            // 
            // numOdometer
            // 
            this.numOdometer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numOdometer.DecimalPlaces = 2;
            this.numOdometer.Location = new System.Drawing.Point(123, 60);
            this.numOdometer.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            this.numOdometer.Name = "numOdometer";
            this.numOdometer.Size = new System.Drawing.Size(295, 20);
            this.numOdometer.TabIndex = 5;
            // 
            // lblFuelLevel
            // 
            this.lblFuelLevel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblFuelLevel.AutoSize = true;
            this.lblFuelLevel.Location = new System.Drawing.Point(3, 91);
            this.lblFuelLevel.Name = "lblFuelLevel";
            this.lblFuelLevel.Size = new System.Drawing.Size(83, 13);
            this.lblFuelLevel.TabIndex = 6;
            this.lblFuelLevel.Text = "Fuel Level (0-1):";
            // 
            // numFuelLevel
            // 
            this.numFuelLevel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numFuelLevel.DecimalPlaces = 2;
            this.numFuelLevel.Increment = new decimal(new int[] { 25, 0, 0, 131072 });
            this.numFuelLevel.Location = new System.Drawing.Point(123, 88);
            this.numFuelLevel.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numFuelLevel.Name = "numFuelLevel";
            this.numFuelLevel.Size = new System.Drawing.Size(295, 20);
            this.numFuelLevel.TabIndex = 7;
            this.numFuelLevel.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblDeposit
            // 
            this.lblDeposit.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDeposit.AutoSize = true;
            this.lblDeposit.Location = new System.Drawing.Point(3, 119);
            this.lblDeposit.Name = "lblDeposit";
            this.lblDeposit.Size = new System.Drawing.Size(46, 13);
            this.lblDeposit.TabIndex = 8;
            this.lblDeposit.Text = "Deposit:";
            // 
            // numDeposit
            // 
            this.numDeposit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numDeposit.DecimalPlaces = 2;
            this.numDeposit.Location = new System.Drawing.Point(123, 116);
            this.numDeposit.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            this.numDeposit.Name = "numDeposit";
            this.numDeposit.Size = new System.Drawing.Size(295, 20);
            this.numDeposit.TabIndex = 9;
            this.numDeposit.Value = new decimal(new int[] { 5000, 0, 0, 0 });
            // 
            // grpInspection
            // 
            this.grpInspection.Controls.Add(this.txtNotes);
            this.grpInspection.Controls.Add(this.lblNotes);
            this.grpInspection.Controls.Add(this.pnlCheckBoxes);
            this.grpInspection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpInspection.Location = new System.Drawing.Point(440, 3);
            this.grpInspection.Name = "grpInspection";
            this.grpInspection.Padding = new System.Windows.Forms.Padding(10);
            this.grpInspection.Size = new System.Drawing.Size(431, 160);
            this.grpInspection.TabIndex = 1;
            this.grpInspection.TabStop = false;
            this.grpInspection.Text = "Inspection & Notes";
            // 
            // txtNotes
            // 
            this.txtNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNotes.Location = new System.Drawing.Point(10, 80);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(411, 70);
            this.txtNotes.TabIndex = 2;
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblNotes.Location = new System.Drawing.Point(10, 60);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Padding = new System.Windows.Forms.Padding(0, 5, 0, 2);
            this.lblNotes.Size = new System.Drawing.Size(38, 20);
            this.lblNotes.TabIndex = 1;
            this.lblNotes.Text = "Notes:";
            // 
            // pnlCheckBoxes
            // 
            this.pnlCheckBoxes.AutoSize = true;
            this.pnlCheckBoxes.Controls.Add(this.chkIsSmokedIn);
            this.pnlCheckBoxes.Controls.Add(this.chkIsClean);
            this.pnlCheckBoxes.Controls.Add(this.chkAccessoriesOk);
            this.pnlCheckBoxes.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCheckBoxes.Location = new System.Drawing.Point(10, 23);
            this.pnlCheckBoxes.Name = "pnlCheckBoxes";
            this.pnlCheckBoxes.Size = new System.Drawing.Size(411, 37); // Height adjusted
            this.pnlCheckBoxes.TabIndex = 0;
            // 
            // chkIsSmokedIn
            // 
            this.chkIsSmokedIn.AutoSize = true;
            this.chkIsSmokedIn.Location = new System.Drawing.Point(3, 3);
            this.chkIsSmokedIn.Margin = new System.Windows.Forms.Padding(3, 3, 15, 3);
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
            this.chkIsClean.Location = new System.Drawing.Point(119, 3);
            this.chkIsClean.Margin = new System.Windows.Forms.Padding(3, 3, 15, 3);
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
            this.chkAccessoriesOk.Location = new System.Drawing.Point(201, 3);
            this.chkAccessoriesOk.Name = "chkAccessoriesOk";
            this.chkAccessoriesOk.Size = new System.Drawing.Size(101, 17);
            this.chkAccessoriesOk.TabIndex = 2;
            this.chkAccessoriesOk.Text = "Accessories OK";
            this.chkAccessoriesOk.UseVisualStyleBackColor = true;
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.btnStartRental);
            this.pnlFooter.Controls.Add(this.btnClear);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFooter.Location = new System.Drawing.Point(13, 553);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(874, 44);
            this.pnlFooter.TabIndex = 4;
            // 
            // btnStartRental
            // 
            this.btnStartRental.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartRental.Location = new System.Drawing.Point(744, 3);
            this.btnStartRental.Name = "btnStartRental";
            this.btnStartRental.Size = new System.Drawing.Size(120, 35);
            this.btnStartRental.TabIndex = 0;
            this.btnStartRental.Text = "Start Rental";
            this.btnStartRental.UseVisualStyleBackColor = true;
            this.btnStartRental.Click += new System.EventHandler(this.btnStartRental_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(638, 3);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 35);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // PickupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutMain);
            this.Name = "PickupForm";
            this.Size = new System.Drawing.Size(900, 600);
            this.layoutMain.ResumeLayout(false);
            this.layoutMain.PerformLayout();
            this.grpCustomer.ResumeLayout(false);
            this.grpCustomer.PerformLayout();
            this.grpVehicle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehicles)).EndInit();
            this.pnlTransaction.ResumeLayout(false);
            this.grpRentalDetails.ResumeLayout(false);
            this.layoutRentalDetails.ResumeLayout(false);
            this.layoutRentalDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOdometer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFuelLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDeposit)).EndInit();
            this.grpInspection.ResumeLayout(false);
            this.grpInspection.PerformLayout();
            this.pnlCheckBoxes.ResumeLayout(false);
            this.pnlCheckBoxes.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        // Main Layout
        private System.Windows.Forms.TableLayoutPanel layoutMain;
        private System.Windows.Forms.TableLayoutPanel pnlTransaction;
        private System.Windows.Forms.TableLayoutPanel layoutRentalDetails;
        private System.Windows.Forms.FlowLayoutPanel pnlCheckBoxes;
        private System.Windows.Forms.Panel pnlFooter;

        // Title
        private System.Windows.Forms.Label lblTitle;

        // Customer
        private System.Windows.Forms.GroupBox grpCustomer;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.Label lblCustomer;

        // Vehicle
        private System.Windows.Forms.GroupBox grpVehicle;
        private System.Windows.Forms.DataGridView dgvVehicles;

        // Details
        private System.Windows.Forms.GroupBox grpRentalDetails;
        private System.Windows.Forms.DateTimePicker dtpPickupDate;
        private System.Windows.Forms.Label lblPickupDate;
        private System.Windows.Forms.DateTimePicker dtpExpectedReturn;
        private System.Windows.Forms.Label lblExpectedReturn;
        private System.Windows.Forms.NumericUpDown numOdometer;
        private System.Windows.Forms.Label lblOdometer;
        private System.Windows.Forms.NumericUpDown numFuelLevel;
        private System.Windows.Forms.Label lblFuelLevel;
        private System.Windows.Forms.NumericUpDown numDeposit;
        private System.Windows.Forms.Label lblDeposit;

        // Inspection
        private System.Windows.Forms.GroupBox grpInspection;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.CheckBox chkIsSmokedIn;
        private System.Windows.Forms.CheckBox chkIsClean;
        private System.Windows.Forms.CheckBox chkAccessoriesOk;

        // Buttons
        private System.Windows.Forms.Button btnStartRental;
        private System.Windows.Forms.Button btnClear;
    }
}