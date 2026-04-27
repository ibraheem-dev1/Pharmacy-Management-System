using System;
using System.Drawing;
using System.Windows.Forms;
using PharmacyWinFormsApp.DAL;
using PharmacyWinFormsApp.Models;

namespace PharmacyWinFormsApp.Forms.Roles
{
    public partial class RoleManagementControl : UserControl
    {
        private Label lblTitle = null!;
        private GroupBox grpRoleDetails = null!;
        private Label lblRoleName = null!;
        private TextBox txtRoleName = null!;
        private Button btnAdd = null!;
        private Button btnClear = null!;
        private DataGridView dgvRoles = null!;
        private RoleDAL roleDAL;
        private int selectedRoleID = 0;

        public RoleManagementControl()
        {
            roleDAL = new RoleDAL();
            InitializeComponent();
            LoadRoles();
        }

        private void InitializeComponent()
        {
            this.lblTitle = new Label();
            this.grpRoleDetails = new GroupBox();
            this.lblRoleName = new Label();
            this.txtRoleName = new TextBox();
            this.btnAdd = new Button();
            this.btnClear = new Button();
            this.dgvRoles = new DataGridView();
            this.grpRoleDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoles)).BeginInit();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = false;
            this.lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.FromArgb(52, 73, 94);
            this.lblTitle.Location = new Point(30, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(400, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Role Management";

            // grpRoleDetails
            this.grpRoleDetails.Controls.Add(this.btnClear);
            this.grpRoleDetails.Controls.Add(this.btnAdd);
            this.grpRoleDetails.Controls.Add(this.txtRoleName);
            this.grpRoleDetails.Controls.Add(this.lblRoleName);
            this.grpRoleDetails.Font = new Font("Segoe UI", 10F);
            this.grpRoleDetails.Location = new Point(30, 70);
            this.grpRoleDetails.Name = "grpRoleDetails";
            this.grpRoleDetails.Padding = new Padding(15);
            this.grpRoleDetails.Size = new Size(800, 180);
            this.grpRoleDetails.TabIndex = 1;
            this.grpRoleDetails.TabStop = false;
            this.grpRoleDetails.Text = "Role Details";

            // lblRoleName
            this.lblRoleName.AutoSize = true;
            this.lblRoleName.Font = new Font("Segoe UI", 11F);
            this.lblRoleName.Location = new Point(20, 40);
            this.lblRoleName.Name = "lblRoleName";
            this.lblRoleName.Size = new Size(85, 20);
            this.lblRoleName.TabIndex = 0;
            this.lblRoleName.Text = "Role Name:";

            // txtRoleName
            this.txtRoleName.Font = new Font("Segoe UI", 11F);
            this.txtRoleName.Location = new Point(20, 65);
            this.txtRoleName.Name = "txtRoleName";
            this.txtRoleName.Size = new Size(350, 27);
            this.txtRoleName.TabIndex = 1;

            // btnAdd
            this.btnAdd.BackColor = Color.FromArgb(46, 204, 113);
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = FlatStyle.Flat;
            this.btnAdd.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.btnAdd.ForeColor = Color.White;
            this.btnAdd.Location = new Point(20, 115);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new Size(130, 45);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add Role";
            this.btnAdd.Cursor = Cursors.Hand;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new EventHandler(this.btnAdd_Click);

            // btnClear
            this.btnClear.BackColor = Color.FromArgb(149, 165, 166);
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = FlatStyle.Flat;
            this.btnClear.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.btnClear.ForeColor = Color.White;
            this.btnClear.Location = new Point(165, 115);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new Size(130, 45);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clear";
            this.btnClear.Cursor = Cursors.Hand;
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new EventHandler(this.btnClear_Click);

            // dgvRoles
            this.dgvRoles.AllowUserToAddRows = false;
            this.dgvRoles.AllowUserToDeleteRows = false;
            this.dgvRoles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRoles.BackgroundColor = Color.White;
            this.dgvRoles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRoles.Location = new Point(30, 270);
            this.dgvRoles.Name = "dgvRoles";
            this.dgvRoles.ReadOnly = true;
            this.dgvRoles.RowHeadersWidth = 51;
            this.dgvRoles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvRoles.Size = new Size(800, 350);
            this.dgvRoles.TabIndex = 2;
            this.dgvRoles.CellClick += new DataGridViewCellEventHandler(this.dgvRoles_CellClick);

            // RoleManagementControl
            this.BackColor = Color.FromArgb(236, 240, 241);
            this.Controls.Add(this.dgvRoles);
            this.Controls.Add(this.grpRoleDetails);
            this.Controls.Add(this.lblTitle);
            this.Name = "RoleManagementControl";
            this.Size = new Size(1200, 700);
            this.grpRoleDetails.ResumeLayout(false);
            this.grpRoleDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoles)).EndInit();
            this.ResumeLayout(false);
        }

        private void LoadRoles()
        {
            try
            {
                var roles = roleDAL.GetAllRoles();
                dgvRoles.DataSource = roles;

                if (dgvRoles.Columns["RoleID"] != null)
                    dgvRoles.Columns["RoleID"]!.HeaderText = "Role ID";
                if (dgvRoles.Columns["RoleName"] != null)
                    dgvRoles.Columns["RoleName"]!.HeaderText = "Role Name";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading roles: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRoleName.Text))
            {
                MessageBox.Show("Please enter role name.", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Role role = new Role
                {
                    RoleName = txtRoleName.Text.Trim()
                };

                if (roleDAL.AddRole(role))
                {
                    MessageBox.Show("Role added successfully!", "Success", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    LoadRoles();
                }
                else
                {
                    MessageBox.Show("Failed to add role.", "Error", 
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

        private void dgvRoles_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvRoles.Rows[e.RowIndex];
                selectedRoleID = Convert.ToInt32(row.Cells["RoleID"].Value);
                txtRoleName.Text = row.Cells["RoleName"].Value.ToString();
            }
        }

        private void ClearForm()
        {
            selectedRoleID = 0;
            txtRoleName.Clear();
            txtRoleName.Focus();
        }
    }
}
