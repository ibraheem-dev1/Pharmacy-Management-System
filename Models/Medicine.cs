namespace PharmacyWinFormsApp.Models
{
    public class Medicine
    {
        public int MedicineID { get; set; }
        public string Name { get; set; } = string.Empty;
        public int StrengthMG { get; set; }
        public int MinimumStockLevel { get; set; }
        public bool IsPrescriptionRequired { get; set; }
        public bool IsActive { get; set; } = true;
        public int CategoryID { get; set; }
        public int ManufacturerID { get; set; }
        public int FormulaID { get; set; }

        // For display purposes
        public string CategoryName { get; set; } = string.Empty;
        public string ManufacturerName { get; set; } = string.Empty;
        public string FormulaName { get; set; } = string.Empty;
        public int TotalStock { get; set; }
        
        public string DisplayName => $"{Name} ({StrengthMG}mg) - {FormulaName}";
    }
}