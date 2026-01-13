using System.Collections.Generic;
using Vormas.Interfaces;
using Vormas.Models;

namespace Vormas.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _repository;

        public VehicleService(IVehicleRepository repository)
        {
            _repository = repository;
        }

        public void AddVehicle(Vehicle vehicle)
        {
            _repository.AddVehicle(vehicle);
        }

        public void UpdateVehicle(Vehicle vehicle)
        {
            _repository.UpdateVehicle(vehicle);
        }

        public void DeleteVehicle(int vehicleId)
        {
            _repository.DeleteVehicle(vehicleId);
        }

        public List<Vehicle> GetAllVehicles()
        {
            return _repository.GetAllVehicles();
        }

        public Vehicle GetVehicleById(int vehicleId)
        {
            return _repository.GetVehicleById(vehicleId);
        }
        
        public IEnumerable<string> GetVehicleCategories()
        {
            return new List<string> { "Hatchback", "Sedan", "SUV", "Pickup", "Van/Minibus" };
        }

        public IEnumerable<string> GetVehicleStatuses()
        {
            return new List<string> { "Available", "Rented", "Reserved", "Under Maintenance", "Out of Service", "Retired" };
        }

        public List<VehicleFeature> GetAllFeatures()
        {
            return _repository.GetAllFeatures();
        }

        public List<int> GetVehicleFeatureIds(int vehicleId)
        {
            return _repository.GetVehicleFeatureIds(vehicleId);
        }

        public void SaveVehicleFeatures(int vehicleId, List<int> featureIds)
        {
            _repository.SaveVehicleFeatures(vehicleId, featureIds);
        }

        public List<string> GetVehicleImages(int vehicleId)
        {
            return _repository.GetVehicleImages(vehicleId);
        }

        public void SaveVehicleImages(int vehicleId, List<string> imagePaths)
        {
            _repository.SaveVehicleImages(vehicleId, imagePaths);
        }

        public void RetireVehicle(int vehicleId)
        {
            _repository.RetireVehicle(vehicleId);
        }
    }
}
