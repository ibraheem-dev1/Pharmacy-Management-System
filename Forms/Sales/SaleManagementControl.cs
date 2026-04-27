using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PharmacyWinFormsApp.DAL;
using PharmacyWinFormsApp.Models;

namespace PharmacyWinFormsApp.Forms.Sales
{
    public partial class SaleManagementControl : UserControl
    {
        private int currentUserID;
        private readonly SaleDAL saleDAL;
        private readonly SaleDetailDAL saleDetailDAL;
        private readonly MedicineDAL medicineDAL;
        private readonly CustomerDAL customerDAL;
        private readonly MedicineBatchDAL medicineBatchDAL;
        private readonly PrescriptionDAL prescriptionDAL;
        private readonly PrescriptionDetailDAL prescriptionDetailDAL;
        
        private List<SaleItem> saleItems = new List<SaleItem>();
        private int? selectedCustomerID = null;
        private int? selectedPrescriptionID = null;

        private Label lblTitle = null!;
        private GroupBox grpCustomer = null!;
        private GroupBox grpMedicines = null!;
        private ComboBox cmbCustomer = null!;
        private ComboBox cmbPrescription = null!;
        private ComboBox cmbMedicine = null!;
        private NumericUpDown numQuantity = null!;
        private NumericUpDown numSellingPrice = null!;
        private Button btnAddToCart = null!;
        private Button btnRemoveItem = null!;
        private Button btnCompleteSale = null!;
        private Button btnClear = null!;
        private DataGridView dgvCart = null!;
        private DataGridView dgvSales = null!;
        private Label lblCustomer = null!;
        private Label lblPrescription = null!;
        private Label lblMedicine = null!;
        private Label lblQuantity = null!;
        private Label lblSellingPrice = null!;
        private Label lblTotal = null!;
        private Label lblTotalAmount = null!;
        private CheckBox chkWalkIn = null!;
        private Label lblFormulaSearch = null!;
        private TextBox txtFormulaSearch = null!;
        
        private List<Medicine> allMedicines = new List<Medicine>();

        public SaleManagementControl(int userID)
        {
            saleDAL = new SaleDAL();
            saleDetailDAL = new SaleDetailDAL();
            medicineDAL = new MedicineDAL();
            customerDAL = new CustomerDAL();
            medicineBatchDAL = new MedicineBatchDAL();
            prescriptionDAL = new PrescriptionDAL();
            prescriptionDetailDAL = new PrescriptionDetailDAL();
            currentUserID = userID;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.lblTitle = new Label();
            this.grpCustomer = new GroupBox();
            this.grpMedicines = new GroupBox();
            this.cmbCustomer = new ComboBox();
            this.cmbPrescription = new ComboBox();
            this.cmbMedicine = new ComboBox();
            this.numQuantity = new NumericUpDown();
            this.numSellingPrice = new NumericUpDown();
            this.btnAddToCart = new Button();
            this.btnRemoveItem = new Button();
            this.btnCompleteSale = new Button();
            this.btnClear = new Button();
            this.dgvCart = new DataGridView();
            this.dgvSales = new DataGridView();
            this.lblCustomer = new Label();
            this.lblPrescription = new Label();
            this.lblMedicine = new Label();
            this.lblQuantity = new Label();
            this.lblSellingPrice = new Label();
            this.lblTotal = new Label();
            this.lblTotalAmount = new Label();
            this.chkWalkIn = new CheckBox();
            this.lblFormulaSearch = new Label();
            this.txtFormulaSearch = new TextBox();
            
            this.grpCustomer.SuspendLayout();
            this.grpMedicines.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSellingPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSales)).BeginInit();
            this.SuspendLayout();
            
            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.FromArgb(41, 128, 185);
            this.lblTitle.Location = new Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(220, 35);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "💊 Sales Management";
            
            // grpCustomer
            this.grpCustomer.BackColor = Color.White;
            this.grpCustomer.Controls.Add(this.chkWalkIn);
            this.grpCustomer.Controls.Add(this.lblCustomer);
            this.grpCustomer.Controls.Add(this.cmbCustomer);
            this.grpCustomer.Controls.Add(this.lblPrescription);
            this.grpCustomer.Controls.Add(this.cmbPrescription);
            this.grpCustomer.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            this.grpCustomer.Location = new Point(20, 60);
            this.grpCustomer.Name = "grpCustomer";
            this.grpCustomer.Padding = new Padding(15);
            this.grpCustomer.Size = new Size(920, 100);
            this.grpCustomer.TabIndex = 1;
            this.grpCustomer.TabStop = false;
            this.grpCustomer.Text = "Customer Information";
            
