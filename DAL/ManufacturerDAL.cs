using PharmacyWinFormsApp.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace PharmacyWinFormsApp.DAL
{
    public class ManufacturerDAL
    {
        public List<Manufacturer> GetAllManufacturers()
        {
            List<Manufacturer> manufacturers = new List<Manufacturer>();
            using (SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_GetAllManufacturers", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            manufacturers.Add(new Manufacturer
                            {
                                ManufacturerID = (int)reader["ManufacturerID"],
                                ManufacturerName = reader["ManufacturerName"].ToString() ?? ""
                            });
                        }
                    }
                }
            }
            return manufacturers;
        }

        public bool AddManufacturer(Manufacturer manufacturer)
        {
            using (SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_AddManufacturer", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ManufacturerName", manufacturer.ManufacturerName);
                    return Convert.ToInt32(command.ExecuteScalar()) > 0;
                }
            }
        }

        public bool UpdateManufacturer(Manufacturer manufacturer)
        {
            using (SqlConnection connection = Database.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_UpdateManufacturer", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ManufacturerID", manufacturer.ManufacturerID);
                    command.Parameters.AddWithValue("@ManufacturerName", manufacturer.ManufacturerName);
                    return Convert.ToInt32(command.ExecuteScalar()) > 0;
                }
            }
        }
    }
}