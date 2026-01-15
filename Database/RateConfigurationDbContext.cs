using System.Collections.Generic;
using Vormas.Helpers;
using Vormas.Interfaces;
using Vormas.Models;

namespace Vormas.Database
{
    public class RateConfigurationDbContext: IRateConfigurationService
    {
        private readonly string _connStr = Helpers.MySqlHelper.GetConnectionString();
        
        
        public RateConfigurations GetRateConfigurationById(int rateConfigId)
        {
            return DbCommandHelper.ExecuteReader(_connStr, "prcGetRateConfigurationById", cmd =>
            {
                cmd.Parameters.AddWithValue("p_RateConfigId", rateConfigId);
            }, reader =>
            {
                return DataReaderMapper.MapToModel<RateConfigurations>(reader);
            });
        }

        public RateConfigurations GetActiveRateConfigurationByCategory(int categoryId)
        {
            return DbCommandHelper.ExecuteReader(_connStr, "prcGetActiveRateConfigurationByCategory", cmd =>
                {
                    cmd.Parameters.AddWithValue("p_CategoryId", categoryId);
                },
                reader =>
                {
                    return DataReaderMapper.MapToModel<RateConfigurations>(reader);
                });
        }

        public List<RateConfigurations> GetAllRateConfigurations()
        {
            return DbCommandHelper.ExecuteReader(_connStr, "prcGetAllRateConfiguration", cmd => { }, reader =>
            {
                return DataReaderMapper.MapToList<RateConfigurations>(reader);
            });
        }

        public List<RateConfigurations> GetRateConfigurationByCategory(int categoryId)
        {
            return DbCommandHelper.ExecuteReader(_connStr, "prcGetRateConfigurationByCategory", cmd =>
            {
                cmd.Parameters.AddWithValue("p_CategoryId", categoryId);
            }, reader =>
            {
                return DataReaderMapper.MapToList<RateConfigurations>(reader);
            });
        }

        public void AddRateConfiguration(RateConfigurations rateConfiguration)
        {
            DbCommandHelper.ExecuteNonQuery(_connStr, "prcAddRateConfiguration", cmd =>
            {
                cmd.Parameters.AddWithValue("p_CategoryId", rateConfiguration.CategoryId);
                cmd.Parameters.AddWithValue("p_DailyRate", rateConfiguration.DailyRate);
                cmd.Parameters.AddWithValue("p_WeeklyRate", rateConfiguration.WeeklyRate);
                cmd.Parameters.AddWithValue("p_MonthlyRate", rateConfiguration.MonthlyRate);
                cmd.Parameters.AddWithValue("p_HourlyRate", rateConfiguration.HourlyRate);
                cmd.Parameters.AddWithValue("p_EffectiveFrom", rateConfiguration.EffectiveFrom);
                cmd.Parameters.AddWithValue("p_EffectiveTo", rateConfiguration.EffectiveTo);
            });
        }

        public int UpdateRateConfigurations(RateConfigurations rateConfiguration)
        {
            int rowsAffected = DbCommandHelper.ExecuteNonQuery(_connStr, "prcUpdateRateConfiguration", cmd =>
            {
                cmd.Parameters.AddWithValue("p_RateConfigId", rateConfiguration.RateConfigId);
                cmd.Parameters.AddWithValue("p_CategoryId", rateConfiguration.CategoryId);
                cmd.Parameters.AddWithValue("p_DailyRate", rateConfiguration.DailyRate);
                cmd.Parameters.AddWithValue("p_WeeklyRate", rateConfiguration.WeeklyRate);
                cmd.Parameters.AddWithValue("p_MonthlyRate", rateConfiguration.MonthlyRate);
                cmd.Parameters.AddWithValue("p_HourlyRate", rateConfiguration.HourlyRate);
                cmd.Parameters.AddWithValue("p_EffectiveFrom", rateConfiguration.EffectiveFrom);
                cmd.Parameters.AddWithValue("p_EffectiveTo", rateConfiguration.EffectiveTo);
            });

            return rowsAffected;
        }

        public void DeleteRateConfiguration(int rateConfigId)
        {
            DbCommandHelper.ExecuteNonQuery(_connStr, "prcDeleteRateConfiguration", cmd =>
            {
                cmd.Parameters.AddWithValue("p_RateConfigId", rateConfigId);
            });
        }
    }
}