            // chkWalkIn
            this.chkWalkIn.AutoSize = true;
            this.chkWalkIn.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            this.chkWalkIn.Location = new Point(20, 65);
            this.chkWalkIn.Name = "chkWalkIn";
            this.chkWalkIn.Size = new Size(145, 21);
            this.chkWalkIn.TabIndex = 5;
            this.chkWalkIn.Text = "Walk-in Customer";
            this.chkWalkIn.UseVisualStyleBackColor = true;
            this.chkWalkIn.CheckedChanged += new EventHandler(this.chkWalkIn_CheckedChanged);
            
            // lblFormulaSearch
            this.lblFormulaSearch.AutoSize = true;
            this.lblFormulaSearch.Location = new Point(20, 35);
            this.lblFormulaSearch.Name = "lblFormulaSearch";
            this.lblFormulaSearch.Size = new Size(100, 15);
            this.lblFormulaSearch.TabIndex = 0;
            this.lblFormulaSearch.Text = "Search by Formula:";
            
            // txtFormulaSearch
            this.txtFormulaSearch.Location = new Point(130, 32);
            this.txtFormulaSearch.Name = "txtFormulaSearch";
            this.txtFormulaSearch.Size = new Size(300, 23);
            this.txtFormulaSearch.TabIndex = 0;
            this.txtFormulaSearch.PlaceholderText = "Type formula name to filter medicines...";
            this.txtFormulaSearch.TextChanged += new EventHandler(this.txtFormulaSearch_TextChanged);
            
            // lblCustomer
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.lblCustomer.Location = new Point(20, 30);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new Size(75, 17);
            this.lblCustomer.TabIndex = 1;
            this.lblCustomer.Text = "Customer:";
            
            // cmbCustomer
            this.cmbCustomer.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbCustomer.Font = new Font("Segoe UI", 9.5F);
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new Point(110, 27);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new Size(350, 25);
            this.cmbCustomer.TabIndex = 2;
            
            // lblPrescription
            this.lblPrescription.AutoSize = true;
            this.lblPrescription.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.lblPrescription.Location = new Point(480, 30);
            this.lblPrescription.Name = "lblPrescription";
            this.lblPrescription.Size = new Size(90, 17);
            this.lblPrescription.TabIndex = 3;
            this.lblPrescription.Text = "Prescription:";
            
            // cmbPrescription
            this.cmbPrescription.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbPrescription.Font = new Font("Segoe UI", 9.5F);
            this.cmbPrescription.FormattingEnabled = true;
            this.cmbPrescription.Location = new Point(580, 27);
            this.cmbPrescription.Name = "cmbPrescription";
            this.cmbPrescription.Size = new Size(310, 25);
            this.cmbPrescription.TabIndex = 4;
            
            // grpMedicines
            this.grpMedicines.BackColor = Color.White;
            this.grpMedicines.Controls.Add(this.lblFormulaSearch);
            this.grpMedicines.Controls.Add(this.txtFormulaSearch);
            this.grpMedicines.Controls.Add(this.lblMedicine);
            this.grpMedicines.Controls.Add(this.cmbMedicine);
            this.grpMedicines.Controls.Add(this.lblQuantity);
            this.grpMedicines.Controls.Add(this.numQuantity);
            this.grpMedicines.Controls.Add(this.lblSellingPrice);
            this.grpMedicines.Controls.Add(this.numSellingPrice);
            this.grpMedicines.Controls.Add(this.btnAddToCart);
            this.grpMedicines.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            this.grpMedicines.Location = new Point(20, 170);
            this.grpMedicines.Name = "grpMedicines";
            this.grpMedicines.Padding = new Padding(15);
            this.grpMedicines.Size = new Size(920, 145);
            this.grpMedicines.TabIndex = 2;
            this.grpMedicines.TabStop = false;
            this.grpMedicines.Text = "Add Medicines";
            
            // lblMedicine
            this.lblMedicine.AutoSize = true;
            this.lblMedicine.Location = new Point(20, 70);
            this.lblMedicine.Name = "lblMedicine";
            this.lblMedicine.Size = new Size(60, 15);
            this.lblMedicine.TabIndex = 1;
            this.lblMedicine.Text = "Medicine:";
            
