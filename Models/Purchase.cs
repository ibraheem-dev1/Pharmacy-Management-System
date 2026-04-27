namespace PharmacyWinFormsApp.Models
{
    public class Purchase
    {
        public int PurchaseID { get; set; }
        public int SupplierID { get; set; }
        public int UserID { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal TotalAmount { get; set; }

        // For display purposes
        public string SupplierName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
    }
}