using System.Web.Http;

namespace WebApiDemo.Controllers
{
    [RoutePrefix("api/authentication")]
    public class AuthorizationController : ApiController
    {
        /// <summary>
        /// Endpoint accessible only to users with the Admin role.
        /// </summary>
        /// <returns>A success message if the user is authorized as an Admin.</returns>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("admin-endpoint")]
        public IHttpActionResult Get()
        {
            return Ok("Welcome, Admin! You are authorized to access this endpoint.");
        }

        /// <summary>
        /// Endpoint accessible only to users with the User role.
        /// </summary>
        /// <returns>A success message if the user is authorized as a User.</returns>
        [HttpGet]
        [Authorize(Roles = "User")]
        [Route("user-endpoint")]
        public IHttpActionResult UserEndpoint()
        {
            return Ok("Welcome, User! You are authorized to access this endpoint.");
        }
    }
}
