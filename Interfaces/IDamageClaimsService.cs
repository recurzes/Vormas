#nullable enable
using System.Collections.Generic;
using Vormas.Models;

namespace Vormas.Interfaces
{
    public interface IDamageClaimsService
    {
        // Rental Agent Operations
        void AddDamageClaim(DamageClaimRequest request);
        List<DamageReports> GetCurrentRentalDamageClaims(int rentalId);
        
        // Admin Operations
        List<DamageReports> GetPendingDamageReports();
        List<DamageReports> GetALlDamageClaims(string? statusFilter = null);
        DamageReports ApproveDamageReport(int damageReportId, decimal chargeAmount, int approvedByUserId);
        int RejectDamageReport(int damageReportId, int approvedByUserId);
        
        // Helper Operations
        List<DamageTypes> GetAvailableDamageTypes();
        DamageReports? GetDamageReportsById(int damageReportId);
    }
}