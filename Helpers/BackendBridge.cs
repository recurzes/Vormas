using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Vormas.Interfaces;

namespace Vormas.Helpers
{
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ComVisible(true)]
    public class BackendBridge
    {
        private readonly ISessionService _session;
        private readonly ICustomerService _customerService;
        private readonly IVehicleService _vehicleService;
        private readonly IReservationService _reservationService;
        private readonly IRentalService _rentalService;
        private readonly IDamageClaimsService _damageClaimsService;
        private readonly IBillingService _billingService;
        private readonly IUserManager _userManager;

        public BackendBridge(
            ISessionService session,
            ICustomerService customerService = null,
            IVehicleService vehicleService = null,
            IReservationService reservationService = null,
            IRentalService rentalService = null,
            IDamageClaimsService damageClaimsService = null,
            IBillingService billingService = null,
            IUserManager userManager = null)
        {
            _session = session;
            _customerService = customerService;
            _vehicleService = vehicleService;
            _reservationService = reservationService;
            _rentalService = rentalService;
            _damageClaimsService = damageClaimsService;
            _billingService = billingService;
            _userManager = userManager;
        }

        public string GetUserProfile()
        {
            if (_session == null || _session.CurrentUser == null) 
            {
                return "{\"error\": \"No active session\"}";
            }
            
            var u = _session.CurrentUser;
            var dob = u.DateOfBirth.ToString("yyyy-MM-dd");
            
            return $@"{{
                ""firstName"": ""{Escape(u.FirstName)}"",
                ""lastName"": ""{Escape(u.LastName)}"",
                ""email"": ""{Escape(u.Email)}"",
                ""phone"": ""{Escape(u.Phone)}"",
                ""dateOfBirth"": ""{dob}"",
                ""username"": ""{Escape(u.UserName)}"",
                ""roleId"": {u.RoleId}
            }}";
        }

        public string UpdateUserProfile(string json)
        {
            if (_session == null || _session.CurrentUser == null) return "{\"error\": \"No active session\"}";
            if (_userManager == null) return "{\"error\": \"UserManager not available\"}";

            try 
            {
                var dict = ParseSimpleJson(json);
                var user = _session.CurrentUser;

                if (dict.ContainsKey("firstName")) user.FirstName = dict["firstName"];
                if (dict.ContainsKey("lastName")) user.LastName = dict["lastName"];
                if (dict.ContainsKey("email")) user.Email = dict["email"];
                if (dict.ContainsKey("phone")) user.Phone = dict["phone"];
                if (dict.ContainsKey("dateOfBirth") && DateTime.TryParse(dict["dateOfBirth"], out var dob)) user.DateOfBirth = dob;

                _userManager.UpdateUser(user);
                
                return "{\"success\": true}";
            }
            catch (Exception ex)
            {
                return $"{{\"error\": \"{Escape(ex.Message)}\"}}";
            }
        }

        private Dictionary<string, string> ParseSimpleJson(string json)
        {
            var dict = new Dictionary<string, string>();
            if (string.IsNullOrEmpty(json)) return dict;
            
            json = json.Trim().Trim('{', '}');
            var pairs = json.Split(',');
            foreach (var pair in pairs)
            {
                var parts = pair.Split(':');
                if (parts.Length >= 2)
                {
                    var key = parts[0].Trim().Trim('"');
                    var value = string.Join(":", parts, 1, parts.Length - 1).Trim().Trim('"');
                    dict[key] = value;
                }
            }
            return dict;
        }

        private string Escape(string s) => s?.Replace("\"", "\\\"").Replace("\r", "").Replace("\n", "") ?? "";

        public string GetCustomers() => "[]";
        public string GetVehicles() => "[]";
        public string GetPendingReservations() => "[]";
        public string GetActiveRentals() => "[]";
        public string GetUnpaidInvoices() => "[]";
        public string GetReportData() => "{}";
        public string GetDashboardStats() => "{}";
        
        public string CreateReservation(string json) => "{\"success\": false, \"message\": \"Not implemented\"}";
        public string CreateRental(string json) => "{\"success\": false, \"message\": \"Not implemented\"}";
        public string CompleteRental(string json) => "{\"success\": false, \"message\": \"Not implemented\"}";
        public string ProcessPayment(string json) => "{\"success\": false, \"message\": \"Not implemented\"}";
        public string LogMaintenance(string json) => "{\"success\": false, \"message\": \"Not implemented\"}";
        public string CompleteMaintenance(int id) => "{\"success\": false, \"message\": \"Not implemented\"}";
    }
}
