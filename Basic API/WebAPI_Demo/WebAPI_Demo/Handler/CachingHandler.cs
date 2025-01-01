using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using System;
using System.Runtime.Caching;

public class CachingHandler : DelegatingHandler
{
    private static readonly MemoryCache Cache = MemoryCache.Default;

    /// <summary>
    /// Intercepts the HTTP request and response to implement caching.
    /// </summary>
    /// <param name="request">The HTTP request message.</param>
    /// <param name="cancellationToken">The cancellation token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation, with the HTTP response message as the result.</returns>
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        // Generate a cache key based on the request URI
        string cacheKey = request.RequestUri.ToString();

        // Check if the response for the given cache key already exists in the cache
        if (Cache.Contains(cacheKey))
        {
            // Return the cached response if available
            return (HttpResponseMessage)Cache.Get(cacheKey);
        }

        // If not cached, send the request to the next handler
        var response = await base.SendAsync(request, cancellationToken);

        // Cache the response if the request was successful
        if (response.IsSuccessStatusCode)
        {
            Cache.Add(cacheKey, response, DateTimeOffset.UtcNow.AddMinutes(5)); // Cache for 5 minutes
        }

        // Return the response
        return response;
    }
}
