using System;
using System.Drawing;
using System.Windows.Forms;
using PharmacyWinFormsApp.DAL;
using PharmacyWinFormsApp.Models;

namespace PharmacyWinFormsApp.Forms.Purchases
{
    public partial class PurchaseManagementControl : UserControl
    {
        private int currentUserID;
        private readonly PurchaseDAL purchaseDAL;
        private readonly MedicineDAL medicineDAL;
        private readonly SupplierDAL supplierDAL;
        private readonly MedicineBatchDAL medicineBatchDAL;

        private Label lblTitle = null!;
        private GroupBox groupBox1 = null!;
        private ComboBox cmbSupplier = null!;
        private ComboBox cmbMedicine = null!;
        private TextBox txtBatchNumber = null!;
        private DateTimePicker dtpExpiryDate = null!;
        private NumericUpDown numQuantity = null!;
        private NumericUpDown numPurchasePrice = null!;
        private NumericUpDown numSellingPrice = null!;
        private Button btnAddPurchase = null!;
        private Button btnClear = null!;
        private DataGridView dgvPurchases = null!;
        private Label lblSupplier = null!;
        private Label lblMedicine = null!;
        private Label lblBatchNumber = null!;
        private Label lblExpiryDate = null!;
        private Label lblQuantity = null!;
        private Label lblPurchasePrice = null!;
        private Label lblSellingPrice = null!;

