using PharmacyWinFormsApp.DAL;
using PharmacyWinFormsApp.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace PharmacyWinFormsApp.Forms.Finance
{
    public partial class SalaryManagementControl : UserControl
    {
        private SalaryDAL salaryDAL;
        private UserDAL userDAL;
        private User currentUser;
        private int selectedSalaryID = 0;
        private List<Salary> allSalaries = new List<Salary>();

        public SalaryManagementControl(User user)
        {
            InitializeComponent();
            salaryDAL = new SalaryDAL();
            userDAL = new UserDAL();
            currentUser = user;
        }

        private void SalaryManagementControl_Load(object sender, EventArgs e)
        {
            LoadUsers();
            LoadMonths();
            LoadYears();
            LoadSalariesData();
        }

        private void LoadUsers()
        {
            List<User> users = userDAL.GetAllUsers();
            
            // Load for filter dropdown
            cmbUser.DataSource = new List<User>(users);
            cmbUser.DisplayMember = "UserName";
            cmbUser.ValueMember = "UserID";
            cmbUser.SelectedIndex = -1;
            
            // Load for input dropdown
            cmbUserInput.DataSource = new List<User>(users);
            cmbUserInput.DisplayMember = "UserName";
            cmbUserInput.ValueMember = "UserID";
            cmbUserInput.SelectedIndex = -1;
        }

        private void LoadMonths()
        {
            cmbMonth.Items.Clear();
            cmbMonth.Items.Add("All Months");
            for (int i = 1; i <= 12; i++)
            {
                cmbMonth.Items.Add(i);
            }
            cmbMonth.SelectedIndex = 0;
        }

        private void LoadYears()
        {
            cmbYear.Items.Clear();
            cmbYear.Items.Add("All Years");
            int currentYear = DateTime.Now.Year;
            for (int i = currentYear; i >= currentYear - 10; i--)
            {
                cmbYear.Items.Add(i);
            }
            cmbYear.SelectedIndex = 0;
        }

        private void LoadSalariesData()
        {
            allSalaries = salaryDAL.GetAllSalaries();
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            var filtered = allSalaries.AsEnumerable();

            // Filter by Month
            if (cmbMonth.SelectedIndex > 0 && cmbMonth.SelectedItem is int month)
            {
                filtered = filtered.Where(s => s.Month == month);
            }

            // Filter by Year
            if (cmbYear.SelectedIndex > 0 && cmbYear.SelectedItem is int year)
            {
                filtered = filtered.Where(s => s.Year == year);
            }

            // Filter by User
            if (cmbUser.SelectedIndex >= 0 && cmbUser.SelectedValue is int userId)
            {
                filtered = filtered.Where(s => s.UserID == userId);
            }

            // Search filter
            if (!string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                string searchText = txtSearch.Text.ToLower();
                filtered = filtered.Where(s =>
                    s.UserName.ToLower().Contains(searchText) ||
                    s.RecordedByName.ToLower().Contains(searchText)
                );
            }

            var result = filtered.ToList();
            dgvSalaries.DataSource = result;

            // Calculate and display totals
            decimal totalBasic = result.Sum(s => s.BasicSalary);
            decimal totalBonus = result.Sum(s => s.Bonus);
            decimal totalDeductions = result.Sum(s => s.Deductions);
            decimal totalNet = result.Sum(s => s.NetSalary);

            lblTotalBasicValue.Text = totalBasic.ToString("C2");
            lblTotalBonusValue.Text = totalBonus.ToString("C2");
            lblTotalDeductionsValue.Text = totalDeductions.ToString("C2");
            lblTotalNetValue.Text = totalNet.ToString("C2");

            FormatDataGridView();
        }

        private void FormatDataGridView()
        {
            if (dgvSalaries.Columns["SalaryID"] != null)
                dgvSalaries.Columns["SalaryID"].Visible = false;
            if (dgvSalaries.Columns["UserID"] != null)
                dgvSalaries.Columns["UserID"].Visible = false;
            if (dgvSalaries.Columns["RecordedBy"] != null)
                dgvSalaries.Columns["RecordedBy"].Visible = false;

            if (dgvSalaries.Columns["UserName"] != null)
                dgvSalaries.Columns["UserName"].HeaderText = "Employee";
            if (dgvSalaries.Columns["Month"] != null)
                dgvSalaries.Columns["Month"].HeaderText = "Month";
            if (dgvSalaries.Columns["Year"] != null)
                dgvSalaries.Columns["Year"].HeaderText = "Year";
            if (dgvSalaries.Columns["BasicSalary"] != null)
            {
                dgvSalaries.Columns["BasicSalary"].HeaderText = "Basic Salary";
                dgvSalaries.Columns["BasicSalary"].DefaultCellStyle.Format = "C2";
            }
            if (dgvSalaries.Columns["Bonus"] != null)
            {
                dgvSalaries.Columns["Bonus"].HeaderText = "Bonus";
                dgvSalaries.Columns["Bonus"].DefaultCellStyle.Format = "C2";
            }
            if (dgvSalaries.Columns["Deductions"] != null)
            {
                dgvSalaries.Columns["Deductions"].HeaderText = "Deductions";
                dgvSalaries.Columns["Deductions"].DefaultCellStyle.Format = "C2";
            }
            if (dgvSalaries.Columns["NetSalary"] != null)
            {
                dgvSalaries.Columns["NetSalary"].HeaderText = "Net Salary";
                dgvSalaries.Columns["NetSalary"].DefaultCellStyle.Format = "C2";
                dgvSalaries.Columns["NetSalary"].DefaultCellStyle.Font = new System.Drawing.Font(dgvSalaries.Font, System.Drawing.FontStyle.Bold);
            }
            if (dgvSalaries.Columns["RecordedDate"] != null)
            {
                dgvSalaries.Columns["RecordedDate"].HeaderText = "Recorded Date";
                dgvSalaries.Columns["RecordedDate"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            }
            if (dgvSalaries.Columns["RecordedByName"] != null)
                dgvSalaries.Columns["RecordedByName"].HeaderText = "Recorded By";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInput())
                    return;

                int userID = (int)cmbUserInput.SelectedValue;
                int month = (int)numMonth.Value;
                int year = (int)numYear.Value;
                decimal basicSalary = numBasicSalary.Value;
                decimal bonus = numBonus.Value;
                decimal deductions = numDeductions.Value;

                salaryDAL.AddSalary(userID, month, year, basicSalary, bonus, deductions, currentUser.UserID);

                MessageBox.Show("Salary record added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
                LoadSalariesData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding salary: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedSalaryID == 0)
                {
                    MessageBox.Show("Please select a salary record to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!ValidateInput())
                    return;

                decimal basicSalary = numBasicSalary.Value;
                decimal bonus = numBonus.Value;
                decimal deductions = numDeductions.Value;

                salaryDAL.UpdateSalary(selectedSalaryID, basicSalary, bonus, deductions);

                MessageBox.Show("Salary record updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
                LoadSalariesData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating salary: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedSalaryID == 0)
                {
                    MessageBox.Show("Please select a salary record to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var result = MessageBox.Show("Are you sure you want to delete this salary record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    salaryDAL.DeleteSalary(selectedSalaryID);
                    MessageBox.Show("Salary record deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputs();
                    LoadSalariesData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting salary: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void dgvSalaries_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSalaries.Rows[e.RowIndex];
                selectedSalaryID = Convert.ToInt32(row.Cells["SalaryID"].Value);

                cmbUserInput.SelectedValue = row.Cells["UserID"].Value;
                numMonth.Value = Convert.ToInt32(row.Cells["Month"].Value);
                numYear.Value = Convert.ToInt32(row.Cells["Year"].Value);
                numBasicSalary.Value = Convert.ToDecimal(row.Cells["BasicSalary"].Value);
                numBonus.Value = Convert.ToDecimal(row.Cells["Bonus"].Value);
                numDeductions.Value = Convert.ToDecimal(row.Cells["Deductions"].Value);

                btnAdd.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        private void cmbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void cmbUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private bool ValidateInput()
        {
            if (cmbUserInput.SelectedIndex < 0)
            {
                MessageBox.Show("Please select an employee.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (numBasicSalary.Value <= 0)
            {
                MessageBox.Show("Basic salary must be greater than zero.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void ClearInputs()
        {
            selectedSalaryID = 0;
            cmbUserInput.SelectedIndex = -1;
            numMonth.Value = DateTime.Now.Month;
            numYear.Value = DateTime.Now.Year;
            numBasicSalary.Value = 0;
            numBonus.Value = 0;
            numDeductions.Value = 0;

            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }
    }
}
