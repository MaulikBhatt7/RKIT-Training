using System;
using MySql.Data.MySqlClient;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // MySQL connection string (replace with your own database details)
            string connectionString = "Server=localhost;Database=college;User ID=tester_user;Password=password123;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    // Open the connection
                    connection.Open();

                    // Create the command object
                    using (MySqlCommand cmd = new MySqlCommand("SelectAllStudents", connection))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        // Execute the command and get the data
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Check if data exists
                            if (reader.HasRows)
                            {
                                // Loop through the data
                                while (reader.Read())
                                {
                                    // Replace with your actual column names
                                    string column1 = reader["rollNo"].ToString();
                                    string column2 = reader["name"].ToString();

                                    // Print each row data to the console
                                    Console.WriteLine($"ID: {column1}, Name: {column2}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("No data found.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
