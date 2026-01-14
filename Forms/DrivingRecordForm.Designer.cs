using System.ComponentModel;

namespace Vormas.Forms
{
    partial class DrivingRecordForm
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

        private void InitializeComponent()
        {
            this.dgvRecords = new System.Windows.Forms.DataGridView();
            this.pnlAdd = new System.Windows.Forms.Panel();
            this.lblViolationDate = new System.Windows.Forms.Label();
            this.dtpViolationDate = new System.Windows.Forms.DateTimePicker();
            this.lblViolationType = new System.Windows.Forms.Label();
            this.cmbViolationType = new System.Windows.Forms.ComboBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblFineAmount = new System.Windows.Forms.Label();
            this.numFineAmount = new System.Windows.Forms.NumericUpDown();
            this.chkMajor = new System.Windows.Forms.CheckBox();
            this.lblAuthority = new System.Windows.Forms.Label();
            this.txtAuthority = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecords)).BeginInit();
            this.pnlAdd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFineAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRecords
            // 
            this.dgvRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecords.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvRecords.Location = new System.Drawing.Point(0, 0);
            this.dgvRecords.Name = "dgvRecords";
            this.dgvRecords.Size = new System.Drawing.Size(784, 250);
            this.dgvRecords.TabIndex = 0;
            // 
            // pnlAdd
            // 
            this.pnlAdd.Controls.Add(this.btnClose);
            this.pnlAdd.Controls.Add(this.btnAdd);
            this.pnlAdd.Controls.Add(this.txtAuthority);
            this.pnlAdd.Controls.Add(this.lblAuthority);
            this.pnlAdd.Controls.Add(this.chkMajor);
            this.pnlAdd.Controls.Add(this.numFineAmount);
            this.pnlAdd.Controls.Add(this.lblFineAmount);
            this.pnlAdd.Controls.Add(this.txtDescription);
            this.pnlAdd.Controls.Add(this.lblDescription);
            this.pnlAdd.Controls.Add(this.cmbViolationType);
            this.pnlAdd.Controls.Add(this.lblViolationType);
            this.pnlAdd.Controls.Add(this.dtpViolationDate);
            this.pnlAdd.Controls.Add(this.lblViolationDate);
            this.pnlAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAdd.Location = new System.Drawing.Point(0, 250);
            this.pnlAdd.Name = "pnlAdd";
            this.pnlAdd.Size = new System.Drawing.Size(784, 161);
            this.pnlAdd.TabIndex = 1;
            // 
            // lblViolationDate
            // 
            this.lblViolationDate.Location = new System.Drawing.Point(12, 15);
            this.lblViolationDate.Name = "lblViolationDate";
            this.lblViolationDate.Size = new System.Drawing.Size(80, 20);
            this.lblViolationDate.TabIndex = 0;
            this.lblViolationDate.Text = "Date:";
            // 
            // dtpViolationDate
            // 
            this.dtpViolationDate.Location = new System.Drawing.Point(100, 12);
            this.dtpViolationDate.Name = "dtpViolationDate";
            this.dtpViolationDate.Size = new System.Drawing.Size(150, 20);
            this.dtpViolationDate.TabIndex = 1;
            // 
            // lblViolationType
            // 
            this.lblViolationType.Location = new System.Drawing.Point(270, 15);
            this.lblViolationType.Name = "lblViolationType";
            this.lblViolationType.Size = new System.Drawing.Size(50, 20);
            this.lblViolationType.TabIndex = 2;
            this.lblViolationType.Text = "Type:";
            // 
            // cmbViolationType
            // 
            this.cmbViolationType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbViolationType.Items.AddRange(new object[] { "Speeding", "DUI", "Reckless", "Accident", "LicenseViolation", "Other" });
            this.cmbViolationType.Location = new System.Drawing.Point(320, 12);
            this.cmbViolationType.Name = "cmbViolationType";
            this.cmbViolationType.Size = new System.Drawing.Size(150, 21);
            this.cmbViolationType.TabIndex = 3;
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(12, 45);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(80, 20);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "Description:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(100, 42);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(370, 40);
            this.txtDescription.TabIndex = 5;
            // 
            // lblFineAmount
            // 
            this.lblFineAmount.Location = new System.Drawing.Point(490, 15);
            this.lblFineAmount.Name = "lblFineAmount";
            this.lblFineAmount.Size = new System.Drawing.Size(40, 20);
            this.lblFineAmount.TabIndex = 6;
            this.lblFineAmount.Text = "Fine:";
            // 
            // numFineAmount
            // 
            this.numFineAmount.DecimalPlaces = 2;
            this.numFineAmount.Location = new System.Drawing.Point(530, 12);
            this.numFineAmount.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.numFineAmount.Name = "numFineAmount";
            this.numFineAmount.Size = new System.Drawing.Size(100, 20);
            this.numFineAmount.TabIndex = 7;
            // 
            // chkMajor
            // 
            this.chkMajor.Location = new System.Drawing.Point(650, 12);
            this.chkMajor.Name = "chkMajor";
            this.chkMajor.Size = new System.Drawing.Size(80, 24);
            this.chkMajor.TabIndex = 8;
            this.chkMajor.Text = "Major";
            // 
            // lblAuthority
            // 
            this.lblAuthority.Location = new System.Drawing.Point(490, 48);
            this.lblAuthority.Name = "lblAuthority";
            this.lblAuthority.Size = new System.Drawing.Size(60, 20);
            this.lblAuthority.TabIndex = 9;
            this.lblAuthority.Text = "Authority:";
            // 
            // txtAuthority
            // 
            this.txtAuthority.Location = new System.Drawing.Point(560, 45);
            this.txtAuthority.Name = "txtAuthority";
            this.txtAuthority.Size = new System.Drawing.Size(210, 20);
            this.txtAuthority.TabIndex = 10;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(100, 95);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 30);
            this.btnAdd.TabIndex = 11;
            this.btnAdd.Text = "Add Record";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(220, 95);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 30);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // DrivingRecordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 411);
            this.Controls.Add(this.pnlAdd);
            this.Controls.Add(this.dgvRecords);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DrivingRecordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Driving Records";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecords)).EndInit();
            this.pnlAdd.ResumeLayout(false);
            this.pnlAdd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFineAmount)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView dgvRecords;
        private System.Windows.Forms.Panel pnlAdd;
        private System.Windows.Forms.Label lblViolationDate;
        private System.Windows.Forms.DateTimePicker dtpViolationDate;
        private System.Windows.Forms.Label lblViolationType;
        private System.Windows.Forms.ComboBox cmbViolationType;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblFineAmount;
        private System.Windows.Forms.NumericUpDown numFineAmount;
        private System.Windows.Forms.CheckBox chkMajor;
        private System.Windows.Forms.Label lblAuthority;
        private System.Windows.Forms.TextBox txtAuthority;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnClose;
    }
}
