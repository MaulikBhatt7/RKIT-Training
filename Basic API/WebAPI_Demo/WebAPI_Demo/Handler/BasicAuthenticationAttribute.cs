using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace AuthDemo.Filters
{
    public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {
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
                    Thread.CurrentPrincipal = new System.Security.Principal.GenericPrincipal(
                        new System.Security.Principal.GenericIdentity(username), null);
                    return;
                }
            }

            HandleUnauthorized(actionContext);
        }

        private bool IsAuthorizedUser(string username, string password)
        {
            // Replace this logic with database or other credential verification logic
            return username == "admin" && password == "password";
        }

        private void HandleUnauthorized(HttpActionContext actionContext)
        {
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            actionContext.Response.Headers.Add("WWW-Authenticate", "Basic realm=\"AuthDemo\"");
        }
    }
}
