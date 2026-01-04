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
        public AdminDashboard(ISessionService session, IAuthService authService, IUserManager userManager)
        {
            _session = session;
            InitializeComponent();
            _controls = new UserControls();
            _authService = authService;
            _userManager = userManager;
        }

        private void btnDamageClaims_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void btnUserManagement_Click(object sender, EventArgs e)
        {
            _controls.LoadUserControl(pnlPages, new UserManagementControl(_authService, _userManager));
        }
    }
}