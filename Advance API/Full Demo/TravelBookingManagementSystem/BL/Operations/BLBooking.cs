using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;
using TravelBookingManagementSystem.Models.DTO;
using TravelBookingManagementSystem.Models.POCO;
using TravelBookingManagementSystem.Models;
using TravelBookingManagementSystem.Models.Enum;
using TravelBookingManagementSystem.Extensions;
using System.Web;

namespace TravelBookingManagementSystem.BL.Operations
{
    public class BLBooking
    {
        private BOK01 _objBOK01; // Booking object for processing.
        private int _id; // Booking ID for identification.
        private Response _objResponse; // Response object to encapsulate operation results.
        private readonly string _connectionString; // Database connection string.
        public EnmEntryType Type { get; set; } // Specifies the type of operation (Add, Edit, etc.).

        // Constructor to initialize the connection string and response object.
        public BLBooking()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["TravelBookingConnection"].ConnectionString;
            _objResponse = new Response();
        }

        // Method to get all bookings from the database.
        public List<BOK01> GetAllBookings()
        {
            List<BOK01> lstBookings = new List<BOK01>();
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string queryOfSelectAll = "SELECT K01F01, K01F02, K01F03, K01F04, K01F05, K01F06, K01F07, K01F08 FROM bok01";
                using (var command = new MySqlCommand(queryOfSelectAll, connection))
                {
                    command.CommandType = CommandType.Text;
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var booking = new BOK01
                            {
                                K01F01 = reader.GetInt32("K01F01"),
                                K01F02 = reader.GetString("K01F02"),
                                K01F03 = reader.GetString("K01F03"),
                                K01F04 = reader.GetDateTime("K01F04"),
                                K01F05 = reader.GetString("K01F05"),
                                K01F06 = reader.GetInt32("K01F06"),
                                K01F07 = reader.GetDateTime("K01F07"),
                                K01F08 = reader.GetDateTime("K01F08")
                            };
                            lstBookings.Add(booking);
                        }
                    }
                }
            }
            return lstBookings;
        }

        // Method to get a booking by ID.
        public BOK01 GetBookingByID(int id)
        {
            BOK01 booking = null;
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = $"SELECT K01F01, K01F02, K01F03, K01F04, K01F05, K01F06, K01F07, K01F08, K01F09 FROM bok01 WHERE K01F01 = {id}";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.CommandType = CommandType.Text;
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            booking = new BOK01
                            {
                                K01F01 = reader.GetInt32("K01F01"),
                                K01F02 = reader.GetString("K01F02"),
                                K01F03 = reader.GetString("K01F03"),
                                K01F04 = reader.GetDateTime("K01F04"),
                                K01F05 = reader.GetString("K01F05"),
                                K01F06 = reader.GetInt32("K01F06"),
                                K01F07 = reader.GetDateTime("K01F07"),
                                K01F08 = reader.GetDateTime("K01F08"),
                                K01F09 = reader.GetInt32("K01F09")
                            };
                        }
                    }
                }
            }
            return booking;
        }

        // Method to prepare a booking object for saving (Add or Edit).
        public void PreSave(DTOBOK01 objDTOBOK01, int userID)
        {
            _objBOK01 = objDTOBOK01.Convert<BOK01>();

            if (Type == EnmEntryType.A)
            {
                _objBOK01.K01F09 = userID;
                _objBOK01.K01F07 = DateTime.Now; // Set creation timestamp
            }
            if (Type == EnmEntryType.E && _objBOK01.K01F01 > 0)
            {
                _objBOK01.K01F08 = DateTime.Now; // Set update timestamp
                _id = _objBOK01.K01F01; // Store booking ID for validation
            }
        }

        // Method to validate before saving (Add or Edit).
        public Response Validation(int userID)
        {
            if (Type == EnmEntryType.E)
            {
                if (_id <= 0)
                {
                    _objResponse.IsError = true;
                    _objResponse.Message = "Enter Correct ID";
                    return _objResponse;
                }
                BOK01 objBOK01 = GetBookingByID(_id);
                if (objBOK01 == null)
                {
                    _objResponse.IsError = true;
                    _objResponse.Message = "Booking Not Found";
                }

                if (objBOK01.K01F09 != userID)
                {
                    _objResponse.IsError = true;
                    _objResponse.Message = "You are not authorized to update this record.";
                }
            }
            return _objResponse;
        }

        // Method to save booking data (Add or Edit).
        public Response Save()
        {
            string queryOfInsert = string.Format(
                "INSERT INTO bok01 (K01F02, K01F03, K01F04, K01F05, K01F06, K01F07, K01F09) VALUES ('{0}', '{1}', '{2}', '{3}', {4}, '{5}', '{6}')",
                _objBOK01.K01F02, _objBOK01.K01F03, _objBOK01.K01F04.ToString("yyyy-MM-dd HH:mm:ss"), _objBOK01.K01F05, _objBOK01.K01F06, _objBOK01.K01F07.ToString("yyyy-MM-dd HH:mm:ss"), _objBOK01.K01F09);

            string queryOfUpdate = string.Format(
                "UPDATE bok01 SET K01F02 = '{0}', K01F03 = '{1}', K01F04 = '{2}', K01F05 = '{3}', K01F06 = {4}, K01F08 = '{5}' WHERE K01F01 = {6}",
                _objBOK01.K01F02, _objBOK01.K01F03, _objBOK01.K01F04.ToString("yyyy-MM-dd HH:mm:ss"), _objBOK01.K01F05, _objBOK01.K01F06, _objBOK01.K01F08.ToString("yyyy-MM-dd HH:mm:ss"), _objBOK01.K01F01);

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
                            _objResponse.Message = "Booking Added Successfully";
                        }
                    }
                    else
                    {
                        using (var command = new MySqlCommand(queryOfUpdate, connection))
                        {
                            command.ExecuteNonQuery();
                            _objResponse.Message = "Booking Updated Successfully";
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

        // Method to delete a booking by ID.
        public Response Delete(int id)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = $"DELETE FROM bok01 WHERE K01F01 = {id}";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
            _objResponse.Message = "Booking Deleted Successfully";
            return _objResponse;
        }
    }
}
