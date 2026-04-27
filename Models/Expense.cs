namespace PharmacyWinFormsApp.Models
{
    public class Expense
    {
        public int ExpenseID { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string Category { get; set; } = string.Empty;
        public DateTime ExpenseDate { get; set; }
        public DateTime RecordedDate { get; set; }
        public int RecordedBy { get; set; }
        public string RecordedByName { get; set; } = string.Empty;
    }
}
