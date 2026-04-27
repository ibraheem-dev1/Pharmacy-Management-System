using PharmacyWinFormsApp.DAL;
using PharmacyWinFormsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PharmacyWinFormsApp.Forms.Medicines
{
    public partial class MedicineManagementControl : UserControl
    {
        private MedicineDAL medicineDAL;
        private CategoryDAL categoryDAL;
        private ManufacturerDAL manufacturerDAL;
        private FormulaDAL formulaDAL;
        private int selectedMedicineID = 0;
        private List<Medicine> allMedicines = new List<Medicine>();

        public MedicineManagementControl()
        {
            InitializeComponent();
            medicineDAL = new MedicineDAL();
            categoryDAL = new CategoryDAL();
            manufacturerDAL = new ManufacturerDAL();
            formulaDAL = new FormulaDAL();
        }

        private void MedicineManagementControl_Load(object sender, EventArgs e)
        {
            LoadComboBoxData();
            LoadMedicinesData();
        }

        private void LoadComboBoxData()
        {
            // Load Categories
            List<Category> categories = categoryDAL.GetAllCategories();
            cmbCategory.DataSource = categories;
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "CategoryID";

            // Load Manufacturers
            List<Manufacturer> manufacturers = manufacturerDAL.GetAllManufacturers();
            cmbManufacturer.DataSource = manufacturers;
            cmbManufacturer.DisplayMember = "ManufacturerName";
            cmbManufacturer.ValueMember = "ManufacturerID";

            // Load Formulas
            List<Formula> formulas = formulaDAL.GetAllFormulas();
            cmbFormula.DataSource = formulas;
            cmbFormula.DisplayMember = "FormulaName";
            cmbFormula.ValueMember = "FormulaID";
        }

        private void LoadMedicinesData()
        {
            allMedicines = medicineDAL.GetAllMedicines();
            dgvMedicines.DataSource = allMedicines;

            // Hide ID columns and set column headers
            if (dgvMedicines.Columns["MedicineID"] != null)
                dgvMedicines.Columns["MedicineID"].Visible = false;
            if (dgvMedicines.Columns["CategoryID"] != null)
                dgvMedicines.Columns["CategoryID"].Visible = false;
            if (dgvMedicines.Columns["ManufacturerID"] != null)
                dgvMedicines.Columns["ManufacturerID"].Visible = false;
            if (dgvMedicines.Columns["FormulaID"] != null)
                dgvMedicines.Columns["FormulaID"].Visible = false;

            // Set display names
            if (dgvMedicines.Columns["Name"] != null)
                dgvMedicines.Columns["Name"].HeaderText = "Medicine Name";
            if (dgvMedicines.Columns["StrengthMG"] != null)
                dgvMedicines.Columns["StrengthMG"].HeaderText = "Strength (MG)";
            if (dgvMedicines.Columns["MinimumStockLevel"] != null)
                dgvMedicines.Columns["MinimumStockLevel"].HeaderText = "Min Stock Level";
            if (dgvMedicines.Columns["IsPrescriptionRequired"] != null)
                dgvMedicines.Columns["IsPrescriptionRequired"].HeaderText = "Prescription Required";
            if (dgvMedicines.Columns["IsActive"] != null)
                dgvMedicines.Columns["IsActive"].HeaderText = "Active";
            if (dgvMedicines.Columns["TotalStock"] != null)
                dgvMedicines.Columns["TotalStock"].HeaderText = "Current Stock";
        }

        private void FilterMedicines(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
            {
                dgvMedicines.DataSource = allMedicines;
            }
            else
            {
                var filtered = allMedicines.Where(m =>
                    m.Name.ToLower().Contains(searchText.ToLower()) ||
                    m.CategoryName.ToLower().Contains(searchText.ToLower()) ||
                    m.ManufacturerName.ToLower().Contains(searchText.ToLower()) ||
                    m.FormulaName.ToLower().Contains(searchText.ToLower())
                ).ToList();
                dgvMedicines.DataSource = filtered;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                Medicine medicine = new Medicine
                {
                    Name = txtName.Text.Trim(),
                    StrengthMG = (int)numStrength.Value,
                    MinimumStockLevel = (int)numMinStock.Value,
                    IsPrescriptionRequired = chkIsPrescriptionRequired.Checked,
                    IsActive = chkIsActive.Checked,
                    CategoryID = cmbCategory.SelectedValue != null ? (int)cmbCategory.SelectedValue : 0,
                    ManufacturerID = cmbManufacturer.SelectedValue != null ? (int)cmbManufacturer.SelectedValue : 0,
                    FormulaID = cmbFormula.SelectedValue != null ? (int)cmbFormula.SelectedValue : 0
                };

                if (medicineDAL.AddMedicine(medicine))
                {
                    MessageBox.Show("Medicine added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    LoadMedicinesData();
                }
                else
                {
                    MessageBox.Show("Medicine already exists!\n\nA medicine with the same Name, Strength, Category, Manufacturer, and Formula is already in the system.", 
                        "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedMedicineID == 0)
            {
                MessageBox.Show("Please select a medicine to update.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ValidateForm())
            {
                Medicine medicine = new Medicine
                {
                    MedicineID = selectedMedicineID,
                    Name = txtName.Text.Trim(),
                    StrengthMG = (int)numStrength.Value,
                    MinimumStockLevel = (int)numMinStock.Value,
                    IsPrescriptionRequired = chkIsPrescriptionRequired.Checked,
                    IsActive = chkIsActive.Checked,
                    CategoryID = cmbCategory.SelectedValue != null ? (int)cmbCategory.SelectedValue : 0,
                    ManufacturerID = cmbManufacturer.SelectedValue != null ? (int)cmbManufacturer.SelectedValue : 0,
                    FormulaID = cmbFormula.SelectedValue != null ? (int)cmbFormula.SelectedValue : 0
                };

                if (medicineDAL.UpdateMedicine(medicine))
                {
                    MessageBox.Show("Medicine updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    LoadMedicinesData();
                }
                else
                {
                    MessageBox.Show("Failed to update medicine.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDeactivate_Click(object sender, EventArgs e)
        {
            if (selectedMedicineID == 0)
            {
                MessageBox.Show("Please select a medicine to deactivate.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to deactivate this medicine?", "Confirm Deactivation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (medicineDAL.DeactivateMedicine(selectedMedicineID))
                {
                    MessageBox.Show("Medicine deactivated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    LoadMedicinesData();
                }
                else
                {
                    MessageBox.Show("Failed to deactivate medicine.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void dgvMedicines_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvMedicines.Rows[e.RowIndex];
                selectedMedicineID = Convert.ToInt32(row.Cells["MedicineID"].Value);
                
                txtName.Text = row.Cells["Name"].Value.ToString();
                numStrength.Value = Convert.ToDecimal(row.Cells["StrengthMG"].Value);
                numMinStock.Value = Convert.ToDecimal(row.Cells["MinimumStockLevel"].Value);
                chkIsPrescriptionRequired.Checked = Convert.ToBoolean(row.Cells["IsPrescriptionRequired"].Value);
                chkIsActive.Checked = Convert.ToBoolean(row.Cells["IsActive"].Value);
                
                cmbCategory.SelectedValue = Convert.ToInt32(row.Cells["CategoryID"].Value);
                cmbManufacturer.SelectedValue = Convert.ToInt32(row.Cells["ManufacturerID"].Value);
                cmbFormula.SelectedValue = Convert.ToInt32(row.Cells["FormulaID"].Value);
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter medicine name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }

            if (cmbCategory.SelectedValue == null)
            {
                MessageBox.Show("Please select a category.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCategory.Focus();
                return false;
            }

            if (cmbManufacturer.SelectedValue == null)
            {
                MessageBox.Show("Please select a manufacturer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbManufacturer.Focus();
                return false;
            }

            if (cmbFormula.SelectedValue == null)
            {
                MessageBox.Show("Please select a formula.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbFormula.Focus();
                return false;
            }

            return true;
        }

        private void ClearForm()
        {
            selectedMedicineID = 0;
            txtName.Clear();
            numStrength.Value = 1;
            numMinStock.Value = 10;
            chkIsPrescriptionRequired.Checked = false;
            chkIsActive.Checked = true;
            
            if (cmbCategory.Items.Count > 0)
                cmbCategory.SelectedIndex = 0;
            if (cmbManufacturer.Items.Count > 0)
                cmbManufacturer.SelectedIndex = 0;
            if (cmbFormula.Items.Count > 0)
                cmbFormula.SelectedIndex = 0;
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            using (AddCategoryForm categoryForm = new AddCategoryForm())
            {
                if (categoryForm.ShowDialog() == DialogResult.OK)
                {
                    LoadComboBoxData();
                    // Set the newly added category as selected
                    if (cmbCategory.Items.Count > 0)
                        cmbCategory.SelectedIndex = cmbCategory.Items.Count - 1;
                }
            }
        }

        private void btnAddManufacturer_Click(object sender, EventArgs e)
        {
            using (AddManufacturerForm manufacturerForm = new AddManufacturerForm())
            {
                if (manufacturerForm.ShowDialog() == DialogResult.OK)
                {
                    LoadComboBoxData();
                    // Set the newly added manufacturer as selected
                    if (cmbManufacturer.Items.Count > 0)
                        cmbManufacturer.SelectedIndex = cmbManufacturer.Items.Count - 1;
                }
            }
        }

        private void btnAddFormula_Click(object sender, EventArgs e)
        {
            using (AddFormulaForm formulaForm = new AddFormulaForm())
            {
                if (formulaForm.ShowDialog() == DialogResult.OK)
                {
                    LoadComboBoxData();
                    // Set the newly added formula as selected
                    if (cmbFormula.Items.Count > 0)
                        cmbFormula.SelectedIndex = cmbFormula.Items.Count - 1;
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            FilterMedicines(txtSearch.Text);
        }
    }
}