using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PharmacyWinFormsApp.Models;

namespace PharmacyWinFormsApp.Forms.Sales
{
    public class SaleInvoiceForm : Form
    {
        private Label lblTitle;
        private Label lblInvoiceNo;
        private Label lblDate;
        private Label lblCustomer;
        private Label lblInvoiceNoValue;
        private Label lblDateValue;
        private Label lblCustomerValue;
        private DataGridView dgvItems;
        private Label lblSubtotal;
        private Label lblSubtotalValue;
        private Label lblTax;
        private Label lblTaxValue;
        private Label lblTotal;
        private Label lblTotalValue;
        private Button btnPrint;
        private Button btnClose;
        private Panel panelHeader;
        private Panel panelItems;
        private Panel panelPayment;
        
        private decimal totalAmount;
        private List<SaleItemInfo> items;
        private int invoiceNumber;
        
        public SaleInvoiceForm(int invoiceNo, string customerName, List<SaleItemInfo> saleItems)
        {
            invoiceNumber = invoiceNo;
            items = saleItems;
            totalAmount = saleItems.Sum(i => i.Quantity * i.SellingPrice);
            
            InitializeComponent();
            
            lblInvoiceNoValue.Text = $"INV-{invoiceNo:D6}";
            lblDateValue.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");
            lblCustomerValue.Text = string.IsNullOrEmpty(customerName) ? "Walk-in Customer" : customerName;
            
            LoadItems();
            CalculateTotals();
        }
        
        private void InitializeComponent()
        {
            this.lblTitle = new Label();
            this.panelHeader = new Panel();
            this.lblInvoiceNo = new Label();
            this.lblInvoiceNoValue = new Label();
            this.lblDate = new Label();
            this.lblDateValue = new Label();
            this.lblCustomer = new Label();
            this.lblCustomerValue = new Label();
            this.panelItems = new Panel();
            this.dgvItems = new DataGridView();
            this.panelPayment = new Panel();
            this.lblSubtotal = new Label();
            this.lblSubtotalValue = new Label();
            this.lblTax = new Label();
            this.lblTaxValue = new Label();
            this.lblTotal = new Label();
            this.lblTotalValue = new Label();
            this.btnPrint = new Button();
            this.btnClose = new Button();
            
            this.panelHeader.SuspendLayout();
            this.panelItems.SuspendLayout();
            this.panelPayment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.SuspendLayout();
            
            // Form
            this.ClientSize = new Size(700, 650);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Sale Invoice";
            this.BackColor = Color.FromArgb(236, 240, 241);
            
            // lblTitle
            this.lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.FromArgb(41, 128, 185);
            this.lblTitle.Location = new Point(20, 20);
            this.lblTitle.Size = new Size(660, 40);
            this.lblTitle.Text = "🧾 SALE INVOICE";
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            
            // panelHeader
            this.panelHeader.BackColor = Color.White;
            this.panelHeader.Location = new Point(20, 70);
            this.panelHeader.Size = new Size(660, 100);
            this.panelHeader.Padding = new Padding(15);
            
            // lblInvoiceNo
            this.lblInvoiceNo.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.lblInvoiceNo.Location = new Point(15, 15);
            this.lblInvoiceNo.Size = new Size(100, 25);
            this.lblInvoiceNo.Text = "Invoice No:";
            
            // lblInvoiceNoValue
            this.lblInvoiceNoValue.Font = new Font("Segoe UI", 9.5F);
            this.lblInvoiceNoValue.Location = new Point(120, 15);
            this.lblInvoiceNoValue.Size = new Size(200, 25);
            
            // lblDate
            this.lblDate.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.lblDate.Location = new Point(350, 15);
            this.lblDate.Size = new Size(80, 25);
            this.lblDate.Text = "Date:";
            
            // lblDateValue
            this.lblDateValue.Font = new Font("Segoe UI", 9.5F);
            this.lblDateValue.Location = new Point(435, 15);
            this.lblDateValue.Size = new Size(210, 25);
            
            // lblCustomer
            this.lblCustomer.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.lblCustomer.Location = new Point(15, 50);
            this.lblCustomer.Size = new Size(100, 25);
            this.lblCustomer.Text = "Customer:";
            
            // lblCustomerValue
            this.lblCustomerValue.Font = new Font("Segoe UI", 9.5F);
            this.lblCustomerValue.Location = new Point(120, 50);
            this.lblCustomerValue.Size = new Size(525, 25);
            
            this.panelHeader.Controls.Add(this.lblInvoiceNo);
            this.panelHeader.Controls.Add(this.lblInvoiceNoValue);
            this.panelHeader.Controls.Add(this.lblDate);
            this.panelHeader.Controls.Add(this.lblDateValue);
            this.panelHeader.Controls.Add(this.lblCustomer);
            this.panelHeader.Controls.Add(this.lblCustomerValue);
            
            // panelItems
            this.panelItems.BackColor = Color.White;
            this.panelItems.Location = new Point(20, 180);
            this.panelItems.Size = new Size(660, 250);
            this.panelItems.Padding = new Padding(10);
            
            // dgvItems
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AllowUserToDeleteRows = false;
            this.dgvItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvItems.BackgroundColor = Color.White;
            this.dgvItems.BorderStyle = BorderStyle.None;
            this.dgvItems.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94);
            this.dgvItems.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.dgvItems.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgvItems.ColumnHeadersHeight = 35;
            this.dgvItems.Dock = DockStyle.Fill;
            this.dgvItems.EnableHeadersVisualStyles = false;
            this.dgvItems.ReadOnly = true;
            this.dgvItems.RowHeadersVisible = false;
            this.dgvItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            
            this.dgvItems.Columns.Add("MedicineName", "Medicine Name");
            this.dgvItems.Columns.Add("Quantity", "Qty");
            this.dgvItems.Columns.Add("Price", "Price");
            this.dgvItems.Columns.Add("Total", "Total");
            
