using PharmacyWinFormsApp.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace PharmacyWinFormsApp.DAL
{
    public class MedicineBatchDAL
    {
        public int AddMedicineBatch(MedicineBatch batch)
        {
            using (SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_AddMedicineBatch", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MedicineID", batch.MedicineID);
                    command.Parameters.AddWithValue("@SupplierID", batch.SupplierID);
                    command.Parameters.AddWithValue("@PurchaseID", batch.PurchaseID);
                    command.Parameters.AddWithValue("@ExpiryDate", batch.ExpiryDate);
                    command.Parameters.AddWithValue("@PurchasePrice", batch.PurchasePrice);
                    command.Parameters.AddWithValue("@QuantityInStock", batch.QuantityInStock);
                    
                    object? result = command.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : 0;
                }
            }
        }

        public List<MedicineBatch> GetAllBatches()
        {
            List<MedicineBatch> batches = new List<MedicineBatch>();
            using (SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_GetAllBatches", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            batches.Add(new MedicineBatch
                            {
                                BatchID = (int)reader["BatchID"],
                                MedicineID = (int)reader["MedicineID"],
                                SupplierID = (int)reader["SupplierID"],
                                PurchaseID = (int)reader["PurchaseID"],
                                BatchNumber = reader["BatchNumber"] == DBNull.Value ? "" : reader["BatchNumber"].ToString() ?? "",
                                ExpiryDate = (DateTime)reader["ExpiryDate"],
                                PurchasePrice = (decimal)reader["PurchasePrice"],
                                QuantityInStock = (int)reader["QuantityInStock"],
                                MedicineName = reader["MedicineName"].ToString() ?? "",
                                StrengthMG = reader["StrengthMG"] != DBNull.Value ? (int)reader["StrengthMG"] : 0,
                                SupplierName = reader["SupplierName"].ToString() ?? "",
                                MinimumStockLevel = reader["MinimumStockLevel"] != DBNull.Value ? (int)reader["MinimumStockLevel"] : 0
                            });
                        }
                    }
                }
            }
            return batches;
        }

        public MedicineBatch? GetEarliestExpiryBatch(int medicineID, int quantityNeeded)
        {
            using (SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_GetEarliestExpiryBatch", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MedicineID", medicineID);
                    command.Parameters.AddWithValue("@QuantityNeeded", quantityNeeded);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new MedicineBatch
                            {
                                BatchID = (int)reader["BatchID"],
                                MedicineID = (int)reader["MedicineID"],
                                SupplierID = (int)reader["SupplierID"],
                                PurchaseID = (int)reader["PurchaseID"],
                                BatchNumber = reader["BatchNumber"] == DBNull.Value ? "" : reader["BatchNumber"].ToString() ?? "",
                                ExpiryDate = (DateTime)reader["ExpiryDate"],
                                PurchasePrice = (decimal)reader["PurchasePrice"],
                                QuantityInStock = (int)reader["QuantityInStock"],
                                MedicineName = reader["MedicineName"].ToString() ?? "",
                                SupplierName = reader["SupplierName"].ToString() ?? ""
                            };
                        }
                    }
                }
            }
            return null;
        }

        public bool UpdateBatchQuantity(int batchID, int newQuantity)
        {
            using (SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_UpdateBatchQuantity", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@BatchID", batchID);
                    command.Parameters.AddWithValue("@QuantityInStock", newQuantity);
                    return Convert.ToInt32(command.ExecuteScalar()) > 0;
                }
            }
        }

        public List<MedicineBatch> GetExpiringSoon(int days = 30)
        {
            List<MedicineBatch> batches = new List<MedicineBatch>();
            using (SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_GetExpiringSoonBatches", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Days", days);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            batches.Add(new MedicineBatch
                            {
                                BatchID = (int)reader["BatchID"],
                                MedicineID = (int)reader["MedicineID"],
                                SupplierID = (int)reader["SupplierID"],
                                PurchaseID = (int)reader["PurchaseID"],
                                BatchNumber = reader["BatchNumber"] == DBNull.Value ? "" : reader["BatchNumber"].ToString() ?? "",
                                ExpiryDate = (DateTime)reader["ExpiryDate"],
                                PurchasePrice = (decimal)reader["PurchasePrice"],
                                QuantityInStock = (int)reader["QuantityInStock"],
                                MedicineName = reader["MedicineName"].ToString() ?? "",
                                SupplierName = reader["SupplierName"].ToString() ?? ""
                            });
                        }
                    }
                }
            }
            return batches;
        }

        public List<MedicineBatch> GetMedicineBatchesByMedicine(int medicineID)
        {
            List<MedicineBatch> batches = new List<MedicineBatch>();
            using (SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_GetBatchesByMedicine", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MedicineID", medicineID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            batches.Add(new MedicineBatch
                            {
                                BatchID = (int)reader["BatchID"],
                                MedicineID = (int)reader["MedicineID"],
                                SupplierID = (int)reader["SupplierID"],
                                PurchaseID = (int)reader["PurchaseID"],
                                BatchNumber = reader["BatchNumber"] == DBNull.Value ? "" : reader["BatchNumber"].ToString() ?? "",
                                ExpiryDate = (DateTime)reader["ExpiryDate"],
                                PurchasePrice = (decimal)reader["PurchasePrice"],
                                QuantityInStock = (int)reader["QuantityInStock"],
                                MedicineName = reader["MedicineName"].ToString() ?? "",
                                SupplierName = reader["SupplierName"].ToString() ?? ""
                            });
                        }
                    }
                }
            }
            return batches;
        }

        public bool UpdateMedicineBatch(MedicineBatch batch)
        {
            using (SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_UpdateBatchQuantity", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@BatchID", batch.BatchID);
                    command.Parameters.AddWithValue("@QuantityInStock", batch.QuantityInStock);
                    return Convert.ToInt32(command.ExecuteScalar()) > 0;
                }
            }
        }

        public List<MedicineBatch> GetByExpiryDate(DateTime expiryDate)
        {
            List<MedicineBatch> batches = new List<MedicineBatch>();
            using (SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_GetBatchesByExpiryDate", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ExpiryDate", expiryDate);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            batches.Add(new MedicineBatch
                            {
                                BatchID = (int)reader["BatchID"],
                                MedicineID = (int)reader["MedicineID"],
                                SupplierID = (int)reader["SupplierID"],
                                PurchaseID = (int)reader["PurchaseID"],
                                BatchNumber = reader["BatchNumber"] == DBNull.Value ? "" : reader["BatchNumber"].ToString() ?? "",
                                ExpiryDate = (DateTime)reader["ExpiryDate"],
                                PurchasePrice = (decimal)reader["PurchasePrice"],
                                QuantityInStock = (int)reader["QuantityInStock"],
                                MedicineName = reader["MedicineName"].ToString() ?? "",
                                SupplierName = reader["SupplierName"].ToString() ?? ""
                            });
                        }
                    }
                }
            }
            return batches;
        }

        public DataTable GetBatchDetails(int batchID)
        {
            using (SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_GetBatchDetails", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@BatchID", batchID);
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