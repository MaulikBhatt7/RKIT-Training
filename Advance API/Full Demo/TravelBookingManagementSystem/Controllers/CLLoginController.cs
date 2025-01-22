using System.Web.Http;
using TravelBookingManagementSystem.BL.Operations;
using TravelBookingManagementSystem.Handlers;
using TravelBookingManagementSystem.Models;
using TravelBookingManagementSystem.Models.DTO;

namespace TravelBookingManagementSystem.Controllers
{
    /// <summary>
    /// Controller to manage login-related API operations.
    /// </summary>
    [ValidateModelState]
    public class CLLoginController : ApiController
    {
        private readonly BLLogin _objBLlogin; // Business logic layer object for login operations
        private Response _objResponse; // Response object to hold operation results

        /// <summary>
        /// Initializes a new instance of the <see cref="CLLoginController"/> class.
        /// </summary>
        public CLLoginController()
        {
            // Initialize the business logic layer object and response object
            _objBLlogin = new BLLogin();
            _objResponse = new Response();
        }

        /// <summary>
        /// Authenticates a user using their login credentials.
        /// </summary>
        /// <param name="objDTOUSR02">The login details (username and password).</param>
        /// <returns>A <see cref="Response"/> object with the result of the login operation.</returns>
        [HttpPost]
        [Route("api/login")]
        public IHttpActionResult Login(DTOUSR02 objDTOUSR02)
        {
            // Check if the provided model is valid
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Return bad request if model state is invalid
            }

            // Authenticate the user using the business logic layer
             _objResponse = _objBLlogin.Authenticate(objDTOUSR02);

            // Return the response as an HTTP response
            return Ok(_objResponse);
        }
    }
}