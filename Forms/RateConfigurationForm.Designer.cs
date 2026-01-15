namespace Vormas.Forms
{
    partial class RateConfigurationForm
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.grpValidity = new System.Windows.Forms.GroupBox();
            this.dtpEffectiveTo = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpEffectiveFrom = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.grpPricing = new System.Windows.Forms.GroupBox();
            this.txtHourlyRate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMonthlyRate = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtWeeklyRate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDailyRate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpCategory = new System.Windows.Forms.GroupBox();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pnlActions = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.dgvRateConfigs = new System.Windows.Forms.DataGridView();
            this.pnlLeft.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.grpValidity.SuspendLayout();
            this.grpPricing.SuspendLayout();
            this.grpCategory.SuspendLayout();
            this.pnlActions.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRateConfigs)).BeginInit();
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
            this.pnlContent.Controls.Add(this.grpValidity);
            this.pnlContent.Controls.Add(this.grpPricing);
            this.pnlContent.Controls.Add(this.grpCategory);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(15, 65);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(320, 655);
            this.pnlContent.TabIndex = 1;
            // 
            // grpValidity
            // 
            this.grpValidity.Controls.Add(this.dtpEffectiveTo);
            this.grpValidity.Controls.Add(this.label3);
            this.grpValidity.Controls.Add(this.dtpEffectiveFrom);
            this.grpValidity.Controls.Add(this.label12);
            this.grpValidity.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpValidity.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpValidity.Location = new System.Drawing.Point(0, 245);
            this.grpValidity.Name = "grpValidity";
            this.grpValidity.Size = new System.Drawing.Size(320, 100);
            this.grpValidity.TabIndex = 2;
            this.grpValidity.TabStop = false;
            this.grpValidity.Text = "Validity Period";
            // 
            // dtpEffectiveTo
            // 
            this.dtpEffectiveTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpEffectiveTo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpEffectiveTo.Location = new System.Drawing.Point(110, 60);
            this.dtpEffectiveTo.Name = "dtpEffectiveTo";
            this.dtpEffectiveTo.Size = new System.Drawing.Size(190, 23);
            this.dtpEffectiveTo.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label3.Location = new System.Drawing.Point(10, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Effective To:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpEffectiveFrom
            // 
            this.dtpEffectiveFrom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpEffectiveFrom.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpEffectiveFrom.Location = new System.Drawing.Point(110, 25);
            this.dtpEffectiveFrom.Name = "dtpEffectiveFrom";
            this.dtpEffectiveFrom.Size = new System.Drawing.Size(190, 23);
            this.dtpEffectiveFrom.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label12.Location = new System.Drawing.Point(10, 25);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(95, 23);
            this.label12.TabIndex = 0;
            this.label12.Text = "Effective From:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpPricing
            // 
            this.grpPricing.Controls.Add(this.txtHourlyRate);
            this.grpPricing.Controls.Add(this.label2);
            this.grpPricing.Controls.Add(this.txtMonthlyRate);
            this.grpPricing.Controls.Add(this.label5);
            this.grpPricing.Controls.Add(this.txtWeeklyRate);
            this.grpPricing.Controls.Add(this.label4);
            this.grpPricing.Controls.Add(this.txtDailyRate);
            this.grpPricing.Controls.Add(this.label1);
            this.grpPricing.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpPricing.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpPricing.Location = new System.Drawing.Point(0, 75);
            this.grpPricing.Name = "grpPricing";
            this.grpPricing.Size = new System.Drawing.Size(320, 170);
            this.grpPricing.TabIndex = 1;
            this.grpPricing.TabStop = false;
            this.grpPricing.Text = "Pricing Rates";
            // 
            // txtHourlyRate
            // 
            this.txtHourlyRate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHourlyRate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtHourlyRate.Location = new System.Drawing.Point(110, 130);
            this.txtHourlyRate.Name = "txtHourlyRate";
            this.txtHourlyRate.Size = new System.Drawing.Size(190, 23);
            this.txtHourlyRate.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label2.Location = new System.Drawing.Point(10, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "Hourly Rate:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMonthlyRate
            // 
            this.txtMonthlyRate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMonthlyRate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMonthlyRate.Location = new System.Drawing.Point(110, 95);
            this.txtMonthlyRate.Name = "txtMonthlyRate";
            this.txtMonthlyRate.Size = new System.Drawing.Size(190, 23);
            this.txtMonthlyRate.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label5.Location = new System.Drawing.Point(10, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 23);
            this.label5.TabIndex = 4;
            this.label5.Text = "Monthly Rate:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtWeeklyRate
            // 
            this.txtWeeklyRate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWeeklyRate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtWeeklyRate.Location = new System.Drawing.Point(110, 60);
            this.txtWeeklyRate.Name = "txtWeeklyRate";
            this.txtWeeklyRate.Size = new System.Drawing.Size(190, 23);
            this.txtWeeklyRate.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label4.Location = new System.Drawing.Point(10, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 23);
            this.label4.TabIndex = 2;
            this.label4.Text = "Weekly Rate:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDailyRate
            // 
            this.txtDailyRate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDailyRate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDailyRate.Location = new System.Drawing.Point(110, 25);
            this.txtDailyRate.Name = "txtDailyRate";
            this.txtDailyRate.Size = new System.Drawing.Size(190, 23);
            this.txtDailyRate.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.Location = new System.Drawing.Point(10, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Daily Rate:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpCategory
            // 
            this.grpCategory.Controls.Add(this.cmbCategory);
            this.grpCategory.Controls.Add(this.label6);
            this.grpCategory.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpCategory.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpCategory.Location = new System.Drawing.Point(0, 0);
            this.grpCategory.Name = "grpCategory";
            this.grpCategory.Size = new System.Drawing.Size(320, 75);
            this.grpCategory.TabIndex = 0;
            this.grpCategory.TabStop = false;
            this.grpCategory.Text = "Category Selection";
            // 
            // cmbCategory
            // 
            this.cmbCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCategory.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(110, 25);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(190, 23);
            this.cmbCategory.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label6.Location = new System.Drawing.Point(10, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 23);
            this.label6.TabIndex = 0;
            this.label6.Text = "Category:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlActions
            // 
            this.pnlActions.Controls.Add(this.btnClear);
            this.pnlActions.Controls.Add(this.btnDelete);
            this.pnlActions.Controls.Add(this.btnSave);
            this.pnlActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlActions.Location = new System.Drawing.Point(15, 720);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Size = new System.Drawing.Size(320, 60);
            this.pnlActions.TabIndex = 2;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(213, 15);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(90, 35);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.IndianRed;
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(111, 15);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(90, 35);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(10, 15);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 35);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.btnSearch);
            this.pnlSearch.Controls.Add(this.txtSearch);
            this.pnlSearch.Controls.Add(this.lblSearch);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Location = new System.Drawing.Point(15, 15);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(320, 50);
            this.pnlSearch.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(230, 10);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 25);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click_1);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(60, 12);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(160, 20);
            this.txtSearch.TabIndex = 1;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(10, 15);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(44, 13);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Search:";
            // 
            // dgvRateConfigs
            // 
            this.dgvRateConfigs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRateConfigs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRateConfigs.Location = new System.Drawing.Point(350, 0);
            this.dgvRateConfigs.Name = "dgvRateConfigs";
            this.dgvRateConfigs.Size = new System.Drawing.Size(983, 795);
            this.dgvRateConfigs.TabIndex = 1;
            this.dgvRateConfigs.SelectionChanged += new System.EventHandler(this.dgvRateConfigs_SelectionChanged);
            // 
            // RateConfigurationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvRateConfigs);
            this.Controls.Add(this.pnlLeft);
            this.Name = "RateConfigurationForm";
            this.Size = new System.Drawing.Size(1333, 795);
            this.pnlLeft.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.grpValidity.ResumeLayout(false);
            this.grpPricing.ResumeLayout(false);
            this.grpPricing.PerformLayout();
            this.grpCategory.ResumeLayout(false);
            this.pnlActions.ResumeLayout(false);
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRateConfigs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.GroupBox grpCategory;
        private System.Windows.Forms.GroupBox grpPricing;
        private System.Windows.Forms.GroupBox grpValidity;
        private System.Windows.Forms.Panel pnlActions;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.DataGridView dgvRateConfigs;
        
        // Control definitions
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDailyRate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtWeeklyRate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMonthlyRate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtHourlyRate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpEffectiveFrom;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dtpEffectiveTo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
    }
}