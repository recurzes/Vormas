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
            // Add business validation logic here if needed
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
            return new List<string> { "Hatchback", "Sedan", "SUV", "Pickup", "Van", "Minibus" };
        }

        public IEnumerable<string> GetVehicleStatuses()
        {
            return new List<string> { "Available", "Rented", "Reserved", "Under Maintenance", "Out of Service", "Retired" };
        }
    }
}