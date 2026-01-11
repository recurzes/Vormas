using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using Vormas.Interfaces;
using Vormas.Models;
using Vormas.Navigation;

namespace Vormas.Forms
{
    public partial class BillingForm : PageControl
    {
        private readonly IBillingService _billingService;
        private readonly ISessionService _sessionService;
        private readonly BindingSource _invoiceBindingSource;
        private readonly BindingSource _lineItemBindingSource;
        private Invoice _selectedInvoice;
        private List<InvoiceLineItem> _currentLineItems;
        private PrintDocument _printDocument;
        private int _currentPrintPage;

        public BillingForm(IBillingService billingService, ISessionService sessionService)
        {
            InitializeComponent();

            _billingService = billingService ?? throw new ArgumentNullException(nameof(billingService));
            _sessionService = sessionService ?? throw new ArgumentNullException(nameof(sessionService));
            _invoiceBindingSource = new BindingSource();
            _lineItemBindingSource = new BindingSource();
            _currentLineItems = new List<InvoiceLineItem>();

            ConfigureInvoiceGrid();
            ConfigureLineItemGrid();
            SetupPrintDocument();
            LoadInvoices();
        }

        public override void OnNavigatedTo()
        {
            base.OnNavigatedTo();
            
            if (Parameter is int rentalId && rentalId > 0)
            {
                try
                {
                    var invoice = _billingService.GetInvoiceByRentalId(rentalId);
                    if (invoice != null)
                    {
                        _selectedInvoice = invoice;
                        LoadInvoiceDetails(invoice);
                        
                        
                        foreach (DataGridViewRow row in dgvInvoices.Rows)
                        {
                            if (row.DataBoundItem is Invoice inv && inv.RentalId == rentalId)
                            {
                                row.Selected = true;
                                dgvInvoices.CurrentCell = row.Cells[0];
                                break;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($@"Error loading invoice for rental: {ex.Message}", @"Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void ConfigureInvoiceGrid()
        {
            dgvInvoices.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInvoices.MultiSelect = false;
            dgvInvoices.ReadOnly = true;
            dgvInvoices.AutoGenerateColumns = false;

            dgvInvoices.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "InvoiceId", HeaderText = @"Invoice #", Width = 70 });
            dgvInvoices.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "CustomerName", HeaderText = @"Customer", Width = 150 });
            dgvInvoices.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "VehicleCode", HeaderText = @"Vehicle", Width = 80 });
            dgvInvoices.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "TotalAmount", HeaderText = @"Total", Width = 90, DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" } });
            dgvInvoices.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "BalanceDue", HeaderText = @"Balance", Width = 90, DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" } });
            dgvInvoices.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "Status", HeaderText = @"Status", Width = 90 });
            dgvInvoices.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "GeneratedAt", HeaderText = @"Date", Width = 100, DefaultCellStyle = new DataGridViewCellStyle { Format = "yyyy-MM-dd" } });

            dgvInvoices.SelectionChanged += DgvInvoices_SelectionChanged;
        }

        private void ConfigureLineItemGrid()
        {
            dgvLineItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLineItems.MultiSelect = false;
            dgvLineItems.ReadOnly = true;
            dgvLineItems.AutoGenerateColumns = false;

            dgvLineItems.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "LineType", HeaderText = @"Type", Width = 100 });
            dgvLineItems.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "Description", HeaderText = @"Description", Width = 250 });
            dgvLineItems.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "Quantity", HeaderText = @"Qty", Width = 50, DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" } });
            dgvLineItems.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "UnitPrice", HeaderText = @"Unit Price", Width = 90, DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" } });
            dgvLineItems.Columns.Add(new DataGridViewTextBoxColumn
                { DataPropertyName = "LineTotal", HeaderText = @"Total", Width = 90, DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" } });
        }

        private void SetupPrintDocument()
        {
            _printDocument = new PrintDocument();
            _printDocument.PrintPage += PrintDocument_PrintPage;
            _printDocument.BeginPrint += (s, e) => _currentPrintPage = 0;
        }

        private void DgvInvoices_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvInvoices.CurrentRow?.DataBoundItem is Invoice invoice)
            {
                _selectedInvoice = invoice;
                LoadInvoiceDetails(invoice);
            }
        }

        private void LoadInvoices()
        {
            try
            {
                string statusFilter = cmbStatusFilter.SelectedItem?.ToString();
                if (statusFilter == "All") statusFilter = null;

                var invoices = _billingService.GetAllInvoices(statusFilter);
                _invoiceBindingSource.DataSource = invoices;
                dgvInvoices.DataSource = _invoiceBindingSource;

                lblInvoiceCount.Text = $@"Invoices: {invoices.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"Error loading invoices: {ex.Message}", @"Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadInvoiceDetails(Invoice invoice)
        {
            try
            {
                _currentLineItems = _billingService.GetInvoiceLineItems(invoice.InvoiceId);
                _lineItemBindingSource.DataSource = _currentLineItems;
                dgvLineItems.DataSource = _lineItemBindingSource;
                
                lblCustomerName.Text = invoice.CustomerName ?? "N/A";
                lblCustomerContact.Text = $@"{invoice.CustomerPhone ?? ""} | {invoice.CustomerEmail ?? ""}";
                lblVehicleInfo.Text = $@"{invoice.VehicleCode ?? ""} - {invoice.VehicleDescription ?? ""}";
                lblRentalDates.Text = $@"Pickup: {invoice.PickupDateTime:yyyy-MM-dd HH:mm} → Return: {invoice.ReturnDateTime:yyyy-MM-dd HH:mm}";

                lblSubtotal.Text = $@"₱{invoice.SubtotalAmount:N2}";
                lblTax.Text = $@"₱{invoice.TaxAmount:N2}";
                lblTotal.Text = $@"₱{invoice.TotalAmount:N2}";
                lblDeposit.Text = $@"₱{invoice.DepositApplied:N2}";
                lblBalanceDue.Text = $@"₱{invoice.BalanceDue:N2}";
                lblStatus.Text = invoice.Status;
                
                switch (invoice.Status)
                {
                    case "Paid":
                        lblStatus.ForeColor = Color.Green;
                        break;
                    case "Unpaid":
                        lblStatus.ForeColor = Color.Red;
                        break;
                    case "PartiallyPaid":
                        lblStatus.ForeColor = Color.Orange;
                        break;
                    default:
                        lblStatus.ForeColor = Color.Black;
                        break;
                }

                btnPrint.Enabled = true;
                btnRecordPayment.Enabled = invoice.Status != "Paid" && invoice.Status != "Refunded";
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"Error loading invoice details: {ex.Message}", @"Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadInvoices();
        }

        private void cmbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadInvoices();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (_selectedInvoice == null)
            {
                MessageBox.Show(@"Please select an invoice to print.", @"Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var printPreview = new PrintPreviewDialog())
            {
                printPreview.Document = _printDocument;
                printPreview.Width = 800;
                printPreview.Height = 600;

                if (printPreview.ShowDialog() == DialogResult.OK)
                {
                    _printDocument.Print();
                }
            }
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (_selectedInvoice == null) return;

            Graphics g = e.Graphics;
            float yPos = 50;
            float leftMargin = 50;
            float rightMargin = e.PageBounds.Width - 50;
            float pageWidth = rightMargin - leftMargin;
            
            Font titleFont = new Font("Arial", 18, FontStyle.Bold);
            Font headerFont = new Font("Arial", 12, FontStyle.Bold);
            Font normalFont = new Font("Arial", 10);
            Font smallFont = new Font("Arial", 8);
            
            g.DrawString("VORMAS CAR RENTAL", titleFont, Brushes.DarkBlue, leftMargin, yPos);
            yPos += 30;
            g.DrawString("Vehicle Operations & Rental Management System", normalFont, Brushes.Black, leftMargin, yPos);
            yPos += 25;
            
            g.DrawLine(Pens.DarkBlue, leftMargin, yPos, rightMargin, yPos);
            yPos += 10;
            g.DrawString($"INVOICE #{_selectedInvoice.InvoiceId}", headerFont, Brushes.Black, leftMargin, yPos);
            g.DrawString($"Date: {_selectedInvoice.GeneratedAt:yyyy-MM-dd}", normalFont, Brushes.Black, rightMargin - 150, yPos);
            yPos += 30;
            
            g.DrawString("Bill To:", headerFont, Brushes.Black, leftMargin, yPos);
            yPos += 20;
            g.DrawString(_selectedInvoice.CustomerName ?? "N/A", normalFont, Brushes.Black, leftMargin + 10, yPos);
            yPos += 15;
            g.DrawString(_selectedInvoice.CustomerPhone ?? "", normalFont, Brushes.Black, leftMargin + 10, yPos);
            yPos += 15;
            g.DrawString(_selectedInvoice.CustomerEmail ?? "", normalFont, Brushes.Black, leftMargin + 10, yPos);
            yPos += 25;
            
            g.DrawString("Rental Details:", headerFont, Brushes.Black, leftMargin, yPos);
            yPos += 20;
            g.DrawString($"Vehicle: {_selectedInvoice.VehicleCode} - {_selectedInvoice.VehicleDescription}", normalFont, Brushes.Black, leftMargin + 10, yPos);
            yPos += 15;
            g.DrawString($"Pickup: {_selectedInvoice.PickupDateTime:yyyy-MM-dd HH:mm}", normalFont, Brushes.Black, leftMargin + 10, yPos);
            yPos += 15;
            g.DrawString($"Return: {_selectedInvoice.ReturnDateTime:yyyy-MM-dd HH:mm}", normalFont, Brushes.Black, leftMargin + 10, yPos);
            yPos += 30;
            
            g.DrawLine(Pens.Black, leftMargin, yPos, rightMargin, yPos);
            yPos += 5;
            g.DrawString("Description", headerFont, Brushes.Black, leftMargin, yPos);
            g.DrawString("Qty", headerFont, Brushes.Black, leftMargin + 300, yPos);
            g.DrawString("Unit Price", headerFont, Brushes.Black, leftMargin + 360, yPos);
            g.DrawString("Total", headerFont, Brushes.Black, leftMargin + 450, yPos);
            yPos += 20;
            g.DrawLine(Pens.Black, leftMargin, yPos, rightMargin, yPos);
            yPos += 5;
            
            foreach (var item in _currentLineItems)
            {
                g.DrawString(item.Description ?? item.LineType, normalFont, Brushes.Black, leftMargin, yPos);
                g.DrawString(item.Quantity.ToString("N2"), normalFont, Brushes.Black, leftMargin + 300, yPos);
                g.DrawString($"₱{item.UnitPrice:N2}", normalFont, Brushes.Black, leftMargin + 360, yPos);
                g.DrawString($"₱{item.LineTotal:N2}", normalFont, Brushes.Black, leftMargin + 450, yPos);
                yPos += 18;
            }

            yPos += 10;
            g.DrawLine(Pens.Black, leftMargin, yPos, rightMargin, yPos);
            yPos += 15;
            
            float totalLabelX = leftMargin + 350;
            float totalValueX = leftMargin + 450;

            g.DrawString("Subtotal:", normalFont, Brushes.Black, totalLabelX, yPos);
            g.DrawString($"₱{_selectedInvoice.SubtotalAmount:N2}", normalFont, Brushes.Black, totalValueX, yPos);
            yPos += 18;

            g.DrawString("Tax (12%):", normalFont, Brushes.Black, totalLabelX, yPos);
            g.DrawString($"₱{_selectedInvoice.TaxAmount:N2}", normalFont, Brushes.Black, totalValueX, yPos);
            yPos += 18;

            g.DrawString("Total:", headerFont, Brushes.Black, totalLabelX, yPos);
            g.DrawString($"₱{_selectedInvoice.TotalAmount:N2}", headerFont, Brushes.Black, totalValueX, yPos);
            yPos += 20;

            g.DrawString("Deposit Applied:", normalFont, Brushes.Black, totalLabelX, yPos);
            g.DrawString($"(₱{_selectedInvoice.DepositApplied:N2})", normalFont, Brushes.Black, totalValueX, yPos);
            yPos += 18;

            g.DrawString("Balance Due:", headerFont, Brushes.Black, totalLabelX, yPos);
            g.DrawString($"₱{_selectedInvoice.BalanceDue:N2}", headerFont, Brushes.DarkRed, totalValueX, yPos);
            yPos += 30;
            
            g.DrawString($"Status: {_selectedInvoice.Status}", headerFont,
                _selectedInvoice.Status == "Paid" ? Brushes.Green : Brushes.Red, leftMargin, yPos);
            yPos += 40;
            
            g.DrawLine(Pens.Gray, leftMargin, yPos, rightMargin, yPos);
            yPos += 10;
            g.DrawString("Thank you for choosing Vormas Car Rental!", smallFont, Brushes.Gray, leftMargin, yPos);
            yPos += 12;
            g.DrawString($"Printed on: {DateTime.Now:yyyy-MM-dd HH:mm:ss}", smallFont, Brushes.Gray, leftMargin, yPos);

            e.HasMorePages = false;
        }

        private void btnRecordPayment_Click(object sender, EventArgs e)
        {
            if (_selectedInvoice == null)
            {
                MessageBox.Show(@"Please select an invoice.", @"Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (numPaymentAmount.Value <= 0)
            {
                MessageBox.Show(@"Please enter a valid payment amount.", @"Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (numPaymentAmount.Value > _selectedInvoice.BalanceDue)
            {
                var result = MessageBox.Show(
                    $@"Payment amount (₱{numPaymentAmount.Value:N2}) exceeds balance due (₱{_selectedInvoice.BalanceDue:N2}). Continue?",
                    @"Confirm Overpayment",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result != DialogResult.Yes) return;
            }

            try
            {
                var payment = new PaymentRequest
                {
                    InvoiceId = _selectedInvoice.InvoiceId,
                    Amount = numPaymentAmount.Value,
                    Method = cmbPaymentMethod.SelectedItem?.ToString() ?? "Cash",
                    ReferenceNumber = txtReferenceNumber.Text,
                    ProcessedByUserId = _sessionService.CurrentUser.UserId
                };

                _billingService.RecordPayment(payment);

                MessageBox.Show(@"Payment recorded successfully!", @"Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                LoadInvoices();
                numPaymentAmount.Value = 0;
                txtReferenceNumber.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"Error recording payment: {ex.Message}", @"Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dgvInvoices.ClearSelection();
            _selectedInvoice = null;
            _currentLineItems.Clear();
            _lineItemBindingSource.DataSource = null;

            lblCustomerName.Text = "";
            lblCustomerContact.Text = "";
            lblVehicleInfo.Text = "";
            lblRentalDates.Text = "";
            lblSubtotal.Text = @"₱0.00";
            lblTax.Text = @"₱0.00";
            lblTotal.Text = @"₱0.00";
            lblDeposit.Text = @"₱0.00";
            lblBalanceDue.Text = @"₱0.00";
            lblStatus.Text = "";

            btnPrint.Enabled = false;
            btnRecordPayment.Enabled = false;
            numPaymentAmount.Value = 0;
            txtReferenceNumber.Text = "";
        }
    }
}
