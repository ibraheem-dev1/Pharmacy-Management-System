using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using PharmacyWinFormsApp.DAL;
using PharmacyWinFormsApp.Models;

namespace PharmacyWinFormsApp.Forms.Reports
{
    public partial class ReportsControl : UserControl
    {
        private readonly ReportsDAL reportsDAL;
        private readonly ExpenseDAL expenseDAL;

        private Label lblTitle = null!;
        private DateTimePicker dtpFrom = null!;
        private DateTimePicker dtpTo = null!;
        private Button btnGenerate = null!;
        
        // Summary panels
        private Panel panelSales = null!;
        private Panel panelPurchases = null!;
        private Panel panelSalaries = null!;
        private Panel panelExpenses = null!;
        private Panel panelNetProfit = null!;
        
        // Detail view
        private Panel panelDetails = null!;
        private Label lblDetailsTitle = null!;
        private DataGridView dgvDetails = null!;
        private Button btnCloseDetails = null!;

        public ReportsControl()
        {
            reportsDAL = new ReportsDAL();
            expenseDAL = new ExpenseDAL();
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.lblTitle = new Label();
            this.dtpFrom = new DateTimePicker();
            this.dtpTo = new DateTimePicker();
            this.btnGenerate = new Button();
            this.panelSales = new Panel();
            this.panelPurchases = new Panel();
            this.panelSalaries = new Panel();
            this.panelExpenses = new Panel();
            this.panelNetProfit = new Panel();
            this.panelDetails = new Panel();
            this.lblDetailsTitle = new Label();
            this.dgvDetails = new DataGridView();
            this.btnCloseDetails = new Button();
            
            this.panelDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            this.SuspendLayout();
            
            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.lblTitle.Location = new Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(250, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "📊 Financial Reports";
            
            // Date range controls
            var lblFrom = new Label
            {
                Text = "From:",
                Location = new Point(20, 70),
                Size = new Size(50, 23),
                Font = new Font("Segoe UI", 10F),
                TextAlign = ContentAlignment.MiddleLeft
            };
            
            this.dtpFrom = new DateTimePicker
            {
                Format = DateTimePickerFormat.Short,
                Location = new Point(75, 67),
                Size = new Size(150, 27),
                Font = new Font("Segoe UI", 10F)
            };
            
            var lblTo = new Label
            {
                Text = "To:",
                Location = new Point(245, 70),
                Size = new Size(30, 23),
                Font = new Font("Segoe UI", 10F),
                TextAlign = ContentAlignment.MiddleLeft
            };
            
            this.dtpTo = new DateTimePicker
            {
                Format = DateTimePickerFormat.Short,
                Location = new Point(280, 67),
                Size = new Size(150, 27),
                Font = new Font("Segoe UI", 10F)
            };
            
            this.btnGenerate = new Button
            {
                Text = "🔄 Generate Report",
                Location = new Point(450, 65),
                Size = new Size(150, 30),
                BackColor = Color.FromArgb(0, 122, 204),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            this.btnGenerate.FlatAppearance.BorderSize = 0;
            this.btnGenerate.Click += new EventHandler(this.btnGenerate_Click);
            
            // Summary panels (2 rows x 3 columns layout)
            this.panelSales = CreateSummaryPanel("💰 Total Sales", "$0.00", Color.FromArgb(40, 167, 69), new Point(20, 120));
            this.panelPurchases = CreateSummaryPanel("🛒 Total Purchases", "$0.00", Color.FromArgb(220, 53, 69), new Point(310, 120));
            this.panelExpenses = CreateSummaryPanel("💸 Total Expenses", "$0.00", Color.FromArgb(255, 193, 7), new Point(600, 120));
            this.panelSalaries = CreateSummaryPanel("👥 Total Salaries", "$0.00", Color.FromArgb(23, 162, 184), new Point(20, 280));
            this.panelNetProfit = CreateSummaryPanel("📈 Net Profit", "$0.00", Color.FromArgb(108, 117, 125), new Point(310, 280));
            this.panelNetProfit.Size = new Size(570, 140);
            
            // Details panel (initially hidden)
            this.panelDetails.BackColor = Color.White;
            this.panelDetails.BorderStyle = BorderStyle.FixedSingle;
            this.panelDetails.Location = new Point(20, 120);
            this.panelDetails.Size = new Size(860, 460);
            this.panelDetails.Visible = false;
            
            this.lblDetailsTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblDetailsTitle.Location = new Point(15, 15);
            this.lblDetailsTitle.Size = new Size(600, 30);
            this.lblDetailsTitle.Text = "Details";
            
            this.btnCloseDetails.Text = "✖ Close";
            this.btnCloseDetails.Location = new Point(750, 15);
            this.btnCloseDetails.Size = new Size(90, 30);
            this.btnCloseDetails.BackColor = Color.FromArgb(220, 53, 69);
            this.btnCloseDetails.ForeColor = Color.White;
            this.btnCloseDetails.FlatStyle = FlatStyle.Flat;
            this.btnCloseDetails.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnCloseDetails.Cursor = Cursors.Hand;
            this.btnCloseDetails.FlatAppearance.BorderSize = 0;
            this.btnCloseDetails.Click += new EventHandler(this.btnCloseDetails_Click);
            
            this.dgvDetails.AllowUserToAddRows = false;
            this.dgvDetails.AllowUserToDeleteRows = false;
            this.dgvDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetails.BackgroundColor = Color.White;
            this.dgvDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetails.Location = new Point(15, 60);
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.ReadOnly = true;
            this.dgvDetails.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetails.Size = new Size(825, 380);
            this.dgvDetails.TabIndex = 0;
            this.dgvDetails.CellClick += new DataGridViewCellEventHandler(this.dgvDetails_CellClick);
            
            this.panelDetails.Controls.Add(this.lblDetailsTitle);
            this.panelDetails.Controls.Add(this.btnCloseDetails);
            this.panelDetails.Controls.Add(this.dgvDetails);
            
            // ReportsControl
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(245, 245, 245);
            this.Controls.Add(this.panelDetails);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(lblFrom);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(lblTo);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.panelSales);
            this.Controls.Add(this.panelPurchases);
            this.Controls.Add(this.panelExpenses);
            this.Controls.Add(this.panelSalaries);
            this.Controls.Add(this.panelNetProfit);
            this.Name = "ReportsControl";
            this.Size = new Size(900, 600);
            this.Load += new EventHandler(this.ReportsControl_Load);
            
            this.panelDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private Panel CreateSummaryPanel(string title, string value, Color color, Point location)
        {
            var panel = new Panel
            {
                Location = location,
                Size = new Size(280, 140),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Cursor = Cursors.Hand
            };
            
            var lblTitle = new Label
            {
                Text = title,
                Location = new Point(15, 15),
                Size = new Size(250, 30),
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 58, 64)
            };
            
            var lblValue = new Label
            {
                Text = value,
                Name = "lblValue",
                Location = new Point(15, 55),
                Size = new Size(250, 50),
                Font = new Font("Segoe UI", 22F, FontStyle.Bold),
                ForeColor = color,
                TextAlign = ContentAlignment.MiddleLeft
            };
            
            var lblClick = new Label
            {
                Text = "Click to view details →",
                Location = new Point(15, 110),
                Size = new Size(250, 20),
                Font = new Font("Segoe UI", 8F, FontStyle.Italic),
                ForeColor = Color.Gray
            };
            
            panel.Controls.Add(lblTitle);
            panel.Controls.Add(lblValue);
            panel.Controls.Add(lblClick);
            
            panel.Click += new EventHandler((s, e) => OnSummaryPanelClick(title));
            lblTitle.Click += new EventHandler((s, e) => OnSummaryPanelClick(title));
            lblValue.Click += new EventHandler((s, e) => OnSummaryPanelClick(title));
            lblClick.Click += new EventHandler((s, e) => OnSummaryPanelClick(title));
            
            // Hover effects
            panel.MouseEnter += (s, e) => { panel.BackColor = Color.FromArgb(248, 249, 250); };
            panel.MouseLeave += (s, e) => { panel.BackColor = Color.White; };
            
            return panel;
        }

        private void ReportsControl_Load(object? sender, EventArgs e)
        {
            // Set date range to start of current year to today for better visibility of all records
            dtpFrom.Value = new DateTime(DateTime.Today.Year, 1, 1);
            dtpTo.Value = DateTime.Today;
            LoadFinancialSummary();
        }

        private void btnGenerate_Click(object? sender, EventArgs e)
        {
            // Validate date range
            if (dtpFrom.Value.Date > dtpTo.Value.Date)
            {
                MessageBox.Show("'From Date' must be less than or equal to 'To Date'.", 
                    "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            LoadFinancialSummary();
        }

        private void LoadFinancialSummary()
        {
            try
            {
                DataRow summary = reportsDAL.GetFinancialSummary(dtpFrom.Value, dtpTo.Value);
                
                if (summary != null)
                {
                    UpdatePanelValue(panelSales, summary["TotalSales"]);
                    UpdatePanelValue(panelPurchases, summary["TotalPurchases"]);
                    UpdatePanelValue(panelSalaries, summary["TotalSalaries"]);
                    UpdatePanelValue(panelExpenses, summary["TotalExpenses"]);
                    UpdatePanelValue(panelNetProfit, summary["NetProfit"]);
                    
                    // Update net profit color based on positive/negative
                    decimal netProfit = Convert.ToDecimal(summary["NetProfit"]);
                    var lblNetProfit = panelNetProfit.Controls.Find("lblValue", false)[0] as Label;
                    if (lblNetProfit != null)
                    {
                        lblNetProfit.ForeColor = netProfit >= 0 ? Color.FromArgb(40, 167, 69) : Color.FromArgb(220, 53, 69);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading financial summary: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdatePanelValue(Panel panel, object value)
        {
            var lblValue = panel.Controls.Find("lblValue", false)[0] as Label;
            if (lblValue != null)
            {
                decimal amount = value != DBNull.Value ? Convert.ToDecimal(value) : 0;
                lblValue.Text = amount.ToString("C");
            }
        }

        private void OnSummaryPanelClick(string panelTitle)
        {
            try
            {
                DataTable data = null!;
                string detailsTitle = "";
                
                if (panelTitle.Contains("Sales"))
                {
                    data = reportsDAL.GetSalesReportByDateRange(dtpFrom.Value, dtpTo.Value);
                    detailsTitle = "💰 Sales Details";
                }
                else if (panelTitle.Contains("Purchases"))
                {
                    data = reportsDAL.GetPurchasesReportByDateRange(dtpFrom.Value, dtpTo.Value);
                    detailsTitle = "🛒 Purchase Details";
                }
                else if (panelTitle.Contains("Salaries"))
                {
                    data = reportsDAL.GetSalariesReportByDateRange(dtpFrom.Value, dtpTo.Value);
                    detailsTitle = "👥 Salary Details";
                }
                else if (panelTitle.Contains("Expenses"))
                {
                    var expenses = expenseDAL.GetExpensesByDateRange(dtpFrom.Value, dtpTo.Value);
                    data = ConvertExpensesToDataTable(expenses);
                    detailsTitle = "💸 Expense Details";
                }
                else if (panelTitle.Contains("Net Profit"))
                {
                    MessageBox.Show("Net Profit is calculated as:\nSales - Purchases - Salaries - Expenses\n\nClick on individual panels to see detailed transactions.", 
                        "Net Profit Calculation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                
                if (data != null)
                {
                    ShowDetails(detailsTitle, data);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowDetails(string title, DataTable data)
        {
            lblDetailsTitle.Text = title;
            dgvDetails.DataSource = data;
            
            // Hide ID columns
            if (dgvDetails.Columns.Contains("SaleID"))
                dgvDetails.Columns["SaleID"]!.Visible = false;
            if (dgvDetails.Columns.Contains("PurchaseID"))
                dgvDetails.Columns["PurchaseID"]!.Visible = false;
            if (dgvDetails.Columns.Contains("SalaryID"))
                dgvDetails.Columns["SalaryID"]!.Visible = false;
            if (dgvDetails.Columns.Contains("ExpenseID"))
                dgvDetails.Columns["ExpenseID"]!.Visible = false;
            if (dgvDetails.Columns.Contains("RecordedBy"))
                dgvDetails.Columns["RecordedBy"]!.Visible = false;
            
            panelDetails.Visible = true;
            panelDetails.BringToFront();
        }

        private void btnCloseDetails_Click(object? sender, EventArgs e)
        {
            panelDetails.Visible = false;
        }

        private void dgvDetails_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                DataGridViewRow row = dgvDetails.Rows[e.RowIndex];
                string title = lblDetailsTitle.Text;

                if (title.Contains("Sales"))
                {
                    ShowSaleDetails(row);
                }
                else if (title.Contains("Purchase"))
                {
                    ShowPurchaseDetails(row);
                }
                else if (title.Contains("Salary"))
                {
                    ShowSalaryDetails(row);
                }
                else if (title.Contains("Expense"))
                {
                    ShowExpenseDetails(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error showing details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowSaleDetails(DataGridViewRow row)
        {
            var saleID = row.Cells["SaleID"].Value;
            var saleDate = row.Cells["SaleDate"].Value;
            var userName = row.Cells["UserName"].Value;
            var customerName = row.Cells["CustomerName"].Value;
            var totalAmount = row.Cells["TotalAmount"].Value;

            string details = $"🛍️ Sale Details\n\n" +
                           $"📋 Sale ID: {saleID}\n" +
                           $"📅 Date: {Convert.ToDateTime(saleDate):yyyy-MM-dd}\n" +
                           $"👤 Sold By: {userName}\n" +
                           $"🧑 Customer: {customerName}\n" +
                           $"💰 Total Amount: {Convert.ToDecimal(totalAmount):C}";

            MessageBox.Show(details, "Sale Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ShowPurchaseDetails(DataGridViewRow row)
        {
            var purchaseID = row.Cells["PurchaseID"].Value;
            var purchaseDate = row.Cells["PurchaseDate"].Value;
            var supplierName = row.Cells["SupplierName"].Value;
            var userName = row.Cells["UserName"].Value;
            var totalAmount = row.Cells["TotalAmount"].Value;

            string details = $"🛒 Purchase Details\n\n" +
                           $"📋 Purchase ID: {purchaseID}\n" +
                           $"📅 Date: {Convert.ToDateTime(purchaseDate):yyyy-MM-dd}\n" +
                           $"🏢 Supplier: {supplierName}\n" +
                           $"👤 Purchased By: {userName}\n" +
                           $"💰 Total Amount: {Convert.ToDecimal(totalAmount):C}";

            MessageBox.Show(details, "Purchase Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ShowSalaryDetails(DataGridViewRow row)
        {
            var salaryID = row.Cells["SalaryID"].Value;
            var userName = row.Cells["UserName"].Value;
            var month = row.Cells["Month"].Value;
            var year = row.Cells["Year"].Value;
            var basicSalary = row.Cells["BasicSalary"].Value;
            var bonus = row.Cells["Bonus"].Value;
            var deductions = row.Cells["Deductions"].Value;
            var netSalary = row.Cells["NetSalary"].Value;
            var recordedDate = row.Cells["RecordedDate"].Value;

            string monthName = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), 1).ToString("MMMM");

            string details = $"👥 Salary Details\n\n" +
                           $"📋 Salary ID: {salaryID}\n" +
                           $"👤 Employee: {userName}\n" +
                           $"📅 Period: {monthName} {year}\n" +
                           $"💵 Basic Salary: {Convert.ToDecimal(basicSalary):C}\n" +
                           $"🎁 Bonus: {Convert.ToDecimal(bonus):C}\n" +
                           $"➖ Deductions: {Convert.ToDecimal(deductions):C}\n" +
                           $"💰 Net Salary: {Convert.ToDecimal(netSalary):C}\n" +
                           $"📝 Recorded: {Convert.ToDateTime(recordedDate):yyyy-MM-dd}";

            MessageBox.Show(details, "Salary Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ShowExpenseDetails(DataGridViewRow row)
        {
            var expenseID = row.Cells["ExpenseID"].Value;
            var description = row.Cells["Description"].Value;
            var amount = row.Cells["Amount"].Value;
            var category = row.Cells["Category"].Value;
            var expenseDate = row.Cells["ExpenseDate"].Value;
            var recordedByName = row.Cells["RecordedByName"].Value;

            string details = $"💸 Expense Details\n\n" +
                           $"📋 Expense ID: {expenseID}\n" +
                           $"📝 Description: {description}\n" +
                           $"📦 Category: {category}\n" +
                           $"📅 Date: {Convert.ToDateTime(expenseDate):yyyy-MM-dd}\n" +
                           $"💰 Amount: {Convert.ToDecimal(amount):C}\n" +
                           $"👤 Recorded By: {recordedByName}";

            MessageBox.Show(details, "Expense Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private DataTable ConvertExpensesToDataTable(List<Expense> expenses)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ExpenseID", typeof(int));
            dt.Columns.Add("Description", typeof(string));
            dt.Columns.Add("Amount", typeof(decimal));
            dt.Columns.Add("Category", typeof(string));
            dt.Columns.Add("ExpenseDate", typeof(DateTime));
            dt.Columns.Add("RecordedByName", typeof(string));

            foreach (var expense in expenses)
            {
                dt.Rows.Add(
                    expense.ExpenseID,
                    expense.Description,
                    expense.Amount,
                    expense.Category,
                    expense.ExpenseDate,
                    expense.RecordedByName
                );
            }

            return dt;
        }
    }
}
