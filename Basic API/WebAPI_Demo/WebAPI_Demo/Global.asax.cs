using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace WebAPI_Demo
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            ConfigureJwtAuth();
        }

        private void ConfigureJwtAuth()
        {
            var config = GlobalConfiguration.Configuration;

            // Add a custom delegating handler to validate the JWT
            config.MessageHandlers.Add(new JwtAuthenticationHandler());
        }
    }


}
