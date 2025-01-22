using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;
using ServiceStack;

namespace TravelBookingManagementSystem.Handlers
{
    public class DynamicQueryHandler
    {
        private readonly string _connectionString;

        public DynamicQueryHandler(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int Insert(string tableName, Dictionary<string, object> columnValues)
        {
            string columns = string.Join(", ", columnValues.Keys);
            string parameters = string.Join(", ", columnValues.Keys.Select(column => $"@{column}"));

            string query = $"INSERT INTO {tableName} ({columns}) VALUES ({parameters});";

            return ExecuteNonQuery(query, columnValues);
        }


        public int Update(string tableName, Dictionary<string, object> columnValues, string whereClause, Dictionary<string, object> whereParameters)
        {
            string setClause = string.Join(", ", columnValues.Keys.Select(column => $"{column} = @{column}"));

            string query = $"UPDATE {tableName} SET {setClause} WHERE {whereClause};";

            // Merge the columnValues and whereParameters dictionaries
            foreach (var kv in whereParameters)
            {
                columnValues[kv.Key] = kv.Value;
            }

            return ExecuteNonQuery(query, columnValues);
        }

        public int Delete(string tableName, string whereClause, Dictionary<string, object> whereParameters)
        {
            string query = $"DELETE FROM {tableName} WHERE {whereClause};";

            return ExecuteNonQuery(query, whereParameters);
        }

        private int ExecuteNonQuery(string query, Dictionary<string, object> parameters)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                using (var command = new MySqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            command.Parameters.AddWithValue($"@{param.Key}", param.Value ?? DBNull.Value);
                        }
                    }

                    connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
        }
    }
}
