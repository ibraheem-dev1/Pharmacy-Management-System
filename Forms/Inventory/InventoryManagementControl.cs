using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using PharmacyWinFormsApp.DAL;
using PharmacyWinFormsApp.Models;

namespace PharmacyWinFormsApp.Forms
{
    public partial class InventoryManagementControl : UserControl
    {
        private MedicineBatchDAL batchDAL;
        private MedicineDAL medicineDAL;
        private ReportsDAL reportsDAL;
        private DataTable availableInventoryData;
        private DataTable expiredInventoryData;
        private DataTable outOfStockData;
        private BindingSource availableBindingSource;
        private BindingSource expiredBindingSource;
        private BindingSource outOfStockBindingSource;

        public InventoryManagementControl()
        {
            InitializeComponent();
            batchDAL = new MedicineBatchDAL();
            medicineDAL = new MedicineDAL();
            reportsDAL = new ReportsDAL();
            availableBindingSource = new BindingSource();
            expiredBindingSource = new BindingSource();
            outOfStockBindingSource = new BindingSource();
        }

        private void InventoryManagementControl_Load(object sender, EventArgs e)
        {
            LoadInventoryData();
            ApplyRowColors();
        }

        private void LoadInventoryData()
        {
            try
            {
                List<MedicineBatch> allBatches = batchDAL.GetAllBatches();
                
                // Convert to DataTable
                DataTable allBatchesTable = ConvertToDataTable(allBatches);

                // Filter Available Inventory
                availableInventoryData = allBatchesTable.Clone();
                foreach (DataRow row in allBatchesTable.Rows)
                {
                    int quantityInStock = Convert.ToInt32(row["QuantityInStock"]);
                    DateTime expiryDate = Convert.ToDateTime(row["ExpiryDate"]);

                    if (quantityInStock > 0 && expiryDate > DateTime.Today)
                    {
                        availableInventoryData.ImportRow(row);
                    }
                }

                // Filter Expired Inventory
                expiredInventoryData = allBatchesTable.Clone();
                foreach (DataRow row in allBatchesTable.Rows)
                {
                    DateTime expiryDate = Convert.ToDateTime(row["ExpiryDate"]);
                    if (expiryDate <= DateTime.Today)
                    {
                        expiredInventoryData.ImportRow(row);
                    }
                }

                // Load Out of Stock Medicines (medicines with TotalStock = 0)
                List<Medicine> allMedicines = medicineDAL.GetAllMedicines();
                outOfStockData = ConvertMedicinesToDataTable(allMedicines.Where(m => m.TotalStock == 0).ToList());

                availableBindingSource.DataSource = availableInventoryData;
                expiredBindingSource.DataSource = expiredInventoryData;
                outOfStockBindingSource.DataSource = outOfStockData;

                dgvAvailableInventory.DataSource = availableBindingSource;
                dgvExpiredInventory.DataSource = expiredBindingSource;
                dgvOutOfStock.DataSource = outOfStockBindingSource;

                ConfigureDataGridView(dgvAvailableInventory);
                ConfigureDataGridView(dgvExpiredInventory);
                ConfigureDataGridViewForMedicines(dgvOutOfStock);

                lblAvailableCount.Text = $"Total: {availableInventoryData.Rows.Count} batches";
                lblExpiredCount.Text = $"Total: {expiredInventoryData.Rows.Count} batches";
                lblOutOfStockCount.Text = $"Total: {outOfStockData.Rows.Count} medicines";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading inventory: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable ConvertToDataTable(List<MedicineBatch> batches)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("BatchID", typeof(int));
            dt.Columns.Add("MedicineID", typeof(int));
            dt.Columns.Add("MedicineName", typeof(string));
            dt.Columns.Add("FormulaName", typeof(string));
            dt.Columns.Add("ManufacturerName", typeof(string));
            dt.Columns.Add("BatchNumber", typeof(string));
            dt.Columns.Add("ExpiryDate", typeof(DateTime));
            dt.Columns.Add("QuantityInStock", typeof(int));
            dt.Columns.Add("MinimumStockLevel", typeof(int));
            dt.Columns.Add("SupplierID", typeof(int));
            dt.Columns.Add("SupplierName", typeof(string));
            dt.Columns.Add("PurchaseID", typeof(int));
            dt.Columns.Add("PurchasePrice", typeof(decimal));

            foreach (var batch in batches)
            {
                string medicineNameWithMG = batch.StrengthMG > 0 
                    ? $"{batch.MedicineName} ({batch.StrengthMG}mg)"
                    : batch.MedicineName;

                // Get formula and manufacturer from medicine
                var medicine = medicineDAL.GetAllMedicines().FirstOrDefault(m => m.MedicineID == batch.MedicineID);
                string formulaName = medicine?.FormulaName ?? "N/A";
                string manufacturerName = medicine?.ManufacturerName ?? "N/A";

                dt.Rows.Add(
                    batch.BatchID,
                    batch.MedicineID,
                    medicineNameWithMG,
                    formulaName,
                    manufacturerName,
                    batch.BatchNumber,
                    batch.ExpiryDate,
                    batch.QuantityInStock,
                    batch.MinimumStockLevel,
                    batch.SupplierID,
                    batch.SupplierName,
                    batch.PurchaseID,
                    batch.PurchasePrice
                );
            }

            return dt;
        }

        private DataTable ConvertMedicinesToDataTable(List<Medicine> medicines)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("MedicineID", typeof(int));
            dt.Columns.Add("MedicineName", typeof(string));
            dt.Columns.Add("CategoryName", typeof(string));
            dt.Columns.Add("ManufacturerName", typeof(string));
            dt.Columns.Add("FormulaName", typeof(string));
            dt.Columns.Add("MinimumStockLevel", typeof(int));
            dt.Columns.Add("IsPrescriptionRequired", typeof(bool));

            foreach (var medicine in medicines)
            {
                string medicineNameWithMG = medicine.StrengthMG > 0 
                    ? $"{medicine.Name} ({medicine.StrengthMG}mg)"
                    : medicine.Name;

                dt.Rows.Add(
                    medicine.MedicineID,
                    medicineNameWithMG,
                    medicine.CategoryName,
                    medicine.ManufacturerName,
                    medicine.FormulaName,
                    medicine.MinimumStockLevel,
                    medicine.IsPrescriptionRequired
                );
            }

            return dt;
        }

