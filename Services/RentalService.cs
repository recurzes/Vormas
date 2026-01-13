using System;
using System.Configuration;
using Vormas.Database;
using Vormas.Models;
using MySql.Data.MySqlClient;

namespace Vormas.Services
{
    public interface IRentalService
    {
        void CreateRental(Rental rental);
        void CompleteRental(int rentalId, DateTime returnDate, int endMileage, double fuelLevelEnd);
        System.Data.DataTable GetActiveRentals();
        System.Data.DataTable GetUnpaidRentals();
        void ProcessPayment(int rentalId, decimal amount, string method);
        System.Collections.Generic.Dictionary<string, object> GetReportStats();
        System.Data.DataTable GetRecentRentals();
        System.Collections.Generic.Dictionary<string, int> GetDashboardCounts();
    }

    public class RentalService : IRentalService
    {
        private readonly string _connectionString;

        public RentalService()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"]?.ConnectionString 
                                ?? "Server=localhost;Database=VormasDb;Uid=root;Pwd=password;";
        }

        public void CreateRental(Rental rental)
        {
            // Transaction to ensure Rental creation and Vehicle Status update happen together
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                using (var trans = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Create Rental
                        string insertRental = @"
                            INSERT INTO Rentals (ReservationId, VehicleId, CustomerId, PickupDate, OdometerStart, FuelLevelStart, Status, CreatedAt)
                            VALUES (@ReservationId, @VehicleId, @CustomerId, @PickupDate, @OdometerStart, @FuelLevelStart, 'Active', NOW());
                            SELECT LAST_INSERT_ID();";

                        int rentalId;
                        using (var cmd = new MySqlCommand(insertRental, conn, trans))
                        {
                            cmd.Parameters.AddWithValue("@ReservationId", rental.ReservationId);
                            cmd.Parameters.AddWithValue("@VehicleId", rental.VehicleId);
                            cmd.Parameters.AddWithValue("@CustomerId", rental.CustomerId);
                            cmd.Parameters.AddWithValue("@PickupDate", rental.ActualStartDate);
                            cmd.Parameters.AddWithValue("@OdometerStart", rental.StartMileage);
                            cmd.Parameters.AddWithValue("@FuelLevelStart", 100); // Default full or pass in
                            
                            rentalId = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        // 2. Update Vehicle Status
                        string updateVehicle = "UPDATE Vehicles SET Status = 'Rented', UpdatedAt = NOW() WHERE VehicleId = @VehicleId";
                        using (var cmd = new MySqlCommand(updateVehicle, conn, trans))
                        {
                            cmd.Parameters.AddWithValue("@VehicleId", rental.VehicleId);
                            cmd.ExecuteNonQuery();
                        }
                        
                        // 3. Update Reservation Status
                        string updateReservation = "UPDATE Reservations SET Status = 'Completed' WHERE ReservationId = @ReservationId";
                        using (var cmd = new MySqlCommand(updateReservation, conn, trans))
                        {
                            cmd.Parameters.AddWithValue("@ReservationId", rental.ReservationId);
                            cmd.ExecuteNonQuery();
                        }

                        trans.Commit();
                        rental.RentalId = rentalId;
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }

        public void CompleteRental(int rentalId, DateTime returnDate, int endMileage, double fuelLevelEnd)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                
                // 1. Get Rental Details to calculate cost
                string getRentalSql = @"
                    SELECT r.PickupDate, v.CurrentRate 
                    FROM Rentals r
                    JOIN Vehicles v ON r.VehicleId = v.VehicleId
                    WHERE r.RentalId = @RentalId";
                
                DateTime pickupDate = DateTime.Now;
                decimal dailyRate = 0;

                using (var cmd = new MySqlCommand(getRentalSql, conn))
                {
                    cmd.Parameters.AddWithValue("@RentalId", rentalId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            pickupDate = Convert.ToDateTime(reader["PickupDate"]);
                            dailyRate = Convert.ToDecimal(reader["CurrentRate"]);
                        }
                    }
                }

                // Calculate Cost
                var days = (returnDate - pickupDate).Days;
                if (days < 1) days = 1; // Minimum 1 day charge
                decimal totalAmount = days * dailyRate;

                using (var trans = conn.BeginTransaction())
                {
                    try
                    {
                        // 2. Update Rental
                        string updateRental = @"
                            UPDATE Rentals 
                            SET ReturnDate = @ReturnDate, 
                                OdometerEnd = @EndMileage, 
                                FuelLevelEnd = @FuelLevelEnd, 
                                TotalAmount = @TotalAmount, 
                                Status = 'Completed' 
                            WHERE RentalId = @RentalId";

                        using (var cmd = new MySqlCommand(updateRental, conn, trans))
                        {
                            cmd.Parameters.AddWithValue("@RentalId", rentalId);
                            cmd.Parameters.AddWithValue("@ReturnDate", returnDate);
                            cmd.Parameters.AddWithValue("@EndMileage", endMileage);
                            cmd.Parameters.AddWithValue("@FuelLevelEnd", fuelLevelEnd);
                            cmd.Parameters.AddWithValue("@TotalAmount", totalAmount);
                            cmd.ExecuteNonQuery();
                        }

                        // 3. Update Vehicle Status
                        string updateVehicle = @"
                            UPDATE Vehicles 
                            SET Status = 'Available', 
                                Mileage = @EndMileage, -- Update vehicle odometer
                                UpdatedAt = NOW() 
                            WHERE VehicleId = (SELECT VehicleId FROM Rentals WHERE RentalId = @RentalId)";

                        using (var cmd = new MySqlCommand(updateVehicle, conn, trans))
                        {
                            cmd.Parameters.AddWithValue("@EndMileage", endMileage); // Sync vehicle mileage
                            cmd.Parameters.AddWithValue("@RentalId", rentalId);
                            cmd.ExecuteNonQuery();
                        }

                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }
        
        public System.Data.DataTable GetActiveRentals()
        {
             // Helper for Return Form
             using (var conn = new MySqlConnection(_connectionString))
             {
                 conn.Open();
                 string query = @"
                    SELECT r.RentalId, 
                           CONCAT(c.FirstName, ' ', c.LastName) as CustomerName,
                           CONCAT(v.Make, ' ', v.Model) as VehicleName,
                           r.PickupDate
                    FROM Rentals r
                    JOIN Customers c ON r.CustomerId = c.CustomerId
                    JOIN Vehicles v ON r.VehicleId = v.VehicleId
                    WHERE r.Status = 'Active'";
                 
                 using (var cmd = new MySqlCommand(query, conn))
                 {
                     using (var adapter = new MySqlDataAdapter(cmd))
                     {
                         var dt = new System.Data.DataTable();
                         adapter.Fill(dt);
                         return dt;
                     }
                 }
             }
        }

        public System.Data.DataTable GetUnpaidRentals()
        {
             // Helper for Billing Form
             using (var conn = new MySqlConnection(_connectionString))
             {
                 conn.Open();
                 // Naive check: TotalAmount > Sum(Payments)
                 string query = @"
                    SELECT r.RentalId, 
                           r.TotalAmount,
                           IFNULL(SUM(p.Amount), 0) as PaidAmount,
                           (r.TotalAmount - IFNULL(SUM(p.Amount), 0)) as BalanceDue,
                           CONCAT(c.FirstName, ' ', c.LastName) as CustomerName
                    FROM Rentals r
                    LEFT JOIN Payments p ON r.RentalId = p.RentalId
                    JOIN Customers c ON r.CustomerId = c.CustomerId
                    WHERE r.Status = 'Completed'
                    GROUP BY r.RentalId, r.TotalAmount, CustomerName
                    HAVING BalanceDue > 0";
                 
                 using (var cmd = new MySqlCommand(query, conn))
                 {
                     using (var adapter = new MySqlDataAdapter(cmd))
                     {
                         var dt = new System.Data.DataTable();
                         adapter.Fill(dt);
                         return dt;
                     }
                 }
             }
        }

        public void ProcessPayment(int rentalId, decimal amount, string method)
        {
             using (var conn = new MySqlConnection(_connectionString))
             {
                 conn.Open();
                 string query = "INSERT INTO Payments (RentalId, Amount, Method, PaymentDate) VALUES (@RentalId, @Amount, @Method, NOW())";
                 using (var cmd = new MySqlCommand(query, conn))
                 {
                     cmd.Parameters.AddWithValue("@RentalId", rentalId);
                     cmd.Parameters.AddWithValue("@Amount", amount);
                     cmd.Parameters.AddWithValue("@Method", method);
                     cmd.ExecuteNonQuery();
                 }
             }
        }
        public System.Collections.Generic.Dictionary<string, object> GetReportStats()
        {
             using (var conn = new MySqlConnection(_connectionString))
             {
                 conn.Open();
                 string statsSql = "SELECT COUNT(*) as Count, SUM(TotalAmount) as Revenue FROM Rentals WHERE Status = 'Completed'";
                 using (var cmd = new MySqlCommand(statsSql, conn))
                 {
                     using (var reader = cmd.ExecuteReader())
                     {
                         if (reader.Read())
                         {
                             return new System.Collections.Generic.Dictionary<string, object>
                             {
                                 { "totalRentals", reader["Count"] != DBNull.Value ? Convert.ToInt32(reader["Count"]) : 0 },
                                 { "totalRevenue", reader["Revenue"] != DBNull.Value ? Convert.ToDecimal(reader["Revenue"]) : 0 }
                             };
                         }
                     }
                 }
             }
             return new System.Collections.Generic.Dictionary<string, object>();
        }

        public System.Data.DataTable GetRecentRentals()
        {
             using (var conn = new MySqlConnection(_connectionString))
             {
                 conn.Open();
                 string recentSql = "SELECT RentalId, PickupDate, ReturnDate, TotalAmount, Status FROM Rentals ORDER BY PickupDate DESC LIMIT 10";
                 using (var cmd = new MySqlCommand(recentSql, conn))
                 {
                     using (var adapter = new MySqlDataAdapter(cmd))
                     {
                         var dt = new System.Data.DataTable();
                         adapter.Fill(dt);
                         return dt;
                     }
                 }
             }
        }
        public System.Collections.Generic.Dictionary<string, int> GetDashboardCounts()
        {
             using (var conn = new MySqlConnection(_connectionString))
             {
                 conn.Open();
                 var counts = new System.Collections.Generic.Dictionary<string, int>();

                 // Active Rentals
                 using (var cmd = new MySqlCommand("SELECT COUNT(*) FROM Rentals WHERE Status = 'Active'", conn))
                     counts["activeRentals"] = Convert.ToInt32(cmd.ExecuteScalar());

                 // Available Vehicles
                 using (var cmd = new MySqlCommand("SELECT COUNT(*) FROM Vehicles WHERE Status = 'Available'", conn))
                     counts["availableVehicles"] = Convert.ToInt32(cmd.ExecuteScalar());

                 // Pending Returns (Active rentals due today or earlier)
                 using (var cmd = new MySqlCommand("SELECT COUNT(*) FROM Rentals WHERE Status = 'Active' AND ReturnDate <= NOW()", conn))
                     counts["pendingReturns"] = Convert.ToInt32(cmd.ExecuteScalar());

                 return counts;
             }
        }
    }
}
