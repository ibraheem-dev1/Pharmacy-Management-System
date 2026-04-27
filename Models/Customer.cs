namespace PharmacyWinFormsApp.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string ContactNo { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }
}