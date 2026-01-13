using System;

namespace Vormas.Models
{
    public class Rental
    {
        public int RentalId { get; set; }
        public int ReservationId { get; set; }
        public int VehicleId { get; set; }
        public int CustomerId { get; set; }
        public DateTime ActualStartDate { get; set; }
        public DateTime? ActualEndDate { get; set; }
        public int StartMileage { get; set; }
        public int? EndMileage { get; set; }
        public string Status { get; set; } // "Active", "Returned"
        
        public string CustomerName { get; set; }
        public string VehicleModel { get; set; }
    }
}
