using System.Drawing;
using System.Windows.Forms;

namespace Vormas.Forms
{
    partial class UserRegisterForm
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlCard = new System.Windows.Forms.Panel();
            this.tlpLayout = new System.Windows.Forms.TableLayoutPanel();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblTagline = new System.Windows.Forms.Label();
            this.btnRegister = new System.Windows.Forms.Button();
            this.lnkLogin = new System.Windows.Forms.LinkLabel();
            this.chkTerms = new System.Windows.Forms.CheckBox();
            
            // Personal Info Controls
            this.lblPersonalHeader = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.dtmBirthDate = new System.Windows.Forms.DateTimePicker();
            this.lblBirthDate = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();

            // Account Info Controls
            this.lblAccountHeader = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.chkShowPassword = new System.Windows.Forms.CheckBox();
            this.pbPasswordStrength = new System.Windows.Forms.ProgressBar();
            this.lblPasswordStrength = new System.Windows.Forms.Label();
            this.txtVerifyPassword = new System.Windows.Forms.TextBox();
            this.lblVerifyPassword = new System.Windows.Forms.Label();
            this.lblStartCheck = new System.Windows.Forms.Label();
            this.lblLengthCheck = new System.Windows.Forms.Label();
            this.lblNumberCheck = new System.Windows.Forms.Label();
            this.lblSpecialCheck = new System.Windows.Forms.Label();
            this.cmbRole = new System.Windows.Forms.ComboBox(); // Hidden or auto-assigned usually, keeping for compatibility
            this.cmbIsActive = new System.Windows.Forms.ComboBox(); // Keeping for compatibility

            this.pnlMain.SuspendLayout();
            this.pnlCard.SuspendLayout();
            this.tlpLayout.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.SuspendLayout();

