using System;
using System.Drawing;
using System.Windows.Forms;
using Vormas.Interfaces;
using Vormas.Models;
using Vormas.Navigation;

namespace Vormas.Forms
{
    /// <summary>
    /// Dashboard form displaying KPIs and activity lists for the Vehicle Rental System.
    /// Uses dependency injection for IReportService to follow SOLID principles.
    /// </summary>
    public partial class DashboardForm : PageControl
    {
        private readonly IReportService _reportService;

        /// <summary>
        /// Initializes the DashboardForm with dependency injection.
        /// </summary>
        /// <param name="reportService">The report service for retrieving dashboard data.</param>
        /// <exception cref="ArgumentNullException">Thrown when reportService is null.</exception>
        public DashboardForm(IReportService reportService)
        {
            InitializeComponent();

            _reportService = reportService ?? throw new ArgumentNullException(nameof(reportService));

            ConfigureGrids();
            ApplyTheme();
        }

        /// <summary>
        /// Called when the form is navigated to. Loads the dashboard data.
        /// </summary>
        public override void OnNavigatedTo()
        {
            base.OnNavigatedTo();
            LoadDashboardData();
        }

        /// <summary>
        /// Loads dashboard data from the service and populates the UI.
        /// Uses safe UI thread invocation for potential async scenarios.
        /// </summary>
        private void LoadDashboardData()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                var summary = _reportService.GetDashboardSummary();

