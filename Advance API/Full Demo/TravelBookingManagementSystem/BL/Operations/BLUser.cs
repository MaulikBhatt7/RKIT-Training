using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;
using TravelBookingManagementSystem.Extensions;
using TravelBookingManagementSystem.Models.DTO;
using TravelBookingManagementSystem.Models.POCO;
using TravelBookingManagementSystem.Models;
using TravelBookingManagementSystem.Models.Enum;
using TravelBookingManagementSystem.Security;

namespace TravelBookingManagementSystem.BL.Operations
{
    /// <summary>
    /// Business Logic class for handling users in the Travel Booking Management System.
    /// This class provides methods to manage users including adding, editing, retrieving, and deleting users.
    /// </summary>
    public class BLUser
    {
        private USR01 _objUSR01; // User object for processing.
        private int _id; // User ID for identification.
        private Response _objResponse; // Response object to encapsulate operation results.
        private readonly string _connectionString; // Database connection string.
        private Hashing _objHashing; // Hashing utility for password hashing.
        public EnmEntryType Type { get; set; } // Specifies the type of operation (Add, Edit, etc.).

        /// <summary>
        /// Constructor to initialize the connection string and response object.
        /// </summary>
        public BLUser()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["TravelBookingConnection"].ConnectionString;
            _objResponse = new Response();
            _objHashing = new Hashing();
        }

        /// <summary>
        /// Method to get all users from the database.
        /// </summary>
        /// <returns>List of all users</returns>
        public List<USR01> GetAllUsers()
        {
            List<USR01> lstUsers = new List<USR01>();
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string queryOfSelectAll = "SELECT R01F01, R01F02, R01F04, R01F05 FROM usr01";
                using (MySqlCommand command = new MySqlCommand(queryOfSelectAll, connection))
                {
                    command.CommandType = CommandType.Text;
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Create a new user object and populate with data from reader
                            var user = new USR01
                            {
                                R01F01 = reader.GetInt32("R01F01"),
                                R01F02 = reader.GetString("R01F02"),
                                R01F04 = reader.GetString("R01F04"),
                                R01F05 = reader.GetString("R01F05")
                            };
                            lstUsers.Add(user); // Add user to the list
                        }
                    }
                }
            }
            return lstUsers;
        }

        /// <summary>
        /// Method to get a user by ID.
        /// </summary>
        /// <param name="id">User ID</param>
        /// <returns>User object</returns>
        public USR01 GetUserByID(int id)
        {
            USR01 user = null;
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = $"SELECT R01F01, R01F02, R01F03, R01F04, R01F05 FROM usr01 WHERE R01F01 = {id}";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.CommandType = CommandType.Text;
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Create a user object and populate with data from reader
                            user = new USR01
                            {
                                R01F01 = reader.GetInt32("R01F01"),
                                R01F02 = reader.GetString("R01F02"),
                                R01F03 = reader.GetString("R01F03"),
                                R01F04 = reader.GetString("R01F04"),
                                R01F05 = reader.GetString("R01F05")
                            };
                        }
                    }
                }
            }
            return user;
        }

        /// <summary>
        /// Method to validate the user before deletion.
        /// </summary>
        /// <param name="id">User ID</param>
        /// <returns>User object</returns>
        public USR01 PreDelete(int id)
        {
            return GetUserByID(id); // Retrieve user by ID for validation before deletion
        }

        /// <summary>
        /// Method to perform validation before user deletion.
        /// </summary>
        /// <param name="objUSR01">User object</param>
        /// <returns>Response object indicating validation results</returns>
        public Response ValidationDelete(USR01 objUSR01)
        {
            if (objUSR01 == null)
            {
                _objResponse.IsError = true;
                _objResponse.Message = "User Not Found.";
            }
            return _objResponse;
        }

        /// <summary>
        /// Method to delete a user by ID.
        /// </summary>
        /// <param name="id">User ID</param>
        /// <returns>Response object indicating the result of the delete operation</returns>
        public Response Delete(int id)
        {
            USR01 user = PreDelete(id); // Validate user before deletion
            Response validationResponse = ValidationDelete(user);

            if (validationResponse.IsError)
                return validationResponse;

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = $"DELETE FROM usr01 WHERE R01F01 = {id}";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.ExecuteNonQuery(); // Execute delete command
                }
            }
            _objResponse.Message = "User Deleted Successfully";
            return _objResponse;
        }

        /// <summary>
        /// Method to prepare a user object for saving (Add or Edit).
        /// </summary>
        /// <param name="objDTOUSR01">DTO object for user</param>
        public void PreSave(DTOUSR01 objDTOUSR01)
        {
            _objUSR01 = objDTOUSR01.Convert<USR01>();
            _objUSR01.R01F05 = "User"; // Default role for new users
            _objUSR01.R01F03 = _objHashing.ComputeHash(_objUSR01.R01F03); // Hash the password

            if (Type == EnmEntryType.A)
            {
                _objUSR01.R01F06 = DateTime.Now; // Set creation timestamp
            }
            if (Type == EnmEntryType.E && _objUSR01.R01F01 > 0)
            {
                _objUSR01.R01F07 = DateTime.Now; // Set update timestamp
                _id = _objUSR01.R01F01; // Store user ID for validation
            }
        }

        /// <summary>
        /// Method to validate before saving (Add or Edit).
        /// </summary>
        /// <returns>Response object indicating validation results</returns>
        public Response Validation()
        {
            if (Type == EnmEntryType.E)
            {
                if (_id <= 0)
                {
                    _objResponse.IsError = true;
                    _objResponse.Message = "Enter Correct ID";
                    return _objResponse;
                }

                if (GetUserByID(_id) == null)
                {
                    _objResponse.IsError = true;
                    _objResponse.Message = "User Not Found";
                }
            }
            return _objResponse;
        }

        /// <summary>
        /// Method to save user data (Add or Edit).
        /// </summary>
        /// <returns>Response object indicating the result of the save operation</returns>
        public Response Save()
        {
            // Prepare insert query
            string queryOfInsert = $"INSERT INTO usr01 (R01F02, R01F03, R01F04, R01F05, R01F06) VALUES ('{_objUSR01.R01F02}', '{_objUSR01.R01F03}', '{_objUSR01.R01F04}', '{_objUSR01.R01F05}', '{_objUSR01.R01F06.ToString("yyyy-MM-dd HH:mm:ss")}')";

            // Prepare update query
            string queryOfUpdate = $"UPDATE usr01 SET R01F02 = '{_objUSR01.R01F02}', R01F03 = '{_objUSR01.R01F03}', R01F04 = '{_objUSR01.R01F04}', R01F05 = '{_objUSR01.R01F05}', R01F07 = '{_objUSR01.R01F07.ToString("yyyy-MM-dd HH:mm:ss")}' WHERE R01F01 = '{_objUSR01.R01F01}'";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();

                    if (Type == EnmEntryType.A)
                    {
                        // Execute insert command
                        using (MySqlCommand command = new MySqlCommand(queryOfInsert, connection))
                        {
                            command.ExecuteNonQuery();
                            _objResponse.Message = "User Added Successfully";
                        }
                    }
                    else
                    {
                        // Execute update command
                        using (MySqlCommand command = new MySqlCommand(queryOfUpdate, connection))
                        {
                            command.ExecuteNonQuery();
                            _objResponse.Message = "User Updated Successfully";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _objResponse.IsError = true;
                _objResponse.Message = ex.Message;
            }
            return _objResponse;
        }
    }
}