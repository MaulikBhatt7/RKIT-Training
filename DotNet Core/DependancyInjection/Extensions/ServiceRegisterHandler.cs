using DependancyInjection.Models;
using DependancyInjection.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DependancyInjection.Extensions
{
    /// <summary>
    /// The ServiceRegisterHandler class provides extension methods for registering services.
    /// </summary>
    public static class ServiceRegisterHandler
    {
        /// <summary>
        /// Adds custom services to the IServiceCollection.
        /// </summary>
        /// <param name="services">The IServiceCollection to add services to.</param>
        /// <returns>The IServiceCollection with added services.</returns>
        public static IServiceCollection AddMyServices(this IServiceCollection services)
        {
           
            // builder.Services.AddSingleton<IHome, Home>();
            // builder.Services.AddScoped<ICricket, Cricket>();

            // Registering Home service with a transient lifetime
            services.AddTransient<IHome, Home>();

            // Registering Cricket service with a transient lifetime
            services.AddTransient<ICricket, Cricket>();

            // Registering School service with a transient lifetime
            services.AddTransient<IEducation, School>();

            // Registering Person service with a transient lifetime
            services.AddTransient<IPerson, Person>();

            return services;
        }
    }
}