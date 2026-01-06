using System.Windows.Forms;
using Vormas.Navigation;
using Vormas.Interfaces;

namespace Vormas.Forms
{
    public partial class AdminDashboard : PageControl
    {
        private readonly ISessionService _session;
        private readonly INavigationService _navigation;

        public AdminDashboard(ISessionService session, INavigationService navigation)
        {
            _session = session;
            _navigation = navigation;
            InitializeComponent();
        }

        private void btnManageVehicles_Click(object sender, System.EventArgs e)
        {
            _navigation.Navigate(Routes.Vehicles);
        }
    }
}