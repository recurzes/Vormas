using System.Collections.Generic;
using Vormas.Models;

namespace Vormas.Interfaces
{
    public interface IRateConfigurationService
    {
        RateConfigurations GetRateConfigurationById(int rateConfigId);
        RateConfigurations GetActiveRateConfigurationByCategory(int categoryId);
        List<RateConfigurations> GetAllRateConfigurations();
        List<RateConfigurations> GetRateConfigurationByCategory(int categoryId);
        void AddRateConfiguration(RateConfigurations rateConfiguration);
        int UpdateRateConfigurations(RateConfigurations rateConfiguration);
    }
}