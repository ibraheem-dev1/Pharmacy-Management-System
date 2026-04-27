using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PharmacyWinFormsApp.DAL;
using PharmacyWinFormsApp.Models;
using System.Collections.Generic;

namespace PharmacyWinFormsApp.Forms.Prescriptions
{
    public partial class PrescriptionManagementControl : UserControl
    {
        private readonly PrescriptionDAL prescriptionDAL;
        private readonly PrescriptionDetailDAL prescriptionDetailDAL;
        private readonly CustomerDAL customerDAL;
        private readonly MedicineDAL medicineDAL;
        private int selectedPrescriptionID = 0;
        private List<PrescriptionDetail> prescriptionDetails = new List<PrescriptionDetail>();

        private Label lblTitle = null!;
        private TableLayoutPanel mainLayout = null!;
        private Panel topPanel = null!;
        private GroupBox grpPrescription = null!;
        private GroupBox grpMedicineDetails = null!;
        private DataGridView dgvPrescriptions = null!;
        
        private ComboBox cmbCustomer = null!;
        private TextBox txtDoctorName = null!;
        private DateTimePicker dtpPrescriptionDate = null!;
        private TextBox txtNotes = null!;
        private Button btnAddPrescription = null!;
        private Button btnUpdate = null!;
        private Button btnClear = null!;
        private Label lblCustomer = null!;
        private Label lblDoctorName = null!;
        private Label lblDate = null!;
        private Label lblNotes = null!;
        private Label lblViewingMode = null!;
        
        private Button btnAddMedicine = null!;
        private DataGridView dgvMedicineDetails = null!;        public PrescriptionManagementControl()
        {
            prescriptionDAL = new PrescriptionDAL();
            prescriptionDetailDAL = new PrescriptionDetailDAL();
            customerDAL = new CustomerDAL();
            medicineDAL = new MedicineDAL();
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.lblTitle = new Label();
            this.mainLayout = new TableLayoutPanel();
            this.topPanel = new Panel();
            this.grpPrescription = new GroupBox();
            this.grpMedicineDetails = new GroupBox();
            this.cmbCustomer = new ComboBox();
            this.txtDoctorName = new TextBox();
            this.dtpPrescriptionDate = new DateTimePicker();
            this.txtNotes = new TextBox();
            this.btnAddPrescription = new Button();
            this.btnUpdate = new Button();
            this.btnClear = new Button();
            this.dgvPrescriptions = new DataGridView();
            this.lblCustomer = new Label();
            this.lblDoctorName = new Label();
            this.lblDate = new Label();
            this.lblNotes = new Label();
            this.lblViewingMode = new Label();
            this.btnAddMedicine = new Button();
            this.dgvMedicineDetails = new DataGridView();
            
            this.mainLayout.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.grpPrescription.SuspendLayout();
            this.grpMedicineDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrescriptions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicineDetails)).BeginInit();
            this.SuspendLayout();
            
            // lblTitle
            this.lblTitle.Dock = DockStyle.Top;
            this.lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new Padding(10, 10, 10, 15);
            this.lblTitle.Size = new Size(1200, 60);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Prescription Management";
            
            // lblViewingMode
            this.lblViewingMode.Dock = DockStyle.Top;
            this.lblViewingMode.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            this.lblViewingMode.ForeColor = Color.FromArgb(0, 122, 204);
            this.lblViewingMode.Name = "lblViewingMode";
            this.lblViewingMode.Padding = new Padding(10, 0, 10, 5);
            this.lblViewingMode.Size = new Size(1200, 25);
            this.lblViewingMode.TabIndex = 1;
            this.lblViewingMode.Text = "";
            
