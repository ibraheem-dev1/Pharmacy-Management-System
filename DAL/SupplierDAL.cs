using PharmacyWinFormsApp.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace PharmacyWinFormsApp.DAL
{
    public class SupplierDAL
    {
        public List<Supplier> SearchSuppliers(string searchTerm)
        {
            List<Supplier> suppliers = new List<Supplier>();
            using (SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_SearchSuppliers", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@SearchTerm", searchTerm);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            suppliers.Add(new Supplier
                            {
                                SupplierID = (int)reader["SupplierID"],
                                SupplierName = reader["SupplierName"].ToString() ?? "",
                                Contact = reader["Contact"].ToString() ?? "",
                                Address = reader["Address"].ToString() ?? ""
                            });
                        }
                    }
                }
            }
            return suppliers;
        }

        public List<Supplier> GetAllSuppliers()
        {
            List<Supplier> suppliers = new List<Supplier>();
            using (SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_GetAllSuppliers", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            suppliers.Add(new Supplier
                            {
                                SupplierID = (int)reader["SupplierID"],
                                SupplierName = reader["SupplierName"].ToString() ?? "",
                                Contact = reader["Contact"] == DBNull.Value ? "" : reader["Contact"].ToString() ?? "",
                                Address = reader["Address"] == DBNull.Value ? "" : reader["Address"].ToString() ?? ""
                            });
                        }
                    }
                }
            }
            return suppliers;
        }

        public bool AddSupplier(Supplier supplier)
        {
            using (SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_AddSupplier", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@SupplierName", supplier.SupplierName);
                    command.Parameters.AddWithValue("@Contact", string.IsNullOrEmpty(supplier.Contact) ? DBNull.Value : supplier.Contact);
                    command.Parameters.AddWithValue("@Address", string.IsNullOrEmpty(supplier.Address) ? DBNull.Value : supplier.Address);
                    return Convert.ToInt32(command.ExecuteScalar()) > 0;
                }
            }
        }

        public bool UpdateSupplier(Supplier supplier)
        {
            using (SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_UpdateSupplier", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@SupplierID", supplier.SupplierID);
                    command.Parameters.AddWithValue("@SupplierName", supplier.SupplierName);
                    command.Parameters.AddWithValue("@Contact", string.IsNullOrEmpty(supplier.Contact) ? DBNull.Value : supplier.Contact);
                    command.Parameters.AddWithValue("@Address", string.IsNullOrEmpty(supplier.Address) ? DBNull.Value : supplier.Address);
                    return Convert.ToInt32(command.ExecuteScalar()) > 0;
                }
            }
        }
    }
}