            // cmbMedicine
            this.cmbMedicine.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cmbMedicine.AutoCompleteSource = AutoCompleteSource.ListItems;
            this.cmbMedicine.FormattingEnabled = true;
            this.cmbMedicine.Location = new Point(130, 67);
            this.cmbMedicine.Name = "cmbMedicine";
            this.cmbMedicine.Size = new Size(300, 23);
            this.cmbMedicine.TabIndex = 2;
            this.cmbMedicine.SelectedIndexChanged += new EventHandler(this.cmbMedicine_SelectedIndexChanged);
            
            // lblQuantity
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new Point(460, 70);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new Size(56, 15);
            this.lblQuantity.TabIndex = 3;
            this.lblQuantity.Text = "Quantity:";
            
            // numQuantity
            this.numQuantity.Location = new Point(560, 67);
            this.numQuantity.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            this.numQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new Size(80, 23);
            this.numQuantity.TabIndex = 4;
            this.numQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            
            // lblSellingPrice
            this.lblSellingPrice.AutoSize = true;
            this.lblSellingPrice.Location = new Point(670, 70);
            this.lblSellingPrice.Name = "lblSellingPrice";
            this.lblSellingPrice.Size = new Size(75, 15);
            this.lblSellingPrice.TabIndex = 5;
            this.lblSellingPrice.Text = "Selling Price:";
            
            // numSellingPrice
            this.numSellingPrice.DecimalPlaces = 2;
            this.numSellingPrice.Location = new Point(760, 67);
            this.numSellingPrice.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.numSellingPrice.Name = "numSellingPrice";
            this.numSellingPrice.Size = new Size(150, 23);
            this.numSellingPrice.TabIndex = 6;
            
            // btnAddToCart
            this.btnAddToCart.BackColor = Color.FromArgb(41, 128, 185);
            this.btnAddToCart.FlatStyle = FlatStyle.Flat;
            this.btnAddToCart.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnAddToCart.ForeColor = Color.White;
            this.btnAddToCart.Location = new Point(340, 100);
            this.btnAddToCart.Name = "btnAddToCart";
            this.btnAddToCart.Size = new Size(180, 30);
            this.btnAddToCart.TabIndex = 7;
            this.btnAddToCart.Text = "Add to Cart";
            this.btnAddToCart.UseVisualStyleBackColor = false;
            this.btnAddToCart.Click += new EventHandler(this.btnAddToCart_Click);
            
