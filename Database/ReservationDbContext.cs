using System;
using System.Collections.Generic;
using Vormas.Interfaces;
using Vormas.Models;
using Vormas.Helpers;

namespace Vormas.Database
{
    public class ReservationDbContext : IReservationRepository
    {
        private readonly string _connStr = Helpers.MySqlHelper.GetConnectionString();

        public int CreateReservation(ReservationRequest request)
        {
            return DbCommandHelper.ExecuteReader(_connStr, "prcCreateReservation", cmd =>
            {
                cmd.Parameters.AddWithValue("pCustomerId", request.CustomerId);
                cmd.Parameters.AddWithValue("pVehicleId", request.VehicleId);
                cmd.Parameters.AddWithValue("pStartDateTime", request.StartDateTime);
                cmd.Parameters.AddWithValue("pEndDateTime", request.EndDateTime);
                cmd.Parameters.AddWithValue("pCreatedByUserId", request.CreatedByUserId);
                cmd.Parameters.AddWithValue("pNotes", request.Notes ?? string.Empty);
            }, reader =>
            {
                if (reader.Read())
                {
                    return Convert.ToInt32(reader["ReservationId"]);
                }
                return 0;
            });
        }

        public void CancelReservation(int reservationId)
        {
            DbCommandHelper.ExecuteNonQuery(_connStr, "prcCancelReservation", cmd =>
            {
                cmd.Parameters.AddWithValue("pReservationId", reservationId);
            });
        }

        public List<Reservation> GetAllReservations(string statusFilter = null)
        {
            return DbCommandHelper.ExecuteReader(_connStr, "prcGetAllReservations", cmd =>
            {
                cmd.Parameters.AddWithValue("pStatusFilter", statusFilter ?? (object)DBNull.Value);
            }, reader =>
            {
                return DataReaderMapper.MapToList<Reservation>(reader);
            });
        }

        public Reservation GetReservationById(int reservationId)
        {
            return DbCommandHelper.ExecuteReader(_connStr, "prcGetReservationById", cmd =>
            {
                cmd.Parameters.AddWithValue("pReservationId", reservationId);
            }, reader =>
            {
                if (reader.Read())
                {
                    return DataReaderMapper.MapToModel<Reservation>(reader);
                }
                return null;
            });
        }

        public List<Vehicle> GetVehiclesForDateRange(DateTime startDate, DateTime endDate)
        {
            return DbCommandHelper.ExecuteReader(_connStr, "prcGetVehiclesForDateRange", cmd =>
            {
                cmd.Parameters.AddWithValue("pStartDate", startDate);
                cmd.Parameters.AddWithValue("pEndDate", endDate);
            }, reader =>
            {
                return DataReaderMapper.MapToList<Vehicle>(reader);
            });
        }

        public bool CheckVehicleAvailability(int vehicleId, DateTime startDate, DateTime endDate, int? excludeReservationId = null)
        {
            return DbCommandHelper.ExecuteReader(_connStr, "prcCheckVehicleAvailability", cmd =>
            {
                cmd.Parameters.AddWithValue("pVehicleId", vehicleId);
                cmd.Parameters.AddWithValue("pStartDate", startDate.Date);
                cmd.Parameters.AddWithValue("pEndDate", endDate.Date);
                cmd.Parameters.AddWithValue("pExcludeReservationId", excludeReservationId ?? (object)DBNull.Value);
            }, reader =>
            {
                if (reader.Read())
                {
                    return Convert.ToBoolean(reader["IsAvailable"]);
                }
                return false;
            });
        }

        public List<Customer> GetEligibleCustomers()
        {
            return DbCommandHelper.ExecuteReader(_connStr, "prcGetEligibleCustomers", cmd => { }, reader =>
            {
                return DataReaderMapper.MapToList<Customer>(reader);
            });
        }
    }
}
