using System.Windows.Forms;
using Vormas.Navigation;
using Vormas.Interfaces;

namespace Vormas.Forms
{
    public partial class RentalAgentDashboard : PageControl
    {
        private readonly ISessionService _session;
        public RentalAgentDashboard(ISessionService session)
        {
            _session = session;
            InitializeComponent();
        }
    }
}