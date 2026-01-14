using System.ComponentModel;

namespace Vormas.Forms
{
    partial class AdminDashboard
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
            this.pnlWebView = new System.Windows.Forms.Panel();
            this.pnlWinForms = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            
            this.pnlWebView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlWebView.Location = new System.Drawing.Point(0, 0);
            this.pnlWebView.Name = "pnlWebView";
            this.pnlWebView.Size = new System.Drawing.Size(1183, 633);
            this.pnlWebView.TabIndex = 0;
            
            this.pnlWinForms.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlWinForms.Location = new System.Drawing.Point(0, 56);
            this.pnlWinForms.Name = "pnlWinForms";
            this.pnlWinForms.Size = new System.Drawing.Size(1183, 577);
            this.pnlWinForms.TabIndex = 1;
            this.pnlWinForms.Visible = false;
            
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlWinForms);
            this.Controls.Add(this.pnlWebView);
            this.Name = "AdminDashboard";
            this.Size = new System.Drawing.Size(1183, 633);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlWebView;
        private System.Windows.Forms.Panel pnlWinForms;

        #endregion
    }
}