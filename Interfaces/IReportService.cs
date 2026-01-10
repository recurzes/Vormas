using Vormas.Models;

namespace Vormas.Interfaces
{
    /// <summary>
    /// Service interface for reporting and dashboard functionality.
    /// Follows Interface Segregation Principle (ISP) - single responsibility for reports.
    /// </summary>
    public interface IReportService
    {
        /// <summary>
        /// Retrieves all dashboard summary data including KPIs and activity lists.
        /// </summary>
        /// <returns>DashboardSummaryDto containing all dashboard metrics and lists.</returns>
        DashboardSummaryDto GetDashboardSummary();
    }
}
