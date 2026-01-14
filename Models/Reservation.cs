using System;

namespace Vormas.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public int CustomerId { get; set; }
        public int VehicleId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string Status { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Notes { get; set; }

        public string CustomerName { get; set; }
        public string VehicleCode { get; set; }
        public string VehicleDescription { get; set; }
    }

    public class ReservationRequest
    {
        public int CustomerId { get; set; }
        public int VehicleId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public int CreatedByUserId { get; set; }
        public string Notes { get; set; }
    }
}
