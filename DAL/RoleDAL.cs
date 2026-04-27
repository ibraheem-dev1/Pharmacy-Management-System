using PharmacyWinFormsApp.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace PharmacyWinFormsApp.DAL
{
    public class RoleDAL
    {
        public List<Role> GetAllRoles()
        {
            List<Role> roles = new List<Role>();
            using (SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_GetAllRoles", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            roles.Add(new Role
                            {
                                RoleID = (int)reader["RoleID"],
                                RoleName = reader["RoleName"].ToString() ?? ""
                            });
                        }
                    }
                }
            }
            return roles;
        }

        public bool AddRole(Role role)
        {
            using (SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_AddRole", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@RoleName", role.RoleName);
                    return Convert.ToInt32(command.ExecuteScalar()) > 0;
                }
            }
        }
    }
}