            // dgvCart
            this.dgvCart.AllowUserToAddRows = false;
            this.dgvCart.AllowUserToDeleteRows = false;
            this.dgvCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCart.BackgroundColor = Color.White;
            this.dgvCart.BorderStyle = BorderStyle.None;
            this.dgvCart.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 152, 219);
            this.dgvCart.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.dgvCart.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgvCart.ColumnHeadersHeight = 35;
            this.dgvCart.DefaultCellStyle.SelectionBackColor = Color.FromArgb(41, 128, 185);
            this.dgvCart.EnableHeadersVisualStyles = false;
            this.dgvCart.Location = new Point(20, 325);
            this.dgvCart.Name = "dgvCart";
            this.dgvCart.ReadOnly = true;
            this.dgvCart.RowHeadersVisible = false;
            this.dgvCart.RowTemplate.Height = 30;
            this.dgvCart.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvCart.Size = new Size(920, 150);
            this.dgvCart.TabIndex = 3;
            
            // lblTotal
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            this.lblTotal.Location = new Point(710, 485);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new Size(60, 25);
            this.lblTotal.TabIndex = 4;
            this.lblTotal.Text = "Total:";
            
            // lblTotalAmount
            this.lblTotalAmount.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            this.lblTotalAmount.ForeColor = Color.FromArgb(39, 174, 96);
            this.lblTotalAmount.Location = new Point(775, 485);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new Size(165, 25);
            this.lblTotalAmount.TabIndex = 5;
            this.lblTotalAmount.Text = "$0.00";
            this.lblTotalAmount.TextAlign = ContentAlignment.MiddleRight;
            
            // btnRemoveItem
            this.btnRemoveItem.BackColor = Color.FromArgb(231, 76, 60);
            this.btnRemoveItem.FlatAppearance.BorderSize = 0;
            this.btnRemoveItem.FlatStyle = FlatStyle.Flat;
            this.btnRemoveItem.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnRemoveItem.ForeColor = Color.White;
            this.btnRemoveItem.Location = new Point(20, 520);
            this.btnRemoveItem.Name = "btnRemoveItem";
            this.btnRemoveItem.Size = new Size(140, 40);
            this.btnRemoveItem.TabIndex = 6;
            this.btnRemoveItem.Text = "Remove Item";
            this.btnRemoveItem.UseVisualStyleBackColor = false;
            this.btnRemoveItem.Click += new EventHandler(this.btnRemoveItem_Click);
            
            // btnCompleteSale
            this.btnCompleteSale.BackColor = Color.FromArgb(39, 174, 96);
            this.btnCompleteSale.FlatAppearance.BorderSize = 0;
            this.btnCompleteSale.FlatStyle = FlatStyle.Flat;
            this.btnCompleteSale.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnCompleteSale.ForeColor = Color.White;
            this.btnCompleteSale.Location = new Point(680, 520);
            this.btnCompleteSale.Name = "btnCompleteSale";
            this.btnCompleteSale.Size = new Size(120, 40);
            this.btnCompleteSale.TabIndex = 7;
            this.btnCompleteSale.Text = "Complete Sale";
            this.btnCompleteSale.UseVisualStyleBackColor = false;
            this.btnCompleteSale.Click += new EventHandler(this.btnCompleteSale_Click);
            
            // btnClear
            this.btnClear.BackColor = Color.FromArgb(149, 165, 166);
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = FlatStyle.Flat;
            this.btnClear.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnClear.ForeColor = Color.White;
            this.btnClear.Location = new Point(810, 520);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new Size(130, 40);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new EventHandler(this.btnClear_Click);
            
            // dgvSales
            this.dgvSales.AllowUserToAddRows = false;
            this.dgvSales.AllowUserToDeleteRows = false;
            this.dgvSales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSales.BackgroundColor = Color.White;
            this.dgvSales.BorderStyle = BorderStyle.None;
            this.dgvSales.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94);
            this.dgvSales.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.dgvSales.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgvSales.ColumnHeadersDefaultCellStyle.Padding = new Padding(5);
            this.dgvSales.ColumnHeadersHeight = 40;
            this.dgvSales.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            this.dgvSales.DefaultCellStyle.SelectionBackColor = Color.FromArgb(41, 128, 185);
            this.dgvSales.DefaultCellStyle.SelectionForeColor = Color.White;
            this.dgvSales.EnableHeadersVisualStyles = false;
            this.dgvSales.Location = new Point(20, 615);
            this.dgvSales.Name = "dgvSales";
            this.dgvSales.ReadOnly = true;
            this.dgvSales.RowHeadersVisible = false;
            this.dgvSales.RowTemplate.Height = 32;
            this.dgvSales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvSales.Size = new Size(920, 200);
            this.dgvSales.TabIndex = 9;
            this.dgvSales.CellDoubleClick += new DataGridViewCellEventHandler(this.dgvSales_CellDoubleClick);
            
            // SaleManagementControl
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = Color.FromArgb(236, 240, 241);
            this.Controls.Add(this.dgvSales);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnCompleteSale);
            this.Controls.Add(this.btnRemoveItem);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.dgvCart);
            this.Controls.Add(this.grpMedicines);
            this.Controls.Add(this.grpCustomer);
            this.Controls.Add(this.lblTitle);
            this.Name = "SaleManagementControl";
            this.Size = new Size(960, 830);
            this.Load += new EventHandler(this.SaleManagementControl_Load);
            
            this.grpCustomer.ResumeLayout(false);
            this.grpCustomer.PerformLayout();
            this.grpMedicines.ResumeLayout(false);
            this.grpMedicines.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSellingPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSales)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void SaleManagementControl_Load(object? sender, EventArgs e)
        {
            LoadCustomers();
            LoadMedicines();
            LoadPrescriptions();
            LoadSales();
            SetupCartGrid();
        }

        private void SetupCartGrid()
        {
            dgvCart.Columns.Clear();
            dgvCart.Columns.Add("MedicineName", "Medicine");
            dgvCart.Columns.Add("BatchNumber", "Batch");
            dgvCart.Columns.Add("Quantity", "Quantity");
            dgvCart.Columns.Add("Price", "Unit Price");
            dgvCart.Columns.Add("Total", "Total");
        }

        private void LoadCustomers()
        {
            var customers = customerDAL.GetAllCustomers();
            cmbCustomer.DataSource = customers;
            cmbCustomer.DisplayMember = "CustomerName";
            cmbCustomer.ValueMember = "CustomerID";
        }

        private void LoadMedicines()
        {
            var medicines = medicineDAL.GetMedicinesWithStock();
            allMedicines = medicines.Where(m => m.TotalStock > 0).ToList();
            FilterMedicines();
        }
        
        private void FilterMedicines()
        {
            var filtered = allMedicines;
            
            if (!string.IsNullOrWhiteSpace(txtFormulaSearch.Text))
            {
                string searchText = txtFormulaSearch.Text.ToLower();
                filtered = allMedicines.Where(m => m.FormulaName.ToLower().Contains(searchText)).ToList();
            }
            
            cmbMedicine.DataSource = null;
            cmbMedicine.DataSource = filtered;
            cmbMedicine.DisplayMember = "DisplayName";
            cmbMedicine.ValueMember = "MedicineID";
        }
        
        private void txtFormulaSearch_TextChanged(object? sender, EventArgs e)
        {
            FilterMedicines();
        }

        private void LoadPrescriptions()
        {
            var prescriptions = prescriptionDAL.GetAllPrescriptions();
            cmbPrescription.DataSource = prescriptions;
            cmbPrescription.DisplayMember = "PrescriptionDisplay";
            cmbPrescription.ValueMember = "PrescriptionID";
        }

        private void LoadSales()
        {
            var sales = saleDAL.GetAllSales();
            dgvSales.DataSource = sales;
            
            if (dgvSales.Columns["SaleID"] != null)
                dgvSales.Columns["SaleID"]!.Visible = false;
            if (dgvSales.Columns["UserID"] != null)
                dgvSales.Columns["UserID"]!.Visible = false;
            if (dgvSales.Columns["CustomerID"] != null)
                dgvSales.Columns["CustomerID"]!.Visible = false;
            if (dgvSales.Columns["PrescriptionID"] != null)
                dgvSales.Columns["PrescriptionID"]!.Visible = false;
        }

        private void chkWalkIn_CheckedChanged(object? sender, EventArgs e)
        {
            cmbCustomer.Enabled = !chkWalkIn.Checked;
            cmbPrescription.Enabled = !chkWalkIn.Checked;
        }

        private void cmbMedicine_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cmbMedicine.SelectedValue != null && cmbMedicine.SelectedValue is int medicineId)
            {
                var batches = medicineBatchDAL.GetMedicineBatchesByMedicine(medicineId);
                var availableBatch = batches.FirstOrDefault(b => b.QuantityInStock > 0);
                
                if (availableBatch != null)
                {
                    numSellingPrice.Value = availableBatch.PurchasePrice * 1.3m; // 30% markup
                    numQuantity.Maximum = availableBatch.QuantityInStock;
                }
            }
        }

        private void btnAddToCart_Click(object? sender, EventArgs e)
        {
            if (cmbMedicine.SelectedValue == null)
            {
                MessageBox.Show("Please select a medicine.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int medicineId = (int)cmbMedicine.SelectedValue;
            
            // Check if medicine requires prescription
            var selectedMedicine = allMedicines.FirstOrDefault(m => m.MedicineID == medicineId);
            if (selectedMedicine != null && selectedMedicine.IsPrescriptionRequired)
            {
                // For walk-in customers or customers without prescription
                if (chkWalkIn.Checked || cmbPrescription.SelectedValue == null)
                {
                    MessageBox.Show(
                        $"The medicine '{selectedMedicine.Name}' requires a prescription.\n\n" +
                        "Please select a customer with a valid prescription to proceed.",
                        "Prescription Required",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }
                
                // Validate that medicine is in the prescription
                int prescriptionID = Convert.ToInt32(cmbPrescription.SelectedValue);
                bool isInPrescription = prescriptionDetailDAL.ValidatePrescriptionMedicine(prescriptionID, medicineId);
                
                if (!isInPrescription)
                {
                    MessageBox.Show(
                        $"The medicine '{selectedMedicine.Name}' is not included in the selected prescription.\n\n" +
                        "Only medicines prescribed by the doctor can be sold for this prescription.",
                        "Medicine Not in Prescription",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }
            }
            
            var batches = medicineBatchDAL.GetMedicineBatchesByMedicine(medicineId);
            var availableBatch = batches.FirstOrDefault(b => b.QuantityInStock > 0);

            if (availableBatch == null)
            {
                MessageBox.Show("No stock available for this medicine.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (numQuantity.Value > availableBatch.QuantityInStock)
            {
                MessageBox.Show($"Only {availableBatch.QuantityInStock} units available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var saleItem = new SaleItem
            {
                MedicineID = availableBatch.MedicineID,
                BatchID = availableBatch.BatchID,
                MedicineName = availableBatch.MedicineName,
                BatchNumber = availableBatch.BatchNumber,
                Quantity = (int)numQuantity.Value,
                SellingPrice = numSellingPrice.Value
            };

            saleItems.Add(saleItem);
            RefreshCart();
        }

        private void RefreshCart()
        {
            dgvCart.Rows.Clear();
            decimal total = 0;

            foreach (var item in saleItems)
            {
                decimal itemTotal = item.Quantity * item.SellingPrice;
                total += itemTotal;
                dgvCart.Rows.Add(item.MedicineName, item.BatchNumber, item.Quantity, 
                    item.SellingPrice.ToString("C"), itemTotal.ToString("C"));
            }

            lblTotalAmount.Text = total.ToString("C");
        }

        private void btnRemoveItem_Click(object? sender, EventArgs e)
        {
            if (dgvCart.SelectedRows.Count > 0)
            {
                int index = dgvCart.SelectedRows[0].Index;
                saleItems.RemoveAt(index);
                RefreshCart();
            }
        }

        private void btnCompleteSale_Click(object? sender, EventArgs e)
        {
            if (saleItems.Count == 0)
            {
                MessageBox.Show("Please add items to cart.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int? custId = chkWalkIn.Checked ? null : (cmbCustomer.SelectedValue != null ? (int?)cmbCustomer.SelectedValue : null);
                int? prescId = chkWalkIn.Checked ? null : (cmbPrescription.SelectedValue != null ? (int?)cmbPrescription.SelectedValue : null);
                
                decimal totalAmount = saleItems.Sum(item => item.Quantity * item.SellingPrice);

                // Create sale first
                Sale sale = new Sale
                {
                    UserID = currentUserID,
                    CustomerID = custId,
                    PrescriptionID = prescId,
                    SaleDate = DateTime.Now,
                    TotalAmount = totalAmount
                };

                int saleId = saleDAL.AddSale(sale);

                if (saleId > 0)
                {
                    foreach (var item in saleItems)
                    {
                        // FIFO procedure will automatically handle batch selection and stock updates
                        saleDetailDAL.AddSaleDetail(saleId, item.MedicineID, item.Quantity, item.SellingPrice);
                    }

                    // Now show invoice dialog with actual SaleID
                    string customerName = chkWalkIn.Checked ? "Walk-in Customer" : 
                        (cmbCustomer.SelectedItem != null ? cmbCustomer.Text : "Walk-in Customer");
                    
                    var invoiceItems = saleItems.Select(item => new SaleItemInfo
                    {
                        MedicineID = item.MedicineID,
                        MedicineName = item.MedicineName,
                        Quantity = item.Quantity,
                        SellingPrice = item.SellingPrice
                    }).ToList();
                    
                    using (var invoiceForm = new SaleInvoiceForm(saleId, customerName, invoiceItems))
                    {
                        invoiceForm.ShowDialog();
                    }

                    MessageBox.Show($"Sale completed successfully!\nInvoice No: INV-{saleId:D6}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    LoadSales();
                    LoadMedicines();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object? sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            saleItems.Clear();
            RefreshCart();
            chkWalkIn.Checked = false;
            if (cmbCustomer.Items.Count > 0)
                cmbCustomer.SelectedIndex = 0;
            if (cmbMedicine.Items.Count > 0)
                cmbMedicine.SelectedIndex = 0;
            if (cmbPrescription.Items.Count > 0)
                cmbPrescription.SelectedIndex = 0;
            numQuantity.Value = 1;
            numSellingPrice.Value = 0;
        }

        private void dgvSales_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSales.Rows[e.RowIndex];
                int saleID = Convert.ToInt32(row.Cells["SaleID"].Value);
                
                // Get the sale object
                Sale sale = new Sale
                {
                    SaleID = saleID,
                    SaleDate = Convert.ToDateTime(row.Cells["SaleDate"].Value),
                    CustomerName = row.Cells["CustomerName"].Value?.ToString() ?? "Walk-in Customer",
                    UserName = row.Cells["UserName"].Value?.ToString() ?? "",
                    TotalAmount = Convert.ToDecimal(row.Cells["TotalAmount"].Value)
                };
                
                // Open sale details form
                SaleDetailsForm detailsForm = new SaleDetailsForm(saleID, sale);
                detailsForm.ShowDialog();
            }
        }

        private class SaleItem
        {
            public int MedicineID { get; set; }
            public int BatchID { get; set; }
            public string MedicineName { get; set; } = "";
            public string BatchNumber { get; set; } = "";
            public int Quantity { get; set; }
            public decimal SellingPrice { get; set; }
        }
    }
}
