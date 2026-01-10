namespace Vormas.Forms
{
    partial class DashboardForm
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlCardsContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlActiveRentals = new System.Windows.Forms.Panel();
            this.lblActiveRentalsTitle = new System.Windows.Forms.Label();
            this.lblActiveRentalsCount = new System.Windows.Forms.Label();
            this.pnlReturnsDue = new System.Windows.Forms.Panel();
            this.lblReturnsDueTitle = new System.Windows.Forms.Label();
            this.lblReturnsDueCount = new System.Windows.Forms.Label();
            this.pnlAvailableVehicles = new System.Windows.Forms.Panel();
            this.lblAvailableTitle = new System.Windows.Forms.Label();
            this.lblAvailableCount = new System.Windows.Forms.Label();
            this.pnlMaintenance = new System.Windows.Forms.Panel();
            this.lblMaintenanceTitle = new System.Windows.Forms.Label();
            this.lblMaintenanceCount = new System.Windows.Forms.Label();
            this.pnlTodayRevenue = new System.Windows.Forms.Panel();
            this.lblTodayRevenueTitle = new System.Windows.Forms.Label();
            this.lblTodayRevenueAmount = new System.Windows.Forms.Label();
            this.pnlMonthlyRevenue = new System.Windows.Forms.Panel();
            this.lblMonthlyRevenueTitle = new System.Windows.Forms.Label();
            this.lblMonthlyRevenueAmount = new System.Windows.Forms.Label();
            this.pnlGridsContainer = new System.Windows.Forms.SplitContainer();
            this.lblOverdueTitle = new System.Windows.Forms.Label();
            this.dgvOverdueRentals = new System.Windows.Forms.DataGridView();
            this.lblTodayActivityTitle = new System.Windows.Forms.Label();
            this.dgvTodayActivities = new System.Windows.Forms.DataGridView();
            this.pnlHeader.SuspendLayout();
            this.pnlCardsContainer.SuspendLayout();
            this.pnlActiveRentals.SuspendLayout();
            this.pnlReturnsDue.SuspendLayout();
            this.pnlAvailableVehicles.SuspendLayout();
            this.pnlMaintenance.SuspendLayout();
            this.pnlTodayRevenue.SuspendLayout();
            this.pnlMonthlyRevenue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlGridsContainer)).BeginInit();
            this.pnlGridsContainer.Panel1.SuspendLayout();
            this.pnlGridsContainer.Panel2.SuspendLayout();
            this.pnlGridsContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOverdueRentals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTodayActivities)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.pnlHeader.Controls.Add(this.btnRefresh);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(984, 60);
            this.pnlHeader.TabIndex = 0;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(178)))), ((int)(((byte)(172)))));
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(869, 15);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 30);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "↻ Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(15, 13);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(136, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Dashboard";
            // 
            // pnlCardsContainer
            // 
            this.pnlCardsContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
            this.pnlCardsContainer.Controls.Add(this.pnlActiveRentals);
            this.pnlCardsContainer.Controls.Add(this.pnlReturnsDue);
            this.pnlCardsContainer.Controls.Add(this.pnlAvailableVehicles);
            this.pnlCardsContainer.Controls.Add(this.pnlMaintenance);
            this.pnlCardsContainer.Controls.Add(this.pnlTodayRevenue);
            this.pnlCardsContainer.Controls.Add(this.pnlMonthlyRevenue);
            this.pnlCardsContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCardsContainer.Location = new System.Drawing.Point(0, 60);
            this.pnlCardsContainer.Name = "pnlCardsContainer";
            this.pnlCardsContainer.Padding = new System.Windows.Forms.Padding(10);
            this.pnlCardsContainer.Size = new System.Drawing.Size(984, 200);
            this.pnlCardsContainer.TabIndex = 1;
            // 
            // pnlActiveRentals
            // 
            this.pnlActiveRentals.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(153)))), ((int)(((byte)(225)))));
            this.pnlActiveRentals.Controls.Add(this.lblActiveRentalsTitle);
            this.pnlActiveRentals.Controls.Add(this.lblActiveRentalsCount);
            this.pnlActiveRentals.Location = new System.Drawing.Point(13, 13);
            this.pnlActiveRentals.Margin = new System.Windows.Forms.Padding(3);
            this.pnlActiveRentals.Name = "pnlActiveRentals";
            this.pnlActiveRentals.Size = new System.Drawing.Size(150, 85);
            this.pnlActiveRentals.TabIndex = 0;
            // 
            // lblActiveRentalsTitle
            // 
            this.lblActiveRentalsTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblActiveRentalsTitle.ForeColor = System.Drawing.Color.White;
            this.lblActiveRentalsTitle.Location = new System.Drawing.Point(10, 8);
            this.lblActiveRentalsTitle.Name = "lblActiveRentalsTitle";
            this.lblActiveRentalsTitle.Size = new System.Drawing.Size(130, 20);
            this.lblActiveRentalsTitle.TabIndex = 0;
            this.lblActiveRentalsTitle.Text = "Active Rentals";
            // 
            // lblActiveRentalsCount
            // 
            this.lblActiveRentalsCount.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblActiveRentalsCount.ForeColor = System.Drawing.Color.White;
            this.lblActiveRentalsCount.Location = new System.Drawing.Point(10, 32);
            this.lblActiveRentalsCount.Name = "lblActiveRentalsCount";
            this.lblActiveRentalsCount.Size = new System.Drawing.Size(130, 45);
            this.lblActiveRentalsCount.TabIndex = 1;
            this.lblActiveRentalsCount.Text = "0";
            // 
            // pnlReturnsDue
            // 
            this.pnlReturnsDue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(137)))), ((int)(((byte)(54)))));
            this.pnlReturnsDue.Controls.Add(this.lblReturnsDueTitle);
            this.pnlReturnsDue.Controls.Add(this.lblReturnsDueCount);
            this.pnlReturnsDue.Location = new System.Drawing.Point(169, 13);
            this.pnlReturnsDue.Margin = new System.Windows.Forms.Padding(3);
            this.pnlReturnsDue.Name = "pnlReturnsDue";
            this.pnlReturnsDue.Size = new System.Drawing.Size(150, 85);
            this.pnlReturnsDue.TabIndex = 1;
            // 
            // lblReturnsDueTitle
            // 
            this.lblReturnsDueTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblReturnsDueTitle.ForeColor = System.Drawing.Color.White;
            this.lblReturnsDueTitle.Location = new System.Drawing.Point(10, 8);
            this.lblReturnsDueTitle.Name = "lblReturnsDueTitle";
            this.lblReturnsDueTitle.Size = new System.Drawing.Size(130, 20);
            this.lblReturnsDueTitle.TabIndex = 0;
            this.lblReturnsDueTitle.Text = "Returns Due Today";
            // 
            // lblReturnsDueCount
            // 
            this.lblReturnsDueCount.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblReturnsDueCount.ForeColor = System.Drawing.Color.White;
            this.lblReturnsDueCount.Location = new System.Drawing.Point(10, 32);
            this.lblReturnsDueCount.Name = "lblReturnsDueCount";
            this.lblReturnsDueCount.Size = new System.Drawing.Size(130, 45);
            this.lblReturnsDueCount.TabIndex = 1;
            this.lblReturnsDueCount.Text = "0";
            // 
            // pnlAvailableVehicles
            // 
            this.pnlAvailableVehicles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(187)))), ((int)(((byte)(120)))));
            this.pnlAvailableVehicles.Controls.Add(this.lblAvailableTitle);
            this.pnlAvailableVehicles.Controls.Add(this.lblAvailableCount);
            this.pnlAvailableVehicles.Location = new System.Drawing.Point(325, 13);
            this.pnlAvailableVehicles.Margin = new System.Windows.Forms.Padding(3);
            this.pnlAvailableVehicles.Name = "pnlAvailableVehicles";
            this.pnlAvailableVehicles.Size = new System.Drawing.Size(150, 85);
            this.pnlAvailableVehicles.TabIndex = 2;
            // 
            // lblAvailableTitle
            // 
            this.lblAvailableTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAvailableTitle.ForeColor = System.Drawing.Color.White;
            this.lblAvailableTitle.Location = new System.Drawing.Point(10, 8);
            this.lblAvailableTitle.Name = "lblAvailableTitle";
            this.lblAvailableTitle.Size = new System.Drawing.Size(130, 20);
            this.lblAvailableTitle.TabIndex = 0;
            this.lblAvailableTitle.Text = "Vehicles Available";
            // 
            // lblAvailableCount
            // 
            this.lblAvailableCount.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblAvailableCount.ForeColor = System.Drawing.Color.White;
            this.lblAvailableCount.Location = new System.Drawing.Point(10, 32);
            this.lblAvailableCount.Name = "lblAvailableCount";
            this.lblAvailableCount.Size = new System.Drawing.Size(130, 45);
            this.lblAvailableCount.TabIndex = 1;
            this.lblAvailableCount.Text = "0";
            // 
            // pnlMaintenance
            // 
            this.pnlMaintenance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(122)))), ((int)(((byte)(234)))));
            this.pnlMaintenance.Controls.Add(this.lblMaintenanceTitle);
            this.pnlMaintenance.Controls.Add(this.lblMaintenanceCount);
            this.pnlMaintenance.Location = new System.Drawing.Point(481, 13);
            this.pnlMaintenance.Margin = new System.Windows.Forms.Padding(3);
            this.pnlMaintenance.Name = "pnlMaintenance";
            this.pnlMaintenance.Size = new System.Drawing.Size(150, 85);
            this.pnlMaintenance.TabIndex = 3;
            // 
            // lblMaintenanceTitle
            // 
            this.lblMaintenanceTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMaintenanceTitle.ForeColor = System.Drawing.Color.White;
            this.lblMaintenanceTitle.Location = new System.Drawing.Point(10, 8);
            this.lblMaintenanceTitle.Name = "lblMaintenanceTitle";
            this.lblMaintenanceTitle.Size = new System.Drawing.Size(130, 20);
            this.lblMaintenanceTitle.TabIndex = 0;
            this.lblMaintenanceTitle.Text = "In Maintenance";
            // 
            // lblMaintenanceCount
            // 
            this.lblMaintenanceCount.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblMaintenanceCount.ForeColor = System.Drawing.Color.White;
            this.lblMaintenanceCount.Location = new System.Drawing.Point(10, 32);
            this.lblMaintenanceCount.Name = "lblMaintenanceCount";
            this.lblMaintenanceCount.Size = new System.Drawing.Size(130, 45);
            this.lblMaintenanceCount.TabIndex = 1;
            this.lblMaintenanceCount.Text = "0";
            // 
            // pnlTodayRevenue
            // 
            this.pnlTodayRevenue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(178)))), ((int)(((byte)(172)))));
            this.pnlTodayRevenue.Controls.Add(this.lblTodayRevenueTitle);
            this.pnlTodayRevenue.Controls.Add(this.lblTodayRevenueAmount);
            this.pnlTodayRevenue.Location = new System.Drawing.Point(637, 13);
            this.pnlTodayRevenue.Margin = new System.Windows.Forms.Padding(3);
            this.pnlTodayRevenue.Name = "pnlTodayRevenue";
            this.pnlTodayRevenue.Size = new System.Drawing.Size(160, 85);
            this.pnlTodayRevenue.TabIndex = 4;
            // 
            // lblTodayRevenueTitle
            // 
            this.lblTodayRevenueTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTodayRevenueTitle.ForeColor = System.Drawing.Color.White;
            this.lblTodayRevenueTitle.Location = new System.Drawing.Point(10, 8);
            this.lblTodayRevenueTitle.Name = "lblTodayRevenueTitle";
            this.lblTodayRevenueTitle.Size = new System.Drawing.Size(140, 20);
            this.lblTodayRevenueTitle.TabIndex = 0;
            this.lblTodayRevenueTitle.Text = "Today\'s Revenue";
            // 
            // lblTodayRevenueAmount
            // 
            this.lblTodayRevenueAmount.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTodayRevenueAmount.ForeColor = System.Drawing.Color.White;
            this.lblTodayRevenueAmount.Location = new System.Drawing.Point(10, 32);
            this.lblTodayRevenueAmount.Name = "lblTodayRevenueAmount";
            this.lblTodayRevenueAmount.Size = new System.Drawing.Size(140, 45);
            this.lblTodayRevenueAmount.TabIndex = 1;
            this.lblTodayRevenueAmount.Text = "₱0.00";
            // 
            // pnlMonthlyRevenue
            // 
            this.pnlMonthlyRevenue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(101)))), ((int)(((byte)(101)))));
            this.pnlMonthlyRevenue.Controls.Add(this.lblMonthlyRevenueTitle);
            this.pnlMonthlyRevenue.Controls.Add(this.lblMonthlyRevenueAmount);
            this.pnlMonthlyRevenue.Location = new System.Drawing.Point(803, 13);
            this.pnlMonthlyRevenue.Margin = new System.Windows.Forms.Padding(3);
            this.pnlMonthlyRevenue.Name = "pnlMonthlyRevenue";
            this.pnlMonthlyRevenue.Size = new System.Drawing.Size(160, 85);
            this.pnlMonthlyRevenue.TabIndex = 5;
            // 
            // lblMonthlyRevenueTitle
            // 
            this.lblMonthlyRevenueTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMonthlyRevenueTitle.ForeColor = System.Drawing.Color.White;
            this.lblMonthlyRevenueTitle.Location = new System.Drawing.Point(10, 8);
            this.lblMonthlyRevenueTitle.Name = "lblMonthlyRevenueTitle";
            this.lblMonthlyRevenueTitle.Size = new System.Drawing.Size(140, 20);
            this.lblMonthlyRevenueTitle.TabIndex = 0;
            this.lblMonthlyRevenueTitle.Text = "Monthly Revenue";
            // 
            // lblMonthlyRevenueAmount
            // 
            this.lblMonthlyRevenueAmount.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblMonthlyRevenueAmount.ForeColor = System.Drawing.Color.White;
            this.lblMonthlyRevenueAmount.Location = new System.Drawing.Point(10, 32);
            this.lblMonthlyRevenueAmount.Name = "lblMonthlyRevenueAmount";
            this.lblMonthlyRevenueAmount.Size = new System.Drawing.Size(140, 45);
            this.lblMonthlyRevenueAmount.TabIndex = 1;
            this.lblMonthlyRevenueAmount.Text = "₱0.00";
            // 
            // pnlGridsContainer
            // 
            this.pnlGridsContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGridsContainer.Location = new System.Drawing.Point(0, 260);
            this.pnlGridsContainer.Name = "pnlGridsContainer";
            // 
            // pnlGridsContainer.Panel1
            // 
            this.pnlGridsContainer.Panel1.BackColor = System.Drawing.Color.White;
            this.pnlGridsContainer.Panel1.Controls.Add(this.dgvOverdueRentals);
            this.pnlGridsContainer.Panel1.Controls.Add(this.lblOverdueTitle);
            this.pnlGridsContainer.Panel1.Padding = new System.Windows.Forms.Padding(10);
            // 
            // pnlGridsContainer.Panel2
            // 
            this.pnlGridsContainer.Panel2.BackColor = System.Drawing.Color.White;
            this.pnlGridsContainer.Panel2.Controls.Add(this.dgvTodayActivities);
            this.pnlGridsContainer.Panel2.Controls.Add(this.lblTodayActivityTitle);
            this.pnlGridsContainer.Panel2.Padding = new System.Windows.Forms.Padding(10);
            this.pnlGridsContainer.Size = new System.Drawing.Size(984, 301);
            this.pnlGridsContainer.SplitterDistance = 490;
            this.pnlGridsContainer.TabIndex = 2;
            // 
            // lblOverdueTitle
            // 
            this.lblOverdueTitle.AutoSize = true;
            this.lblOverdueTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblOverdueTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblOverdueTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(101)))), ((int)(((byte)(101)))));
            this.lblOverdueTitle.Location = new System.Drawing.Point(10, 10);
            this.lblOverdueTitle.Name = "lblOverdueTitle";
            this.lblOverdueTitle.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.lblOverdueTitle.Size = new System.Drawing.Size(139, 26);
            this.lblOverdueTitle.TabIndex = 0;
            this.lblOverdueTitle.Text = "Overdue Returns";
            // 
            // dgvOverdueRentals
            // 
            this.dgvOverdueRentals.AllowUserToAddRows = false;
            this.dgvOverdueRentals.AllowUserToDeleteRows = false;
            this.dgvOverdueRentals.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOverdueRentals.BackgroundColor = System.Drawing.Color.White;
            this.dgvOverdueRentals.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvOverdueRentals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOverdueRentals.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOverdueRentals.Location = new System.Drawing.Point(10, 36);
            this.dgvOverdueRentals.Name = "dgvOverdueRentals";
            this.dgvOverdueRentals.ReadOnly = true;
            this.dgvOverdueRentals.RowHeadersVisible = false;
            this.dgvOverdueRentals.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOverdueRentals.Size = new System.Drawing.Size(470, 255);
            this.dgvOverdueRentals.TabIndex = 1;
            // 
            // lblTodayActivityTitle
            // 
            this.lblTodayActivityTitle.AutoSize = true;
            this.lblTodayActivityTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTodayActivityTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTodayActivityTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(153)))), ((int)(((byte)(225)))));
            this.lblTodayActivityTitle.Location = new System.Drawing.Point(10, 10);
            this.lblTodayActivityTitle.Name = "lblTodayActivityTitle";
            this.lblTodayActivityTitle.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.lblTodayActivityTitle.Size = new System.Drawing.Size(188, 26);
            this.lblTodayActivityTitle.TabIndex = 0;
            this.lblTodayActivityTitle.Text = "Today\'s Pickups/Returns";
            // 
            // dgvTodayActivities
            // 
            this.dgvTodayActivities.AllowUserToAddRows = false;
            this.dgvTodayActivities.AllowUserToDeleteRows = false;
            this.dgvTodayActivities.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTodayActivities.BackgroundColor = System.Drawing.Color.White;
            this.dgvTodayActivities.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTodayActivities.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTodayActivities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTodayActivities.Location = new System.Drawing.Point(10, 36);
            this.dgvTodayActivities.Name = "dgvTodayActivities";
            this.dgvTodayActivities.ReadOnly = true;
            this.dgvTodayActivities.RowHeadersVisible = false;
            this.dgvTodayActivities.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTodayActivities.Size = new System.Drawing.Size(470, 255);
            this.dgvTodayActivities.TabIndex = 1;
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
            this.Controls.Add(this.pnlGridsContainer);
            this.Controls.Add(this.pnlCardsContainer);
            this.Controls.Add(this.pnlHeader);
            this.Name = "DashboardForm";
            this.Size = new System.Drawing.Size(984, 561);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlCardsContainer.ResumeLayout(false);
            this.pnlActiveRentals.ResumeLayout(false);
            this.pnlReturnsDue.ResumeLayout(false);
            this.pnlAvailableVehicles.ResumeLayout(false);
            this.pnlMaintenance.ResumeLayout(false);
            this.pnlTodayRevenue.ResumeLayout(false);
            this.pnlMonthlyRevenue.ResumeLayout(false);
            this.pnlGridsContainer.Panel1.ResumeLayout(false);
            this.pnlGridsContainer.Panel1.PerformLayout();
            this.pnlGridsContainer.Panel2.ResumeLayout(false);
            this.pnlGridsContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlGridsContainer)).EndInit();
            this.pnlGridsContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOverdueRentals)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTodayActivities)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.FlowLayoutPanel pnlCardsContainer;
        private System.Windows.Forms.Panel pnlActiveRentals;
        private System.Windows.Forms.Label lblActiveRentalsTitle;
        private System.Windows.Forms.Label lblActiveRentalsCount;
        private System.Windows.Forms.Panel pnlReturnsDue;
        private System.Windows.Forms.Label lblReturnsDueTitle;
        private System.Windows.Forms.Label lblReturnsDueCount;
        private System.Windows.Forms.Panel pnlAvailableVehicles;
        private System.Windows.Forms.Label lblAvailableTitle;
        private System.Windows.Forms.Label lblAvailableCount;
        private System.Windows.Forms.Panel pnlMaintenance;
        private System.Windows.Forms.Label lblMaintenanceTitle;
        private System.Windows.Forms.Label lblMaintenanceCount;
        private System.Windows.Forms.Panel pnlTodayRevenue;
        private System.Windows.Forms.Label lblTodayRevenueTitle;
        private System.Windows.Forms.Label lblTodayRevenueAmount;
        private System.Windows.Forms.Panel pnlMonthlyRevenue;
        private System.Windows.Forms.Label lblMonthlyRevenueTitle;
        private System.Windows.Forms.Label lblMonthlyRevenueAmount;
        private System.Windows.Forms.SplitContainer pnlGridsContainer;
        private System.Windows.Forms.Label lblOverdueTitle;
        private System.Windows.Forms.DataGridView dgvOverdueRentals;
        private System.Windows.Forms.Label lblTodayActivityTitle;
        private System.Windows.Forms.DataGridView dgvTodayActivities;
    }
}
