using System.Collections.Generic;
using System.Web.Http;
using TravelBookingManagementSystem.BL.Operations;
using TravelBookingManagementSystem.Models.DTO;
using TravelBookingManagementSystem.Models.Enum;
using TravelBookingManagementSystem.Models.POCO;
using TravelBookingManagementSystem.Models;
using TravelBookingManagementSystem.Handlers;
using System;
using System.IdentityModel.Tokens.Jwt;

namespace TravelBookingManagementSystem.Controllers
{
    /// <summary>
    /// Controller to manage booking-related API operations.
    /// </summary>
    [ValidateModelState]
    public class CLBookingController : ApiController
    {
        /// <summary>
        /// Response object to hold operation results.
        /// </summary>
        private Response _objResponse = new Response();

        /// <summary>
        /// Business logic layer object to handle booking operations.
        /// </summary>
        private BLBooking _objBLBooking = new BLBooking();
        private BLConverter _objBLConverter = new BLConverter();

        /// <summary>
        /// Retrieves a list of all bookings.
        /// </summary>
        /// <returns>Object of Response.</returns>
        [HttpGet]
        [AuthorizeRole(EnmRoles.Admin)]
        [Route("get-all-bookings")]
        public IHttpActionResult GetAllBookings()
        {
            // Fetch all booking records from the business logic layer
            List<BOK01> lstBookings = _objBLBooking.GetAllBookings();

            // Check if any bookings were retrieved
            if (lstBookings.Count > 0)
            {
                // Convert booking list to DataTable and add to response
                _objResponse.Data = _objBLConverter.ToDataTable(lstBookings);
                _objResponse.Message = "Data Get Successfully";
            }
            else
            {
                // Handle case where no data is found
                _objResponse.IsError = true;
                _objResponse.Message = "No Data Found";
            }
            return Ok(_objResponse); // Return the response object
        }

        /// <summary>
        /// Retrieves a booking by its ID.
        /// </summary>
        /// <param name="id">Booking ID.</param>
        /// <returns>Object of Response.</returns>
        [HttpGet]
        [AuthorizeRole(EnmRoles.Admin,EnmRoles.User)]
        [Route("get-booking-by-id")]
        public IHttpActionResult GetBookingByID(int id)
        {
            // Retrieve token from request
            string token = GetTokenFromRequest();
            // Get user ID and role from token
            var (userID, role) = JwtHandler.GetUserIdAndRoleFromToken(token);

            // Retrieve booking record by ID
            BOK01 objBooking = _objBLBooking.GetBookingByID(id);

            // Check if booking record exists
            if (objBooking == null)
            {
                _objResponse.IsError = true;
                _objResponse.Message = "No Data Found";
            }
            // Check if the user is authorized to access this record
            else if (objBooking.K01F09 != userID && role != EnmRoles.Admin.ToString())
            {
                _objResponse.IsError = true;
                _objResponse.Message = "You are not Authorized to access this record.";
            }
            else
            {
                // Convert the booking object to DataTable and add to response
                _objResponse.Data = _objBLConverter.ObjectToDataTable(objBooking);
                _objResponse.Message = "Data Get Successfully";
            }
            return Ok(_objResponse); // Return the response
        }

        /// <summary>
        /// Adds a new booking to the database (Admin only).
        /// </summary>
        /// <param name="objDTOBOK01">Booking data transfer object containing booking details.</param>
        /// <returns>Response object indicating success or failure of the operation.</returns>
        [HttpPost]
        [AuthorizeRole(EnmRoles.Admin, EnmRoles.User)] // Only Admins and Users can access this action
        [Route("add-booking")]
        public IHttpActionResult AddBooking(DTOBOK01 objDTOBOK01)
        {
            // Retrieve token from request
            string token = GetTokenFromRequest();
            // Get user ID and role from token
            var (userID, role) = JwtHandler.GetUserIdAndRoleFromToken(token);

            // Check validation
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Set the operation type to "Add"
            _objBLBooking.Type = EnmEntryType.A;

            // Prepare the booking object for saving
            _objBLBooking.PreSave(objDTOBOK01, userID);

            // Validate the booking data
            _objResponse = _objBLBooking.Validation(userID, role);

            // If validation passes, save the booking record
            if (!_objResponse.IsError)
            {
                _objResponse = _objBLBooking.Save(userID);
            }

            // Return the response
            return Ok(_objResponse);
        }

        /// <summary>
        /// Updates an existing booking's information (Admin only).
        /// </summary>
        /// <param name="objDTOBOK01">Booking data transfer object containing updated details.</param>
        /// <returns>Response object indicating success or failure of the operation.</returns>
        [HttpPut]
        [AuthorizeRole(EnmRoles.Admin, EnmRoles.User)] // Only Admins and Users can access this action
        [Route("update-booking")]
        public IHttpActionResult UpdateBooking(DTOBOK01 objDTOBOK01)
        {
            // Retrieve token from request
            string token = GetTokenFromRequest();
            // Get user ID and role from token
            var (userID, role) = JwtHandler.GetUserIdAndRoleFromToken(token);

            // Check validation
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Set the operation type to "Edit"
            _objBLBooking.Type = EnmEntryType.E;

            // Prepare the booking object for saving
            _objBLBooking.PreSave(objDTOBOK01, userID);

            // Validate the booking data
            _objResponse = _objBLBooking.Validation(userID, role);

            // If validation passes, save the updated booking record
            if (!_objResponse.IsError)
            {
                _objResponse = _objBLBooking.Save(userID);
            }

            // Return the response
            return Ok(_objResponse);
        }

        /// <summary>
        /// Deletes a booking by its ID (Admin only).
        /// </summary>
        /// <param name="id">Booking ID to be deleted.</param>
        /// <returns>Response object indicating success or failure.</returns>
        [HttpDelete]
        [AuthorizeRole(EnmRoles.Admin, EnmRoles.User)] // Only Admins and Users can access this action
        [Route("delete-booking")]
        public IHttpActionResult DeleteBooking(int id)
        {
            // Set the operation type to "Delete"
            _objBLBooking.Type = EnmEntryType.D;

            // Perform the delete operation and store the response
            _objResponse = _objBLBooking.Delete(id);

            // Return the response
            return Ok(_objResponse);
        }

        /// <summary>
        /// Retrieves the authorization token from the request headers.
        /// </summary>
        /// <returns>The authorization token as a string.</returns>
        private string GetTokenFromRequest()
        {
            var token = string.Empty;

            // Check if the Authorization header exists
            if (Request.Headers.Authorization != null)
            {
                // The token should be in the format 'Bearer <token>'
                var authorizationHeader = Request.Headers.Authorization.Parameter;
                if (!string.IsNullOrEmpty(authorizationHeader))
                {
                    token = authorizationHeader;
                }
            }

            if (string.IsNullOrEmpty(token))
            {
                throw new UnauthorizedAccessException("Authorization token is missing.");
            }

            return token;
        }
    }
}