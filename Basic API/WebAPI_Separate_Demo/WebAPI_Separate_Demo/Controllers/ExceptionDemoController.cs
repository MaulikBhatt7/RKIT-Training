using System.Web.Http;

namespace WebAPI_Separate_Demo.Controllers
{
    /// <summary>
    /// Controller to demonstrate exception handling using a custom exception filter.
    /// </summary>
    public class ExceptionDemoController : ApiController
    {
        /// <summary>
        /// Demonstrates throwing an exception, which is handled by a custom exception filter.
        /// </summary>
        /// <returns>
        /// This method intentionally throws an exception for demonstration purposes.
        /// </returns>
        /// <exception cref="System.Exception">
        /// Thrown to demonstrate exception handling in Web API.
        /// </exception>
        [HttpGet]
        [CustomExceptionFilter]
        [Route("api/exception")]
        public IHttpActionResult GetException()
        {
            throw new System.Exception("This is a Demo exception.");
        }
    }
}
