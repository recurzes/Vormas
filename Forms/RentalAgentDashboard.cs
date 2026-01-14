using System;
using System.Windows.Forms;
using Vormas.Forms.Controls;
using Vormas.Interfaces;
using Vormas.Navigation;

namespace Vormas.Forms
{
    public partial class RentalAgentDashboard : PageControl
    {
        private readonly ISessionService _session;
        private readonly ICustomerService _customerService;
        private readonly IRentalService _rentalService;
        private readonly IReservationService _reservationService;
        private readonly IDamageClaimsService _damageClaimsService;
        private readonly IBillingService _billingService;
        private readonly INavigationService _navigationService;
        private WebViewControl _headerWebView;
        private WebViewControl _contentWebView;
        private Control _currentWinFormsControl;

        public RentalAgentDashboard(
            ISessionService session,
            ICustomerService customerService,
            IRentalService rentalService,
            IReservationService reservationService,
            IDamageClaimsService damageClaimsService,
            IBillingService billingService,
            INavigationService navigationService)
        {
            _session = session;
            _customerService = customerService;
            _rentalService = rentalService;
            _reservationService = reservationService;
            _damageClaimsService = damageClaimsService;
            _billingService = billingService;
            _navigationService = navigationService;

            InitializeComponent();
            InitializeHybridLayout();
        }

        private void InitializeHybridLayout()
        {
            _headerWebView = new WebViewControl("/?mode=agent-header");
            _headerWebView.Dock = DockStyle.Fill;
            _headerWebView.OnFormRequest += HandleFormRequest;
            pnlHeader.Controls.Add(_headerWebView);

            _contentWebView = new WebViewControl("/analytics?mode=content");
            _contentWebView.Dock = DockStyle.Fill;
            _contentWebView.OnFormRequest += HandleFormRequest;
            pnlContent.Controls.Add(_contentWebView);
        }

        private void HandleFormRequest(object sender, string formName)
        {
            if (formName.StartsWith("navigate:"))
            {
                string route = formName.Substring("navigate:".Length);
                NavigateContent(route);
                return;
            }

            switch (formName)
            {
                case "openCustomers":
                    ShowWinFormsControl(new CustomerForm(_customerService));
                    break;
                case "openRent":
                    ShowWinFormsControl(new PickupForm(_rentalService, _session));
                    break;
                case "openReserve":
                    ShowWinFormsControl(new ReservationForm(_reservationService, _session));
                    break;
                case "openReturn":
                    ShowWinFormsControl(new ReturnForm(_rentalService, _damageClaimsService, _session, _billingService, _navigationService));
                    break;
                case "showReact":
                    ShowReactContent();
                    break;
            }
        }

        private void NavigateContent(string route)
        {
            ShowReactContent();
            _contentWebView.NavigateToRoute(route + "?mode=content");
        }

        private void ShowWinFormsControl(Control winFormsControl)
        {
            if (_currentWinFormsControl != null)
            {
                pnlContent.Controls.Remove(_currentWinFormsControl);
                _currentWinFormsControl.Dispose();
            }

            _contentWebView.Visible = false;

            _currentWinFormsControl = winFormsControl;
            _currentWinFormsControl.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(_currentWinFormsControl);
            _currentWinFormsControl.BringToFront();
        }

        private void ShowReactContent()
        {
            if (_currentWinFormsControl != null)
            {
                pnlContent.Controls.Remove(_currentWinFormsControl);
                _currentWinFormsControl.Dispose();
                _currentWinFormsControl = null;
            }

            _contentWebView.Visible = true;
            _contentWebView.BringToFront();
        }
    }
}