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
    /// Business Logic class for handling hotels in the Travel Booking Management System.
    /// This class provides methods to manage hotels including adding, editing, retrieving, and deleting hotels.
    /// </summary>
    public class BLHotel
    {
        private HTL01 _objHTL01; // Hotel object for processing.
        private int _id; // Hotel ID for identification.
        private Response _objResponse; // Response object to encapsulate operation results.
        private readonly string _connectionString; // Database connection string.
        private readonly IDbConnectionFactory _dbFactory; // Factory to manage database connections.
        public EnmEntryType Type { get; set; } // Specifies the type of operation (Add, Edit, etc.).

        /// <summary>
        /// Constructor to initialize the connection string and response object.
        /// </summary>
        public BLHotel()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["TravelBookingConnection"].ConnectionString;
            _objResponse = new Response();
            _dbFactory = HttpContext.Current.Application["DbFactory"] as IDbConnectionFactory;
        }

        /// <summary>
        /// Method to get all hotels from the database.
        /// </summary>
        /// <returns>List of all hotels</returns>
        public List<HTL01> GetAllHotels()
        {
            string cacheKey = "GetAllHotels";

            // Check if the data exists in the cache
            List<HTL01> cachedHotels = CacheHelper.GetFromCache<List<HTL01>>(cacheKey);
            if (cachedHotels != null)
            {
                return cachedHotels; // Return cached data
            }
            using (IDbConnection dbConnection = _dbFactory.OpenDbConnection())
            {
                List<HTL01> lstHotel = dbConnection.Select<HTL01>(); // Fetch all hotel records.

                CacheHelper.AddToCache(cacheKey, lstHotel, 30); // Add data to cache

                return lstHotel;
            }
        }

        /// <summary>
        /// Method to get a hotel by ID.
        /// </summary>
        /// <param name="id">Hotel ID</param>
        /// <returns>Hotel object</returns>
        public HTL01 GetHotelByID(int id)
        {
            using (IDbConnection dbConnection = _dbFactory.OpenDbConnection())
            {
                return dbConnection.SingleById<HTL01>(id); // Fetch hotel record by ID.
            }
        }

        /// <summary>
        /// Method to prepare a hotel object for saving (Add or Edit).
        /// </summary>
        /// <param name="objDTOHTL01">DTO object for hotel</param>
        public void PreSave(DTOHTL01 objDTOHTL01)
        {
            _objHTL01 = objDTOHTL01.Convert<HTL01>();
            if (Type == EnmEntryType.A)
            {
                _objHTL01.L01F07 = DateTime.Now; // Set creation timestamp
            }
            if (Type == EnmEntryType.E && _objHTL01.L01F01 > 0)
            {
                _objHTL01.L01F08 = DateTime.Now; // Set update timestamp
                _id = _objHTL01.L01F01; // Store hotel ID for validation
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

                if (GetHotelByID(_id) == null)
                {
                    _objResponse.IsError = true;
                    _objResponse.Message = "Hotel Not Found";
                }
            }
            return _objResponse;
        }

        /// <summary>
        /// Method to save hotel data (Add or Edit).
        /// </summary>
        /// <returns>Response object indicating the result of the save operation</returns>
        public Response Save()
        {
            DynamicQueryHandler objDynamicQueryHandler = new DynamicQueryHandler(_connectionString);

            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "L01F02", _objHTL01.L01F02 },
                    { "L01F03", _objHTL01.L01F03 },
                    { "L01F04", _objHTL01.L01F04 },
                    { "L01F05", _objHTL01.L01F05 },
                    { "L01F06", _objHTL01.L01F06 },
                };

                if (Type == EnmEntryType.A)
                {
                    // Insert logic
                    parameters["L01F07"] = _objHTL01.L01F07.ToString("yyyy-MM-dd HH:mm:ss");
                    objDynamicQueryHandler.Insert("HTL01", parameters);
                    _objResponse.Message = "Hotel Added Successfully";
                }
                else
                {
                    // Update logic
                    string whereClause = "L01F01 = @L01F01";
                    Dictionary<string, object> whereParameters = new Dictionary<string, object>
                    {
                        { "L01F01", _objHTL01.L01F01 }
                    };

                    parameters["L01F08"] = _objHTL01.L01F08.ToString("yyyy-MM-dd HH:mm:ss");
                    objDynamicQueryHandler.Update("HTL01", parameters, whereClause, whereParameters);
                    _objResponse.Message = "Hotel Updated Successfully";
                }

                // Clear cache for all hotels
                CacheHelper.RemoveFromCache("GetAllHotels");
            }
            catch (Exception ex)
            {
                _objResponse.IsError = true;
                _objResponse.Message = ex.Message;
            }
            return _objResponse;
        }

        /// <summary>
        /// Method to validate before deleting a hotel.
        /// </summary>
        /// <param name="id">Hotel ID</param>
        /// <returns>Response object indicating validation results</returns>
        public Response ValidationDelete(int id)
        {
            dynamic checkHotelUsed = null;
            using (IDbConnection dbConnection = _dbFactory.OpenDbConnection())
            {
                checkHotelUsed = dbConnection.Select<BOK01>(objBOK01 => objBOK01.K01F06 == id); // Check if hotel is used in bookings
            }
            if (checkHotelUsed != null)
            {
                _objResponse.IsError = true;
                _objResponse.Message = "You can't delete this Hotel because this Hotel is booked by a user";
            }
            return _objResponse;
        }

        /// <summary>
        /// Method to delete a hotel by ID.
        /// </summary>
        /// <param name="id">Hotel ID</param>
        /// <returns>Response object indicating the result of the delete operation</returns>
        public Response Delete(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = $"DELETE FROM htl01 WHERE L01F01 = {id}";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
            _objResponse.Message = "Hotel Deleted Successfully";
            // Clear cache for all hotels
            CacheHelper.RemoveFromCache("GetAllHotels");
            return _objResponse;
        }
    }
}