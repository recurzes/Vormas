#nullable enable
using System;

namespace Vormas.Models.DTO
{
    public class ActiveRentalDto
    {
        public int RentalId { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerPhone { get; set; } = string.Empty;
        public int VehicleId { get; set; }
        public string VehicleInfo { get; set; } = string.Empty;
        public string? LicensePlate { get; set; }
        public DateTime PickupDateTime { get; set; }
        public decimal? PickupOdometer { get; set; }
        public decimal? PickupFuelLevel { get; set; }
        public decimal DepositAmount { get; set; }
        public string Status { get; set; } = string.Empty;
        public string PickupAgent { get; set; } = string.Empty;
        public int DaysRented { get; set; }
    }
}