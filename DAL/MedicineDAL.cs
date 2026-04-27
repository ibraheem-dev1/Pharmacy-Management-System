using PharmacyWinFormsApp.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace PharmacyWinFormsApp.DAL
{
    public class MedicineDAL
    {
        public List<string> GetDistinctMedicineNames()
        {
            List<string> names = new List<string>();
            using (SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_GetDistinctMedicineNames", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            names.Add(reader["Name"].ToString() ?? "");
                        }
                    }
                }
            }
            return names;
        }

        public List<Medicine> GetMedicineVariants(string medicineName)
        {
            List<Medicine> medicines = new List<Medicine>();
            using (SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_GetMedicineVariants", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MedicineName", medicineName);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            medicines.Add(new Medicine
                            {
                                MedicineID = (int)reader["MedicineID"],
                                Name = reader["Name"].ToString() ?? "",
                                StrengthMG = (int)reader["StrengthMG"],
                                FormulaID = (int)reader["FormulaID"],
                                FormulaName = reader["FormulaName"].ToString() ?? ""
                            });
                        }
                    }
                }
            }
            return medicines;
        }

        public List<Medicine> GetAllMedicines()
        {
            List<Medicine> medicines = new List<Medicine>();
            using (SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_GetAllMedicines", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            medicines.Add(new Medicine
                            {
                                MedicineID = (int)reader["MedicineID"],
                                Name = reader["Name"].ToString() ?? "",
                                StrengthMG = (int)reader["StrengthMG"],
                                MinimumStockLevel = (int)reader["MinimumStockLevel"],
                                IsPrescriptionRequired = (bool)reader["IsPrescriptionRequired"],
                                IsActive = (bool)reader["IsActive"],
                                CategoryID = (int)reader["CategoryID"],
                                ManufacturerID = (int)reader["ManufacturerID"],
                                FormulaID = (int)reader["FormulaID"],
                                CategoryName = reader["CategoryName"].ToString() ?? "",
                                ManufacturerName = reader["ManufacturerName"].ToString() ?? "",
                                FormulaName = reader["FormulaName"].ToString() ?? "",
                                TotalStock = (int)reader["TotalStock"]
                            });
                        }
                    }
                }
            }
            return medicines;
        }

        public bool AddMedicine(Medicine medicine)
        {
            using (SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_AddMedicine", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Name", medicine.Name);
                    command.Parameters.AddWithValue("@StrengthMG", medicine.StrengthMG);
                    command.Parameters.AddWithValue("@MinimumStockLevel", medicine.MinimumStockLevel);
                    command.Parameters.AddWithValue("@IsPrescriptionRequired", medicine.IsPrescriptionRequired);
                    command.Parameters.AddWithValue("@IsActive", medicine.IsActive);
                    command.Parameters.AddWithValue("@CategoryID", medicine.CategoryID);
                    command.Parameters.AddWithValue("@ManufacturerID", medicine.ManufacturerID);
                    command.Parameters.AddWithValue("@FormulaID", medicine.FormulaID);
                    return Convert.ToInt32(command.ExecuteScalar()) > 0;
                }
            }
        }

        public bool UpdateMedicine(Medicine medicine)
        {
            using (SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_UpdateMedicine", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MedicineID", medicine.MedicineID);
                    command.Parameters.AddWithValue("@Name", medicine.Name);
                    command.Parameters.AddWithValue("@StrengthMG", medicine.StrengthMG);
                    command.Parameters.AddWithValue("@MinimumStockLevel", medicine.MinimumStockLevel);
                    command.Parameters.AddWithValue("@IsPrescriptionRequired", medicine.IsPrescriptionRequired);
                    command.Parameters.AddWithValue("@IsActive", medicine.IsActive);
                    command.Parameters.AddWithValue("@CategoryID", medicine.CategoryID);
                    command.Parameters.AddWithValue("@ManufacturerID", medicine.ManufacturerID);
                    command.Parameters.AddWithValue("@FormulaID", medicine.FormulaID);
                    return Convert.ToInt32(command.ExecuteScalar()) > 0;
                }
            }
        }

        public bool DeactivateMedicine(int medicineID)
        {
            using (SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_DeactivateMedicine", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MedicineID", medicineID);
                    return Convert.ToInt32(command.ExecuteScalar()) > 0;
                }
            }
        }

        public List<Medicine> GetMedicinesWithLowStock()
        {
            List<Medicine> medicines = new List<Medicine>();
            using (SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_GetMedicinesWithLowStock", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            medicines.Add(new Medicine
                            {
                                MedicineID = (int)reader["MedicineID"],
                                Name = reader["Name"].ToString() ?? "",
                                StrengthMG = (int)reader["StrengthMG"],
                                MinimumStockLevel = (int)reader["MinimumStockLevel"],
                                TotalStock = (int)reader["TotalStock"]
                            });
                        }
                    }
                }
            }
            return medicines;
        }

        public List<Medicine> GetMedicinesWithStock()
        {
            List<Medicine> medicines = new List<Medicine>();
            using (SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_GetMedicinesWithStock", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            medicines.Add(new Medicine
                            {
                                MedicineID = (int)reader["MedicineID"],
                                Name = reader["Name"].ToString() ?? "",
                                StrengthMG = (int)reader["StrengthMG"],
                                MinimumStockLevel = (int)reader["MinimumStockLevel"],
                                IsPrescriptionRequired = (bool)reader["IsPrescriptionRequired"],
                                IsActive = (bool)reader["IsActive"],
                                CategoryID = (int)reader["CategoryID"],
                                ManufacturerID = (int)reader["ManufacturerID"],
                                FormulaID = (int)reader["FormulaID"],
                                CategoryName = reader["CategoryName"].ToString() ?? "",
                                ManufacturerName = reader["ManufacturerName"].ToString() ?? "",
                                FormulaName = reader["FormulaName"].ToString() ?? "",
                                TotalStock = (int)reader["TotalStock"]
                            });
                        }
                    }
                }
            }
            return medicines;
        }

        public DataTable GetMedicineDetails(int medicineID)
        {
            using (SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_GetMedicineDetails", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MedicineID", medicineID);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }
    }
}