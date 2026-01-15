using System;

namespace Vormas.Models
{
    public class RateConfigurations
    {
        public int RateConfigId { get; set; }
        public int CategoryId { get; set; }
        public decimal DailyRate { get; set; }
        public decimal WeeklyRate { get; set; }
        public decimal MonthlyRate { get; set; }
        public decimal HourlyRate { get; set; }
        public DateTime EffectiveFrom { get; set; }
        public DateTime? EffectiveTo { get; set; }
    }
}