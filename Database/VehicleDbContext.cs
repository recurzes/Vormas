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
                cmd.Parameters.AddWithValue("pCategory", vehicle.CategoryId);
                cmd.Parameters.AddWithValue("pTransmission", vehicle.Transmission);
                cmd.Parameters.AddWithValue("pFuelType", vehicle.FuelType);
                cmd.Parameters.AddWithValue("pSeatingCapacity", vehicle.SeatingCapacity);
                cmd.Parameters.AddWithValue("pOdometer", vehicle.Odometer);
                cmd.Parameters.AddWithValue("pCargoCapacity", vehicle.CargoCapacity);
                cmd.Parameters.AddWithValue("pFuelEfficiency", vehicle.FuelEfficiency);
                cmd.Parameters.AddWithValue("pStatus", vehicle.Status);
                cmd.Parameters.AddWithValue("pImagePath", vehicle.ImagePath);
            });
        }

        public void UpdateVehicle(Vehicle vehicle)
        {
            DbCommandHelper.ExecuteNonQuery(_connStr, "prcUpdateVehicle", cmd =>
            {
                cmd.Parameters.AddWithValue("pVehicleId", vehicle.VehicleId);
                cmd.Parameters.AddWithValue("pVehicleCode", vehicle.VehicleCode);
                cmd.Parameters.AddWithValue("pMake", vehicle.Make);
                cmd.Parameters.AddWithValue("pModel", vehicle.Model);
                cmd.Parameters.AddWithValue("pYear", vehicle.Year);
                cmd.Parameters.AddWithValue("pColor", vehicle.Color);
                cmd.Parameters.AddWithValue("pLicensePlate", vehicle.LicensePlate);
                cmd.Parameters.AddWithValue("pVin", vehicle.VIN);
                cmd.Parameters.AddWithValue("pCategory", vehicle.CategoryId);
                cmd.Parameters.AddWithValue("pTransmission", vehicle.Transmission);
                cmd.Parameters.AddWithValue("pFuelType", vehicle.FuelType);
                cmd.Parameters.AddWithValue("pSeatingCapacity", vehicle.SeatingCapacity);
                cmd.Parameters.AddWithValue("pOdometer", vehicle.Odometer);
                cmd.Parameters.AddWithValue("pCargoCapacity", vehicle.CargoCapacity);
                cmd.Parameters.AddWithValue("pFuelEfficiency", vehicle.FuelEfficiency);
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

        public List<VehicleFeature> GetAllFeatures()
        {
            return DbCommandHelper.ExecuteReader(_connStr, "prcGetAllVehicleFeatures", cmd => { }, reader =>
            {
                var features = new List<VehicleFeature>();
                while (reader.Read())
                {
                    features.Add(new VehicleFeature
                    {
                        FeatureId = reader.GetInt32("FeatureId"),
                        Name = reader.GetString("Name"),
                        Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? "" : reader.GetString("Description")
                    });
                }
                return features;
            });
        }

        public List<int> GetVehicleFeatureIds(int vehicleId)
        {
            return DbCommandHelper.ExecuteReader(_connStr, "prcGetVehicleFeatureIds", cmd =>
            {
                cmd.Parameters.AddWithValue("pVehicleId", vehicleId);
            }, reader =>
            {
                var ids = new List<int>();
                while (reader.Read())
                {
                    ids.Add(reader.GetInt32("FeatureId"));
                }
                return ids;
            });
        }

        public void SaveVehicleFeatures(int vehicleId, List<int> featureIds)
        {
            DbCommandHelper.ExecuteNonQuery(_connStr, "prcClearVehicleFeatures", cmd =>
            {
                cmd.Parameters.AddWithValue("pVehicleId", vehicleId);
            });

            foreach (var featureId in featureIds)
            {
                DbCommandHelper.ExecuteNonQuery(_connStr, "prcAddVehicleFeature", cmd =>
                {
                    cmd.Parameters.AddWithValue("pVehicleId", vehicleId);
                    cmd.Parameters.AddWithValue("pFeatureId", featureId);
                });
            }
        }

        public List<string> GetVehicleImages(int vehicleId)
        {
            return DbCommandHelper.ExecuteReader(_connStr, "prcGetVehicleImages", cmd =>
            {
                cmd.Parameters.AddWithValue("pVehicleId", vehicleId);
            }, reader =>
            {
                var images = new List<string>();
                while (reader.Read())
                {
                    images.Add(reader.GetString("ImagePath"));
                }
                return images;
            });
        }

        public void SaveVehicleImages(int vehicleId, List<string> imagePaths)
        {
            DbCommandHelper.ExecuteNonQuery(_connStr, "prcClearVehicleImages", cmd =>
            {
                cmd.Parameters.AddWithValue("pVehicleId", vehicleId);
            });

            foreach (var imagePath in imagePaths)
            {
                DbCommandHelper.ExecuteNonQuery(_connStr, "prcAddVehicleImage", cmd =>
                {
                    cmd.Parameters.AddWithValue("pVehicleId", vehicleId);
                    cmd.Parameters.AddWithValue("pImagePath", imagePath);
                });
            }
        }

        public void RetireVehicle(int vehicleId)
        {
            DbCommandHelper.ExecuteNonQuery(_connStr, "prcRetireVehicle", cmd =>
            {
                cmd.Parameters.AddWithValue("pVehicleId", vehicleId);
            });
        }
    }
}

