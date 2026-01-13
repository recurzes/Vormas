using System;
using System.Collections.Generic;

namespace Vormas.Models
{
    public class CustomerHistory
    {
        public int CustomerId { get; set; }
        public int TotalRentals { get; set; }
        public decimal TotalAmountSpent { get; set; }
        public int TotalDamages { get; set; }
        public decimal TotalDamageCharges { get; set; }
        public int LateReturns { get; set; }
        public decimal TotalPayments { get; set; }
        public int DrivingViolations { get; set; }
        public int MajorViolations { get; set; }
        public List<RentalHistoryItem> RentalHistory { get; set; } = new List<RentalHistoryItem>();
    }

    public class RentalHistoryItem
    {
        public int RentalId { get; set; }
        public string VehicleInfo { get; set; }
        public DateTime PickupDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string Status { get; set; }
        public decimal TotalAmount { get; set; }
        public bool WasLate { get; set; }
        public bool HasDamage { get; set; }
    }
}
