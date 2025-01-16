using System;
using MySql.Data.MySqlClient;

namespace TestProcedure
{
    class MySQLTesting
    {
        /// <summary>
        /// Main entry point of the application that connects to a MySQL database,
        /// executes a stored procedure to fetch student data, and displays the results.
        /// </summary>
        public void Test()
        {
            // MySQL connection string - Replace with your actual database connection details
            string connectionString = "Server=localhost;Database=abcd;User ID=abcd;Password=abcd;";

            // Using block ensures the connection is closed when done
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    // Open the MySQL connection
                    connection.Open();

                    // Create a command object for executing the stored procedure
                    using (MySqlCommand cmd = new MySqlCommand("SelectAllStudents", connection))
                    {
                        // Set the command type to StoredProcedure
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        // Execute the command and retrieve the data using a data reader
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Check if any rows exist in the result set
                            if (reader.HasRows)
                            {
                                // Loop through all the rows returned by the stored procedure
                                while (reader.Read())
                                {
                                    // Extract data from each column by specifying the column name
                                    string rollNo = reader["rollNo"].ToString();
                                    string name = reader["name"].ToString();

                                    // Print each student's data (roll number and name) to the console
                                    Console.WriteLine($"ID: {rollNo}, Name: {name}");
                                }
                            }
                            else
                            {
                                // Display message if no data was returned
                                Console.WriteLine("No data found.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Display any errors that occur during database connection or command execution
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            // Wait for user input before exiting the application
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
