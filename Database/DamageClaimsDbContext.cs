using System.Collections.Generic;
using Vormas.Helpers;
using Vormas.Interfaces;
using Vormas.Models;

namespace Vormas.Database
{
    public class DamageClaimsDbContext : IDamageClaimsService
    {
        private readonly string _connStr = MySqlHelper.GetConnectionString();

        public void AddDamageClaim(DamageClaimRequest request)
        {
            DbCommandHelper.ExecuteNonQuery(_connStr, "prcAddDamageClaim", cmd =>
            {
                cmd.Parameters.AddWithValue("pRentalId", request.RentalId);
                cmd.Parameters.AddWithValue("pDamageId", request.DamageId);
                cmd.Parameters.AddWithValue("pReportedByUserId", request.ReportedByUserId);
                cmd.Parameters.AddWithValue("pPhotoPath", request.PhotoPath);
                cmd.Parameters.AddWithValue("pInitialChargeAmount", request.InitialChargeAmount);
            });
        }

        public List<DamageReports> GetCurrentRentalDamageClaims(int rentalId)
        {
            return DbCommandHelper.ExecuteReader(_connStr, "prcGetCurrentRentalDamageClaims",
                cmd => { cmd.Parameters.AddWithValue("pRentalId", rentalId); },
                reader => { return DataReaderMapper.MapToList<DamageReports>(reader); });
        }

        public List<DamageReports> GetPendingDamageReports()
        {
            return DbCommandHelper.ExecuteReader(_connStr, "prcGetPendingDamageReports", cmd => { },
                reader => { return DataReaderMapper.MapToList<DamageReports>(reader); });
        }

        public List<DamageReports> GetALlDamageClaims(string statusFilter = null)
        {
            return DbCommandHelper.ExecuteReader(_connStr, "prcGetAllDamageClaims",
                cmd => { cmd.Parameters.AddWithValue("pStatusFilter", statusFilter); },
                reader => { return DataReaderMapper.MapToList<DamageReports>(reader); });
        }

        public DamageReports ApproveDamageReport(int damageReportId, decimal chargeAmount, int approvedByUserId)
        {
            return DbCommandHelper.ExecuteReader(_connStr, "prcApproveDamageReport", cmd =>
            {
                cmd.Parameters.AddWithValue("pDamageReportId", damageReportId);
                cmd.Parameters.AddWithValue("pChargeAmount", chargeAmount);
                cmd.Parameters.AddWithValue("pApprovedByUserId", approvedByUserId);
            }, reader => { return DataReaderMapper.MapToModel<DamageReports>(reader); });
        }

        public int RejectDamageReport(int damageReportId, int approvedByUserId)
        {
            return DbCommandHelper.ExecuteNonQuery(_connStr, "prcRejectDamageReport", cmd =>
            {
                cmd.Parameters.AddWithValue("pDamageReportId", damageReportId);
                cmd.Parameters.AddWithValue("pApprovedByUserId", approvedByUserId);
            });
        }

        public List<DamageTypes> GetAvailableDamageTypes()
        {
            return DbCommandHelper.ExecuteReader(_connStr, "prcGetAvaialableDamageTypes", cmd => { },
                reader => { return DataReaderMapper.MapToList<DamageTypes>(reader); });
        }

        public DamageReports GetDamageReportsById(int damageReportId)
        {
            return DbCommandHelper.ExecuteReader(_connStr, "prcGetDamageReportById",
                cmd => { cmd.Parameters.AddWithValue("pDamageReportId", damageReportId); },
                reader => { return DataReaderMapper.MapToModel<DamageReports>(reader); });
        }
    }
}