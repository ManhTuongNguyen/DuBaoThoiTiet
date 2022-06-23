using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace WeatherForecast_Server
{
    public class DataProvider
    {
        private static readonly string connectionString = "Server=.;Database=WeatherForecast;User Id=sa;Password=123;";

        public static DataTable ExecuteQuery(string query)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    DataTable dataTable = new DataTable();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    sqlDataAdapter.Fill(dataTable);
                    sqlConnection.Close();
                    return dataTable;
                }
            }
        }

        public static int ExecuteNonquery(string query, object[] parameters)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                int data = 0;
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    AddValueToParameters(query, parameters, sqlCommand);
                    data = sqlCommand.ExecuteNonQuery();
                }
                sqlConnection.Close();
                return data;
            }
        }

        private static void AddValueToParameters(string query, object[] parameters, SqlCommand sqlCommand)
        {
            if (parameters == null)
            {
                return;
            }
            int i = 0;
            string[] listPara = query.Split(' ');
            foreach (string item in listPara)
            {
                if (item.Contains('@'))
                {
                    sqlCommand.Parameters.AddWithValue(item, parameters[i]);
                    i += 1;
                }
            }
        }
    }
}