            this.dgvItems.Columns["Quantity"].Width = 60;
            this.dgvItems.Columns["Price"].Width = 100;
            this.dgvItems.Columns["Total"].Width = 100;
            
            this.panelItems.Controls.Add(this.dgvItems);
            
            // panelPayment
            this.panelPayment.BackColor = Color.White;
            this.panelPayment.Location = new Point(20, 440);
            this.panelPayment.Size = new Size(660, 180);
            this.panelPayment.Padding = new Padding(15);
            
            // lblSubtotal
            this.lblSubtotal.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblSubtotal.Location = new Point(350, 15);
            this.lblSubtotal.Size = new Size(150, 25);
            this.lblSubtotal.Text = "Subtotal:";
            this.lblSubtotal.TextAlign = ContentAlignment.MiddleRight;
            
            // lblSubtotalValue
            this.lblSubtotalValue.Font = new Font("Segoe UI", 10F);
            this.lblSubtotalValue.Location = new Point(510, 15);
            this.lblSubtotalValue.Size = new Size(135, 25);
            this.lblSubtotalValue.TextAlign = ContentAlignment.MiddleRight;
            
            // lblTax
            this.lblTax.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblTax.Location = new Point(350, 45);
            this.lblTax.Size = new Size(150, 25);
            this.lblTax.Text = "Tax (0%):";
            this.lblTax.TextAlign = ContentAlignment.MiddleRight;
            
            // lblTaxValue
            this.lblTaxValue.Font = new Font("Segoe UI", 10F);
            this.lblTaxValue.Location = new Point(510, 45);
            this.lblTaxValue.Size = new Size(135, 25);
            this.lblTaxValue.Text = "$0.00";
            this.lblTaxValue.TextAlign = ContentAlignment.MiddleRight;
            
            // lblTotal
            this.lblTotal.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblTotal.ForeColor = Color.FromArgb(39, 174, 96);
            this.lblTotal.Location = new Point(350, 75);
            this.lblTotal.Size = new Size(150, 30);
            this.lblTotal.Text = "TOTAL:";
            this.lblTotal.TextAlign = ContentAlignment.MiddleRight;
            
            // lblTotalValue
            this.lblTotalValue.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblTotalValue.ForeColor = Color.FromArgb(39, 174, 96);
            this.lblTotalValue.Location = new Point(510, 75);
            this.lblTotalValue.Size = new Size(135, 30);
            this.lblTotalValue.TextAlign = ContentAlignment.MiddleRight;
            
            // btnPrint
            this.btnPrint.BackColor = Color.FromArgb(41, 128, 185);
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = FlatStyle.Flat;
            this.btnPrint.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.btnPrint.ForeColor = Color.White;
            this.btnPrint.Location = new Point(220, 120);
            this.btnPrint.Size = new Size(150, 45);
            this.btnPrint.Text = "🖨 Print Invoice";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += BtnPrint_Click;
            
            // btnClose
            this.btnClose.BackColor = Color.FromArgb(149, 165, 166);
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = FlatStyle.Flat;
            this.btnClose.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.btnClose.ForeColor = Color.White;
            this.btnClose.Location = new Point(390, 120);
            this.btnClose.Size = new Size(130, 45);
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += BtnClose_Click;
            
            this.panelPayment.Controls.Add(this.lblSubtotal);
            this.panelPayment.Controls.Add(this.lblSubtotalValue);
            this.panelPayment.Controls.Add(this.lblTax);
            this.panelPayment.Controls.Add(this.lblTaxValue);
            this.panelPayment.Controls.Add(this.lblTotal);
            this.panelPayment.Controls.Add(this.lblTotalValue);
            this.panelPayment.Controls.Add(this.btnPrint);
            this.panelPayment.Controls.Add(this.btnClose);
            
