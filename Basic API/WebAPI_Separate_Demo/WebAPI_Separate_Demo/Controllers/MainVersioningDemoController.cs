using System.Web.Http;
using System.Linq;
using System.Net.Http;
using System.Web.Routing;

namespace WebAPI_Separate_Demo.Controllers
{

    public class MainVersioningDemo : ApiController
    {
        // Central method to extract version dynamically (URL, query, or header)

        private string GetVersion()
        {
            // Check URI for version (path versioning)
            var versionFromUri = this.ControllerContext.RouteData.Values["version"]?.ToString();
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

        // Common action method that decides what to return based on the version
        [Route("api/versioning-demo")]
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
