using System;
using System.Configuration;
using Vormas.Database;
using MySql.Data.MySqlClient;

namespace Vormas.Services
{
    public interface IMaintenanceService
    {
        void LogMaintenance(int vehicleId, string description, decimal cost);
        void CompleteMaintenance(int vehicleId);
    }

    public class MaintenanceService : IMaintenanceService
    {
        private readonly string _connectionString;

        public MaintenanceService()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"]?.ConnectionString 
                                ?? "Server=localhost;Database=VormasDb;Uid=root;Pwd=password;";
        }

        public void LogMaintenance(int vehicleId, string description, decimal cost)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                using (var trans = conn.BeginTransaction())
                {
                    try
                    {
                        string insertMaint = "INSERT INTO Maintenance (VehicleId, Description, Cost, DatePerformed, CreatedAt) VALUES (@Id, @Desc, @Cost, NOW(), NOW())";
                        using (var cmd = new MySqlCommand(insertMaint, conn, trans))
                        {
                            cmd.Parameters.AddWithValue("@Id", vehicleId);
                            cmd.Parameters.AddWithValue("@Desc", description);
                            cmd.Parameters.AddWithValue("@Cost", cost);
                            cmd.ExecuteNonQuery();
                        }

                        string updateVehicle = "UPDATE Vehicles SET Status = 'Under Maintenance', UpdatedAt = NOW() WHERE VehicleId = @Id";
                        using (var cmd = new MySqlCommand(updateVehicle, conn, trans))
                        {
                            cmd.Parameters.AddWithValue("@Id", vehicleId);
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

        public void CompleteMaintenance(int vehicleId)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                 string updateVehicle = "UPDATE Vehicles SET Status = 'Available', UpdatedAt = NOW() WHERE VehicleId = @Id";
                 using (var cmd = new MySqlCommand(updateVehicle, conn))
                 {
                     cmd.Parameters.AddWithValue("@Id", vehicleId);
                     cmd.ExecuteNonQuery();
                 }
            }
        }
    }
}
