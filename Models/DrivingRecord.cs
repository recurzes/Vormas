using System;

namespace Vormas.Models
{
    public class DrivingRecord
    {
        public int RecordId { get; set; }
        public int CustomerId { get; set; }
        public DateTime ViolationDate { get; set; }
        public string ViolationType { get; set; }
        public string Description { get; set; }
        public decimal FineAmount { get; set; }
        public bool IsMajorViolation { get; set; }
        public string IssuingAuthority { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
