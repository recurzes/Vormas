using System.Collections.Generic;

namespace Vormas.Models
{
    /// <summary>
    /// Data Transfer Object containing all dashboard summary data.
    /// Populated from the sp_DashboardSummary stored procedure.
    /// </summary>
    public class DashboardSummaryDto
    {
        // KPI Values
        public int ActiveRentalsCount { get; set; }
        public int ReturnsDueTodayCount { get; set; }
        public int AvailableVehiclesCount { get; set; }
        public int VehiclesInMaintenanceCount { get; set; }
        public decimal TodayRevenue { get; set; }
        public decimal MonthlyRevenue { get; set; }

        // Lists
        public List<OverdueRentalDto> OverdueRentals { get; set; }
        public List<TodayActivityDto> TodayActivities { get; set; }

        public DashboardSummaryDto()
        {
            OverdueRentals = new List<OverdueRentalDto>();
            TodayActivities = new List<TodayActivityDto>();
        }
    }
}
