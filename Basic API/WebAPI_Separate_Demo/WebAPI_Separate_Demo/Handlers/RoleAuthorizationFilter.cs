using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

public class RoleAuthorizationFilter : AuthorizationFilterAttribute
{
    /// <summary>
    /// An array of roles that are allowed to access the resource.
    /// </summary>
    private readonly string[] _allowedRoles;

    /// <summary>
    /// Initializes a new instance of the <see cref="RoleAuthorizationFilter"/> class with the allowed roles.
    /// </summary>
    /// <param name="roles">A list of roles allowed to access the resource.</param>
    public RoleAuthorizationFilter(params string[] roles)
    {
        _allowedRoles = roles;
    }

    /// <summary>
    /// Verifies if the user is authenticated and authorized to access the resource.
    /// </summary>
    /// <param name="actionContext">The context of the current HTTP request, including the action being invoked.</param>
    public override void OnAuthorization(HttpActionContext actionContext)
    {
        // Check if the current principal (user) is authenticated
        var principal = Thread.CurrentPrincipal;
        if (principal == null || !Thread.CurrentPrincipal.Identity.IsAuthenticated)
        {
            HandleUnauthorized(actionContext, "User is not authenticated");
            return;
        }

        // Check if the user has the required roles
        if (_allowedRoles.Length > 0 && !_allowedRoles.Any(role => Thread.CurrentPrincipal.IsInRole(role)))
        {
            HandleUnauthorized(actionContext, "User is not authorized");
            return;
        }
    }

    /// <summary>
    /// Creates a response indicating the user is not authorized to access the resource.
    /// </summary>
    /// <param name="actionContext">The context of the current HTTP request.</param>
    /// <param name="message">The message to be sent with the unauthorized response.</param>
    private void HandleUnauthorized(HttpActionContext actionContext, string message)
    {
        actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Forbidden, new { Message = message });
    }
}
