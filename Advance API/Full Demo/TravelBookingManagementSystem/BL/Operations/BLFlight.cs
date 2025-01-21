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
    public class BLFlight
    {
        private FLT01 _objFLT01; // Flight object for processing.
        private int _id; // Flight ID for identification.
        private Response _objResponse; // Response object to encapsulate operation results.
        private readonly string _connectionString; // Database connection string.
        public EnmEntryType Type { get; set; } // Specifies the type of operation (Add, Edit, etc.).

        // Constructor to initialize the connection string and response object.
        public BLFlight()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["TravelBookingConnection"].ConnectionString;
            _objResponse = new Response();
        }

        // Method to get all flights from the database.
        public List<FLT01> GetAllFlights()
        {
            List<FLT01> lstFlights = new List<FLT01>();
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string queryOfSelectAll = "SELECT T01F01, T01F02, T01F03, T01F04, T01F05, T01F06, T01F07, T01F08, T01F09, T01F10 FROM flt01";
                using (var command = new MySqlCommand(queryOfSelectAll, connection))
                {
                    command.CommandType = CommandType.Text;
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var flight = new FLT01
                            {
                                T01F01 = reader.GetInt32("T01F01"),
                                T01F02 = reader.GetString("T01F02"),
                                T01F03 = reader.GetString("T01F03"),
                                T01F04 = reader.GetString("T01F04"),
                                T01F05 = reader.GetDateTime("T01F05"),
                                T01F06 = reader.GetDateTime("T01F06"),
                                T01F07 = reader.GetDecimal("T01F07"),
                                T01F08 = reader.GetString("T01F08"),
                                T01F09 = reader.GetDateTime("T01F09"),
                                T01F10 = reader.GetDateTime("T01F10")
                            };
                            lstFlights.Add(flight);
                        }
                    }
                }
            }
            return lstFlights;
        }

        // Method to get a flight by ID.
        public FLT01 GetFlightByID(int id)
        {
            FLT01 flight = null;
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = $"SELECT T01F01, T01F02, T01F03, T01F04, T01F05, T01F06, T01F07, T01F08, T01F09, T01F10 FROM flt01 WHERE T01F01 = {id}";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.CommandType = CommandType.Text;
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            flight = new FLT01
                            {
                                T01F01 = reader.GetInt32("T01F01"),
                                T01F02 = reader.GetString("T01F02"),
                                T01F03 = reader.GetString("T01F03"),
                                T01F04 = reader.GetString("T01F04"),
                                T01F05 = reader.GetDateTime("T01F05"),
                                T01F06 = reader.GetDateTime("T01F06"),
                                T01F07 = reader.GetDecimal("T01F07"),
                                T01F08 = reader.GetString("T01F08"),
                                T01F09 = reader.GetDateTime("T01F09"),
                                T01F10 = reader.GetDateTime("T01F10")
                            };
                        }
                    }
                }
            }
            return flight;
        }

        // Method to prepare a flight object for saving (Add or Edit).
        public void PreSave(DTOFLT01 objDTOFLT01)
        {
            _objFLT01 = objDTOFLT01.Convert<FLT01>();
            if (Type == EnmEntryType.A)
            {
                _objFLT01.T01F09 = DateTime.Now;
            }
            if (Type == EnmEntryType.E && _objFLT01.T01F01 > 0)
            {
                _objFLT01.T01F10 = DateTime.Now;
                _id = _objFLT01.T01F01;
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

                if (GetFlightByID(_id) == null)
                {
                    _objResponse.IsError = true;
                    _objResponse.Message = "Flight Not Found";
                }
            }
            return _objResponse;
        }

        // Method to save flight data (Add or Edit).
        public Response Save()
        {
            string queryOfInsert = string.Format(
                "INSERT INTO flt01 (T01F02, T01F03, T01F04, T01F05, T01F06, T01F07, T01F08, T01F09) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', {5}, '{6}', '{7}')",
                _objFLT01.T01F02, _objFLT01.T01F03, _objFLT01.T01F04, _objFLT01.T01F05.ToString("yyyy-MM-dd HH:mm:ss"),
                _objFLT01.T01F06.ToString("yyyy-MM-dd HH:mm:ss"), _objFLT01.T01F07, _objFLT01.T01F08, _objFLT01.T01F09.ToString("yyyy-MM-dd HH:mm:ss"));

            string queryOfUpdate = string.Format(
                "UPDATE flt01 SET T01F02 = '{0}', T01F03 = '{1}', T01F04 = '{2}', T01F05 = '{3}', T01F06 = '{4}', T01F07 = {5}, T01F08 = '{6}', T01F10 = '{7}' WHERE T01F01 = {8}",
                _objFLT01.T01F02, _objFLT01.T01F03, _objFLT01.T01F04, _objFLT01.T01F05.ToString("yyyy-MM-dd HH:mm:ss"),
                _objFLT01.T01F06.ToString("yyyy-MM-dd HH:mm:ss"), _objFLT01.T01F07, _objFLT01.T01F08, _objFLT01.T01F10.ToString("yyyy-MM-dd HH:mm:ss"), _objFLT01.T01F01);

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
                            _objResponse.Message = "Flight Added Successfully";
                        }
                    }
                    else
                    {
                        using (var command = new MySqlCommand(queryOfUpdate, connection))
                        {
                            command.ExecuteNonQuery();
                            _objResponse.Message = "Flight Updated Successfully";
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

        // Method to delete a flight by ID.
        public Response Delete(int id)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = $"DELETE FROM flt01 WHERE T01F01 = {id}";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
            _objResponse.Message = "Flight Deleted Successfully";
            return _objResponse;
        }
    }
}
