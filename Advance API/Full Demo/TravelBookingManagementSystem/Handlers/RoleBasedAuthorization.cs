using System;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Http.Filters;
using TravelBookingManagementSystem.Handlers.Exceptions;

namespace TravelBookingManagementSystem.Handlers
{
    public class RoleBasedAuthorizationFilter : AuthorizationFilterAttribute
    {
        // Method that gets invoked before the action method is called
        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            var requiredRole = GetRequiredRole(actionContext);

            if (string.IsNullOrEmpty(requiredRole))
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
            if (userRole != requiredRole)
            {
                throw new ForbiddenAccessException($"You need {requiredRole} role to access this resource");
            }

            base.OnAuthorization(actionContext);
        }

        // Method to retrieve the required role from the action attribute
        private string GetRequiredRole(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            var roleAttribute = actionContext.ActionDescriptor.GetCustomAttributes<AuthorizeRoleAttribute>().FirstOrDefault();
            return roleAttribute?.Role;
        }
    }

    // Custom attribute to specify required roles for an action
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false)]
    public class AuthorizeRoleAttribute : Attribute
    {
        public string Role { get; }

        public AuthorizeRoleAttribute(string role)
        {
            Role = role;
        }
    }
}
