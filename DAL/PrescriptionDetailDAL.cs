using PharmacyWinFormsApp.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace PharmacyWinFormsApp.DAL
{
    public class PrescriptionDetailDAL
    {
        public bool AddPrescriptionDetail(PrescriptionDetail detail)
        {
            using (SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_AddPrescriptionDetail", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PrescriptionID", detail.PrescriptionID);
                    command.Parameters.AddWithValue("@MedicineID", detail.MedicineID);
                    command.Parameters.AddWithValue("@Dosage", detail.Dosage);
                    command.Parameters.AddWithValue("@Frequency", detail.Frequency);
                    command.Parameters.AddWithValue("@DurationDays", detail.DurationDays);
                    return Convert.ToInt32(command.ExecuteScalar()) > 0;
                }
            }
        }

        public List<PrescriptionDetail> GetPrescriptionDetails(int prescriptionID)
        {
            List<PrescriptionDetail> details = new List<PrescriptionDetail>();
            using (SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_GetPrescriptionDetails", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PrescriptionID", prescriptionID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            details.Add(new PrescriptionDetail
                            {
                                PrescriptionID = (int)reader["PrescriptionID"],
                                MedicineID = (int)reader["MedicineID"],
                                Dosage = reader["Dosage"].ToString() ?? "",
                                Frequency = reader["Frequency"].ToString() ?? "",
                                DurationDays = (int)reader["DurationDays"],
                                MedicineName = reader["MedicineName"].ToString() ?? ""
                            });
                        }
                    }
                }
            }
            return details;
        }

        public bool ValidatePrescriptionMedicine(int prescriptionID, int medicineID)
        {
            using (SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_ValidatePrescriptionMedicine", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PrescriptionID", prescriptionID);
                    command.Parameters.AddWithValue("@MedicineID", medicineID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return Convert.ToInt32(reader["IsValid"]) == 1;
                        }
                    }
                }
            }
            return false;
        }

        public List<int> GetMedicineIDsByPrescription(int prescriptionID)
        {
            List<int> medicineIDs = new List<int>();
            using (SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_GetMedicinesByPrescription", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PrescriptionID", prescriptionID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            medicineIDs.Add((int)reader["MedicineID"]);
                        }
                    }
                }
            }
            return medicineIDs;
        }
    }
}