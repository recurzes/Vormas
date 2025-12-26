#nullable enable
using System;

namespace Vormas.Models.DTO
{
    public class RentalDetailsDto
    {
        public int RentalId { get; set; }
        public int? ReservationId { get; set; }
        
        // Customer
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string? CustomerEmail { get; set; }
        public string? CustomerPhon { get; set; }
        public string? CustomerAddress { get; set; }
        
        // Vehicle
        public int VehicleId { get; set; }
        public string VehicleCode { get; set; } = string.Empty;
        public string VehicleInfo { get; set; } = string.Empty;
        public string? LicensePlater { get; set; }
        public string? Color { get; set; }
        public string? FuelType { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        
        // Rental
        public DateTime PickupDateTime { get; set; }
        public DateTime? ReturnDateTime { get; set; }
        public decimal? PickupOdometer { get; set; }
        public decimal? ReturnOdometer { get; set; }
        public decimal? PickupFuelLevel { get; set; }
        public decimal? ReturnFuelLevel { get; set; }

        public string Status { get; set; } = string.Empty;
        public decimal DepositAmount { get; set; }
        
        // Agents
        public string PickupAgentName { get; set; } = string.Empty;
        public string? ReturnAgentName { get; set; }
        
        // Calculated
        public decimal? MileageTraveled { get; set; } // ReturnOdometer - PickupOdometer
        public double? RentalDurationDays { get; set; } // Duration in days
    }
}