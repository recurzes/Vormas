#nullable enable
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Vormas.Helpers;
using Vormas.Interfaces;
using Vormas.Models;

namespace Vormas.Database
{
    public class BillingDbContext : IBillingService
    {
        private readonly string _connStr = Helpers.MySqlHelper.GetConnectionString();

        public Invoice? GetInvoiceByRentalId(int rentalId)
        {
            return DbCommandHelper.ExecuteReader(_connStr, "prcGetInvoiceByRentalId", cmd =>
            {
                cmd.Parameters.AddWithValue("pRentalId", rentalId);
            }, reader =>
            {
                if (reader.Read())
                {
                    return MapInvoice(reader);
                }
                return null;
            });
        }

        public Invoice? GetInvoiceById(int invoiceId)
        {
            return DbCommandHelper.ExecuteReader(_connStr, "prcGetInvoiceById", cmd =>
            {
                cmd.Parameters.AddWithValue("pInvoiceId", invoiceId);
            }, reader =>
            {
                if (reader.Read())
                {
                    return MapInvoice(reader);
                }
                return null;
            });
        }

        public List<Invoice> GetAllInvoices(string? statusFilter = null)
        {
            return DbCommandHelper.ExecuteReader(_connStr, "prcGetAllInvoices", cmd =>
            {
                cmd.Parameters.AddWithValue("pStatusFilter", statusFilter ?? (object)DBNull.Value);
            }, reader =>
            {
                var invoices = new List<Invoice>();
                while (reader.Read())
                {
                    invoices.Add(MapInvoice(reader));
                }
                return invoices;
            });
        }

        public List<Invoice> GetUnpaidInvoices()
        {
            return GetAllInvoices("Unpaid");
        }

        public List<InvoiceLineItem> GetInvoiceLineItems(int invoiceId)
        {
            return DbCommandHelper.ExecuteReader(_connStr, "prcGetInvoiceLineItems", cmd =>
            {
                cmd.Parameters.AddWithValue("pInvoiceId", invoiceId);
            }, reader =>
            {
                return DataReaderMapper.MapToList<InvoiceLineItem>(reader);
            });
        }

        public Invoice GenerateInvoice(int rentalId, int generatedByUserId)
        {
            return DbCommandHelper.ExecuteReader(_connStr, "prcGenerateInvoice", cmd =>
            {
                cmd.Parameters.AddWithValue("pRentalId", rentalId);
                cmd.Parameters.AddWithValue("pGeneratedByUserId", generatedByUserId);
            }, reader =>
            {
                if (reader.Read())
                {
                    return MapInvoice(reader);
                }
                return new Invoice();
            });
        }

        public void AddInvoiceLineItem(int invoiceId, InvoiceLineItem lineItem)
        {
            DbCommandHelper.ExecuteNonQuery(_connStr, "prcAddInvoiceLineItem", cmd =>
            {
                cmd.Parameters.AddWithValue("pInvoiceId", invoiceId);
                cmd.Parameters.AddWithValue("pLineType", lineItem.LineType);
                cmd.Parameters.AddWithValue("pDescription", lineItem.Description ?? string.Empty);
                cmd.Parameters.AddWithValue("pQuantity", lineItem.Quantity);
                cmd.Parameters.AddWithValue("pUnitPrice", lineItem.UnitPrice);
                cmd.Parameters.AddWithValue("pLineTotal", lineItem.LineTotal);
            });
        }

        public List<Payment> GetPaymentsByInvoiceId(int invoiceId)
        {
            return DbCommandHelper.ExecuteReader(_connStr, "prcGetPaymentsByInvoiceId", cmd =>
            {
                cmd.Parameters.AddWithValue("pInvoiceId", invoiceId);
            }, reader =>
            {
                return DataReaderMapper.MapToList<Payment>(reader);
            });
        }

        public void RecordPayment(PaymentRequest request)
        {
            DbCommandHelper.ExecuteNonQuery(_connStr, "prcRecordPayment", cmd =>
            {
                cmd.Parameters.AddWithValue("pInvoiceId", request.InvoiceId);
                cmd.Parameters.AddWithValue("pAmount", request.Amount);
                cmd.Parameters.AddWithValue("pMethod", request.Method);
                cmd.Parameters.AddWithValue("pReferenceNumber", request.ReferenceNumber ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("pProcessedByUserId", request.ProcessedByUserId);
            });
        }

        public void UpdateInvoiceStatus(int invoiceId, string status)
        {
            DbCommandHelper.ExecuteNonQuery(_connStr, "prcUpdateInvoiceStatus", cmd =>
            {
                cmd.Parameters.AddWithValue("pInvoiceId", invoiceId);
                cmd.Parameters.AddWithValue("pStatus", status);
            });
        }

        private Invoice MapInvoice(MySqlDataReader reader)
        {
            var invoice = new Invoice
            {
                InvoiceId = reader.GetInt32("InvoiceId"),
                RentalId = reader.GetInt32("RentalId"),
                SubtotalAmount = reader.GetDecimal("SubtotalAmount"),
                TaxAmount = reader.GetDecimal("TaxAmount"),
                TotalAmount = reader.GetDecimal("TotalAmount"),
                DepositApplied = reader.GetDecimal("DepositApplied"),
                BalanceDue = reader.GetDecimal("BalanceDue"),
                GeneratedAt = reader.GetDateTime("GeneratedAt"),
                Status = reader.GetString("Status")
            };

            // Try to get joined fields (may not be present in all queries)
            try
            {
                if (HasColumn(reader, "CustomerName") && !reader.IsDBNull(reader.GetOrdinal("CustomerName")))
                    invoice.CustomerName = reader.GetString("CustomerName");
                if (HasColumn(reader, "CustomerPhone") && !reader.IsDBNull(reader.GetOrdinal("CustomerPhone")))
                    invoice.CustomerPhone = reader.GetString("CustomerPhone");
                if (HasColumn(reader, "CustomerEmail") && !reader.IsDBNull(reader.GetOrdinal("CustomerEmail")))
                    invoice.CustomerEmail = reader.GetString("CustomerEmail");
                if (HasColumn(reader, "CustomerAddress") && !reader.IsDBNull(reader.GetOrdinal("CustomerAddress")))
                    invoice.CustomerAddress = reader.GetString("CustomerAddress");
                if (HasColumn(reader, "VehicleCode") && !reader.IsDBNull(reader.GetOrdinal("VehicleCode")))
                    invoice.VehicleCode = reader.GetString("VehicleCode");
                if (HasColumn(reader, "VehicleDescription") && !reader.IsDBNull(reader.GetOrdinal("VehicleDescription")))
                    invoice.VehicleDescription = reader.GetString("VehicleDescription");
                if (HasColumn(reader, "PickupDateTime") && !reader.IsDBNull(reader.GetOrdinal("PickupDateTime")))
                    invoice.PickupDateTime = reader.GetDateTime("PickupDateTime");
                if (HasColumn(reader, "ReturnDateTime") && !reader.IsDBNull(reader.GetOrdinal("ReturnDateTime")))
                    invoice.ReturnDateTime = reader.GetDateTime("ReturnDateTime");
            }
            catch { /* Ignore missing columns */ }

            return invoice;
        }

        private bool HasColumn(MySqlDataReader reader, string columnName)
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (reader.GetName(i).Equals(columnName, StringComparison.OrdinalIgnoreCase))
                    return true;
            }
            return false;
        }
    }
}
