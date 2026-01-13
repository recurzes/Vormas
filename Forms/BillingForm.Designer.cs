namespace Vormas.Forms
{
    partial class BillingForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panelInvoiceList = new System.Windows.Forms.Panel();
            this.dgvInvoices = new System.Windows.Forms.DataGridView();
            this.panelListControls = new System.Windows.Forms.Panel();
            this.lblInvoiceCount = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cmbStatusFilter = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblListTitle = new System.Windows.Forms.Label();
            this.panelDetails = new System.Windows.Forms.Panel();
            this.groupBoxPayment = new System.Windows.Forms.GroupBox();
            this.btnRecordPayment = new System.Windows.Forms.Button();
            this.txtReferenceNumber = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbPaymentMethod = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.numPaymentAmount = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBoxTotals = new System.Windows.Forms.GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblBalanceDue = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblDeposit = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblTax = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvLineItems = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBoxCustomer = new System.Windows.Forms.GroupBox();
            this.lblRentalDates = new System.Windows.Forms.Label();
            this.lblVehicleInfo = new System.Windows.Forms.Label();
            this.lblCustomerContact = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.panelDetailsHeader = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.lblDetailsTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panelInvoiceList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoices)).BeginInit();
            this.panelListControls.SuspendLayout();
            this.panelDetails.SuspendLayout();
            this.groupBoxPayment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPaymentAmount)).BeginInit();
            this.groupBoxTotals.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineItems)).BeginInit();
            this.groupBoxCustomer.SuspendLayout();
            this.panelDetailsHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panelInvoiceList);
            this.splitContainer1.Panel1MinSize = 400;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panelDetails);
            this.splitContainer1.Panel2MinSize = 450;
            this.splitContainer1.Size = new System.Drawing.Size(1200, 700);
            this.splitContainer1.SplitterDistance = 550;
            this.splitContainer1.TabIndex = 0;
            // 
            // panelInvoiceList
            // 
            this.panelInvoiceList.Controls.Add(this.dgvInvoices);
            this.panelInvoiceList.Controls.Add(this.panelListControls);
            this.panelInvoiceList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelInvoiceList.Location = new System.Drawing.Point(0, 0);
            this.panelInvoiceList.Name = "panelInvoiceList";
            this.panelInvoiceList.Padding = new System.Windows.Forms.Padding(10);
            this.panelInvoiceList.Size = new System.Drawing.Size(550, 700);
            this.panelInvoiceList.TabIndex = 0;
            // 
            // dgvInvoices
            // 
            this.dgvInvoices.AllowUserToAddRows = false;
            this.dgvInvoices.AllowUserToDeleteRows = false;
            this.dgvInvoices.BackgroundColor = System.Drawing.Color.White;
            this.dgvInvoices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInvoices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInvoices.Location = new System.Drawing.Point(10, 70);
            this.dgvInvoices.Name = "dgvInvoices";
            this.dgvInvoices.RowHeadersVisible = false;
            this.dgvInvoices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInvoices.Size = new System.Drawing.Size(530, 620);
            this.dgvInvoices.TabIndex = 1;
            // 
            // panelListControls
            // 
            this.panelListControls.Controls.Add(this.lblInvoiceCount);
            this.panelListControls.Controls.Add(this.btnRefresh);
            this.panelListControls.Controls.Add(this.cmbStatusFilter);
            this.panelListControls.Controls.Add(this.label1);
            this.panelListControls.Controls.Add(this.lblListTitle);
            this.panelListControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelListControls.Location = new System.Drawing.Point(10, 10);
            this.panelListControls.Name = "panelListControls";
            this.panelListControls.Size = new System.Drawing.Size(530, 60);
            this.panelListControls.TabIndex = 0;
            // 
            // lblInvoiceCount
            // 
            this.lblInvoiceCount.AutoSize = true;
            this.lblInvoiceCount.Location = new System.Drawing.Point(3, 38);
            this.lblInvoiceCount.Name = "lblInvoiceCount";
            this.lblInvoiceCount.Size = new System.Drawing.Size(58, 13);
            this.lblInvoiceCount.TabIndex = 4;
            this.lblInvoiceCount.Text = "Invoices: 0";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(452, 6);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // cmbStatusFilter
            // 
            this.cmbStatusFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatusFilter.FormattingEnabled = true;
            this.cmbStatusFilter.Items.AddRange(new object[] {
            "All",
            "Unpaid",
            "PartiallyPaid",
            "Paid",
            "Refunded"});
            this.cmbStatusFilter.Location = new System.Drawing.Point(310, 8);
            this.cmbStatusFilter.Name = "cmbStatusFilter";
            this.cmbStatusFilter.Size = new System.Drawing.Size(121, 21);
            this.cmbStatusFilter.TabIndex = 2;
            this.cmbStatusFilter.SelectedIndexChanged += new System.EventHandler(this.cmbStatusFilter_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(263, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Status:";
            // 
            // lblListTitle
            // 
            this.lblListTitle.AutoSize = true;
            this.lblListTitle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblListTitle.Location = new System.Drawing.Point(3, 5);
            this.lblListTitle.Name = "lblListTitle";
            this.lblListTitle.Size = new System.Drawing.Size(83, 25);
            this.lblListTitle.TabIndex = 0;
            this.lblListTitle.Text = "Invoices";
            // 
            // panelDetails
            // 
            this.panelDetails.Controls.Add(this.groupBoxPayment);
            this.panelDetails.Controls.Add(this.groupBoxTotals);
            this.panelDetails.Controls.Add(this.dgvLineItems);
            this.panelDetails.Controls.Add(this.label2);
            this.panelDetails.Controls.Add(this.groupBoxCustomer);
            this.panelDetails.Controls.Add(this.panelDetailsHeader);
            this.panelDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDetails.Location = new System.Drawing.Point(0, 0);
            this.panelDetails.Name = "panelDetails";
            this.panelDetails.Padding = new System.Windows.Forms.Padding(10);
            this.panelDetails.Size = new System.Drawing.Size(646, 700);
            this.panelDetails.TabIndex = 0;
            // 
            // groupBoxPayment
            // 
            this.groupBoxPayment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxPayment.Controls.Add(this.btnRecordPayment);
            this.groupBoxPayment.Controls.Add(this.txtReferenceNumber);
            this.groupBoxPayment.Controls.Add(this.label8);
            this.groupBoxPayment.Controls.Add(this.cmbPaymentMethod);
            this.groupBoxPayment.Controls.Add(this.label7);
            this.groupBoxPayment.Controls.Add(this.numPaymentAmount);
            this.groupBoxPayment.Controls.Add(this.label6);
            this.groupBoxPayment.Location = new System.Drawing.Point(13, 610);
            this.groupBoxPayment.Name = "groupBoxPayment";
            this.groupBoxPayment.Size = new System.Drawing.Size(620, 80);
            this.groupBoxPayment.TabIndex = 5;
            this.groupBoxPayment.TabStop = false;
            this.groupBoxPayment.Text = "Record Payment";
            // 
            // btnRecordPayment
            // 
            this.btnRecordPayment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnRecordPayment.Enabled = false;
            this.btnRecordPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecordPayment.ForeColor = System.Drawing.Color.White;
            this.btnRecordPayment.Location = new System.Drawing.Point(515, 28);
            this.btnRecordPayment.Name = "btnRecordPayment";
            this.btnRecordPayment.Size = new System.Drawing.Size(95, 35);
            this.btnRecordPayment.TabIndex = 6;
            this.btnRecordPayment.Text = "Record";
            this.btnRecordPayment.UseVisualStyleBackColor = false;
            this.btnRecordPayment.Click += new System.EventHandler(this.btnRecordPayment_Click);
            // 
            // txtReferenceNumber
            // 
            this.txtReferenceNumber.Location = new System.Drawing.Point(365, 38);
            this.txtReferenceNumber.Name = "txtReferenceNumber";
            this.txtReferenceNumber.Size = new System.Drawing.Size(130, 20);
            this.txtReferenceNumber.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(362, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Reference:";
            // 
            // cmbPaymentMethod
            // 
            this.cmbPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaymentMethod.FormattingEnabled = true;
            this.cmbPaymentMethod.Items.AddRange(new object[] {
            "Cash",
            "Card",
            "Transfer",
            "Check"});
            this.cmbPaymentMethod.Location = new System.Drawing.Point(225, 38);
            this.cmbPaymentMethod.Name = "cmbPaymentMethod";
            this.cmbPaymentMethod.Size = new System.Drawing.Size(121, 21);
            this.cmbPaymentMethod.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(222, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Method:";
            // 
            // numPaymentAmount
            // 
            this.numPaymentAmount.DecimalPlaces = 2;
            this.numPaymentAmount.Location = new System.Drawing.Point(15, 38);
            this.numPaymentAmount.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numPaymentAmount.Name = "numPaymentAmount";
            this.numPaymentAmount.Size = new System.Drawing.Size(181, 20);
            this.numPaymentAmount.TabIndex = 1;
            this.numPaymentAmount.ThousandsSeparator = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Amount:";
            // 
            // groupBoxTotals
            // 
            this.groupBoxTotals.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxTotals.Controls.Add(this.lblStatus);
            this.groupBoxTotals.Controls.Add(this.label15);
            this.groupBoxTotals.Controls.Add(this.lblBalanceDue);
            this.groupBoxTotals.Controls.Add(this.label13);
            this.groupBoxTotals.Controls.Add(this.lblDeposit);
            this.groupBoxTotals.Controls.Add(this.label11);
            this.groupBoxTotals.Controls.Add(this.lblTotal);
            this.groupBoxTotals.Controls.Add(this.label9);
            this.groupBoxTotals.Controls.Add(this.lblTax);
            this.groupBoxTotals.Controls.Add(this.label5);
            this.groupBoxTotals.Controls.Add(this.lblSubtotal);
            this.groupBoxTotals.Controls.Add(this.label3);
            this.groupBoxTotals.Location = new System.Drawing.Point(13, 485);
            this.groupBoxTotals.Name = "groupBoxTotals";
            this.groupBoxTotals.Size = new System.Drawing.Size(620, 120);
            this.groupBoxTotals.TabIndex = 4;
            this.groupBoxTotals.TabStop = false;
            this.groupBoxTotals.Text = "Invoice Summary";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(450, 82);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 20);
            this.lblStatus.TabIndex = 11;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(390, 84);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(54, 16);
            this.label15.TabIndex = 10;
            this.label15.Text = "Status:";
            // 
            // lblBalanceDue
            // 
            this.lblBalanceDue.AutoSize = true;
            this.lblBalanceDue.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalanceDue.ForeColor = System.Drawing.Color.DarkRed;
            this.lblBalanceDue.Location = new System.Drawing.Point(450, 45);
            this.lblBalanceDue.Name = "lblBalanceDue";
            this.lblBalanceDue.Size = new System.Drawing.Size(60, 25);
            this.lblBalanceDue.TabIndex = 9;
            this.lblBalanceDue.Text = "₱0.00";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(352, 50);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(93, 16);
            this.label13.TabIndex = 8;
            this.label13.Text = "Balance Due:";
            // 
            // lblDeposit
            // 
            this.lblDeposit.AutoSize = true;
            this.lblDeposit.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeposit.Location = new System.Drawing.Point(450, 20);
            this.lblDeposit.Name = "lblDeposit";
            this.lblDeposit.Size = new System.Drawing.Size(43, 17);
            this.lblDeposit.TabIndex = 7;
            this.lblDeposit.Text = "₱0.00";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(352, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 13);
            this.label11.TabIndex = 6;
            this.label11.Text = "Deposit Applied:";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(120, 81);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(52, 21);
            this.lblTotal.TabIndex = 5;
            this.lblTotal.Text = "₱0.00";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(23, 83);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 16);
            this.label9.TabIndex = 4;
            this.label9.Text = "Total:";
            // 
            // lblTax
            // 
            this.lblTax.AutoSize = true;
            this.lblTax.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTax.Location = new System.Drawing.Point(120, 52);
            this.lblTax.Name = "lblTax";
            this.lblTax.Size = new System.Drawing.Size(43, 17);
            this.lblTax.TabIndex = 3;
            this.lblTax.Text = "₱0.00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Tax (12%):";
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtotal.Location = new System.Drawing.Point(120, 23);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(43, 17);
            this.lblSubtotal.TabIndex = 1;
            this.lblSubtotal.Text = "₱0.00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Subtotal:";
            // 
            // dgvLineItems
            // 
            this.dgvLineItems.AllowUserToAddRows = false;
            this.dgvLineItems.AllowUserToDeleteRows = false;
            this.dgvLineItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLineItems.BackgroundColor = System.Drawing.Color.White;
            this.dgvLineItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLineItems.Location = new System.Drawing.Point(13, 215);
            this.dgvLineItems.Name = "dgvLineItems";
            this.dgvLineItems.RowHeadersVisible = false;
            this.dgvLineItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLineItems.Size = new System.Drawing.Size(620, 264);
            this.dgvLineItems.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 195);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Line Items:";
            // 
            // groupBoxCustomer
            // 
            this.groupBoxCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxCustomer.Controls.Add(this.lblRentalDates);
            this.groupBoxCustomer.Controls.Add(this.lblVehicleInfo);
            this.groupBoxCustomer.Controls.Add(this.lblCustomerContact);
            this.groupBoxCustomer.Controls.Add(this.lblCustomerName);
            this.groupBoxCustomer.Location = new System.Drawing.Point(13, 55);
            this.groupBoxCustomer.Name = "groupBoxCustomer";
            this.groupBoxCustomer.Size = new System.Drawing.Size(620, 135);
            this.groupBoxCustomer.TabIndex = 1;
            this.groupBoxCustomer.TabStop = false;
            this.groupBoxCustomer.Text = "Customer && Rental Information";
            // 
            // lblRentalDates
            // 
            this.lblRentalDates.AutoSize = true;
            this.lblRentalDates.Location = new System.Drawing.Point(15, 105);
            this.lblRentalDates.Name = "lblRentalDates";
            this.lblRentalDates.Size = new System.Drawing.Size(0, 13);
            this.lblRentalDates.TabIndex = 3;
            // 
            // lblVehicleInfo
            // 
            this.lblVehicleInfo.AutoSize = true;
            this.lblVehicleInfo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVehicleInfo.Location = new System.Drawing.Point(15, 78);
            this.lblVehicleInfo.Name = "lblVehicleInfo";
            this.lblVehicleInfo.Size = new System.Drawing.Size(0, 17);
            this.lblVehicleInfo.TabIndex = 2;
            // 
            // lblCustomerContact
            // 
            this.lblCustomerContact.AutoSize = true;
            this.lblCustomerContact.Location = new System.Drawing.Point(15, 50);
            this.lblCustomerContact.Name = "lblCustomerContact";
            this.lblCustomerContact.Size = new System.Drawing.Size(0, 13);
            this.lblCustomerContact.TabIndex = 1;
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerName.Location = new System.Drawing.Point(13, 22);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(0, 21);
            this.lblCustomerName.TabIndex = 0;
            // 
            // panelDetailsHeader
            // 
            this.panelDetailsHeader.Controls.Add(this.btnClear);
            this.panelDetailsHeader.Controls.Add(this.btnPrint);
            this.panelDetailsHeader.Controls.Add(this.lblDetailsTitle);
            this.panelDetailsHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDetailsHeader.Location = new System.Drawing.Point(10, 10);
            this.panelDetailsHeader.Name = "panelDetailsHeader";
            this.panelDetailsHeader.Size = new System.Drawing.Size(626, 40);
            this.panelDetailsHeader.TabIndex = 0;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(538, 8);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
            this.btnPrint.Enabled = false;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Location = new System.Drawing.Point(438, 5);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(90, 28);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "🖨️ Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // lblDetailsTitle
            // 
            this.lblDetailsTitle.AutoSize = true;
            this.lblDetailsTitle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetailsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblDetailsTitle.Location = new System.Drawing.Point(3, 5);
            this.lblDetailsTitle.Name = "lblDetailsTitle";
            this.lblDetailsTitle.Size = new System.Drawing.Size(140, 25);
            this.lblDetailsTitle.TabIndex = 0;
            this.lblDetailsTitle.Text = "Invoice Details";
            // 
            // BillingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "BillingForm";
            this.Size = new System.Drawing.Size(1200, 700);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panelInvoiceList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoices)).EndInit();
            this.panelListControls.ResumeLayout(false);
            this.panelListControls.PerformLayout();
            this.panelDetails.ResumeLayout(false);
            this.panelDetails.PerformLayout();
            this.groupBoxPayment.ResumeLayout(false);
            this.groupBoxPayment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPaymentAmount)).EndInit();
            this.groupBoxTotals.ResumeLayout(false);
            this.groupBoxTotals.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineItems)).EndInit();
            this.groupBoxCustomer.ResumeLayout(false);
            this.groupBoxCustomer.PerformLayout();
            this.panelDetailsHeader.ResumeLayout(false);
            this.panelDetailsHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panelInvoiceList;
        private System.Windows.Forms.DataGridView dgvInvoices;
        private System.Windows.Forms.Panel panelListControls;
        private System.Windows.Forms.Label lblInvoiceCount;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ComboBox cmbStatusFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblListTitle;
        private System.Windows.Forms.Panel panelDetails;
        private System.Windows.Forms.Panel panelDetailsHeader;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label lblDetailsTitle;
        private System.Windows.Forms.GroupBox groupBoxCustomer;
        private System.Windows.Forms.Label lblRentalDates;
        private System.Windows.Forms.Label lblVehicleInfo;
        private System.Windows.Forms.Label lblCustomerContact;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvLineItems;
        private System.Windows.Forms.GroupBox groupBoxTotals;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblBalanceDue;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblDeposit;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblTax;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBoxPayment;
        private System.Windows.Forms.Button btnRecordPayment;
        private System.Windows.Forms.TextBox txtReferenceNumber;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbPaymentMethod;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numPaymentAmount;
        private System.Windows.Forms.Label label6;
    }
}
