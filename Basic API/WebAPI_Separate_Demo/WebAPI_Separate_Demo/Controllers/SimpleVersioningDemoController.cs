using Microsoft.Web.Http;
using System.Web.Http;

namespace WebAPI_Separate_Demo.Controllers
{
    /// <summary>
    /// Controller to demonstrate API versioning using attribute-based routing.
    /// </summary>
    [RoutePrefix("api/versioning")]
    public class SimpleVersioningDemoController : ApiController
    {
        /// <summary>
        /// Retrieves data for version 1.0 of the API.
        /// </summary>
        /// <returns>
        /// An HTTP response containing the message for version 1.0.
        /// </returns>
        [HttpGet]
        //[ApiVersion("1.0")]
        [Route("v1/demo")]
        //[Route("api/v{version:apiVersion}/demo")]
        public IHttpActionResult GetVersion1()
        {
            return Ok(new { message = "This is version 1.0" });
        }

        /// <summary>
        /// Retrieves data for version 2.0 of the API.
        /// </summary>
        /// <returns>
        /// An HTTP response containing the message for version 2.0.
        /// </returns>
        [HttpGet]
        //[ApiVersion("2.0")]
        //[Route("api/v{version:apiVersion}/demo")]
        [Route("v2/demo")]
        public IHttpActionResult GetVersion2()
        {
            return Ok(new { message = "This is version 2.0" });
        }
    }
}
