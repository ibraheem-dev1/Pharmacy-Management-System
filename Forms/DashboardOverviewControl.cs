using System;
using System.Drawing;
using System.Windows.Forms;
using PharmacyWinFormsApp.DAL;

namespace PharmacyWinFormsApp.Forms
{
    public partial class DashboardOverviewControl : UserControl
    {
        private Panel pnlTotalMedicines = null!;
        private Panel pnlLowStock = null!;
        private Panel pnlTodaySales = null!;
        private Panel pnlTotalCustomers = null!;
        private Label lblTitle = null!;

        public DashboardOverviewControl()
        {
            InitializeComponent();
            LoadDashboardData();
        }

        private void InitializeComponent()
        {
            this.lblTitle = new Label();
            this.pnlTotalMedicines = new Panel();
            this.pnlLowStock = new Panel();
            this.pnlTodaySales = new Panel();
            this.pnlTotalCustomers = new Panel();

            this.SuspendLayout();

            // Title
            this.lblTitle.AutoSize = false;
            this.lblTitle.Text = "Dashboard Overview";
            this.lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.FromArgb(52, 73, 94);
            this.lblTitle.Location = new Point(30, 20);
            this.lblTitle.Size = new Size(400, 40);

            // Card Panels
            CreateStatCard(this.pnlTotalMedicines, "Total Medicines", "0", Color.FromArgb(52, 152, 219), 30, 80);
            CreateStatCard(this.pnlLowStock, "Low Stock Alerts", "0", Color.FromArgb(231, 76, 60), 310, 80);
            CreateStatCard(this.pnlTodaySales, "Today's Sales", "$0.00", Color.FromArgb(46, 204, 113), 590, 80);
            CreateStatCard(this.pnlTotalCustomers, "Total Customers", "0", Color.FromArgb(155, 89, 182), 870, 80);

            // DashboardOverviewControl
            this.BackColor = Color.FromArgb(236, 240, 241);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pnlTotalMedicines);
            this.Controls.Add(this.pnlLowStock);
            this.Controls.Add(this.pnlTodaySales);
            this.Controls.Add(this.pnlTotalCustomers);
            this.Name = "DashboardOverviewControl";
            this.Size = new Size(1200, 700);

            this.ResumeLayout(false);
        }

        private void CreateStatCard(Panel panel, string title, string value, Color bgColor, int x, int y)
        {
            panel.BackColor = bgColor;
            panel.Location = new Point(x, y);
            panel.Size = new Size(250, 150);
            panel.Cursor = Cursors.Hand;

            // Add shadow effect
            panel.Paint += (s, e) =>
            {
                ControlPaint.DrawBorder(e.Graphics, panel.ClientRectangle,
                    Color.FromArgb(30, 0, 0, 0), 0, ButtonBorderStyle.Solid,
                    Color.FromArgb(30, 0, 0, 0), 0, ButtonBorderStyle.Solid,
                    Color.FromArgb(30, 0, 0, 0), 3, ButtonBorderStyle.Solid,
                    Color.FromArgb(30, 0, 0, 0), 3, ButtonBorderStyle.Solid);
            };

            Label lblTitle = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(15, 15),
                AutoSize = true
            };

            Label lblValue = new Label
            {
                Text = value,
                Font = new Font("Segoe UI", 28F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(15, 60),
                AutoSize = false,
                Size = new Size(220, 60),
                TextAlign = ContentAlignment.MiddleLeft,
                Name = "lblValue"
            };

            panel.Controls.Add(lblTitle);
            panel.Controls.Add(lblValue);
        }

        private void LoadDashboardData()
        {
            try
            {
                MedicineDAL medicineDAL = new MedicineDAL();
                CustomerDAL customerDAL = new CustomerDAL();
                ReportsDAL reportsDAL = new ReportsDAL();
                SaleDAL saleDAL = new SaleDAL();

                // Total Medicines
                var medicines = medicineDAL.GetAllMedicines();
                UpdateCardValue(pnlTotalMedicines, medicines.Count.ToString());

                // Low Stock Alerts
                var lowStock = reportsDAL.GetLowStockMedicines();
                UpdateCardValue(pnlLowStock, lowStock.Rows.Count.ToString());

                // Today's Sales
                var todaySales = saleDAL.GetSalesByDate(DateTime.Today);
                decimal totalSales = 0;
                foreach (var sale in todaySales)
                {
                    totalSales += sale.TotalAmount;
                }
                UpdateCardValue(pnlTodaySales, totalSales.ToString("C"));

                // Total Customers
                var customers = customerDAL.GetAllCustomers();
                UpdateCardValue(pnlTotalCustomers, customers.Count.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading dashboard data: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateCardValue(Panel panel, string value)
        {
            foreach (Control control in panel.Controls)
            {
                if (control is Label lbl && lbl.Name == "lblValue")
                {
                    lbl.Text = value;
                    break;
                }
            }
        }
    }
}
