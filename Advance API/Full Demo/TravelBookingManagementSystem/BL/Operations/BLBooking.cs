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
using ServiceStack.OrmLite;
using ServiceStack.Data;
using TravelBookingManagementSystem.Handlers;

namespace TravelBookingManagementSystem.BL.Operations
{
    /// <summary>
    /// Business Logic class for handling bookings in the Travel Booking Management System.
    /// This class provides methods to manage bookings including adding, editing, retrieving, and deleting bookings.
    /// </summary>
    public class BLBooking
    {
        private BOK01 _objBOK01; // Booking object for processing.
        private int _id; // Booking ID for identification.
        private Response _objResponse; // Response object to encapsulate operation results.
        private readonly string _connectionString; // Database connection string.
        public EnmEntryType Type { get; set; } // Specifies the type of operation (Add, Edit, etc.).
        private readonly IDbConnectionFactory _dbFactory; // Factory to manage database connections.

        /// <summary>
        /// Constructor to initialize the connection string and response object.
        /// </summary>
        public BLBooking()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["TravelBookingConnection"].ConnectionString;
            _objResponse = new Response();
            _dbFactory = HttpContext.Current.Application["DbFactory"] as IDbConnectionFactory;
        }

        /// <summary>
        /// Method to get all bookings from the database.
        /// </summary>
        /// <returns>List of all bookings</returns>
        public List<BOK01> GetAllBookings()
        {
            string cacheKey = "GetAllBookings";

            // Check if the data exists in the cache
            List<BOK01> cachedBookings = CacheHelper.GetFromCache<List<BOK01>>(cacheKey);
            if (cachedBookings != null)
            {
                return cachedBookings; // Return cached data
            }
            using (IDbConnection dbConnection = _dbFactory.OpenDbConnection())
            {
                List<BOK01> lstBooking = dbConnection.Select<BOK01>(); // Fetch all booking records.

                CacheHelper.AddToCache(cacheKey, lstBooking, 30); // Add data to cache

                return lstBooking;
            }
        }

        /// <summary>
        /// Method to get a booking by ID.
        /// </summary>
        /// <param name="id">Booking ID</param>
        /// <returns>Booking object</returns>
        public BOK01 GetBookingByID(int id)
        {
            using (IDbConnection dbConnection = _dbFactory.OpenDbConnection())
            {
                return dbConnection.SingleById<BOK01>(id); // Fetch booking by id.
            }
        }

        /// <summary>
        /// Method to prepare a booking object for saving (Add or Edit).
        /// </summary>
        /// <param name="objDTOBOK01">DTO object for booking</param>
        /// <param name="userID">User ID</param>
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

        /// <summary>
        /// Method to validate before saving (Add or Edit).
        /// </summary>
        /// <param name="userID">User ID</param>
        /// <param name="role">User role</param>
        /// <returns>Response object indicating validation results</returns>
        public Response Validation(int userID, string role)
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

                if (objBOK01.K01F09 != userID && role != EnmRoles.Admin.ToString())
                {
                    _objResponse.IsError = true;
                    _objResponse.Message = "You are not authorized to update this record.";
                }
            }
            return _objResponse;
        }

        /// <summary>
        /// Method to save booking data (Add or Edit).
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
                    { "K01F02", _objBOK01.K01F02 },
                    { "K01F03", _objBOK01.K01F03 },
                    { "K01F04", _objBOK01.K01F04.ToString("yyyy-MM-dd HH:mm:ss") },
                    { "K01F05", _objBOK01.K01F05 },
                    { "K01F06", _objBOK01.K01F06 },
                    { "K01F09", _objBOK01.K01F09 }
                };

                if (Type == EnmEntryType.A)
                {
                    // Insert logic
                    parameters["K01F07"] = _objBOK01.K01F07.ToString("yyyy-MM-dd HH:mm:ss");
                    objDynamicQueryHandler.Insert("BOK01", parameters);
                    _objResponse.Message = "Booking Added Successfully";
                }
                else
                {
                    // Update logic
                    string whereClause = "K01F01 = @K01F01 ";
                    Dictionary<string, object> whereParameters = new Dictionary<string, object>
                    {
                        { "K01F01", _objBOK01.K01F01 }
                    };

                    parameters["K01F08"] = _objBOK01.K01F08.ToString("yyyy-MM-dd HH:mm:ss");

                    objDynamicQueryHandler.Update("BOK01", parameters, whereClause, whereParameters);
                    _objResponse.Message = "Booking Updated Successfully";
                }
            }
            catch (Exception ex)
            {
                _objResponse.IsError = true;
                _objResponse.Message = ex.Message;
            }
            // Clear cache for all bookings
            CacheHelper.RemoveFromCache("GetAllBookings");
            return _objResponse;
        }

        /// <summary>
        /// Method to delete a booking by ID.
        /// </summary>
        /// <param name="id">Booking ID</param>
        /// <returns>Response object indicating the result of the delete operation</returns>
        public Response Delete(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = $"DELETE FROM bok01 WHERE K01F01 = {id}";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
            _objResponse.Message = "Booking Deleted Successfully";
            // Clear cache for all bookings
            CacheHelper.RemoveFromCache("GetAllBookings");
            return _objResponse;
        }
    }
}
