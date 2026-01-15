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
        public string? CustomDescription { get; set; }
        public string? Severity { get; set; }
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
        
        public string? CustomerName { get; set; }
        public string? VehicleCode { get; set; }
        public string? Make { get; set; }
        public string? Model { get; set; }
        public string? DamageDescription { get; set; }
        public string? Severity { get; set; }
        public decimal? EstimatedRepairCost { get; set; }
        public string? ReportedBy { get; set; }
        public string? ApprovedBy { get; set; }
        public DateTime? ReturnDateTime { get; set; }
        
        public string VehicleInfo => !string.IsNullOrEmpty(Make) ? $"{Make} {Model} ({VehicleCode})" : "";
        public string DamageSeverity => Severity ?? "";
        public string ReportedByName => ReportedBy ?? "";
    }

    public class DamageTypes
    {
        public int DamageId { get; set; }
        public string Description { get; set; } = "";
        public string? Severity { get; set; }
        public decimal? EstimatedRepairCost { get; set; }
    }
}