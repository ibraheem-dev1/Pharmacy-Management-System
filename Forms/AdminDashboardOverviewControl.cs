using System;
using System.Drawing;
using System.Windows.Forms;
using PharmacyWinFormsApp.DAL;

namespace PharmacyWinFormsApp.Forms
{
    public partial class AdminDashboardOverviewControl : UserControl
    {
        private Label lblTitle = null!;
        private TableLayoutPanel layout = null!;
        private FlowLayoutPanel cardsPanel = null!;

        public AdminDashboardOverviewControl()
        {
            InitializeComponent();
            LoadDashboardData();
        }

        private void InitializeComponent()
        {
            this.BackColor = Color.White;
            this.Dock = DockStyle.Fill;

            layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 2,
                Padding = new Padding(20)
            };
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 70));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

            lblTitle = new Label
            {
                Text = "📊 Admin Dashboard",
                Font = new Font("Segoe UI", 24F, FontStyle.Bold),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                ForeColor = Color.FromArgb(52, 73, 94)
            };

            cardsPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = true,
                AutoScroll = true
            };

            layout.Controls.Add(lblTitle, 0, 0);
            layout.Controls.Add(cardsPanel, 0, 1);

            this.Controls.Add(layout);
        }

        private void LoadDashboardData()
        {
            try
            {
                MedicineDAL medicineDAL = new MedicineDAL();
                CustomerDAL customerDAL = new CustomerDAL();
                ReportsDAL reportsDAL = new ReportsDAL();
                SaleDAL saleDAL = new SaleDAL();
                UserDAL userDAL = new UserDAL();

                int totalMedicines = medicineDAL.GetAllMedicines().Count;
                int totalCustomers = customerDAL.GetAllCustomers().Count;
                int totalUsers = userDAL.GetAllUsers().Count;
                int lowStock = reportsDAL.GetLowStockMedicines().Rows.Count;

                decimal todaySales = 0;
                foreach (var sale in saleDAL.GetSalesByDate(DateTime.Today))
                    todaySales += sale.TotalAmount;

                decimal monthlySales = 0;
                foreach (var sale in saleDAL.GetSalesByMonth(DateTime.Today.Month, DateTime.Today.Year))
                    monthlySales += sale.TotalAmount;

                cardsPanel.Controls.Add(CreateCard("💊 Total Medicines", totalMedicines.ToString(), Color.FromArgb(52, 152, 219)));
                cardsPanel.Controls.Add(CreateCard("⚠️ Low Stock Alerts", lowStock.ToString(), Color.FromArgb(231, 76, 60)));
                cardsPanel.Controls.Add(CreateCard("👥 Total Customers", totalCustomers.ToString(), Color.FromArgb(155, 89, 182)));
                cardsPanel.Controls.Add(CreateCard("👤 System Users", totalUsers.ToString(), Color.FromArgb(127, 140, 141)));
                cardsPanel.Controls.Add(CreateCard("💰 Today's Sales", todaySales.ToString("C"), Color.FromArgb(46, 204, 113)));
                cardsPanel.Controls.Add(CreateCard("📈 Monthly Revenue", monthlySales.ToString("C"), Color.FromArgb(243, 156, 18)));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading dashboard data: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Panel CreateCard(string title, string value, Color color)
        {
            Panel panel = new Panel
            {
                Size = new Size(260, 140),
                BackColor = color,
                Margin = new Padding(10),
                Cursor = Cursors.Hand
            };

            // Add hover effect
            panel.MouseEnter += (s, e) => { panel.BackColor = ControlPaint.Light(color, 0.1f); };
            panel.MouseLeave += (s, e) => { panel.BackColor = color; };

            Label lblTitle = new Label
            {
                Text = title,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                Location = new Point(15, 15),
                AutoSize = true
            };

            Label lblValue = new Label
            {
                Text = value,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 26F, FontStyle.Bold),
                Location = new Point(15, 60),
                Size = new Size(230, 60),
                TextAlign = ContentAlignment.MiddleLeft
            };

            panel.Controls.Add(lblTitle);
            panel.Controls.Add(lblValue);

            return panel;
        }
    }
}
