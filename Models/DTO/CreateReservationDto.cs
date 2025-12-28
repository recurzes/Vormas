#nullable enable
using System;

namespace Vormas.Models.DTO
{
    public class CreateReservationDto
    {
        public int CustomerId { get; set; }
        public int VehicleId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string Status { get; set; } = "Pending";
        public int CreatedByUserId { get; set; }
        public string? Notes { get; set; }
    }
}