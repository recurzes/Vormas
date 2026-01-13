namespace Vormas.Forms
{
    partial class ReturnForm
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.chkExpectedToday = new System.Windows.Forms.CheckBox();
            this.grpRentals = new System.Windows.Forms.GroupBox();
            this.dgvRentals = new System.Windows.Forms.DataGridView();
            this.grpPickupCondition = new System.Windows.Forms.GroupBox();
            this.lblPickupInfo = new System.Windows.Forms.Label();
            this.lblPickupOdometer = new System.Windows.Forms.Label();
            this.lblPickupFuel = new System.Windows.Forms.Label();
            this.lblPickupClean = new System.Windows.Forms.Label();
            this.lblPickupSmoked = new System.Windows.Forms.Label();
            this.lblPickupAccessories = new System.Windows.Forms.Label();
            this.grpReturnDetails = new System.Windows.Forms.GroupBox();
            this.dtpReturnDate = new System.Windows.Forms.DateTimePicker();
            this.lblReturnDate = new System.Windows.Forms.Label();
            this.numOdometer = new System.Windows.Forms.NumericUpDown();
            this.lblOdometer = new System.Windows.Forms.Label();
            this.numFuelLevel = new System.Windows.Forms.NumericUpDown();
            this.lblFuelLevel = new System.Windows.Forms.Label();
            this.grpMetrics = new System.Windows.Forms.GroupBox();
            this.lblDuration = new System.Windows.Forms.Label();
            this.lblMileage = new System.Windows.Forms.Label();
            this.lblMileageOverage = new System.Windows.Forms.Label();
            this.lblLateReturn = new System.Windows.Forms.Label();
            this.grpInspection = new System.Windows.Forms.GroupBox();
            this.chkIsSmokedIn = new System.Windows.Forms.CheckBox();
            this.chkIsClean = new System.Windows.Forms.CheckBox();
            this.chkAccessoriesOk = new System.Windows.Forms.CheckBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.grpDamageAssessment = new System.Windows.Forms.GroupBox();
            this.dgvDamages = new System.Windows.Forms.DataGridView();
            this.cmbDamageType = new System.Windows.Forms.ComboBox();
            this.lblDamageType = new System.Windows.Forms.Label();
            this.txtDamagePhotoPath = new System.Windows.Forms.TextBox();
            this.lblDamagePhoto = new System.Windows.Forms.Label();
            this.btnBrowsePhoto = new System.Windows.Forms.Button();
            this.btnAddDamage = new System.Windows.Forms.Button();
            this.btnRemoveDamage = new System.Windows.Forms.Button();
            this.lblDamageCount = new System.Windows.Forms.Label();
            this.btnCompleteRental = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.grpRentals.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRentals)).BeginInit();
            this.grpPickupCondition.SuspendLayout();
            this.grpReturnDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOdometer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFuelLevel)).BeginInit();
            this.grpMetrics.SuspendLayout();
            this.grpInspection.SuspendLayout();
            this.grpDamageAssessment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDamages)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(180, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Vehicle Return";
            // 
            // chkExpectedToday
            // 
            this.chkExpectedToday.AutoSize = true;
            this.chkExpectedToday.Location = new System.Drawing.Point(220, 18);
            this.chkExpectedToday.Name = "chkExpectedToday";
            this.chkExpectedToday.Size = new System.Drawing.Size(170, 19);
            this.chkExpectedToday.TabIndex = 1;
            this.chkExpectedToday.Text = "Show only expected today";
            this.chkExpectedToday.UseVisualStyleBackColor = true;
            this.chkExpectedToday.CheckedChanged += new System.EventHandler(this.chkExpectedToday_CheckedChanged);
            // 
            // grpRentals
            // 
            this.grpRentals.Controls.Add(this.dgvRentals);
            this.grpRentals.Location = new System.Drawing.Point(20, 45);
            this.grpRentals.Name = "grpRentals";
            this.grpRentals.Size = new System.Drawing.Size(560, 130);
            this.grpRentals.TabIndex = 2;
            this.grpRentals.TabStop = false;
            this.grpRentals.Text = "Active Rentals";
            // 
            // dgvRentals
            // 
            this.dgvRentals.AllowUserToAddRows = false;
            this.dgvRentals.AllowUserToDeleteRows = false;
            this.dgvRentals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRentals.Location = new System.Drawing.Point(10, 20);
            this.dgvRentals.Name = "dgvRentals";
            this.dgvRentals.RowTemplate.Height = 25;
            this.dgvRentals.Size = new System.Drawing.Size(540, 100);
            this.dgvRentals.TabIndex = 0;
            // 
            // grpPickupCondition
            // 
            this.grpPickupCondition.Controls.Add(this.lblPickupInfo);
            this.grpPickupCondition.Controls.Add(this.lblPickupOdometer);
            this.grpPickupCondition.Controls.Add(this.lblPickupFuel);
            this.grpPickupCondition.Controls.Add(this.lblPickupClean);
            this.grpPickupCondition.Controls.Add(this.lblPickupSmoked);
            this.grpPickupCondition.Controls.Add(this.lblPickupAccessories);
            this.grpPickupCondition.Location = new System.Drawing.Point(590, 45);
            this.grpPickupCondition.Name = "grpPickupCondition";
            this.grpPickupCondition.Size = new System.Drawing.Size(195, 130);
            this.grpPickupCondition.TabIndex = 3;
            this.grpPickupCondition.TabStop = false;
            this.grpPickupCondition.Text = "Pickup Condition (Compare)";
            // 
            // lblPickupInfo
            // 
            this.lblPickupInfo.AutoSize = true;
            this.lblPickupInfo.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
            this.lblPickupInfo.ForeColor = System.Drawing.Color.Gray;
            this.lblPickupInfo.Location = new System.Drawing.Point(10, 20);
            this.lblPickupInfo.Name = "lblPickupInfo";
            this.lblPickupInfo.Size = new System.Drawing.Size(0, 13);
            this.lblPickupInfo.TabIndex = 0;
            // 
            // lblPickupOdometer
            // 
            this.lblPickupOdometer.AutoSize = true;
            this.lblPickupOdometer.Location = new System.Drawing.Point(10, 38);
            this.lblPickupOdometer.Name = "lblPickupOdometer";
            this.lblPickupOdometer.Size = new System.Drawing.Size(0, 15);
            this.lblPickupOdometer.TabIndex = 1;
            // 
            // lblPickupFuel
            // 
            this.lblPickupFuel.AutoSize = true;
            this.lblPickupFuel.Location = new System.Drawing.Point(10, 56);
            this.lblPickupFuel.Name = "lblPickupFuel";
            this.lblPickupFuel.Size = new System.Drawing.Size(0, 15);
            this.lblPickupFuel.TabIndex = 2;
            // 
            // lblPickupClean
            // 
            this.lblPickupClean.AutoSize = true;
            this.lblPickupClean.Location = new System.Drawing.Point(10, 74);
            this.lblPickupClean.Name = "lblPickupClean";
            this.lblPickupClean.Size = new System.Drawing.Size(0, 15);
            this.lblPickupClean.TabIndex = 3;
            // 
            // lblPickupSmoked
            // 
            this.lblPickupSmoked.AutoSize = true;
            this.lblPickupSmoked.Location = new System.Drawing.Point(10, 92);
            this.lblPickupSmoked.Name = "lblPickupSmoked";
            this.lblPickupSmoked.Size = new System.Drawing.Size(0, 15);
            this.lblPickupSmoked.TabIndex = 4;
            // 
            // lblPickupAccessories
            // 
            this.lblPickupAccessories.AutoSize = true;
            this.lblPickupAccessories.Location = new System.Drawing.Point(10, 110);
            this.lblPickupAccessories.Name = "lblPickupAccessories";
            this.lblPickupAccessories.Size = new System.Drawing.Size(0, 15);
            this.lblPickupAccessories.TabIndex = 5;
            // 
            // grpReturnDetails
            // 
            this.grpReturnDetails.Controls.Add(this.dtpReturnDate);
            this.grpReturnDetails.Controls.Add(this.lblReturnDate);
            this.grpReturnDetails.Controls.Add(this.numOdometer);
            this.grpReturnDetails.Controls.Add(this.lblOdometer);
            this.grpReturnDetails.Controls.Add(this.numFuelLevel);
            this.grpReturnDetails.Controls.Add(this.lblFuelLevel);
            this.grpReturnDetails.Location = new System.Drawing.Point(20, 185);
            this.grpReturnDetails.Name = "grpReturnDetails";
            this.grpReturnDetails.Size = new System.Drawing.Size(240, 100);
            this.grpReturnDetails.TabIndex = 4;
            this.grpReturnDetails.TabStop = false;
            this.grpReturnDetails.Text = "Return Details";
            // 
            // dtpReturnDate
            // 
            this.dtpReturnDate.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpReturnDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpReturnDate.Location = new System.Drawing.Point(85, 20);
            this.dtpReturnDate.Name = "dtpReturnDate";
            this.dtpReturnDate.Size = new System.Drawing.Size(145, 23);
            this.dtpReturnDate.TabIndex = 1;
            this.dtpReturnDate.ValueChanged += new System.EventHandler(this.dtpReturnDate_ValueChanged);
            // 
            // lblReturnDate
            // 
            this.lblReturnDate.AutoSize = true;
            this.lblReturnDate.Location = new System.Drawing.Point(10, 23);
            this.lblReturnDate.Name = "lblReturnDate";
            this.lblReturnDate.Size = new System.Drawing.Size(74, 15);
            this.lblReturnDate.TabIndex = 0;
            this.lblReturnDate.Text = "Return Date:";
            // 
            // numOdometer
            // 
            this.numOdometer.DecimalPlaces = 2;
            this.numOdometer.Location = new System.Drawing.Point(85, 50);
            this.numOdometer.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            this.numOdometer.Name = "numOdometer";
            this.numOdometer.Size = new System.Drawing.Size(100, 23);
            this.numOdometer.TabIndex = 3;
            this.numOdometer.ValueChanged += new System.EventHandler(this.numOdometer_ValueChanged);
            // 
            // lblOdometer
            // 
            this.lblOdometer.AutoSize = true;
            this.lblOdometer.Location = new System.Drawing.Point(10, 53);
            this.lblOdometer.Name = "lblOdometer";
            this.lblOdometer.Size = new System.Drawing.Size(67, 15);
            this.lblOdometer.TabIndex = 2;
            this.lblOdometer.Text = "Odometer:";
            // 
            // numFuelLevel
            // 
            this.numFuelLevel.DecimalPlaces = 2;
            this.numFuelLevel.Increment = new decimal(new int[] { 25, 0, 0, 131072 });
            this.numFuelLevel.Location = new System.Drawing.Point(85, 77);
            this.numFuelLevel.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numFuelLevel.Name = "numFuelLevel";
            this.numFuelLevel.Size = new System.Drawing.Size(60, 23);
            this.numFuelLevel.TabIndex = 5;
            this.numFuelLevel.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblFuelLevel
            // 
            this.lblFuelLevel.AutoSize = true;
            this.lblFuelLevel.Location = new System.Drawing.Point(10, 80);
            this.lblFuelLevel.Name = "lblFuelLevel";
            this.lblFuelLevel.Size = new System.Drawing.Size(66, 15);
            this.lblFuelLevel.TabIndex = 4;
            this.lblFuelLevel.Text = "Fuel (0-1):";
            // 
            // grpMetrics
            // 
            this.grpMetrics.Controls.Add(this.lblDuration);
            this.grpMetrics.Controls.Add(this.lblMileage);
            this.grpMetrics.Controls.Add(this.lblMileageOverage);
            this.grpMetrics.Controls.Add(this.lblLateReturn);
            this.grpMetrics.Location = new System.Drawing.Point(270, 185);
            this.grpMetrics.Name = "grpMetrics";
            this.grpMetrics.Size = new System.Drawing.Size(230, 100);
            this.grpMetrics.TabIndex = 5;
            this.grpMetrics.TabStop = false;
            this.grpMetrics.Text = "Rental Metrics";
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDuration.Location = new System.Drawing.Point(10, 22);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(0, 15);
            this.lblDuration.TabIndex = 0;
            // 
            // lblMileage
            // 
            this.lblMileage.AutoSize = true;
            this.lblMileage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMileage.Location = new System.Drawing.Point(10, 42);
            this.lblMileage.Name = "lblMileage";
            this.lblMileage.Size = new System.Drawing.Size(0, 15);
            this.lblMileage.TabIndex = 1;
            // 
            // lblMileageOverage
            // 
            this.lblMileageOverage.AutoSize = true;
            this.lblMileageOverage.Location = new System.Drawing.Point(10, 62);
            this.lblMileageOverage.Name = "lblMileageOverage";
            this.lblMileageOverage.Size = new System.Drawing.Size(0, 15);
            this.lblMileageOverage.TabIndex = 2;
            this.lblMileageOverage.Visible = false;
            // 
            // lblLateReturn
            // 
            this.lblLateReturn.AutoSize = true;
            this.lblLateReturn.Location = new System.Drawing.Point(10, 80);
            this.lblLateReturn.Name = "lblLateReturn";
            this.lblLateReturn.Size = new System.Drawing.Size(0, 15);
            this.lblLateReturn.TabIndex = 3;
            this.lblLateReturn.Visible = false;
            // 
            // grpInspection
            // 
            this.grpInspection.Controls.Add(this.chkIsSmokedIn);
            this.grpInspection.Controls.Add(this.chkIsClean);
            this.grpInspection.Controls.Add(this.chkAccessoriesOk);
            this.grpInspection.Controls.Add(this.txtNotes);
            this.grpInspection.Controls.Add(this.lblNotes);
            this.grpInspection.Location = new System.Drawing.Point(510, 185);
            this.grpInspection.Name = "grpInspection";
            this.grpInspection.Size = new System.Drawing.Size(275, 100);
            this.grpInspection.TabIndex = 6;
            this.grpInspection.TabStop = false;
            this.grpInspection.Text = "Return Inspection";
            // 
            // chkIsSmokedIn
            // 
            this.chkIsSmokedIn.AutoSize = true;
            this.chkIsSmokedIn.Location = new System.Drawing.Point(10, 20);
            this.chkIsSmokedIn.Name = "chkIsSmokedIn";
            this.chkIsSmokedIn.Size = new System.Drawing.Size(70, 19);
            this.chkIsSmokedIn.TabIndex = 0;
            this.chkIsSmokedIn.Text = "Smoked";
            this.chkIsSmokedIn.UseVisualStyleBackColor = true;
            // 
            // chkIsClean
            // 
            this.chkIsClean.AutoSize = true;
            this.chkIsClean.Checked = true;
            this.chkIsClean.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsClean.Location = new System.Drawing.Point(90, 20);
            this.chkIsClean.Name = "chkIsClean";
            this.chkIsClean.Size = new System.Drawing.Size(54, 19);
            this.chkIsClean.TabIndex = 1;
            this.chkIsClean.Text = "Clean";
            this.chkIsClean.UseVisualStyleBackColor = true;
            // 
            // chkAccessoriesOk
            // 
            this.chkAccessoriesOk.AutoSize = true;
            this.chkAccessoriesOk.Checked = true;
            this.chkAccessoriesOk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAccessoriesOk.Location = new System.Drawing.Point(155, 20);
            this.chkAccessoriesOk.Name = "chkAccessoriesOk";
            this.chkAccessoriesOk.Size = new System.Drawing.Size(62, 19);
            this.chkAccessoriesOk.TabIndex = 2;
            this.chkAccessoriesOk.Text = "Acc OK";
            this.chkAccessoriesOk.UseVisualStyleBackColor = true;
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(10, 58);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(255, 35);
            this.txtNotes.TabIndex = 4;
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(10, 42);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(41, 15);
            this.lblNotes.TabIndex = 3;
            this.lblNotes.Text = "Notes:";
            // 
            // grpDamageAssessment
            // 
            this.grpDamageAssessment.Controls.Add(this.dgvDamages);
            this.grpDamageAssessment.Controls.Add(this.cmbDamageType);
            this.grpDamageAssessment.Controls.Add(this.lblDamageType);
            this.grpDamageAssessment.Controls.Add(this.txtDamagePhotoPath);
            this.grpDamageAssessment.Controls.Add(this.lblDamagePhoto);
            this.grpDamageAssessment.Controls.Add(this.btnBrowsePhoto);
            this.grpDamageAssessment.Controls.Add(this.btnAddDamage);
            this.grpDamageAssessment.Controls.Add(this.btnRemoveDamage);
            this.grpDamageAssessment.Controls.Add(this.lblDamageCount);
            this.grpDamageAssessment.Location = new System.Drawing.Point(20, 295);
            this.grpDamageAssessment.Name = "grpDamageAssessment";
            this.grpDamageAssessment.Size = new System.Drawing.Size(490, 145);
            this.grpDamageAssessment.TabIndex = 7;
            this.grpDamageAssessment.TabStop = false;
            this.grpDamageAssessment.Text = "Damage Assessment";
            // 
            // dgvDamages
            // 
            this.dgvDamages.AllowUserToAddRows = false;
            this.dgvDamages.AllowUserToDeleteRows = false;
            this.dgvDamages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDamages.Location = new System.Drawing.Point(200, 20);
            this.dgvDamages.Name = "dgvDamages";
            this.dgvDamages.RowTemplate.Height = 25;
            this.dgvDamages.Size = new System.Drawing.Size(280, 90);
            this.dgvDamages.TabIndex = 8;
            // 
            // cmbDamageType
            // 
            this.cmbDamageType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDamageType.FormattingEnabled = true;
            this.cmbDamageType.Location = new System.Drawing.Point(10, 38);
            this.cmbDamageType.Name = "cmbDamageType";
            this.cmbDamageType.Size = new System.Drawing.Size(180, 23);
            this.cmbDamageType.TabIndex = 1;
            // 
            // lblDamageType
            // 
            this.lblDamageType.AutoSize = true;
            this.lblDamageType.Location = new System.Drawing.Point(10, 20);
            this.lblDamageType.Name = "lblDamageType";
            this.lblDamageType.Size = new System.Drawing.Size(81, 15);
            this.lblDamageType.TabIndex = 0;
            this.lblDamageType.Text = "Damage Type:";
            // 
            // txtDamagePhotoPath
            // 
            this.txtDamagePhotoPath.Location = new System.Drawing.Point(10, 82);
            this.txtDamagePhotoPath.Name = "txtDamagePhotoPath";
            this.txtDamagePhotoPath.Size = new System.Drawing.Size(130, 23);
            this.txtDamagePhotoPath.TabIndex = 3;
            // 
            // lblDamagePhoto
            // 
            this.lblDamagePhoto.AutoSize = true;
            this.lblDamagePhoto.Location = new System.Drawing.Point(10, 64);
            this.lblDamagePhoto.Name = "lblDamagePhoto";
            this.lblDamagePhoto.Size = new System.Drawing.Size(44, 15);
            this.lblDamagePhoto.TabIndex = 2;
            this.lblDamagePhoto.Text = "Photo:";
            // 
            // btnBrowsePhoto
            // 
            this.btnBrowsePhoto.Location = new System.Drawing.Point(145, 81);
            this.btnBrowsePhoto.Name = "btnBrowsePhoto";
            this.btnBrowsePhoto.Size = new System.Drawing.Size(45, 25);
            this.btnBrowsePhoto.TabIndex = 4;
            this.btnBrowsePhoto.Text = "...";
            this.btnBrowsePhoto.UseVisualStyleBackColor = true;
            this.btnBrowsePhoto.Click += new System.EventHandler(this.btnBrowsePhoto_Click);
            // 
            // btnAddDamage
            // 
            this.btnAddDamage.BackColor = System.Drawing.Color.OrangeRed;
            this.btnAddDamage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddDamage.ForeColor = System.Drawing.Color.White;
            this.btnAddDamage.Location = new System.Drawing.Point(10, 112);
            this.btnAddDamage.Name = "btnAddDamage";
            this.btnAddDamage.Size = new System.Drawing.Size(90, 25);
            this.btnAddDamage.TabIndex = 5;
            this.btnAddDamage.Text = "+ Add";
            this.btnAddDamage.UseVisualStyleBackColor = false;
            this.btnAddDamage.Click += new System.EventHandler(this.btnAddDamage_Click);
            // 
            // btnRemoveDamage
            // 
            this.btnRemoveDamage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveDamage.Location = new System.Drawing.Point(105, 112);
            this.btnRemoveDamage.Name = "btnRemoveDamage";
            this.btnRemoveDamage.Size = new System.Drawing.Size(85, 25);
            this.btnRemoveDamage.TabIndex = 6;
            this.btnRemoveDamage.Text = "Remove";
            this.btnRemoveDamage.UseVisualStyleBackColor = true;
            this.btnRemoveDamage.Click += new System.EventHandler(this.btnRemoveDamage_Click);
            // 
            // lblDamageCount
            // 
            this.lblDamageCount.AutoSize = true;
            this.lblDamageCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDamageCount.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblDamageCount.Location = new System.Drawing.Point(200, 117);
            this.lblDamageCount.Name = "lblDamageCount";
            this.lblDamageCount.Size = new System.Drawing.Size(0, 15);
            this.lblDamageCount.TabIndex = 7;
            // 
            // btnCompleteRental
            // 
            this.btnCompleteRental.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnCompleteRental.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompleteRental.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCompleteRental.ForeColor = System.Drawing.Color.White;
            this.btnCompleteRental.Location = new System.Drawing.Point(520, 320);
            this.btnCompleteRental.Name = "btnCompleteRental";
            this.btnCompleteRental.Size = new System.Drawing.Size(140, 40);
            this.btnCompleteRental.TabIndex = 8;
            this.btnCompleteRental.Text = "Complete Return";
            this.btnCompleteRental.UseVisualStyleBackColor = false;
            this.btnCompleteRental.Click += new System.EventHandler(this.btnCompleteRental_Click);
            // 
            // btnClear
            // 
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Location = new System.Drawing.Point(670, 320);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 40);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // ReturnForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnCompleteRental);
            this.Controls.Add(this.grpDamageAssessment);
            this.Controls.Add(this.grpInspection);
            this.Controls.Add(this.grpMetrics);
            this.Controls.Add(this.grpReturnDetails);
            this.Controls.Add(this.grpPickupCondition);
            this.Controls.Add(this.grpRentals);
            this.Controls.Add(this.chkExpectedToday);
            this.Controls.Add(this.lblTitle);
            this.Name = "ReturnForm";
            this.Size = new System.Drawing.Size(800, 460);
            this.grpRentals.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRentals)).EndInit();
            this.grpPickupCondition.ResumeLayout(false);
            this.grpPickupCondition.PerformLayout();
            this.grpReturnDetails.ResumeLayout(false);
            this.grpReturnDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOdometer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFuelLevel)).EndInit();
            this.grpMetrics.ResumeLayout(false);
            this.grpMetrics.PerformLayout();
            this.grpInspection.ResumeLayout(false);
            this.grpInspection.PerformLayout();
            this.grpDamageAssessment.ResumeLayout(false);
            this.grpDamageAssessment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDamages)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.CheckBox chkExpectedToday;
        private System.Windows.Forms.GroupBox grpRentals;
        private System.Windows.Forms.DataGridView dgvRentals;
        private System.Windows.Forms.GroupBox grpPickupCondition;
        private System.Windows.Forms.Label lblPickupInfo;
        private System.Windows.Forms.Label lblPickupOdometer;
        private System.Windows.Forms.Label lblPickupFuel;
        private System.Windows.Forms.Label lblPickupClean;
        private System.Windows.Forms.Label lblPickupSmoked;
        private System.Windows.Forms.Label lblPickupAccessories;
        private System.Windows.Forms.GroupBox grpReturnDetails;
        private System.Windows.Forms.DateTimePicker dtpReturnDate;
        private System.Windows.Forms.Label lblReturnDate;
        private System.Windows.Forms.NumericUpDown numOdometer;
        private System.Windows.Forms.Label lblOdometer;
        private System.Windows.Forms.NumericUpDown numFuelLevel;
        private System.Windows.Forms.Label lblFuelLevel;
        private System.Windows.Forms.GroupBox grpMetrics;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.Label lblMileage;
        private System.Windows.Forms.Label lblMileageOverage;
        private System.Windows.Forms.Label lblLateReturn;
        private System.Windows.Forms.GroupBox grpInspection;
        private System.Windows.Forms.CheckBox chkIsSmokedIn;
        private System.Windows.Forms.CheckBox chkIsClean;
        private System.Windows.Forms.CheckBox chkAccessoriesOk;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.GroupBox grpDamageAssessment;
        private System.Windows.Forms.DataGridView dgvDamages;
        private System.Windows.Forms.ComboBox cmbDamageType;
        private System.Windows.Forms.Label lblDamageType;
        private System.Windows.Forms.TextBox txtDamagePhotoPath;
        private System.Windows.Forms.Label lblDamagePhoto;
        private System.Windows.Forms.Button btnBrowsePhoto;
        private System.Windows.Forms.Button btnAddDamage;
        private System.Windows.Forms.Button btnRemoveDamage;
        private System.Windows.Forms.Label lblDamageCount;
        private System.Windows.Forms.Button btnCompleteRental;
        private System.Windows.Forms.Button btnClear;
    }
}