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
    public class BLUser
    {
        private USR01 _objUSR01; // User object for processing.
        private int _id; // User ID for identification.
        private Response _objResponse; // Response object to encapsulate operation results.
        private readonly string _connectionString; // Database connection string.
        private Hashing _objHashing;
        public EnmEntryType Type { get; set; } // Specifies the type of operation (Add, Edit, etc.).

        // Constructor to initialize the connection string and response object.
        public BLUser()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["TravelBookingConnection"].ConnectionString;
            _objResponse = new Response();
            _objHashing = new Hashing();
        }

        // Method to get all users from the database.
        public List<USR01> GetAllUsers()
        {
            List<USR01> lstUsers = new List<USR01>();
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string queryOfSelectAll = "SELECT R01F01, R01F02, R01F04, R01F05 FROM usr01";
                using (var command = new MySqlCommand(queryOfSelectAll, connection))
                {
                    command.CommandType = CommandType.Text;
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var user = new USR01
                            {
                                R01F01 = reader.GetInt32("R01F01"),
                                R01F02 = reader.GetString("R01F02"),
                                R01F04 = reader.GetString("R01F04"),
                                R01F05 = reader.GetString("R01F05")
                            };
                            lstUsers.Add(user);
                        }
                    }
                }
            }
            return lstUsers;
        }

        // Method to get a user by ID.
        public USR01 GetUserByID(int id)
        {
            USR01 user = null;
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = string.Format("SELECT R01F01, R01F02, R01F03, R01F04, R01F05 FROM usr01 WHERE r01f01 = {0}",id);
                using (var command = new MySqlCommand(query, connection))
                {
                    command.CommandType = CommandType.Text;
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
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

        // Method to validate the user before deletion.
        public USR01 PreDelete(int id)
        {
            return GetUserByID(id);
        }

        // Method to perform validation before user deletion.
        public Response ValidationDelete(USR01 objUSR01)
        {
            if (objUSR01 == null)
            {
                _objResponse.IsError = true;
                _objResponse.Message = "User Not Found.";
            }
            return _objResponse;
        }

        // Method to delete a user by ID.
        public Response Delete(int id)
        {
            USR01 user = PreDelete(id);
            Response validationResponse = ValidationDelete(user);

            if (validationResponse.IsError)
                return validationResponse;

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = string.Format("DELETE FROM usr01 WHERE r01f01 = {0}",id);
                using (var command = new MySqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
            _objResponse.Message = "User Deleted Successfully";
            return _objResponse;
        }

        // Method to prepare a user object for saving (Add or Edit).
        public void PreSave(DTOUSR01 objDTOUSR01)
        {
            _objUSR01 = objDTOUSR01.Convert<USR01>();
            _objUSR01.R01F05 = "User";
            _objUSR01.R01F03 = _objHashing.ComputeHash(_objUSR01.R01F03);
            
            if (Type == EnmEntryType.A)
            {
                _objUSR01.R01F06 = DateTime.Now;
            }
            if (Type == EnmEntryType.E && _objUSR01.R01F01 > 0)
            {
                _objUSR01.R01F07 = DateTime.Now;
                _id = _objUSR01.R01F01;
            }
        }

        // Method to validate before saving (Add or Edit).
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

        // Method to save user data (Add or Edit).
        public Response Save()
        {
            string queryOfInsert = string.Format(
                "INSERT INTO usr01 (R01F02, R01F03, R01F04, R01F05, R01F06) VALUES ('{0}', '{1}', '{2}', '{3}','{4}')",
                _objUSR01.R01F02, _objUSR01.R01F03, _objUSR01.R01F04, _objUSR01.R01F05,  _objUSR01.R01F06.ToString("yyyy-MM-dd HH:mm:ss"));

            string queryOfUpdate = string.Format(
                "UPDATE usr01 SET R01F02 = '{0}', R01F03 = '{1}', R01F04 = '{2}', R01F05 = '{3}', R01F07 = '{4}' WHERE R01F01 = '{5}'",
                _objUSR01.R01F02, _objUSR01.R01F03, _objUSR01.R01F04, _objUSR01.R01F05, _objUSR01.R01F07.ToString("yyyy-MM-dd HH:mm:ss"), _objUSR01.R01F01);

            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();

                    if (Type == EnmEntryType.A)
                    {
                        using (var command = new MySqlCommand(queryOfInsert, connection))
                        {
                            command.ExecuteNonQuery();
                            _objResponse.Message = "User Added Successfully";
                        }
                    }
                    else
                    {
                        using (var command = new MySqlCommand(queryOfUpdate, connection))
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