        private void ConfigureDataGridView(DataGridView dgv)
        {
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.RowHeadersVisible = false;
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgv.ColumnHeadersHeight = 40;
            dgv.RowTemplate.Height = 35;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);

            if (dgv.Columns.Contains("BatchID"))
                dgv.Columns["BatchID"].Visible = false;
            if (dgv.Columns.Contains("MedicineID"))
                dgv.Columns["MedicineID"].Visible = false;
            if (dgv.Columns.Contains("SupplierID"))
                dgv.Columns["SupplierID"].Visible = false;
            if (dgv.Columns.Contains("PurchaseID"))
                dgv.Columns["PurchaseID"].Visible = false;
            if (dgv.Columns.Contains("PurchasePrice"))
                dgv.Columns["PurchasePrice"].Visible = false;

            if (dgv.Columns.Contains("MedicineName"))
                dgv.Columns["MedicineName"].HeaderText = "Medicine Name";
            if (dgv.Columns.Contains("FormulaName"))
                dgv.Columns["FormulaName"].HeaderText = "Formula";
            if (dgv.Columns.Contains("ManufacturerName"))
                dgv.Columns["ManufacturerName"].HeaderText = "Manufacturer";
            if (dgv.Columns.Contains("BatchNumber"))
                dgv.Columns["BatchNumber"].HeaderText = "Batch Number";
            if (dgv.Columns.Contains("ExpiryDate"))
            {
                dgv.Columns["ExpiryDate"].HeaderText = "Expiry Date";
                dgv.Columns["ExpiryDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            if (dgv.Columns.Contains("QuantityInStock"))
                dgv.Columns["QuantityInStock"].HeaderText = "Stock Quantity";
            if (dgv.Columns.Contains("MinimumStockLevel"))
                dgv.Columns["MinimumStockLevel"].HeaderText = "Min Stock Level";
            if (dgv.Columns.Contains("SupplierName"))
                dgv.Columns["SupplierName"].HeaderText = "Supplier";
        }

        private void ConfigureDataGridViewForMedicines(DataGridView dgv)
        {
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.RowHeadersVisible = false;
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgv.ColumnHeadersHeight = 40;
            dgv.RowTemplate.Height = 35;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);

            if (dgv.Columns.Contains("MedicineID"))
                dgv.Columns["MedicineID"].Visible = false;

            if (dgv.Columns.Contains("MedicineName"))
                dgv.Columns["MedicineName"].HeaderText = "Medicine Name";
            if (dgv.Columns.Contains("CategoryName"))
                dgv.Columns["CategoryName"].HeaderText = "Category";
            if (dgv.Columns.Contains("ManufacturerName"))
                dgv.Columns["ManufacturerName"].HeaderText = "Manufacturer";
            if (dgv.Columns.Contains("FormulaName"))
                dgv.Columns["FormulaName"].HeaderText = "Formula";
            if (dgv.Columns.Contains("MinimumStockLevel"))
                dgv.Columns["MinimumStockLevel"].HeaderText = "Min Stock Level";
            if (dgv.Columns.Contains("IsPrescriptionRequired"))
                dgv.Columns["IsPrescriptionRequired"].HeaderText = "Prescription Required";
        }

