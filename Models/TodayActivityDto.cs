using System;

namespace Vormas.Models
{
    /// <summary>
    /// Data Transfer Object for today's pickup/return activities displayed in the dashboard grid.
    /// </summary>
    public class TodayActivityDto
    {
        public int RentalId { get; set; }
        public string CustomerName { get; set; }
        public string VehicleName { get; set; }
        public string LicensePlate { get; set; }
        public string ActivityType { get; set; } // "Pickup" or "Return Due"
        public DateTime ScheduledTime { get; set; }
    }
}
