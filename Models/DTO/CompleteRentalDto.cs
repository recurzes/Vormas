#nullable enable
using System;

namespace Vormas.Models.DTO
{
    public class CompleteRentalDto
    {
        public int RentalId { get; set; }
        public DateTime ReturnDateTime { get; set; }
        public decimal ReturnOdometer { get; set; }
        public decimal ReturnFuelLevel { get; set; }
        public int ReturnAgentId { get; set; }
        public bool IsSmokedIn { get; set; }
        public bool IsClean { get; set; }
        public bool AccessoriesOk { get; set; }
        public string? InspectionNotes { get; set; }
    }
}