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
    /// Controller to manage hotel-related API operations.
    /// </summary>
    public class CLHotelController : ApiController
    {
        /// <summary>
        /// Response object to hold operation results.
        /// </summary>
        private Response _objResponse = new Response();

        /// <summary>
        /// Business logic layer object to handle hotel operations.
        /// </summary>
        private BLHotel _objBLHotel = new BLHotel();
        private BLConverter _objBLConverter = new BLConverter();

        /// <summary>
        /// Retrieves a list of all hotels.
        /// </summary>
        /// <returns>Object of Response.</returns>
        [HttpGet]
        [AuthorizeRole(EnmRoles.Admin, EnmRoles.User)]
        [Route("get-all-hotels")]
        public IHttpActionResult GetAllHotels()
        {
            // Fetch all hotel records from the business logic layer
            List<HTL01> lstHotels = _objBLHotel.GetAllHotels();

            // Check if any hotels were retrieved
            if (lstHotels.Count > 0)
            {
                // Convert hotel list to DataTable and add to response
                _objResponse.Data = _objBLConverter.ToDataTable(lstHotels);
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
        /// Retrieves a hotel by its ID.
        /// </summary>
        /// <param name="id">Hotel ID.</param>
        /// <returns>Object of Response.</returns>
        [HttpGet]
        [Route("get-hotel-by-id")]
        public IHttpActionResult GetHotelByID(int id)
        {
            // Retrieve hotel record by ID
            HTL01 objHotel = _objBLHotel.GetHotelByID(id);

            // Check if hotel record exists
            if (objHotel == null)
            {
                _objResponse.IsError = true;
                _objResponse.Message = "No Data Found";
            }
            else
            {
                // Convert the hotel object to DataTable and add to response
                _objResponse.Data = _objBLConverter.ObjectToDataTable(objHotel);
                _objResponse.Message = "Data Get Successfully";
            }
            return Ok(_objResponse); // Return the response
        }

        /// <summary>
        /// Adds a new hotel to the database (Admin only).
        /// </summary>
        /// <param name="objDTOHotel01">Hotel data transfer object containing hotel details.</param>
        /// <returns>Response object indicating success or failure of the operation.</returns>
        [HttpPost]
        [AuthorizeRole(EnmRoles.Admin)] // Only Admins can access this action
        [Route("add-hotel")]
        public IHttpActionResult AddHotel(DTOHTL01 objDTOHotel01)
        {
            // Check validation
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Set the operation type to "Add"
            _objBLHotel.Type = EnmEntryType.A;

            // Prepare the hotel object for saving
            _objBLHotel.PreSave(objDTOHotel01);

            // Validate the hotel data
            _objResponse = _objBLHotel.Validation();

            // If validation passes, save the hotel record
            if (!_objResponse.IsError)
            {
                _objResponse = _objBLHotel.Save();
            }

            // Return the response
            return Ok(_objResponse);
        }

        /// <summary>
        /// Updates an existing hotel's information (Admin only).
        /// </summary>
        /// <param name="objDTOHotel01">Hotel data transfer object containing updated details.</param>
        /// <returns>Response object indicating success or failure of the operation.</returns>
        [HttpPut]
        [AuthorizeRole(EnmRoles.Admin)] // Only Admins can access this action
        [Route("update-hotel")]
        public IHttpActionResult UpdateHotel(DTOHTL01 objDTOHotel01)
        {
            // Check validation
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Set the operation type to "Edit"
            _objBLHotel.Type = EnmEntryType.E;

            // Prepare the hotel object for saving
            _objBLHotel.PreSave(objDTOHotel01);

            // Validate the hotel data
            _objResponse = _objBLHotel.Validation();

            // If validation passes, save the updated hotel record
            if (!_objResponse.IsError)
            {
                _objResponse = _objBLHotel.Save();
            }

            // Return the response
            return Ok(_objResponse);
        }

        /// <summary>
        /// Deletes a hotel by its ID (Admin only).
        /// </summary>
        /// <param name="id">Hotel ID to be deleted.</param>
        /// <returns>Response object indicating success or failure.</returns>
        [HttpDelete]
        [AuthorizeRole(EnmRoles.Admin)] // Only Admins can access this action
        [Route("delete-hotel")]
        public IHttpActionResult DeleteHotel(int id)
        {
            // Set the operation type to "Delete"
            _objBLHotel.Type = EnmEntryType.D;

            // Perform the delete operation and store the response
            _objResponse = _objBLHotel.Delete(id);

            // Return the response
            return Ok(_objResponse);
        }
    }
}
