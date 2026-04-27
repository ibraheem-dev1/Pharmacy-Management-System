using PharmacyWinFormsApp.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace PharmacyWinFormsApp.DAL
{
    public class PrescriptionDAL
    {
        public int AddPrescription(Prescription prescription)
        {
            using (SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_AddPrescription", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CustomerID", prescription.CustomerID);
                    command.Parameters.AddWithValue("@DoctorName", prescription.DoctorName);
                    command.Parameters.AddWithValue("@PrescriptionDate", prescription.PrescriptionDate);
                    command.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(prescription.Notes) ? DBNull.Value : prescription.Notes);
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        public List<Prescription> GetAllPrescriptions()
        {
            List<Prescription> prescriptions = new List<Prescription>();
            using (SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_GetAllPrescriptions", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            prescriptions.Add(new Prescription
                            {
                                PrescriptionID = (int)reader["PrescriptionID"],
                                CustomerID = (int)reader["CustomerID"],
                                DoctorName = reader["DoctorName"].ToString() ?? "",
                                PrescriptionDate = (DateTime)reader["PrescriptionDate"],
                                Notes = reader["Notes"] == DBNull.Value ? "" : reader["Notes"].ToString() ?? "",
                                CustomerName = reader["CustomerName"].ToString() ?? ""
                            });
                        }
                    }
                }
            }
            return prescriptions;
        }

        public bool UpdatePrescription(Prescription prescription)
        {
            using (SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_UpdatePrescription", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PrescriptionID", prescription.PrescriptionID);
                    command.Parameters.AddWithValue("@CustomerID", prescription.CustomerID);
                    command.Parameters.AddWithValue("@DoctorName", prescription.DoctorName);
                    command.Parameters.AddWithValue("@PrescriptionDate", prescription.PrescriptionDate);
                    command.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(prescription.Notes) ? DBNull.Value : prescription.Notes);
                    return Convert.ToInt32(command.ExecuteScalar()) > 0;
                }
            }
        }

        public List<Prescription> GetPrescriptionsByDate(DateTime date)
        {
            List<Prescription> prescriptions = new List<Prescription>();
            using (SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM Prescription WHERE CAST(PrescriptionDate AS DATE) = @Date", connection))
                {
                    command.Parameters.AddWithValue("@Date", date.Date);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            prescriptions.Add(new Prescription
                            {
                                PrescriptionID = (int)reader["PrescriptionID"],
                                CustomerID = (int)reader["CustomerID"],
                                DoctorName = reader["DoctorName"].ToString() ?? "",
                                PrescriptionDate = (DateTime)reader["PrescriptionDate"],
                                Notes = reader["Notes"] == DBNull.Value ? "" : reader["Notes"].ToString() ?? ""
                            });
                        }
                    }
                }
            }
            return prescriptions;
        }
    }
}