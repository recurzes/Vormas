using System;

namespace Vormas.Models
{
    public class DriverLicense
    {
        public int CustomerId { get; set; }
        public string LicenseNumber { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string IssuingCountry { get; set; }
        public string IssuingStateProvince { get; set; }
        public string LicenseImagePath { get; set; }
        public bool IsInternational { get; set; }
    }
}