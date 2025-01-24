using ExceptionHandlingDemo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ExceptionHandlingDemo.Controllers
{
    /// <summary>
    /// The TestController class defines API endpoints for testing exception handling.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IExceptionService _exceptionService;

        /// <summary>
        /// Initializes a new instance of the TestController class.
        /// </summary>
        /// <param name="exceptionService">The exception handling service.</param>
        public TestController(IExceptionService exceptionService)
        {
            _exceptionService = exceptionService;
        }

        /// <summary>
        /// Endpoint to simulate a general exception and handle it using the exception service.
        /// </summary>
        /// <returns>An IActionResult indicating the result of the operation.</returns>
        [HttpGet("general-error")]
        public async Task<IActionResult> GeneralError()
        {
            try
            {
                // Simulate an exception
                throw new Exception("This is a test exception from the user.");
            }
            catch (Exception ex)
            {
                // Use the exception service to handle the error
                await _exceptionService.HandleExceptionAsync(HttpContext, ex);
                return new EmptyResult(); // Optional, as the response is already written by the exception service
            }
        }

        /// <summary>
        /// Endpoint to simulate a developer-specific exception.
        /// </summary>
        /// <returns>An IActionResult indicating the result of the operation.</returns>
        [HttpGet("developer-error")]
        public IActionResult DeveloperError()
        {
            // Simulate an exception that is not caught within the method
            throw new Exception("This is a test exception for development!");
        }
    }
}