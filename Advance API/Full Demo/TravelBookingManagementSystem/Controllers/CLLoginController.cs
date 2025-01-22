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
        private readonly BLLogin _objBLlogin;
        private readonly Response _objResponse;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginController"/> class.
        /// </summary>
        public CLLoginController()
        {
            _objBLlogin = new BLLogin();
            _objResponse = new Response();
        }

        /// <summary>
        /// Authenticates a user using their login credentials.
        /// </summary>
        /// <param name="loginDto">The login details (username and password).</param>
        /// <returns>A <see cref="Response"/> object with the result of the login operation.</returns>
        [HttpPost]
        [Route("api/login")]
        public IHttpActionResult Login(DTOUSR02 objDTOUSR02)
        {
            // Check if the provided model is valid
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Authenticate the user using the business logic layer
            Response response = _objBLlogin.Authenticate(objDTOUSR02);

            // Return the response as an HTTP response
            return Ok(response);
        }
    }
}
