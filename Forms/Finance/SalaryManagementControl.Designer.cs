namespace PharmacyWinFormsApp.Forms.Finance
{
    partial class SalaryManagementControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelFilters;
        private System.Windows.Forms.Label lblFilterMonth;
        private System.Windows.Forms.ComboBox cmbMonth;
        private System.Windows.Forms.Label lblFilterYear;
        private System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.Label lblFilterUser;
        private System.Windows.Forms.ComboBox cmbUser;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dgvSalaries;
        private System.Windows.Forms.Panel panelTotals;
        private System.Windows.Forms.Label lblTotalBasic;
        private System.Windows.Forms.Label lblTotalBasicValue;
        private System.Windows.Forms.Label lblTotalBonus;
        private System.Windows.Forms.Label lblTotalBonusValue;
        private System.Windows.Forms.Label lblTotalDeductions;
        private System.Windows.Forms.Label lblTotalDeductionsValue;
        private System.Windows.Forms.Label lblTotalNet;
        private System.Windows.Forms.Label lblTotalNetValue;
        private System.Windows.Forms.Panel panelInput;
        private System.Windows.Forms.Label lblUserInput;
        private System.Windows.Forms.ComboBox cmbUserInput;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.NumericUpDown numMonth;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.NumericUpDown numYear;
        private System.Windows.Forms.Label lblBasicSalary;
        private System.Windows.Forms.NumericUpDown numBasicSalary;
        private System.Windows.Forms.Label lblBonus;
        private System.Windows.Forms.NumericUpDown numBonus;
        private System.Windows.Forms.Label lblDeductions;
        private System.Windows.Forms.NumericUpDown numDeductions;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelFilters = new System.Windows.Forms.Panel();
            this.lblFilterMonth = new System.Windows.Forms.Label();
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.lblFilterYear = new System.Windows.Forms.Label();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.lblFilterUser = new System.Windows.Forms.Label();
            this.cmbUser = new System.Windows.Forms.ComboBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dgvSalaries = new System.Windows.Forms.DataGridView();
            this.panelTotals = new System.Windows.Forms.Panel();
            this.lblTotalBasic = new System.Windows.Forms.Label();
            this.lblTotalBasicValue = new System.Windows.Forms.Label();
            this.lblTotalBonus = new System.Windows.Forms.Label();
            this.lblTotalBonusValue = new System.Windows.Forms.Label();
            this.lblTotalDeductions = new System.Windows.Forms.Label();
            this.lblTotalDeductionsValue = new System.Windows.Forms.Label();
            this.lblTotalNet = new System.Windows.Forms.Label();
            this.lblTotalNetValue = new System.Windows.Forms.Label();
            this.panelInput = new System.Windows.Forms.Panel();
            this.lblUserInput = new System.Windows.Forms.Label();
            this.cmbUserInput = new System.Windows.Forms.ComboBox();
            this.lblMonth = new System.Windows.Forms.Label();
            this.numMonth = new System.Windows.Forms.NumericUpDown();
            this.lblYear = new System.Windows.Forms.Label();
            this.numYear = new System.Windows.Forms.NumericUpDown();
            this.lblBasicSalary = new System.Windows.Forms.Label();
            this.numBasicSalary = new System.Windows.Forms.NumericUpDown();
            this.lblBonus = new System.Windows.Forms.Label();
            this.numBonus = new System.Windows.Forms.NumericUpDown();
            this.lblDeductions = new System.Windows.Forms.Label();
            this.numDeductions = new System.Windows.Forms.NumericUpDown();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.panelFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalaries)).BeginInit();
            this.panelTotals.SuspendLayout();
            this.panelInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMonth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBasicSalary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBonus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDeductions)).BeginInit();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1200, 50);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Salary Management (Admin Only)";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.lblTitle.ForeColor = System.Drawing.Color.White;

            // panelFilters
            this.panelFilters.BackColor = System.Drawing.Color.FromArgb(236, 240, 241);
            this.panelFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFilters.Location = new System.Drawing.Point(0, 50);
            this.panelFilters.Name = "panelFilters";
            this.panelFilters.Size = new System.Drawing.Size(1200, 60);
            this.panelFilters.TabIndex = 1;
            this.panelFilters.Padding = new System.Windows.Forms.Padding(10);

            // lblFilterMonth
            this.lblFilterMonth.AutoSize = true;
            this.lblFilterMonth.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblFilterMonth.Location = new System.Drawing.Point(15, 20);
            this.lblFilterMonth.Name = "lblFilterMonth";
            this.lblFilterMonth.Text = "Month:";

            // cmbMonth
            this.cmbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMonth.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbMonth.Location = new System.Drawing.Point(80, 17);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(120, 25);
            this.cmbMonth.TabIndex = 1;
            this.cmbMonth.SelectedIndexChanged += new System.EventHandler(this.cmbMonth_SelectedIndexChanged);

            // lblFilterYear
            this.lblFilterYear.AutoSize = true;
            this.lblFilterYear.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblFilterYear.Location = new System.Drawing.Point(220, 20);
            this.lblFilterYear.Name = "lblFilterYear";
            this.lblFilterYear.Text = "Year:";

            // cmbYear
            this.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbYear.Location = new System.Drawing.Point(270, 17);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(120, 25);
            this.cmbYear.TabIndex = 2;
            this.cmbYear.SelectedIndexChanged += new System.EventHandler(this.cmbYear_SelectedIndexChanged);

            // lblFilterUser
            this.lblFilterUser.AutoSize = true;
            this.lblFilterUser.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblFilterUser.Location = new System.Drawing.Point(410, 20);
            this.lblFilterUser.Name = "lblFilterUser";
            this.lblFilterUser.Text = "Employee:";

            // cmbUser
            this.cmbUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUser.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbUser.Location = new System.Drawing.Point(490, 17);
            this.cmbUser.Name = "cmbUser";
            this.cmbUser.Size = new System.Drawing.Size(200, 25);
            this.cmbUser.TabIndex = 3;
            this.cmbUser.SelectedIndexChanged += new System.EventHandler(this.cmbUser_SelectedIndexChanged);

            // lblSearch
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSearch.Location = new System.Drawing.Point(710, 20);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Text = "Search:";

            // txtSearch
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.Location = new System.Drawing.Point(770, 17);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(250, 25);
            this.txtSearch.TabIndex = 4;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);

            this.panelFilters.Controls.Add(this.lblFilterMonth);
            this.panelFilters.Controls.Add(this.cmbMonth);
            this.panelFilters.Controls.Add(this.lblFilterYear);
            this.panelFilters.Controls.Add(this.cmbYear);
            this.panelFilters.Controls.Add(this.lblFilterUser);
            this.panelFilters.Controls.Add(this.cmbUser);
            this.panelFilters.Controls.Add(this.lblSearch);
            this.panelFilters.Controls.Add(this.txtSearch);

            // dgvSalaries
            this.dgvSalaries.AllowUserToAddRows = false;
            this.dgvSalaries.AllowUserToDeleteRows = false;
            this.dgvSalaries.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSalaries.BackgroundColor = System.Drawing.Color.White;
            this.dgvSalaries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalaries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSalaries.Location = new System.Drawing.Point(0, 110);
            this.dgvSalaries.Name = "dgvSalaries";
            this.dgvSalaries.ReadOnly = true;
            this.dgvSalaries.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSalaries.Size = new System.Drawing.Size(800, 390);
            this.dgvSalaries.TabIndex = 2;
            this.dgvSalaries.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSalaries_CellClick);

            // panelTotals
            this.panelTotals.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.panelTotals.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelTotals.Location = new System.Drawing.Point(0, 500);
            this.panelTotals.Name = "panelTotals";
            this.panelTotals.Size = new System.Drawing.Size(1200, 80);
            this.panelTotals.TabIndex = 3;
            this.panelTotals.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);

            // lblTotalBasic
            this.lblTotalBasic.AutoSize = true;
            this.lblTotalBasic.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalBasic.ForeColor = System.Drawing.Color.White;
            this.lblTotalBasic.Location = new System.Drawing.Point(20, 12);
            this.lblTotalBasic.Name = "lblTotalBasic";
            this.lblTotalBasic.Text = "Total Basic Salary:";

            // lblTotalBasicValue
            this.lblTotalBasicValue.AutoSize = true;
            this.lblTotalBasicValue.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTotalBasicValue.ForeColor = System.Drawing.Color.White;
            this.lblTotalBasicValue.Location = new System.Drawing.Point(20, 35);
            this.lblTotalBasicValue.Name = "lblTotalBasicValue";
            this.lblTotalBasicValue.Text = "$0.00";

            // lblTotalBonus
            this.lblTotalBonus.AutoSize = true;
            this.lblTotalBonus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalBonus.ForeColor = System.Drawing.Color.White;
            this.lblTotalBonus.Location = new System.Drawing.Point(240, 12);
            this.lblTotalBonus.Name = "lblTotalBonus";
            this.lblTotalBonus.Text = "Total Bonus:";

            // lblTotalBonusValue
            this.lblTotalBonusValue.AutoSize = true;
            this.lblTotalBonusValue.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTotalBonusValue.ForeColor = System.Drawing.Color.White;
            this.lblTotalBonusValue.Location = new System.Drawing.Point(240, 35);
            this.lblTotalBonusValue.Name = "lblTotalBonusValue";
            this.lblTotalBonusValue.Text = "$0.00";

            // lblTotalDeductions
            this.lblTotalDeductions.AutoSize = true;
            this.lblTotalDeductions.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalDeductions.ForeColor = System.Drawing.Color.White;
            this.lblTotalDeductions.Location = new System.Drawing.Point(440, 12);
            this.lblTotalDeductions.Name = "lblTotalDeductions";
            this.lblTotalDeductions.Text = "Total Deductions:";

            // lblTotalDeductionsValue
            this.lblTotalDeductionsValue.AutoSize = true;
            this.lblTotalDeductionsValue.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTotalDeductionsValue.ForeColor = System.Drawing.Color.White;
            this.lblTotalDeductionsValue.Location = new System.Drawing.Point(440, 35);
            this.lblTotalDeductionsValue.Name = "lblTotalDeductionsValue";
            this.lblTotalDeductionsValue.Text = "$0.00";

            // lblTotalNet
            this.lblTotalNet.AutoSize = true;
            this.lblTotalNet.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalNet.ForeColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.lblTotalNet.Location = new System.Drawing.Point(680, 12);
            this.lblTotalNet.Name = "lblTotalNet";
            this.lblTotalNet.Text = "TOTAL NET SALARY:";

            // lblTotalNetValue
            this.lblTotalNetValue.AutoSize = true;
            this.lblTotalNetValue.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTotalNetValue.ForeColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.lblTotalNetValue.Location = new System.Drawing.Point(680, 35);
            this.lblTotalNetValue.Name = "lblTotalNetValue";
            this.lblTotalNetValue.Text = "$0.00";

            this.panelTotals.Controls.Add(this.lblTotalBasic);
            this.panelTotals.Controls.Add(this.lblTotalBasicValue);
            this.panelTotals.Controls.Add(this.lblTotalBonus);
            this.panelTotals.Controls.Add(this.lblTotalBonusValue);
            this.panelTotals.Controls.Add(this.lblTotalDeductions);
            this.panelTotals.Controls.Add(this.lblTotalDeductionsValue);
            this.panelTotals.Controls.Add(this.lblTotalNet);
            this.panelTotals.Controls.Add(this.lblTotalNetValue);

            // panelInput
            this.panelInput.BackColor = System.Drawing.Color.FromArgb(236, 240, 241);
            this.panelInput.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelInput.Location = new System.Drawing.Point(800, 110);
            this.panelInput.Name = "panelInput";
            this.panelInput.Size = new System.Drawing.Size(400, 390);
            this.panelInput.TabIndex = 4;
            this.panelInput.Padding = new System.Windows.Forms.Padding(15);
            this.panelInput.AutoScroll = true;

            // lblUserInput
            this.lblUserInput.AutoSize = true;
            this.lblUserInput.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblUserInput.Location = new System.Drawing.Point(20, 20);
            this.lblUserInput.Name = "lblUserInput";
            this.lblUserInput.Text = "Employee:";

            // cmbUserInput
            this.cmbUserInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUserInput.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbUserInput.Location = new System.Drawing.Point(20, 45);
            this.cmbUserInput.Name = "cmbUserInput";
            this.cmbUserInput.Size = new System.Drawing.Size(360, 25);
            this.cmbUserInput.TabIndex = 5;

            // lblMonth
            this.lblMonth.AutoSize = true;
            this.lblMonth.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMonth.Location = new System.Drawing.Point(20, 85);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Text = "Month:";

            // numMonth
            this.numMonth.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numMonth.Location = new System.Drawing.Point(20, 110);
            this.numMonth.Maximum = 12;
            this.numMonth.Minimum = 1;
            this.numMonth.Name = "numMonth";
            this.numMonth.Size = new System.Drawing.Size(170, 25);
            this.numMonth.TabIndex = 6;
            this.numMonth.Value = 1;

            // lblYear
            this.lblYear.AutoSize = true;
            this.lblYear.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblYear.Location = new System.Drawing.Point(210, 85);
            this.lblYear.Name = "lblYear";
            this.lblYear.Text = "Year:";

            // numYear
            this.numYear.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numYear.Location = new System.Drawing.Point(210, 110);
            this.numYear.Maximum = 2100;
            this.numYear.Minimum = 2000;
            this.numYear.Name = "numYear";
            this.numYear.Size = new System.Drawing.Size(170, 25);
            this.numYear.TabIndex = 7;
            this.numYear.Value = 2025;

            // lblBasicSalary
            this.lblBasicSalary.AutoSize = true;
            this.lblBasicSalary.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblBasicSalary.Location = new System.Drawing.Point(20, 150);
            this.lblBasicSalary.Name = "lblBasicSalary";
            this.lblBasicSalary.Text = "Basic Salary:";

            // numBasicSalary
            this.numBasicSalary.DecimalPlaces = 2;
            this.numBasicSalary.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numBasicSalary.Location = new System.Drawing.Point(20, 175);
            this.numBasicSalary.Maximum = 1000000;
            this.numBasicSalary.Name = "numBasicSalary";
            this.numBasicSalary.Size = new System.Drawing.Size(360, 25);
            this.numBasicSalary.TabIndex = 8;

            // lblBonus
            this.lblBonus.AutoSize = true;
            this.lblBonus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblBonus.Location = new System.Drawing.Point(20, 215);
            this.lblBonus.Name = "lblBonus";
            this.lblBonus.Text = "Bonus:";

            // numBonus
            this.numBonus.DecimalPlaces = 2;
            this.numBonus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numBonus.Location = new System.Drawing.Point(20, 240);
            this.numBonus.Maximum = 1000000;
            this.numBonus.Name = "numBonus";
            this.numBonus.Size = new System.Drawing.Size(360, 25);
            this.numBonus.TabIndex = 9;

            // lblDeductions
            this.lblDeductions.AutoSize = true;
            this.lblDeductions.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDeductions.Location = new System.Drawing.Point(20, 280);
            this.lblDeductions.Name = "lblDeductions";
            this.lblDeductions.Text = "Deductions:";

            // numDeductions
            this.numDeductions.DecimalPlaces = 2;
            this.numDeductions.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numDeductions.Location = new System.Drawing.Point(20, 305);
            this.numDeductions.Maximum = 1000000;
            this.numDeductions.Name = "numDeductions";
            this.numDeductions.Size = new System.Drawing.Size(360, 25);
            this.numDeductions.TabIndex = 10;

            // btnAdd
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(20, 350);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(170, 38);
            this.btnAdd.TabIndex = 11;
            this.btnAdd.Text = "💾 Add Salary";
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // btnUpdate
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnUpdate.Enabled = false;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(210, 350);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(170, 38);
            this.btnUpdate.TabIndex = 12;
            this.btnUpdate.Text = "✏️ Update";
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);

            // btnDelete
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.btnDelete.Enabled = false;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(20, 398);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(170, 38);
            this.btnDelete.TabIndex = 13;
            this.btnDelete.Text = "🗑️ Delete";
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // btnClear
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(149, 165, 166);
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(210, 398);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(170, 38);
            this.btnClear.TabIndex = 14;
            this.btnClear.Text = "🔄 Clear";
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);

            this.panelInput.Controls.Add(this.lblUserInput);
            this.panelInput.Controls.Add(this.cmbUserInput);
            this.panelInput.Controls.Add(this.lblMonth);
            this.panelInput.Controls.Add(this.numMonth);
            this.panelInput.Controls.Add(this.lblYear);
            this.panelInput.Controls.Add(this.numYear);
            this.panelInput.Controls.Add(this.lblBasicSalary);
            this.panelInput.Controls.Add(this.numBasicSalary);
            this.panelInput.Controls.Add(this.lblBonus);
            this.panelInput.Controls.Add(this.numBonus);
            this.panelInput.Controls.Add(this.lblDeductions);
            this.panelInput.Controls.Add(this.numDeductions);
            this.panelInput.Controls.Add(this.btnAdd);
            this.panelInput.Controls.Add(this.btnUpdate);
            this.panelInput.Controls.Add(this.btnDelete);
            this.panelInput.Controls.Add(this.btnClear);

            // SalaryManagementControl
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dgvSalaries);
            this.Controls.Add(this.panelInput);
            this.Controls.Add(this.panelTotals);
            this.Controls.Add(this.panelFilters);
            this.Controls.Add(this.lblTitle);
            this.Name = "SalaryManagementControl";
            this.Size = new System.Drawing.Size(1200, 600);
            this.Load += new System.EventHandler(this.SalaryManagementControl_Load);
            this.panelFilters.ResumeLayout(false);
            this.panelFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalaries)).EndInit();
            this.panelTotals.ResumeLayout(false);
            this.panelTotals.PerformLayout();
            this.panelInput.ResumeLayout(false);
            this.panelInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMonth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBasicSalary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBonus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDeductions)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
