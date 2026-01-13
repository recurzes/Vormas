using System;
using System.Runtime.InteropServices;
using System.Web.Script.Serialization;
using Vormas.Interfaces;
using Vormas.Models;
using System.Collections.Generic;
using System.Linq;

namespace Vormas.Services
{
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ComVisible(true)]
    public class BackendBridge
    {
        private readonly ICustomerService _customerService;
        private readonly IVehicleService _vehicleService;
        private readonly IReservationService _reservationService;
        private readonly JavaScriptSerializer _serializer;

        public BackendBridge(
            ICustomerService customerService, 
            IVehicleService vehicleService, 
            IReservationService reservationService)
        {
            _customerService = customerService;
            _vehicleService = vehicleService;
            _reservationService = reservationService;
            _serializer = new JavaScriptSerializer();
        }

        public string GetCustomers()
        {
            try 
            {
                var customers = _customerService.GetAll();
                // Select simple object for frontend
                var dtos = customers.Select(c => new { 
                    id = c.CustomerId, 
                    name = $"{c.FirstName} {c.LastName}" 
                }).ToList();
                return _serializer.Serialize(dtos);
            }
            catch (Exception ex)
            {
                return _serializer.Serialize(new { error = ex.Message });
            }
        }

        public string GetVehicles()
        {
            try
            {
                // In a real app we might filter by availability dates here, but for now returned all
                var vehicles = _vehicleService.GetAllVehicles();
                var dtos = vehicles.Select(v => new { 
                    id = v.VehicleId, 
                    display = $"{v.Make} {v.Model} ({v.LicensePlate})" 
                }).ToList();
                return _serializer.Serialize(dtos);
            }
            catch (Exception ex)
            {
                return _serializer.Serialize(new { error = ex.Message });
            }
        }

        public string CreateReservation(string json)
        {
            try
            {
                // Deserialize partial object
                var data = _serializer.Deserialize<Dictionary<string, object>>(json);
                
                int customerId = Convert.ToInt32(data["customerId"]);
                int vehicleId = Convert.ToInt32(data["vehicleId"]);
                DateTime startDate = Convert.ToDateTime(data["startDate"]);
                DateTime endDate = Convert.ToDateTime(data["endDate"]);

                // Validation
                if (startDate.Date < DateTime.Today) return _serializer.Serialize(new { success = false, message = "Start date cannot be in the past." });
                if (endDate < startDate) return _serializer.Serialize(new { success = false, message = "End date cannot be before start date." });

                bool available = _reservationService.IsVehicleAvailable(vehicleId, startDate, endDate);
                if (!available) return _serializer.Serialize(new { success = false, message = "Vehicle not available for these dates." });

                var reservation = new Reservation
                {
                    CustomerId = customerId,
                    VehicleId = vehicleId,
                    StartDate = startDate,
                    EndDate = endDate,
                    Status = "Pending"
                };

                _reservationService.CreateReservation(reservation);
                return _serializer.Serialize(new { success = true, message = "Reservation created successfully!" });
            }
            catch (Exception ex)
            {
                return _serializer.Serialize(new { success = false, message = ex.Message });
            }
        }

        // --- Rental Methods ---
        private readonly IRentalService _rentalService;
        private readonly IMaintenanceService _maintenanceService;

        // Updated Constructor
        public BackendBridge(
            ICustomerService customerService, 
            IVehicleService vehicleService, 
            IReservationService reservationService,
            IRentalService rentalService,
            IMaintenanceService maintenanceService)
        {
            _customerService = customerService;
            _vehicleService = vehicleService;
            _reservationService = reservationService;
            _rentalService = rentalService;
            _maintenanceService = maintenanceService;
            _serializer = new JavaScriptSerializer();
        }

        public string GetPendingReservations()
        {
            try
            {
                var reservations = _reservationService.GetReservations().Where(r => r.Status == "Pending").ToList();
                var dtos = reservations.Select(r => new {
                    id = r.ReservationId,
                    display = $"#{r.ReservationId} - {r.CustomerName} ({r.StartDate:d} - {r.EndDate:d})",
                    customerId = r.CustomerId,
                    vehicleId = r.VehicleId,
                    customerName = r.CustomerName,
                    vehicleModel = r.VehicleModel
                });
                return _serializer.Serialize(dtos);
            }
            catch (Exception ex) { return _serializer.Serialize(new { error = ex.Message }); }
        }

        public string CreateRental(string json)
        {
            try
            {
                var data = _serializer.Deserialize<Dictionary<string, object>>(json);
                var rental = new Rental
                {
                    ReservationId = Convert.ToInt32(data["reservationId"]),
                    VehicleId = Convert.ToInt32(data["vehicleId"]),
                    CustomerId = Convert.ToInt32(data["customerId"]),
                    ActualStartDate = DateTime.Now,
                    StartMileage = Convert.ToInt32(data["startMileage"])
                };

                _rentalService.CreateRental(rental);
                return _serializer.Serialize(new { success = true, message = "Rental created successfully!" });
            }
            catch (Exception ex) { return _serializer.Serialize(new { success = false, message = ex.Message }); }
        }

        // --- Return Methods ---
        public string GetActiveRentals()
        {
            try
            {
                var dt = _rentalService.GetActiveRentals();
                var list = new List<Dictionary<string, object>>();
                foreach (System.Data.DataRow row in dt.Rows)
                {
                    var dict = new Dictionary<string, object>();
                    foreach (System.Data.DataColumn col in dt.Columns) dict[col.ColumnName] = row[col];
                    // Add standard display property
                    dict["display"] = $"Rental #{row["RentalId"]} - {row["CustomerName"]} ({row["VehicleName"]})";
                    list.Add(dict);
                }
                return _serializer.Serialize(list);
            }
            catch (Exception ex) { return _serializer.Serialize(new { error = ex.Message }); }
        }

        public string CompleteRental(string json)
        {
            try
            {
                var data = _serializer.Deserialize<Dictionary<string, object>>(json);
                int id = Convert.ToInt32(data["rentalId"]);
                int mileage = Convert.ToInt32(data["endMileage"]);
                double fuel = Convert.ToDouble(data["fuelLevel"]);
                _rentalService.CompleteRental(id, DateTime.Now, mileage, fuel);
                return _serializer.Serialize(new { success = true, message = "Rental completed/returned successfully!" });
            }
            catch (Exception ex) { return _serializer.Serialize(new { success = false, message = ex.Message }); }
        }

        // --- Billing Methods ---
        public string GetUnpaidInvoices()
        {
            try
            {
                var dt = _rentalService.GetUnpaidRentals();
                var list = new List<Dictionary<string, object>>();
                foreach (System.Data.DataRow row in dt.Rows)
                {
                    var dict = new Dictionary<string, object>();
                    foreach (System.Data.DataColumn col in dt.Columns) dict[col.ColumnName] = row[col];
                    dict["display"] = $"Rental #{row["RentalId"]} - {row["CustomerName"]} (Due: {row["BalanceDue"]})";
                    list.Add(dict);
                }
                return _serializer.Serialize(list);
            }
            catch (Exception ex) { return _serializer.Serialize(new { error = ex.Message }); }
        }

        public string ProcessPayment(string json)
        {
            try
            {
                var data = _serializer.Deserialize<Dictionary<string, object>>(json);
                int id = Convert.ToInt32(data["rentalId"]);
                decimal amount = Convert.ToDecimal(data["amount"]);
                string method = Convert.ToString(data["method"]);
                _rentalService.ProcessPayment(id, amount, method);
                return _serializer.Serialize(new { success = true, message = "Payment processed successfully!" });
            }
            catch (Exception ex) { return _serializer.Serialize(new { success = false, message = ex.Message }); }
        }

        // --- Maintenance Methods ---
        public string LogMaintenance(string json)
        {
            try
            {
                var data = _serializer.Deserialize<Dictionary<string, object>>(json);
                int vid = Convert.ToInt32(data["vehicleId"]);
                string desc = Convert.ToString(data["description"]);
                decimal cost = Convert.ToDecimal(data["cost"]);
                _maintenanceService.LogMaintenance(vid, desc, cost);
                return _serializer.Serialize(new { success = true, message = "Maintenance logged." });
            }
            catch (Exception ex) { return _serializer.Serialize(new { success = false, message = ex.Message }); }
        }

        public string CompleteMaintenance(int vehicleId)
        {
            try
            {
                _maintenanceService.CompleteMaintenance(vehicleId);
                return _serializer.Serialize(new { success = true, message = "Vehicle maintenance completed." });
            }
            catch (Exception ex) { return _serializer.Serialize(new { success = false, message = ex.Message }); }
        }

        // --- Reports Methods ---
        public string GetReportData()
        {
            try
            {
                var stats = _rentalService.GetReportStats();
                var recentDt = _rentalService.GetRecentRentals();
                var recentList = new List<Dictionary<string, object>>();
                foreach (System.Data.DataRow row in recentDt.Rows)
                {
                    var dict = new Dictionary<string, object>();
                    foreach (System.Data.DataColumn col in recentDt.Columns) dict[col.ColumnName] = row[col].ToString(); // Date to string
                    recentList.Add(dict);
                }

                return _serializer.Serialize(new { 
                    stats = stats, 
                    recent = recentList 
                });
            }
            catch (Exception ex) { return _serializer.Serialize(new { error = ex.Message }); }
        }
        public string GetDashboardStats()
        {
            try
            {
                var counts = _rentalService.GetDashboardCounts();
                return _serializer.Serialize(counts);
            }
            catch (Exception ex) { return _serializer.Serialize(new { error = ex.Message }); }
        }
    }
}
