#nullable enable
using System;
using System.Collections.Generic;

namespace Vormas.Models
{
    /// <summary>
    /// Represents an invoice for a rental transaction
    /// </summary>
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public int RentalId { get; set; }
        public decimal SubtotalAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DepositApplied { get; set; }
        public decimal BalanceDue { get; set; }
        public DateTime GeneratedAt { get; set; }
        public string Status { get; set; } = "Unpaid"; // Unpaid, PartiallyPaid, Paid, Refunded

        // Joined fields from queries
        public string? CustomerName { get; set; }
        public string? CustomerPhone { get; set; }
        public string? CustomerEmail { get; set; }
        public string? CustomerAddress { get; set; }
        public string? VehicleCode { get; set; }
        public string? VehicleDescription { get; set; }
        public DateTime? PickupDateTime { get; set; }
        public DateTime? ReturnDateTime { get; set; }

        // Navigation property
        public List<InvoiceLineItem> LineItems { get; set; } = new List<InvoiceLineItem>();
    }

    /// <summary>
    /// Represents a line item on an invoice
    /// </summary>
    public class InvoiceLineItem
    {
        public int LineItemId { get; set; }
        public int InvoiceId { get; set; }
        public string LineType { get; set; } = "Other"; // BaseRental, AdditionalService, FuelCharge, LateFee, MileageOverage, CleaningFee, DamageCharge, TollFee, Other
        public string? Description { get; set; }
        public decimal Quantity { get; set; } = 1.00m;
        public decimal UnitPrice { get; set; }
        public decimal LineTotal { get; set; }
    }

    /// <summary>
    /// Represents a payment against an invoice
    /// </summary>
    public class Payment
    {
        public int PaymentId { get; set; }
        public int InvoiceId { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public string Method { get; set; } = "Cash"; // Cash, Card, Transfer, Check
        public string? ReferenceNumber { get; set; }
        public int ProcessedByUserId { get; set; }

        // Joined fields
        public string? ProcessedByName { get; set; }
    }

    /// <summary>
    /// Request object for recording a payment
    /// </summary>
    public class PaymentRequest
    {
        public int InvoiceId { get; set; }
        public decimal Amount { get; set; }
        public string Method { get; set; } = "Cash";
        public string? ReferenceNumber { get; set; }
        public int ProcessedByUserId { get; set; }
    }
}
