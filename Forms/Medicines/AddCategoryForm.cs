using System;
using System.Drawing;
using System.Windows.Forms;
using PharmacyWinFormsApp.DAL;
using PharmacyWinFormsApp.Models;

namespace PharmacyWinFormsApp.Forms.Medicines
{
    public partial class AddCategoryForm : Form
    {
        private readonly CategoryDAL categoryDAL;
        public bool CategoryAdded { get; private set; }

        private Label lblTitle = null!;
        private Label lblCategoryName = null!;
        private TextBox txtCategoryName = null!;
        private Button btnSave = null!;
        private Button btnCancel = null!;

        public AddCategoryForm()
        {
            categoryDAL = new CategoryDAL();
            CategoryAdded = false;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.lblTitle = new Label();
            this.lblCategoryName = new Label();
            this.txtCategoryName = new TextBox();
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
            this.lblTitle.Text = "Add New Category";

            // lblCategoryName
            this.lblCategoryName.AutoSize = true;
            this.lblCategoryName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblCategoryName.Location = new Point(20, 60);
            this.lblCategoryName.Name = "lblCategoryName";
            this.lblCategoryName.Size = new Size(120, 19);
            this.lblCategoryName.TabIndex = 1;
            this.lblCategoryName.Text = "Category Name:";

            // txtCategoryName
            this.txtCategoryName.Font = new Font("Segoe UI", 10F);
            this.txtCategoryName.Location = new Point(20, 85);
            this.txtCategoryName.Name = "txtCategoryName";
            this.txtCategoryName.PlaceholderText = "Enter category name";
            this.txtCategoryName.Size = new Size(360, 25);
            this.txtCategoryName.TabIndex = 0;

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

            // AddCategoryForm
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            this.ClientSize = new Size(400, 190);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtCategoryName);
            this.Controls.Add(this.lblCategoryName);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddCategoryForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Add Category";

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void btnSave_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                MessageBox.Show("Please enter category name.", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCategoryName.Focus();
                return;
            }

            try
            {
                Category category = new Category
                {
                    CategoryName = txtCategoryName.Text.Trim()
                };

                if (categoryDAL.AddCategory(category))
                {
                    MessageBox.Show("Category added successfully!", "Success", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CategoryAdded = true;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to add category.", "Error", 
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