        private void ApplyRowColors()
        {
            foreach (DataGridViewRow row in dgvAvailableInventory.Rows)
            {
                if (row.Cells["ExpiryDate"].Value != DBNull.Value &&
                    row.Cells["QuantityInStock"].Value != DBNull.Value &&
                    row.Cells["MinimumStockLevel"].Value != DBNull.Value)
                {
                    DateTime expiryDate = Convert.ToDateTime(row.Cells["ExpiryDate"].Value);
                    int quantityInStock = Convert.ToInt32(row.Cells["QuantityInStock"].Value);
                    int minStockLevel = Convert.ToInt32(row.Cells["MinimumStockLevel"].Value);

                    if (expiryDate <= DateTime.Today.AddDays(30))
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 200, 100);
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                    else if (quantityInStock < minStockLevel)
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 150, 150);
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
            }

            foreach (DataGridViewRow row in dgvExpiredInventory.Rows)
            {
                row.DefaultCellStyle.BackColor = Color.FromArgb(220, 220, 220);
                row.DefaultCellStyle.ForeColor = Color.DarkRed;
            }

            foreach (DataGridViewRow row in dgvOutOfStock.Rows)
            {
                row.DefaultCellStyle.BackColor = Color.FromArgb(255, 230, 230);
                row.DefaultCellStyle.ForeColor = Color.FromArgb(192, 57, 43);
                row.DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim().ToLower();

            if (tabControl.SelectedTab == tabAvailable)
            {
                if (string.IsNullOrEmpty(searchText))
                {
                    availableBindingSource.RemoveFilter();
                }
                else
                {
                    availableBindingSource.Filter = $"MedicineName LIKE '%{searchText}%' OR BatchNumber LIKE '%{searchText}%' OR FormulaName LIKE '%{searchText}%' OR ManufacturerName LIKE '%{searchText}%'";
                }
                lblAvailableCount.Text = $"Total: {dgvAvailableInventory.Rows.Count} batches";
            }
            else if (tabControl.SelectedTab == tabExpired)
            {
                if (string.IsNullOrEmpty(searchText))
                {
                    expiredBindingSource.RemoveFilter();
                }
                else
                {
                    expiredBindingSource.Filter = $"MedicineName LIKE '%{searchText}%' OR BatchNumber LIKE '%{searchText}%' OR FormulaName LIKE '%{searchText}%' OR ManufacturerName LIKE '%{searchText}%'";
                }
                lblExpiredCount.Text = $"Total: {dgvExpiredInventory.Rows.Count} batches";
            }
            else if (tabControl.SelectedTab == tabOutOfStock)
            {
                if (string.IsNullOrEmpty(searchText))
                {
                    outOfStockBindingSource.RemoveFilter();
                }
                else
                {
                    outOfStockBindingSource.Filter = $"MedicineName LIKE '%{searchText}%' OR CategoryName LIKE '%{searchText}%' OR ManufacturerName LIKE '%{searchText}%'";
                }
                lblOutOfStockCount.Text = $"Total: {dgvOutOfStock.Rows.Count} medicines";
            }

            ApplyRowColors();
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty;
            ApplyRowColors();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty;
            LoadInventoryData();
            ApplyRowColors();
            MessageBox.Show("Inventory data refreshed successfully.", "Refresh", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dgvAvailableInventory_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            ApplyRowColors();
        }

        private void dgvExpiredInventory_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            ApplyRowColors();
        }

        private void dgvOutOfStock_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            ApplyRowColors();
        }

