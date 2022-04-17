using System;
using Company.UTILS;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Company
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            await GetAllEmployees(); 
        }
        public async static Task GetAllEmployees()
        {
            using (SqlConnection connection = new SqlConnection(Constants.connectionString))
            {
                connection.Open();
                string command = "SELECT * FROM Employee";
                using (SqlCommand sqlCommand = new SqlCommand(command, connection))
                {
                    SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"Fullname: {reader["Fullname"]}");
                        }
                    }
                }
            }
        }
    }
}
