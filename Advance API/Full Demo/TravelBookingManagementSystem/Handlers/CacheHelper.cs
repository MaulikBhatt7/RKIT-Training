using System;
using System.Web;

namespace TravelBookingManagementSystem.Handlers
{
    /// <summary>
    /// Cacher Helper class to handle caching.
    /// </summary>
    public static class CacheHelper
    {
        /// <summary>
        /// Adds or updates an item in the cache.
        /// </summary>
        /// <param name="key">The cache key.</param>
        /// <param name="value">The value to store in the cache.</param>
        /// <param name="durationInMinutes">The cache duration in minutes.</param>
        public static void AddToCache(string key, object value, int durationInMinutes)
        {
            if (value == null) return;

            HttpRuntime.Cache.Insert(
                key,
                value,
                null, // No file dependency
                DateTime.UtcNow.AddMinutes(durationInMinutes), // Absolute expiration
                System.Web.Caching.Cache.NoSlidingExpiration // No sliding expiration
            );
        }

        /// <summary>
        /// Retrieves an item from the cache.
        /// </summary>
        /// <typeparam name="T">The type of the cached object.</typeparam>
        /// <param name="key">The cache key.</param>
        /// <returns>The cached object, or null if the key is not found.</returns>
        public static T GetFromCache<T>(string key) where T : class
        {
            return HttpRuntime.Cache[key] as T;
        }

        /// <summary>
        /// Removes an item from the cache.
        /// </summary>
        /// <param name="key">The cache key.</param>
        public static void RemoveFromCache(string key)
        {
            if (HttpRuntime.Cache[key] != null)
            {
                HttpRuntime.Cache.Remove(key);
            }
        }
    }
}