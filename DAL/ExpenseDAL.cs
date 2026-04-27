using PharmacyWinFormsApp.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace PharmacyWinFormsApp.DAL
{
    public class ExpenseDAL
    {
        public int AddExpense(string description, decimal amount, string category, DateTime expenseDate, int recordedBy)
        {
            using (SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_AddExpense", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Description", description);
                    command.Parameters.AddWithValue("@Amount", amount);
                    command.Parameters.AddWithValue("@Category", category);
                    command.Parameters.AddWithValue("@ExpenseDate", expenseDate);
                    command.Parameters.AddWithValue("@RecordedBy", recordedBy);

                    object? result = command.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : 0;
                }
            }
        }

        public List<Expense> GetAllExpenses()
        {
            List<Expense> expenses = new List<Expense>();
            using (SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_GetAllExpenses", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            expenses.Add(new Expense
                            {
                                ExpenseID = (int)reader["ExpenseID"],
                                Description = reader["Description"].ToString() ?? "",
                                Amount = (decimal)reader["Amount"],
                                Category = reader["Category"].ToString() ?? "",
                                ExpenseDate = (DateTime)reader["ExpenseDate"],
                                RecordedDate = (DateTime)reader["RecordedDate"],
                                RecordedBy = (int)reader["RecordedBy"],
                                RecordedByName = reader["RecordedByName"].ToString() ?? ""
                            });
                        }
                    }
                }
            }
            return expenses;
        }

        public List<Expense> GetExpensesByDateRange(DateTime startDate, DateTime endDate)
        {
            List<Expense> expenses = new List<Expense>();
            using (SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_GetExpensesByDateRange", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            expenses.Add(new Expense
                            {
                                ExpenseID = (int)reader["ExpenseID"],
                                Description = reader["Description"].ToString() ?? "",
                                Amount = (decimal)reader["Amount"],
                                Category = reader["Category"].ToString() ?? "",
                                ExpenseDate = (DateTime)reader["ExpenseDate"],
                                RecordedDate = (DateTime)reader["RecordedDate"],
                                RecordedBy = (int)reader["RecordedBy"],
                                RecordedByName = reader["RecordedByName"].ToString() ?? ""
                            });
                        }
                    }
                }
            }
            return expenses;
        }

        public List<Expense> GetExpensesByCategory(string category)
        {
            List<Expense> expenses = new List<Expense>();
            using (SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_GetExpensesByCategory", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Category", category);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            expenses.Add(new Expense
                            {
                                ExpenseID = (int)reader["ExpenseID"],
                                Description = reader["Description"].ToString() ?? "",
                                Amount = (decimal)reader["Amount"],
                                Category = reader["Category"].ToString() ?? "",
                                ExpenseDate = (DateTime)reader["ExpenseDate"],
                                RecordedDate = (DateTime)reader["RecordedDate"],
                                RecordedBy = (int)reader["RecordedBy"],
                                RecordedByName = reader["RecordedByName"].ToString() ?? ""
                            });
                        }
                    }
                }
            }
            return expenses;
        }

        public decimal GetTotalExpensesByMonth(int month, int year)
        {
            using (SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_GetTotalExpensesByMonth", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Month", month);
                    command.Parameters.AddWithValue("@Year", year);

                    object? result = command.ExecuteScalar();
                    return result != null ? Convert.ToDecimal(result) : 0;
                }
            }
        }

        public void UpdateExpense(int expenseID, string description, decimal amount, string category, DateTime expenseDate)
        {
            using (SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_UpdateExpense", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ExpenseID", expenseID);
                    command.Parameters.AddWithValue("@Description", description);
                    command.Parameters.AddWithValue("@Amount", amount);
                    command.Parameters.AddWithValue("@Category", category);
                    command.Parameters.AddWithValue("@ExpenseDate", expenseDate);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteExpense(int expenseID)
        {
            using (SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_DeleteExpense", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ExpenseID", expenseID);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
