using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Vormas.Database;
using Vormas.Forms;
using Vormas.Interfaces;
using Vormas.Navigation;
using Vormas.Services;

namespace Vormas
{
    public partial class Form1 : Form
    {
        private INavigationService _navigation;
        private readonly IUserManager _userManager;
        private readonly IAuthService _authService;
        private readonly ISessionService _sessionService;

        public Form1(IUserManager userManager, IAuthService authService, ISessionService sessionService)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));
            _sessionService = sessionService ?? throw new ArgumentNullException(nameof(sessionService));

            InitializeComponent();
            InitializeNavigation();
        }

        private void InitializeNavigation()
        {
            // Phase A: create mutable routes registry and register routes that don't need INavigationService
            var routes = new Dictionary<string, Func<PageControl>>
            {
                { Routes.UserRegister, () => new UserRegisterForm(_userManager, _authService) },
                { Routes.RentalAgentDashboard, () => new RentalAgentDashboard(_sessionService) },
                { Routes.AdminDashboard, () => new AdminDashboard(_sessionService) },
            };

            
            _navigation = new NavigationService(contentHost, routes);

            
            routes[Routes.UserLogin] = () => new UserLoginForm(_authService, _sessionService, _navigation);
            
            _navigation.Navigate(Routes.UserLogin);
        }

        public INavigationService Navigator => _navigation;
    }
}
