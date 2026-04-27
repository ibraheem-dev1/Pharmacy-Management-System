namespace PharmacyWinFormsApp.Models
{
    public class Salary
    {
        public int SalaryID { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; } = string.Empty;
        public int Month { get; set; }
        public int Year { get; set; }
        public decimal BasicSalary { get; set; }
        public decimal Bonus { get; set; }
        public decimal Deductions { get; set; }
        public decimal NetSalary { get; set; }
        public DateTime RecordedDate { get; set; }
        public int RecordedBy { get; set; }
        public string RecordedByName { get; set; } = string.Empty;
    }
}
