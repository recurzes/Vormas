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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1183, 56);
            this.pnlHeader.TabIndex = 0;
            
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 56);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1183, 577);
            this.pnlContent.TabIndex = 1;
            
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlHeader);
            this.Name = "AdminDashboard";
            this.Size = new System.Drawing.Size(1183, 633);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlContent;

        #endregion
    }
}