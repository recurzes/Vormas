using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Vormas.Interfaces;
using Vormas.Models;
using Vormas.Helpers;

namespace Vormas.Database
{
    public class RentalDbContext : IRentalRepository
    {
        private readonly string _connStr = Helpers.MySqlHelper.GetConnectionString();

        public int StartRental(RentalPickupRequest request)
        {
            int? reservationId = request.ReservationId;
            
            if (!reservationId.HasValue && request.ExpectedReturnDateTime.HasValue)
            {
                reservationId = CreateQuickReservation(
                    request.CustomerId,
                    request.VehicleId,
                    request.PickupDateTime,
                    request.ExpectedReturnDateTime.Value,
                    request.PickupAgentId
                );
            }
            
            return DbCommandHelper.ExecuteReader(_connStr, "prcStartRental", cmd =>
            {
                cmd.Parameters.AddWithValue("pReservationId", reservationId.HasValue ? (object)reservationId.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("pCustomerId", request.CustomerId);
                cmd.Parameters.AddWithValue("pVehicleId", request.VehicleId);
                cmd.Parameters.AddWithValue("pPickupDateTime", request.PickupDateTime);
                cmd.Parameters.AddWithValue("pPickupOdometer", request.PickupOdometer);
                cmd.Parameters.AddWithValue("pPickupFuelLevel", request.PickupFuelLevel);
                cmd.Parameters.AddWithValue("pPickupAgentId", request.PickupAgentId);
                cmd.Parameters.AddWithValue("pDepositAmount", request.DepositAmount);
                cmd.Parameters.AddWithValue("pIsSmokedIn", request.IsSmokedIn ? 1 : 0);
                cmd.Parameters.AddWithValue("pIsClean", request.IsClean ? 1 : 0);
                cmd.Parameters.AddWithValue("pAccessoriesOk", request.AccessoriesOk ? 1 : 0);
                cmd.Parameters.AddWithValue("pInspectionNotes", request.InspectionNotes ?? string.Empty);
            }, reader =>
            {
                if (reader.Read())
                {
                    return Convert.ToInt32(reader["NewRentalId"]);
                }
                return 0;
            });
        }

        private int CreateQuickReservation(int customerId, int vehicleId, DateTime startDateTime, DateTime endDateTime, int createdByUserId)
        {
            return DbCommandHelper.ExecuteReader(_connStr, "prcCreateQuickReservation", cmd =>
            {
                cmd.Parameters.AddWithValue("pCustomerId", customerId);
                cmd.Parameters.AddWithValue("pVehicleId", vehicleId);
                cmd.Parameters.AddWithValue("pStartDateTime", startDateTime);
                cmd.Parameters.AddWithValue("pEndDateTime", endDateTime);
                cmd.Parameters.AddWithValue("pCreatedByUserId", createdByUserId);
            }, reader =>
            {
                if (reader.Read())
                {
                    return Convert.ToInt32(reader["ReservationId"]);
                }
                return 0;
            });
        }

        public void CompleteRental(RentalReturnRequest request)
        {
            DbCommandHelper.ExecuteNonQuery(_connStr, "prcCompleteRental", cmd =>
            {
                cmd.Parameters.AddWithValue("pRentalId", request.RentalId);
                cmd.Parameters.AddWithValue("pReturnDateTime", request.ReturnDateTime);
                cmd.Parameters.AddWithValue("pReturnOdometer", request.ReturnOdometer);
                cmd.Parameters.AddWithValue("pReturnFuelLevel", request.ReturnFuelLevel);
                cmd.Parameters.AddWithValue("pReturnAgentId", request.ReturnAgentId);
                cmd.Parameters.AddWithValue("pIsSmokedIn", request.IsSmokedIn ? 1 : 0);
                cmd.Parameters.AddWithValue("pIsClean", request.IsClean ? 1 : 0);
                cmd.Parameters.AddWithValue("pAccessoriesOk", request.AccessoriesOk ? 1 : 0);
                cmd.Parameters.AddWithValue("pInspectionNotes", request.InspectionNotes ?? string.Empty);
            });
        }

        public List<Rental> GetActiveRentals()
        {
            return DbCommandHelper.ExecuteReader(_connStr, "prcGetActiveRentals", cmd => { }, reader =>
            {
                return DataReaderMapper.MapToList<Rental>(reader);
            });
        }

        public Rental GetRentalById(int rentalId)
        {
            return DbCommandHelper.ExecuteReader(_connStr, "prcGetRentalById", cmd =>
            {
                cmd.Parameters.AddWithValue("pRentalId", rentalId);
            }, reader =>
            {
                if (reader.Read())
                {
                    return DataReaderMapper.MapToModel<Rental>(reader);
                }
                return null;
            });
        }

        public List<Vehicle> GetAvailableVehicles()
        {
            return DbCommandHelper.ExecuteReader(_connStr, "prcGetAvailableVehicles", cmd => { }, reader =>
            {
                return DataReaderMapper.MapToList<Vehicle>(reader);
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
