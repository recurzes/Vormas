namespace Vormas.Forms
{
    partial class RentalForm
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
            this.lblReservation = new System.Windows.Forms.Label();
            this.cmbReservation = new System.Windows.Forms.ComboBox();
            this.lblVehicleDetails = new System.Windows.Forms.Label();
            this.txtVehicleDetails = new System.Windows.Forms.TextBox();
            this.lblCustomerDetails = new System.Windows.Forms.Label();
            this.txtCustomerDetails = new System.Windows.Forms.TextBox();
            this.lblMileage = new System.Windows.Forms.Label();
            this.txtMileage = new System.Windows.Forms.TextBox();
            this.btnStartRental = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblReservation
            // 
            this.lblReservation.AutoSize = true;
            this.lblReservation.Location = new System.Drawing.Point(30, 30);
            this.lblReservation.Name = "lblReservation";
            this.lblReservation.Size = new System.Drawing.Size(100, 13);
            this.lblReservation.TabIndex = 0;
            this.lblReservation.Text = "Select Reservation:";
            // 
            // cmbReservation
            // 
            this.cmbReservation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReservation.FormattingEnabled = true;
            this.cmbReservation.Location = new System.Drawing.Point(150, 27);
            this.cmbReservation.Name = "cmbReservation";
            this.cmbReservation.Size = new System.Drawing.Size(400, 21);
            this.cmbReservation.TabIndex = 1;
            this.cmbReservation.SelectedIndexChanged += new System.EventHandler(this.cmbReservation_SelectedIndexChanged);
            // 
            // lblVehicleDetails
            // 
            this.lblVehicleDetails.AutoSize = true;
            this.lblVehicleDetails.Location = new System.Drawing.Point(30, 80);
            this.lblVehicleDetails.Name = "lblVehicleDetails";
            this.lblVehicleDetails.Size = new System.Drawing.Size(45, 13);
            this.lblVehicleDetails.TabIndex = 2;
            this.lblVehicleDetails.Text = "Vehicle:";
            // 
            // txtVehicleDetails
            // 
            this.txtVehicleDetails.Location = new System.Drawing.Point(150, 77);
            this.txtVehicleDetails.Name = "txtVehicleDetails";
            this.txtVehicleDetails.ReadOnly = true;
            this.txtVehicleDetails.Size = new System.Drawing.Size(400, 20);
            this.txtVehicleDetails.TabIndex = 3;
            // 
            // lblCustomerDetails
            // 
            this.lblCustomerDetails.AutoSize = true;
            this.lblCustomerDetails.Location = new System.Drawing.Point(30, 120);
            this.lblCustomerDetails.Name = "lblCustomerDetails";
            this.lblCustomerDetails.Size = new System.Drawing.Size(54, 13);
            this.lblCustomerDetails.TabIndex = 4;
            this.lblCustomerDetails.Text = "Customer:";
            // 
            // txtCustomerDetails
            // 
            this.txtCustomerDetails.Location = new System.Drawing.Point(150, 117);
            this.txtCustomerDetails.Name = "txtCustomerDetails";
            this.txtCustomerDetails.ReadOnly = true;
            this.txtCustomerDetails.Size = new System.Drawing.Size(400, 20);
            this.txtCustomerDetails.TabIndex = 5;
            // 
            // lblMileage
            // 
            this.lblMileage.AutoSize = true;
            this.lblMileage.Location = new System.Drawing.Point(30, 160);
            this.lblMileage.Name = "lblMileage";
            this.lblMileage.Size = new System.Drawing.Size(95, 13);
            this.lblMileage.TabIndex = 6;
            this.lblMileage.Text = "Current Mileage:";
            // 
            // txtMileage
            // 
            this.txtMileage.Location = new System.Drawing.Point(150, 157);
            this.txtMileage.Name = "txtMileage";
            this.txtMileage.Size = new System.Drawing.Size(150, 20);
            this.txtMileage.TabIndex = 7;
            // 
            // btnStartRental
            // 
            this.btnStartRental.Location = new System.Drawing.Point(150, 200);
            this.btnStartRental.Name = "btnStartRental";
            this.btnStartRental.Size = new System.Drawing.Size(150, 40);
            this.btnStartRental.TabIndex = 8;
            this.btnStartRental.Text = "Start Rental";
            this.btnStartRental.UseVisualStyleBackColor = true;
            this.btnStartRental.Click += new System.EventHandler(this.btnStartRental_Click);
            // 
            // RentalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnStartRental);
            this.Controls.Add(this.txtMileage);
            this.Controls.Add(this.lblMileage);
            this.Controls.Add(this.txtCustomerDetails);
            this.Controls.Add(this.lblCustomerDetails);
            this.Controls.Add(this.txtVehicleDetails);
            this.Controls.Add(this.lblVehicleDetails);
            this.Controls.Add(this.cmbReservation);
            this.Controls.Add(this.lblReservation);
            this.Name = "RentalForm";
            this.Size = new System.Drawing.Size(800, 500);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblReservation;
        private System.Windows.Forms.ComboBox cmbReservation;
        private System.Windows.Forms.Label lblVehicleDetails;
        private System.Windows.Forms.TextBox txtVehicleDetails;
        private System.Windows.Forms.Label lblCustomerDetails;
        private System.Windows.Forms.TextBox txtCustomerDetails;
        private System.Windows.Forms.Label lblMileage;
        private System.Windows.Forms.TextBox txtMileage;
        private System.Windows.Forms.Button btnStartRental;
    }
}
