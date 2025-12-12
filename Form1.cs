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
        public Form1()
        {
            InitializeComponent();
            InitializeNavigation();
        }

        private void InitializeNavigation()
        {
            var dbContext = new UserDbContext();
            IUserManager userManager = new UserManager(dbContext);
            ISessionService sessionService = new SessionService();
            IAuthService authService = new AuthManager(userManager, sessionService);
            var routes = new Dictionary<string, Func<PageControl>>
            {
                { "user_login", () => new UserLoginForm(authService, sessionService) },
                {"user_register", () => new UserRegisterForm(userManager, authService)},
                {"rental_agent_dashboard", () => new RentalAgentDashboard()},
                {"admin_dashboard", () => new AdminDashboard()},
            };

            _navigation = new NavigationService(contentHost, routes);
            
            _navigation.Navigate("user_login");
        }

        public INavigationService Navigator => _navigation;
    }
}
