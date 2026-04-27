using PharmacyWinFormsApp.DAL;
using PharmacyWinFormsApp.Models;
using System;
using System.Windows.Forms;

namespace PharmacyWinFormsApp.Forms
{
    public partial class LoginForm : Form
    {
        public User? LoggedInUser { get; private set; }

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Please enter username.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please enter password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            try
            {
                UserDAL userDAL = new UserDAL();
                User? user = userDAL.ValidateLogin(txtUsername.Text, txtPassword.Text);

                if (user != null)
                {
                    LoggedInUser = user;
                    this.DialogResult = DialogResult.OK;
                    this.Hide();

                    // Open Dashboard
                    DashboardForm dashboard = new DashboardForm(user);
                    DialogResult dashboardResult = dashboard.ShowDialog();
                    
                    // If logout (Cancel), show login form again
                    if (dashboardResult == DialogResult.Cancel)
                    {
                        this.Show();
                        txtPassword.Clear();
                        txtUsername.Focus();
                    }
                    else
                    {
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Clear();
                    txtUsername.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Login error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}