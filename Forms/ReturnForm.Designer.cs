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
            this.lblRental = new System.Windows.Forms.Label();
            this.cmbRentals = new System.Windows.Forms.ComboBox();
            this.dtpReturnDate = new System.Windows.Forms.DateTimePicker();
            this.lblReturnDate = new System.Windows.Forms.Label();
            this.lblEndMileage = new System.Windows.Forms.Label();
            this.txtEndMileage = new System.Windows.Forms.TextBox();
            this.lblFuel = new System.Windows.Forms.Label();
            this.txtFuel = new System.Windows.Forms.TextBox();
            this.btnComplete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblRental
            // 
            this.lblRental.AutoSize = true;
            this.lblRental.Location = new System.Drawing.Point(30, 30);
            this.lblRental.Name = "lblRental";
            this.lblRental.Size = new System.Drawing.Size(73, 13);
            this.lblRental.TabIndex = 0;
            this.lblRental.Text = "Active Rental:";
            // 
            // cmbRentals
            // 
            this.cmbRentals.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRentals.FormattingEnabled = true;
            this.cmbRentals.Location = new System.Drawing.Point(130, 27);
            this.cmbRentals.Name = "cmbRentals";
            this.cmbRentals.Size = new System.Drawing.Size(400, 21);
            this.cmbRentals.TabIndex = 1;
            // 
            // dtpReturnDate
            // 
            this.dtpReturnDate.Location = new System.Drawing.Point(130, 70);
            this.dtpReturnDate.Name = "dtpReturnDate";
            this.dtpReturnDate.Size = new System.Drawing.Size(200, 20);
            this.dtpReturnDate.TabIndex = 2;
            // 
            // lblReturnDate
            // 
            this.lblReturnDate.AutoSize = true;
            this.lblReturnDate.Location = new System.Drawing.Point(30, 76);
            this.lblReturnDate.Name = "lblReturnDate";
            this.lblReturnDate.Size = new System.Drawing.Size(68, 13);
            this.lblReturnDate.TabIndex = 3;
            this.lblReturnDate.Text = "Return Date:";
            // 
            // lblEndMileage
            // 
            this.lblEndMileage.AutoSize = true;
            this.lblEndMileage.Location = new System.Drawing.Point(30, 116);
            this.lblEndMileage.Name = "lblEndMileage";
            this.lblEndMileage.Size = new System.Drawing.Size(69, 13);
            this.lblEndMileage.TabIndex = 4;
            this.lblEndMileage.Text = "End Mileage:";
            // 
            // txtEndMileage
            // 
            this.txtEndMileage.Location = new System.Drawing.Point(130, 113);
            this.txtEndMileage.Name = "txtEndMileage";
            this.txtEndMileage.Size = new System.Drawing.Size(120, 20);
            this.txtEndMileage.TabIndex = 5;
            // 
            // lblFuel
            // 
            this.lblFuel.AutoSize = true;
            this.lblFuel.Location = new System.Drawing.Point(30, 156);
            this.lblFuel.Name = "lblFuel";
            this.lblFuel.Size = new System.Drawing.Size(79, 13);
            this.lblFuel.TabIndex = 6;
            this.lblFuel.Text = "Fuel Level (%):";
            // 
            // txtFuel
            // 
            this.txtFuel.Location = new System.Drawing.Point(130, 153);
            this.txtFuel.Name = "txtFuel";
            this.txtFuel.Size = new System.Drawing.Size(120, 20);
            this.txtFuel.TabIndex = 7;
            // 
            // btnComplete
            // 
            this.btnComplete.Location = new System.Drawing.Point(130, 200);
            this.btnComplete.Name = "btnComplete";
            this.btnComplete.Size = new System.Drawing.Size(150, 40);
            this.btnComplete.TabIndex = 8;
            this.btnComplete.Text = "Complete Return";
            this.btnComplete.UseVisualStyleBackColor = true;
            this.btnComplete.Click += new System.EventHandler(this.btnComplete_Click);
            // 
            // ReturnForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnComplete);
            this.Controls.Add(this.txtFuel);
            this.Controls.Add(this.lblFuel);
            this.Controls.Add(this.txtEndMileage);
            this.Controls.Add(this.lblEndMileage);
            this.Controls.Add(this.lblReturnDate);
            this.Controls.Add(this.dtpReturnDate);
            this.Controls.Add(this.cmbRentals);
            this.Controls.Add(this.lblRental);
            this.Name = "ReturnForm";
            this.Size = new System.Drawing.Size(800, 500);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRental;
        private System.Windows.Forms.ComboBox cmbRentals;
        private System.Windows.Forms.DateTimePicker dtpReturnDate;
        private System.Windows.Forms.Label lblReturnDate;
        private System.Windows.Forms.Label lblEndMileage;
        private System.Windows.Forms.TextBox txtEndMileage;
        private System.Windows.Forms.Label lblFuel;
        private System.Windows.Forms.TextBox txtFuel;
        private System.Windows.Forms.Button btnComplete;
    }
}
