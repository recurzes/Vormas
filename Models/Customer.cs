namespace Vormas.Models
{
    public class Customer: Person
    {
        public int CustomerId { get; set; }
        public CustomerType CustomerType { get; set; }
        public string EmergencyContactName { get; set; }
        public string EmergencyContactPhone { get; set; }
        public bool IsBlacklisted { get; set; }
    }

    public enum CustomerType
    {
        Individual,
        Corporate,
        Frequent,
        Blacklisted
    }
}