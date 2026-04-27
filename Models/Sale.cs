namespace PharmacyWinFormsApp.Models
{
    public class Sale
    {
        public int SaleID { get; set; }
        public int UserID { get; set; }
        public int? CustomerID { get; set; }
        public int? PrescriptionID { get; set; }
        public DateTime SaleDate { get; set; }
        public decimal TotalAmount { get; set; }

        // For display purposes
        public string UserName { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
    }
}