using System.Collections.Generic;
using System.Web.Http;
using TravelBookingManagementSystem.BL.Operations;
using TravelBookingManagementSystem.Models.DTO;
using TravelBookingManagementSystem.Models.Enum;
using TravelBookingManagementSystem.Models.POCO;
using TravelBookingManagementSystem.Models;
using TravelBookingManagementSystem.BL.Operations;
using TravelBookingManagementSystem.Handlers;

namespace TravelBookingManagementSystem.Controllers
{
    /// <summary>
    /// Controller to manage user-related API operations.
    /// </summary>
    [ValidateModelState]
    public class CLUserController : ApiController
    {
        /// <summary>
        /// Response object to hold operation results.
        /// </summary>
        private Response _objResponse = new Response();

        /// <summary>
        /// Business logic layer object to handle user operations.
        /// </summary>
        private BLUser _objBLUser = new BLUser();
        private BLConverter _objBLConverter = new BLConverter();

        /// <summary>
        /// Retrieves a list of all users.
        /// </summary>
        /// <returns>Object of Response.</returns>
        [Route("get-all-users")]
        public IHttpActionResult GetAllUsers()
        {
            // Fetch all user records from the business logic layer
            List<USR01> lstUsers = _objBLUser.GetAllUsers();

            // Check if any users were retrieved
            if (lstUsers.Count > 0)
            {
                // Convert user list to DataTable and add to response
                _objResponse.Data = _objBLConverter.ToDataTable(lstUsers);
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
        /// Retrieves a user by their ID.
        /// </summary>
        /// <param name="id">User ID.</param>
        /// <returns>Object of Response.</returns>
        [Route("get-user-by-id")]
        public IHttpActionResult GetUserByID(int id)
        {
            // Retrieve user record by ID
            USR01 objUser = _objBLUser.GetUserByID(id);

            // Check if user record exists
            if (objUser == null)
            {
                _objResponse.IsError = true;
                _objResponse.Message = "No Data Found";
            }
            else
            {
                // Convert the user object to DataTable and add to response
                _objResponse.Data = _objBLConverter.ObjectToDataTable(objUser);
                _objResponse.Message = "Data Get Successfully";
            }
            return Ok(_objResponse); // Return the response
        }

        /// <summary>
        /// Deletes a user by their ID.
        /// </summary>
        /// <param name="id">User ID to be deleted.</param>
        /// <returns>Response object indicating success or failure.</returns>
        [HttpDelete]
        [Route("delete-user")]
        public IHttpActionResult Delete(int id)
        {
            // Set the operation type to "Delete"
            _objBLUser.Type = EnmEntryType.D;

            // Perform the delete operation and store the response
            _objResponse = _objBLUser.Delete(id);

            // Return the response
            return Ok(_objResponse);
        }

        /// <summary>
        /// Adds a new user to the database.
        /// </summary>
        /// <param name="objDTOUser01">User data transfer object containing user details.</param>
        /// <returns>Response object indicating success or failure of the operation.</returns>
        [HttpPost]
        [Route("add-user")]
        public IHttpActionResult AddUser(DTOUSR01 objDTOUser01)
        {
            // Check validation
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // Set the operation type to "Add"
            _objBLUser.Type = EnmEntryType.A;

            // Prepare the user object for saving
            _objBLUser.PreSave(objDTOUser01);

            // Validate the user data
            _objResponse = _objBLUser.Validation();

            // If validation passes, save the user record
            if (!_objResponse.IsError)
            {
                _objResponse = _objBLUser.Save();
            }

            // Return the response
            return Ok(_objResponse);
        }

        /// <summary>
        /// Updates an existing user's information.
        /// </summary>
        /// <param name="objDTOUser01">User data transfer object containing updated details.</param>
        /// <returns>Response object indicating success or failure of the operation.</returns>
        [HttpPut]
        [Route("update-user")]
        public IHttpActionResult UpdateUser(DTOUSR01 objDTOUser01)
        {
            // Check validation
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // Set the operation type to "Edit"
            _objBLUser.Type = EnmEntryType.E;

            // Prepare the user object for saving
            _objBLUser.PreSave(objDTOUser01);

            // Validate the user data
            _objResponse = _objBLUser.Validation();

            // If validation passes, save the updated user record
            if (!_objResponse.IsError)
            {
                _objResponse = _objBLUser.Save();
            }

            // Return the response
            return Ok(_objResponse);
        }
    }
}
