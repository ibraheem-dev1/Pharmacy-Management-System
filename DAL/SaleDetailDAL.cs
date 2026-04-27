using PharmacyWinFormsApp.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace PharmacyWinFormsApp.DAL
{
    public class SaleDetailDAL
    {
        public bool AddSaleDetail(int saleID, int medicineID, int quantity, decimal sellingPrice)
        {
            try
            {
                using (SqlConnection connection = Database.GetConnection())
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("sp_SellMedicine_FIFO", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@SaleID", saleID);
                        command.Parameters.AddWithValue("@MedicineID", medicineID);
                        command.Parameters.AddWithValue("@Quantity", quantity);
                        command.Parameters.AddWithValue("@SellingPrice", sellingPrice);
                        command.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("INSUFFICIENT STOCK"))
                {
                    throw new Exception("Insufficient stock available for this medicine.");
                }
                throw;
            }
        }

        public List<SaleDetail> GetSaleDetails(int saleID)
        {
            List<SaleDetail> details = new List<SaleDetail>();
            using (SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_GetSaleDetails", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@SaleID", saleID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            details.Add(new SaleDetail
                            {
                                SaleID = saleID,
                                BatchID = (int)reader["BatchID"],
                                QuantitySold = (int)reader["QuantitySold"],
                                SellingPrice = (decimal)reader["SellingPrice"],
                                MedicineName = reader["MedicineName"].ToString() ?? "",
                                BatchNumber = reader["BatchNumber"] == DBNull.Value ? "" : reader["BatchNumber"].ToString() ?? "",
                                ExpiryDate = (DateTime)reader["ExpiryDate"]
                            });
                        }
                    }
                }
            }
            return details;
        }
    }
}