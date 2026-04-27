using PharmacyWinFormsApp.Models;
using System.Data;
using Microsoft.Data.SqlClient;

namespace PharmacyWinFormsApp.DAL
{
    public class SupplierMedicineDAL
    {
        public bool AddSupplierMedicine(int supplierID, int medicineID)
        {
            using (SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_AddSupplierMedicine", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@SupplierID", supplierID);
                    command.Parameters.AddWithValue("@MedicineID", medicineID);
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool RemoveSupplierMedicine(int supplierID, int medicineID)
        {
            using (SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_RemoveSupplierMedicine", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@SupplierID", supplierID);
                    command.Parameters.AddWithValue("@MedicineID", medicineID);
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public List<Medicine> GetMedicinesBySupplier(int supplierID)
        {
            List<Medicine> medicines = new List<Medicine>();
            using (SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_GetMedicinesBySupplier", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@SupplierID", supplierID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            medicines.Add(new Medicine
                            {
                                MedicineID = (int)reader["MedicineID"],
                                Name = reader["Name"].ToString() ?? "",
                                StrengthMG = (int)reader["StrengthMG"]
                            });
                        }
                    }
                }
            }
            return medicines;
        }
    }
}