            // 
            // pnlMain
            // 
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(249, 250, 251); // Gray-50
            this.pnlMain.Controls.Add(this.pnlCard);
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1000, 700);
            this.pnlMain.TabIndex = 0;
            this.pnlMain.Padding = new Padding(20);

            // 
            // pnlCard
            // 
            this.pnlCard.Anchor = AnchorStyles.None;
            this.pnlCard.BackColor = System.Drawing.Color.White;
            this.pnlCard.Controls.Add(this.lblHeader);
            this.pnlCard.Controls.Add(this.lblTagline);
            this.pnlCard.Controls.Add(this.tlpLayout);
            this.pnlCard.Controls.Add(this.chkTerms);
            this.pnlCard.Controls.Add(this.btnRegister);
            this.pnlCard.Controls.Add(this.lnkLogin);
            this.pnlCard.Location = new System.Drawing.Point(100, 25);
            this.pnlCard.Name = "pnlCard";
            this.pnlCard.Size = new System.Drawing.Size(800, 650);
            this.pnlCard.TabIndex = 0;

            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = false;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblHeader.Location = new System.Drawing.Point(0, 20);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(800, 45);
            this.lblHeader.TabIndex = 1;
            this.lblHeader.Text = "Join Vormas";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // lblTagline
            // 
            this.lblTagline.AutoSize = false;
            this.lblTagline.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTagline.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblTagline.Location = new System.Drawing.Point(0, 65);
            this.lblTagline.Name = "lblTagline";
            this.lblTagline.Size = new System.Drawing.Size(800, 30);
            this.lblTagline.TabIndex = 2;
            this.lblTagline.Text = "Create your account to get started";
            this.lblTagline.TextAlign = System.Drawing.ContentAlignment.TopCenter;

            // 
            // tlpLayout
            // 
            this.tlpLayout.ColumnCount = 2;
            this.tlpLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpLayout.Controls.Add(this.pnlLeft, 0, 0);
            this.tlpLayout.Controls.Add(this.pnlRight, 1, 0);
            this.tlpLayout.Location = new System.Drawing.Point(30, 100);
            this.tlpLayout.Name = "tlpLayout";
            this.tlpLayout.RowCount = 1;
            this.tlpLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLayout.Size = new System.Drawing.Size(740, 400);
            this.tlpLayout.TabIndex = 3;

            // 
            // pnlLeft (Personal Info)
            // 
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeft.AutoScroll = true;
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.pnlLeft.Controls.Add(this.lblPersonalHeader);
            this.pnlLeft.Controls.Add(this.lblFirstName);
            this.pnlLeft.Controls.Add(this.txtFirstName);
            this.pnlLeft.Controls.Add(this.lblLastName);
            this.pnlLeft.Controls.Add(this.txtLastName);
            this.pnlLeft.Controls.Add(this.lblEmail);
            this.pnlLeft.Controls.Add(this.txtEmail);
            this.pnlLeft.Controls.Add(this.lblPhone);
            this.pnlLeft.Controls.Add(this.txtPhone);
            this.pnlLeft.Controls.Add(this.lblBirthDate);
            this.pnlLeft.Controls.Add(this.dtmBirthDate);
            this.pnlLeft.Controls.Add(this.lblAddress);
            this.pnlLeft.Controls.Add(this.txtAddress);

            // 
            // lblPersonalHeader
            // 
            this.lblPersonalHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblPersonalHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.lblPersonalHeader.Location = new System.Drawing.Point(0, 0);
            this.lblPersonalHeader.Size = new System.Drawing.Size(300, 30);
            this.lblPersonalHeader.Text = "Personal Information";

            // FirstName
            this.lblFirstName.Location = new System.Drawing.Point(0, 40);
            this.lblFirstName.Text = "First Name";
            this.lblFirstName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFirstName.Size = new System.Drawing.Size(300, 20);
            
            this.txtFirstName.Location = new System.Drawing.Point(0, 60);
            this.txtFirstName.Size = new System.Drawing.Size(320, 25);
            this.txtFirstName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtFirstName.Name = "txtFirstName";

            // LastName
            this.lblLastName.Location = new System.Drawing.Point(0, 95);
            this.lblLastName.Text = "Last Name";
            this.lblLastName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblLastName.Size = new System.Drawing.Size(300, 20);

            this.txtLastName.Location = new System.Drawing.Point(0, 115);
            this.txtLastName.Size = new System.Drawing.Size(320, 25);
            this.txtLastName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtLastName.Name = "txtLastName";

            // Email
            this.lblEmail.Location = new System.Drawing.Point(0, 150);
            this.lblEmail.Text = "Email Address";
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblEmail.Size = new System.Drawing.Size(300, 20);

            this.txtEmail.Location = new System.Drawing.Point(0, 170);
            this.txtEmail.Size = new System.Drawing.Size(320, 25);
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtEmail.Name = "txtEmail";

             // Phone
            this.lblPhone.Location = new System.Drawing.Point(0, 205);
            this.lblPhone.Text = "Phone Number";
            this.lblPhone.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPhone.Size = new System.Drawing.Size(300, 20);

            this.txtPhone.Location = new System.Drawing.Point(0, 225);
            this.txtPhone.Size = new System.Drawing.Size(320, 25);
            this.txtPhone.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPhone.Name = "txtPhone";

             // DOB
            this.lblBirthDate.Location = new System.Drawing.Point(0, 260);
            this.lblBirthDate.Text = "Date of Birth";
            this.lblBirthDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblBirthDate.Size = new System.Drawing.Size(300, 20);

            this.dtmBirthDate.Location = new System.Drawing.Point(0, 280);
            this.dtmBirthDate.Size = new System.Drawing.Size(320, 25);
            this.dtmBirthDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtmBirthDate.Format = DateTimePickerFormat.Short;
            this.dtmBirthDate.Name = "dtmBirthDate";

            // Address
            this.lblAddress.Location = new System.Drawing.Point(0, 315);
            this.lblAddress.Text = "Address";
            this.lblAddress.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblAddress.Size = new System.Drawing.Size(300, 20);

            this.txtAddress.Location = new System.Drawing.Point(0, 335);
            this.txtAddress.Size = new System.Drawing.Size(320, 50); // Multiline
            this.txtAddress.Multiline = true;
            this.txtAddress.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAddress.Name = "txtAddress";


            // 
            // pnlRight (Account Info)
            // 
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.AutoScroll = true;
            this.pnlRight.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.pnlRight.Controls.Add(this.lblAccountHeader);
            this.pnlRight.Controls.Add(this.lblUsername);
            this.pnlRight.Controls.Add(this.txtUsername);
            this.pnlRight.Controls.Add(this.lblPassword);
            this.pnlRight.Controls.Add(this.txtPassword);
            this.pnlRight.Controls.Add(this.chkShowPassword);
            this.pnlRight.Controls.Add(this.pbPasswordStrength);
            this.pnlRight.Controls.Add(this.lblPasswordStrength);
            this.pnlRight.Controls.Add(this.lblVerifyPassword);
            this.pnlRight.Controls.Add(this.txtVerifyPassword);
            // Validation labels
            this.pnlRight.Controls.Add(this.lblLengthCheck);
            this.pnlRight.Controls.Add(this.lblNumberCheck);
            this.pnlRight.Controls.Add(this.lblSpecialCheck);
            // Hidden/Compat
            this.pnlRight.Controls.Add(this.cmbRole);
            this.pnlRight.Controls.Add(this.cmbIsActive);


             // Header
            this.lblAccountHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblAccountHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.lblAccountHeader.Location = new System.Drawing.Point(20, 0);
            this.lblAccountHeader.Size = new System.Drawing.Size(300, 30);
            this.lblAccountHeader.Text = "Account Details";

            // Username
            this.lblUsername.Location = new System.Drawing.Point(20, 40);
            this.lblUsername.Text = "Username";
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblUsername.Size = new System.Drawing.Size(300, 20);

            this.txtUsername.Location = new System.Drawing.Point(20, 60);
            this.txtUsername.Size = new System.Drawing.Size(320, 25);
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtUsername.Name = "txtUsername";

            // Password
            this.lblPassword.Location = new System.Drawing.Point(20, 95);
            this.lblPassword.Text = "Password";
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPassword.Size = new System.Drawing.Size(300, 20);

            this.txtPassword.Location = new System.Drawing.Point(20, 115);
            this.txtPassword.Size = new System.Drawing.Size(320, 25);
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Name = "txtPassword";

            // Show Password
            this.chkShowPassword.Location = new System.Drawing.Point(20, 142);
            this.chkShowPassword.Text = "Show Password";
            this.chkShowPassword.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.chkShowPassword.AutoSize = true;
            this.chkShowPassword.Name = "chkShowPassword";

            // Strength Bar
            this.pbPasswordStrength.Location = new System.Drawing.Point(20, 165);
            this.pbPasswordStrength.Size = new System.Drawing.Size(320, 5);
            this.pbPasswordStrength.Style = ProgressBarStyle.Continuous;
            this.pbPasswordStrength.Name = "pbPasswordStrength";

             // Strength Text
            this.lblPasswordStrength.Location = new System.Drawing.Point(20, 172);
            this.lblPasswordStrength.Text = "Strength: Weak";
            this.lblPasswordStrength.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblPasswordStrength.ForeColor = System.Drawing.Color.Gray;
            this.lblPasswordStrength.AutoSize = true;
            this.lblPasswordStrength.Name = "lblPasswordStrength";

            // Verify Password
            this.lblVerifyPassword.Location = new System.Drawing.Point(20, 195);
            this.lblVerifyPassword.Text = "Confirm Password";
            this.lblVerifyPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblVerifyPassword.Size = new System.Drawing.Size(300, 20);

            this.txtVerifyPassword.Location = new System.Drawing.Point(20, 215);
            this.txtVerifyPassword.Size = new System.Drawing.Size(320, 25);
            this.txtVerifyPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtVerifyPassword.PasswordChar = '●';
            this.txtVerifyPassword.Name = "txtVerifyPassword";

            // Requirements checks
            this.lblLengthCheck.Location = new System.Drawing.Point(20, 250);
            this.lblLengthCheck.Text = "• At least 8 characters";
            this.lblLengthCheck.ForeColor = Color.Red;
            this.lblLengthCheck.AutoSize = true;
            this.lblLengthCheck.Name = "lblLengthCheck";

            this.lblNumberCheck.Location = new System.Drawing.Point(20, 270);
            this.lblNumberCheck.Text = "• Contains number";
            this.lblNumberCheck.ForeColor = Color.Red;
            this.lblNumberCheck.AutoSize = true;
            this.lblNumberCheck.Name = "lblNumberCheck";

            this.lblSpecialCheck.Location = new System.Drawing.Point(20, 290);
            this.lblSpecialCheck.Text = "• Contains special char";
            this.lblSpecialCheck.ForeColor = Color.Red;
            this.lblSpecialCheck.AutoSize = true;
            this.lblSpecialCheck.Name = "lblSpecialCheck";

            // Hidden but needed
            this.cmbRole.Visible = false;
            this.cmbIsActive.Visible = false;
            
            // 
            // chkTerms
            // 
            this.chkTerms.Location = new System.Drawing.Point(30, 520);
            this.chkTerms.Text = "I agree to the Terms of Service and Privacy Policy";
            this.chkTerms.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkTerms.AutoSize = true;
            this.chkTerms.Name = "chkTerms";

            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnRegister.ForeColor = System.Drawing.Color.White;
            this.btnRegister.Cursor = Cursors.Hand;
            this.btnRegister.FlatAppearance.BorderSize = 0;
            this.btnRegister.Location = new System.Drawing.Point(30, 550);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(740, 45);
            this.btnRegister.TabIndex = 20;
            this.btnRegister.Text = "Create Account";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);

            // 
            // lnkLogin
            // 
            this.lnkLogin.AutoSize = true;
            this.lnkLogin.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lnkLogin.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            // Center roughly: 800/2 = 400. Text is ~200px wide. 400-100 = 300.
            this.lnkLogin.Location = new System.Drawing.Point(300, 610);
            this.lnkLogin.Name = "lnkLogin";
            this.lnkLogin.Size = new System.Drawing.Size(200, 20);
            this.lnkLogin.TabIndex = 21;
            this.lnkLogin.TabStop = true;
            this.lnkLogin.Text = "Already have an account? Sign in";
            this.lnkLogin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLogin_LinkClicked);


            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UserRegisterForm";
            this.Text = "Join Vormas";
            
            this.pnlMain.ResumeLayout(false);
            this.pnlCard.ResumeLayout(false);
            this.pnlCard.PerformLayout();
            this.tlpLayout.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlCard;
        private System.Windows.Forms.TableLayoutPanel tlpLayout;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblTagline;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.LinkLabel lnkLogin;
        private System.Windows.Forms.CheckBox chkTerms;

        // Personal
        private System.Windows.Forms.Label lblPersonalHeader;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblBirthDate;
        private System.Windows.Forms.DateTimePicker dtmBirthDate;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;

        // Account
        private System.Windows.Forms.Label lblAccountHeader;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblVerifyPassword;
        private System.Windows.Forms.TextBox txtVerifyPassword;
        private System.Windows.Forms.CheckBox chkShowPassword;
        private System.Windows.Forms.ProgressBar pbPasswordStrength;
        private System.Windows.Forms.Label lblPasswordStrength;

        // Validation Checks
        private System.Windows.Forms.Label lblStartCheck; // Unused but kept for structure
        private System.Windows.Forms.Label lblLengthCheck;
        private System.Windows.Forms.Label lblNumberCheck;
        private System.Windows.Forms.Label lblSpecialCheck;

        // Legacy/Hidden
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.ComboBox cmbIsActive;

    }
}