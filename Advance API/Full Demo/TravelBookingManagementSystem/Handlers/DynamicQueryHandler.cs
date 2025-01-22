using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;
using ServiceStack;

namespace TravelBookingManagementSystem.Handlers
{
    /// <summary>
    /// Handler for executing dynamic SQL queries.
    /// </summary>
    public class DynamicQueryHandler
    {
        private readonly string _connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicQueryHandler"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string for the MySQL database.</param>
        public DynamicQueryHandler(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Inserts a new record into the specified table.
        /// </summary>
        /// <param name="tableName">The name of the table.</param>
        /// <param name="columnValues">A dictionary of column names and their corresponding values.</param>
        /// <returns>The number of rows affected.</returns>
        public int Insert(string tableName, Dictionary<string, object> columnValues)
        {
            // Generate the list of columns and their corresponding parameters
            string columns = string.Join(", ", columnValues.Keys);
            string parameters = string.Join(", ", columnValues.Keys.Select(column => $"@{column}"));

            // Construct the INSERT SQL query
            string query = $"INSERT INTO {tableName} ({columns}) VALUES ({parameters});";

            // Execute the query and return the number of rows affected
            return ExecuteNonQuery(query, columnValues);
        }

        /// <summary>
        /// Updates existing records in the specified table.
        /// </summary>
        /// <param name="tableName">The name of the table.</param>
        /// <param name="columnValues">A dictionary of column names and their corresponding values to update.</param>
        /// <param name="whereClause">The WHERE clause to identify which records to update.</param>
        /// <param name="whereParameters">A dictionary of parameters for the WHERE clause.</param>
        /// <returns>The number of rows affected.</returns>
        public int Update(string tableName, Dictionary<string, object> columnValues, string whereClause, Dictionary<string, object> whereParameters)
        {
            // Generate the SET clause for the UPDATE SQL query
            string setClause = string.Join(", ", columnValues.Keys.Select(column => $"{column} = @{column}"));

            // Construct the UPDATE SQL query
            string query = $"UPDATE {tableName} SET {setClause} WHERE {whereClause};";

            // Merge the columnValues and whereParameters dictionaries
            foreach (var kv in whereParameters)
            {
                columnValues[kv.Key] = kv.Value;
            }

            // Execute the query and return the number of rows affected
            return ExecuteNonQuery(query, columnValues);
        }

        /// <summary>
        /// Deletes records from the specified table.
        /// </summary>
        /// <param name="tableName">The name of the table.</param>
        /// <param name="whereClause">The WHERE clause to identify which records to delete.</param>
        /// <param name="whereParameters">A dictionary of parameters for the WHERE clause.</param>
        /// <returns>The number of rows affected.</returns>
        public int Delete(string tableName, string whereClause, Dictionary<string, object> whereParameters)
        {
            // Construct the DELETE SQL query
            string query = $"DELETE FROM {tableName} WHERE {whereClause};";

            // Execute the query and return the number of rows affected
            return ExecuteNonQuery(query, whereParameters);
        }

        /// <summary>
        /// Executes a non-query SQL command (INSERT, UPDATE, DELETE).
        /// </summary>
        /// <param name="query">The SQL query to execute.</param>
        /// <param name="parameters">A dictionary of parameters for the SQL query.</param>
        /// <returns>The number of rows affected.</returns>
        private int ExecuteNonQuery(string query, Dictionary<string, object> parameters)
        {
            // Create a new MySQL connection using the provided connection string
            using (var connection = new MySqlConnection(_connectionString))
            {
                // Create a new MySQL command using the provided query and connection
                using (var command = new MySqlCommand(query, connection))
                {
                    // Add the parameters to the command
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            command.Parameters.AddWithValue($"@{param.Key}", param.Value ?? DBNull.Value);
                        }
                    }

                    // Open the connection and execute the non-query command
                    connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
        }
    }
}