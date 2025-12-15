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
    }
}