                if (InvokeRequired)
                {
                    Invoke(new Action(() => PopulateUI(summary)));
                }
                else
                {
                    PopulateUI(summary);
                }
            }
            catch (Exception ex)
            {
                // Unwrapping the exception to see the real SQL error
                var realError = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                
                MessageBox.Show(
                    $@"Error loading dashboard data: {realError}",
                    @"Dashboard Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Populates all UI elements with the dashboard summary data.
        /// </summary>
        /// <param name="summary">The dashboard summary DTO.</param>
        private void PopulateUI(DashboardSummaryDto summary)
        {
            // Populate KPI Cards
            lblActiveRentalsCount.Text = summary.ActiveRentalsCount.ToString();
            lblReturnsDueCount.Text = summary.ReturnsDueTodayCount.ToString();
            lblAvailableCount.Text = summary.AvailableVehiclesCount.ToString();
            lblMaintenanceCount.Text = summary.VehiclesInMaintenanceCount.ToString();
            lblTodayRevenueAmount.Text = summary.TodayRevenue.ToString("C");
            lblMonthlyRevenueAmount.Text = summary.MonthlyRevenue.ToString("C");

            // Populate Grids
            dgvOverdueRentals.DataSource = summary.OverdueRentals;
            dgvTodayActivities.DataSource = summary.TodayActivities;

            // Apply conditional styling for overdue count
            // Apply conditional styling for overdue count
            if (summary.ReturnsDueTodayCount > 0)
            {
                // Keeping the text dark grey/black for consistency in the light theme, 
                // or we could use the accent color (Orange) to draw attention.
                // For now, let's keep it consistent with the theme (Dark Grey).
                lblReturnsDueCount.ForeColor = ColorTranslator.FromHtml("#212529"); 
            }
        }

        /// <summary>
        /// Configures the DataGridView columns for both grids.
        /// </summary>
        private void ConfigureGrids()
        {
            // Configure Overdue Rentals Grid
            dgvOverdueRentals.AutoGenerateColumns = false;
            dgvOverdueRentals.Columns.Clear();
            dgvOverdueRentals.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CustomerName",
                HeaderText = "Customer",
                FillWeight = 25
            });
            dgvOverdueRentals.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "VehicleName",
                HeaderText = "Vehicle",
                FillWeight = 25
            });
            dgvOverdueRentals.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "LicensePlate",
                HeaderText = "Plate",
                FillWeight = 15
            });
            dgvOverdueRentals.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DaysOverdue",
                HeaderText = "Days Overdue",
                FillWeight = 15,
                DefaultCellStyle = new DataGridViewCellStyle { ForeColor = Color.Red, Font = new Font("Segoe UI", 9, FontStyle.Bold) }
            });
            dgvOverdueRentals.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CustomerPhone",
                HeaderText = "Phone",
                FillWeight = 20
            });

            // Configure Today's Activities Grid
            dgvTodayActivities.AutoGenerateColumns = false;
            dgvTodayActivities.Columns.Clear();
            dgvTodayActivities.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ActivityType",
                HeaderText = "Type",
                FillWeight = 15
            });
            dgvTodayActivities.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CustomerName",
                HeaderText = "Customer",
                FillWeight = 25
            });
            dgvTodayActivities.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "VehicleName",
                HeaderText = "Vehicle",
                FillWeight = 25
            });
            dgvTodayActivities.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "LicensePlate",
                HeaderText = "Plate",
                FillWeight = 15
            });
            dgvTodayActivities.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ScheduledTime",
                HeaderText = "Time",
                FillWeight = 20,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "hh:mm tt" }
            });

            // Style both grids
            StyleDataGridView(dgvOverdueRentals);
            StyleDataGridView(dgvTodayActivities);
        }

        /// <summary>
        /// Applies consistent styling to a DataGridView.
        /// </summary>
        /// <param name="grid">The DataGridView to style.</param>
        private void StyleDataGridView(DataGridView grid)
        {
            grid.EnableHeadersVisualStyles = false;
            // Header Style
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#212529"); // Dark Grey
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            grid.ColumnHeadersDefaultCellStyle.Padding = new Padding(5);
            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            grid.ColumnHeadersHeight = 40;

            // Row Style
            grid.BackgroundColor = Color.White;
            grid.GridColor = ColorTranslator.FromHtml("#DEE2E6"); // Light border color
            grid.DefaultCellStyle.BackColor = Color.White;
            grid.DefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#212529");
            grid.DefaultCellStyle.Padding = new Padding(5);
            grid.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#E9ECEF"); // Very light grey selection
            grid.DefaultCellStyle.SelectionForeColor = ColorTranslator.FromHtml("#212529"); // Keep text dark
            
            // Alternating Rows
            grid.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F8F9FA");

            grid.RowTemplate.Height = 35;
            grid.BorderStyle = BorderStyle.None;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        }

        /// <summary>
        /// Applies rounded corner styling to KPI card panels.
        /// </summary>
        /// <summary>
        /// Applies the application-wide theme to the dashboard controls.
        /// </summary>
        private void ApplyTheme()
        {
            // Main Form Background
            this.BackColor = ColorTranslator.FromHtml("#F8F9FA");
            pnlCardsContainer.BackColor = ColorTranslator.FromHtml("#F8F9FA");
            pnlHeader.BackColor = Color.White;
            
            // Header Title
            lblTitle.ForeColor = ColorTranslator.FromHtml("#212529");

            // Refresh Button Styling 
            // (Keeping it as is or neutral? Let's make it match the primary accent or keep its specific style)
            // btnRefresh is already styled, we can leave it or refine it.
            
            // Style KPI Cards
            StyleKpiPanel(pnlActiveRentals);
            StyleKpiPanel(pnlReturnsDue);
            StyleKpiPanel(pnlAvailableVehicles);
            StyleKpiPanel(pnlMaintenance);
            StyleKpiPanel(pnlTodayRevenue);
            StyleKpiPanel(pnlMonthlyRevenue);

            // Update Grid Container
            pnlGridsContainer.Panel1.BackColor = Color.White;
            pnlGridsContainer.Panel2.BackColor = Color.White;
        }

        private void StyleKpiPanel(Panel panel)
        {
            // Capture the original color to use as the accent strip
            Color accentColor = panel.BackColor;

            // Set card background to White
            panel.BackColor = Color.White;

            // Add Accent Strip
            Panel accentStrip = new Panel
            {
                Size = new Size(5, panel.Height),
                Dock = DockStyle.Left,
                BackColor = accentColor
            };
            panel.Controls.Add(accentStrip);
            accentStrip.BringToFront(); // Ensure it's on the left

            // Style Labels inside
            foreach (Control ctrl in panel.Controls)
            {
                if (ctrl is Label lbl)
                {
                    // Heuristic: If font size is large (> 12), it's the Count/Value => Dark Grey
                    // If small, it's the Title => Medium Grey
                    if (lbl.Font.Size > 12)
                    {
                        lbl.ForeColor = ColorTranslator.FromHtml("#212529"); 
                    }
                    else
                    {
                        lbl.ForeColor = ColorTranslator.FromHtml("#6C757D");
                    }
                }
            }
        }

        /// <summary>
        /// Applies rounded corner styling to KPI card panels.
        /// </summary>
        private void ApplyCardStyling()
        {
             // Deprecated by ApplyTheme logic, but kept empty/minimal if needed for specific paint events
             // Removing the paint handler attachment since we are changing the visuals significantly
        }

        /// <summary>
        /// Paints rounded corners on card panels.
        /// </summary>
        private void Panel_Paint(object sender, PaintEventArgs e)
        {
            if (sender is Panel panel)
            {
                // Create a rounded rectangle path for visual effect
                using (var brush = new SolidBrush(panel.BackColor))
                {
                    e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    // The panel already has its BackColor, this just smooths the rendering
                }
            }
        }

        /// <summary>
        /// Handles the Refresh button click event.
        /// </summary>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDashboardData();
        }
    }
}
