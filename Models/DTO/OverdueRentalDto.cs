#nullable enable
using System;

namespace Vormas.Models.DTO
{
    public class OverdueRentalDto
    {
        public int RentalId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string? CustomerPhone { get; set; }
        public string? CustomerEmail { get; set; }
        public string VehicleInfo { get; set; } = string.Empty;
        public string? LicensePlate { get; set; }
        public DateTime PickupDateTime { get; set; }
        public DateTime ExpectedReturnDate { get; set; }
        
        public int DaysOverdue { get; set; }
    }
}