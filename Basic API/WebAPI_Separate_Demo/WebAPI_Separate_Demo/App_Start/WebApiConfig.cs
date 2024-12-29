using System.Web.Http.Cors;
using System.Web.Http;
using Swashbuckle.Application;
using GlobalExceptionDemo;
using System.Runtime.InteropServices;
using System.Web.Http.ExceptionHandling;
using Microsoft.Web.Http.Versioning;
using Microsoft.Web.Http;


namespace WebAPI_Separate_Demo
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            //// Enable API versioning
            //config.AddApiVersioning(options =>
            //{
            //    options.ReportApiVersions = true; // Includes version info in response headers
            //    options.AssumeDefaultVersionWhenUnspecified = true; // Defaults to the specified version if none is provided
            //    options.DefaultApiVersion = new ApiVersion(1, 0); // Default API version
            //});

            config.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
                options.ApiVersionReader = new HeaderApiVersionReader("X-API-Version"); // Default to Header Versioning
                // You can switch to other readers as needed:
                // options.ApiVersionReader = new UrlSegmentApiVersionReader();
                // options.ApiVersionReader = new QueryStringApiVersionReader("v");
            });

            // Web API routes
            config.MapHttpAttributeRoutes();

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

            // Enable Swagger
            config.EnableSwagger(c =>
            {
                c.SingleApiVersion("v1", "Your API Title");
            })
            .EnableSwaggerUi();


            // Enable CORS globally
            var cors = new EnableCorsAttribute(
                origins: "*", // Specify allowed origin
                headers: "*",                    // Allow all headers
                methods: "*"                     // Allow all methods (GET, POST, etc.)
            );
            config.EnableCors(cors);

            

            // Add JwtAuthenticationHandler to the pipeline
            //config.MessageHandlers.Add(new JwtAuthenticationHandler());


            // Add the custom global exception handler
            config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler());

            //Add Custom Authorization Filter
            //config.Filters.Add(new RoleAuthorizationFilter("Admin", "Manager"));


        }
    }
}
