using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Vormas.Database;
using Vormas.Forms;
using Vormas.Forms.Temp;
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
        private readonly IVehicleService _vehicleService;
        private readonly ICustomerService _customerService;

        public Form1(IUserManager userManager, IAuthService authService, ISessionService sessionService, IVehicleService vehicleService, ICustomerService customerService)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));
            _sessionService = sessionService ?? throw new ArgumentNullException(nameof(sessionService));
            _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
            _vehicleService = vehicleService;

            InitializeComponent();
            InitializeNavigation();
        }

        private void InitializeNavigation()
        {
            var routes = new Dictionary<string, Func<PageControl>>
            {
                { Routes.UserRegister, () => new UserRegisterForm(_userManager, _authService) },
                { Routes.RentalAgentDashboard, () => new RentalAgentDashboard(_sessionService) },
                { Routes.AdminDashboard, () => new AdminDashboard(_sessionService) },
                { Routes.Customers, () => new CustomerForm(_customerService) },
                { Routes.Vehicles, () => new VehicleForm(_vehicleService)},
            };
            
            _navigation = new NavigationService(contentHost, routes);
            
            routes[Routes.UserLogin] = () => new UserLoginForm(_authService, _sessionService, _navigation);
            routes[Routes.TempDashboard] = () => new Dashboard(_navigation);
            
            _navigation.Navigate(Routes.TempDashboard);
        }

        public INavigationService Navigator => _navigation;
    }
}
