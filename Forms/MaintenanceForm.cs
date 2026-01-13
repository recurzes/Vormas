using System;
using System.Linq;
using System.Windows.Forms;
using Vormas.Navigation;
using Vormas.Services;
using Vormas.Interfaces;

namespace Vormas.Forms
{
    public partial class MaintenanceForm : PageControl
    {
        private readonly IMaintenanceService _maintenanceService;
        private readonly IVehicleService _vehicleService;

        public MaintenanceForm(IMaintenanceService maintenanceService, IVehicleService vehicleService)
        {
            InitializeComponent();
            _maintenanceService = maintenanceService ?? throw new ArgumentNullException(nameof(maintenanceService));
            _vehicleService = vehicleService ?? throw new ArgumentNullException(nameof(vehicleService));
            
            // Fix for layout visibility
            this.AutoScroll = true;
            
            LoadVehicles();
            
            // Set default priority
            if (cmbPriority.Items.Count > 0)
                cmbPriority.SelectedIndex = 0;
        }

        private void LoadVehicles()
        {
            try
            {
                var vehicles = _vehicleService.GetAllVehicles();
                var list = vehicles.Select(v => new { v.VehicleId, Display = $"{v.Make} {v.Model} [{v.Status}]" }).ToList();
                cmbVehicles.DataSource = list;
                cmbVehicles.DisplayMember = "Display";
                cmbVehicles.ValueMember = "VehicleId";
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Error loading vehicles: " + ex.Message);
            }
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            if (cmbVehicles.SelectedValue == null) return;
            if (!decimal.TryParse(txtCost.Text, out decimal cost))
            {
                MessageBox.Show(@"Invalid Cost");
                return;
            }

            try
            {
                _maintenanceService.LogMaintenance((int)cmbVehicles.SelectedValue, txtDescription.Text, cost);
                MessageBox.Show(@"Maintenance logged.");
                LoadVehicles();
                txtDescription.Text = "";
                txtCost.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Error: " + ex.Message);
            }
        }

        private void btnFix_Click(object sender, EventArgs e)
        {
            if (cmbVehicles.SelectedValue == null) return;
             try
            {
                _maintenanceService.CompleteMaintenance((int)cmbVehicles.SelectedValue);
                MessageBox.Show(@"Vehicle marked as Available.");
                LoadVehicles();
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Error: " + ex.Message);
            }
        }
    }
}
