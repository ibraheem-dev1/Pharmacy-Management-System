using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using PharmacyWinFormsApp.DAL;

namespace PharmacyWinFormsApp.Forms.Purchases
{
    public partial class PurchaseDetailsForm : Form
    {
        private int purchaseID;
        private Panel pnlPurchaseInfo = null!;
        private Label lblPurchaseInfoTitle = null!;
        private Label lblPurchaseDate = null!;
        private Label lblTotalAmount = null!;
        private DataGridView dgvPurchaseDetails = null!;

        public PurchaseDetailsForm(int purchaseID)
        {
            this.purchaseID = purchaseID;
            InitializeComponent();
            LoadPurchaseDetails();
        }

        private void InitializeComponent()
        {
            this.Text = "Purchase Details";
            this.ClientSize = new Size(1000, 700);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.White;

            // Panel for Purchase Info
            this.pnlPurchaseInfo = new Panel();
            this.pnlPurchaseInfo.BackColor = Color.FromArgb(52, 152, 219);
            this.pnlPurchaseInfo.Location = new Point(20, 20);
            this.pnlPurchaseInfo.Size = new Size(940, 120);
            this.pnlPurchaseInfo.Padding = new Padding(15);

            // Title
            this.lblPurchaseInfoTitle = new Label();
            this.lblPurchaseInfoTitle.Text = "Purchase Information";
            this.lblPurchaseInfoTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblPurchaseInfoTitle.ForeColor = Color.White;
            this.lblPurchaseInfoTitle.Location = new Point(15, 15);
            this.lblPurchaseInfoTitle.Size = new Size(500, 35);

            // Purchase Date
            this.lblPurchaseDate = new Label();
            this.lblPurchaseDate.Font = new Font("Segoe UI", 11F);
            this.lblPurchaseDate.ForeColor = Color.White;
            this.lblPurchaseDate.Location = new Point(15, 55);
            this.lblPurchaseDate.Size = new Size(500, 25);

            // Total Amount
            this.lblTotalAmount = new Label();
            this.lblTotalAmount.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblTotalAmount.ForeColor = Color.White;
            this.lblTotalAmount.Location = new Point(15, 85);
            this.lblTotalAmount.Size = new Size(500, 25);

            this.pnlPurchaseInfo.Controls.Add(this.lblPurchaseInfoTitle);
            this.pnlPurchaseInfo.Controls.Add(this.lblPurchaseDate);
            this.pnlPurchaseInfo.Controls.Add(this.lblTotalAmount);

            // DataGridView for Medicine Batches
            this.dgvPurchaseDetails = new DataGridView();
            this.dgvPurchaseDetails.Location = new Point(20, 160);
            this.dgvPurchaseDetails.Size = new Size(940, 480);
            this.dgvPurchaseDetails.AllowUserToAddRows = false;
            this.dgvPurchaseDetails.AllowUserToDeleteRows = false;
            this.dgvPurchaseDetails.ReadOnly = true;
            this.dgvPurchaseDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPurchaseDetails.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvPurchaseDetails.BackgroundColor = Color.White;
            this.dgvPurchaseDetails.RowHeadersVisible = false;
            this.dgvPurchaseDetails.RowTemplate.Height = 32;
            this.dgvPurchaseDetails.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 152, 219);
            this.dgvPurchaseDetails.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgvPurchaseDetails.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.dgvPurchaseDetails.ColumnHeadersDefaultCellStyle.Padding = new Padding(5);
            this.dgvPurchaseDetails.ColumnHeadersHeight = 40;
            this.dgvPurchaseDetails.EnableHeadersVisualStyles = false;

            this.Controls.Add(this.pnlPurchaseInfo);
            this.Controls.Add(this.dgvPurchaseDetails);
        }

        private void LoadPurchaseDetails()
        {
            try
            {
                using (SqlConnection connection = Database.GetConnection())
                {
                    connection.Open();
                    string query = @"
                        SELECT 
                            p.PurchaseID,
                            p.PurchaseDate,
                            p.TotalAmount,

                            mb.BatchID,
                            mb.BatchNumber,
                            mb.ExpiryDate,
                            mb.PurchasePrice,
                            mb.QuantityInStock,

                            m.MedicineID,
                            m.Name as MedicineName,
                            m.StrengthMG,

                            s.SupplierID,
                            s.SupplierName

                        FROM Purchase p
                        LEFT JOIN MedicineBatch mb 
                            ON p.PurchaseID = mb.PurchaseID
                        LEFT JOIN Medicine m 
                            ON mb.MedicineID = m.MedicineID
                        LEFT JOIN Supplier s 
                            ON mb.SupplierID = s.SupplierID

                        WHERE p.PurchaseID = @PurchaseID";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@PurchaseID", purchaseID);
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        if (dataTable.Rows.Count > 0)
                        {
                            // Fill purchase info
                            DataRow firstRow = dataTable.Rows[0];
                            lblPurchaseDate.Text = $"Purchase Date: {Convert.ToDateTime(firstRow["PurchaseDate"]):dd-MMM-yyyy}";
                            lblTotalAmount.Text = $"Total Amount: Rs. {Convert.ToDecimal(firstRow["TotalAmount"]):N2}";

                            // Prepare data for grid
                            DataTable gridData = new DataTable();
                            gridData.Columns.Add("Medicine", typeof(string));
                            gridData.Columns.Add("Strength (MG)", typeof(int));
                            gridData.Columns.Add("Batch Number", typeof(string));
                            gridData.Columns.Add("Supplier", typeof(string));
                            gridData.Columns.Add("Quantity", typeof(int));
                            gridData.Columns.Add("Purchase Price", typeof(decimal));
                            gridData.Columns.Add("Expiry Date", typeof(string));
                            gridData.Columns.Add("Subtotal", typeof(decimal));

                            foreach (DataRow row in dataTable.Rows)
                            {
                                if (row["MedicineName"] != DBNull.Value)
                                {
                                    int quantity = Convert.ToInt32(row["QuantityInStock"]);
                                    decimal purchasePrice = Convert.ToDecimal(row["PurchasePrice"]);
                                    decimal subtotal = quantity * purchasePrice;

                                    gridData.Rows.Add(
                                        row["MedicineName"],
                                        row["StrengthMG"],
                                        row["BatchNumber"],
                                        row["SupplierName"],
                                        quantity,
                                        purchasePrice,
                                        Convert.ToDateTime(row["ExpiryDate"]).ToString("dd-MMM-yyyy"),
                                        subtotal
                                    );
                                }
                            }

                            dgvPurchaseDetails.DataSource = gridData;

                            // Format currency columns
                            dgvPurchaseDetails.Columns["Purchase Price"].DefaultCellStyle.Format = "N2";
                            dgvPurchaseDetails.Columns["Subtotal"].DefaultCellStyle.Format = "N2";
                            dgvPurchaseDetails.Columns["Subtotal"].DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading purchase details: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
