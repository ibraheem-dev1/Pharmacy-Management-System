using PharmacyWinFormsApp.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace PharmacyWinFormsApp.DAL
{
    public class FormulaDAL
    {
        public List<Formula> GetAllFormulas()
        {
            List<Formula> formulas = new List<Formula>();
            using (SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_GetAllFormulas", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            formulas.Add(new Formula
                            {
                                FormulaID = (int)reader["FormulaID"],
                                FormulaName = reader["FormulaName"].ToString() ?? ""
                            });
                        }
                    }
                }
            }
            return formulas;
        }

        public bool AddFormula(Formula formula)
        {
            using (SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_AddFormula", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FormulaName", formula.FormulaName);
                    return Convert.ToInt32(command.ExecuteScalar()) > 0;
                }
            }
        }

        public bool UpdateFormula(Formula formula)
        {
            using (SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_UpdateFormula", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FormulaID", formula.FormulaID);
                    command.Parameters.AddWithValue("@FormulaName", formula.FormulaName);
                    return Convert.ToInt32(command.ExecuteScalar()) > 0;
                }
            }
        }
    }
}