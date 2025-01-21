using System;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;
using TravelBookingManagementSystem.Models;
using TravelBookingManagementSystem.Models.DTO;
using TravelBookingManagementSystem.Models.POCO;
using TravelBookingManagementSystem.BL.Operations;
using TravelBookingManagementSystem.Security;
using TravelBookingManagementSystem.Handlers;
using System.Net.PeerToPeer;
using System.Web.Security;

namespace TravelBookingManagementSystem.BL.Operations
{
    /// <summary>
    /// Business logic for handling login-related operations.
    /// </summary>
    public class BLLogin
    {
        private readonly string _connectionString;
        private readonly Response _objResponse;
        private BLConverter _objBLConverter;
        private Hashing _objHashing;
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
        /// <param name="loginDto">The login details (username and password).</param>
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

                objDTOUSR02.R01F03 = _objHashing.ComputeHash(objDTOUSR02.R01F03);

                // Query to check user credentials
                string query = string.Format("SELECT R01F01, R01F02, R01F05 FROM usr01 WHERE r01f02 = '{0}' and r01f03 = '{1}'", objDTOUSR02.R01F02, objDTOUSR02.R01F03);

                using (var connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();

                    using (var command = new MySqlCommand(query, connection))
                    {
                        

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // User found, populate response with user details
                                int id = reader.GetInt32("R01F01");
                                string username = reader.GetString("R01F02");
                                string role = reader.GetString("R01F05");
                               

                                var generatedToken = JwtHandler.GenerateToken(username, role);
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
