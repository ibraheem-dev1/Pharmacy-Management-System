using PharmacyWinFormsApp.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace PharmacyWinFormsApp.DAL
{
    public class SaleDAL
    {
        public int AddSale(Sale sale)
        {
            using (SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_AddSale", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", sale.UserID);
                    command.Parameters.AddWithValue("@CustomerID", sale.CustomerID.HasValue ? sale.CustomerID.Value : DBNull.Value);
                    command.Parameters.AddWithValue("@PrescriptionID", sale.PrescriptionID.HasValue ? sale.PrescriptionID.Value : DBNull.Value);
                    command.Parameters.AddWithValue("@SaleDate", sale.SaleDate);
                    command.Parameters.AddWithValue("@TotalAmount", sale.TotalAmount);
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        public List<Sale> GetAllSales()
        {
            List<Sale> sales = new List<Sale>();
            using (SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_GetAllSales", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            sales.Add(new Sale
                            {
                                SaleID = (int)reader["SaleID"],
                                UserID = (int)reader["UserID"],
                                CustomerID = reader["CustomerID"] == DBNull.Value ? null : (int?)reader["CustomerID"],
                                PrescriptionID = reader["PrescriptionID"] == DBNull.Value ? null : (int?)reader["PrescriptionID"],
                                SaleDate = (DateTime)reader["SaleDate"],
                                TotalAmount = reader["TotalAmount"] == DBNull.Value ? 0 : (decimal)reader["TotalAmount"],
                                UserName = reader["UserName"].ToString() ?? "",
                                CustomerName = reader["CustomerName"] == DBNull.Value ? "Walk-in Customer" : reader["CustomerName"].ToString() ?? "Walk-in Customer"
                            });
                        }
                    }
                }
            }
            return sales;
        }

        public List<Sale> GetSalesByDate(DateTime date)
        {
            List<Sale> sales = new List<Sale>();
            using (SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_GetSalesByDate", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@SaleDate", date.Date);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            sales.Add(new Sale
                            {
                                SaleID = (int)reader["SaleID"],
                                UserID = (int)reader["UserID"],
                                CustomerID = reader["CustomerID"] == DBNull.Value ? null : (int?)reader["CustomerID"],
                                PrescriptionID = reader["PrescriptionID"] == DBNull.Value ? null : (int?)reader["PrescriptionID"],
                                SaleDate = (DateTime)reader["SaleDate"],
                                TotalAmount = reader["TotalAmount"] == DBNull.Value ? 0 : (decimal)reader["TotalAmount"],
                                UserName = reader["UserName"].ToString() ?? "",
                                CustomerName = reader["CustomerName"] == DBNull.Value ? "Walk-in Customer" : reader["CustomerName"].ToString() ?? "Walk-in Customer"
                            });
                        }
                    }
                }
            }
            return sales;
        }

        public List<Sale> GetSalesByMonth(int month, int year)
        {
            List<Sale> sales = new List<Sale>();
            using (SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM Sale WHERE MONTH(SaleDate) = @Month AND YEAR(SaleDate) = @Year", connection))
                {
                    command.Parameters.AddWithValue("@Month", month);
                    command.Parameters.AddWithValue("@Year", year);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            sales.Add(new Sale
                            {
                                SaleID = (int)reader["SaleID"],
                                UserID = (int)reader["UserID"],
                                CustomerID = reader["CustomerID"] == DBNull.Value ? null : (int?)reader["CustomerID"],
                                PrescriptionID = reader["PrescriptionID"] == DBNull.Value ? null : (int?)reader["PrescriptionID"],
                                SaleDate = (DateTime)reader["SaleDate"],
                                TotalAmount = reader["TotalAmount"] == DBNull.Value ? 0 : (decimal)reader["TotalAmount"]
                            });
                        }
                    }
                }
            }
            return sales;
        }
    }
}