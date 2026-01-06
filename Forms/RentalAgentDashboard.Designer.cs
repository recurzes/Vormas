using System.ComponentModel;

namespace Vormas.Forms
{
    partial class RentalAgentDashboard
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btnCreateReservation = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(298, 161);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Rental Agent";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCreateReservation
            // 
            this.btnCreateReservation.Location = new System.Drawing.Point(248, 200);
            this.btnCreateReservation.Name = "btnCreateReservation";
            this.btnCreateReservation.Size = new System.Drawing.Size(200, 40);
            this.btnCreateReservation.TabIndex = 1;
            this.btnCreateReservation.Text = "Create New Reservation";
            this.btnCreateReservation.UseVisualStyleBackColor = true;
            this.btnCreateReservation.Click += new System.EventHandler(this.btnCreateReservation_Click);
            // 
            // RentalAgentDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCreateReservation);
            this.Controls.Add(this.label1);
            this.Name = "RentalAgentDashboard";
            this.Size = new System.Drawing.Size(800, 450);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCreateReservation;

        #endregion
    }
}