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
            
            // Shared Data Contexts
            var userDbContext = new UserDbContext();
            var vehicleDbContext = new VehicleDbContext();
            var customerDbContext = new CustomerDbContext();
            var reservationDbContext = new ReservationDbContext();

            // Services / Repositories
            IUserManager userManager = new UserManager(userDbContext);
            ISessionService sessionService = new SessionService();
            IAuthService authService = new AuthManager(userManager, sessionService);
            
            IVehicleRepository vehicleRepo = vehicleDbContext;
            IVehicleService vehicleService = new VehicleService(vehicleRepo);
            
            ICustomerManager customerManager = new CustomerManager(customerDbContext);
            IReservationRepository reservationRepo = reservationDbContext;
            IReservationService reservationService = new ReservationService(reservationRepo);
            
            // To run the Main Application:
            //Application.Run(new Form1(userManager, authService, sessionService, vehicleService));
            Application.Run(new ReservationForm(reservationService, vehicleRepo, customerManager));

            // To run the Reservation Form properly (Test Mode):
            // Application.Run(new ReservationForm(reservationService, vehicleRepo, customerManager));
        }
    }
}