            // Add all to form
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelItems);
            this.Controls.Add(this.panelPayment);
            
            this.panelHeader.ResumeLayout(false);
            this.panelItems.ResumeLayout(false);
            this.panelPayment.ResumeLayout(false);
            this.panelPayment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.ResumeLayout(false);
        }
        
        private void LoadItems()
        {
            dgvItems.Rows.Clear();
            foreach (var item in items)
            {
                decimal itemTotal = item.Quantity * item.SellingPrice;
                dgvItems.Rows.Add(
                    item.MedicineName,
                    item.Quantity,
                    item.SellingPrice.ToString("C"),
                    itemTotal.ToString("C")
                );
            }
        }
        
        private void CalculateTotals()
        {
            lblSubtotalValue.Text = totalAmount.ToString("C");
            lblTotalValue.Text = totalAmount.ToString("C");
        }
        
        private void BtnPrint_Click(object? sender, EventArgs e)
        {
            try
            {
                PrintDialog printDialog = new PrintDialog();
                System.Drawing.Printing.PrintDocument printDocument = new System.Drawing.Printing.PrintDocument();
                printDocument.PrintPage += PrintDocument_PrintPage;
                
                printDialog.Document = printDocument;
                
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDocument.Print();
                    MessageBox.Show("Invoice printed successfully!", "Print", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error printing invoice: {ex.Message}", "Print Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void PrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // Set up fonts
            Font titleFont = new Font("Segoe UI", 20, FontStyle.Bold);
            Font headerFont = new Font("Segoe UI", 12, FontStyle.Bold);
            Font regularFont = new Font("Segoe UI", 10);
            Font boldFont = new Font("Segoe UI", 10, FontStyle.Bold);
            
            // Brushes
            Brush blackBrush = Brushes.Black;
            Brush blueBrush = new SolidBrush(Color.FromArgb(41, 128, 185));
            
            float y = 50;
            float leftMargin = 50;
            float rightMargin = e.PageBounds.Width - 50;
            
            // Title
            e.Graphics.DrawString("PHARMACY MANAGEMENT SYSTEM", titleFont, blueBrush, leftMargin, y);
            y += 40;
            e.Graphics.DrawString("SALE INVOICE", headerFont, blackBrush, leftMargin, y);
            y += 30;
            
            // Invoice details
            e.Graphics.DrawString($"Invoice No: INV-{invoiceNumber:D6}", regularFont, blackBrush, leftMargin, y);
            e.Graphics.DrawString($"Date: {lblDateValue.Text}", regularFont, blackBrush, rightMargin - 200, y);
            y += 25;
            e.Graphics.DrawString($"Customer: {lblCustomerValue.Text}", regularFont, blackBrush, leftMargin, y);
            y += 40;
            
            // Table header
            e.Graphics.DrawLine(Pens.Black, leftMargin, y, rightMargin, y);
            y += 5;
            e.Graphics.DrawString("Medicine", boldFont, blackBrush, leftMargin, y);
            e.Graphics.DrawString("Qty", boldFont, blackBrush, rightMargin - 300, y);
            e.Graphics.DrawString("Price", boldFont, blackBrush, rightMargin - 200, y);
            e.Graphics.DrawString("Total", boldFont, blackBrush, rightMargin - 100, y);
            y += 20;
            e.Graphics.DrawLine(Pens.Black, leftMargin, y, rightMargin, y);
            y += 10;
            
            // Items
            foreach (var item in items)
            {
                decimal itemTotal = item.Quantity * item.SellingPrice;
                e.Graphics.DrawString(item.MedicineName, regularFont, blackBrush, leftMargin, y);
                e.Graphics.DrawString(item.Quantity.ToString(), regularFont, blackBrush, rightMargin - 300, y);
                e.Graphics.DrawString(item.SellingPrice.ToString("C"), regularFont, blackBrush, rightMargin - 200, y);
                e.Graphics.DrawString(itemTotal.ToString("C"), regularFont, blackBrush, rightMargin - 100, y);
                y += 25;
            }
            
            y += 10;
            e.Graphics.DrawLine(Pens.Black, leftMargin, y, rightMargin, y);
            y += 15;
            
            // Total
            e.Graphics.DrawString("TOTAL:", headerFont, blackBrush, rightMargin - 300, y);
            e.Graphics.DrawString(totalAmount.ToString("C"), headerFont, blackBrush, rightMargin - 100, y);
            y += 40;
            
            // Footer
            e.Graphics.DrawString("Thank you for your business!", regularFont, blackBrush, leftMargin, y);
        }
        
        private void BtnClose_Click(object? sender, EventArgs e)
        {
            this.Close();
        }
    }
    
    public class SaleItemInfo
    {
        public int MedicineID { get; set; }
        public string MedicineName { get; set; } = "";
        public int Quantity { get; set; }
        public decimal SellingPrice { get; set; }
    }
}
