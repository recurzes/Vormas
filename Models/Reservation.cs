using System;

namespace Vormas.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public int CustomerId { get; set; }
        public int VehicleId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; } // "Pending", "Confirmed", "Cancelled", "Completed"
        public DateTime CreatedAt { get; set; }

        // Navigation properties (optional, depending on ORM usage, keeping simple for now)
        public string CustomerName { get; set; } // For display
        public string VehicleModel { get; set; } // For display
    }
}
