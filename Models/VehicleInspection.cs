using System;

namespace Vormas.Models
{
    public class VehicleInspection
    {
        public int InspectionId { get; set; }
        public int RentalId { get; set; }
        public int VehicleId { get; set; }
        public string InspectionType { get; set; } // Pickup, Return
        public DateTime InspectionDateTime { get; set; }
        public decimal? OdometerReading { get; set; }
        public decimal? FuelLevel { get; set; }
        public bool IsSmokedIn { get; set; }
        public bool IsClean { get; set; }
        public bool AccessoriesOk { get; set; }
        public string Notes { get; set; }
    }
}
