using System;
using System.Web.Caching;
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
        /// Retrieves static data, caching it for 5 minutes to improve performance using Cache methods.
        /// </summary>
        /// <returns>An HTTP response containing cached or newly cached data.</returns>
        [HttpGet]
        [Route("api/caching")]
        public IHttpActionResult GetData()
        {
            var cacheKey = "staticDataKey";
            string staticData = "This is some static data."; // Replace with your static content

            // Example: Retrieve data from cache using Get
            var cachedData = Cache.Get(cacheKey);
            if (cachedData != null)
            {
                return Ok($"Retrieved from Cache (using Get): {cachedData}");
            }

            // Example: Add data to cache using Add (only if it doesn't exist)
            Cache.Add(
                cacheKey,
                staticData,
                null,
                DateTime.UtcNow.AddMinutes(5),
                Cache.NoSlidingExpiration,
                CacheItemPriority.Default,
                null
            );

            // Example: Retrieve data again to verify Add worked
            cachedData = Cache.Get(cacheKey);
            if (cachedData != null)
            {
                return Ok($"Added to Cache (using Add): {cachedData}");
            }

            return Ok("Failed to add data to cache.");
        }

        /// <summary>
        /// Removes an item from the cache by key.
        /// </summary>
        /// <returns>An HTTP response indicating the result of the removal.</returns>
        [HttpDelete]
        [Route("api/caching/remove")]
        public IHttpActionResult RemoveData()
        {
            var cacheKey = "staticDataKey";

            // Remove the item from the cache
            var removedData = Cache.Remove(cacheKey);

            if (removedData != null)
            {
                return Ok($"Removed from Cache: {removedData}");
            }

            return Ok("Item was not found in Cache.");
        }

        /// <summary>
        /// Updates or adds static data in the cache using Insert.
        /// </summary>
        /// <returns>An HTTP response containing the updated or newly cached data.</returns>
        [HttpPost]
        [Route("api/caching/insert")]
        public IHttpActionResult InsertData()
        {
            var cacheKey = "staticDataKey";
            string updatedData = "This is updated static data."; // Replace with your updated static content

            // Insert updates or adds the data in the cache
            Cache.Insert(
                cacheKey,
                updatedData,
                null,
                DateTime.UtcNow.AddMinutes(5),
                Cache.NoSlidingExpiration
            );

            return Ok($"Data updated or inserted in Cache: {updatedData}");
        }
    }
}
