using System.ComponentModel;

namespace Vormas.Forms
{
    partial class RateConfigurationForm
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
            this.dgvRateConfigs = new System.Windows.Forms.DataGridView();
            this.dtpEffectiveFrom = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.txtHourlyRate = new System.Windows.Forms.TextBox();
            this.pnlInputs = new System.Windows.Forms.Panel();
            this.dtpEffectiveTo = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMonthlyRate = new System.Windows.Forms.TextBox();
            this.txtWeeklyRate = new System.Windows.Forms.TextBox();
            this.txtDailyRate = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRateConfigs)).BeginInit();
            this.pnlInputs.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvRateConfigs
            // 
            this.dgvRateConfigs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRateConfigs.Dock = System.Windows.Forms.DockStyle.Right;
            this.dgvRateConfigs.Location = new System.Drawing.Point(575, 60);
            this.dgvRateConfigs.Name = "dgvRateConfigs";
            this.dgvRateConfigs.Size = new System.Drawing.Size(758, 735);
            this.dgvRateConfigs.TabIndex = 8;
            this.dgvRateConfigs.SelectionChanged += new System.EventHandler(this.dgvRateConfigs_SelectionChanged);
            // 
            // dtpEffectiveFrom
            // 
            this.dtpEffectiveFrom.Location = new System.Drawing.Point(207, 270);
            this.dtpEffectiveFrom.Name = "dtpEffectiveFrom";
            this.dtpEffectiveFrom.Size = new System.Drawing.Size(214, 20);
            this.dtpEffectiveFrom.TabIndex = 53;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(101, 267);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(100, 23);
            this.label12.TabIndex = 52;
            this.label12.Text = "Effective From:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtHourlyRate
            // 
            this.txtHourlyRate.Location = new System.Drawing.Point(206, 233);
            this.txtHourlyRate.Name = "txtHourlyRate";
            this.txtHourlyRate.Size = new System.Drawing.Size(214, 20);
            this.txtHourlyRate.TabIndex = 48;
            // 
            // pnlInputs
            // 
            this.pnlInputs.AutoScroll = true;
            this.pnlInputs.Controls.Add(this.dtpEffectiveTo);
            this.pnlInputs.Controls.Add(this.label3);
            this.pnlInputs.Controls.Add(this.cmbCategory);
            this.pnlInputs.Controls.Add(this.dtpEffectiveFrom);
            this.pnlInputs.Controls.Add(this.label12);
            this.pnlInputs.Controls.Add(this.txtHourlyRate);
            this.pnlInputs.Controls.Add(this.label2);
            this.pnlInputs.Controls.Add(this.txtMonthlyRate);
            this.pnlInputs.Controls.Add(this.txtWeeklyRate);
            this.pnlInputs.Controls.Add(this.txtDailyRate);
            this.pnlInputs.Controls.Add(this.label5);
            this.pnlInputs.Controls.Add(this.label4);
            this.pnlInputs.Controls.Add(this.label1);
            this.pnlInputs.Controls.Add(this.label6);
            this.pnlInputs.Controls.Add(this.btnClear);
            this.pnlInputs.Controls.Add(this.btnDelete);
            this.pnlInputs.Controls.Add(this.btnSave);
            this.pnlInputs.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlInputs.Location = new System.Drawing.Point(0, 60);
            this.pnlInputs.Name = "pnlInputs";
            this.pnlInputs.Size = new System.Drawing.Size(531, 735);
            this.pnlInputs.TabIndex = 7;
            // 
            // dtpEffectiveTo
            // 
            this.dtpEffectiveTo.Location = new System.Drawing.Point(207, 308);
            this.dtpEffectiveTo.Name = "dtpEffectiveTo";
            this.dtpEffectiveTo.Size = new System.Drawing.Size(214, 20);
            this.dtpEffectiveTo.TabIndex = 56;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(101, 305);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 55;
            this.label3.Text = "Effective To:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbCategory
            // 
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Items.AddRange(new object[] { "1", "2" });
            this.cmbCategory.Location = new System.Drawing.Point(206, 92);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(214, 21);
            this.cmbCategory.TabIndex = 54;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(100, 228);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 42;
            this.label2.Text = "Hourly Rate:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMonthlyRate
            // 
            this.txtMonthlyRate.Location = new System.Drawing.Point(206, 194);
            this.txtMonthlyRate.Name = "txtMonthlyRate";
            this.txtMonthlyRate.Size = new System.Drawing.Size(214, 20);
            this.txtMonthlyRate.TabIndex = 41;
            // 
            // txtWeeklyRate
            // 
            this.txtWeeklyRate.Location = new System.Drawing.Point(206, 160);
            this.txtWeeklyRate.Name = "txtWeeklyRate";
            this.txtWeeklyRate.Size = new System.Drawing.Size(214, 20);
            this.txtWeeklyRate.TabIndex = 40;
            // 
            // txtDailyRate
            // 
            this.txtDailyRate.Location = new System.Drawing.Point(206, 126);
            this.txtDailyRate.Name = "txtDailyRate";
            this.txtDailyRate.Size = new System.Drawing.Size(214, 20);
            this.txtDailyRate.TabIndex = 38;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(100, 192);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 36;
            this.label5.Text = "Monthly Rate:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(100, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 35;
            this.label4.Text = "Weekly Rate:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(100, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 33;
            this.label1.Text = "Daily Rate:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(100, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 23);
            this.label6.TabIndex = 32;
            this.label6.Text = "Category:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(334, 395);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 30);
            this.btnClear.TabIndex = 27;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.IndianRed;
            this.btnDelete.Location = new System.Drawing.Point(224, 395);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 30);
            this.btnDelete.TabIndex = 26;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSave.Location = new System.Drawing.Point(114, 395);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 30);
            this.btnSave.TabIndex = 25;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.label11);
            this.pnlTop.Controls.Add(this.btnSearch);
            this.pnlTop.Controls.Add(this.txtSearch);
            this.pnlTop.Controls.Add(this.lblSearch);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1333, 60);
            this.pnlTop.TabIndex = 6;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 13);
            this.label11.TabIndex = 3;
            this.label11.Text = "Search:";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(340, 18);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click_1);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(60, 20);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(260, 20);
            this.txtSearch.TabIndex = 1;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(10, 23);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(0, 13);
            this.lblSearch.TabIndex = 0;
            // 
            // RateConfigurationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvRateConfigs);
            this.Controls.Add(this.pnlInputs);
            this.Controls.Add(this.pnlTop);
            this.Name = "RateConfigurationForm";
            this.Size = new System.Drawing.Size(1333, 795);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRateConfigs)).EndInit();
            this.pnlInputs.ResumeLayout(false);
            this.pnlInputs.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DateTimePicker dtpEffectiveTo;
        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.ComboBox cmbCategory;

        private System.Windows.Forms.DataGridView dgvRateConfigs;
        private System.Windows.Forms.DateTimePicker dtpEffectiveFrom;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtHourlyRate;
        private System.Windows.Forms.Panel pnlInputs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMonthlyRate;
        private System.Windows.Forms.TextBox txtWeeklyRate;
        private System.Windows.Forms.TextBox txtDailyRate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;

        #endregion
    }
}