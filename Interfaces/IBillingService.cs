#nullable enable
using System.Collections.Generic;
using Vormas.Models;

namespace Vormas.Interfaces
{
    public interface IBillingService
    {
        // Invoice Operations
        Invoice? GetInvoiceByRentalId(int rentalId);
        Invoice? GetInvoiceById(int invoiceId);
        List<Invoice> GetAllInvoices(string? statusFilter = null);
        List<Invoice> GetUnpaidInvoices();
        
        // Line Item Operations
        List<InvoiceLineItem> GetInvoiceLineItems(int invoiceId);
        
        // Invoice Generation
        Invoice GenerateInvoice(int rentalId, int generatedByUserId);
        void AddInvoiceLineItem(int invoiceId, InvoiceLineItem lineItem);
        
        // Payment Operations
        List<Payment> GetPaymentsByInvoiceId(int invoiceId);
        void RecordPayment(PaymentRequest request);
        void UpdateInvoiceStatus(int invoiceId, string status);
    }
}
