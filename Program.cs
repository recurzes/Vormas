using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vormas.Database;
using Vormas.Forms;
using Vormas.Interfaces;
using Vormas.Services;

namespace Vormas
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            // Manual composition / DI
            var dbContext = new UserDbContext();
            var customerDbContext = new CustomerDbContext();
            var damageClaimsDbContext = new DamageClaimsDbContext();
            IRateConfigurationService rateConfigurationService = new RateConfigurationDbContext();
            ICustomerRepository customerRepository = new CustomerRepository(customerDbContext);
            IVehicleRepository vehicleRepository = new VehicleDbContext();
            IUserManager userManager = new UserManager(dbContext);
            ISessionService sessionService = new SessionService();
            IAuthService authService = new AuthManager(userManager, sessionService);
            VehicleService vehicleService = new VehicleService(vehicleRepository);
            ICustomerService customerService = new CustomerService(customerRepository);
            IDamageClaimsService damageClaimsService = new DamageClaimsService(damageClaimsDbContext);
            IRentalRepository rentalRepository = new RentalDbContext();
            IRentalService rentalService = new RentalService(rentalRepository);
            var billingDbContext = new BillingDbContext();
            IBillingService billingService = new BillingService(billingDbContext);
            IReservationRepository reservationRepository = new ReservationDbContext();
            IReservationService reservationService = new ReservationService(reservationRepository);
            
            Application.Run(new Form1(userManager, authService, sessionService, vehicleService, customerService, rateConfigurationService, damageClaimsService, rentalService, billingService, reservationService));
        }
    }
}
