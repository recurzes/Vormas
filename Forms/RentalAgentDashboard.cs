using System;
using System.Drawing;
using System.Windows.Forms;
using Vormas.Navigation;
using Vormas.Services;
using Vormas.Interfaces;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using System.Text.RegularExpressions;

namespace Vormas.Forms
{
    public partial class RentalAgentDashboard : PageControl
    {
        private readonly ISessionService _session;
        // Dependencies for child pages
        private readonly IReservationService _reservationService;
        private readonly IVehicleService _vehicleService;
        private readonly ICustomerService _customerService;
        private readonly IRentalService _rentalService;
        private readonly IMaintenanceService _maintenanceService;

        private WebView2 _webView;
        private string _baseUrl = "http://localhost:5173";

        public RentalAgentDashboard(
            ISessionService session, 
            IReservationService reservationService,
            IVehicleService vehicleService,
            ICustomerService customerService,
            IRentalService rentalService)
        {
            _session = session;
            _reservationService = reservationService;
            _vehicleService = vehicleService;
            _customerService = customerService;
            _rentalService = rentalService;
            _maintenanceService = new MaintenanceService(); // Local for now
            
            InitializeComponent();
            InitializeWebView();
        }

        private async void InitializeWebView()
        {
            this.Controls.Clear();
            _webView = new WebView2
            {
                Dock = DockStyle.Fill
            };
            this.Controls.Add(_webView);

            try
            {
                await _webView.EnsureCoreWebView2Async(null);
                
                // Allow host objects
                _webView.CoreWebView2.Settings.AreHostObjectsAllowed = true;

                // Inject Bridge
                var bridge = new BackendBridge(_customerService, _vehicleService, _reservationService, _rentalService, _maintenanceService);
                _webView.CoreWebView2.AddHostObjectToScript("backend", bridge);
                
                // Add event handler for messages from React
                _webView.WebMessageReceived += WebView_WebMessageReceived;

                // Navigate to Agent Dashboard
                _webView.CoreWebView2.Navigate($"{_baseUrl}/agent");
            }
            catch (Exception ex)
            {
               MessageBox.Show($"Failed to load Web Dashboard. Ensure 'npm run dev' is running in Web folder.\n\nError: {ex.Message}");
            }
        }

        private void WebView_WebMessageReceived(object sender, CoreWebView2WebMessageReceivedEventArgs e)
        {
            try
            {
                // Message format: { "action": "navigate", "target": "ReservationForm" }
                var json = e.WebMessageAsJson;
                
                // Simple parsing using Regex to avoid new dependencies
                var actionMatch = Regex.Match(json, "\"action\"\\s*:\\s*\"([^\"]+)\"");
                var targetMatch = Regex.Match(json, "\"target\"\\s*:\\s*\"([^\"]+)\"");

                if (actionMatch.Success && actionMatch.Groups[1].Value == "navigate" && targetMatch.Success)
                {
                    string target = targetMatch.Groups[1].Value;
                    HandleNavigation(target);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error processing web message: " + ex.Message);
            }
        }

        private void HandleNavigation(string target)
        {
            PageControl page = null;
            switch (target)
            {
                case "ReservationForm":
                     page = new ReservationForm(_reservationService, _vehicleService, _customerService);
                     break;
                case "RentalForm":
                     page = new RentalForm(_rentalService, _reservationService, _vehicleService);
                     break;
                case "ReturnForm":
                     page = new ReturnForm(_rentalService); 
                     break;
                case "BillingForm":
                     page = new BillingForm(_rentalService);
                     break;
                case "MaintenanceForm":
                     page = new MaintenanceForm(_maintenanceService,  _vehicleService);
                     break;
                case "ReportsForm":
                     page = new ReportsForm(); 
                     break;
                default:
                    MessageBox.Show($"Unknown Target: {target}");
                    return;
            }

            if (page != null)
            {
                ShowPage(page);
            }
        }

        private void ShowPage(PageControl page)
        {
            // Hide WebView
            _webView.Visible = false;
            
            // Add Page
            page.Dock = DockStyle.Fill;
            this.Controls.Add(page);
            page.BringToFront();

            // Add a temporary top bar for navigation back
            Panel topPanel = new Panel { Dock = DockStyle.Top, Height = 40, BackColor = Color.WhiteSmoke };
            Button btnBack = new Button { Text = "← Back to Dashboard", Bounds = new Rectangle(10, 5, 140, 30), BackColor = Color.White };
            btnBack.Click += (s, e) => {
                this.Controls.Remove(page);
                this.Controls.Remove(topPanel);
                page.Dispose(); 
                _webView.Visible = true;
            };
            topPanel.Controls.Add(btnBack);
            this.Controls.Add(topPanel);
            topPanel.BringToFront();
        }
    }
}