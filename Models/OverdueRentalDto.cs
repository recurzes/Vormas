using System;

namespace Vormas.Models
{
    /// <summary>
    /// Data Transfer Object for overdue rental items displayed in the dashboard grid.
    /// </summary>
    public class OverdueRentalDto
    {
        public int RentalId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string VehicleName { get; set; }
        public string LicensePlate { get; set; }
        public DateTime ExpectedReturnDate { get; set; }
        public int DaysOverdue { get; set; }
    }
}
