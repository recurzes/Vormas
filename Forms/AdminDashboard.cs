using System;
using System.Windows.Forms;
using Vormas.Forms.Pages;
using Vormas.Forms.Controls;
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
        private readonly IDamageClaimsService _damageClaimsService;
        private WebViewControl _webViewControl;
        private Control _currentWinFormsControl;

        public AdminDashboard(ISessionService session, IAuthService authService, IUserManager userManager, IVehicleService vehicleService, IRateConfigurationService rateConfigurationService, IDamageClaimsService damageClaimsService)
        {
            _session = session;
            InitializeComponent();
            _controls = new UserControls();
            _authService = authService;
            _userManager = userManager;
            _vehicleService = vehicleService;
            _rateConfigurationService = rateConfigurationService;
            _damageClaimsService = damageClaimsService;
            
            _webViewControl = new WebViewControl("/");
            _webViewControl.Dock = DockStyle.Fill;
            _webViewControl.OnFormRequest += HandleFormRequest;
            pnlWebView.Controls.Add(_webViewControl);
        }

        private void HandleFormRequest(object sender, string formName)
        {
            switch (formName)
            {
                case "openFleet":
                    ShowWinFormsControl(new VehicleForm(_vehicleService));
                    break;
                case "openUsers":
                    ShowWinFormsControl(new UserManagementControl(_authService, _userManager));
                    break;
                case "openRates":
                    ShowWinFormsControl(new RateConfigurationForm(_rateConfigurationService));
                    break;
                case "openDamage":
                    ShowWinFormsControl(new DamageClaimsForm(_damageClaimsService, _session));
                    break;
                case "showReact":
                    ShowReactContent();
                    break;
            }
        }

        private void ShowWinFormsControl(Control winFormsControl)
        {
            if (_currentWinFormsControl != null)
            {
                pnlWinForms.Controls.Remove(_currentWinFormsControl);
                _currentWinFormsControl.Dispose();
            }
            
            _currentWinFormsControl = winFormsControl;
            _currentWinFormsControl.Dock = DockStyle.Fill;
            pnlWinForms.Controls.Add(_currentWinFormsControl);
            
            pnlWinForms.Visible = true;
            pnlWinForms.BringToFront();
        }

        private void ShowReactContent()
        {
            pnlWinForms.Visible = false;
            
            if (_currentWinFormsControl != null)
            {
                pnlWinForms.Controls.Remove(_currentWinFormsControl);
                _currentWinFormsControl.Dispose();
                _currentWinFormsControl = null;
            }
        }
    }
}