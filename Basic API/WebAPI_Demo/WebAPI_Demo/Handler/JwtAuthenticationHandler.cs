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
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        // Check if the request contains an Authorization header
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
                // Token validation failed; unauthorized response
                return request.CreateResponse(HttpStatusCode.Unauthorized, "Invalid token.");
            }
        }

        // Proceed with the next handler
        return await base.SendAsync(request, cancellationToken);
    }
}
