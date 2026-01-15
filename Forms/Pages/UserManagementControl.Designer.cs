using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Vormas.Forms.Pages
{
    partial class UserManagementControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.grpPermissions = new System.Windows.Forms.GroupBox();
            this.cmbIsActive = new System.Windows.Forms.ComboBox();
            this.cmbRole = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.grpCredentials = new System.Windows.Forms.GroupBox();
            this.txtVerifyPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.grpContact = new System.Windows.Forms.GroupBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.grpPersonal = new System.Windows.Forms.GroupBox();
            this.dtmBirthDate = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pnlActions = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.pnlLeft.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.grpPermissions.SuspendLayout();
            this.grpCredentials.SuspendLayout();
            this.grpContact.SuspendLayout();
            this.grpPersonal.SuspendLayout();
            this.pnlActions.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.SystemColors.Control;
            this.pnlLeft.Controls.Add(this.pnlContent);
            this.pnlLeft.Controls.Add(this.pnlActions);
            this.pnlLeft.Controls.Add(this.pnlSearch);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(15);
            this.pnlLeft.Size = new System.Drawing.Size(350, 795);
            this.pnlLeft.TabIndex = 0;
            // 
            // pnlContent
            // 
            this.pnlContent.AutoScroll = true;
            this.pnlContent.Controls.Add(this.grpPermissions);
            this.pnlContent.Controls.Add(this.grpCredentials);
            this.pnlContent.Controls.Add(this.grpContact);
            this.pnlContent.Controls.Add(this.grpPersonal);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(15, 75);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(320, 655);
            this.pnlContent.TabIndex = 2;
            // 
            // grpPermissions
            // 
            this.grpPermissions.Controls.Add(this.cmbIsActive);
            this.grpPermissions.Controls.Add(this.cmbRole);
            this.grpPermissions.Controls.Add(this.label10);
            this.grpPermissions.Controls.Add(this.label9);
            this.grpPermissions.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpPermissions.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpPermissions.Location = new System.Drawing.Point(0, 480);
            this.grpPermissions.Name = "grpPermissions";
            this.grpPermissions.Size = new System.Drawing.Size(320, 110);
            this.grpPermissions.TabIndex = 3;
            this.grpPermissions.TabStop = false;
            this.grpPermissions.Text = "Permissions";
            // 
            // cmbIsActive
            // 
            this.cmbIsActive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIsActive.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbIsActive.FormattingEnabled = true;
            this.cmbIsActive.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.cmbIsActive.Location = new System.Drawing.Point(100, 65);
            this.cmbIsActive.Name = "cmbIsActive";
            this.cmbIsActive.Size = new System.Drawing.Size(200, 23);
            this.cmbIsActive.TabIndex = 3;
            // 
            // cmbRole
            // 
            this.cmbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRole.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRole.FormattingEnabled = true;
            this.cmbRole.Location = new System.Drawing.Point(100, 25);
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.Size = new System.Drawing.Size(200, 23);
            this.cmbRole.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(5, 65);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(90, 23);
            this.label10.TabIndex = 2;
            this.label10.Text = "Is Active:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(5, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 23);
            this.label9.TabIndex = 0;
            this.label9.Text = "Role:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpCredentials
            // 
            this.grpCredentials.Controls.Add(this.txtVerifyPassword);
            this.grpCredentials.Controls.Add(this.txtUsername);
            this.grpCredentials.Controls.Add(this.txtPassword);
            this.grpCredentials.Controls.Add(this.label8);
            this.grpCredentials.Controls.Add(this.label7);
            this.grpCredentials.Controls.Add(this.label2);
            this.grpCredentials.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpCredentials.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpCredentials.Location = new System.Drawing.Point(0, 330);
            this.grpCredentials.Name = "grpCredentials";
            this.grpCredentials.Size = new System.Drawing.Size(320, 150);
            this.grpCredentials.TabIndex = 2;
            this.grpCredentials.TabStop = false;
            this.grpCredentials.Text = "Account Credentials";
            // 
            // txtVerifyPassword
            // 
            this.txtVerifyPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVerifyPassword.Location = new System.Drawing.Point(100, 105);
            this.txtVerifyPassword.Name = "txtVerifyPassword";
            this.txtVerifyPassword.PasswordChar = '●';
            this.txtVerifyPassword.Size = new System.Drawing.Size(200, 23);
            this.txtVerifyPassword.TabIndex = 5;
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(100, 25);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(200, 23);
            this.txtUsername.TabIndex = 1;
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(100, 65);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Size = new System.Drawing.Size(200, 23);
            this.txtPassword.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(5, 105);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 23);
            this.label8.TabIndex = 4;
            this.label8.Text = "Verify:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(5, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 23);
            this.label7.TabIndex = 2;
            this.label7.Text = "Password:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Username:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpContact
            // 
            this.grpContact.Controls.Add(this.txtPhone);
            this.grpContact.Controls.Add(this.txtEmail);
            this.grpContact.Controls.Add(this.label5);
            this.grpContact.Controls.Add(this.label4);
            this.grpContact.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpContact.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpContact.Location = new System.Drawing.Point(0, 220);
            this.grpContact.Name = "grpContact";
            this.grpContact.Size = new System.Drawing.Size(320, 110);
            this.grpContact.TabIndex = 1;
            this.grpContact.TabStop = false;
            this.grpContact.Text = "Contact Info";
            // 
            // txtPhone
            // 
            this.txtPhone.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhone.Location = new System.Drawing.Point(100, 65);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(200, 23);
            this.txtPhone.TabIndex = 3;
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(100, 25);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(200, 23);
            this.txtEmail.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(5, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 23);
            this.label5.TabIndex = 2;
            this.label5.Text = "Phone:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(5, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 23);
            this.label4.TabIndex = 0;
            this.label4.Text = "Email:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpPersonal
            // 
            this.grpPersonal.Controls.Add(this.dtmBirthDate);
            this.grpPersonal.Controls.Add(this.label12);
            this.grpPersonal.Controls.Add(this.txtLastName);
            this.grpPersonal.Controls.Add(this.txtFirstName);
            this.grpPersonal.Controls.Add(this.label1);
            this.grpPersonal.Controls.Add(this.label6);
            this.grpPersonal.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpPersonal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpPersonal.Location = new System.Drawing.Point(0, 0);
            this.grpPersonal.Name = "grpPersonal";
            this.grpPersonal.Size = new System.Drawing.Size(320, 220);
            this.grpPersonal.TabIndex = 0;
            this.grpPersonal.TabStop = false;
            this.grpPersonal.Text = "Personal Info";
            // 
            // dtmBirthDate
            // 
            this.dtmBirthDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtmBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtmBirthDate.Location = new System.Drawing.Point(100, 145);
            this.dtmBirthDate.Name = "dtmBirthDate";
            this.dtmBirthDate.Size = new System.Drawing.Size(200, 23);
            this.dtmBirthDate.TabIndex = 5;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(5, 145);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(90, 23);
            this.label12.TabIndex = 4;
            this.label12.Text = "Date of Birth:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtLastName
            // 
            this.txtLastName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLastName.Location = new System.Drawing.Point(100, 85);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(200, 23);
            this.txtLastName.TabIndex = 3;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFirstName.Location = new System.Drawing.Point(100, 35);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(200, 23);
            this.txtFirstName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Last Name:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(5, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 23);
            this.label6.TabIndex = 0;
            this.label6.Text = "First Name:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlActions
            // 
            this.pnlActions.Controls.Add(this.btnSave);
            this.pnlActions.Controls.Add(this.btnDelete);
            this.pnlActions.Controls.Add(this.btnClear);
            this.pnlActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlActions.Location = new System.Drawing.Point(15, 730);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Size = new System.Drawing.Size(320, 50);
            this.pnlActions.TabIndex = 3;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(10, 8);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 35);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.IndianRed;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(110, 8);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(90, 35);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(210, 8);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(90, 35);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.btnSearch);
            this.pnlSearch.Controls.Add(this.txtSearch);
            this.pnlSearch.Controls.Add(this.lblSearch);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Location = new System.Drawing.Point(15, 15);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(320, 60);
            this.pnlSearch.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(235, 18);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 25);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(60, 19);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(160, 23);
            this.txtSearch.TabIndex = 1;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(5, 23);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(45, 15);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Search:";
            // 
            // dgvUsers
            // 
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToDeleteRows = false;

            this.dgvUsers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUsers.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsers.Location = new System.Drawing.Point(350, 0);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsers.Size = new System.Drawing.Size(983, 795);
            this.dgvUsers.TabIndex = 1;
            this.dgvUsers.SelectionChanged += new System.EventHandler(this.dgvUsers_SelectionChanged);
            // 
            // UserManagementControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvUsers);
            this.Controls.Add(this.pnlLeft);
            this.Name = "UserManagementControl";
            this.Size = new System.Drawing.Size(1333, 795);
            this.pnlLeft.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.grpPermissions.ResumeLayout(false);
            this.grpCredentials.ResumeLayout(false);
            this.grpCredentials.PerformLayout();
            this.grpContact.ResumeLayout(false);
            this.grpContact.PerformLayout();
            this.grpPersonal.ResumeLayout(false);
            this.grpPersonal.PerformLayout();
            this.pnlActions.ResumeLayout(false);
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        
        private System.Windows.Forms.Panel pnlContent;
        
        private System.Windows.Forms.GroupBox grpPersonal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dtmBirthDate;

        private System.Windows.Forms.GroupBox grpContact;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label5;

        private System.Windows.Forms.GroupBox grpCredentials;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtVerifyPassword;

        private System.Windows.Forms.GroupBox grpPermissions;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbIsActive;

        private System.Windows.Forms.Panel pnlActions;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;

        private System.Windows.Forms.DataGridView dgvUsers;
    }
}