using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace FiltersDemo.Filters
{
    /// <summary>
    /// Custom exception filter to handle exceptions and provide a custom response.
    /// </summary>
    public class CustomExceptionFilter : Attribute, IExceptionFilter
    {
        /// <summary>
        /// Code to execute when an exception occurs.
        /// </summary>
        /// <param name="context">The context of the exception filter.</param>
        public void OnException(ExceptionContext context)
        {
            // Log the exception message.
            Console.WriteLine($"Exception: {context.Exception.Message}");

            // Set the result to a JSON response with a custom error message and status code.
            context.Result = new JsonResult(new { error = "An error occurred" })
            {
                StatusCode = 500 // Internal Server Error
            };
        }
    }
}