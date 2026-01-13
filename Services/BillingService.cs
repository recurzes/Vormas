using System.Collections.Generic;
using Vormas.Interfaces;
using Vormas.Models;

namespace Vormas.Services
{
    public class BillingService : IBillingService
    {
        private readonly IBillingService _repository;

        public BillingService(IBillingService repository)
        {
            _repository = repository;
        }

        public Invoice GetInvoiceByRentalId(int rentalId)
        {
            return _repository.GetInvoiceByRentalId(rentalId);
        }

        public Invoice GetInvoiceById(int invoiceId)
        {
            return _repository.GetInvoiceById(invoiceId);
        }

        public List<Invoice> GetAllInvoices(string statusFilter = null)
        {
            return _repository.GetAllInvoices(statusFilter);
        }

        public List<Invoice> GetUnpaidInvoices()
        {
            return _repository.GetUnpaidInvoices();
        }

        public List<InvoiceLineItem> GetInvoiceLineItems(int invoiceId)
        {
            return _repository.GetInvoiceLineItems(invoiceId);
        }

        public Invoice GenerateInvoice(int rentalId, int generatedByUserId)
        {
            return _repository.GenerateInvoice(rentalId, generatedByUserId);
        }

        public void AddInvoiceLineItem(int invoiceId, InvoiceLineItem lineItem)
        {
            _repository.AddInvoiceLineItem(invoiceId, lineItem);
        }

        public List<Payment> GetPaymentsByInvoiceId(int invoiceId)
        {
            return _repository.GetPaymentsByInvoiceId(invoiceId);
        }

        public void RecordPayment(PaymentRequest request)
        {
            _repository.RecordPayment(request);
        }

        public void UpdateInvoiceStatus(int invoiceId, string status)
        {
            _repository.UpdateInvoiceStatus(invoiceId, status);
        }
    }
}
