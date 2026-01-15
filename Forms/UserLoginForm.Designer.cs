using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Vormas.Forms
{
    partial class UserLoginForm
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
            this.pnlLoginCard = new System.Windows.Forms.Panel();
            this.lblForgotPassword = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.pnlPassword = new System.Windows.Forms.Panel();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPasswordIcon = new System.Windows.Forms.Label();
            this.pnlUsername = new System.Windows.Forms.Panel();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblUserIcon = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.lblLogoText = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.pnlLoginCard.SuspendLayout();
            this.pnlPassword.SuspendLayout();
            this.pnlUsername.SuspendLayout();
            this.pnlLogo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(24)))), ((int)(((byte)(38)))));
            this.pnlMain.Controls.Add(this.pnlLoginCard);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(800, 500);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlLoginCard
            // 
            this.pnlLoginCard.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlLoginCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(35)))), ((int)(((byte)(53)))));
            this.pnlLoginCard.Controls.Add(this.lblForgotPassword);
            this.pnlLoginCard.Controls.Add(this.btnLogin);
            this.pnlLoginCard.Controls.Add(this.pnlPassword);
            this.pnlLoginCard.Controls.Add(this.pnlUsername);
            this.pnlLoginCard.Controls.Add(this.lblSubtitle);
            this.pnlLoginCard.Controls.Add(this.lblTitle);
            this.pnlLoginCard.Controls.Add(this.pnlLogo);
            this.pnlLoginCard.Location = new System.Drawing.Point(200, 50);
            this.pnlLoginCard.Name = "pnlLoginCard";
            this.pnlLoginCard.Padding = new System.Windows.Forms.Padding(40);
            this.pnlLoginCard.Size = new System.Drawing.Size(400, 400);
            this.pnlLoginCard.TabIndex = 0;
            // 
            // lblForgotPassword
            // 
            this.lblForgotPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblForgotPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblForgotPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(115)))), ((int)(((byte)(148)))));
            this.lblForgotPassword.Location = new System.Drawing.Point(40, 355);
            this.lblForgotPassword.Name = "lblForgotPassword";
            this.lblForgotPassword.Size = new System.Drawing.Size(320, 20);
            this.lblForgotPassword.TabIndex = 6;
            this.lblForgotPassword.Text = "Forgot your password? Contact your administrator.";
            this.lblForgotPassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(165)))), ((int)(((byte)(250)))));
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(40, 295);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(320, 48);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Sign In";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // pnlPassword
            // 
            this.pnlPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(47)))), ((int)(((byte)(70)))));
            this.pnlPassword.Controls.Add(this.txtPassword);
            this.pnlPassword.Controls.Add(this.lblPasswordIcon);
            this.pnlPassword.Location = new System.Drawing.Point(40, 230);
            this.pnlPassword.Name = "pnlPassword";
            this.pnlPassword.Padding = new System.Windows.Forms.Padding(15, 0, 15, 0);
            this.pnlPassword.Size = new System.Drawing.Size(320, 48);
            this.pnlPassword.TabIndex = 2;
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(47)))), ((int)(((byte)(70)))));
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.txtPassword.Location = new System.Drawing.Point(50, 14);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Size = new System.Drawing.Size(255, 20);
            this.txtPassword.TabIndex = 1;
            // 
            // lblPasswordIcon
            // 
            this.lblPasswordIcon.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPasswordIcon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(115)))), ((int)(((byte)(148)))));
            this.lblPasswordIcon.Location = new System.Drawing.Point(15, 12);
            this.lblPasswordIcon.Name = "lblPasswordIcon";
            this.lblPasswordIcon.Size = new System.Drawing.Size(30, 24);
            this.lblPasswordIcon.TabIndex = 0;
            this.lblPasswordIcon.Text = "🔒";
            this.lblPasswordIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlUsername
            // 
            this.pnlUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(47)))), ((int)(((byte)(70)))));
            this.pnlUsername.Controls.Add(this.txtUsername);
            this.pnlUsername.Controls.Add(this.lblUserIcon);
            this.pnlUsername.Location = new System.Drawing.Point(40, 170);
            this.pnlUsername.Name = "pnlUsername";
            this.pnlUsername.Padding = new System.Windows.Forms.Padding(15, 0, 15, 0);
            this.pnlUsername.Size = new System.Drawing.Size(320, 48);
            this.pnlUsername.TabIndex = 1;
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(47)))), ((int)(((byte)(70)))));
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.txtUsername.Location = new System.Drawing.Point(50, 14);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(255, 20);
            this.txtUsername.TabIndex = 1;
            // 
            // lblUserIcon
            // 
            this.lblUserIcon.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblUserIcon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(115)))), ((int)(((byte)(148)))));
            this.lblUserIcon.Location = new System.Drawing.Point(15, 12);
            this.lblUserIcon.Name = "lblUserIcon";
            this.lblUserIcon.Size = new System.Drawing.Size(30, 24);
            this.lblUserIcon.TabIndex = 0;
            this.lblUserIcon.Text = "👤";
            this.lblUserIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(115)))), ((int)(((byte)(148)))));
            this.lblSubtitle.Location = new System.Drawing.Point(40, 130);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(320, 25);
            this.lblSubtitle.TabIndex = 2;
            this.lblSubtitle.Text = "Sign in to access your dashboard";
            this.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.lblTitle.Location = new System.Drawing.Point(40, 95);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(320, 35);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Welcome Back";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlLogo
            // 
            this.pnlLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.pnlLogo.Controls.Add(this.lblLogoText);
            this.pnlLogo.Location = new System.Drawing.Point(160, 30);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(80, 50);
            this.pnlLogo.TabIndex = 0;
            // 
            // lblLogoText
            // 
            this.lblLogoText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLogoText.Font = new System.Drawing.Font("Segoe UI Black", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblLogoText.ForeColor = System.Drawing.Color.White;
            this.lblLogoText.Location = new System.Drawing.Point(0, 0);
            this.lblLogoText.Name = "lblLogoText";
            this.lblLogoText.Size = new System.Drawing.Size(80, 50);
            this.lblLogoText.TabIndex = 0;
            this.lblLogoText.Text = "V";
            this.lblLogoText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UserLoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(24)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.pnlMain);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "UserLoginForm";
            this.Text = "Vormas - Sign In";
            this.pnlMain.ResumeLayout(false);
            this.pnlLoginCard.ResumeLayout(false);
            this.pnlPassword.ResumeLayout(false);
            this.pnlPassword.PerformLayout();
            this.pnlUsername.ResumeLayout(false);
            this.pnlUsername.PerformLayout();
            this.pnlLogo.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlLoginCard;
        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.Label lblLogoText;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel pnlUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblUserIcon;
        private System.Windows.Forms.Panel pnlPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPasswordIcon;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblForgotPassword;
    }
}