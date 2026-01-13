using System;

namespace Vormas.Models
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public int RentalId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsPaid { get; set; }
        public string PaymentMethod { get; set; }
    }
}
