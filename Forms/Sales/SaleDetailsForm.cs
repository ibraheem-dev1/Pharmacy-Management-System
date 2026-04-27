using System;
using System.Drawing;
using System.Windows.Forms;
using PharmacyWinFormsApp.DAL;
using PharmacyWinFormsApp.Models;

namespace PharmacyWinFormsApp.Forms.Sales
{
    public partial class SaleDetailsForm : Form
    {
        private int saleID;
        private Sale sale;
        private readonly SaleDetailDAL saleDetailDAL;

        private Label lblTitle = null!;
        private GroupBox grpSaleInfo = null!;
        private Label lblSaleIDLabel = null!;
        private Label lblSaleID = null!;
        private Label lblDateLabel = null!;
        private Label lblDate = null!;
        private Label lblCustomerLabel = null!;
        private Label lblCustomer = null!;
        private Label lblUserLabel = null!;
        private Label lblUser = null!;
        private Label lblTotalLabel = null!;
        private Label lblTotal = null!;
        private DataGridView dgvSaleDetails = null!;
        private Button btnPrint = null!;
        private Button btnClose = null!;

        public SaleDetailsForm(int saleID, Sale sale)
        {
            this.saleID = saleID;
            this.sale = sale;
            saleDetailDAL = new SaleDetailDAL();
            InitializeComponent();
            LoadSaleDetails();
        }

        private void InitializeComponent()
        {
            this.lblTitle = new Label();
            this.grpSaleInfo = new GroupBox();
            this.lblSaleIDLabel = new Label();
            this.lblSaleID = new Label();
            this.lblDateLabel = new Label();
            this.lblDate = new Label();
            this.lblCustomerLabel = new Label();
            this.lblCustomer = new Label();
            this.lblUserLabel = new Label();
            this.lblUser = new Label();
            this.lblTotalLabel = new Label();
            this.lblTotal = new Label();
            this.dgvSaleDetails = new DataGridView();
            this.btnPrint = new Button();
            this.btnClose = new Button();

            this.grpSaleInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSaleDetails)).BeginInit();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = false;
            this.lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.FromArgb(41, 128, 185);
            this.lblTitle.Location = new Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(300, 35);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Sale Details";

            // grpSaleInfo
            this.grpSaleInfo.BackColor = Color.FromArgb(236, 240, 241);
            this.grpSaleInfo.Controls.Add(this.lblSaleIDLabel);
            this.grpSaleInfo.Controls.Add(this.lblSaleID);
            this.grpSaleInfo.Controls.Add(this.lblDateLabel);
            this.grpSaleInfo.Controls.Add(this.lblDate);
            this.grpSaleInfo.Controls.Add(this.lblCustomerLabel);
            this.grpSaleInfo.Controls.Add(this.lblCustomer);
            this.grpSaleInfo.Controls.Add(this.lblUserLabel);
            this.grpSaleInfo.Controls.Add(this.lblUser);
            this.grpSaleInfo.Controls.Add(this.lblTotalLabel);
            this.grpSaleInfo.Controls.Add(this.lblTotal);
            this.grpSaleInfo.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.grpSaleInfo.Location = new Point(20, 60);
            this.grpSaleInfo.Name = "grpSaleInfo";
            this.grpSaleInfo.Size = new Size(760, 120);
            this.grpSaleInfo.TabIndex = 1;
            this.grpSaleInfo.TabStop = false;
            this.grpSaleInfo.Text = "Sale Information";

            // lblSaleIDLabel
            this.lblSaleIDLabel.AutoSize = true;
            this.lblSaleIDLabel.Location = new Point(20, 30);
            this.lblSaleIDLabel.Name = "lblSaleIDLabel";
            this.lblSaleIDLabel.Size = new Size(55, 17);
            this.lblSaleIDLabel.Text = "Sale ID:";

            // lblSaleID
            this.lblSaleID.AutoSize = true;
            this.lblSaleID.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            this.lblSaleID.Location = new Point(120, 30);
            this.lblSaleID.Name = "lblSaleID";
            this.lblSaleID.Size = new Size(50, 17);
            this.lblSaleID.Text = "0";

            // lblDateLabel
            this.lblDateLabel.AutoSize = true;
            this.lblDateLabel.Location = new Point(20, 60);
            this.lblDateLabel.Name = "lblDateLabel";
            this.lblDateLabel.Size = new Size(70, 17);
            this.lblDateLabel.Text = "Sale Date:";

