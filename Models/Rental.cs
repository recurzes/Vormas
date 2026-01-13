using System;

namespace Vormas.Models
{
    public class Rental
    {
        public int RentalId { get; set; }
        public int? ReservationId { get; set; }
        public int CustomerId { get; set; }
        public int VehicleId { get; set; }
        public DateTime PickupDateTime { get; set; }
        public DateTime? ReturnDateTime { get; set; }
        public DateTime? ExpectedReturnDateTime { get; set; }
        public decimal? PickupOdometer { get; set; }
        public decimal? ReturnOdometer { get; set; }
        public decimal? PickupFuelLevel { get; set; }
        public decimal? ReturnFuelLevel { get; set; }
        public string Status { get; set; } // Active, Completed, Cancelled, Overdue
        public int PickupAgentId { get; set; }
        public int? ReturnAgentId { get; set; }
        public decimal DepositAmount { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation properties for display
        public string CustomerName { get; set; }
        public string VehicleCode { get; set; }
        public string VehicleDescription { get; set; }
        
        // Pickup inspection data for comparison
        public bool? PickupIsSmokedIn { get; set; }
        public bool? PickupIsClean { get; set; }
        public bool? PickupAccessoriesOk { get; set; }
        public string PickupNotes { get; set; }
    }

    public class RentalPickupRequest
    {
        public int? ReservationId { get; set; }
        public int CustomerId { get; set; }
        public int VehicleId { get; set; }
        public DateTime PickupDateTime { get; set; }
        public DateTime? ExpectedReturnDateTime { get; set; }
        public decimal PickupOdometer { get; set; }
        public decimal PickupFuelLevel { get; set; }
        public int PickupAgentId { get; set; }
        public decimal DepositAmount { get; set; }
        public bool IsSmokedIn { get; set; }
        public bool IsClean { get; set; }
        public bool AccessoriesOk { get; set; }
        public string InspectionNotes { get; set; }
    }

    public class RentalReturnRequest
    {
        public int RentalId { get; set; }
        public DateTime ReturnDateTime { get; set; }
        public decimal ReturnOdometer { get; set; }
        public decimal ReturnFuelLevel { get; set; }
        public int ReturnAgentId { get; set; }
        public bool IsSmokedIn { get; set; }
        public bool IsClean { get; set; }
        public bool AccessoriesOk { get; set; }
        public string InspectionNotes { get; set; }
    }
}
