using System.Collections.Generic;
using Vormas.Interfaces;
using Vormas.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace Vormas.Database
{
    public class VehicleRepository : IVehicleRepository
    {
        private string _connStr = Helpers.MySqlHelper.GetConnectionString();

        public void AddVehicle(Vehicle vehicle)
        {
            DbCommandHelper.ExecuteNonQuery(_connStr, "prcAddVehicle", cmd =>
            {
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
                cmd.Parameters.AddWithValue("pDailyRate", vehicle.DailyRate);
                cmd.Parameters.AddWithValue("pStatus", vehicle.Status);
                cmd.Parameters.AddWithValue("pImagePath", vehicle.ImagePath);
            });
        }

        public void UpdateVehicle(Vehicle vehicle)
        {
            DbCommandHelper.ExecuteNonQuery(_connStr, "prcUpdateVehicle", cmd =>
            {
                cmd.Parameters.AddWithValue("pVehicleId", vehicle.VehicleId);
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
                cmd.Parameters.AddWithValue("pDailyRate", vehicle.DailyRate);
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
                var vehicles = new List<Vehicle>();
                while (reader.Read())
                {
                    vehicles.Add(MapVehicle(reader));
                }
                return vehicles;
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
                    return MapVehicle(reader);
                }
                return null;
            });
        }

        private Vehicle MapVehicle(MySqlDataReader reader)
        {
            return new Vehicle
            {
                VehicleId = reader.GetInt32("VehicleId"),
                Make = reader.GetString("Make"),
                Model = reader.GetString("Model"),
                Year = reader.GetInt32("Year"),
                Color = reader.GetString("Color"),
                LicensePlate = reader.GetString("LicensePlate"),
                VIN = reader.GetString("VIN"),
                Category = reader.GetString("Category"),
                Transmission = reader.GetString("Transmission"),
                FuelType = reader.GetString("FuelType"),
                SeatingCapacity = reader.GetInt32("SeatingCapacity"),
                DailyRate = reader.GetDecimal("DailyRate"),
                Status = reader.GetString("Status"),
                ImagePath = reader.IsDBNull(reader.GetOrdinal("ImagePath")) ? null : reader.GetString("ImagePath"),
                CreatedAt = reader.GetDateTime("CreatedAt"),
                UpdatedAt = reader.GetDateTime("UpdatedAt")
            };
        }
    }
}