            // lblDate
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            this.lblDate.Location = new Point(120, 60);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new Size(50, 17);
            this.lblDate.Text = "-";

            // lblCustomerLabel
            this.lblCustomerLabel.AutoSize = true;
            this.lblCustomerLabel.Location = new Point(20, 90);
            this.lblCustomerLabel.Name = "lblCustomerLabel";
            this.lblCustomerLabel.Size = new Size(70, 17);
            this.lblCustomerLabel.Text = "Customer:";

            // lblCustomer
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            this.lblCustomer.Location = new Point(120, 90);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new Size(50, 17);
            this.lblCustomer.Text = "-";

            // lblUserLabel
            this.lblUserLabel.AutoSize = true;
            this.lblUserLabel.Location = new Point(400, 30);
            this.lblUserLabel.Name = "lblUserLabel";
            this.lblUserLabel.Size = new Size(60, 17);
            this.lblUserLabel.Text = "Sold By:";

            // lblUser
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            this.lblUser.Location = new Point(480, 30);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new Size(50, 17);
            this.lblUser.Text = "-";

            // lblTotalLabel
            this.lblTotalLabel.AutoSize = true;
            this.lblTotalLabel.Location = new Point(400, 60);
            this.lblTotalLabel.Name = "lblTotalLabel";
            this.lblTotalLabel.Size = new Size(95, 17);
            this.lblTotalLabel.Text = "Total Amount:";

            // lblTotal
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblTotal.ForeColor = Color.FromArgb(39, 174, 96);
            this.lblTotal.Location = new Point(480, 58);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new Size(50, 21);
            this.lblTotal.Text = "$0.00";

