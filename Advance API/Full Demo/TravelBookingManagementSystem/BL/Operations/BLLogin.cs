using System;
using System.Configuration;
using MySql.Data.MySqlClient;
using TravelBookingManagementSystem.Models;
using TravelBookingManagementSystem.Models.DTO;
using TravelBookingManagementSystem.Security;
using TravelBookingManagementSystem.Handlers;

namespace TravelBookingManagementSystem.BL.Operations
{
    /// <summary>
    /// Business logic for handling login-related operations.
    /// </summary>
    public class BLLogin
    {
        private readonly string _connectionString; // Database connection string.
        private readonly Response _objResponse; // Response object to encapsulate operation results.
        private BLConverter _objBLConverter; // Converter for handling data transformations.
        private Hashing _objHashing; // Hashing utility for password hashing.

        /// <summary>
        /// Initializes a new instance of the <see cref="BLLogin"/> class.
        /// </summary>
        public BLLogin()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["TravelBookingConnection"].ConnectionString;
            _objResponse = new Response();
            _objHashing = new Hashing();
            _objBLConverter = new BLConverter();
        }

        /// <summary>
        /// Validates user credentials and returns the login result.
        /// </summary>
        /// <param name="objDTOUSR02">The login details (username and password).</param>
        /// <returns>A <see cref="Response"/> object indicating the result of the operation.</returns>
        public Response Authenticate(DTOUSR02 objDTOUSR02)
        {
            try
            {
                // Validate input
                if (string.IsNullOrEmpty(objDTOUSR02.R01F02) || string.IsNullOrEmpty(objDTOUSR02.R01F03))
                {
                    _objResponse.IsError = true;
                    _objResponse.Message = "Username and Password cannot be empty.";
                    return _objResponse;
                }

                // Hash the password
                objDTOUSR02.R01F03 = _objHashing.ComputeHash(objDTOUSR02.R01F03);

                // Query to check user credentials
                string query = $"SELECT R01F01, R01F02, R01F05 FROM usr01 WHERE R01F02 = '{objDTOUSR02.R01F02}' AND R01F03 = '{objDTOUSR02.R01F03}'";

                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // User found, populate response with user details
                                int id = reader.GetInt32("R01F01");
                                string username = reader.GetString("R01F02");
                                string role = reader.GetString("R01F05");

                                // Generate JWT token
                                string generatedToken = JwtHandler.GenerateToken(username, id, role);
                                var userData = new 
                                {
                                    Token = generatedToken,
                                    ID = id,
                                    Username = username,
                                    Role = role
                                };

                                _objResponse.Data = _objBLConverter.ObjectToDataTable(userData);
                                _objResponse.Message = "Login successful.";
                            }
                            else
                            {
                                // User not found or invalid credentials
                                _objResponse.IsError = true;
                                _objResponse.Message = "Invalid username or password.";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _objResponse.IsError = true;
                _objResponse.Message = $"An error occurred during login: {ex.Message}";
            }

            return _objResponse;
        }
    }
}