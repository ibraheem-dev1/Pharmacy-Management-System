using System.Configuration;
using Microsoft.Data.SqlClient;

namespace PharmacyWinFormsApp.DAL
{
    public static class Database
    {
        public static SqlConnection GetConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["PharmacyDB"].ConnectionString;
            return new SqlConnection(connectionString);
        }
    }
}