using System.Linq;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI_Separate_Demo.Controllers
{
    public class MainVersioningDemoController : ApiController
    {

        private string GetVersion()
        {
            // Check URI for version (path versioning)
            var versionFromUri = this.ControllerContext.RouteData.Values.ContainsKey("version")
                                ? this.ControllerContext.RouteData.Values["version"]?.ToString()
                                : null;

            if (!string.IsNullOrEmpty(versionFromUri))
            {
                return versionFromUri;
            }

            // Check Query string for version (query versioning)
            var versionFromQuery = Request.GetQueryNameValuePairs()
                .FirstOrDefault(q => q.Key == "version").Value;

            if (!string.IsNullOrEmpty(versionFromQuery))
            {
                return versionFromQuery;
            }

            // Check Headers for version (header versioning)
            var versionFromHeader = Request.Headers.Contains("X-API-Version")
                ? Request.Headers.GetValues("X-API-Version").FirstOrDefault()
                : null;

            if (!string.IsNullOrEmpty(versionFromHeader))
            {
                return versionFromHeader;
            }

            // Default to "1.0" if no versioning method is provided
            return "1.0";
        }

        [HttpGet]
        // Common action method that decides what to return based on the version
        [Route("api/versioning-demo")]
        [Route("api/v{version}/versioning-demo")]
        public IHttpActionResult GetProducts()
        {
            var version = GetVersion();

            switch (version)
            {
                case "1.0":
                    return Ok("V1 - List of Products");
                case "2.0":
                    return Ok("V2 - List of Products with Extended Info");
                default:
                    return BadRequest("Invalid version");
            }
        }
    }
}
