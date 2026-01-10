using Vormas.Models;

namespace Vormas.Interfaces
{
    /// <summary>
    /// Repository interface for report data access operations.
    /// </summary>
    public interface IReportRepository
    {
        /// <summary>
        /// Retrieves dashboard summary data from the database.
        /// </summary>
        /// <returns>DashboardSummaryDto with all KPIs and activity lists.</returns>
        DashboardSummaryDto GetDashboardSummary();
    }
}
