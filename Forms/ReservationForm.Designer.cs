namespace Vormas.Forms
{
    public partial class ReservationForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelTitle = new System.Windows.Forms.Label();
            this.comboVehicles = new System.Windows.Forms.ComboBox();
            this.labelVehicle = new System.Windows.Forms.Label();
            this.labelCustomer = new System.Windows.Forms.Label();
            this.comboCustomers = new System.Windows.Forms.ComboBox();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.labelStart = new System.Windows.Forms.Label();
            this.labelEnd = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.btnCheckAvailability = new System.Windows.Forms.Button();
            this.lblAvailabilityStatus = new System.Windows.Forms.Label();
            this.btnCreateReservation = new System.Windows.Forms.Button();
            this.labelTotalCost = new System.Windows.Forms.Label();
            this.lblTotalCostValue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(30, 20);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(199, 24);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "New Reservation";
            // 
            // comboVehicles
            // 
            this.comboVehicles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboVehicles.FormattingEnabled = true;
            this.comboVehicles.Location = new System.Drawing.Point(34, 80);
            this.comboVehicles.Name = "comboVehicles";
            this.comboVehicles.Size = new System.Drawing.Size(300, 21);
            this.comboVehicles.TabIndex = 1;
            // 
            // labelVehicle
            // 
            this.labelVehicle.AutoSize = true;
            this.labelVehicle.Location = new System.Drawing.Point(34, 60);
            this.labelVehicle.Name = "labelVehicle";
            this.labelVehicle.Size = new System.Drawing.Size(42, 13);
            this.labelVehicle.TabIndex = 2;
            this.labelVehicle.Text = "Vehicle";
            // 
            // labelCustomer
            // 
            this.labelCustomer.AutoSize = true;
            this.labelCustomer.Location = new System.Drawing.Point(34, 120);
            this.labelCustomer.Name = "labelCustomer";
            this.labelCustomer.Size = new System.Drawing.Size(51, 13);
            this.labelCustomer.TabIndex = 4;
            this.labelCustomer.Text = "Customer";
            // 
            // comboCustomers
            // 
            this.comboCustomers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCustomers.FormattingEnabled = true;
            this.comboCustomers.Location = new System.Drawing.Point(34, 140);
            this.comboCustomers.Name = "comboCustomers";
            this.comboCustomers.Size = new System.Drawing.Size(300, 21);
            this.comboCustomers.TabIndex = 3;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Location = new System.Drawing.Point(34, 200);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(200, 20);
            this.dtpStartDate.TabIndex = 5;
            // 
            // labelStart
            // 
            this.labelStart.AutoSize = true;
            this.labelStart.Location = new System.Drawing.Point(34, 180);
            this.labelStart.Name = "labelStart";
            this.labelStart.Size = new System.Drawing.Size(55, 13);
            this.labelStart.TabIndex = 6;
            this.labelStart.Text = "Start Date";
            // 
            // labelEnd
            // 
            this.labelEnd.AutoSize = true;
            this.labelEnd.Location = new System.Drawing.Point(260, 180);
            this.labelEnd.Name = "labelEnd";
            this.labelEnd.Size = new System.Drawing.Size(52, 13);
            this.labelEnd.TabIndex = 8;
            this.labelEnd.Text = "End Date";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Location = new System.Drawing.Point(260, 200);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(200, 20);
            this.dtpEndDate.TabIndex = 7;
            // 
            // btnCheckAvailability
            // 
            this.btnCheckAvailability.Location = new System.Drawing.Point(34, 240);
            this.btnCheckAvailability.Name = "btnCheckAvailability";
            this.btnCheckAvailability.Size = new System.Drawing.Size(120, 30);
            this.btnCheckAvailability.TabIndex = 9;
            this.btnCheckAvailability.Text = "Check Availability";
            this.btnCheckAvailability.UseVisualStyleBackColor = true;
            // 
            // lblAvailabilityStatus
            // 
            this.lblAvailabilityStatus.AutoSize = true;
            this.lblAvailabilityStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvailabilityStatus.Location = new System.Drawing.Point(170, 247);
            this.lblAvailabilityStatus.Name = "lblAvailabilityStatus";
            this.lblAvailabilityStatus.Size = new System.Drawing.Size(19, 15);
            this.lblAvailabilityStatus.TabIndex = 10;
            this.lblAvailabilityStatus.Text = "...";
            // 
            // btnCreateReservation
            // 
            this.btnCreateReservation.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnCreateReservation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateReservation.ForeColor = System.Drawing.Color.White;
            this.btnCreateReservation.Location = new System.Drawing.Point(34, 300);
            this.btnCreateReservation.Name = "btnCreateReservation";
            this.btnCreateReservation.Size = new System.Drawing.Size(426, 40);
            this.btnCreateReservation.TabIndex = 11;
            this.btnCreateReservation.Text = "Confirm and Create Reservation";
            this.btnCreateReservation.UseVisualStyleBackColor = false;
            // 
            // labelTotalCost
            // 
            this.labelTotalCost.AutoSize = true;
            this.labelTotalCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalCost.Location = new System.Drawing.Point(260, 275);
            this.labelTotalCost.Name = "labelTotalCost";
            this.labelTotalCost.Size = new System.Drawing.Size(102, 17);
            this.labelTotalCost.TabIndex = 12;
            this.labelTotalCost.Text = "Estimated Cost:";
            // 
            // lblTotalCostValue
            // 
            this.lblTotalCostValue.AutoSize = true;
            this.lblTotalCostValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCostValue.Location = new System.Drawing.Point(368, 275);
            this.lblTotalCostValue.Name = "lblTotalCostValue";
            this.lblTotalCostValue.Size = new System.Drawing.Size(49, 17);
            this.lblTotalCostValue.TabIndex = 13;
            this.lblTotalCostValue.Text = "$0.00";
            // 
            // ReservationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 380);
            this.Controls.Add(this.lblTotalCostValue);
            this.Controls.Add(this.labelTotalCost);
            this.Controls.Add(this.btnCreateReservation);
            this.Controls.Add(this.lblAvailabilityStatus);
            this.Controls.Add(this.btnCheckAvailability);
            this.Controls.Add(this.labelEnd);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.labelStart);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.labelCustomer);
            this.Controls.Add(this.comboCustomers);
            this.Controls.Add(this.labelVehicle);
            this.Controls.Add(this.comboVehicles);
            this.Controls.Add(this.labelTitle);
            this.Name = "ReservationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create Reservation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.ComboBox comboVehicles;
        private System.Windows.Forms.Label labelVehicle;
        private System.Windows.Forms.Label labelCustomer;
        private System.Windows.Forms.ComboBox comboCustomers;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label labelStart;
        private System.Windows.Forms.Label labelEnd;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Button btnCheckAvailability;
        private System.Windows.Forms.Label lblAvailabilityStatus;
        private System.Windows.Forms.Button btnCreateReservation;
        private System.Windows.Forms.Label labelTotalCost;
        private System.Windows.Forms.Label lblTotalCostValue;
    }
}
