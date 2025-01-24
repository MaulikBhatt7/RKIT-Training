using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace ExceptionHandlingDemo.Services
{
    /// <summary>
    /// Interface defining a contract for handling exceptions.
    /// </summary>
    public interface IExceptionService
    {
        /// <summary>
        /// Handles an exception asynchronously.
        /// </summary>
        /// <param name="context">The HTTP context.</param>
        /// <param name="exception">The exception to handle.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task HandleExceptionAsync(HttpContext context, Exception exception);
    }

    /// <summary>
    /// Implementation of the IExceptionService interface for handling exceptions.
    /// </summary>
    public class ExceptionService : IExceptionService
    {
        /// <summary>
        /// Handles an exception by setting the response status code and content type,
        /// and writing a JSON error response to the HTTP response.
        /// </summary>
        /// <param name="context">The HTTP context.</param>
        /// <param name="exception">The exception to handle.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            // Set the response status code to 500 (Internal Server Error)
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            // Set the response content type to application/json
            context.Response.ContentType = "application/json";

            // Create an error response object
            var errorResponse = new
            {
                Title = "Internal Server Error",
                Detail = exception.Message,
                StatusCode = context.Response.StatusCode
            };

            // Serialize the error response object to JSON
            var errorJson = System.Text.Json.JsonSerializer.Serialize(errorResponse);

            // Write the JSON error response to the HTTP response
            return context.Response.WriteAsync(errorJson);
        }
    }
}