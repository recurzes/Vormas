using System.Collections.Generic;
using Vormas.Interfaces;
using Vormas.Models;
using MySql.Data.MySqlClient;
using System.Data;
using Vormas.Helpers;

namespace Vormas.Database
{
    public class VehicleDbContext : IVehicleRepository
    {
        private readonly string _connStr = Helpers.MySqlHelper.GetConnectionString();

        public void AddVehicle(Vehicle vehicle)
        {
            DbCommandHelper.ExecuteNonQuery(_connStr, "prcAddVehicle", cmd =>
            {
                cmd.Parameters.AddWithValue("pVehicleCode", vehicle.VehicleCode);
                cmd.Parameters.AddWithValue("pMake", vehicle.Make);
                cmd.Parameters.AddWithValue("pModel", vehicle.Model);
                cmd.Parameters.AddWithValue("pYear", vehicle.Year);
                cmd.Parameters.AddWithValue("pColor", vehicle.Color);
                cmd.Parameters.AddWithValue("pLicensePlate", vehicle.LicensePlate);
                cmd.Parameters.AddWithValue("pVin", vehicle.VIN);
                cmd.Parameters.AddWithValue("pCategory", vehicle.Category);
                cmd.Parameters.AddWithValue("pTransmission", vehicle.Transmission);
                cmd.Parameters.AddWithValue("pFuelType", vehicle.FuelType);
                cmd.Parameters.AddWithValue("pSeatingCapacity", vehicle.SeatingCapacity);
                cmd.Parameters.AddWithValue("pOdometer", vehicle.Odometer);
                cmd.Parameters.AddWithValue("pStatus", vehicle.Status);
                cmd.Parameters.AddWithValue("pImagePath", vehicle.ImagePath);
            });
        }

        public void UpdateVehicle(Vehicle vehicle)
        {
            DbCommandHelper.ExecuteNonQuery(_connStr, "prcUpdateVehicle", cmd =>
            {
                cmd.Parameters.AddWithValue("pVehicleCode", vehicle.VehicleCode);
                cmd.Parameters.AddWithValue("pMake", vehicle.Make);
                cmd.Parameters.AddWithValue("pModel", vehicle.Model);
                cmd.Parameters.AddWithValue("pYear", vehicle.Year);
                cmd.Parameters.AddWithValue("pColor", vehicle.Color);
                cmd.Parameters.AddWithValue("pLicensePlate", vehicle.LicensePlate);
                cmd.Parameters.AddWithValue("pVin", vehicle.VIN);
                cmd.Parameters.AddWithValue("pCategory", vehicle.Category);
                cmd.Parameters.AddWithValue("pTransmission", vehicle.Transmission);
                cmd.Parameters.AddWithValue("pFuelType", vehicle.FuelType);
                cmd.Parameters.AddWithValue("pSeatingCapacity", vehicle.SeatingCapacity);
                cmd.Parameters.AddWithValue("pOdometer", vehicle.Odometer);
                cmd.Parameters.AddWithValue("pStatus", vehicle.Status);
                cmd.Parameters.AddWithValue("pImagePath", vehicle.ImagePath);
            });
        }

        public void DeleteVehicle(int vehicleId)
        {
            DbCommandHelper.ExecuteNonQuery(_connStr, "prcDeleteVehicle", cmd =>
            {
                cmd.Parameters.AddWithValue("pVehicleId", vehicleId);
            });
        }

        public List<Vehicle> GetAllVehicles()
        {
            return DbCommandHelper.ExecuteReader(_connStr, "prcGetAllVehicles", cmd => { }, reader =>
            {
                return DataReaderMapper.MapToList<Vehicle>(reader);
            });
        }

        public Vehicle GetVehicleById(int vehicleId)
        {
            return DbCommandHelper.ExecuteReader(_connStr, "prcGetVehicleById", cmd =>
            {
                cmd.Parameters.AddWithValue("pVehicleId", vehicleId);
            }, reader =>
            {
                if (reader.Read())
                {
                    return DataReaderMapper.MapToModel<Vehicle>(reader);
                }
                return null;
            });
        }
    }
}
