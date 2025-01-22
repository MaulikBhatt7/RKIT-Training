using System.Collections.Generic;
using System.Web.Http;
using TravelBookingManagementSystem.BL.Operations;
using TravelBookingManagementSystem.Models.DTO;
using TravelBookingManagementSystem.Models.Enum;
using TravelBookingManagementSystem.Models.POCO;
using TravelBookingManagementSystem.Models;
using TravelBookingManagementSystem.Handlers;

namespace TravelBookingManagementSystem.Controllers
{
    /// <summary>
    /// Controller to manage flight-related API operations.
    /// </summary>
    [ValidateModelState]
    public class CLFlightController : ApiController
    {
        /// <summary>
        /// Response object to hold operation results.
        /// </summary>
        private Response _objResponse = new Response();

        /// <summary>
        /// Business logic layer object to handle flight operations.
        /// </summary>
        private BLFlight _objBLFlight = new BLFlight();
        private BLConverter _objBLConverter = new BLConverter();

        /// <summary>
        /// Retrieves a list of all flights.
        /// </summary>
        /// <returns>Object of Response.</returns>
        [HttpGet]
        [AuthorizeRole(EnmRoles.Admin, EnmRoles.User)]
        [Route("get-all-flights")]
        public IHttpActionResult GetAllFlights()
        {
            // Fetch all flight records from the business logic layer
            List<FLT01> lstFlights = _objBLFlight.GetAllFlights();

            // Check if any flights were retrieved
            if (lstFlights.Count > 0)
            {
                // Convert flight list to DataTable and add to response
                _objResponse.Data = _objBLConverter.ToDataTable(lstFlights);
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
        /// Retrieves a flight by its ID.
        /// </summary>
        /// <param name="id">Flight ID.</param>
        /// <returns>Object of Response.</returns>
        [HttpGet]
        [AuthorizeRole(EnmRoles.Admin, EnmRoles.User)]
        [Route("get-flight-by-id")]
        public IHttpActionResult GetFlightByID(int id)
        {
            // Retrieve flight record by ID
            FLT01 objFlight = _objBLFlight.GetFlightByID(id);

            // Check if flight record exists
            if (objFlight == null)
            {
                _objResponse.IsError = true;
                _objResponse.Message = "No Data Found";
            }
            else
            {
                // Convert the flight object to DataTable and add to response
                _objResponse.Data = _objBLConverter.ObjectToDataTable(objFlight);
                _objResponse.Message = "Data Get Successfully";
            }
            return Ok(_objResponse); // Return the response
        }

        /// <summary>
        /// Adds a new flight to the database (Admin only).
        /// </summary>
        /// <param name="objDTOFlight01">Flight data transfer object containing flight details.</param>
        /// <returns>Response object indicating success or failure of the operation.</returns>
        [HttpPost]
        [AuthorizeRole(EnmRoles.Admin)] // Only Admins can access this action
        [Route("add-flight")]
        public IHttpActionResult AddFlight(DTOFLT01 objDTOFlight01)
        {
            // Check validation
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Set the operation type to "Add"
            _objBLFlight.Type = EnmEntryType.A;

            // Prepare the flight object for saving
            _objBLFlight.PreSave(objDTOFlight01);

            // Validate the flight data
            _objResponse = _objBLFlight.Validation();

            // If validation passes, save the flight record
            if (!_objResponse.IsError)
            {
                _objResponse = _objBLFlight.Save();
            }

            // Return the response
            return Ok(_objResponse);
        }

        /// <summary>
        /// Updates an existing flight's information (Admin only).
        /// </summary>
        /// <param name="objDTOFlight01">Flight data transfer object containing updated details.</param>
        /// <returns>Response object indicating success or failure of the operation.</returns>
        [HttpPut]
        [AuthorizeRole(EnmRoles.Admin)] // Only Admins can access this action
        [Route("update-flight")]
        public IHttpActionResult UpdateFlight(DTOFLT01 objDTOFlight01)
        {
            // Check validation
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Set the operation type to "Edit"
            _objBLFlight.Type = EnmEntryType.E;

            // Prepare the flight object for saving
            _objBLFlight.PreSave(objDTOFlight01);

            // Validate the flight data
            _objResponse = _objBLFlight.Validation();

            // If validation passes, save the updated flight record
            if (!_objResponse.IsError)
            {
                _objResponse = _objBLFlight.Save();
            }

            // Return the response
            return Ok(_objResponse);
        }

        /// <summary>
        /// Deletes a flight by its ID (Admin only).
        /// </summary>
        /// <param name="id">Flight ID to be deleted.</param>
        /// <returns>Response object indicating success or failure.</returns>
        [HttpDelete]
        [AuthorizeRole(EnmRoles.Admin)] // Only Admins can access this action
        [Route("delete-flight")]
        public IHttpActionResult DeleteFlight(int id)
        {
            // Set the operation type to "Delete"
            _objBLFlight.Type = EnmEntryType.D;

            // Perform the delete operation and store the response
            _objResponse = _objBLFlight.Delete(id);

            // Return the response
            return Ok(_objResponse);
        }
    }
}