        private void dgvAvailableInventory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int batchID = Convert.ToInt32(dgvAvailableInventory.Rows[e.RowIndex].Cells["BatchID"].Value);
                ShowBatchDetails(batchID);
            }
        }

        private void dgvExpiredInventory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int batchID = Convert.ToInt32(dgvExpiredInventory.Rows[e.RowIndex].Cells["BatchID"].Value);
                ShowBatchDetails(batchID);
            }
        }

        private void dgvOutOfStock_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int medicineID = Convert.ToInt32(dgvOutOfStock.Rows[e.RowIndex].Cells["MedicineID"].Value);
                ShowMedicineDetails(medicineID);
            }
        }

        private void ShowBatchDetails(int batchID)
        {
            try
            {
                DataTable batchDetails = batchDAL.GetBatchDetails(batchID);
                
                if (batchDetails.Rows.Count > 0)
                {
                    DataRow row = batchDetails.Rows[0];
                    
                    string details = "═══════════════════════════════════\n";
                    details += "         BATCH DETAILS\n";
                    details += "═══════════════════════════════════\n\n";
                    
                    details += $"🏥 Medicine: {row["MedicineName"]} ({row["StrengthMG"]}mg)\n";
                    details += $"💊 Formula: {row["FormulaName"]}\n";
                    details += $"🏭 Manufacturer: {row["ManufacturerName"]}\n";
                    details += $"📦 Category: {row["CategoryName"]}\n\n";
                    
                    details += $"📋 Batch Number: {row["BatchNumber"]}\n";
                    details += $"📅 Expiry Date: {Convert.ToDateTime(row["ExpiryDate"]).ToString("dd/MM/yyyy")}\n";
                    details += $"📊 Quantity in Stock: {row["QuantityInStock"]}\n";
                    details += $"⚠️  Minimum Stock Level: {row["MinimumStockLevel"]}\n";
                    details += $"💰 Purchase Price: {Convert.ToDecimal(row["PurchasePrice"]).ToString("C")}\n\n";
                    
                    details += $"🏢 Supplier: {row["SupplierName"]}\n";
                    details += $"📞 Supplier Contact: {row["SupplierContact"]}\n";
                    details += $"📍 Supplier Address: {row["SupplierAddress"]}\n\n";
                    
                    if (row["PurchaseDate"] != DBNull.Value)
                    {
                        details += $"🛒 Purchase Date: {Convert.ToDateTime(row["PurchaseDate"]).ToString("dd/MM/yyyy")}\n";
                        details += $"👤 Purchased By: {row["PurchasedBy"]}\n";
                    }
                    
                    if (Convert.ToBoolean(row["IsPrescriptionRequired"]))
                        details += "\n⚕️  Prescription Required: Yes";
                    
                    MessageBox.Show(details, "Batch Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading batch details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowMedicineDetails(int medicineID)
        {
            try
            {
                DataTable medicineDetails = medicineDAL.GetMedicineDetails(medicineID);
                
                if (medicineDetails.Rows.Count > 0)
                {
                    DataRow row = medicineDetails.Rows[0];
                    
                    string details = "═══════════════════════════════════\n";
                    details += "       MEDICINE DETAILS\n";
                    details += "═══════════════════════════════════\n\n";
                    
                    details += $"🏥 Medicine: {row["MedicineName"]} ({row["StrengthMG"]}mg)\n";
                    details += $"💊 Formula: {row["FormulaName"]}\n";
                    details += $"🏭 Manufacturer: {row["ManufacturerName"]}\n";
                    details += $"📦 Category: {row["CategoryName"]}\n\n";
                    
                    details += $"📊 Total Stock: {row["TotalStock"]} units\n";
                    details += $"⚠️  Minimum Stock Level: {row["MinimumStockLevel"]} units\n";
                    details += $"📋 Total Batches: {row["TotalBatches"]}\n\n";
                    
                    details += $"✅ Status: {(Convert.ToBoolean(row["IsActive"]) ? "Active" : "Inactive")}\n";
                    
                    if (Convert.ToBoolean(row["IsPrescriptionRequired"]))
                        details += "⚕️  Prescription Required: Yes\n";
                    
                    details += "\n⚠️  This medicine is OUT OF STOCK!\n";
                    details += "Please order new batches immediately.";
                    
                    MessageBox.Show(details, "Medicine Details - OUT OF STOCK", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading medicine details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
