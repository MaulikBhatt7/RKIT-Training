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
    /// Custom attribute for basic authentication filter, which checks the Authorization header for valid credentials.
    /// </summary>
    public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {
        /// <summary>
        /// Executes authorization logic for the incoming HTTP request.
        /// </summary>
        /// <param name="actionContext">
        /// The context of the HTTP request to be authorized.
        /// </param>
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            // Check if the Authorization header is present
            var authHeader = actionContext.Request.Headers.Authorization;

            if (authHeader != null && authHeader.Scheme.Equals("Basic", StringComparison.OrdinalIgnoreCase))
            {
                var credentials = Encoding.UTF8.GetString(Convert.FromBase64String(authHeader.Parameter)).Split(':');
                var username = credentials[0];
                var password = credentials[1];

                if (IsAuthorizedUser(username, password))
                {
                    // Set the current principal if credentials are valid
                    Thread.CurrentPrincipal = new System.Security.Principal.GenericPrincipal(
                        new System.Security.Principal.GenericIdentity(username), null);
                    return;
                }
            }

            HandleUnauthorized(actionContext);
        }

        /// <summary>
        /// Verifies if the provided username and password are valid.
        /// </summary>
        /// <param name="username">The username to verify.</param>
        /// <param name="password">The password to verify.</param>
        /// <returns>
        /// Returns true if the user is authorized, otherwise false.
        /// </returns>
        private bool IsAuthorizedUser(string username, string password)
        {
            // Replace this logic with database or other credential verification logic
            return username == "admin" && password == "password";
        }

        /// <summary>
        /// Handles the unauthorized request by setting a 401 response and a WWW-Authenticate header.
        /// </summary>
        /// <param name="actionContext">
        /// The context of the HTTP request to be responded to with unauthorized status.
        /// </param>
        private void HandleUnauthorized(HttpActionContext actionContext)
        {
            // Set unauthorized response with a message and WWW-Authenticate header
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, "You are not authenticated.");
            actionContext.Response.Headers.Add("WWW-Authenticate", "Basic realm=\"AuthDemo\"");
            actionContext.Response.Headers.Add("StatusCode", "403");
        }
    }
}
