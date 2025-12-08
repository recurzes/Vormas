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

            var dbContext = new UserDbContext();
            IUserManager userManager = new UserManager(dbContext);
            IAuthService authService = new AuthManager(userManager);
            
            Application.Run(new UserLoginForm(authService));
        }
    }
}
