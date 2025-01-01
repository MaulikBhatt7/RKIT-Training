using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace AuthDemo.Filters
{
    /// <summary>
    /// A custom filter that handles basic authentication for API requests.
    /// </summary>
    public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {
        /// <summary>
        /// Called to authorize the request by checking the Authorization header.
        /// </summary>
        /// <param name="actionContext">The context for the current HTTP action.</param>
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            // Check if the Authorization header is present
            var authHeader = actionContext.Request.Headers.Authorization;

            if (authHeader != null && authHeader.Scheme.Equals("Basic", StringComparison.OrdinalIgnoreCase))
            {
                // Decode the credentials from the base64 string
                var credentials = Encoding.UTF8.GetString(Convert.FromBase64String(authHeader.Parameter)).Split(':');
                var username = credentials[0];
                var password = credentials[1];

                // Validate the credentials
                if (IsAuthorizedUser(username, password))
                {
                    // Set the current principal for the authenticated user
                    Thread.CurrentPrincipal = new System.Security.Principal.GenericPrincipal(
                        new System.Security.Principal.GenericIdentity(username), null);
                    return;
                }
            }

            // Handle unauthorized access if credentials are invalid or missing
            HandleUnauthorized(actionContext);
        }

        /// <summary>
        /// Verifies if the provided username and password are valid.
        /// </summary>
        /// <param name="username">The username of the user attempting to authenticate.</param>
        /// <param name="password">The password of the user attempting to authenticate.</param>
        /// <returns>True if the user is authorized, otherwise false.</returns>
        private bool IsAuthorizedUser(string username, string password)
        {
            // Replace this logic with database or other credential verification logic
            return username == "admin" && password == "password";
        }

        /// <summary>
        /// Handles unauthorized access by setting the response to Unauthorized.
        /// </summary>
        /// <param name="actionContext">The context for the current HTTP action.</param>
        private void HandleUnauthorized(HttpActionContext actionContext)
        {
            // Set the response status code to Unauthorized and add the WWW-Authenticate header
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            actionContext.Response.Headers.Add("WWW-Authenticate", "Basic realm=\"AuthDemo\"");
        }
    }
}
