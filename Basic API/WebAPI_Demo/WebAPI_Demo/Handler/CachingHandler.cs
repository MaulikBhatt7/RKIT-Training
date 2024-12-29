using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using System;
using System.Runtime.Caching;


public class CachingHandler : DelegatingHandler
{
    private static readonly MemoryCache Cache = MemoryCache.Default;

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        string cacheKey = request.RequestUri.ToString();
        if (Cache.Contains(cacheKey))
        {

            return (HttpResponseMessage)Cache.Get(cacheKey);
        }
        
        var response = await base.SendAsync(request, cancellationToken);

        if (response.IsSuccessStatusCode)
        {
            Cache.Add(cacheKey, response, DateTimeOffset.UtcNow.AddMinutes(5));
        }

        return response;
    }
}
