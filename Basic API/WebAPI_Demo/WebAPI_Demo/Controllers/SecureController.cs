using AuthDemo.Filters;
using System.Web.Http;

namespace AuthDemo.Controllers
{
    /// <summary>
    /// A controller providing secure endpoints that require basic authentication.
    /// </summary>
    [BasicAuthentication]
    public class SecureController : ApiController
    {
        /// <summary>
        /// Retrieves secure data for an authenticated user.
        /// </summary>
        /// <returns>
        /// A secure message containing the username of the authenticated user.
        /// </returns>
        [HttpGet]
        [Route("api/secure/data")]
        public IHttpActionResult GetSecureData()
        {
            // Retrieve the username from the current thread's identity
            var username = System.Threading.Thread.CurrentPrincipal.Identity.Name;

            // Return a personalized secure message
            return Ok($"Hello, {username}. This is secure data.");
        }
    }
}