        public PurchaseManagementControl(int userID)
        {
            purchaseDAL = new PurchaseDAL();
            medicineDAL = new MedicineDAL();
            supplierDAL = new SupplierDAL();
            medicineBatchDAL = new MedicineBatchDAL();
            currentUserID = userID;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.lblTitle = new Label();
            this.groupBox1 = new GroupBox();
            this.cmbSupplier = new ComboBox();
            this.cmbMedicine = new ComboBox();
            this.txtBatchNumber = new TextBox();
            this.dtpExpiryDate = new DateTimePicker();
            this.numQuantity = new NumericUpDown();
            this.numPurchasePrice = new NumericUpDown();
            this.numSellingPrice = new NumericUpDown();
            this.btnAddPurchase = new Button();
            this.btnClear = new Button();
            this.dgvPurchases = new DataGridView();
            this.lblSupplier = new Label();
            this.lblMedicine = new Label();
            this.lblBatchNumber = new Label();
            this.lblExpiryDate = new Label();
            this.lblQuantity = new Label();
            this.lblPurchasePrice = new Label();
            this.lblSellingPrice = new Label();
            
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPurchasePrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSellingPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchases)).BeginInit();
            this.SuspendLayout();
            
            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTitle.Location = new Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(250, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Purchase Management";
            
            // groupBox1
            this.groupBox1.Controls.Add(this.lblSupplier);
            this.groupBox1.Controls.Add(this.cmbSupplier);
            this.groupBox1.Controls.Add(this.lblMedicine);
            this.groupBox1.Controls.Add(this.cmbMedicine);
            this.groupBox1.Controls.Add(this.lblBatchNumber);
            this.groupBox1.Controls.Add(this.txtBatchNumber);
            this.groupBox1.Controls.Add(this.lblExpiryDate);
            this.groupBox1.Controls.Add(this.dtpExpiryDate);
            this.groupBox1.Controls.Add(this.lblQuantity);
            this.groupBox1.Controls.Add(this.numQuantity);
            this.groupBox1.Controls.Add(this.lblPurchasePrice);
            this.groupBox1.Controls.Add(this.numPurchasePrice);
            this.groupBox1.Controls.Add(this.lblSellingPrice);
            this.groupBox1.Controls.Add(this.numSellingPrice);
            this.groupBox1.Controls.Add(this.btnAddPurchase);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Location = new Point(20, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(860, 250);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "New Purchase Entry";
            
            // lblSupplier
            this.lblSupplier.AutoSize = true;
            this.lblSupplier.Location = new Point(20, 35);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new Size(55, 15);
            this.lblSupplier.TabIndex = 0;
            this.lblSupplier.Text = "Supplier:";
            
            // cmbSupplier
            this.cmbSupplier.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbSupplier.FormattingEnabled = true;
            this.cmbSupplier.Location = new Point(130, 32);
            this.cmbSupplier.Name = "cmbSupplier";
            this.cmbSupplier.Size = new Size(300, 23);
            this.cmbSupplier.TabIndex = 1;
            
            // lblMedicine
            this.lblMedicine.AutoSize = true;
            this.lblMedicine.Location = new Point(20, 75);
            this.lblMedicine.Name = "lblMedicine";
            this.lblMedicine.Size = new Size(60, 15);
            this.lblMedicine.TabIndex = 2;
            this.lblMedicine.Text = "Medicine:";
            
            // cmbMedicine
            this.cmbMedicine.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbMedicine.FormattingEnabled = true;
            this.cmbMedicine.Location = new Point(130, 72);
            this.cmbMedicine.Name = "cmbMedicine";
            this.cmbMedicine.Size = new Size(300, 23);
            this.cmbMedicine.TabIndex = 3;
            
            // lblBatchNumber
            this.lblBatchNumber.AutoSize = true;
            this.lblBatchNumber.Location = new Point(20, 115);
            this.lblBatchNumber.Name = "lblBatchNumber";
            this.lblBatchNumber.Size = new Size(90, 15);
            this.lblBatchNumber.TabIndex = 4;
            this.lblBatchNumber.Text = "Batch Number:";
            
            // txtBatchNumber
            this.txtBatchNumber.Location = new Point(130, 112);
            this.txtBatchNumber.Name = "txtBatchNumber";
            this.txtBatchNumber.Size = new Size(200, 23);
            this.txtBatchNumber.TabIndex = 5;
            this.txtBatchNumber.ReadOnly = true;
            this.txtBatchNumber.BackColor = Color.LightGray;
            this.txtBatchNumber.Text = "(Auto-generated)";
            
            // lblExpiryDate
            this.lblExpiryDate.AutoSize = true;
            this.lblExpiryDate.Location = new Point(20, 155);
            this.lblExpiryDate.Name = "lblExpiryDate";
            this.lblExpiryDate.Size = new Size(73, 15);
            this.lblExpiryDate.TabIndex = 6;
            this.lblExpiryDate.Text = "Expiry Date:";
            
            // dtpExpiryDate
            this.dtpExpiryDate.Format = DateTimePickerFormat.Short;
            this.dtpExpiryDate.Location = new Point(130, 152);
            this.dtpExpiryDate.Name = "dtpExpiryDate";
            this.dtpExpiryDate.Size = new Size(200, 23);
            this.dtpExpiryDate.TabIndex = 7;
            
            // lblQuantity
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new Point(460, 35);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new Size(56, 15);
            this.lblQuantity.TabIndex = 8;
            this.lblQuantity.Text = "Quantity:";
            
            // numQuantity
            this.numQuantity.Location = new Point(580, 32);
            this.numQuantity.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            this.numQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new Size(150, 23);
            this.numQuantity.TabIndex = 9;
            this.numQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            
            // lblPurchasePrice
            this.lblPurchasePrice.AutoSize = true;
            this.lblPurchasePrice.Location = new Point(460, 75);
            this.lblPurchasePrice.Name = "lblPurchasePrice";
            this.lblPurchasePrice.Size = new Size(90, 15);
            this.lblPurchasePrice.TabIndex = 10;
            this.lblPurchasePrice.Text = "Purchase Price:";
            
            // numPurchasePrice
            this.numPurchasePrice.DecimalPlaces = 2;
            this.numPurchasePrice.Location = new Point(580, 72);
            this.numPurchasePrice.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.numPurchasePrice.Name = "numPurchasePrice";
            this.numPurchasePrice.Size = new Size(150, 23);
            this.numPurchasePrice.TabIndex = 11;
            
            // lblSellingPrice
            this.lblSellingPrice.AutoSize = true;
            this.lblSellingPrice.Location = new Point(460, 115);
            this.lblSellingPrice.Name = "lblSellingPrice";
            this.lblSellingPrice.Size = new Size(78, 15);
            this.lblSellingPrice.TabIndex = 12;
            this.lblSellingPrice.Text = "Selling Price:";
            
            // numSellingPrice
            this.numSellingPrice.DecimalPlaces = 2;
            this.numSellingPrice.Location = new Point(580, 112);
            this.numSellingPrice.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.numSellingPrice.Name = "numSellingPrice";
            this.numSellingPrice.Size = new Size(150, 23);
            this.numSellingPrice.TabIndex = 13;
            
            // btnAddPurchase
            this.btnAddPurchase.BackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnAddPurchase.FlatStyle = FlatStyle.Flat;
            this.btnAddPurchase.ForeColor = Color.White;
            this.btnAddPurchase.Location = new Point(460, 195);
            this.btnAddPurchase.Name = "btnAddPurchase";
            this.btnAddPurchase.Size = new Size(130, 35);
            this.btnAddPurchase.TabIndex = 14;
            this.btnAddPurchase.Text = "Add Purchase";
            this.btnAddPurchase.UseVisualStyleBackColor = false;
            this.btnAddPurchase.Click += new EventHandler(this.btnAddPurchase_Click);
            
            // btnClear
            this.btnClear.BackColor = Color.Gray;
            this.btnClear.FlatStyle = FlatStyle.Flat;
            this.btnClear.ForeColor = Color.White;
            this.btnClear.Location = new Point(600, 195);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new Size(130, 35);
            this.btnClear.TabIndex = 15;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new EventHandler(this.btnClear_Click);
            
            // dgvPurchases
            this.dgvPurchases.AllowUserToAddRows = false;
            this.dgvPurchases.AllowUserToDeleteRows = false;
            this.dgvPurchases.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPurchases.BackgroundColor = Color.White;
            this.dgvPurchases.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPurchases.Location = new Point(20, 340);
            this.dgvPurchases.Name = "dgvPurchases";
            this.dgvPurchases.ReadOnly = true;
            this.dgvPurchases.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvPurchases.Size = new Size(860, 240);
            this.dgvPurchases.TabIndex = 2;
            this.dgvPurchases.DoubleClick += new EventHandler(this.dgvPurchases_DoubleClick);
            
            // PurchaseManagementControl
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            this.Controls.Add(this.dgvPurchases);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblTitle);
            this.Name = "PurchaseManagementControl";
            this.Size = new Size(900, 600);
            this.Load += new EventHandler(this.PurchaseManagementControl_Load);
            
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPurchasePrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSellingPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchases)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void PurchaseManagementControl_Load(object? sender, EventArgs e)
        {
            LoadSuppliers();
            LoadMedicines();
            LoadPurchases();
            dtpExpiryDate.MinDate = DateTime.Today.AddDays(1);
            dtpExpiryDate.Value = DateTime.Today.AddMonths(12);
        }

