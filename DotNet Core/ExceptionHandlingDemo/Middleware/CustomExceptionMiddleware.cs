using ExceptionHandlingDemo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace ExceptionHandlingDemo.Middleware
{
    /// <summary>
    /// Middleware for handling exceptions globally in the application.
    /// </summary>
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomExceptionMiddleware> _logger;
        private readonly IExceptionService _exceptionService;

        /// <summary>
        /// Initializes a new instance of the CustomExceptionMiddleware class.
        /// </summary>
        /// <param name="next">The next middleware in the pipeline.</param>
        /// <param name="logger">The logger instance to log errors.</param>
        /// <param name="exceptionService">The service to handle exceptions.</param>
        public CustomExceptionMiddleware(RequestDelegate next, ILogger<CustomExceptionMiddleware> logger, IExceptionService exceptionService)
        {
            _next = next;
            _logger = logger;
            _exceptionService = exceptionService;
        }

        /// <summary>
        /// Invokes the middleware to handle the incoming HTTP request.
        /// </summary>
        /// <param name="context">The HTTP context.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                // Call the next middleware in the pipeline
                await _next(context);
            }
            catch (Exception ex)
            {
                // Check if the response has not started yet
                if (!context.Response.HasStarted)
                {
                    // Log the exception
                    _logger.LogError(ex, "An unhandled exception occurred.");

                    // Handle the exception using the exception service
                    await _exceptionService.HandleExceptionAsync(context, ex);
                }
                else
                {
                    // Log a message indicating that the response has already started
                    _logger.LogError("The response has already started. Cannot handle the exception.");
                }
            }
        }
    }
}