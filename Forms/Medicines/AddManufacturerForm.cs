using System;
using System.Drawing;
using System.Windows.Forms;
using PharmacyWinFormsApp.DAL;
using PharmacyWinFormsApp.Models;

namespace PharmacyWinFormsApp.Forms.Medicines
{
    public partial class AddManufacturerForm : Form
    {
        private readonly ManufacturerDAL manufacturerDAL;
        public bool ManufacturerAdded { get; private set; }

        private Label lblTitle = null!;
        private Label lblManufacturerName = null!;
        private TextBox txtManufacturerName = null!;
        private Button btnSave = null!;
        private Button btnCancel = null!;

        public AddManufacturerForm()
        {
            manufacturerDAL = new ManufacturerDAL();
            ManufacturerAdded = false;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.lblTitle = new Label();
            this.lblManufacturerName = new Label();
            this.txtManufacturerName = new TextBox();
            this.btnSave = new Button();
            this.btnCancel = new Button();

            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = false;
            this.lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.FromArgb(41, 128, 185);
            this.lblTitle.Location = new Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(300, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Add New Manufacturer";

            // lblManufacturerName
            this.lblManufacturerName.AutoSize = true;
            this.lblManufacturerName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblManufacturerName.Location = new Point(20, 60);
            this.lblManufacturerName.Name = "lblManufacturerName";
            this.lblManufacturerName.Size = new Size(150, 19);
            this.lblManufacturerName.TabIndex = 1;
            this.lblManufacturerName.Text = "Manufacturer Name:";

            // txtManufacturerName
            this.txtManufacturerName.Font = new Font("Segoe UI", 10F);
            this.txtManufacturerName.Location = new Point(20, 85);
            this.txtManufacturerName.Name = "txtManufacturerName";
            this.txtManufacturerName.PlaceholderText = "Enter manufacturer name";
            this.txtManufacturerName.Size = new Size(360, 25);
            this.txtManufacturerName.TabIndex = 0;

            // btnSave
            this.btnSave.BackColor = Color.FromArgb(39, 174, 96);
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = FlatStyle.Flat;
            this.btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnSave.ForeColor = Color.White;
            this.btnSave.Location = new Point(150, 130);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new Size(110, 40);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new EventHandler(this.btnSave_Click);

            // btnCancel
            this.btnCancel.BackColor = Color.FromArgb(149, 165, 166);
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = FlatStyle.Flat;
            this.btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnCancel.ForeColor = Color.White;
            this.btnCancel.Location = new Point(270, 130);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(110, 40);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);

            // AddManufacturerForm
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            this.ClientSize = new Size(400, 190);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtManufacturerName);
            this.Controls.Add(this.lblManufacturerName);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddManufacturerForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Add Manufacturer";

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void btnSave_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtManufacturerName.Text))
            {
                MessageBox.Show("Please enter manufacturer name.", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtManufacturerName.Focus();
                return;
            }

            try
            {
                Manufacturer manufacturer = new Manufacturer
                {
                    ManufacturerName = txtManufacturerName.Text.Trim()
                };

                if (manufacturerDAL.AddManufacturer(manufacturer))
                {
                    MessageBox.Show("Manufacturer added successfully!", "Success", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ManufacturerAdded = true;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to add manufacturer.", "Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
