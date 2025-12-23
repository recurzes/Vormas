using System;
using FxResources.System;
namespace Vormas.Models
{
    public class Vehicle
    {
        public int VehicleId { get; set; }
        public string VehicleCode { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public string LicensePlate { get; set; }
        public string VIN { get; set; }
        public string Category { get; set; } 
        public string Transmission { get; set; } 
        public string FuelType { get; set; } 
        public int SeatingCapacity { get; set; }
        public int Odometer { get; set; }
        public string Status { get; set; }
        public string ImagePath { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}