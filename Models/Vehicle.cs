using System;
using System.Collections.Generic;

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
        public string CategoryId { get; set; } 
        public string CategoryName { get; set; } // Display property
        public string Transmission { get; set; } 
        public string FuelType { get; set; } 
        public int SeatingCapacity { get; set; }
        public int Odometer { get; set; }
        public decimal CargoCapacity { get; set; }
        public decimal FuelEfficiency { get; set; }
        public string Status { get; set; }
        public string ImagePath { get; set; }
        public List<string> ImagePaths { get; set; } = new List<string>();
        public List<int> FeatureIds { get; set; } = new List<int>();
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}