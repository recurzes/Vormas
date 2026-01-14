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
        private readonly IRateConfigurationService _rateConfigurationService;
        private readonly IDamageClaimsService _damageClaimsService;
        private readonly IRentalService _rentalService;
        private readonly IBillingService _billingService;
        private readonly IReservationService _reservationService;

        public Form1(IUserManager userManager, IAuthService authService, ISessionService sessionService, IVehicleService vehicleService, ICustomerService customerService, IRateConfigurationService rateConfigurationService, IDamageClaimsService damageClaimsService, IRentalService rentalService, IBillingService billingService, IReservationService reservationService)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));
            _sessionService = sessionService ?? throw new ArgumentNullException(nameof(sessionService));
            _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
            _vehicleService = vehicleService ?? throw new ArgumentNullException(nameof(vehicleService));
            _rateConfigurationService = rateConfigurationService ??
                                        throw new ArgumentNullException(nameof(rateConfigurationService));
            _damageClaimsService = damageClaimsService ?? throw new ArgumentNullException(nameof(damageClaimsService));
            _rentalService = rentalService ?? throw new ArgumentNullException(nameof(rentalService));
            _billingService = billingService ?? throw new ArgumentNullException(nameof(billingService));
            _reservationService = reservationService ?? throw new ArgumentNullException(nameof(reservationService));
            
            InitializeComponent();
            InitializeNavigation();
        }

        private void InitializeNavigation()
        {
            var routes = new Dictionary<string, Func<PageControl>>
            {
                { Routes.UserRegister, () => new UserRegisterForm(_userManager, _authService) },
                { Routes.Customers, () => new CustomerForm(_customerService) },
                { Routes.Vehicles, () => new VehicleForm(_vehicleService)},
                { Routes.DamageClaims, () => new DamageClaimsForm(_damageClaimsService, _sessionService)},
                { Routes.RentalPickup, () => new PickupForm(_rentalService, _sessionService)},
                { Routes.Billing, () => new BillingForm(_billingService, _sessionService)},
                { Routes.Reservation, () => new ReservationForm(_reservationService, _sessionService)},
            };
            
            _navigation = new NavigationService(contentHost, routes);
            
            routes[Routes.UserLogin] = () => new UserLoginForm(_authService, _sessionService, _navigation);
            routes[Routes.TempDashboard] = () => new Dashboard(_navigation);
            routes[Routes.RentalReturn] = () => new ReturnForm(_rentalService, _damageClaimsService, _sessionService, _billingService, _navigation);
            routes[Routes.RentalAgentDashboard] = () => new RentalAgentDashboard(_sessionService, _customerService, _rentalService, _reservationService, _damageClaimsService, _billingService, _navigation, _userManager);
            routes[Routes.AdminDashboard] = () => new AdminDashboard(_sessionService, _authService, _userManager,
                _vehicleService, _rateConfigurationService, _damageClaimsService, _navigation);
            
            _navigation.Navigate(Routes.UserRegister);
        }

        public INavigationService Navigator => _navigation;
    }
}
