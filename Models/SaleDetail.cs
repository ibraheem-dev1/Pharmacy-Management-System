namespace PharmacyWinFormsApp.Models
{
    public class SaleDetail
    {
        public int SaleID { get; set; }
        public int BatchID { get; set; }
        public int QuantitySold { get; set; }
        public decimal SellingPrice { get; set; }

        // For display purposes
        public string MedicineName { get; set; } = string.Empty;
        public string BatchNumber { get; set; } = string.Empty;
        public DateTime ExpiryDate { get; set; }
    }
}