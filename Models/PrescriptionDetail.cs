namespace PharmacyWinFormsApp.Models
{
    public class PrescriptionDetail
    {
        public int PrescriptionID { get; set; }
        public int MedicineID { get; set; }
        public string Dosage { get; set; } = string.Empty;
        public string Frequency { get; set; } = string.Empty;
        public int DurationDays { get; set; }

        // For display purposes
        public string MedicineName { get; set; } = string.Empty;
    }
}