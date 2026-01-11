using System.ComponentModel;

namespace Vormas.Forms
{
    partial class ReturnForm
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
            this.grpDamageAssessment = new System.Windows.Forms.GroupBox();
            this.chkIsSmokedIn = new System.Windows.Forms.CheckBox();
            this.chkIsClean = new System.Windows.Forms.CheckBox();
            this.chkAccessoriesOk = new System.Windows.Forms.CheckBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.lblPickupInfo = new System.Windows.Forms.Label();
            this.dtpReturnDate = new System.Windows.Forms.DateTimePicker();
            this.lblReturnDate = new System.Windows.Forms.Label();
            this.numOdometer = new System.Windows.Forms.NumericUpDown();
            this.lblOdometer = new System.Windows.Forms.Label();
            this.numFuelLevel = new System.Windows.Forms.NumericUpDown();
            this.lblFuelLevel = new System.Windows.Forms.Label();
            this.grpReturnDetails = new System.Windows.Forms.GroupBox();
            this.dgvRentals = new System.Windows.Forms.DataGridView();
            this.grpInspection = new System.Windows.Forms.GroupBox();
            this.grpRentals = new System.Windows.Forms.GroupBox();
            this.lblTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDamages)).BeginInit();
            this.grpDamageAssessment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOdometer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFuelLevel)).BeginInit();
            this.grpReturnDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRentals)).BeginInit();
            this.grpInspection.SuspendLayout();
            this.grpRentals.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClear
            // 
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Location = new System.Drawing.Point(155, 314);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(86, 35);
            this.btnClear.TabIndex = 13;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // dgvDamages
            // 
            this.dgvDamages.AllowUserToAddRows = false;
            this.dgvDamages.AllowUserToDeleteRows = false;
            this.dgvDamages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDamages.Location = new System.Drawing.Point(9, 100);
            this.dgvDamages.Name = "dgvDamages";
            this.dgvDamages.RowTemplate.Height = 25;
            this.dgvDamages.Size = new System.Drawing.Size(180, 65);
            this.dgvDamages.TabIndex = 8;
            // 
            // cmbDamageType
            // 
            this.cmbDamageType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDamageType.FormattingEnabled = true;
            this.cmbDamageType.Location = new System.Drawing.Point(9, 32);
            this.cmbDamageType.Name = "cmbDamageType";
            this.cmbDamageType.Size = new System.Drawing.Size(181, 21);
            this.cmbDamageType.TabIndex = 1;
            // 
            // lblDamageType
            // 
            this.lblDamageType.AutoSize = true;
            this.lblDamageType.Location = new System.Drawing.Point(9, 16);
            this.lblDamageType.Name = "lblDamageType";
            this.lblDamageType.Size = new System.Drawing.Size(77, 13);
            this.lblDamageType.TabIndex = 0;
            this.lblDamageType.Text = "Damage Type:";
            // 
            // txtDamagePhotoPath
            // 
            this.txtDamagePhotoPath.Location = new System.Drawing.Point(9, 71);
            this.txtDamagePhotoPath.Name = "txtDamagePhotoPath";
            this.txtDamagePhotoPath.Size = new System.Drawing.Size(129, 20);
            this.txtDamagePhotoPath.TabIndex = 3;
            // 
            // lblDamagePhoto
            // 
            this.lblDamagePhoto.AutoSize = true;
            this.lblDamagePhoto.Location = new System.Drawing.Point(9, 55);
            this.lblDamagePhoto.Name = "lblDamagePhoto";
            this.lblDamagePhoto.Size = new System.Drawing.Size(84, 13);
            this.lblDamagePhoto.TabIndex = 2;
            this.lblDamagePhoto.Text = "Photo (optional):";
            // 
            // btnBrowsePhoto
            // 
            this.btnBrowsePhoto.Location = new System.Drawing.Point(141, 70);
            this.btnBrowsePhoto.Name = "btnBrowsePhoto";
            this.btnBrowsePhoto.Size = new System.Drawing.Size(47, 22);
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
            this.btnAddDamage.Location = new System.Drawing.Point(9, 169);
            this.btnAddDamage.Name = "btnAddDamage";
            this.btnAddDamage.Size = new System.Drawing.Size(86, 22);
            this.btnAddDamage.TabIndex = 5;
            this.btnAddDamage.Text = "+ Add Damage";
            this.btnAddDamage.UseVisualStyleBackColor = false;
            this.btnAddDamage.Click += new System.EventHandler(this.btnAddDamage_Click);
            // 
            // btnRemoveDamage
            // 
            this.btnRemoveDamage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveDamage.Location = new System.Drawing.Point(99, 169);
            this.btnRemoveDamage.Name = "btnRemoveDamage";
            this.btnRemoveDamage.Size = new System.Drawing.Size(64, 22);
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
            this.lblDamageCount.Location = new System.Drawing.Point(167, 173);
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
            this.btnCompleteRental.Location = new System.Drawing.Point(18, 314);
            this.btnCompleteRental.Name = "btnCompleteRental";
            this.btnCompleteRental.Size = new System.Drawing.Size(129, 35);
            this.btnCompleteRental.TabIndex = 12;
            this.btnCompleteRental.Text = "Complete Return";
            this.btnCompleteRental.UseVisualStyleBackColor = false;
            this.btnCompleteRental.Click += new System.EventHandler(this.btnCompleteRental_Click);
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
            this.grpDamageAssessment.Location = new System.Drawing.Point(472, 188);
            this.grpDamageAssessment.Name = "grpDamageAssessment";
            this.grpDamageAssessment.Size = new System.Drawing.Size(197, 195);
            this.grpDamageAssessment.TabIndex = 11;
            this.grpDamageAssessment.TabStop = false;
            this.grpDamageAssessment.Text = "Damage Assessment";
            // 
            // chkIsSmokedIn
            // 
            this.chkIsSmokedIn.AutoSize = true;
            this.chkIsSmokedIn.Location = new System.Drawing.Point(13, 19);
            this.chkIsSmokedIn.Name = "chkIsSmokedIn";
            this.chkIsSmokedIn.Size = new System.Drawing.Size(77, 17);
            this.chkIsSmokedIn.TabIndex = 0;
            this.chkIsSmokedIn.Text = "Smoked In";
            this.chkIsSmokedIn.UseVisualStyleBackColor = true;
            // 
            // chkIsClean
            // 
            this.chkIsClean.AutoSize = true;
            this.chkIsClean.Checked = true;
            this.chkIsClean.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsClean.Location = new System.Drawing.Point(90, 19);
            this.chkIsClean.Name = "chkIsClean";
            this.chkIsClean.Size = new System.Drawing.Size(53, 17);
            this.chkIsClean.TabIndex = 1;
            this.chkIsClean.Text = "Clean";
            this.chkIsClean.UseVisualStyleBackColor = true;
            // 
            // chkAccessoriesOk
            // 
            this.chkAccessoriesOk.AutoSize = true;
            this.chkAccessoriesOk.Checked = true;
            this.chkAccessoriesOk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAccessoriesOk.Location = new System.Drawing.Point(138, 19);
            this.chkAccessoriesOk.Name = "chkAccessoriesOk";
            this.chkAccessoriesOk.Size = new System.Drawing.Size(63, 17);
            this.chkAccessoriesOk.TabIndex = 2;
            this.chkAccessoriesOk.Text = "Acc OK";
            this.chkAccessoriesOk.UseVisualStyleBackColor = true;
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(13, 54);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(172, 48);
            this.txtNotes.TabIndex = 4;
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(13, 38);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(38, 13);
            this.lblNotes.TabIndex = 3;
            this.lblNotes.Text = "Notes:";
            // 
            // lblPickupInfo
            // 
            this.lblPickupInfo.AutoSize = true;
            this.lblPickupInfo.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
            this.lblPickupInfo.ForeColor = System.Drawing.Color.Gray;
            this.lblPickupInfo.Location = new System.Drawing.Point(13, 94);
            this.lblPickupInfo.Name = "lblPickupInfo";
            this.lblPickupInfo.Size = new System.Drawing.Size(0, 13);
            this.lblPickupInfo.TabIndex = 6;
            // 
            // dtpReturnDate
            // 
            this.dtpReturnDate.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpReturnDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpReturnDate.Location = new System.Drawing.Point(94, 19);
            this.dtpReturnDate.Name = "dtpReturnDate";
            this.dtpReturnDate.Size = new System.Drawing.Size(133, 20);
            this.dtpReturnDate.TabIndex = 1;
            // 
            // lblReturnDate
            // 
            this.lblReturnDate.AutoSize = true;
            this.lblReturnDate.Location = new System.Drawing.Point(13, 22);
            this.lblReturnDate.Name = "lblReturnDate";
            this.lblReturnDate.Size = new System.Drawing.Size(68, 13);
            this.lblReturnDate.TabIndex = 0;
            this.lblReturnDate.Text = "Return Date:";
            // 
            // numOdometer
            // 
            this.numOdometer.DecimalPlaces = 2;
            this.numOdometer.Location = new System.Drawing.Point(94, 45);
            this.numOdometer.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            this.numOdometer.Name = "numOdometer";
            this.numOdometer.Size = new System.Drawing.Size(94, 20);
            this.numOdometer.TabIndex = 3;
            // 
            // lblOdometer
            // 
            this.lblOdometer.AutoSize = true;
            this.lblOdometer.Location = new System.Drawing.Point(13, 48);
            this.lblOdometer.Name = "lblOdometer";
            this.lblOdometer.Size = new System.Drawing.Size(56, 13);
            this.lblOdometer.TabIndex = 2;
            this.lblOdometer.Text = "Odometer:";
            // 
            // numFuelLevel
            // 
            this.numFuelLevel.DecimalPlaces = 2;
            this.numFuelLevel.Increment = new decimal(new int[] { 25, 0, 0, 131072 });
            this.numFuelLevel.Location = new System.Drawing.Point(94, 71);
            this.numFuelLevel.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numFuelLevel.Name = "numFuelLevel";
            this.numFuelLevel.Size = new System.Drawing.Size(60, 20);
            this.numFuelLevel.TabIndex = 5;
            this.numFuelLevel.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblFuelLevel
            // 
            this.lblFuelLevel.AutoSize = true;
            this.lblFuelLevel.Location = new System.Drawing.Point(13, 74);
            this.lblFuelLevel.Name = "lblFuelLevel";
            this.lblFuelLevel.Size = new System.Drawing.Size(72, 13);
            this.lblFuelLevel.TabIndex = 4;
            this.lblFuelLevel.Text = "Fuel (0.0-1.0):";
            // 
            // grpReturnDetails
            // 
            this.grpReturnDetails.Controls.Add(this.lblPickupInfo);
            this.grpReturnDetails.Controls.Add(this.dtpReturnDate);
            this.grpReturnDetails.Controls.Add(this.lblReturnDate);
            this.grpReturnDetails.Controls.Add(this.numOdometer);
            this.grpReturnDetails.Controls.Add(this.lblOdometer);
            this.grpReturnDetails.Controls.Add(this.numFuelLevel);
            this.grpReturnDetails.Controls.Add(this.lblFuelLevel);
            this.grpReturnDetails.Location = new System.Drawing.Point(18, 188);
            this.grpReturnDetails.Name = "grpReturnDetails";
            this.grpReturnDetails.Size = new System.Drawing.Size(240, 113);
            this.grpReturnDetails.TabIndex = 9;
            this.grpReturnDetails.TabStop = false;
            this.grpReturnDetails.Text = "Return Details";
            // 
            // dgvRentals
            // 
            this.dgvRentals.AllowUserToAddRows = false;
            this.dgvRentals.AllowUserToDeleteRows = false;
            this.dgvRentals.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRentals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRentals.Location = new System.Drawing.Point(13, 19);
            this.dgvRentals.Name = "dgvRentals";
            this.dgvRentals.RowTemplate.Height = 25;
            this.dgvRentals.Size = new System.Drawing.Size(626, 100);
            this.dgvRentals.TabIndex = 0;
            // 
            // grpInspection
            // 
            this.grpInspection.Controls.Add(this.chkIsSmokedIn);
            this.grpInspection.Controls.Add(this.chkIsClean);
            this.grpInspection.Controls.Add(this.chkAccessoriesOk);
            this.grpInspection.Controls.Add(this.txtNotes);
            this.grpInspection.Controls.Add(this.lblNotes);
            this.grpInspection.Location = new System.Drawing.Point(267, 188);
            this.grpInspection.Name = "grpInspection";
            this.grpInspection.Size = new System.Drawing.Size(197, 113);
            this.grpInspection.TabIndex = 10;
            this.grpInspection.TabStop = false;
            this.grpInspection.Text = "Return Inspection";
            // 
            // grpRentals
            // 
            this.grpRentals.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.grpRentals.Controls.Add(this.dgvRentals);
            this.grpRentals.Location = new System.Drawing.Point(18, 50);
            this.grpRentals.Name = "grpRentals";
            this.grpRentals.Size = new System.Drawing.Size(651, 130);
            this.grpRentals.TabIndex = 8;
            this.grpRentals.TabStop = false;
            this.grpRentals.Text = "Active Rentals";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(18, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(162, 30);
            this.lblTitle.TabIndex = 7;
            this.lblTitle.Text = "Vehicle Return";
            // 
            // ReturnForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnCompleteRental);
            this.Controls.Add(this.grpDamageAssessment);
            this.Controls.Add(this.grpReturnDetails);
            this.Controls.Add(this.grpInspection);
            this.Controls.Add(this.grpRentals);
            this.Controls.Add(this.lblTitle);
            this.Name = "ReturnForm";
            this.Size = new System.Drawing.Size(686, 399);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDamages)).EndInit();
            this.grpDamageAssessment.ResumeLayout(false);
            this.grpDamageAssessment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOdometer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFuelLevel)).EndInit();
            this.grpReturnDetails.ResumeLayout(false);
            this.grpReturnDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRentals)).EndInit();
            this.grpInspection.ResumeLayout(false);
            this.grpInspection.PerformLayout();
            this.grpRentals.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button btnClear;
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
        private System.Windows.Forms.GroupBox grpDamageAssessment;
        private System.Windows.Forms.CheckBox chkIsSmokedIn;
        private System.Windows.Forms.CheckBox chkIsClean;
        private System.Windows.Forms.CheckBox chkAccessoriesOk;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.Label lblPickupInfo;
        private System.Windows.Forms.DateTimePicker dtpReturnDate;
        private System.Windows.Forms.Label lblReturnDate;
        private System.Windows.Forms.NumericUpDown numOdometer;
        private System.Windows.Forms.Label lblOdometer;
        private System.Windows.Forms.NumericUpDown numFuelLevel;
        private System.Windows.Forms.Label lblFuelLevel;
        private System.Windows.Forms.GroupBox grpReturnDetails;
        private System.Windows.Forms.DataGridView dgvRentals;
        private System.Windows.Forms.GroupBox grpInspection;
        private System.Windows.Forms.GroupBox grpRentals;
        private System.Windows.Forms.Label lblTitle;

        #endregion
    }
}