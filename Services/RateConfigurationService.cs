using System.Collections.Generic;
using Vormas.Interfaces;
using Vormas.Models;

namespace Vormas.Services
{
    public class RateConfigurationService: IRateConfigurationService
    {
        private readonly IRateConfigurationService _repository;

        public RateConfigurationService(IRateConfigurationService repository)
        {
            _repository = repository;
        }
        
        public RateConfigurations GetRateConfigurationById(int rateConfigId)
        {
            return _repository.GetRateConfigurationById(rateConfigId);
        }

        public RateConfigurations GetActiveRateConfigurationByCategory(int categoryId)
        {
            return _repository.GetActiveRateConfigurationByCategory(categoryId);
        }

        public List<RateConfigurations> GetAllRateConfigurations()
        {
            return _repository.GetAllRateConfigurations();
        }

        public List<RateConfigurations> GetRateConfigurationByCategory(int categoryId)
        {
            return _repository.GetRateConfigurationByCategory(categoryId);
        }

        public void AddRateConfiguration(RateConfigurations rateConfiguration)
        {
            _repository.AddRateConfiguration(rateConfiguration);
        }

        public int UpdateRateConfigurations(RateConfigurations rateConfiguration)
        {
            return _repository.UpdateRateConfigurations(rateConfiguration);
        }

        public void DeleteRateConfiguration(int rateConfigId)
        {
            _repository.DeleteRateConfiguration(rateConfigId);
        }
    }
}