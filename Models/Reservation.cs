using System;

namespace Vormas.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public int VehicleId { get; set; }
        public int CustomerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalCost { get; set; }
        public string Status { get; set; } // Confirmed, Cancelled, Completed
        public int CreatedBy { get; set; } // UserId
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Optional navigation properties for UI binding if needed
        public string VehicleName { get; set; }
        public string CustomerName { get; set; }
    }
}