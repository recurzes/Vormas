using System;
using System.Windows.Forms;
using Vormas.Forms.Pages;
using Vormas.Helpers;
using Vormas.Navigation;
using Vormas.Interfaces;

namespace Vormas.Forms
{
    public partial class AdminDashboard : PageControl
    {
        private readonly ISessionService _session;
        private readonly UserControls _controls;
        private readonly IAuthService _authService;
        private readonly IUserManager _userManager;
        private readonly IVehicleService _vehicleService;
        private readonly IRateConfigurationService _rateConfigurationService;
        public AdminDashboard(ISessionService session, IAuthService authService, IUserManager userManager, IVehicleService vehicleService, IRateConfigurationService rateConfigurationService)
        {
            _session = session;
            InitializeComponent();
            _controls = new UserControls();
            _authService = authService;
            _userManager = userManager;
            _vehicleService = vehicleService;
            _rateConfigurationService = rateConfigurationService;
        }

        private void btnDamageClaims_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void btnUserManagement_Click(object sender, EventArgs e)
        {
            _controls.LoadUserControl(pnlPages, new UserManagementControl(_authService, _userManager));
        }

        private void btnFleetManagement_Click(object sender, EventArgs e)
        {
            _controls.LoadUserControl(pnlPages, new VehicleForm(_vehicleService));
        }

        private void btnRateManagement_Click(object sender, EventArgs e)
        {
            _controls.LoadUserControl(pnlPages, new RateConfigurationForm(_rateConfigurationService));
        }
    }
}