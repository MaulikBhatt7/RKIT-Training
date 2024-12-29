using System.Threading.Tasks;
using System.Threading;
using System.Web.Caching;
using System;
using System.Web.Http;

namespace MyApplication.Controllers
{
    /// <summary>
    /// Controller to demonstrate caching static data using the System.Web.Caching.Cache class.
    /// </summary>
    public class CachingDemoController : ApiController
    {
        private static readonly Cache Cache = new Cache();

        /// <summary>
        /// Retrieves static data, caching it for 5 minutes to improve performance.
        /// </summary>
        /// <returns>
        /// An HTTP response containing the cached static data or newly cached data.
        /// </returns>
        [HttpGet]
        [Route("api/caching")]
        public IHttpActionResult GetData()
        {
            var cacheKey = "staticDataKey";
            string staticData = "This is some static data."; // Replace with your static content

            // Check if the data is cached
            if (Cache[cacheKey] != null)
            {
                return Ok(Cache[cacheKey]);
            }

            // Cache the static data with a 5-minute expiration
            Cache.Insert(
                cacheKey,
                staticData,
                null,
                DateTime.UtcNow.AddMinutes(5),
                Cache.NoSlidingExpiration
            );

            return Ok(staticData);
        }
    }
}
