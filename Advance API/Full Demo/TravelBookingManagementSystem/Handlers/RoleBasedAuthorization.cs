using System;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Http.Filters;
using TravelBookingManagementSystem.Handlers.Exceptions;
using TravelBookingManagementSystem.Models.Enum;

namespace TravelBookingManagementSystem.Handlers
{
    /// <summary>
    /// Authorization filter for role-based access control.
    /// </summary>
    public class RoleBasedAuthorizationFilter : AuthorizationFilterAttribute
    {
        /// <summary>
        /// Method that gets invoked before the action method is called.
        /// </summary>
        /// <param name="actionContext">The action context.</param>
        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            // Retrieve the required roles for the action
            string[] requiredRoles = GetRequiredRole(actionContext);

            if (requiredRoles == null)
            {
                // If no role is specified in the action attribute, allow the request to proceed.
                base.OnAuthorization(actionContext);
                return;
            }

            // Extract the JWT token from the Authorization header
            var token = HttpContext.Current.Request.Headers["Authorization"]?.Split(' ').Last();
            if (string.IsNullOrEmpty(token))
            {
                throw new UnauthorizedAccessException("Token is required");
            }

            // Validate the token and get claims
            var claimsPrincipal = JwtHandler.ValidateToken(token);
            if (claimsPrincipal == null)
            {
                throw new UnauthorizedAccessException("Invalid or expired token");
            }

            // Extract the user's role from the claims
            var userRole = claimsPrincipal.FindFirst(ClaimTypes.Role)?.Value;

            // Check if the user's role matches the required role   
            if (!requiredRoles.Contains(userRole))
            {
                throw new ForbiddenAccessException("You are not authorized to access this resource");
            }

            // Allow the request to proceed
            base.OnAuthorization(actionContext);
        }

        /// <summary>
        /// Method to retrieve the required role from the action attribute.
        /// </summary>
        /// <param name="actionContext">The action context.</param>
        /// <returns>An array of required roles.</returns>
        private string[] GetRequiredRole(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            // Retrieve the AuthorizeRole attribute from the action descriptor
            var roleAttribute = actionContext.ActionDescriptor.GetCustomAttributes<AuthorizeRoleAttribute>().FirstOrDefault();
            return roleAttribute?.Roles;
        }
    }

    /// <summary>
    /// Custom attribute to specify required roles for an action.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false)]
    public class AuthorizeRoleAttribute : Attribute
    {
        /// <summary>
        /// Gets the required roles.
        /// </summary>
        public string[] Roles { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizeRoleAttribute"/> class.
        /// </summary>
        /// <param name="roles">The roles required for the action.</param>
        public AuthorizeRoleAttribute(params EnmRoles[] roles)
        {
            // Convert the roles to their string representations
            Roles = roles.Select(r => r.ToString()).ToArray();
        }
    }
}