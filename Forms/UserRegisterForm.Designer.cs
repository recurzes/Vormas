using System.ComponentModel;

namespace Vormas.Forms
{
    partial class UserRegisterForm
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
            this.pnlCard = new System.Windows.Forms.Panel();
            this.lnkLogin = new System.Windows.Forms.LinkLabel();
            this.btnRegister = new System.Windows.Forms.Button();
            this.labelHeader = new System.Windows.Forms.Label();
            this.grpAccount = new System.Windows.Forms.GroupBox();
            this.cmbIsActive = new System.Windows.Forms.ComboBox();
            this.cmbRole = new System.Windows.Forms.ComboBox();
            this.txtVerifyPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.grpPersonal = new System.Windows.Forms.GroupBox();
            this.dtmBirthDate = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlCard.SuspendLayout();
            this.grpAccount.SuspendLayout();
            this.grpPersonal.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCard
            // 
            this.pnlCard.BackColor = System.Drawing.Color.White;
            this.pnlCard.Controls.Add(this.lnkLogin);
            this.pnlCard.Controls.Add(this.btnRegister);
            this.pnlCard.Controls.Add(this.labelHeader);
            this.pnlCard.Controls.Add(this.grpAccount);
            this.pnlCard.Controls.Add(this.grpPersonal);
            this.pnlCard.Location = new System.Drawing.Point(50, 25);
            this.pnlCard.Name = "pnlCard";
            this.pnlCard.Size = new System.Drawing.Size(700, 500);
            this.pnlCard.TabIndex = 0;
            // 
            // lnkLogin
            // 
            this.lnkLogin.AutoSize = true;
            this.lnkLogin.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lnkLogin.Location = new System.Drawing.Point(280, 460);
            this.lnkLogin.Name = "lnkLogin";
            this.lnkLogin.Size = new System.Drawing.Size(142, 15);
            this.lnkLogin.TabIndex = 22;
            this.lnkLogin.TabStop = true;
            this.lnkLogin.Text = "Already have an account?";
            this.lnkLogin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLogin_LinkClicked);
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.btnRegister.FlatAppearance.BorderSize = 0;
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnRegister.ForeColor = System.Drawing.Color.White;
            this.btnRegister.Location = new System.Drawing.Point(250, 410);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(200, 40);
            this.btnRegister.TabIndex = 21;
            this.btnRegister.Text = "Create Account";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // labelHeader
            // 
            this.labelHeader.AutoSize = false;
            this.labelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelHeader.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.labelHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.labelHeader.Location = new System.Drawing.Point(0, 0);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(700, 60);
            this.labelHeader.TabIndex = 0;
            this.labelHeader.Text = "Join Vormas";
            this.labelHeader.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // grpPersonal
            // 
            this.grpPersonal.Controls.Add(this.dtmBirthDate);
            this.grpPersonal.Controls.Add(this.label12);
            this.grpPersonal.Controls.Add(this.txtPhone);
            this.grpPersonal.Controls.Add(this.txtEmail);
            this.grpPersonal.Controls.Add(this.txtAddress);
            this.grpPersonal.Controls.Add(this.txtLastName);
            this.grpPersonal.Controls.Add(this.txtFirstName);
            this.grpPersonal.Controls.Add(this.label5);
            this.grpPersonal.Controls.Add(this.label4);
            this.grpPersonal.Controls.Add(this.label3);
            this.grpPersonal.Controls.Add(this.label2);
            this.grpPersonal.Controls.Add(this.label1);
            this.grpPersonal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpPersonal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.grpPersonal.Location = new System.Drawing.Point(20, 80);
            this.grpPersonal.Name = "grpPersonal";
            this.grpPersonal.Size = new System.Drawing.Size(320, 310);
            this.grpPersonal.TabIndex = 1;
            this.grpPersonal.TabStop = false;
            this.grpPersonal.Text = "Personal Information";
            // 
            // grpAccount
            // 
            this.grpAccount.Controls.Add(this.cmbIsActive);
            this.grpAccount.Controls.Add(this.cmbRole);
            this.grpAccount.Controls.Add(this.txtVerifyPassword);
            this.grpAccount.Controls.Add(this.txtUsername);
            this.grpAccount.Controls.Add(this.txtPassword);
            this.grpAccount.Controls.Add(this.label10);
            this.grpAccount.Controls.Add(this.label9);
            this.grpAccount.Controls.Add(this.label8);
            this.grpAccount.Controls.Add(this.label7);
            this.grpAccount.Controls.Add(this.label6);
            this.grpAccount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpAccount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.grpAccount.Location = new System.Drawing.Point(360, 80);
            this.grpAccount.Name = "grpAccount";
            this.grpAccount.Size = new System.Drawing.Size(320, 310);
            this.grpAccount.TabIndex = 2;
            this.grpAccount.TabStop = false;
            this.grpAccount.Text = "Account Details";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.Location = new System.Drawing.Point(15, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 15);
            this.label1.Text = "First Name";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtFirstName.Location = new System.Drawing.Point(15, 48);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(290, 23);
            this.txtFirstName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label2.Location = new System.Drawing.Point(15, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 15);
            this.label2.Text = "Last Name";
            // 
            // txtLastName
            // 
            this.txtLastName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtLastName.Location = new System.Drawing.Point(15, 93);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(290, 23);
            this.txtLastName.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label12.Location = new System.Drawing.Point(15, 120);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(73, 15);
            this.label12.Text = "Date of Birth";
            // 
            // dtmBirthDate
            // 
            this.dtmBirthDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtmBirthDate.Location = new System.Drawing.Point(15, 138);
            this.dtmBirthDate.Name = "dtmBirthDate";
            this.dtmBirthDate.Size = new System.Drawing.Size(290, 23);
            this.dtmBirthDate.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label3.Location = new System.Drawing.Point(15, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 15);
            this.label3.Text = "Address";
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtAddress.Location = new System.Drawing.Point(15, 183);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(290, 23);
            this.txtAddress.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label4.Location = new System.Drawing.Point(15, 210);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 15);
            this.label4.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtEmail.Location = new System.Drawing.Point(15, 228);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(290, 23);
            this.txtEmail.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label5.Location = new System.Drawing.Point(15, 255);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 15);
            this.label5.Text = "Phone";
            // 
            // txtPhone
            // 
            this.txtPhone.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPhone.Location = new System.Drawing.Point(15, 273);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(290, 23);
            this.txtPhone.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label6.Location = new System.Drawing.Point(15, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 15);
            this.label6.Text = "Username";
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtUsername.Location = new System.Drawing.Point(15, 48);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(290, 23);
            this.txtUsername.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label7.Location = new System.Drawing.Point(15, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 15);
            this.label7.Text = "Password";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPassword.Location = new System.Drawing.Point(15, 93);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Size = new System.Drawing.Size(290, 23);
            this.txtPassword.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label8.Location = new System.Drawing.Point(15, 120);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 15);
            this.label8.Text = "Verify Password";
            // 
            // txtVerifyPassword
            // 
            this.txtVerifyPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtVerifyPassword.Location = new System.Drawing.Point(15, 138);
            this.txtVerifyPassword.Name = "txtVerifyPassword";
            this.txtVerifyPassword.PasswordChar = '●';
            this.txtVerifyPassword.Size = new System.Drawing.Size(290, 23);
            this.txtVerifyPassword.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label9.Location = new System.Drawing.Point(15, 165);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 15);
            this.label9.Text = "Role";
            // 
            // cmbRole
            // 
            this.cmbRole.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbRole.FormattingEnabled = true;

            this.cmbRole.Location = new System.Drawing.Point(15, 183);
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.Size = new System.Drawing.Size(290, 23);
            this.cmbRole.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label10.Location = new System.Drawing.Point(15, 210);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 15);
            this.label10.Text = "Is Active";
            // 
            // cmbIsActive
            // 
            this.cmbIsActive.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbIsActive.FormattingEnabled = true;
            this.cmbIsActive.Items.AddRange(new object[] { "Yes", "No" });
            this.cmbIsActive.Location = new System.Drawing.Point(15, 228);
            this.cmbIsActive.Name = "cmbIsActive";
            this.cmbIsActive.Size = new System.Drawing.Size(290, 23);
            this.cmbIsActive.TabIndex = 11;
            // 
            // UserRegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.pnlCard);
            this.Name = "UserRegisterForm";
            this.Text = "Register - Vormas";
            this.pnlCard.ResumeLayout(false);
            this.pnlCard.PerformLayout();
            this.grpAccount.ResumeLayout(false);
            this.grpAccount.PerformLayout();
            this.grpPersonal.ResumeLayout(false);
            this.grpPersonal.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlCard;
        private System.Windows.Forms.GroupBox grpPersonal;
        private System.Windows.Forms.GroupBox grpAccount;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.LinkLabel lnkLogin;

        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dtmBirthDate;

        private System.Windows.Forms.Button btnRegister;

        private System.Windows.Forms.ComboBox cmbIsActive;

        private System.Windows.Forms.ComboBox cmbRole;

        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtVerifyPassword;

        private System.Windows.Forms.TextBox txtPhone;

        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtEmail;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;

        #endregion
    }
}