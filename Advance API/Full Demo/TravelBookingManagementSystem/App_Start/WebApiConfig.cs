using ServiceStack.OrmLite;
using Swashbuckle.Application;
using System.Web.Http;
using System.Web.Http.Cors;
using TravelBookingManagementSystem.Handlers;

namespace TravelBookingManagementSystem
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configure Role Based Authorization Filter Globally.
            config.Filters.Add(new RoleBasedAuthorizationFilter());

            // Configure Validate Model State Globally.
            config.Filters.Add(new ValidateModelStateAttribute());

            // Web API routes
            config.MapHttpAttributeRoutes();

            // Enable CORS globally
            var cors = new EnableCorsAttribute("*", "*", "*"); // Allow all origins, headers, and methods
            config.EnableCors(cors);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Redirect root to Swagger
            config.Routes.MapHttpRoute(
                name: "SwaggerRedirect",
                routeTemplate: "",
                defaults: null,
                constraints: null,
                handler: new RedirectHandler(message => message.RequestUri.ToString(), "swagger")
            );
        }
    }
}