            // dgvSaleDetails
            this.dgvSaleDetails.AllowUserToAddRows = false;
            this.dgvSaleDetails.AllowUserToDeleteRows = false;
            this.dgvSaleDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSaleDetails.BackgroundColor = Color.White;
            this.dgvSaleDetails.BorderStyle = BorderStyle.None;
            this.dgvSaleDetails.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94);
            this.dgvSaleDetails.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.dgvSaleDetails.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgvSaleDetails.ColumnHeadersDefaultCellStyle.Padding = new Padding(5);
            this.dgvSaleDetails.ColumnHeadersHeight = 40;
            this.dgvSaleDetails.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            this.dgvSaleDetails.DefaultCellStyle.SelectionBackColor = Color.FromArgb(41, 128, 185);
            this.dgvSaleDetails.DefaultCellStyle.SelectionForeColor = Color.White;
            this.dgvSaleDetails.EnableHeadersVisualStyles = false;
            this.dgvSaleDetails.Location = new Point(20, 200);
            this.dgvSaleDetails.Name = "dgvSaleDetails";
            this.dgvSaleDetails.ReadOnly = true;
            this.dgvSaleDetails.RowHeadersVisible = false;
            this.dgvSaleDetails.RowTemplate.Height = 32;
            this.dgvSaleDetails.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvSaleDetails.Size = new Size(760, 320);
            this.dgvSaleDetails.TabIndex = 2;

            // btnPrint
            this.btnPrint.BackColor = Color.FromArgb(41, 128, 185);
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = FlatStyle.Flat;
            this.btnPrint.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.btnPrint.ForeColor = Color.White;
            this.btnPrint.Location = new Point(560, 530);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new Size(110, 35);
            this.btnPrint.TabIndex = 3;
            this.btnPrint.Text = "🖨 Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new EventHandler(this.btnPrint_Click);

            // btnClose
            this.btnClose.BackColor = Color.FromArgb(149, 165, 166);
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = FlatStyle.Flat;
            this.btnClose.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.btnClose.ForeColor = Color.White;
            this.btnClose.Location = new Point(680, 530);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new Size(100, 35);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new EventHandler(this.btnClose_Click);

            // SaleDetailsForm
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            this.ClientSize = new Size(800, 585);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvSaleDetails);
            this.Controls.Add(this.grpSaleInfo);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SaleDetailsForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Sale Details";

            this.grpSaleInfo.ResumeLayout(false);
            this.grpSaleInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSaleDetails)).EndInit();
            this.ResumeLayout(false);
        }

        private void LoadSaleDetails()
        {
            // Set sale information
            lblSaleID.Text = $"INV-{saleID:D6}";
            lblDate.Text = sale.SaleDate.ToString("MMM dd, yyyy hh:mm tt");
            lblCustomer.Text = sale.CustomerName;
            lblUser.Text = sale.UserName;
            lblTotal.Text = sale.TotalAmount.ToString("C2");

            // Load sale details
            var details = saleDetailDAL.GetSaleDetails(saleID);

            // Setup columns
            dgvSaleDetails.Columns.Clear();
            dgvSaleDetails.Columns.Add("MedicineName", "Medicine Name");
            dgvSaleDetails.Columns.Add("BatchNumber", "Batch #");
            dgvSaleDetails.Columns.Add("Quantity", "Quantity");
            dgvSaleDetails.Columns.Add("UnitPrice", "Unit Price");
            dgvSaleDetails.Columns.Add("Total", "Total");
            dgvSaleDetails.Columns.Add("ExpiryDate", "Expiry Date");

            // Set column widths
            dgvSaleDetails.Columns["MedicineName"].Width = 200;
            dgvSaleDetails.Columns["BatchNumber"].Width = 100;
            dgvSaleDetails.Columns["Quantity"].Width = 80;
            dgvSaleDetails.Columns["UnitPrice"].Width = 100;
            dgvSaleDetails.Columns["Total"].Width = 100;
            dgvSaleDetails.Columns["ExpiryDate"].Width = 120;

            // Add rows
            foreach (var detail in details)
            {
                decimal total = detail.QuantitySold * detail.SellingPrice;
                dgvSaleDetails.Rows.Add(
                    detail.MedicineName,
                    detail.BatchNumber,
                    detail.QuantitySold,
                    detail.SellingPrice.ToString("C2"),
                    total.ToString("C2"),
                    detail.ExpiryDate.ToString("MM/dd/yyyy")
                );
            }
        }

        private void btnPrint_Click(object? sender, EventArgs e)
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
            e.Graphics.DrawString($"Invoice No: INV-{saleID:D6}", regularFont, blackBrush, leftMargin, y);
            e.Graphics.DrawString($"Date: {sale.SaleDate:MMM dd, yyyy hh:mm tt}", regularFont, blackBrush, rightMargin - 200, y);
            y += 25;
            e.Graphics.DrawString($"Customer: {sale.CustomerName}", regularFont, blackBrush, leftMargin, y);
            e.Graphics.DrawString($"Sold By: {sale.UserName}", regularFont, blackBrush, rightMargin - 200, y);
            y += 40;
            
            // Table header
            e.Graphics.DrawLine(Pens.Black, leftMargin, y, rightMargin, y);
            y += 5;
            e.Graphics.DrawString("Medicine", boldFont, blackBrush, leftMargin, y);
            e.Graphics.DrawString("Batch", boldFont, blackBrush, leftMargin + 200, y);
            e.Graphics.DrawString("Qty", boldFont, blackBrush, rightMargin - 300, y);
            e.Graphics.DrawString("Price", boldFont, blackBrush, rightMargin - 200, y);
            e.Graphics.DrawString("Total", boldFont, blackBrush, rightMargin - 100, y);
            y += 20;
            e.Graphics.DrawLine(Pens.Black, leftMargin, y, rightMargin, y);
            y += 10;
            
            // Items
            var details = saleDetailDAL.GetSaleDetails(saleID);
            foreach (var detail in details)
            {
                decimal itemTotal = detail.QuantitySold * detail.SellingPrice;
                e.Graphics.DrawString(detail.MedicineName, regularFont, blackBrush, leftMargin, y);
                e.Graphics.DrawString(detail.BatchNumber, regularFont, blackBrush, leftMargin + 200, y);
                e.Graphics.DrawString(detail.QuantitySold.ToString(), regularFont, blackBrush, rightMargin - 300, y);
                e.Graphics.DrawString(detail.SellingPrice.ToString("C"), regularFont, blackBrush, rightMargin - 200, y);
                e.Graphics.DrawString(itemTotal.ToString("C"), regularFont, blackBrush, rightMargin - 100, y);
                y += 25;
            }
            
            y += 10;
            e.Graphics.DrawLine(Pens.Black, leftMargin, y, rightMargin, y);
            y += 15;
            
            // Total
            e.Graphics.DrawString("TOTAL:", headerFont, blackBrush, rightMargin - 300, y);
            e.Graphics.DrawString(sale.TotalAmount.ToString("C"), headerFont, blackBrush, rightMargin - 100, y);
            y += 40;
            
            // Footer
            e.Graphics.DrawString("Thank you for your business!", regularFont, blackBrush, leftMargin, y);
        }

        private void btnClose_Click(object? sender, EventArgs e)
        {
            this.Close();
        }
    }
}
