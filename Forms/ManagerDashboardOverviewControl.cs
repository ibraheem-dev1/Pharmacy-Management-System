using System;
using System.Drawing;
using System.Windows.Forms;
using PharmacyWinFormsApp.DAL;

namespace PharmacyWinFormsApp.Forms
{
    public partial class ManagerDashboardOverviewControl : UserControl
    {
        private Label lblTitle = null!;
        private FlowLayoutPanel cardsPanel = null!;

        public ManagerDashboardOverviewControl()
        {
            InitializeComponent();
            LoadDashboardData();
        }

        private void InitializeComponent()
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.White;

            lblTitle = new Label
            {
                Text = "📊 Manager Dashboard",
                Font = new Font("Segoe UI", 24F, FontStyle.Bold),
                Dock = DockStyle.Top,
                Height = 70,
                Padding = new Padding(20, 10, 0, 0),
                ForeColor = Color.FromArgb(52, 73, 94)
            };

            cardsPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(20),
                WrapContents = true,
                AutoScroll = true
            };

            this.Controls.Add(cardsPanel);
            this.Controls.Add(lblTitle);
        }

        private void LoadDashboardData()
        {
            try
            {
                SaleDAL saleDAL = new SaleDAL();
                ReportsDAL reportsDAL = new ReportsDAL();
                PrescriptionDAL prescriptionDAL = new PrescriptionDAL();

                decimal todaySales = 0;
                foreach (var sale in saleDAL.GetSalesByDate(DateTime.Today))
                    todaySales += sale.TotalAmount;

                int prescriptionsToday = prescriptionDAL.GetPrescriptionsByDate(DateTime.Today).Count;
                int lowStock = reportsDAL.GetLowStockMedicines().Rows.Count;
                int expiringSoon = reportsDAL.GetExpiringMedicines(30).Rows.Count;

                cardsPanel.Controls.Add(CreateCard("💰 Today's Sales", todaySales.ToString("C"), Color.FromArgb(46, 204, 113)));
                cardsPanel.Controls.Add(CreateCard("📋 Prescriptions Today", prescriptionsToday.ToString(), Color.FromArgb(52, 152, 219)));
                cardsPanel.Controls.Add(CreateCard("⚠️ Low Stock Alerts", lowStock.ToString(), Color.FromArgb(231, 76, 60)));
                cardsPanel.Controls.Add(CreateCard("⏰ Expiring Medicines (30 days)", expiringSoon.ToString(), Color.FromArgb(243, 156, 18)));
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
