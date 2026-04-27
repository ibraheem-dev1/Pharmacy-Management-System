namespace PharmacyWinFormsApp.Forms
{
    partial class InventoryManagementControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabAvailable = new System.Windows.Forms.TabPage();
            this.dgvAvailableInventory = new System.Windows.Forms.DataGridView();
            this.panelAvailableFooter = new System.Windows.Forms.Panel();
            this.lblAvailableCount = new System.Windows.Forms.Label();
            this.panelLegendAvailable = new System.Windows.Forms.Panel();
            this.lblLegendExpiring = new System.Windows.Forms.Label();
            this.pnlColorExpiring = new System.Windows.Forms.Panel();
            this.lblLegendLowStock = new System.Windows.Forms.Label();
            this.pnlColorLowStock = new System.Windows.Forms.Panel();
            this.tabExpired = new System.Windows.Forms.TabPage();
            this.dgvExpiredInventory = new System.Windows.Forms.DataGridView();
            this.panelExpiredFooter = new System.Windows.Forms.Panel();
            this.lblExpiredCount = new System.Windows.Forms.Label();
            this.tabOutOfStock = new System.Windows.Forms.TabPage();
            this.dgvOutOfStock = new System.Windows.Forms.DataGridView();
            this.panelOutOfStockFooter = new System.Windows.Forms.Panel();
            this.lblOutOfStockCount = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabAvailable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailableInventory)).BeginInit();
            this.panelAvailableFooter.SuspendLayout();
            this.panelLegendAvailable.SuspendLayout();
            this.tabExpired.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpiredInventory)).BeginInit();
            this.panelExpiredFooter.SuspendLayout();
            this.tabOutOfStock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutOfStock)).BeginInit();
            this.panelOutOfStockFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.White;
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Controls.Add(this.btnRefresh);
            this.panelHeader.Controls.Add(this.txtSearch);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Padding = new System.Windows.Forms.Padding(20);
            this.panelHeader.Size = new System.Drawing.Size(1200, 120);
            this.panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(274, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "📦 Inventory Status";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(1050, 70);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(130, 35);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "🔄 Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSearch.ForeColor = System.Drawing.Color.Gray;
            this.txtSearch.Location = new System.Drawing.Point(20, 70);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "🔍 Search by medicine name or batch number...";
            this.txtSearch.Size = new System.Drawing.Size(1010, 27);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabAvailable);
            this.tabControl.Controls.Add(this.tabExpired);
            this.tabControl.Controls.Add(this.tabOutOfStock);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabControl.Location = new System.Drawing.Point(0, 120);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1200, 580);
            this.tabControl.TabIndex = 1;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabAvailable
            // 
            this.tabAvailable.Controls.Add(this.dgvAvailableInventory);
            this.tabAvailable.Controls.Add(this.panelAvailableFooter);
            this.tabAvailable.Location = new System.Drawing.Point(4, 29);
            this.tabAvailable.Name = "tabAvailable";
            this.tabAvailable.Padding = new System.Windows.Forms.Padding(10);
            this.tabAvailable.Size = new System.Drawing.Size(1192, 547);
            this.tabAvailable.TabIndex = 0;
            this.tabAvailable.Text = "✅ Available Inventory";
            this.tabAvailable.UseVisualStyleBackColor = true;
            // 
            // dgvAvailableInventory
            // 
            this.dgvAvailableInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAvailableInventory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAvailableInventory.Location = new System.Drawing.Point(10, 10);
            this.dgvAvailableInventory.Name = "dgvAvailableInventory";
            this.dgvAvailableInventory.RowTemplate.Height = 25;
            this.dgvAvailableInventory.Size = new System.Drawing.Size(1172, 447);
            this.dgvAvailableInventory.TabIndex = 0;
            this.dgvAvailableInventory.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAvailableInventory_CellClick);
            this.dgvAvailableInventory.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvAvailableInventory_DataBindingComplete);
            // 
            // panelAvailableFooter
            // 
            this.panelAvailableFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.panelAvailableFooter.Controls.Add(this.lblAvailableCount);
            this.panelAvailableFooter.Controls.Add(this.panelLegendAvailable);
            this.panelAvailableFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelAvailableFooter.Location = new System.Drawing.Point(10, 457);
            this.panelAvailableFooter.Name = "panelAvailableFooter";
            this.panelAvailableFooter.Padding = new System.Windows.Forms.Padding(10);
            this.panelAvailableFooter.Size = new System.Drawing.Size(1172, 80);
            this.panelAvailableFooter.TabIndex = 1;
            // 
            // lblAvailableCount
            // 
            this.lblAvailableCount.AutoSize = true;
            this.lblAvailableCount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblAvailableCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblAvailableCount.Location = new System.Drawing.Point(10, 30);
            this.lblAvailableCount.Name = "lblAvailableCount";
            this.lblAvailableCount.Size = new System.Drawing.Size(79, 19);
            this.lblAvailableCount.TabIndex = 0;
            this.lblAvailableCount.Text = "Total: 0 batches";
            // 
            // panelLegendAvailable
            // 
            this.panelLegendAvailable.Controls.Add(this.lblLegendExpiring);
            this.panelLegendAvailable.Controls.Add(this.pnlColorExpiring);
            this.panelLegendAvailable.Controls.Add(this.lblLegendLowStock);
            this.panelLegendAvailable.Controls.Add(this.pnlColorLowStock);
            this.panelLegendAvailable.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelLegendAvailable.Location = new System.Drawing.Point(682, 10);
            this.panelLegendAvailable.Name = "panelLegendAvailable";
            this.panelLegendAvailable.Size = new System.Drawing.Size(480, 60);
            this.panelLegendAvailable.TabIndex = 1;
            // 
            // lblLegendExpiring
            // 
            this.lblLegendExpiring.AutoSize = true;
            this.lblLegendExpiring.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblLegendExpiring.Location = new System.Drawing.Point(40, 20);
            this.lblLegendExpiring.Name = "lblLegendExpiring";
            this.lblLegendExpiring.Size = new System.Drawing.Size(160, 15);
            this.lblLegendExpiring.TabIndex = 1;
            this.lblLegendExpiring.Text = "Expiring Soon (within 30 days)";
            // 
            // pnlColorExpiring
            // 
            this.pnlColorExpiring.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(200)))), ((int)(((byte)(100)))));
            this.pnlColorExpiring.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlColorExpiring.Location = new System.Drawing.Point(10, 18);
            this.pnlColorExpiring.Name = "pnlColorExpiring";
            this.pnlColorExpiring.Size = new System.Drawing.Size(20, 20);
            this.pnlColorExpiring.TabIndex = 0;
            // 
            // lblLegendLowStock
            // 
            this.lblLegendLowStock.AutoSize = true;
            this.lblLegendLowStock.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblLegendLowStock.Location = new System.Drawing.Point(280, 20);
            this.lblLegendLowStock.Name = "lblLegendLowStock";
            this.lblLegendLowStock.Size = new System.Drawing.Size(188, 15);
            this.lblLegendLowStock.TabIndex = 3;
            this.lblLegendLowStock.Text = "Low Stock (Below Minimum Level)";
            // 
            // pnlColorLowStock
            // 
            this.pnlColorLowStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.pnlColorLowStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlColorLowStock.Location = new System.Drawing.Point(250, 18);
            this.pnlColorLowStock.Name = "pnlColorLowStock";
            this.pnlColorLowStock.Size = new System.Drawing.Size(20, 20);
            this.pnlColorLowStock.TabIndex = 2;
            // 
            // tabExpired
            // 
            this.tabExpired.Controls.Add(this.dgvExpiredInventory);
            this.tabExpired.Controls.Add(this.panelExpiredFooter);
            this.tabExpired.Location = new System.Drawing.Point(4, 29);
            this.tabExpired.Name = "tabExpired";
            this.tabExpired.Padding = new System.Windows.Forms.Padding(10);
            this.tabExpired.Size = new System.Drawing.Size(1192, 547);
            this.tabExpired.TabIndex = 1;
            this.tabExpired.Text = "❌ Expired Medicines";
            this.tabExpired.UseVisualStyleBackColor = true;
            // 
            // dgvExpiredInventory
            // 
            this.dgvExpiredInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExpiredInventory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvExpiredInventory.Location = new System.Drawing.Point(10, 10);
            this.dgvExpiredInventory.Name = "dgvExpiredInventory";
            this.dgvExpiredInventory.RowTemplate.Height = 25;
            this.dgvExpiredInventory.Size = new System.Drawing.Size(1172, 467);
            this.dgvExpiredInventory.TabIndex = 0;
            this.dgvExpiredInventory.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvExpiredInventory_CellClick);
            this.dgvExpiredInventory.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvExpiredInventory_DataBindingComplete);
            // 
            // panelExpiredFooter
            // 
            this.panelExpiredFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.panelExpiredFooter.Controls.Add(this.lblExpiredCount);
            this.panelExpiredFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelExpiredFooter.Location = new System.Drawing.Point(10, 477);
            this.panelExpiredFooter.Name = "panelExpiredFooter";
            this.panelExpiredFooter.Padding = new System.Windows.Forms.Padding(10);
            this.panelExpiredFooter.Size = new System.Drawing.Size(1172, 60);
            this.panelExpiredFooter.TabIndex = 1;
            // 
            // lblExpiredCount
            // 
            this.lblExpiredCount.AutoSize = true;
            this.lblExpiredCount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblExpiredCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.lblExpiredCount.Location = new System.Drawing.Point(10, 20);
            this.lblExpiredCount.Name = "lblExpiredCount";
            this.lblExpiredCount.Size = new System.Drawing.Size(79, 19);
            this.lblExpiredCount.TabIndex = 0;
            this.lblExpiredCount.Text = "Total: 0 batches";
            // 
            // tabOutOfStock
            // 
            this.tabOutOfStock.Controls.Add(this.dgvOutOfStock);
            this.tabOutOfStock.Controls.Add(this.panelOutOfStockFooter);
            this.tabOutOfStock.Location = new System.Drawing.Point(4, 29);
            this.tabOutOfStock.Name = "tabOutOfStock";
            this.tabOutOfStock.Padding = new System.Windows.Forms.Padding(10);
            this.tabOutOfStock.Size = new System.Drawing.Size(1192, 547);
            this.tabOutOfStock.TabIndex = 2;
            this.tabOutOfStock.Text = "⚠️ Out of Stock";
            this.tabOutOfStock.UseVisualStyleBackColor = true;
            // 
            // dgvOutOfStock
            // 
            this.dgvOutOfStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOutOfStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOutOfStock.Location = new System.Drawing.Point(10, 10);
            this.dgvOutOfStock.Name = "dgvOutOfStock";
            this.dgvOutOfStock.RowTemplate.Height = 25;
            this.dgvOutOfStock.Size = new System.Drawing.Size(1172, 467);
            this.dgvOutOfStock.TabIndex = 0;
            this.dgvOutOfStock.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOutOfStock_CellClick);
            this.dgvOutOfStock.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvOutOfStock_DataBindingComplete);
            // 
            // panelOutOfStockFooter
            // 
            this.panelOutOfStockFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.panelOutOfStockFooter.Controls.Add(this.lblOutOfStockCount);
            this.panelOutOfStockFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelOutOfStockFooter.Location = new System.Drawing.Point(10, 477);
            this.panelOutOfStockFooter.Name = "panelOutOfStockFooter";
            this.panelOutOfStockFooter.Padding = new System.Windows.Forms.Padding(10);
            this.panelOutOfStockFooter.Size = new System.Drawing.Size(1172, 60);
            this.panelOutOfStockFooter.TabIndex = 1;
            // 
            // lblOutOfStockCount
            // 
            this.lblOutOfStockCount.AutoSize = true;
            this.lblOutOfStockCount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblOutOfStockCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.lblOutOfStockCount.Location = new System.Drawing.Point(10, 20);
            this.lblOutOfStockCount.Name = "lblOutOfStockCount";
            this.lblOutOfStockCount.Size = new System.Drawing.Size(79, 19);
            this.lblOutOfStockCount.TabIndex = 0;
            this.lblOutOfStockCount.Text = "Total: 0 medicines";
            // 
            // InventoryManagementControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.panelHeader);
            this.Name = "InventoryManagementControl";
            this.Size = new System.Drawing.Size(1200, 700);
            this.Load += new System.EventHandler(this.InventoryManagementControl_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabAvailable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailableInventory)).EndInit();
            this.panelAvailableFooter.ResumeLayout(false);
            this.panelAvailableFooter.PerformLayout();
            this.panelLegendAvailable.ResumeLayout(false);
            this.panelLegendAvailable.PerformLayout();
            this.tabExpired.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpiredInventory)).EndInit();
            this.panelExpiredFooter.ResumeLayout(false);
            this.panelExpiredFooter.PerformLayout();
            this.tabOutOfStock.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutOfStock)).EndInit();
            this.panelOutOfStockFooter.ResumeLayout(false);
            this.panelOutOfStockFooter.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabAvailable;
        private System.Windows.Forms.DataGridView dgvAvailableInventory;
        private System.Windows.Forms.Panel panelAvailableFooter;
        private System.Windows.Forms.Label lblAvailableCount;
        private System.Windows.Forms.Panel panelLegendAvailable;
        private System.Windows.Forms.Label lblLegendExpiring;
        private System.Windows.Forms.Panel pnlColorExpiring;
        private System.Windows.Forms.Label lblLegendLowStock;
        private System.Windows.Forms.Panel pnlColorLowStock;
        private System.Windows.Forms.TabPage tabExpired;
        private System.Windows.Forms.DataGridView dgvExpiredInventory;
        private System.Windows.Forms.Panel panelExpiredFooter;
        private System.Windows.Forms.Label lblExpiredCount;
        private System.Windows.Forms.TabPage tabOutOfStock;
        private System.Windows.Forms.DataGridView dgvOutOfStock;
        private System.Windows.Forms.Panel panelOutOfStockFooter;
        private System.Windows.Forms.Label lblOutOfStockCount;
    }
}
