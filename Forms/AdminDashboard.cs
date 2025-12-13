using System.Windows.Forms;
using Vormas.Navigation;
using Vormas.Interfaces;

namespace Vormas.Forms
{
    public partial class AdminDashboard : PageControl
    {
        private readonly ISessionService _session;
        public AdminDashboard(ISessionService session)
        {
            _session = session;
            InitializeComponent();
        }
    }
}