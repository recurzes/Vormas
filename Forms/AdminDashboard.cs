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
        private readonly INavigationService _navigation;
        private WebViewControl _headerWebView;
        private WebViewControl _contentWebView;
        private Control _currentWinFormsControl;

        public AdminDashboard(ISessionService session, IAuthService authService, IUserManager userManager, IVehicleService vehicleService, IRateConfigurationService rateConfigurationService, IDamageClaimsService damageClaimsService, INavigationService navigation)
        {
            _session = session;
            InitializeComponent();
            _controls = new UserControls();
            _authService = authService;
            _userManager = userManager;
            _vehicleService = vehicleService;
            _rateConfigurationService = rateConfigurationService;
            _damageClaimsService = damageClaimsService;
            _navigation = navigation;
            
            InitializeHybridLayout();
        }

        private void InitializeHybridLayout()
        {
            var bridge = new BackendBridge(_session, null, _vehicleService, null, null, _damageClaimsService, null, _userManager);

            _headerWebView = new WebViewControl("/?mode=header", bridge);
            _headerWebView.Dock = DockStyle.Fill;
            _headerWebView.OnFormRequest += HandleFormRequest;
            pnlHeader.Controls.Add(_headerWebView);
            
            _contentWebView = new WebViewControl("/?mode=content", bridge);
            _contentWebView.Dock = DockStyle.Fill;
            _contentWebView.OnFormRequest += HandleFormRequest;
            pnlContent.Controls.Add(_contentWebView);
        }

        private void HandleFormRequest(object sender, string formName)
        {
            if (formName.StartsWith("navigate:"))
            {
                string route = formName.Substring("navigate:".Length);
                NavigateContent(route);
                return;
            }
            
            switch (formName)
            {
                case "openFleet":
                    ShowWinFormsControl(new VehicleForm(_vehicleService));
                    break;
                case "openUsers":
                    ShowWinFormsControl(new UserManagementControl(_authService, _userManager));
                    break;
                case "openRates":
                    ShowWinFormsControl(new RateConfigurationForm(_rateConfigurationService, _vehicleService));
                    break;
                case "openDamage":
                    ShowWinFormsControl(new DamageClaimsForm(_damageClaimsService, _session));
                    break;
                case "showReact":
                    ShowReactContent();
                    break;
                case "logout":
                    HandleLogout();
                    break;
            }
        }

        private void HandleLogout()
        {
            var result = MessageBox.Show(
                "Are you sure you want to logout?",
                "Logout Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                _session.ClearSession();
                _navigation.Navigate(Routes.UserLogin);
            }
        }

        private void NavigateContent(string route)
        {
            ShowReactContent();
            _contentWebView.NavigateToRoute(route + "?mode=content");
        }

        private void ShowWinFormsControl(Control winFormsControl)
        {
            if (_currentWinFormsControl != null)
            {
                pnlContent.Controls.Remove(_currentWinFormsControl);
                _currentWinFormsControl.Dispose();
            }
            
            _contentWebView.Visible = false;
            
            _currentWinFormsControl = winFormsControl;
            _currentWinFormsControl.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(_currentWinFormsControl);
            _currentWinFormsControl.BringToFront();
        }

        private void ShowReactContent()
        {
            if (_currentWinFormsControl != null)
            {
                pnlContent.Controls.Remove(_currentWinFormsControl);
                _currentWinFormsControl.Dispose();
                _currentWinFormsControl = null;
            }
            
            _contentWebView.Visible = true;
            _contentWebView.BringToFront();
        }
    }
}