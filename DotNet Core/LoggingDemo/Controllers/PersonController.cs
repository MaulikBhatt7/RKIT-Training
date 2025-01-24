using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace LoggingDemo.Controllers
{
    /// <summary>
    /// The PersonController class defines API endpoints for person-related actions.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;

        /// <summary>
        /// Initializes a new instance of the PersonController class.
        /// </summary>
        /// <param name="logger">The logger instance to log messages.</param>
        public PersonController(ILogger<PersonController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// GET api/person endpoint.
        /// </summary>
        /// <returns>An IActionResult indicating the result of the operation.</returns>
        [HttpGet]
        public IActionResult Get()
        {
            // Log an informational message when the endpoint is accessed
            _logger.LogInformation("PersonController Get endpoint accessed");

            try
            {
                // Simulate a warning
                _logger.LogWarning("This is a sample warning message");

                // Simulate an exception
                throw new Exception("Sample exception");
            }
            catch (Exception ex)
            {
                // Log the exception as an error
                _logger.LogError(ex, "An error occurred in PersonController.Get");

                // Return a 500 Internal Server Error response
                return StatusCode(500, "An internal error occurred");
            }
        }
    }
}