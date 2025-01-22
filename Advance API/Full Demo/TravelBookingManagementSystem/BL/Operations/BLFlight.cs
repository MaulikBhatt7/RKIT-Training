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
    /// <summary>
    /// Business Logic class for handling flights in the Travel Booking Management System.
    /// This class provides methods to manage flights including adding, editing, retrieving, and deleting flights.
    /// </summary>
    public class BLFlight
    {
        private FLT01 _objFLT01; // Flight object for processing.
        private int _id; // Flight ID for identification.
        private Response _objResponse; // Response object to encapsulate operation results.
        private readonly string _connectionString; // Database connection string.
        public EnmEntryType Type { get; set; } // Specifies the type of operation (Add, Edit, etc.).
        private readonly IDbConnectionFactory _dbFactory; // Factory to manage database connections.

        /// <summary>
        /// Constructor to initialize the connection string and response object.
        /// </summary>
        public BLFlight()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["TravelBookingConnection"].ConnectionString;
            _objResponse = new Response();
            _dbFactory = HttpContext.Current.Application["DbFactory"] as IDbConnectionFactory;
        }

        /// <summary>
        /// Method to get all flights from the database.
        /// </summary>
        /// <returns>List of all flights</returns>
        public List<FLT01> GetAllFlights()
        {
            string cacheKey = "GetAllFlights";

            // Check if the data exists in the cache
            List<FLT01> cachedFlights = CacheHelper.GetFromCache<List<FLT01>>(cacheKey);
            if (cachedFlights != null)
            {
                return cachedFlights; // Return cached data
            }
            using (IDbConnection dbConnection = _dbFactory.OpenDbConnection())
            {
                List<FLT01> lstFlight = dbConnection.Select<FLT01>(); // Fetch all flight records.

                CacheHelper.AddToCache(cacheKey, lstFlight, 30); // Add data to cache

                return lstFlight;
            }
        }

        /// <summary>
        /// Method to get a flight by ID.
        /// </summary>
        /// <param name="id">Flight ID</param>
        /// <returns>Flight object</returns>
        public FLT01 GetFlightByID(int id)
        {
            using (IDbConnection dbConnection = _dbFactory.OpenDbConnection())
            {
                return dbConnection.SingleById<FLT01>(id); // Fetch flight by id.
            }
        }

        /// <summary>
        /// Method to prepare a flight object for saving (Add or Edit).
        /// </summary>
        /// <param name="objDTOFLT01">DTO object for flight</param>
        public void PreSave(DTOFLT01 objDTOFLT01)
        {
            _objFLT01 = objDTOFLT01.Convert<FLT01>();
            if (Type == EnmEntryType.A)
            {
                _objFLT01.T01F09 = DateTime.Now; // Set creation timestamp
            }
            if (Type == EnmEntryType.E && _objFLT01.T01F01 > 0)
            {
                _objFLT01.T01F10 = DateTime.Now; // Set update timestamp
                _id = _objFLT01.T01F01; // Store flight ID for validation
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

                if (GetFlightByID(_id) == null)
                {
                    _objResponse.IsError = true;
                    _objResponse.Message = "Flight Not Found";
                }
            }
            return _objResponse;
        }

        /// <summary>
        /// Method to save flight data (Add or Edit).
        /// </summary>
        /// <returns>Response object indicating the result of the save operation</returns>
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
                    { "T01F06", _objFLT01.T01F06 },
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

            // Clear cache for all flights
            CacheHelper.RemoveFromCache("GetAllFlights");

            return _objResponse;
        }

        /// <summary>
        /// Method to delete a flight by ID.
        /// </summary>
        /// <param name="id">Flight ID</param>
        /// <returns>Response object indicating the result of the delete operation</returns>
        public Response Delete(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = $"DELETE FROM flt01 WHERE T01F01 = {id}";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
            _objResponse.Message = "Flight Deleted Successfully";
            // Clear cache for all flights
            CacheHelper.RemoveFromCache("GetAllFlights");
            return _objResponse;
        }
    }
}