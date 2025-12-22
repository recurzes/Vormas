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
            IVehicleRepository vehicleRepository = new VehicleDbContext();
            IUserManager userManager = new UserManager(dbContext);
            ISessionService sessionService = new SessionService();
            IAuthService authService = new AuthManager(userManager, sessionService);
            VehicleService vehicleService = new VehicleService(vehicleRepository);
            
            Application.Run(new Form1(userManager, authService, sessionService, vehicleService));
        }
    }
}
