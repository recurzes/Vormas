#nullable enable
using System;

namespace Vormas.Models.DTO
{
    public class StartRentalDto
    {
        public int? ReservationId { get; set; }
        public int CustomerId { get; set; }
        public int VehicleId { get; set; }
        public DateTime PickupDateTime { get; set; }
        public decimal PickupOdometer { get; set; }
        public decimal PickupFuelLevel { get; set; }
        public int PickupAgentId { get; set; }
        public decimal DepositAmount { get; set; }
        public bool IsSmokedIn { get; set; }
        public bool IsClean { get; set; }
        public bool AccessoriesOk { get; set; }
        public string? InspectionNotes { get; set; }
    }
}