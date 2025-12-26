using System;

namespace Vormas.Models
{
    public class Rentals
    {
        public int RentalId { get; set; }
        public int ReservationId { get; set; }
        public int CustomerId { get; set; }
        public int VehicleId { get; set; }
        public DateTime PickupDateTime { get; set; }
        public DateTime ReturnDateTime { get; set; }
        public decimal PickupOdometer { get; set; }
        public decimal ReturnOdometer { get; set; }
        public decimal PickupFuelLevel { get; set; }
        public decimal ReturnFuelLevel { get; set; }
        public string Status { get; set; } // Enum jud ni sya
        public int PickupAgentId { get; set; }
        public int ReturnAgentId { get; set; }
        public decimal DepositAmount { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}