using PharmacyWinFormsApp.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace PharmacyWinFormsApp.DAL
{
    public class PurchaseDAL
    {
        public int AddPurchase(Purchase purchase)
        {
            using (SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_AddPurchase", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@SupplierID", purchase.SupplierID);
                    command.Parameters.AddWithValue("@UserID", purchase.UserID);
                    command.Parameters.AddWithValue("@PurchaseDate", purchase.PurchaseDate);
                    command.Parameters.AddWithValue("@TotalAmount", purchase.TotalAmount);
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        public List<Purchase> GetAllPurchases()
        {
            List<Purchase> purchases = new List<Purchase>();
            using (SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_GetAllPurchases", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            purchases.Add(new Purchase
                            {
                                PurchaseID = (int)reader["PurchaseID"],
                                SupplierID = (int)reader["SupplierID"],
                                UserID = (int)reader["UserID"],
                                PurchaseDate = (DateTime)reader["PurchaseDate"],
                                TotalAmount = reader["TotalAmount"] == DBNull.Value ? 0 : (decimal)reader["TotalAmount"],
                                SupplierName = reader["SupplierName"].ToString() ?? "",
                                UserName = reader["UserName"].ToString() ?? ""
                            });
                        }
                    }
                }
            }
            return purchases;
        }
    }
}