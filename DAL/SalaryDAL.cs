using PharmacyWinFormsApp.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace PharmacyWinFormsApp.DAL
{
    public class SalaryDAL
    {
        public int AddSalary(int userID, int month, int year, decimal basicSalary, decimal bonus, decimal deductions, int recordedBy)
        {
            using (SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_AddSalary", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", userID);
                    command.Parameters.AddWithValue("@Month", month);
                    command.Parameters.AddWithValue("@Year", year);
                    command.Parameters.AddWithValue("@BasicSalary", basicSalary);
                    command.Parameters.AddWithValue("@Bonus", bonus);
                    command.Parameters.AddWithValue("@Deductions", deductions);
                    command.Parameters.AddWithValue("@RecordedBy", recordedBy);

                    object? result = command.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : 0;
                }
            }
        }

        public List<Salary> GetAllSalaries()
        {
            List<Salary> salaries = new List<Salary>();
            using (SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_GetAllSalaries", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            salaries.Add(new Salary
                            {
                                SalaryID = (int)reader["SalaryID"],
                                UserID = (int)reader["UserID"],
                                UserName = reader["UserName"].ToString() ?? "",
                                Month = (int)reader["Month"],
                                Year = (int)reader["Year"],
                                BasicSalary = (decimal)reader["BasicSalary"],
                                Bonus = (decimal)reader["Bonus"],
                                Deductions = (decimal)reader["Deductions"],
                                NetSalary = (decimal)reader["NetSalary"],
                                RecordedDate = (DateTime)reader["RecordedDate"],
                                RecordedBy = (int)reader["RecordedBy"],
                                RecordedByName = reader["RecordedByName"].ToString() ?? ""
                            });
                        }
                    }
                }
            }
            return salaries;
        }

        public List<Salary> GetSalariesByMonth(int month, int year)
        {
            List<Salary> salaries = new List<Salary>();
            using (SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_GetSalariesByMonth", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Month", month);
                    command.Parameters.AddWithValue("@Year", year);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            salaries.Add(new Salary
                            {
                                SalaryID = (int)reader["SalaryID"],
                                UserID = (int)reader["UserID"],
                                UserName = reader["UserName"].ToString() ?? "",
                                Month = (int)reader["Month"],
                                Year = (int)reader["Year"],
                                BasicSalary = (decimal)reader["BasicSalary"],
                                Bonus = (decimal)reader["Bonus"],
                                Deductions = (decimal)reader["Deductions"],
                                NetSalary = (decimal)reader["NetSalary"],
                                RecordedDate = (DateTime)reader["RecordedDate"],
                                RecordedBy = (int)reader["RecordedBy"],
                                RecordedByName = reader["RecordedByName"].ToString() ?? ""
                            });
                        }
                    }
                }
            }
            return salaries;
        }

        public List<Salary> GetSalariesByUser(int userID)
        {
            List<Salary> salaries = new List<Salary>();
            using (SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_GetSalariesByUser", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", userID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            salaries.Add(new Salary
                            {
                                SalaryID = (int)reader["SalaryID"],
                                UserID = (int)reader["UserID"],
                                UserName = reader["UserName"].ToString() ?? "",
                                Month = (int)reader["Month"],
                                Year = (int)reader["Year"],
                                BasicSalary = (decimal)reader["BasicSalary"],
                                Bonus = (decimal)reader["Bonus"],
                                Deductions = (decimal)reader["Deductions"],
                                NetSalary = (decimal)reader["NetSalary"],
                                RecordedDate = (DateTime)reader["RecordedDate"],
                                RecordedBy = (int)reader["RecordedBy"],
                                RecordedByName = reader["RecordedByName"].ToString() ?? ""
                            });
                        }
                    }
                }
            }
            return salaries;
        }

        public decimal GetTotalSalaryByMonth(int month, int year)
        {
            using (SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_GetTotalSalaryByMonth", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Month", month);
                    command.Parameters.AddWithValue("@Year", year);

                    object? result = command.ExecuteScalar();
                    return result != null ? Convert.ToDecimal(result) : 0;
                }
            }
        }

        public void UpdateSalary(int salaryID, decimal basicSalary, decimal bonus, decimal deductions)
        {
            using (SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_UpdateSalary", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@SalaryID", salaryID);
                    command.Parameters.AddWithValue("@BasicSalary", basicSalary);
                    command.Parameters.AddWithValue("@Bonus", bonus);
                    command.Parameters.AddWithValue("@Deductions", deductions);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteSalary(int salaryID)
        {
            using (SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_DeleteSalary", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@SalaryID", salaryID);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