            // mainLayout
            this.mainLayout.ColumnCount = 1;
            this.mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this.mainLayout.Controls.Add(this.topPanel, 0, 0);
            this.mainLayout.Controls.Add(this.dgvPrescriptions, 0, 1);
            this.mainLayout.Dock = DockStyle.Fill;
            this.mainLayout.Location = new Point(0, 85);
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.Padding = new Padding(10, 0, 10, 10);
            this.mainLayout.RowCount = 2;
            this.mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 380F));
            this.mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this.mainLayout.Size = new Size(1200, 715);
            this.mainLayout.TabIndex = 2;
            
            // topPanel
            this.topPanel.Controls.Add(this.grpMedicineDetails);
            this.topPanel.Controls.Add(this.grpPrescription);
            this.topPanel.Dock = DockStyle.Fill;
            this.topPanel.Name = "topPanel";
            this.topPanel.Padding = new Padding(0, 0, 0, 10);
            this.topPanel.Size = new Size(1180, 380);
            this.topPanel.TabIndex = 0;
            
            // grpPrescription
            this.grpPrescription.Controls.Add(this.CreatePrescriptionLayout());
            this.grpPrescription.Dock = DockStyle.Left;
            this.grpPrescription.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.grpPrescription.Name = "grpPrescription";
            this.grpPrescription.Padding = new Padding(10);
            this.grpPrescription.Size = new Size(580, 370);
            this.grpPrescription.TabIndex = 0;
            this.grpPrescription.TabStop = false;
            this.grpPrescription.Text = "Prescription Details";
            
            // grpMedicineDetails
            this.grpMedicineDetails.Controls.Add(this.CreateMedicineLayout());
            this.grpMedicineDetails.Dock = DockStyle.Fill;
            this.grpMedicineDetails.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.grpMedicineDetails.Location = new Point(580, 0);
            this.grpMedicineDetails.Name = "grpMedicineDetails";
            this.grpMedicineDetails.Padding = new Padding(10);
            this.grpMedicineDetails.Size = new Size(600, 370);
            this.grpMedicineDetails.TabIndex = 1;
            this.grpMedicineDetails.TabStop = false;
            this.grpMedicineDetails.Text = "Medicine Summary";
            
            // dgvPrescriptions
            this.dgvPrescriptions.AllowUserToAddRows = false;
            this.dgvPrescriptions.AllowUserToDeleteRows = false;
            this.dgvPrescriptions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPrescriptions.BackgroundColor = Color.White;
            this.dgvPrescriptions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrescriptions.Dock = DockStyle.Fill;
            this.dgvPrescriptions.Name = "dgvPrescriptions";
            this.dgvPrescriptions.ReadOnly = true;
            this.dgvPrescriptions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvPrescriptions.TabIndex = 1;
            this.dgvPrescriptions.CellClick += new DataGridViewCellEventHandler(this.dgvPrescriptions_CellClick);
            
            // PrescriptionManagementControl
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            this.Controls.Add(this.mainLayout);
            this.Controls.Add(this.lblViewingMode);
            this.Controls.Add(this.lblTitle);
            this.Name = "PrescriptionManagementControl";
            this.Size = new Size(1200, 800);
            this.Load += new EventHandler(this.PrescriptionManagementControl_Load);
            
            this.mainLayout.ResumeLayout(false);
            this.topPanel.ResumeLayout(false);
            this.grpPrescription.ResumeLayout(false);
            this.grpMedicineDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrescriptions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicineDetails)).EndInit();
            this.ResumeLayout(false);
        }

        private TableLayoutPanel CreatePrescriptionLayout()
        {
            var layout = new TableLayoutPanel();
            layout.Dock = DockStyle.Fill;
            layout.ColumnCount = 2;
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layout.RowCount = 6;
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 10F));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            layout.Padding = new Padding(5);
            
            this.lblCustomer = new Label { Text = "Customer:", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft, Font = new Font("Segoe UI", 9F) };
            this.cmbCustomer = new ComboBox { Dock = DockStyle.Fill, DropDownStyle = ComboBoxStyle.DropDownList, Font = new Font("Segoe UI", 9F) };
            
            this.lblDoctorName = new Label { Text = "Doctor Name:", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft, Font = new Font("Segoe UI", 9F) };
            this.txtDoctorName = new TextBox { Dock = DockStyle.Fill, Font = new Font("Segoe UI", 9F) };
            
            this.lblDate = new Label { Text = "Date:", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft, Font = new Font("Segoe UI", 9F) };
            this.dtpPrescriptionDate = new DateTimePicker { Dock = DockStyle.Fill, Format = DateTimePickerFormat.Short, Font = new Font("Segoe UI", 9F) };
            
            this.lblNotes = new Label { Text = "Notes:", Dock = DockStyle.Fill, TextAlign = ContentAlignment.TopLeft, Font = new Font("Segoe UI", 9F), Padding = new Padding(0, 5, 0, 0) };
            this.txtNotes = new TextBox { Dock = DockStyle.Fill, Multiline = true, Font = new Font("Segoe UI", 9F) };
            
            var buttonPanel = new FlowLayoutPanel { Dock = DockStyle.Fill, FlowDirection = FlowDirection.RightToLeft, WrapContents = false };
            
            this.btnClear = new Button
            {
                Text = "Clear",
                Size = new Size(90, 35),
                BackColor = Color.Gray,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F)
            };
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.Click += new EventHandler(this.btnClear_Click);
            
            this.btnUpdate = new Button
            {
                Text = "Update",
                Size = new Size(90, 35),
                BackColor = Color.FromArgb(255, 193, 7),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Margin = new Padding(5, 0, 5, 0)
            };
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.Click += new EventHandler(this.btnUpdate_Click);
            
            this.btnAddPrescription = new Button
            {
                Text = "Add",
                Size = new Size(90, 35),
                BackColor = Color.FromArgb(0, 122, 204),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Margin = new Padding(5, 0, 0, 0)
            };
            this.btnAddPrescription.FlatAppearance.BorderSize = 0;
            this.btnAddPrescription.Click += new EventHandler(this.btnAddPrescription_Click);
            
            buttonPanel.Controls.Add(this.btnClear);
            buttonPanel.Controls.Add(this.btnUpdate);
            buttonPanel.Controls.Add(this.btnAddPrescription);
            
            layout.Controls.Add(this.lblCustomer, 0, 0);
            layout.Controls.Add(this.cmbCustomer, 1, 0);
            layout.Controls.Add(this.lblDoctorName, 0, 1);
            layout.Controls.Add(this.txtDoctorName, 1, 1);
            layout.Controls.Add(this.lblDate, 0, 2);
            layout.Controls.Add(this.dtpPrescriptionDate, 1, 2);
            layout.Controls.Add(this.lblNotes, 0, 3);
            layout.Controls.Add(this.txtNotes, 1, 3);
            layout.Controls.Add(buttonPanel, 0, 5);
            layout.SetColumnSpan(buttonPanel, 2);
            
            return layout;
        }

        private TableLayoutPanel CreateMedicineLayout()
        {
            var layout = new TableLayoutPanel();
            layout.Dock = DockStyle.Fill;
            layout.ColumnCount = 1;
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layout.RowCount = 2;
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layout.Padding = new Padding(5);
            
            this.btnAddMedicine = new Button
            {
                Text = "➕ Add Medicine",
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(40, 167, 69),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            this.btnAddMedicine.FlatAppearance.BorderSize = 0;
            this.btnAddMedicine.Click += new EventHandler(this.btnAddMedicine_Click);
            
            this.dgvMedicineDetails = new DataGridView
            {
                Dock = DockStyle.Fill,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White,
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                Font = new Font("Segoe UI", 9F)
            };
            
            layout.Controls.Add(this.btnAddMedicine, 0, 0);
            layout.Controls.Add(this.dgvMedicineDetails, 0, 1);
            
            return layout;
        }

        private void PrescriptionManagementControl_Load(object? sender, EventArgs e)
        {
            LoadCustomers();
            LoadPrescriptions();
            LoadMedicineDetailsGrid();
            dtpPrescriptionDate.Value = DateTime.Today;
            UpdateViewingMode();
        }

        private void LoadCustomers()
        {
            var customers = customerDAL.GetAllCustomers();
            cmbCustomer.DataSource = customers;
            cmbCustomer.DisplayMember = "CustomerName";
            cmbCustomer.ValueMember = "CustomerID";
        }

        private void LoadMedicineDetailsGrid()
        {
            dgvMedicineDetails.DataSource = null;
            dgvMedicineDetails.DataSource = prescriptionDetails;
            
            if (dgvMedicineDetails.Columns["PrescriptionID"] != null)
                dgvMedicineDetails.Columns["PrescriptionID"]!.Visible = false;
            if (dgvMedicineDetails.Columns["MedicineID"] != null)
                dgvMedicineDetails.Columns["MedicineID"]!.Visible = false;
        }

        private void LoadPrescriptions()
        {
            var prescriptions = prescriptionDAL.GetAllPrescriptions();
            dgvPrescriptions.DataSource = prescriptions;
            
            if (dgvPrescriptions.Columns["PrescriptionID"] != null)
                dgvPrescriptions.Columns["PrescriptionID"]!.Visible = false;
            if (dgvPrescriptions.Columns["CustomerID"] != null)
                dgvPrescriptions.Columns["CustomerID"]!.Visible = false;
        }

        private void btnAddMedicine_Click(object? sender, EventArgs e)
        {
            using (var modal = new AddMedicineModal(medicineDAL))
            {
                if (modal.ShowDialog() == DialogResult.OK)
                {
                    var detail = modal.GetPrescriptionDetail();
                    
                    if (prescriptionDetails.Any(d => d.MedicineID == detail.MedicineID))
                    {
                        MessageBox.Show("This medicine is already added to the prescription.", "Duplicate Entry", 
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    prescriptionDetails.Add(detail);
                    LoadMedicineDetailsGrid();
                }
            }
        }

        private void btnAddPrescription_Click(object? sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            if (prescriptionDetails.Count == 0)
            {
                MessageBox.Show("Please add at least one medicine to the prescription.", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Prescription prescription = new Prescription
                {
                    CustomerID = cmbCustomer.SelectedValue != null ? (int)cmbCustomer.SelectedValue : 0,
                    DoctorName = txtDoctorName.Text.Trim(),
                    PrescriptionDate = dtpPrescriptionDate.Value,
                    Notes = txtNotes.Text.Trim()
                };

                int prescriptionID = prescriptionDAL.AddPrescription(prescription);
                if (prescriptionID > 0)
                {
                    // Add all medicine details
                    bool allDetailsAdded = true;
                    foreach (var detail in prescriptionDetails)
                    {
                        detail.PrescriptionID = prescriptionID;
                        if (!prescriptionDetailDAL.AddPrescriptionDetail(detail))
                        {
                            allDetailsAdded = false;
                            break;
                        }
                    }

                    if (allDetailsAdded)
                    {
                        MessageBox.Show("Prescription added successfully with all medicines!", "Success", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearForm();
                        LoadPrescriptions();
                    }
                    else
                    {
                        MessageBox.Show("Prescription added but some medicine details failed to save.", "Warning", 
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Failed to add prescription.", "Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object? sender, EventArgs e)
        {
            if (selectedPrescriptionID == 0)
            {
                MessageBox.Show("Please select a prescription to update.", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateForm())
                return;

            try
            {
                Prescription prescription = new Prescription
                {
                    PrescriptionID = selectedPrescriptionID,
                    CustomerID = cmbCustomer.SelectedValue != null ? (int)cmbCustomer.SelectedValue : 0,
                    DoctorName = txtDoctorName.Text.Trim(),
                    PrescriptionDate = dtpPrescriptionDate.Value,
                    Notes = txtNotes.Text.Trim()
                };

                if (prescriptionDAL.UpdatePrescription(prescription))
                {
                    MessageBox.Show("Prescription updated successfully!", "Success", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    LoadPrescriptions();
                }
                else
                {
                    MessageBox.Show("Failed to update prescription.", "Error", 
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

        private void dgvPrescriptions_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPrescriptions.Rows[e.RowIndex];
                selectedPrescriptionID = Convert.ToInt32(row.Cells["PrescriptionID"].Value);
                
                var customerId = Convert.ToInt32(row.Cells["CustomerID"].Value);
                cmbCustomer.SelectedValue = customerId;
                txtDoctorName.Text = row.Cells["DoctorName"].Value.ToString();
                dtpPrescriptionDate.Value = Convert.ToDateTime(row.Cells["PrescriptionDate"].Value);
                txtNotes.Text = row.Cells["Notes"]?.Value?.ToString() ?? "";

                LoadPrescriptionDetails(selectedPrescriptionID);
                UpdateViewingMode();
            }
        }

        private void LoadPrescriptionDetails(int prescriptionID)
        {
            prescriptionDetails.Clear();
            prescriptionDetails.AddRange(prescriptionDetailDAL.GetPrescriptionDetails(prescriptionID));
            LoadMedicineDetailsGrid();
        }

        private bool ValidateForm()
        {
            if (cmbCustomer.SelectedValue == null)
            {
                MessageBox.Show("Please select a customer.", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDoctorName.Text))
            {
                MessageBox.Show("Please enter doctor name.", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void ClearForm()
        {
            selectedPrescriptionID = 0;
            if (cmbCustomer.Items.Count > 0)
                cmbCustomer.SelectedIndex = 0;
            txtDoctorName.Clear();
            dtpPrescriptionDate.Value = DateTime.Today;
            txtNotes.Clear();
            prescriptionDetails.Clear();
            LoadMedicineDetailsGrid();
            UpdateViewingMode();
        }

        private void UpdateViewingMode()
        {
            if (selectedPrescriptionID > 0)
            {
                lblViewingMode.Text = $"Viewing Prescription #{selectedPrescriptionID} | Editing Mode";
                lblViewingMode.ForeColor = Color.FromArgb(255, 193, 7);
            }
            else
            {
                lblViewingMode.Text = "New Prescription Mode";
                lblViewingMode.ForeColor = Color.FromArgb(40, 167, 69);
            }
        }
    }

    public class AddMedicineModal : Form
    {
        private readonly MedicineDAL medicineDAL;
        private PrescriptionDetail? prescriptionDetail;
        private List<Medicine> availableVariants = new List<Medicine>();

        private ComboBox cmbMedicineName = null!;
        private ComboBox cmbFormula = null!;
        private ComboBox cmbStrength = null!;
        private TextBox txtDosage = null!;
        private TextBox txtFrequency = null!;
        private NumericUpDown numDurationDays = null!;
        private Button btnSave = null!;
        private Button btnCancel = null!;

        public AddMedicineModal(MedicineDAL medicineDAL)
        {
            this.medicineDAL = medicineDAL;
            InitializeComponent();
            LoadMedicineNames();
        }

        private void InitializeComponent()
        {
            this.Text = "Add Medicine to Prescription";
            this.Size = new Size(550, 420);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.White;

            var layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 8,
                Padding = new Padding(20)
            };
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));

            var lblMedicineName = new Label { Text = "Medicine:", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft, Font = new Font("Segoe UI", 9F) };
            this.cmbMedicineName = new ComboBox { Dock = DockStyle.Fill, DropDownStyle = ComboBoxStyle.DropDownList, Font = new Font("Segoe UI", 9F) };
            this.cmbMedicineName.SelectedIndexChanged += new EventHandler(this.cmbMedicineName_SelectedIndexChanged);

            var lblFormula = new Label { Text = "Formula:", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft, Font = new Font("Segoe UI", 9F) };
            this.cmbFormula = new ComboBox { Dock = DockStyle.Fill, DropDownStyle = ComboBoxStyle.DropDownList, Font = new Font("Segoe UI", 9F), Enabled = false };
            this.cmbFormula.SelectedIndexChanged += new EventHandler(this.cmbFormula_SelectedIndexChanged);

            var lblStrength = new Label { Text = "Strength (mg):", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft, Font = new Font("Segoe UI", 9F) };
            this.cmbStrength = new ComboBox { Dock = DockStyle.Fill, DropDownStyle = ComboBoxStyle.DropDownList, Font = new Font("Segoe UI", 9F), Enabled = false };

            var lblDosage = new Label { Text = "Dosage:", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft, Font = new Font("Segoe UI", 9F) };
            this.txtDosage = new TextBox { Dock = DockStyle.Fill, PlaceholderText = "e.g., 1 tablet", Font = new Font("Segoe UI", 9F) };

            var lblFrequency = new Label { Text = "Frequency:", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft, Font = new Font("Segoe UI", 9F) };
            this.txtFrequency = new TextBox { Dock = DockStyle.Fill, PlaceholderText = "e.g., Twice daily", Font = new Font("Segoe UI", 9F) };

            var lblDuration = new Label { Text = "Duration (Days):", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft, Font = new Font("Segoe UI", 9F) };
            this.numDurationDays = new NumericUpDown { Dock = DockStyle.Fill, Minimum = 1, Maximum = 365, Value = 7, Font = new Font("Segoe UI", 9F) };

            var buttonPanel = new FlowLayoutPanel { Dock = DockStyle.Fill, FlowDirection = FlowDirection.RightToLeft };

            this.btnCancel = new Button
            {
                Text = "Cancel",
                Size = new Size(100, 35),
                BackColor = Color.Gray,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F),
                DialogResult = DialogResult.Cancel
            };
            this.btnCancel.FlatAppearance.BorderSize = 0;

            this.btnSave = new Button
            {
                Text = "Save",
                Size = new Size(100, 35),
                BackColor = Color.FromArgb(40, 167, 69),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Margin = new Padding(0, 0, 10, 0)
            };
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.Click += new EventHandler(this.btnSave_Click);

            buttonPanel.Controls.Add(this.btnCancel);
            buttonPanel.Controls.Add(this.btnSave);

            layout.Controls.Add(lblMedicineName, 0, 0);
            layout.Controls.Add(this.cmbMedicineName, 1, 0);
            layout.Controls.Add(lblFormula, 0, 1);
            layout.Controls.Add(this.cmbFormula, 1, 1);
            layout.Controls.Add(lblStrength, 0, 2);
            layout.Controls.Add(this.cmbStrength, 1, 2);
            layout.Controls.Add(lblDosage, 0, 3);
            layout.Controls.Add(this.txtDosage, 1, 3);
            layout.Controls.Add(lblFrequency, 0, 4);
            layout.Controls.Add(this.txtFrequency, 1, 4);
            layout.Controls.Add(lblDuration, 0, 5);
            layout.Controls.Add(this.numDurationDays, 1, 5);
            layout.Controls.Add(buttonPanel, 0, 7);
            layout.SetColumnSpan(buttonPanel, 2);

            this.Controls.Add(layout);
            this.AcceptButton = this.btnSave;
            this.CancelButton = this.btnCancel;
        }

        private void LoadMedicineNames()
        {
            var names = medicineDAL.GetDistinctMedicineNames();
            cmbMedicineName.DataSource = names;
            cmbMedicineName.SelectedIndex = -1;
        }

        private void cmbMedicineName_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cmbMedicineName.SelectedIndex < 0 || string.IsNullOrEmpty(cmbMedicineName.Text))
            {
                cmbFormula.DataSource = null;
                cmbFormula.Enabled = false;
                cmbStrength.DataSource = null;
                cmbStrength.Enabled = false;
                availableVariants.Clear();
                return;
            }

            string selectedMedicine = cmbMedicineName.Text;
            availableVariants = medicineDAL.GetMedicineVariants(selectedMedicine);

            // Get distinct formulas
            var formulas = availableVariants
                .Select(m => new { m.FormulaID, m.FormulaName })
                .Distinct()
                .ToList();

            cmbFormula.DataSource = formulas;
            cmbFormula.DisplayMember = "FormulaName";
            cmbFormula.ValueMember = "FormulaID";
            cmbFormula.Enabled = formulas.Count > 0;
            cmbFormula.SelectedIndex = formulas.Count > 0 ? 0 : -1;
        }

        private void cmbFormula_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cmbFormula.SelectedIndex < 0 || cmbFormula.SelectedValue == null)
            {
                cmbStrength.DataSource = null;
                cmbStrength.Enabled = false;
                return;
            }

            int selectedFormulaID = Convert.ToInt32(cmbFormula.SelectedValue);

            // Get strengths for the selected formula
            var strengths = availableVariants
                .Where(m => m.FormulaID == selectedFormulaID)
                .Select(m => new { m.MedicineID, Strength = $"{m.StrengthMG}mg" })
                .ToList();

            cmbStrength.DataSource = strengths;
            cmbStrength.DisplayMember = "Strength";
            cmbStrength.ValueMember = "MedicineID";
            cmbStrength.Enabled = strengths.Count > 0;
            cmbStrength.SelectedIndex = strengths.Count > 0 ? 0 : -1;
        }

        private void btnSave_Click(object? sender, EventArgs e)
        {
            if (cmbStrength.SelectedIndex < 0 || cmbStrength.SelectedValue == null)
            {
                MessageBox.Show("Please select medicine, formula, and strength.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDosage.Text))
            {
                MessageBox.Show("Please enter dosage.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtFrequency.Text))
            {
                MessageBox.Show("Please enter frequency.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int selectedMedicineID = Convert.ToInt32(cmbStrength.SelectedValue);
            var selectedMedicine = availableVariants.FirstOrDefault(m => m.MedicineID == selectedMedicineID);

            prescriptionDetail = new PrescriptionDetail
            {
                MedicineID = selectedMedicineID,
                MedicineName = selectedMedicine != null ? $"{selectedMedicine.Name} ({selectedMedicine.StrengthMG}mg) - {selectedMedicine.FormulaName}" : cmbMedicineName.Text,
                Dosage = txtDosage.Text.Trim(),
                Frequency = txtFrequency.Text.Trim(),
                DurationDays = (int)numDurationDays.Value
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        public PrescriptionDetail GetPrescriptionDetail()
        {
            return prescriptionDetail!;
        }
    }
}
