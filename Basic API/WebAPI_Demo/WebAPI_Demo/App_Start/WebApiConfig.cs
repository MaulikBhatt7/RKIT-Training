using GlobalExceptionDemo;
using Swashbuckle.Application;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.ExceptionHandling;

namespace WebAPI_Demo
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

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
                origins: "http://localhost:3000", // Specify allowed origin
                headers: "*",                    // Allow all headers
                methods: "*"                     // Allow all methods (GET, POST, etc.)
            );
            config.EnableCors(cors);


            // Add the custom global exception handler
            config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler());

            // Add Caching handler 
            config.MessageHandlers.Add(new CachingHandler());


        }
    }
}