        private void LoadSuppliers()
        {
            var suppliers = supplierDAL.GetAllSuppliers();
            cmbSupplier.DataSource = suppliers;
            cmbSupplier.DisplayMember = "SupplierName";
            cmbSupplier.ValueMember = "SupplierID";
        }

        private void LoadMedicines()
        {
            var medicines = medicineDAL.GetAllMedicines();
            cmbMedicine.DataSource = medicines;
            cmbMedicine.DisplayMember = "DisplayName";
            cmbMedicine.ValueMember = "MedicineID";
        }

        private void LoadPurchases()
        {
            var purchases = purchaseDAL.GetAllPurchases();
            dgvPurchases.DataSource = purchases;
            
            if (dgvPurchases.Columns["PurchaseID"] != null)
                dgvPurchases.Columns["PurchaseID"]!.Visible = false;
            if (dgvPurchases.Columns["UserID"] != null)
                dgvPurchases.Columns["UserID"]!.Visible = false;
            if (dgvPurchases.Columns["SupplierID"] != null)
                dgvPurchases.Columns["SupplierID"]!.Visible = false;
        }

        private void btnAddPurchase_Click(object? sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            try
            {
                Purchase purchase = new Purchase
                {
                    SupplierID = cmbSupplier.SelectedValue != null ? (int)cmbSupplier.SelectedValue : 0,
                    UserID = currentUserID,
                    PurchaseDate = DateTime.Now,
                    TotalAmount = numPurchasePrice.Value * numQuantity.Value
                };

                int purchaseID = purchaseDAL.AddPurchase(purchase);
                
                if (purchaseID > 0)
                {
                    MedicineBatch batch = new MedicineBatch
                    {
                        MedicineID = cmbMedicine.SelectedValue != null ? (int)cmbMedicine.SelectedValue : 0,
                        SupplierID = cmbSupplier.SelectedValue != null ? (int)cmbSupplier.SelectedValue : 0,
                        PurchaseID = purchaseID,
                        ExpiryDate = dtpExpiryDate.Value,
                        PurchasePrice = numPurchasePrice.Value,
                        QuantityInStock = (int)numQuantity.Value
                    };

                    int batchID = medicineBatchDAL.AddMedicineBatch(batch);
                    if (batchID > 0)
                    {
                        MessageBox.Show($"Purchase recorded successfully!\n\nBatch ID: {batchID}\nBatch Number: {batchID}", "Success", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearForm();
                        LoadPurchases();
                    }
                    else
                    {
                        MessageBox.Show("Failed to add medicine batch.", "Error", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Failed to record purchase.", "Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object? sender, EventArgs e)
        {
            ClearForm();
        }

        private bool ValidateForm()
        {
            if (cmbSupplier.SelectedValue == null)
            {
                MessageBox.Show("Please select a supplier.", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbMedicine.SelectedValue == null)
            {
                MessageBox.Show("Please select a medicine.", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (numQuantity.Value <= 0)
            {
                MessageBox.Show("Quantity must be greater than zero.", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (numPurchasePrice.Value <= 0)
            {
                MessageBox.Show("Purchase price must be greater than zero.", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (numSellingPrice.Value <= 0)
            {
                MessageBox.Show("Selling price must be greater than zero.", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (numSellingPrice.Value <= numPurchasePrice.Value)
            {
                MessageBox.Show("Selling price must be greater than purchase price.", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numSellingPrice.Focus();
                return false;
            }

            if (dtpExpiryDate.Value <= DateTime.Today)
            {
                MessageBox.Show("Expiry date must be in the future.", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void ClearForm()
        {
            if (cmbSupplier.Items.Count > 0)
                cmbSupplier.SelectedIndex = 0;
            if (cmbMedicine.Items.Count > 0)
                cmbMedicine.SelectedIndex = 0;
            txtBatchNumber.Clear();
            dtpExpiryDate.Value = DateTime.Today.AddMonths(12);
            numQuantity.Value = 1;
            numPurchasePrice.Value = 0;
            numSellingPrice.Value = 0;
        }

        private void dgvPurchases_DoubleClick(object? sender, EventArgs e)
        {
            if (dgvPurchases.SelectedRows.Count > 0)
            {
                int purchaseID = Convert.ToInt32(dgvPurchases.SelectedRows[0].Cells["PurchaseID"].Value);
                PurchaseDetailsForm detailsForm = new PurchaseDetailsForm(purchaseID);
                detailsForm.ShowDialog();
            }
        }
    }
}
