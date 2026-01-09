using System.Collections.Generic;
using Vormas.Database;
using Vormas.Interfaces;
using Vormas.Models;

namespace Vormas.Services
{
    public class DamageClaimsService: IDamageClaimsService
    {
        private readonly IDamageClaimsService _repo;

        public DamageClaimsService(IDamageClaimsService repo)
        {
            _repo = repo;
        }

        public void AddDamageClaim(DamageClaimRequest request)
        {
            _repo.AddDamageClaim(request);
        }

        public List<DamageReports> GetCurrentRentalDamageClaims(int rentalId)
        {
            return _repo.GetCurrentRentalDamageClaims(rentalId);
        }

        public List<DamageReports> GetPendingDamageReports()
        {
            return _repo.GetPendingDamageReports();
        }

        public List<DamageReports> GetALlDamageClaims(string statusFilter = null)
        {
            return _repo.GetALlDamageClaims(statusFilter);
        }

        public DamageReports ApproveDamageReport(int damageReportId, decimal chargeAmount, int approvedByUserId)
        {
            return _repo.ApproveDamageReport(damageReportId, chargeAmount, approvedByUserId);
        }

        public int RejectDamageReport(int damageReportId, int approvedByUserId)
        {
            return _repo.RejectDamageReport(damageReportId, approvedByUserId);
        }

        public List<DamageTypes> GetAvailableDamageTypes()
        {
            return _repo.GetAvailableDamageTypes();
        }

        public DamageReports GetDamageReportsById(int damageReportId)
        {
            return _repo.GetDamageReportsById(damageReportId);
        }
    }
}