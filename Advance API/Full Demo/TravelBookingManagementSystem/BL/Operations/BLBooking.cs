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
using System.Data.Odbc;
using ServiceStack.OrmLite;
using ServiceStack.Data;
using TravelBookingManagementSystem.Handlers;

namespace TravelBookingManagementSystem.BL.Operations
{
    public class BLBooking
    {
        private BOK01 _objBOK01; // Booking object for processing.
        private int _id; // Booking ID for identification.
        private Response _objResponse; // Response object to encapsulate operation results.
        private readonly string _connectionString; // Database connection string.
        public EnmEntryType Type { get; set; } // Specifies the type of operation (Add, Edit, etc.).
        private readonly IDbConnectionFactory _dbFactory; // Factory to manage database connections.

        // Constructor to initialize the connection string and response object.
        public BLBooking()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["TravelBookingConnection"].ConnectionString;
            _objResponse = new Response();
            _dbFactory = HttpContext.Current.Application["DbFactory"] as IDbConnectionFactory;

        }

        // Method to get all bookings from the database.
        public List<BOK01> GetAllBookings()
        {
            using (IDbConnection db = _dbFactory.OpenDbConnection())
            {
                return db.Select<BOK01>(); // Fetch all booking records.
            }
        }

        // Method to get a booking by ID.
        public BOK01 GetBookingByID(int id)
        {
            using (IDbConnection db = _dbFactory.OpenDbConnection())
            {
                return db.SingleById<BOK01>(id); // Fetch flight by id.
            }
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

        // Method to save booking data (Add or Edit).
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
                    string whereClause = "K01F01 = @K01F01";
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
