using System;
using Vormas.Interfaces;
using Vormas.Models;

namespace Vormas.Services
{
    /// <summary>
    /// Service implementation for reporting and dashboard functionality.
    /// Decouples business logic from the UI layer using Dependency Injection.
    /// </summary>
    public class ReportService : IReportService
    {
        private readonly IReportRepository _repository;

        /// <summary>
        /// Initializes a new instance of ReportService with repository injection.
        /// </summary>
        /// <param name="repository">The report repository for data access.</param>
        /// <exception cref="ArgumentNullException">Thrown when repository is null.</exception>
        public ReportService(IReportRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        /// <summary>
        /// Retrieves all dashboard summary data including KPIs and activity lists.
        /// Includes error handling to prevent UI crashes.
        /// </summary>
        /// <returns>DashboardSummaryDto containing all dashboard metrics and lists.</returns>
        /// <exception cref="InvalidOperationException">Thrown when data retrieval fails.</exception>
        public DashboardSummaryDto GetDashboardSummary()
        {
            try
            {
                var summary = _repository.GetDashboardSummary();

                // Apply any business logic or transformations here
                // For example, ensure lists are never null
                if (summary.OverdueRentals == null)
                {
                    summary.OverdueRentals = new System.Collections.Generic.List<OverdueRentalDto>();
                }

                if (summary.TodayActivities == null)
                {
                    summary.TodayActivities = new System.Collections.Generic.List<TodayActivityDto>();
                }

                return summary;
            }
            catch (Exception ex)
            {
                // Log the exception (would use a proper logging framework in production)
                System.Diagnostics.Debug.WriteLine($"Error retrieving dashboard summary: {ex.Message}");

                // Re-throw with a user-friendly message
                throw new InvalidOperationException(
                    "Failed to retrieve dashboard data. Please check your database connection and try again.", ex);
            }
        }
    }
}
