namespace PharmacyWinFormsApp.Models
{
    public class MedicineBatch
    {
        public int BatchID { get; set; }
        public int MedicineID { get; set; }
        public int SupplierID { get; set; }
        public int PurchaseID { get; set; }
        public string BatchNumber { get; set; } = string.Empty;
        public DateTime ExpiryDate { get; set; }
        public decimal PurchasePrice { get; set; }
        public int QuantityInStock { get; set; }

        // For display purposes
        public string MedicineName { get; set; } = string.Empty;
        public int StrengthMG { get; set; }
        public string SupplierName { get; set; } = string.Empty;
        public int MinimumStockLevel { get; set; }
        public int DaysToExpiry => (ExpiryDate - DateTime.Now).Days;
    }
}