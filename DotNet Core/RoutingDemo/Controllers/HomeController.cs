using Microsoft.AspNetCore.Mvc;

namespace RoutingDemo.Controllers
{
    /// <summary>
    /// Controller to handle home-related actions.
    /// </summary>
    public class HomeController : ControllerBase
    {
        /// <summary>
        /// Endpoint to get a message from the Home Controller.
        /// </summary>
        /// <returns>Returns a message indicating the Home Controller is accessed.</returns>
        public IActionResult Index()
        {
            // Return a message indicating the Home Controller is accessed.
            return Ok("Home Controller");
        }
    }
}