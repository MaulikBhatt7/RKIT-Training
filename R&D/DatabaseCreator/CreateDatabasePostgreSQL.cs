﻿using Npgsql;


namespace DatabaseCreator
{
    public class CreateDatabasePostgreSQL
    {
        public static void CreateDatabases(int number, string createTableQuery, string server, string username, string password)
        {
            string serverConnectionString = $"Host={server};Database=postgres;Username={username};Password={password};";

            try
            {
                // Connect to the server to manage databases
                using (var serverConnection = new NpgsqlConnection(serverConnectionString))
                {
                    serverConnection.Open();
                    Console.WriteLine("Connected to PostgreSQL server.");

                    for (int i = 1; i <= number; i++)
                    {
                        string databaseName = $"test_db_{i}";

                        try
                        {
                            // Check if database exists
                            if (!DatabaseExists(serverConnection, databaseName))
                            {
                                // Create the database if it doesn't exist
                                CreateDatabase(serverConnection, databaseName);
                            }
                            else
                            {
                                Console.WriteLine($"Database '{databaseName}' already exists.");
                            }

                            // Create tables in the new database
                            CreateTableInDatabase(server, databaseName, username, password, createTableQuery);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error while handling database '{databaseName}': {ex.Message}");
                        }
                    }
                }

                Console.WriteLine("All databases and tables processed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while connecting to the PostgreSQL server: {ex.Message}");
            }
        }

        // Check if a database exists
        private static bool DatabaseExists(NpgsqlConnection serverConnection, string databaseName)
        {
            try
            {
                string checkDbQuery = $"SELECT 1 FROM pg_database WHERE datname = @databaseName;";
                using (var checkCmd = new NpgsqlCommand(checkDbQuery, serverConnection))
                {
                    checkCmd.Parameters.AddWithValue("@databaseName", databaseName);
                    var dbExists = checkCmd.ExecuteScalar();
                    return dbExists != null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking existence of database '{databaseName}': {ex.Message}");
                return false;
            }
        }

        // Create the database
        private static void CreateDatabase(NpgsqlConnection serverConnection, string databaseName)
        {
            try
            {
                string createDbQuery = $"CREATE DATABASE {databaseName};";
                using (var createCmd = new NpgsqlCommand(createDbQuery, serverConnection))
                {
                    createCmd.ExecuteNonQuery();
                    Console.WriteLine($"Database '{databaseName}' created.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating database '{databaseName}': {ex.Message}");
            }
        }

        // Create tables in the specified database
        private static void CreateTableInDatabase(string server, string databaseName, string username, string password, string createTableQuery)
        {
            string dbConnectionString = $"Host={server};Database={databaseName};Username={username};Password={password};";
            try
            {
                using (var dbConnection = new NpgsqlConnection(dbConnectionString))
                {
                    dbConnection.Open();
                    using (var createTableCmd = new NpgsqlCommand(createTableQuery, dbConnection))
                    {
                        createTableCmd.ExecuteNonQuery();
                        Console.WriteLine($"Table 'orders' created in '{databaseName}'.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating table in database '{databaseName}': {ex.Message}");
            }
        }
    }
}