using System.ComponentModel;

namespace Vormas.Forms
{
    partial class AdminDashboard
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDamageClaims = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnRateManagement = new System.Windows.Forms.Button();
            this.btnFleetManagement = new System.Windows.Forms.Button();
            this.btnUserManagement = new System.Windows.Forms.Button();
            this.pnlPages = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDamageClaims);
            this.panel1.Controls.Add(this.btnReports);
            this.panel1.Controls.Add(this.btnRateManagement);
            this.panel1.Controls.Add(this.btnFleetManagement);
            this.panel1.Controls.Add(this.btnUserManagement);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(177, 633);
            this.panel1.TabIndex = 0;
            // 
            // btnDamageClaims
            // 
            this.btnDamageClaims.Location = new System.Drawing.Point(29, 349);
            this.btnDamageClaims.Name = "btnDamageClaims";
            this.btnDamageClaims.Size = new System.Drawing.Size(117, 33);
            this.btnDamageClaims.TabIndex = 4;
            this.btnDamageClaims.Text = "Damage Claims";
            this.btnDamageClaims.UseVisualStyleBackColor = true;
            this.btnDamageClaims.Click += new System.EventHandler(this.btnDamageClaims_Click);
            // 
            // btnReports
            // 
            this.btnReports.Location = new System.Drawing.Point(29, 300);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(117, 33);
            this.btnReports.TabIndex = 3;
            this.btnReports.Text = "Reports";
            this.btnReports.UseVisualStyleBackColor = true;
            // 
            // btnRateManagement
            // 
            this.btnRateManagement.Location = new System.Drawing.Point(29, 251);
            this.btnRateManagement.Name = "btnRateManagement";
            this.btnRateManagement.Size = new System.Drawing.Size(117, 33);
            this.btnRateManagement.TabIndex = 2;
            this.btnRateManagement.Text = "Rate Management";
            this.btnRateManagement.UseVisualStyleBackColor = true;
            // 
            // btnFleetManagement
            // 
            this.btnFleetManagement.Location = new System.Drawing.Point(29, 200);
            this.btnFleetManagement.Name = "btnFleetManagement";
            this.btnFleetManagement.Size = new System.Drawing.Size(117, 33);
            this.btnFleetManagement.TabIndex = 1;
            this.btnFleetManagement.Text = "Fleet Management";
            this.btnFleetManagement.UseVisualStyleBackColor = true;
            // 
            // btnUserManagement
            // 
            this.btnUserManagement.Location = new System.Drawing.Point(29, 152);
            this.btnUserManagement.Name = "btnUserManagement";
            this.btnUserManagement.Size = new System.Drawing.Size(117, 33);
            this.btnUserManagement.TabIndex = 0;
            this.btnUserManagement.Text = "User Management";
            this.btnUserManagement.UseVisualStyleBackColor = true;
            this.btnUserManagement.Click += new System.EventHandler(this.btnUserManagement_Click);
            // 
            // pnlPages
            // 
            this.pnlPages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPages.Location = new System.Drawing.Point(177, 0);
            this.pnlPages.Name = "pnlPages";
            this.pnlPages.Size = new System.Drawing.Size(1006, 633);
            this.pnlPages.TabIndex = 1;
            // 
            // AdminDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlPages);
            this.Controls.Add(this.panel1);
            this.Name = "AdminDashboard";
            this.Size = new System.Drawing.Size(1183, 633);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button btnDamageClaims;

        private System.Windows.Forms.Button btnReports;

        private System.Windows.Forms.Button btnRateManagement;

        private System.Windows.Forms.Button btnUserManagement;
        private System.Windows.Forms.Button btnFleetManagement;

        private System.Windows.Forms.Panel pnlPages;

        private System.Windows.Forms.Panel panel1;

        #endregion
    }
}