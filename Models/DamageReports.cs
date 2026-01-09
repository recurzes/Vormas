#nullable enable
using System;

namespace Vormas.Models
{
    public class DamageClaimRequest
    {
        public int RentalId { get; set; }
        public int DamageId { get; set; }
        public int ReportedByUserId { get; set; }
        public string? PhotoPath { get; set; }
        public decimal? InitialChargeAmount { get; set; }
    }
    
    public class DamageReports
    {
        public int DamageReportId { get; set; }
        public int RentalId { get; set; }
        public int DamageId { get; set; }
        public int ReportedByUserId { get; set; }
        public int? ApprovedByUserId { get; set; }
        public string? PhotoPath { get; set; }
        public decimal ChargeToCustomerAmount { get; set; }
        public string Status { get; set; } = "PendingApproval";
        public DateTime CreatedAt { get; set; } 
    }

    public class DamageTypes
    {
        public int DamageId { get; set; }
        public string Description { get; set; } = "";
        public decimal? EstimatedRepairCost { get; set; }
    }
}