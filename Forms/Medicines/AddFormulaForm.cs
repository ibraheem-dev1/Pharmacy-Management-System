using System;
using System.Drawing;
using System.Windows.Forms;
using PharmacyWinFormsApp.DAL;
using PharmacyWinFormsApp.Models;

namespace PharmacyWinFormsApp.Forms.Medicines
{
    public partial class AddFormulaForm : Form
    {
        private readonly FormulaDAL formulaDAL;
        public bool FormulaAdded { get; private set; }

        private Label lblTitle = null!;
        private Label lblFormulaName = null!;
        private TextBox txtFormulaName = null!;
        private Button btnSave = null!;
        private Button btnCancel = null!;

        public AddFormulaForm()
        {
            formulaDAL = new FormulaDAL();
            FormulaAdded = false;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.lblTitle = new Label();
            this.lblFormulaName = new Label();
            this.txtFormulaName = new TextBox();
            this.btnSave = new Button();
            this.btnCancel = new Button();

            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = false;
            this.lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.FromArgb(41, 128, 185);
            this.lblTitle.Location = new Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(250, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Add New Formula";

            // lblFormulaName
            this.lblFormulaName.AutoSize = true;
            this.lblFormulaName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblFormulaName.Location = new Point(20, 60);
            this.lblFormulaName.Name = "lblFormulaName";
            this.lblFormulaName.Size = new Size(110, 19);
            this.lblFormulaName.TabIndex = 1;
            this.lblFormulaName.Text = "Formula Name:";

            // txtFormulaName
            this.txtFormulaName.Font = new Font("Segoe UI", 10F);
            this.txtFormulaName.Location = new Point(20, 85);
            this.txtFormulaName.Name = "txtFormulaName";
            this.txtFormulaName.PlaceholderText = "Enter formula name (e.g., Tablet, Capsule)";
            this.txtFormulaName.Size = new Size(360, 25);
            this.txtFormulaName.TabIndex = 0;

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

            // AddFormulaForm
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            this.ClientSize = new Size(400, 190);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtFormulaName);
            this.Controls.Add(this.lblFormulaName);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddFormulaForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Add Formula";

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void btnSave_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFormulaName.Text))
            {
                MessageBox.Show("Please enter formula name.", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFormulaName.Focus();
                return;
            }

            try
            {
                Formula formula = new Formula
                {
                    FormulaName = txtFormulaName.Text.Trim()
                };

                if (formulaDAL.AddFormula(formula))
                {
                    MessageBox.Show("Formula added successfully!", "Success", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FormulaAdded = true;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to add formula.", "Error", 
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
