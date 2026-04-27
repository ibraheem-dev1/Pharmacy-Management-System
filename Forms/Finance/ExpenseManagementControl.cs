using PharmacyWinFormsApp.DAL;
using PharmacyWinFormsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PharmacyWinFormsApp.Forms.Finance
{
    public partial class ExpenseManagementControl : UserControl
    {
        private ExpenseDAL expenseDAL;
        private User currentUser;
        private int selectedExpenseID = 0;
        private List<Expense> allExpenses = new List<Expense>();
        private List<string> categories = new List<string>
        {
            "Utilities",
            "Rent",
            "Maintenance",
            "Office Supplies",
            "Marketing",
            "Transportation",
            "Insurance",
            "Taxes",
            "Professional Fees",
            "Miscellaneous"
        };

        public ExpenseManagementControl(User user)
        {
            InitializeComponent();
            expenseDAL = new ExpenseDAL();
            currentUser = user;
        }

        private void ExpenseManagementControl_Load(object sender, EventArgs e)
        {
            LoadCategories();
            dtpStartDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpEndDate.Value = DateTime.Now;
            LoadExpensesData();
        }

        private void LoadCategories()
        {
            cmbCategory.Items.Clear();
            cmbCategory.Items.Add("All Categories");
            cmbCategory.Items.AddRange(categories.ToArray());
            cmbCategory.SelectedIndex = 0;

            cmbCategoryInput.Items.Clear();
            cmbCategoryInput.Items.AddRange(categories.ToArray());
        }

        private void LoadExpensesData()
        {
            // Validate date range
            if (dtpStartDate.Value.Date > dtpEndDate.Value.Date)
            {
                MessageBox.Show("'Start Date' must be less than or equal to 'End Date'.", 
                    "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpEndDate.Value = dtpStartDate.Value;
                return;
            }
            
            allExpenses = expenseDAL.GetAllExpenses();
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            var filtered = allExpenses.AsEnumerable();

            // Filter by Date Range
            filtered = filtered.Where(e => e.ExpenseDate >= dtpStartDate.Value.Date && 
                                          e.ExpenseDate <= dtpEndDate.Value.Date);

            // Filter by Category
            if (cmbCategory.SelectedIndex > 0)
            {
                string selectedCategory = cmbCategory.SelectedItem.ToString();
                filtered = filtered.Where(e => e.Category == selectedCategory);
            }

            // Search filter
            if (!string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                string searchText = txtSearch.Text.ToLower();
                filtered = filtered.Where(e =>
                    e.Description.ToLower().Contains(searchText) ||
                    e.Category.ToLower().Contains(searchText) ||
                    e.RecordedByName.ToLower().Contains(searchText)
                );
            }

            var result = filtered.ToList();
            dgvExpenses.DataSource = result;

            // Calculate and display total
            decimal totalExpenses = result.Sum(e => e.Amount);
            lblTotalValue.Text = totalExpenses.ToString("C2");

            FormatDataGridView();
        }

        private void FormatDataGridView()
        {
            if (dgvExpenses.Columns["ExpenseID"] != null)
                dgvExpenses.Columns["ExpenseID"].Visible = false;
            if (dgvExpenses.Columns["RecordedBy"] != null)
                dgvExpenses.Columns["RecordedBy"].Visible = false;

            if (dgvExpenses.Columns["Description"] != null)
                dgvExpenses.Columns["Description"].HeaderText = "Description";
            if (dgvExpenses.Columns["Amount"] != null)
            {
                dgvExpenses.Columns["Amount"].HeaderText = "Amount";
                dgvExpenses.Columns["Amount"].DefaultCellStyle.Format = "C2";
                dgvExpenses.Columns["Amount"].DefaultCellStyle.Font = new System.Drawing.Font(dgvExpenses.Font, System.Drawing.FontStyle.Bold);
            }
            if (dgvExpenses.Columns["Category"] != null)
                dgvExpenses.Columns["Category"].HeaderText = "Category";
            if (dgvExpenses.Columns["ExpenseDate"] != null)
            {
                dgvExpenses.Columns["ExpenseDate"].HeaderText = "Expense Date";
                dgvExpenses.Columns["ExpenseDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            if (dgvExpenses.Columns["RecordedDate"] != null)
            {
                dgvExpenses.Columns["RecordedDate"].HeaderText = "Recorded Date";
                dgvExpenses.Columns["RecordedDate"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            }
            if (dgvExpenses.Columns["RecordedByName"] != null)
                dgvExpenses.Columns["RecordedByName"].HeaderText = "Recorded By";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInput())
                    return;

                string description = txtDescription.Text.Trim();
                decimal amount = numAmount.Value;
                string category = cmbCategoryInput.SelectedItem.ToString();
                DateTime expenseDate = dtpExpenseDate.Value.Date;

                // Validate expense date is not in future
                if (expenseDate > DateTime.Today)
                {
                    MessageBox.Show("Expense date cannot be in the future.", "Invalid Date", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                expenseDAL.AddExpense(description, amount, category, expenseDate, currentUser.UserID);

                MessageBox.Show("Expense record added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
                LoadExpensesData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding expense: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedExpenseID == 0)
                {
                    MessageBox.Show("Please select an expense record to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!ValidateInput())
                    return;

                string description = txtDescription.Text.Trim();
                decimal amount = numAmount.Value;
                string category = cmbCategoryInput.SelectedItem.ToString();
                DateTime expenseDate = dtpExpenseDate.Value.Date;

                expenseDAL.UpdateExpense(selectedExpenseID, description, amount, category, expenseDate);

                MessageBox.Show("Expense record updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
                LoadExpensesData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating expense: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedExpenseID == 0)
                {
                    MessageBox.Show("Please select an expense record to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var result = MessageBox.Show("Are you sure you want to delete this expense record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    expenseDAL.DeleteExpense(selectedExpenseID);
                    MessageBox.Show("Expense record deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputs();
                    LoadExpensesData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting expense: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void dgvExpenses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvExpenses.Rows[e.RowIndex];
                selectedExpenseID = Convert.ToInt32(row.Cells["ExpenseID"].Value);

                txtDescription.Text = row.Cells["Description"].Value.ToString();
                numAmount.Value = Convert.ToDecimal(row.Cells["Amount"].Value);
                cmbCategoryInput.SelectedItem = row.Cells["Category"].Value.ToString();
                dtpExpenseDate.Value = Convert.ToDateTime(row.Cells["ExpenseDate"].Value);

                btnAdd.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("Please enter a description.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (numAmount.Value <= 0)
            {
                MessageBox.Show("Amount must be greater than zero.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbCategoryInput.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a category.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void ClearInputs()
        {
            selectedExpenseID = 0;
            txtDescription.Text = "";
            numAmount.Value = 0;
            cmbCategoryInput.SelectedIndex = -1;
            dtpExpenseDate.Value = DateTime.Now;

            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }
    }
}
