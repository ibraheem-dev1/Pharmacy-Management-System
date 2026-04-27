using PharmacyWinFormsApp.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace PharmacyWinFormsApp.DAL
{
    public class CustomerDAL
    {
        public List<Customer> SearchCustomers(string searchTerm)
        {
            List<Customer> customers = new List<Customer>();
            using (SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_SearchCustomers", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@SearchTerm", searchTerm);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            customers.Add(new Customer
                            {
                                CustomerID = (int)reader["CustomerID"],
                                CustomerName = reader["CustomerName"].ToString() ?? "",
                                ContactNo = reader["ContactNo"].ToString() ?? "",
                                Address = reader["Address"].ToString() ?? ""
                            });
                        }
                    }
                }
            }
            return customers;
        }

        public List<Customer> GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();
            using (SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_GetAllCustomers", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            customers.Add(new Customer
                            {
                                CustomerID = (int)reader["CustomerID"],
                                CustomerName = reader["CustomerName"].ToString() ?? "",
                                ContactNo = reader["ContactNo"] == DBNull.Value ? "" : reader["ContactNo"].ToString() ?? "",
                                Address = reader["Address"] == DBNull.Value ? "" : reader["Address"].ToString() ?? ""
                            });
                        }
                    }
                }
            }
            return customers;
        }

        public bool AddCustomer(Customer customer)
        {
            using (SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_AddCustomer", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CustomerName", customer.CustomerName);
                    command.Parameters.AddWithValue("@ContactNo", string.IsNullOrEmpty(customer.ContactNo) ? DBNull.Value : customer.ContactNo);
                    command.Parameters.AddWithValue("@Address", string.IsNullOrEmpty(customer.Address) ? DBNull.Value : customer.Address);
                    return Convert.ToInt32(command.ExecuteScalar()) > 0;
                }
            }
        }

        public bool UpdateCustomer(Customer customer)
        {
            using (SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_UpdateCustomer", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CustomerID", customer.CustomerID);
                    command.Parameters.AddWithValue("@CustomerName", customer.CustomerName);
                    command.Parameters.AddWithValue("@ContactNo", string.IsNullOrEmpty(customer.ContactNo) ? DBNull.Value : customer.ContactNo);
                    command.Parameters.AddWithValue("@Address", string.IsNullOrEmpty(customer.Address) ? DBNull.Value : customer.Address);
                    return Convert.ToInt32(command.ExecuteScalar()) > 0;
                }
            }
        }
    }
}