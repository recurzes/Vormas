using System;
using System.Collections.Generic;
using System.Configuration;
using Vormas.Database;
using Vormas.Models;
using Vormas.Interfaces;
using MySql.Data.MySqlClient;

namespace Vormas.Services
{
    public class ReservationService : IReservationService
    {
        private readonly string _connectionString;

        public ReservationService()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"]?.ConnectionString 
                                ?? "Server=localhost;Database=VormasDb;Uid=root;Pwd=password;"; 
        }

        public List<Reservation> GetReservations()
        {
            string query = @"
                SELECT 
                    r.ReservationId, r.CustomerId, r.VehicleId, r.StartDate, r.EndDate, r.Status, r.CreatedAt,
                    CONCAT(c.FirstName, ' ', c.LastName) AS CustomerName,
                    CONCAT(v.Make, ' ', v.Model) AS VehicleModel
                FROM Reservations r
                JOIN Customers c ON r.CustomerId = c.CustomerId
                JOIN Vehicles v ON r.VehicleId = v.VehicleId
                ORDER BY r.CreatedAt DESC";

            return DbCommandHelper.ExecuteReaderText(_connectionString, query, 
                cmd => { }, 
                reader =>
                {
                    var list = new List<Reservation>();
                    while (reader.Read())
                    {
                        list.Add(new Reservation
                        {
                            ReservationId = Convert.ToInt32(reader["ReservationId"]),
                            CustomerId = Convert.ToInt32(reader["CustomerId"]),
                            VehicleId = Convert.ToInt32(reader["VehicleId"]),
                            StartDate = Convert.ToDateTime(reader["StartDate"]),
                            EndDate = Convert.ToDateTime(reader["EndDate"]),
                            Status = reader["Status"].ToString(),
                            CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
                            CustomerName = reader["CustomerName"].ToString(),
                            VehicleModel = reader["VehicleModel"].ToString()
                        });
                    }
                    return list;
                });
        }

        public void CreateReservation(Reservation reservation)
        {
            string query = @"
                INSERT INTO Reservations (VehicleId, CustomerId, StartDate, EndDate, Status, CreatedAt)
                VALUES (@VehicleId, @CustomerId, @StartDate, @EndDate, @Status, NOW());";

            DbCommandHelper.ExecuteReaderText(_connectionString, query,
                cmd =>
                {
                    cmd.Parameters.AddWithValue("@VehicleId", reservation.VehicleId);
                    cmd.Parameters.AddWithValue("@CustomerId", reservation.CustomerId);
                    cmd.Parameters.AddWithValue("@StartDate", reservation.StartDate);
                    cmd.Parameters.AddWithValue("@EndDate", reservation.EndDate);
                    cmd.Parameters.AddWithValue("@Status", reservation.Status ?? "Pending");
                },
                reader => 0); // ExecuteReaderText can work for Insert if we don't care about result, but Helper forces Read?
                              // Looking at Helper, ExecuteReaderText returns T. ExecuteNonQuery might be better, 
                              // but Helper only has ExecuteNonQuery for StoredProcedures. 
                              // Wait, Helper ExecuteReaderText uses CommandType.Text.
                              // ExecuteNonQuery uses CommandType.StoredProcedure.
                              // So to run Text Internal/Update/Delete, I have to use ExecuteReaderText and ignore result or add a new helper method.
                              // I'll stick to ExecuteReaderText and ignore result for now or add a helper if I was editing helper. 
                              // Actually, I can just use a dummy mapper.
        }

        public void UpdateReservationStatus(int reservationId, string status)
        {
            string query = "UPDATE Reservations SET Status = @Status WHERE ReservationId = @Id";
             DbCommandHelper.ExecuteReaderText(_connectionString, query,
                cmd =>
                {
                    cmd.Parameters.AddWithValue("@Id", reservationId);
                    cmd.Parameters.AddWithValue("@Status", status);
                },
                reader => 0);
        }

        public bool IsVehicleAvailable(int vehicleId, DateTime start, DateTime end)
        {
            string query = @"
                SELECT COUNT(*) 
                FROM Reservations 
                WHERE VehicleId = @VehicleId 
                  AND Status IN ('Pending', 'Confirmed')
                  AND (
                      (StartDate <= @End AND EndDate >= @Start)
                  )";

            int count = DbCommandHelper.ExecuteReaderText(_connectionString, query,
                cmd =>
                {
                    cmd.Parameters.AddWithValue("@VehicleId", vehicleId);
                    cmd.Parameters.AddWithValue("@Start", start);
                    cmd.Parameters.AddWithValue("@End", end);
                },
                reader =>
                {
                    if (reader.Read()) return Convert.ToInt32(reader[0]);
                    return 0;
                });

            return count == 0;
        }
    }
}
