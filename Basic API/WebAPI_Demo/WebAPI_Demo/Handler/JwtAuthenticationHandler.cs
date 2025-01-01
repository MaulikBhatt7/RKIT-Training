using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Microsoft.IdentityModel.Tokens;

public class JwtAuthenticationHandler : DelegatingHandler
{
    /// <summary>
    /// Intercepts the HTTP request to validate the JWT token in the Authorization header.
    /// </summary>
    /// <param name="request">The HTTP request message.</param>
    /// <param name="cancellationToken">The cancellation token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation, with the HTTP response message as the result.</returns>
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        // Check if the request contains an Authorization header with a Bearer token
        if (request.Headers.Authorization != null && request.Headers.Authorization.Scheme == "Bearer")
        {
            var token = request.Headers.Authorization.Parameter;
            var key = Encoding.UTF8.GetBytes("my-256-bit-secret-key-12345678901234567890123456789012");

            // Set up token validation parameters
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
                // Validate the token and extract the ClaimsPrincipal
                var tokenHandler = new JwtSecurityTokenHandler();
                SecurityToken validatedToken;
                var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out validatedToken);

                // Attach the ClaimsPrincipal to the current thread and HttpContext
                Thread.CurrentPrincipal = principal;
                if (HttpContext.Current != null)
                {
                    HttpContext.Current.User = principal;
                }
            }
            catch (Exception)
            {
                // Token validation failed; return an unauthorized response
                return request.CreateResponse(HttpStatusCode.Unauthorized, "Invalid token.");
            }
        }

        // Proceed with the next handler in the pipeline
        return await base.SendAsync(request, cancellationToken);
    }
}
