namespace PharmacyWinFormsApp.Models
{
    public class Prescription
    {
        public int PrescriptionID { get; set; }
        public int CustomerID { get; set; }
        public string DoctorName { get; set; } = string.Empty;
        public DateTime PrescriptionDate { get; set; }
        public string Notes { get; set; } = string.Empty;

        // For display purposes
        public string CustomerName { get; set; } = string.Empty;
        public string PrescriptionDisplay => $"Rx#{PrescriptionID} - {CustomerName} - {PrescriptionDate:MM/dd/yyyy}";
    }
}