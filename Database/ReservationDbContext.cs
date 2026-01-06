using System;
using System.Data;
using Vormas.Interfaces;
using Vormas.Models;
using Vormas.Helpers;

namespace Vormas.Database
{
    public class ReservationDbContext : IReservationRepository
    {
        private readonly string _connStr = MySqlHelper.GetConnectionString();

        public bool CheckVehicleAvailability(int vehicleId, DateTime startDate, DateTime endDate)
        {
            // Returns 1 if available, 0 if not (based on SP logic)
            // But wait, the SP 'sp_CheckVehicleAvailability' returns a result set with a column 'IsAvailable'.
            // mapResult should read that scalar or first row.
            
            return DbCommandHelper.ExecuteReader(_connStr, "sp_CheckVehicleAvailability", cmd =>
            {
                cmd.Parameters.AddWithValue("p_VehicleId", vehicleId);
                cmd.Parameters.AddWithValue("p_StartDate", startDate);
                cmd.Parameters.AddWithValue("p_EndDate", endDate);
            }, reader =>
            {
                if (reader.Read())
                {
                    // Assuming the first column is the boolean/int indicator
                    int result = Convert.ToInt32(reader["IsAvailable"]);
                    return result == 1;
                }
                return false;
            });
        }

        public void CreateReservation(Reservation reservation)
        {
            DbCommandHelper.ExecuteNonQuery(_connStr, "sp_CreateReservation", cmd =>
            {
                cmd.Parameters.AddWithValue("p_VehicleId", reservation.VehicleId);
                cmd.Parameters.AddWithValue("p_CustomerId", reservation.CustomerId);
                cmd.Parameters.AddWithValue("p_StartDate", reservation.StartDate);
                cmd.Parameters.AddWithValue("p_EndDate", reservation.EndDate);
                cmd.Parameters.AddWithValue("p_TotalCost", reservation.TotalCost);
                cmd.Parameters.AddWithValue("p_CreatedBy", reservation.CreatedBy);
            });
        }
    }
}
