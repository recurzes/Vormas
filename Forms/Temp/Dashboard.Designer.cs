using System.ComponentModel;

namespace Vormas.Forms.Temp
{
    partial class Dashboard
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
            this.btnVehicle = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnCustomer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnVehicle
            // 
            this.btnVehicle.Location = new System.Drawing.Point(113, 135);
            this.btnVehicle.Name = "btnVehicle";
            this.btnVehicle.Size = new System.Drawing.Size(179, 49);
            this.btnVehicle.TabIndex = 0;
            this.btnVehicle.Text = "Go To Vehicle Page";
            this.btnVehicle.UseVisualStyleBackColor = true;
            this.btnVehicle.Click += new System.EventHandler(this.btnVehicle_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(113, 210);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(179, 49);
            this.btnLogin.TabIndex = 1;
            this.btnLogin.Text = "Go To Login Page";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnCustomer
            // 
            this.btnCustomer.Location = new System.Drawing.Point(113, 286);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Size = new System.Drawing.Size(179, 49);
            this.btnCustomer.TabIndex = 2;
            this.btnCustomer.Text = "Go To Customer Page";
            this.btnCustomer.UseVisualStyleBackColor = true;
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCustomer);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnVehicle);
            this.Name = "Dashboard";
            this.Size = new System.Drawing.Size(418, 471);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button btnVehicle;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnCustomer;

        #endregion
    }
}