using System;
using System.Data;
using MySql.Data.MySqlClient;
using Vormas.Helpers;
using Vormas.Interfaces;
using Vormas.Models;

namespace Vormas.Database
{
    /// <summary>
    /// Data access class for report/dashboard data.
    /// Implements IReportRepository and uses the stored procedure sp_DashboardSummary.
    /// </summary>
    public class ReportDbContext : IReportRepository
    {
        private readonly string _connStr = Helpers.MySqlHelper.GetConnectionString();

        /// <summary>
        /// Retrieves dashboard summary by calling sp_DashboardSummary stored procedure.
        /// Handles multiple result sets from the stored procedure.
        /// </summary>
        public DashboardSummaryDto GetDashboardSummary()
        {
            var summary = new DashboardSummaryDto();

            using (var conn = new MySqlConnection(_connStr))
            {
                using (var cmd = new MySqlCommand("sp_DashboardSummary", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        // Result Set 1: KPI Summary (single row)
                        if (reader.Read())
                        {
                            summary.ActiveRentalsCount = GetInt32Safe(reader, "ActiveRentalsCount");
                            summary.ReturnsDueTodayCount = GetInt32Safe(reader, "ReturnsDueTodayCount");
                            summary.AvailableVehiclesCount = GetInt32Safe(reader, "AvailableVehiclesCount");
                            summary.VehiclesInMaintenanceCount = GetInt32Safe(reader, "VehiclesInMaintenanceCount");
                            summary.TodayRevenue = GetDecimalSafe(reader, "TodayRevenue");
                            summary.MonthlyRevenue = GetDecimalSafe(reader, "MonthlyRevenue");
                        }

                        // Result Set 2: Overdue Rentals
                        if (reader.NextResult())
                        {
                            while (reader.Read())
                            {
                                summary.OverdueRentals.Add(new OverdueRentalDto
                                {
                                    RentalId = GetInt32Safe(reader, "RentalId"),
                                    CustomerName = GetStringSafe(reader, "CustomerName"),
                                    CustomerPhone = GetStringSafe(reader, "CustomerPhone"),
                                    VehicleName = GetStringSafe(reader, "VehicleName"),
                                    LicensePlate = GetStringSafe(reader, "LicensePlate"),
                                    ExpectedReturnDate = GetDateTimeSafe(reader, "ExpectedReturnDate"),
                                    DaysOverdue = GetInt32Safe(reader, "DaysOverdue")
                                });
                            }
                        }

                        // Result Set 3: Today's Activities
                        if (reader.NextResult())
                        {
                            while (reader.Read())
                            {
                                summary.TodayActivities.Add(new TodayActivityDto
                                {
                                    RentalId = GetInt32Safe(reader, "RentalId"),
                                    CustomerName = GetStringSafe(reader, "CustomerName"),
                                    VehicleName = GetStringSafe(reader, "VehicleName"),
                                    LicensePlate = GetStringSafe(reader, "LicensePlate"),
                                    ActivityType = GetStringSafe(reader, "ActivityType"),
                                    ScheduledTime = GetDateTimeSafe(reader, "ScheduledTime")
                                });
                            }
                        }
                    }
                }
            }

            return summary;
        }

        #region Helper Methods for Safe Data Reading

        private static int GetInt32Safe(MySqlDataReader reader, string columnName)
        {
            try
            {
                int ordinal = reader.GetOrdinal(columnName);
                return reader.IsDBNull(ordinal) ? 0 : Convert.ToInt32(reader.GetValue(ordinal));
            }
            catch (IndexOutOfRangeException)
            {
                return 0;
            }
        }

        private static decimal GetDecimalSafe(MySqlDataReader reader, string columnName)
        {
            try
            {
                int ordinal = reader.GetOrdinal(columnName);
                return reader.IsDBNull(ordinal) ? 0m : Convert.ToDecimal(reader.GetValue(ordinal));
            }
            catch (IndexOutOfRangeException)
            {
                return 0m;
            }
        }

        private static string GetStringSafe(MySqlDataReader reader, string columnName)
        {
            try
            {
                int ordinal = reader.GetOrdinal(columnName);
                return reader.IsDBNull(ordinal) ? string.Empty : reader.GetString(ordinal);
            }
            catch (IndexOutOfRangeException)
            {
                return string.Empty;
            }
        }

        private static DateTime GetDateTimeSafe(MySqlDataReader reader, string columnName)
        {
            try
            {
                int ordinal = reader.GetOrdinal(columnName);
                return reader.IsDBNull(ordinal) ? DateTime.MinValue : reader.GetDateTime(ordinal);
            }
            catch (IndexOutOfRangeException)
            {
                return DateTime.MinValue;
            }
        }

        #endregion
    }
}
