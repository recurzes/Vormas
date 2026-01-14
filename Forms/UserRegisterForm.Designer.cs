using System.ComponentModel;
using System.Drawing;

namespace Vormas.Forms
{
    partial class UserRegisterForm
    {
        private IContainer components = null;

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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlRegisterCard = new System.Windows.Forms.Panel();
            this.btnRegister = new System.Windows.Forms.Button();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.lblRightSection = new System.Windows.Forms.Label();
            this.pnlIsActive = new System.Windows.Forms.Panel();
            this.cmbIsActive = new System.Windows.Forms.ComboBox();
            this.lblIsActiveIcon = new System.Windows.Forms.Label();
            this.lblIsActive = new System.Windows.Forms.Label();
            this.pnlRole = new System.Windows.Forms.Panel();
            this.cmbRole = new System.Windows.Forms.ComboBox();
            this.lblRoleIcon = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.pnlVerifyPassword = new System.Windows.Forms.Panel();
            this.txtVerifyPassword = new System.Windows.Forms.TextBox();
            this.lblVerifyPasswordIcon = new System.Windows.Forms.Label();
            this.lblVerifyPassword = new System.Windows.Forms.Label();
            this.pnlPassword = new System.Windows.Forms.Panel();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPasswordIcon = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.pnlUsername = new System.Windows.Forms.Panel();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblUsernameIcon = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.pnlBirthDate = new System.Windows.Forms.Panel();
            this.dtmBirthDate = new System.Windows.Forms.DateTimePicker();
            this.lblBirthDateIcon = new System.Windows.Forms.Label();
            this.lblBirthDate = new System.Windows.Forms.Label();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.lblLeftSection = new System.Windows.Forms.Label();
            this.pnlPhone = new System.Windows.Forms.Panel();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblPhoneIcon = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.pnlEmail = new System.Windows.Forms.Panel();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmailIcon = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.pnlAddress = new System.Windows.Forms.Panel();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblAddressIcon = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.pnlLastName = new System.Windows.Forms.Panel();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblLastNameIcon = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.pnlFirstName = new System.Windows.Forms.Panel();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblFirstNameIcon = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.lblLogoText = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.pnlRegisterCard.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlIsActive.SuspendLayout();
            this.pnlRole.SuspendLayout();
            this.pnlVerifyPassword.SuspendLayout();
            this.pnlPassword.SuspendLayout();
            this.pnlUsername.SuspendLayout();
            this.pnlBirthDate.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlPhone.SuspendLayout();
            this.pnlEmail.SuspendLayout();
            this.pnlAddress.SuspendLayout();
            this.pnlLastName.SuspendLayout();
            this.pnlFirstName.SuspendLayout();
            this.pnlLogo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(24)))), ((int)(((byte)(38)))));
            this.pnlMain.Controls.Add(this.pnlRegisterCard);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(900, 600);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlRegisterCard
            // 
            this.pnlRegisterCard.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlRegisterCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(35)))), ((int)(((byte)(53)))));
            this.pnlRegisterCard.Controls.Add(this.btnRegister);
            this.pnlRegisterCard.Controls.Add(this.pnlRight);
            this.pnlRegisterCard.Controls.Add(this.pnlLeft);
            this.pnlRegisterCard.Controls.Add(this.lblSubtitle);
            this.pnlRegisterCard.Controls.Add(this.lblTitle);
            this.pnlRegisterCard.Controls.Add(this.pnlLogo);
            this.pnlRegisterCard.Location = new System.Drawing.Point(100, 30);
            this.pnlRegisterCard.Name = "pnlRegisterCard";
            this.pnlRegisterCard.Padding = new System.Windows.Forms.Padding(30);
            this.pnlRegisterCard.Size = new System.Drawing.Size(700, 540);
            this.pnlRegisterCard.TabIndex = 0;
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnRegister.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegister.FlatAppearance.BorderSize = 0;
            this.btnRegister.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(150)))), ((int)(((byte)(105)))));
            this.btnRegister.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(211)))), ((int)(((byte)(153)))));
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRegister.ForeColor = System.Drawing.Color.White;
            this.btnRegister.Location = new System.Drawing.Point(225, 480);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(250, 48);
            this.btnRegister.TabIndex = 13;
            this.btnRegister.Text = "Create Account";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.lblRightSection);
            this.pnlRight.Controls.Add(this.pnlIsActive);
            this.pnlRight.Controls.Add(this.pnlRole);
            this.pnlRight.Controls.Add(this.pnlVerifyPassword);
            this.pnlRight.Controls.Add(this.pnlPassword);
            this.pnlRight.Controls.Add(this.pnlUsername);
            this.pnlRight.Controls.Add(this.pnlBirthDate);
            this.pnlRight.Location = new System.Drawing.Point(360, 130);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(310, 335);
            this.pnlRight.TabIndex = 5;
            // 
            // lblRightSection
            // 
            this.lblRightSection.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblRightSection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblRightSection.Location = new System.Drawing.Point(0, 0);
            this.lblRightSection.Name = "lblRightSection";
            this.lblRightSection.Size = new System.Drawing.Size(310, 25);
            this.lblRightSection.TabIndex = 0;
            this.lblRightSection.Text = "Account Settings";
            // 
            // pnlIsActive
            // 
            this.pnlIsActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(47)))), ((int)(((byte)(70)))));
            this.pnlIsActive.Controls.Add(this.cmbIsActive);
            this.pnlIsActive.Controls.Add(this.lblIsActiveIcon);
            this.pnlIsActive.Controls.Add(this.lblIsActive);
            this.pnlIsActive.Location = new System.Drawing.Point(0, 285);
            this.pnlIsActive.Name = "pnlIsActive";
            this.pnlIsActive.Size = new System.Drawing.Size(310, 42);
            this.pnlIsActive.TabIndex = 6;
            // 
            // cmbIsActive
            // 
            this.cmbIsActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(47)))), ((int)(((byte)(70)))));
            this.cmbIsActive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIsActive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbIsActive.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbIsActive.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.cmbIsActive.FormattingEnabled = true;
            this.cmbIsActive.Items.AddRange(new object[] { "Yes", "No" });
            this.cmbIsActive.Location = new System.Drawing.Point(115, 8);
            this.cmbIsActive.Name = "cmbIsActive";
            this.cmbIsActive.Size = new System.Drawing.Size(185, 25);
            this.cmbIsActive.TabIndex = 12;
            // 
            // lblIsActiveIcon
            // 
            this.lblIsActiveIcon.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblIsActiveIcon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(115)))), ((int)(((byte)(148)))));
            this.lblIsActiveIcon.Location = new System.Drawing.Point(10, 10);
            this.lblIsActiveIcon.Name = "lblIsActiveIcon";
            this.lblIsActiveIcon.Size = new System.Drawing.Size(22, 22);
            this.lblIsActiveIcon.TabIndex = 0;
            this.lblIsActiveIcon.Text = "✓";
            this.lblIsActiveIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblIsActive
            // 
            this.lblIsActive.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblIsActive.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblIsActive.Location = new System.Drawing.Point(32, 12);
            this.lblIsActive.Name = "lblIsActive";
            this.lblIsActive.Size = new System.Drawing.Size(80, 18);
            this.lblIsActive.TabIndex = 1;
            this.lblIsActive.Text = "Active";
            // 
            // pnlRole
            // 
            this.pnlRole.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(47)))), ((int)(((byte)(70)))));
            this.pnlRole.Controls.Add(this.cmbRole);
            this.pnlRole.Controls.Add(this.lblRoleIcon);
            this.pnlRole.Controls.Add(this.lblRole);
            this.pnlRole.Location = new System.Drawing.Point(0, 237);
            this.pnlRole.Name = "pnlRole";
            this.pnlRole.Size = new System.Drawing.Size(310, 42);
            this.pnlRole.TabIndex = 5;
            // 
            // cmbRole
            // 
            this.cmbRole.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(47)))), ((int)(((byte)(70)))));
            this.cmbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRole.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbRole.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbRole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.cmbRole.FormattingEnabled = true;
            this.cmbRole.Items.AddRange(new object[] { "Admin", "Agent" });
            this.cmbRole.Location = new System.Drawing.Point(115, 8);
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.Size = new System.Drawing.Size(185, 25);
            this.cmbRole.TabIndex = 11;
            // 
            // lblRoleIcon
            // 
            this.lblRoleIcon.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblRoleIcon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(115)))), ((int)(((byte)(148)))));
            this.lblRoleIcon.Location = new System.Drawing.Point(10, 10);
            this.lblRoleIcon.Name = "lblRoleIcon";
            this.lblRoleIcon.Size = new System.Drawing.Size(22, 22);
            this.lblRoleIcon.TabIndex = 0;
            this.lblRoleIcon.Text = "⚙";
            this.lblRoleIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRole
            // 
            this.lblRole.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblRole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblRole.Location = new System.Drawing.Point(32, 12);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(80, 18);
            this.lblRole.TabIndex = 1;
            this.lblRole.Text = "Role";
            // 
            // pnlVerifyPassword
            // 
            this.pnlVerifyPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(47)))), ((int)(((byte)(70)))));
            this.pnlVerifyPassword.Controls.Add(this.txtVerifyPassword);
            this.pnlVerifyPassword.Controls.Add(this.lblVerifyPasswordIcon);
            this.pnlVerifyPassword.Controls.Add(this.lblVerifyPassword);
            this.pnlVerifyPassword.Location = new System.Drawing.Point(0, 189);
            this.pnlVerifyPassword.Name = "pnlVerifyPassword";
            this.pnlVerifyPassword.Size = new System.Drawing.Size(310, 42);
            this.pnlVerifyPassword.TabIndex = 4;
            // 
            // txtVerifyPassword
            // 
            this.txtVerifyPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(47)))), ((int)(((byte)(70)))));
            this.txtVerifyPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtVerifyPassword.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtVerifyPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.txtVerifyPassword.Location = new System.Drawing.Point(115, 12);
            this.txtVerifyPassword.Name = "txtVerifyPassword";
            this.txtVerifyPassword.PasswordChar = '●';
            this.txtVerifyPassword.Size = new System.Drawing.Size(185, 18);
            this.txtVerifyPassword.TabIndex = 10;
            // 
            // lblVerifyPasswordIcon
            // 
            this.lblVerifyPasswordIcon.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblVerifyPasswordIcon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(115)))), ((int)(((byte)(148)))));
            this.lblVerifyPasswordIcon.Location = new System.Drawing.Point(10, 10);
            this.lblVerifyPasswordIcon.Name = "lblVerifyPasswordIcon";
            this.lblVerifyPasswordIcon.Size = new System.Drawing.Size(22, 22);
            this.lblVerifyPasswordIcon.TabIndex = 0;
            this.lblVerifyPasswordIcon.Text = "🔐";
            this.lblVerifyPasswordIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVerifyPassword
            // 
            this.lblVerifyPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblVerifyPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblVerifyPassword.Location = new System.Drawing.Point(32, 12);
            this.lblVerifyPassword.Name = "lblVerifyPassword";
            this.lblVerifyPassword.Size = new System.Drawing.Size(80, 18);
            this.lblVerifyPassword.TabIndex = 1;
            this.lblVerifyPassword.Text = "Confirm";
            // 
            // pnlPassword
            // 
            this.pnlPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(47)))), ((int)(((byte)(70)))));
            this.pnlPassword.Controls.Add(this.txtPassword);
            this.pnlPassword.Controls.Add(this.lblPasswordIcon);
            this.pnlPassword.Controls.Add(this.lblPassword);
            this.pnlPassword.Location = new System.Drawing.Point(0, 141);
            this.pnlPassword.Name = "pnlPassword";
            this.pnlPassword.Size = new System.Drawing.Size(310, 42);
            this.pnlPassword.TabIndex = 3;
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(47)))), ((int)(((byte)(70)))));
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.txtPassword.Location = new System.Drawing.Point(115, 12);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Size = new System.Drawing.Size(185, 18);
            this.txtPassword.TabIndex = 9;
            // 
            // lblPasswordIcon
            // 
            this.lblPasswordIcon.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPasswordIcon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(115)))), ((int)(((byte)(148)))));
            this.lblPasswordIcon.Location = new System.Drawing.Point(10, 10);
            this.lblPasswordIcon.Name = "lblPasswordIcon";
            this.lblPasswordIcon.Size = new System.Drawing.Size(22, 22);
            this.lblPasswordIcon.TabIndex = 0;
            this.lblPasswordIcon.Text = "🔒";
            this.lblPasswordIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPassword
            // 
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblPassword.Location = new System.Drawing.Point(32, 12);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(80, 18);
            this.lblPassword.TabIndex = 1;
            this.lblPassword.Text = "Password";
            // 
            // pnlUsername
            // 
            this.pnlUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(47)))), ((int)(((byte)(70)))));
            this.pnlUsername.Controls.Add(this.txtUsername);
            this.pnlUsername.Controls.Add(this.lblUsernameIcon);
            this.pnlUsername.Controls.Add(this.lblUsername);
            this.pnlUsername.Location = new System.Drawing.Point(0, 93);
            this.pnlUsername.Name = "pnlUsername";
            this.pnlUsername.Size = new System.Drawing.Size(310, 42);
            this.pnlUsername.TabIndex = 2;
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(47)))), ((int)(((byte)(70)))));
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.txtUsername.Location = new System.Drawing.Point(115, 12);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(185, 18);
            this.txtUsername.TabIndex = 8;
            // 
            // lblUsernameIcon
            // 
            this.lblUsernameIcon.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblUsernameIcon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(115)))), ((int)(((byte)(148)))));
            this.lblUsernameIcon.Location = new System.Drawing.Point(10, 10);
            this.lblUsernameIcon.Name = "lblUsernameIcon";
            this.lblUsernameIcon.Size = new System.Drawing.Size(22, 22);
            this.lblUsernameIcon.TabIndex = 0;
            this.lblUsernameIcon.Text = "👤";
            this.lblUsernameIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUsername
            // 
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblUsername.Location = new System.Drawing.Point(32, 12);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(80, 18);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "Username";
            // 
            // pnlBirthDate
            // 
            this.pnlBirthDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(47)))), ((int)(((byte)(70)))));
            this.pnlBirthDate.Controls.Add(this.dtmBirthDate);
            this.pnlBirthDate.Controls.Add(this.lblBirthDateIcon);
            this.pnlBirthDate.Controls.Add(this.lblBirthDate);
            this.pnlBirthDate.Location = new System.Drawing.Point(0, 45);
            this.pnlBirthDate.Name = "pnlBirthDate";
            this.pnlBirthDate.Size = new System.Drawing.Size(310, 42);
            this.pnlBirthDate.TabIndex = 1;
            // 
            // dtmBirthDate
            // 
            this.dtmBirthDate.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.dtmBirthDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtmBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtmBirthDate.Location = new System.Drawing.Point(115, 10);
            this.dtmBirthDate.Name = "dtmBirthDate";
            this.dtmBirthDate.Size = new System.Drawing.Size(185, 23);
            this.dtmBirthDate.TabIndex = 7;
            // 
            // lblBirthDateIcon
            // 
            this.lblBirthDateIcon.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblBirthDateIcon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(115)))), ((int)(((byte)(148)))));
            this.lblBirthDateIcon.Location = new System.Drawing.Point(10, 10);
            this.lblBirthDateIcon.Name = "lblBirthDateIcon";
            this.lblBirthDateIcon.Size = new System.Drawing.Size(22, 22);
            this.lblBirthDateIcon.TabIndex = 0;
            this.lblBirthDateIcon.Text = "📅";
            this.lblBirthDateIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBirthDate
            // 
            this.lblBirthDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblBirthDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblBirthDate.Location = new System.Drawing.Point(32, 12);
            this.lblBirthDate.Name = "lblBirthDate";
            this.lblBirthDate.Size = new System.Drawing.Size(80, 18);
            this.lblBirthDate.TabIndex = 1;
            this.lblBirthDate.Text = "Birth Date";
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lblLeftSection);
            this.pnlLeft.Controls.Add(this.pnlPhone);
            this.pnlLeft.Controls.Add(this.pnlEmail);
            this.pnlLeft.Controls.Add(this.pnlAddress);
            this.pnlLeft.Controls.Add(this.pnlLastName);
            this.pnlLeft.Controls.Add(this.pnlFirstName);
            this.pnlLeft.Location = new System.Drawing.Point(30, 130);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(310, 335);
            this.pnlLeft.TabIndex = 4;
            // 
            // lblLeftSection
            // 
            this.lblLeftSection.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblLeftSection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblLeftSection.Location = new System.Drawing.Point(0, 0);
            this.lblLeftSection.Name = "lblLeftSection";
            this.lblLeftSection.Size = new System.Drawing.Size(310, 25);
            this.lblLeftSection.TabIndex = 0;
            this.lblLeftSection.Text = "Personal Information";
            // 
            // pnlPhone
            // 
            this.pnlPhone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(47)))), ((int)(((byte)(70)))));
            this.pnlPhone.Controls.Add(this.txtPhone);
            this.pnlPhone.Controls.Add(this.lblPhoneIcon);
            this.pnlPhone.Controls.Add(this.lblPhone);
            this.pnlPhone.Location = new System.Drawing.Point(0, 237);
            this.pnlPhone.Name = "pnlPhone";
            this.pnlPhone.Size = new System.Drawing.Size(310, 42);
            this.pnlPhone.TabIndex = 5;
            // 
            // txtPhone
            // 
            this.txtPhone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(47)))), ((int)(((byte)(70)))));
            this.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPhone.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPhone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.txtPhone.Location = new System.Drawing.Point(115, 12);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(185, 18);
            this.txtPhone.TabIndex = 5;
            // 
            // lblPhoneIcon
            // 
            this.lblPhoneIcon.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPhoneIcon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(115)))), ((int)(((byte)(148)))));
            this.lblPhoneIcon.Location = new System.Drawing.Point(10, 10);
            this.lblPhoneIcon.Name = "lblPhoneIcon";
            this.lblPhoneIcon.Size = new System.Drawing.Size(22, 22);
            this.lblPhoneIcon.TabIndex = 0;
            this.lblPhoneIcon.Text = "📞";
            this.lblPhoneIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPhone
            // 
            this.lblPhone.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPhone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblPhone.Location = new System.Drawing.Point(32, 12);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(80, 18);
            this.lblPhone.TabIndex = 1;
            this.lblPhone.Text = "Phone";
            // 
            // pnlEmail
            // 
            this.pnlEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(47)))), ((int)(((byte)(70)))));
            this.pnlEmail.Controls.Add(this.txtEmail);
            this.pnlEmail.Controls.Add(this.lblEmailIcon);
            this.pnlEmail.Controls.Add(this.lblEmail);
            this.pnlEmail.Location = new System.Drawing.Point(0, 189);
            this.pnlEmail.Name = "pnlEmail";
            this.pnlEmail.Size = new System.Drawing.Size(310, 42);
            this.pnlEmail.TabIndex = 4;
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(47)))), ((int)(((byte)(70)))));
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.txtEmail.Location = new System.Drawing.Point(115, 12);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(185, 18);
            this.txtEmail.TabIndex = 4;
            // 
            // lblEmailIcon
            // 
            this.lblEmailIcon.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblEmailIcon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(115)))), ((int)(((byte)(148)))));
            this.lblEmailIcon.Location = new System.Drawing.Point(10, 10);
            this.lblEmailIcon.Name = "lblEmailIcon";
            this.lblEmailIcon.Size = new System.Drawing.Size(22, 22);
            this.lblEmailIcon.TabIndex = 0;
            this.lblEmailIcon.Text = "✉";
            this.lblEmailIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEmail
            // 
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblEmail.Location = new System.Drawing.Point(32, 12);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(80, 18);
            this.lblEmail.TabIndex = 1;
            this.lblEmail.Text = "Email";
            // 
            // pnlAddress
            // 
            this.pnlAddress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(47)))), ((int)(((byte)(70)))));
            this.pnlAddress.Controls.Add(this.txtAddress);
            this.pnlAddress.Controls.Add(this.lblAddressIcon);
            this.pnlAddress.Controls.Add(this.lblAddress);
            this.pnlAddress.Location = new System.Drawing.Point(0, 141);
            this.pnlAddress.Name = "pnlAddress";
            this.pnlAddress.Size = new System.Drawing.Size(310, 42);
            this.pnlAddress.TabIndex = 3;
            // 
            // txtAddress
            // 
            this.txtAddress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(47)))), ((int)(((byte)(70)))));
            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAddress.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.txtAddress.Location = new System.Drawing.Point(115, 12);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(185, 18);
            this.txtAddress.TabIndex = 3;
            // 
            // lblAddressIcon
            // 
            this.lblAddressIcon.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblAddressIcon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(115)))), ((int)(((byte)(148)))));
            this.lblAddressIcon.Location = new System.Drawing.Point(10, 10);
            this.lblAddressIcon.Name = "lblAddressIcon";
            this.lblAddressIcon.Size = new System.Drawing.Size(22, 22);
            this.lblAddressIcon.TabIndex = 0;
            this.lblAddressIcon.Text = "📍";
            this.lblAddressIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAddress
            // 
            this.lblAddress.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblAddress.Location = new System.Drawing.Point(32, 12);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(80, 18);
            this.lblAddress.TabIndex = 1;
            this.lblAddress.Text = "Address";
            // 
            // pnlLastName
            // 
            this.pnlLastName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(47)))), ((int)(((byte)(70)))));
            this.pnlLastName.Controls.Add(this.txtLastName);
            this.pnlLastName.Controls.Add(this.lblLastNameIcon);
            this.pnlLastName.Controls.Add(this.lblLastName);
            this.pnlLastName.Location = new System.Drawing.Point(0, 93);
            this.pnlLastName.Name = "pnlLastName";
            this.pnlLastName.Size = new System.Drawing.Size(310, 42);
            this.pnlLastName.TabIndex = 2;
            // 
            // txtLastName
            // 
            this.txtLastName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(47)))), ((int)(((byte)(70)))));
            this.txtLastName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLastName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtLastName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.txtLastName.Location = new System.Drawing.Point(115, 12);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(185, 18);
            this.txtLastName.TabIndex = 2;
            // 
            // lblLastNameIcon
            // 
            this.lblLastNameIcon.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblLastNameIcon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(115)))), ((int)(((byte)(148)))));
            this.lblLastNameIcon.Location = new System.Drawing.Point(10, 10);
            this.lblLastNameIcon.Name = "lblLastNameIcon";
            this.lblLastNameIcon.Size = new System.Drawing.Size(22, 22);
            this.lblLastNameIcon.TabIndex = 0;
            this.lblLastNameIcon.Text = "👥";
            this.lblLastNameIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLastName
            // 
            this.lblLastName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblLastName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblLastName.Location = new System.Drawing.Point(32, 12);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(80, 18);
            this.lblLastName.TabIndex = 1;
            this.lblLastName.Text = "Last Name";
            // 
            // pnlFirstName
            // 
            this.pnlFirstName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(47)))), ((int)(((byte)(70)))));
            this.pnlFirstName.Controls.Add(this.txtFirstName);
            this.pnlFirstName.Controls.Add(this.lblFirstNameIcon);
            this.pnlFirstName.Controls.Add(this.lblFirstName);
            this.pnlFirstName.Location = new System.Drawing.Point(0, 45);
            this.pnlFirstName.Name = "pnlFirstName";
            this.pnlFirstName.Size = new System.Drawing.Size(310, 42);
            this.pnlFirstName.TabIndex = 1;
            // 
            // txtFirstName
            // 
            this.txtFirstName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(47)))), ((int)(((byte)(70)))));
            this.txtFirstName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFirstName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtFirstName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.txtFirstName.Location = new System.Drawing.Point(115, 12);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(185, 18);
            this.txtFirstName.TabIndex = 1;
            // 
            // lblFirstNameIcon
            // 
            this.lblFirstNameIcon.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblFirstNameIcon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(115)))), ((int)(((byte)(148)))));
            this.lblFirstNameIcon.Location = new System.Drawing.Point(10, 10);
            this.lblFirstNameIcon.Name = "lblFirstNameIcon";
            this.lblFirstNameIcon.Size = new System.Drawing.Size(22, 22);
            this.lblFirstNameIcon.TabIndex = 0;
            this.lblFirstNameIcon.Text = "👤";
            this.lblFirstNameIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFirstName
            // 
            this.lblFirstName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblFirstName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblFirstName.Location = new System.Drawing.Point(32, 12);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(80, 18);
            this.lblFirstName.TabIndex = 1;
            this.lblFirstName.Text = "First Name";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(115)))), ((int)(((byte)(148)))));
            this.lblSubtitle.Location = new System.Drawing.Point(30, 95);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(640, 25);
            this.lblSubtitle.TabIndex = 2;
            this.lblSubtitle.Text = "Create a new user account for the system";
            this.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.lblTitle.Location = new System.Drawing.Point(30, 55);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(640, 40);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "User Registration";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlLogo
            // 
            this.pnlLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.pnlLogo.Controls.Add(this.lblLogoText);
            this.pnlLogo.Location = new System.Drawing.Point(310, 10);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(80, 40);
            this.pnlLogo.TabIndex = 0;
            // 
            // lblLogoText
            // 
            this.lblLogoText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLogoText.Font = new System.Drawing.Font("Segoe UI Black", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblLogoText.ForeColor = System.Drawing.Color.White;
            this.lblLogoText.Location = new System.Drawing.Point(0, 0);
            this.lblLogoText.Name = "lblLogoText";
            this.lblLogoText.Size = new System.Drawing.Size(80, 40);
            this.lblLogoText.TabIndex = 0;
            this.lblLogoText.Text = "V+";
            this.lblLogoText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UserRegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(24)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.pnlMain);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "UserRegisterForm";
            this.Text = "Vormas - User Registration";
            this.pnlMain.ResumeLayout(false);
            this.pnlRegisterCard.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.pnlIsActive.ResumeLayout(false);
            this.pnlRole.ResumeLayout(false);
            this.pnlVerifyPassword.ResumeLayout(false);
            this.pnlVerifyPassword.PerformLayout();
            this.pnlPassword.ResumeLayout(false);
            this.pnlPassword.PerformLayout();
            this.pnlUsername.ResumeLayout(false);
            this.pnlUsername.PerformLayout();
            this.pnlBirthDate.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            this.pnlPhone.ResumeLayout(false);
            this.pnlPhone.PerformLayout();
            this.pnlEmail.ResumeLayout(false);
            this.pnlEmail.PerformLayout();
            this.pnlAddress.ResumeLayout(false);
            this.pnlAddress.PerformLayout();
            this.pnlLastName.ResumeLayout(false);
            this.pnlLastName.PerformLayout();
            this.pnlFirstName.ResumeLayout(false);
            this.pnlFirstName.PerformLayout();
            this.pnlLogo.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlRegisterCard;
        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.Label lblLogoText;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Label lblLeftSection;
        private System.Windows.Forms.Panel pnlFirstName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblFirstNameIcon;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Panel pnlLastName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblLastNameIcon;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Panel pnlAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblAddressIcon;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Panel pnlEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmailIcon;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Panel pnlPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblPhoneIcon;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Label lblRightSection;
        private System.Windows.Forms.Panel pnlBirthDate;
        private System.Windows.Forms.DateTimePicker dtmBirthDate;
        private System.Windows.Forms.Label lblBirthDateIcon;
        private System.Windows.Forms.Label lblBirthDate;
        private System.Windows.Forms.Panel pnlUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblUsernameIcon;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Panel pnlPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPasswordIcon;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Panel pnlVerifyPassword;
        private System.Windows.Forms.TextBox txtVerifyPassword;
        private System.Windows.Forms.Label lblVerifyPasswordIcon;
        private System.Windows.Forms.Label lblVerifyPassword;
        private System.Windows.Forms.Panel pnlRole;
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.Label lblRoleIcon;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Panel pnlIsActive;
        private System.Windows.Forms.ComboBox cmbIsActive;
        private System.Windows.Forms.Label lblIsActiveIcon;
        private System.Windows.Forms.Label lblIsActive;
        private System.Windows.Forms.Button btnRegister;
    }
}