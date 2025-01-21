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

namespace TravelBookingManagementSystem.BL.Operations
{
    public class BLHotel
    {
        private HTL01 _objHTL01; // Hotel object for processing.
        private int _id; // Hotel ID for identification.
        private Response _objResponse; // Response object to encapsulate operation results.
        private readonly string _connectionString; // Database connection string.
        public EnmEntryType Type { get; set; } // Specifies the type of operation (Add, Edit, etc.).

        // Constructor to initialize the connection string and response object.
        public BLHotel()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["TravelBookingConnection"].ConnectionString;
            _objResponse = new Response();
        }

        // Method to get all hotels from the database.
        public List<HTL01> GetAllHotels()
        {
            List<HTL01> lstHotels = new List<HTL01>();
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string queryOfSelectAll = "SELECT L01F01, L01F02, L01F03, L01F04, L01F05, L01F06 FROM htl01";
                using (var command = new MySqlCommand(queryOfSelectAll, connection))
                {
                    command.CommandType = CommandType.Text;
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var hotel = new HTL01
                            {
                                L01F01 = reader.GetInt32("L01F01"),
                                L01F02 = reader.GetString("L01F02"),
                                L01F03 = reader.GetString("L01F03"),
                                L01F04 = reader.GetDecimal("L01F04"),
                                L01F05 = reader.GetFloat("L01F05"),
                                L01F06 = reader.GetInt32("L01F06")
                            };
                            lstHotels.Add(hotel);
                        }
                    }
                }
            }
            return lstHotels;
        }

        // Method to get a hotel by ID.
        public HTL01 GetHotelByID(int id)
        {
            HTL01 hotel = null;
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = $"SELECT L01F01, L01F02, L01F03, L01F04, L01F05, L01F06 FROM htl01 WHERE L01F01 = {id}";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.CommandType = CommandType.Text;
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            hotel = new HTL01
                            {
                                L01F01 = reader.GetInt32("L01F01"),
                                L01F02 = reader.GetString("L01F02"),
                                L01F03 = reader.GetString("L01F03"),
                                L01F04 = reader.GetDecimal("L01F04"),
                                L01F05 = reader.GetFloat("L01F05"),
                                L01F06 = reader.GetInt32("L01F06")
                            };
                        }
                    }
                }
            }
            return hotel;
        }

        // Method to prepare a hotel object for saving (Add or Edit).
        public void PreSave(DTOHTL01 objDTOHTL01)
        {
            _objHTL01 = objDTOHTL01.Convert<HTL01>();
            if (Type == EnmEntryType.A)
            {
                _objHTL01.L01F07 = DateTime.Now;
            }
            if (Type == EnmEntryType.E && _objHTL01.L01F01 > 0)
            {
                _objHTL01.L01F08 = DateTime.Now;
                _id = _objHTL01.L01F01;
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

                if (GetHotelByID(_id) == null)
                {
                    _objResponse.IsError = true;
                    _objResponse.Message = "Hotel Not Found";
                }
            }
            return _objResponse;
        }

        // Method to save hotel data (Add or Edit).
        public Response Save()
        {
            string queryOfInsert = string.Format(
                "INSERT INTO htl01 (L01F02, L01F03, L01F04, L01F05, L01F06, L01F07) VALUES ('{0}', '{1}', {2}, '{3}', '{4}', '{5}')",
                _objHTL01.L01F02, _objHTL01.L01F03, _objHTL01.L01F04, _objHTL01.L01F05, _objHTL01.L01F06,  _objHTL01.L01F07.ToString("yyyy-MM-dd HH:mm:ss"));

            string queryOfUpdate = string.Format(
                "UPDATE htl01 SET L01F02 = '{0}', L01F03 = '{1}', L01F04 = {2}, L01F05 = {3}, L01F06 = {4}, L01F06 = '{5}' WHERE L01F01 = {6}",
                _objHTL01.L01F02, _objHTL01.L01F03, _objHTL01.L01F04, _objHTL01.L01F05, _objHTL01.L01F06, _objHTL01.L01F08.ToString("yyyy-MM-dd HH:mm:ss"), _objHTL01.L01F01);

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
                            _objResponse.Message = "Hotel Added Successfully";
                        }
                    }
                    else
                    {
                        using (var command = new MySqlCommand(queryOfUpdate, connection))
                        {
                            command.ExecuteNonQuery();
                            _objResponse.Message = "Hotel Updated Successfully";
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

        // Method to delete a hotel by ID.
        public Response Delete(int id)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = $"DELETE FROM htl01 WHERE L01F01 = {id}";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
            _objResponse.Message = "Hotel Deleted Successfully";
            return _objResponse;
        }
    }
}
