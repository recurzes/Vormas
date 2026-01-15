using System.Collections.Generic;
using Vormas.Models;

namespace Vormas.Interfaces
{
    public interface IVehicleService
    {
        void AddVehicle(Vehicle vehicle);
        void UpdateVehicle(Vehicle vehicle);
        void DeleteVehicle(int vehicleId);
        List<Vehicle> GetAllVehicles();
        Vehicle GetVehicleById(int vehicleId);
        IEnumerable<string> GetVehicleCategories();
        IEnumerable<string> GetVehicleStatuses();
        List<VehicleFeature> GetAllFeatures();
        List<int> GetVehicleFeatureIds(int vehicleId);
        void SaveVehicleFeatures(int vehicleId, List<int> featureIds);
        List<string> GetVehicleImages(int vehicleId);
        void SaveVehicleImages(int vehicleId, List<string> imagePaths);
        void RetireVehicle(int vehicleId);
    }
}