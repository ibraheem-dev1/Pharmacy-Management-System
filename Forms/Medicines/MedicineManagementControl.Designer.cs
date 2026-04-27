namespace PharmacyWinFormsApp.Forms.Medicines
{
    partial class MedicineManagementControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.groupBoxMedicineForm = new System.Windows.Forms.GroupBox();
            this.chkIsPrescriptionRequired = new System.Windows.Forms.CheckBox();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.cmbFormula = new System.Windows.Forms.ComboBox();
            this.lblFormula = new System.Windows.Forms.Label();
            this.btnAddFormula = new System.Windows.Forms.Button();
            this.cmbManufacturer = new System.Windows.Forms.ComboBox();
            this.lblManufacturer = new System.Windows.Forms.Label();
            this.btnAddManufacturer = new System.Windows.Forms.Button();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.btnAddCategory = new System.Windows.Forms.Button();
            this.numMinStock = new System.Windows.Forms.NumericUpDown();
            this.lblMinStock = new System.Windows.Forms.Label();
            this.numStrength = new System.Windows.Forms.NumericUpDown();
            this.lblStrength = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDeactivate = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dgvMedicines = new System.Windows.Forms.DataGridView();
            this.mainLayout.SuspendLayout();
            this.searchPanel.SuspendLayout();
            this.groupBoxMedicineForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMinStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStrength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicines)).BeginInit();
            this.SuspendLayout();
            // 
            // mainLayout
            // 
            this.mainLayout.ColumnCount = 1;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.Controls.Add(this.lblTitle, 0, 0);
            this.mainLayout.Controls.Add(this.groupBoxMedicineForm, 0, 1);
            this.mainLayout.Controls.Add(this.searchPanel, 0, 2);
            this.mainLayout.Controls.Add(this.dgvMedicines, 0, 3);
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.Location = new System.Drawing.Point(0, 0);
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.Padding = new System.Windows.Forms.Padding(10);
            this.mainLayout.RowCount = 4;
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 240F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.Size = new System.Drawing.Size(1200, 800);
            this.mainLayout.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblTitle.Location = new System.Drawing.Point(13, 13);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.lblTitle.Size = new System.Drawing.Size(1174, 44);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "💊 Medicine Management";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // searchPanel
            // 
            this.searchPanel.Controls.Add(this.txtSearch);
            this.searchPanel.Controls.Add(this.lblSearch);
            this.searchPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchPanel.Location = new System.Drawing.Point(13, 303);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Padding = new System.Windows.Forms.Padding(5);
            this.searchPanel.Size = new System.Drawing.Size(1174, 44);
            this.searchPanel.TabIndex = 2;
            // 
            // lblSearch
            // 
            this.lblSearch.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSearch.Location = new System.Drawing.Point(5, 5);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(80, 35);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "🔍 Search:";
            this.lblSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSearch
            // 
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSearch.Location = new System.Drawing.Point(85, 5);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "Search by medicine name, category, manufacturer, or formula...";
            this.txtSearch.Size = new System.Drawing.Size(1084, 27);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // groupBoxMedicineForm
            // 
            this.groupBoxMedicineForm.Controls.Add(this.chkIsPrescriptionRequired);
            this.groupBoxMedicineForm.Controls.Add(this.chkIsActive);
            this.groupBoxMedicineForm.Controls.Add(this.cmbFormula);
            this.groupBoxMedicineForm.Controls.Add(this.lblFormula);
            this.groupBoxMedicineForm.Controls.Add(this.btnAddFormula);
            this.groupBoxMedicineForm.Controls.Add(this.cmbManufacturer);
            this.groupBoxMedicineForm.Controls.Add(this.lblManufacturer);
            this.groupBoxMedicineForm.Controls.Add(this.btnAddManufacturer);
            this.groupBoxMedicineForm.Controls.Add(this.cmbCategory);
            this.groupBoxMedicineForm.Controls.Add(this.lblCategory);
            this.groupBoxMedicineForm.Controls.Add(this.btnAddCategory);
            this.groupBoxMedicineForm.Controls.Add(this.numMinStock);
            this.groupBoxMedicineForm.Controls.Add(this.lblMinStock);
            this.groupBoxMedicineForm.Controls.Add(this.numStrength);
            this.groupBoxMedicineForm.Controls.Add(this.lblStrength);
            this.groupBoxMedicineForm.Controls.Add(this.txtName);
            this.groupBoxMedicineForm.Controls.Add(this.lblName);
            this.groupBoxMedicineForm.Controls.Add(this.btnClear);
            this.groupBoxMedicineForm.Controls.Add(this.btnDeactivate);
            this.groupBoxMedicineForm.Controls.Add(this.btnUpdate);
            this.groupBoxMedicineForm.Controls.Add(this.btnAdd);
            this.groupBoxMedicineForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxMedicineForm.BackColor = System.Drawing.Color.White;
            this.groupBoxMedicineForm.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBoxMedicineForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.groupBoxMedicineForm.Location = new System.Drawing.Point(13, 63);
            this.groupBoxMedicineForm.Name = "groupBoxMedicineForm";
            this.groupBoxMedicineForm.Padding = new System.Windows.Forms.Padding(20);
            this.groupBoxMedicineForm.Size = new System.Drawing.Size(1174, 234);
            this.groupBoxMedicineForm.TabIndex = 1;
            this.groupBoxMedicineForm.TabStop = false;
            this.groupBoxMedicineForm.Text = "Medicine Details";
            // 
            // chkIsPrescriptionRequired
            // 
            this.chkIsPrescriptionRequired.AutoSize = true;
            this.chkIsPrescriptionRequired.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chkIsPrescriptionRequired.Location = new System.Drawing.Point(640, 155);
            this.chkIsPrescriptionRequired.Name = "chkIsPrescriptionRequired";
            this.chkIsPrescriptionRequired.Size = new System.Drawing.Size(164, 21);
            this.chkIsPrescriptionRequired.TabIndex = 6;
            this.chkIsPrescriptionRequired.Text = "Prescription Required";
            this.chkIsPrescriptionRequired.UseVisualStyleBackColor = true;
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Checked = true;
            this.chkIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsActive.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chkIsActive.Location = new System.Drawing.Point(830, 155);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(79, 21);
            this.chkIsActive.TabIndex = 7;
            this.chkIsActive.Text = "Is Active";
            this.chkIsActive.UseVisualStyleBackColor = true;
            // 
            // cmbFormula
            // 
            this.cmbFormula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFormula.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbFormula.FormattingEnabled = true;
            this.cmbFormula.Location = new System.Drawing.Point(640, 110);
            this.cmbFormula.Name = "cmbFormula";
            this.cmbFormula.Size = new System.Drawing.Size(230, 25);
            this.cmbFormula.TabIndex = 5;
            // 
            // btnAddFormula
            // 
            this.btnAddFormula.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnAddFormula.FlatAppearance.BorderSize = 0;
            this.btnAddFormula.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddFormula.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAddFormula.ForeColor = System.Drawing.Color.White;
            this.btnAddFormula.Location = new System.Drawing.Point(875, 110);
            this.btnAddFormula.Name = "btnAddFormula";
            this.btnAddFormula.Size = new System.Drawing.Size(45, 25);
            this.btnAddFormula.TabIndex = 22;
            this.btnAddFormula.Text = "+ Add";
            this.btnAddFormula.UseVisualStyleBackColor = false;
            this.btnAddFormula.Click += new System.EventHandler(this.btnAddFormula_Click);
            // 
            // lblFormula
            // 
            this.lblFormula.AutoSize = true;
            this.lblFormula.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblFormula.Location = new System.Drawing.Point(640, 85);
            this.lblFormula.Name = "lblFormula";
            this.lblFormula.Size = new System.Drawing.Size(60, 17);
            this.lblFormula.TabIndex = 14;
            this.lblFormula.Text = "Formula:";
            // 
            // cmbManufacturer
            // 
            this.cmbManufacturer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbManufacturer.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbManufacturer.FormattingEnabled = true;
            this.cmbManufacturer.Location = new System.Drawing.Point(330, 110);
            this.cmbManufacturer.Name = "cmbManufacturer";
            this.cmbManufacturer.Size = new System.Drawing.Size(230, 25);
            this.cmbManufacturer.TabIndex = 4;
            // 
            // btnAddManufacturer
            // 
            this.btnAddManufacturer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnAddManufacturer.FlatAppearance.BorderSize = 0;
            this.btnAddManufacturer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddManufacturer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAddManufacturer.ForeColor = System.Drawing.Color.White;
            this.btnAddManufacturer.Location = new System.Drawing.Point(565, 110);
            this.btnAddManufacturer.Name = "btnAddManufacturer";
            this.btnAddManufacturer.Size = new System.Drawing.Size(45, 25);
            this.btnAddManufacturer.TabIndex = 21;
            this.btnAddManufacturer.Text = "+ Add";
            this.btnAddManufacturer.UseVisualStyleBackColor = false;
            this.btnAddManufacturer.Click += new System.EventHandler(this.btnAddManufacturer_Click);
            // 
            // lblManufacturer
            // 
            this.lblManufacturer.AutoSize = true;
            this.lblManufacturer.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblManufacturer.Location = new System.Drawing.Point(330, 85);
            this.lblManufacturer.Name = "lblManufacturer";
            this.lblManufacturer.Size = new System.Drawing.Size(97, 17);
            this.lblManufacturer.TabIndex = 12;
            this.lblManufacturer.Text = "Manufacturer:";
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(20, 110);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(230, 25);
            this.cmbCategory.TabIndex = 3;
            // 
            // btnAddCategory
            // 
            this.btnAddCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnAddCategory.FlatAppearance.BorderSize = 0;
            this.btnAddCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddCategory.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAddCategory.ForeColor = System.Drawing.Color.White;
            this.btnAddCategory.Location = new System.Drawing.Point(255, 110);
            this.btnAddCategory.Name = "btnAddCategory";
            this.btnAddCategory.Size = new System.Drawing.Size(45, 25);
            this.btnAddCategory.TabIndex = 20;
            this.btnAddCategory.Text = "+ Add";
            this.btnAddCategory.UseVisualStyleBackColor = false;
            this.btnAddCategory.Click += new System.EventHandler(this.btnAddCategory_Click);
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCategory.Location = new System.Drawing.Point(20, 85);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(68, 17);
            this.lblCategory.TabIndex = 10;
            this.lblCategory.Text = "Category:";
            // 
            // numMinStock
            // 
            this.numMinStock.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numMinStock.Location = new System.Drawing.Point(640, 45);
            this.numMinStock.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numMinStock.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMinStock.Name = "numMinStock";
            this.numMinStock.Size = new System.Drawing.Size(150, 25);
            this.numMinStock.TabIndex = 2;
            this.numMinStock.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // lblMinStock
            // 
            this.lblMinStock.AutoSize = true;
            this.lblMinStock.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblMinStock.Location = new System.Drawing.Point(640, 20);
            this.lblMinStock.Name = "lblMinStock";
            this.lblMinStock.Size = new System.Drawing.Size(145, 17);
            this.lblMinStock.TabIndex = 8;
            this.lblMinStock.Text = "Minimum Stock Level:";
            // 
            // numStrength
            // 
            this.numStrength.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numStrength.Location = new System.Drawing.Point(330, 45);
            this.numStrength.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numStrength.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numStrength.Name = "numStrength";
            this.numStrength.Size = new System.Drawing.Size(150, 25);
            this.numStrength.TabIndex = 1;
            this.numStrength.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblStrength
            // 
            this.lblStrength.AutoSize = true;
            this.lblStrength.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblStrength.Location = new System.Drawing.Point(330, 20);
            this.lblStrength.Name = "lblStrength";
            this.lblStrength.Size = new System.Drawing.Size(99, 17);
            this.lblStrength.TabIndex = 6;
            this.lblStrength.Text = "Strength (MG):";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtName.Location = new System.Drawing.Point(20, 45);
            this.txtName.Name = "txtName";
            this.txtName.PlaceholderText = "Enter medicine name";
            this.txtName.Size = new System.Drawing.Size(280, 25);
            this.txtName.TabIndex = 0;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblName.Location = new System.Drawing.Point(20, 20);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(109, 17);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "Medicine Name:";
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(420, 205);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(120, 45);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDeactivate
            // 
            this.btnDeactivate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnDeactivate.FlatAppearance.BorderSize = 0;
            this.btnDeactivate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeactivate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDeactivate.ForeColor = System.Drawing.Color.White;
            this.btnDeactivate.Location = new System.Drawing.Point(280, 205);
            this.btnDeactivate.Name = "btnDeactivate";
            this.btnDeactivate.Size = new System.Drawing.Size(120, 45);
            this.btnDeactivate.TabIndex = 9;
            this.btnDeactivate.Text = "Deactivate";
            this.btnDeactivate.UseVisualStyleBackColor = false;
            this.btnDeactivate.Click += new System.EventHandler(this.btnDeactivate_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(140, 205);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(120, 45);
            this.btnUpdate.TabIndex = 8;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(20, 205);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 45);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dgvMedicines
            // 
            this.dgvMedicines.AllowUserToAddRows = false;
            this.dgvMedicines.AllowUserToDeleteRows = false;
            this.dgvMedicines.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvMedicines.BackgroundColor = System.Drawing.Color.White;
            this.dgvMedicines.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMedicines.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.dgvMedicines.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.dgvMedicines.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvMedicines.ColumnHeadersDefaultCellStyle.Padding = new System.Windows.Forms.Padding(5);
            this.dgvMedicines.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.dgvMedicines.ColumnHeadersHeight = 40;
            this.dgvMedicines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvMedicines.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dgvMedicines.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.dgvMedicines.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvMedicines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMedicines.EnableHeadersVisualStyles = false;
            this.dgvMedicines.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(195)))), ((int)(((byte)(199)))));
            this.dgvMedicines.Location = new System.Drawing.Point(13, 353);
            this.dgvMedicines.Name = "dgvMedicines";
            this.dgvMedicines.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.dgvMedicines.ReadOnly = true;
            this.dgvMedicines.RowHeadersVisible = false;
            this.dgvMedicines.RowHeadersWidth = 51;
            this.dgvMedicines.RowTemplate.Height = 32;
            this.dgvMedicines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMedicines.Size = new System.Drawing.Size(1174, 424);
            this.dgvMedicines.TabIndex = 3;
            this.dgvMedicines.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMedicines_CellClick);
            // 
            // MedicineManagementControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.Controls.Add(this.mainLayout);
            this.Name = "MedicineManagementControl";
            this.Size = new System.Drawing.Size(1200, 800);
            this.Load += new System.EventHandler(this.MedicineManagementControl_Load);
            this.mainLayout.ResumeLayout(false);
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            this.groupBoxMedicineForm.ResumeLayout(false);
            this.groupBoxMedicineForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMinStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStrength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicines)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainLayout;
        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox groupBoxMedicineForm;
        private System.Windows.Forms.DataGridView dgvMedicines;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDeactivate;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblStrength;
        private System.Windows.Forms.NumericUpDown numStrength;
        private System.Windows.Forms.NumericUpDown numMinStock;
        private System.Windows.Forms.Label lblMinStock;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbManufacturer;
        private System.Windows.Forms.Label lblManufacturer;
        private System.Windows.Forms.ComboBox cmbFormula;
        private System.Windows.Forms.Label lblFormula;
        private System.Windows.Forms.CheckBox chkIsPrescriptionRequired;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.Button btnAddCategory;
        private System.Windows.Forms.Button btnAddManufacturer;
        private System.Windows.Forms.Button btnAddFormula;
    }
}