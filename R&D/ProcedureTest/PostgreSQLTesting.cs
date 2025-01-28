using Npgsql;

namespace TestProcedure
{
    public class PostgreSQLTesting
    {
        /// <summary>
        /// Main entry point of the application that connects to a PostgreSQL database,
        /// executes a stored procedure to fetch student data, and displays the results.
        /// </summary>
        public void Test()
        {
            // PostgreSQL connection string - Replace with your actual database connection details
            string connectionString = "Host=localhost;Database=test_college;Username=user_all;Password=password_all;";

            // Using block ensures the connection is closed when done
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    // Open the PostgreSQL connection
                    connection.Open();

                    // Create a command object for executing the stored procedure
                    using (NpgsqlCommand cmd = new NpgsqlCommand("INSERT_PROC", connection))
                    {
                        // Set the command type to StoredProcedure
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("student_id", 11157);
                        cmd.Parameters.AddWithValue("student_name", "asdf");


                        int insert = cmd.ExecuteNonQuery();
                        if (insert == 0)
                        {
                            Console.WriteLine("Error");
                        }
                        else
                        {
                            Console.WriteLine("Data Inserted Successfully");
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
