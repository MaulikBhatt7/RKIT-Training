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
using System.Data.Odbc;
using ServiceStack.Data;
using System.Web;
using ServiceStack.OrmLite;
using TravelBookingManagementSystem.Handlers;

namespace TravelBookingManagementSystem.BL.Operations
{
    public class BLFlight
    {
        private FLT01 _objFLT01; // Flight object for processing.
        private int _id; // Flight ID for identification.
        private Response _objResponse; // Response object to encapsulate operation results.
        private readonly string _connectionString; // Database connection string.
        public EnmEntryType Type { get; set; } // Specifies the type of operation (Add, Edit, etc.).
        private readonly IDbConnectionFactory _dbFactory; // Factory to manage database connections.

        // Constructor to initialize the connection string and response object.
        public BLFlight()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["TravelBookingConnection"].ConnectionString;
            _objResponse = new Response();
            _dbFactory = HttpContext.Current.Application["DbFactory"] as IDbConnectionFactory;
        }

        // Method to get all flights from the database.
        public List<FLT01> GetAllFlights()
        {
            using (IDbConnection db = _dbFactory.OpenDbConnection())
            {
                return db.Select<FLT01>(); // Fetch all flights records.
            }
        }

        // Method to get a flight by ID.
        public FLT01 GetFlightByID(int id)
        {
            using (IDbConnection db = _dbFactory.OpenDbConnection())
            {
                return db.SingleById<FLT01>(id); // Fetch flight by id.
            }
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
            DynamicQueryHandler objDynamicQueryHandler = new DynamicQueryHandler(_connectionString);

            try
            {
                // Prepare column values for insert or update
                Dictionary<string, object> parameters = new Dictionary<string, object>
        {
            { "T01F02", _objFLT01.T01F02 },
            { "T01F03", _objFLT01.T01F03 },
            { "T01F04", _objFLT01.T01F04 },
            { "T01F05", _objFLT01.T01F05 },
            { "T01F06", _objFLT01.T01F06},
            { "T01F07", _objFLT01.T01F07 },
            { "T01F08", _objFLT01.T01F08 },
        };

                if (Type == EnmEntryType.A)
                {
                    // Insert logic
                    parameters["T01F09"] = _objFLT01.T01F09.ToString("yyyy-MM-dd HH:mm:ss");
                    objDynamicQueryHandler.Insert("FLT01", parameters);
                    _objResponse.Message = "Flight Added Successfully";
                }
                else
                {
                    // Update logic
                    parameters["T01F10"] = _objFLT01.T01F10.ToString("yyyy-MM-dd HH:mm:ss");
                    string whereClause = "T01F01 = @T01F01";
                    Dictionary<string, object> whereParameters = new Dictionary<string, object>
            {
                { "T01F01", _objFLT01.T01F01 }
            };

                    objDynamicQueryHandler.Update("FLT01", parameters, whereClause, whereParameters);
                    _objResponse.Message = "Flight Updated Successfully";
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
