using PharmacyWinFormsApp.Models;
using PharmacyWinFormsApp.Forms.Medicines;
using PharmacyWinFormsApp.Forms.Suppliers;
using PharmacyWinFormsApp.Forms.Customers;
using PharmacyWinFormsApp.Forms.Prescriptions;
using PharmacyWinFormsApp.Forms.Purchases;
using PharmacyWinFormsApp.Forms.Sales;
using PharmacyWinFormsApp.Forms.Reports;
using PharmacyWinFormsApp.Forms.Users;
using PharmacyWinFormsApp.Forms.Finance;
using System;
using System.Windows.Forms;

namespace PharmacyWinFormsApp.Forms
{
    public partial class DashboardForm : Form
    {
        private User currentUser;
        private Button activeButton;

        public DashboardForm(User user)
        {
            InitializeComponent();
            currentUser = user;
            lblWelcome.Text = $"{user.UserName} ({user.RoleName})";

            BuildSidebarForRole();
            
            // Highlight the first visible button based on role
            if (currentUser.RoleName.Equals("SalesMan", StringComparison.OrdinalIgnoreCase) || 
                currentUser.RoleName.Equals("Salesman", StringComparison.OrdinalIgnoreCase))
            {
                Highlight(btnInventory);
                LoadUserControl(new InventoryManagementControl());
            }
            else
            {
                Highlight(btnDashboard);
                LoadRoleSpecificDashboard();
            }
        }

        private void BuildSidebarForRole()
        {
            panelSidebar.SuspendLayout();

            btnDashboard.Visible = false;
            btnMedicines.Visible = false;
            btnInventory.Visible = false;
            btnSuppliers.Visible = false;
            btnCustomers.Visible = false;
            btnPrescriptions.Visible = false;
            btnPurchases.Visible = false;
            btnSales.Visible = false;
            btnReports.Visible = false;
            btnSalaries.Visible = false;
            btnExpenses.Visible = false;
            btnUsers.Visible = false;

            int top = 70;

            void ShowButton(Button btn)
            {
                btn.Visible = true;
                btn.Location = new System.Drawing.Point(15, top);
                top += 60;
            }

            if (currentUser.RoleName.Equals("SalesMan", StringComparison.OrdinalIgnoreCase) || 
                currentUser.RoleName.Equals("Salesman", StringComparison.OrdinalIgnoreCase))
            {
                ShowButton(btnInventory);
                ShowButton(btnSales);
                ShowButton(btnPrescriptions);
                ShowButton(btnCustomers);
                ShowButton(btnMedicines);
            }
            else if (currentUser.RoleName == "Manager")
            {
                ShowButton(btnDashboard);
                ShowButton(btnMedicines);
                ShowButton(btnInventory);
                ShowButton(btnSales);
                ShowButton(btnPrescriptions);
                ShowButton(btnCustomers);
                ShowButton(btnPurchases);
            }
            else if (currentUser.RoleName == "Admin")
            {
                ShowButton(btnDashboard);
                ShowButton(btnMedicines);
                ShowButton(btnInventory);
                ShowButton(btnSuppliers);
                ShowButton(btnCustomers);
                ShowButton(btnPrescriptions);
                ShowButton(btnPurchases);
                ShowButton(btnSales);
                ShowButton(btnReports);
                ShowButton(btnSalaries);
                ShowButton(btnExpenses);
                ShowButton(btnUsers);
            }

            panelSidebar.ResumeLayout();
        }

        private void LoadUserControl(UserControl userControl)
        {
            panelMain.Controls.Clear();
            userControl.Dock = DockStyle.Fill;
            panelMain.Controls.Add(userControl);
        }

        private void Highlight(Button activeButton)
        {
            if (btnDashboard.Visible)
            {
                btnDashboard.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
                btnDashboard.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular);
            }
            if (btnMedicines.Visible)
            {
                btnMedicines.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
                btnMedicines.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular);
            }
            if (btnInventory.Visible)
            {
                btnInventory.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
                btnInventory.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular);
            }
            if (btnSuppliers.Visible)
            {
                btnSuppliers.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
                btnSuppliers.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular);
            }
            if (btnCustomers.Visible)
            {
                btnCustomers.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
                btnCustomers.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular);
            }
            if (btnPrescriptions.Visible)
            {
                btnPrescriptions.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
                btnPrescriptions.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular);
            }
            if (btnPurchases.Visible)
            {
                btnPurchases.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
                btnPurchases.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular);
            }
            if (btnSales.Visible)
            {
                btnSales.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
                btnSales.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular);
            }
            if (btnReports.Visible)
            {
                btnReports.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
                btnReports.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular);
            }
            if (btnUsers.Visible)
            {
                btnUsers.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
                btnUsers.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular);
            }
            if (btnSalaries.Visible)
            {
                btnSalaries.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
                btnSalaries.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular);
            }
            if (btnExpenses.Visible)
            {
                btnExpenses.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
                btnExpenses.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular);
            }

            activeButton.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            activeButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            Highlight(btnDashboard);
            LoadRoleSpecificDashboard();
        }

        private void LoadRoleSpecificDashboard()
        {
            if (currentUser.RoleName.Equals("Admin", StringComparison.OrdinalIgnoreCase))
            {
                LoadUserControl(new AdminDashboardOverviewControl());
            }
            else if (currentUser.RoleName.Equals("Manager", StringComparison.OrdinalIgnoreCase))
            {
                LoadUserControl(new ManagerDashboardOverviewControl());
            }
            else
            {
                LoadUserControl(new DashboardOverviewControl());
            }
        }

        private void btnMedicines_Click(object sender, EventArgs e)
        {
            Highlight(btnMedicines);
            LoadUserControl(new MedicineManagementControl());
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            Highlight(btnInventory);
            LoadUserControl(new InventoryManagementControl());
        }

        private void btnSuppliers_Click(object sender, EventArgs e)
        {
            Highlight(btnSuppliers);
            LoadUserControl(new SupplierManagementControl());
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            Highlight(btnCustomers);
            LoadUserControl(new CustomerManagementControl());
        }

        private void btnPrescriptions_Click(object sender, EventArgs e)
        {
            Highlight(btnPrescriptions);
            LoadUserControl(new PrescriptionManagementControl());
        }

        private void btnPurchases_Click(object sender, EventArgs e)
        {
            Highlight(btnPurchases);
            LoadUserControl(new PurchaseManagementControl(currentUser.UserID));
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            Highlight(btnSales);
            LoadUserControl(new SaleManagementControl(currentUser.UserID));
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            Highlight(btnReports);
            LoadUserControl(new ReportsControl());
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            Highlight(btnUsers);
            LoadUserControl(new UserManagementControl());
        }

        private void btnSalaries_Click(object sender, EventArgs e)
        {
            Highlight(btnSalaries);
            LoadUserControl(new SalaryManagementControl(currentUser));
        }

        private void btnExpenses_Click(object sender, EventArgs e)
        {
            Highlight(btnExpenses);
            LoadUserControl(new ExpenseManagementControl(currentUser));
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to logout?", "Confirm Logout",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }
    }
}
