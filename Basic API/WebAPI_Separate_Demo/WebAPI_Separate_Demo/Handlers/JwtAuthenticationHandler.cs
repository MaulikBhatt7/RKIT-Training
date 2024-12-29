using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Microsoft.IdentityModel.Tokens;

public class JwtAuthenticationHandler : DelegatingHandler
{
    /// <summary>
    /// A flag to enable or disable JWT authentication in the handler.
    /// </summary>
    private static readonly bool EnableJwtAuthentication = false;

    /// <summary>
    /// Intercepts the HTTP request and validates the JWT token if present in the Authorization header.
    /// </summary>
    /// <param name="request">The HTTP request message that contains the JWT token.</param>
    /// <param name="cancellationToken">The cancellation token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation. The result is an HTTP response message.</returns>
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        if (EnableJwtAuthentication)
        {
            // Check if the request contains an Authorization header with Bearer scheme
            if (request.Headers.Authorization != null && request.Headers.Authorization.Scheme == "Bearer")
            {
                var token = request.Headers.Authorization.Parameter;
                var key = Encoding.UTF8.GetBytes("my-256-bit-secret-key-12345678901234567890123456789012");

                var tokenValidationParameters = new TokenValidationParameters
             
                
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "my-issuer",
                    ValidAudience = "my-audience",
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };

                try
                {
                    // Validate the token
                    var tokenHandler = new JwtSecurityTokenHandler();
                    SecurityToken validatedToken;
                    var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out validatedToken);

                    // Attach the ClaimsPrincipal to the current thread
                    Thread.CurrentPrincipal = principal;
                    if (HttpContext.Current != null)
                    {
                        HttpContext.Current.User = principal;
                    }
                }
                catch (Exception)
                {
                    // Token validation failed; return unauthorized response
                    return request.CreateResponse(HttpStatusCode.Unauthorized, "Invalid token.");
                }
            }
        }

        return await base.SendAsync(request, cancellationToken);
    }
}
