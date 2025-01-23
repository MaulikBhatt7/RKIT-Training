using FiltersDemo.Filters;
using Microsoft.AspNetCore.Mvc;

namespace FiltersDemo.Controllers
{
    /// <summary>
    /// Controller to demonstrate the use of various filters.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [CustomAuthorizationFilter] // Applied at the controller level for authorization
    public class FilterDemoController : ControllerBase
    {
        /// <summary>
        /// Endpoint that applies Resource, Action, and Result filters.
        /// </summary>
        /// <returns>A message indicating the filters applied.</returns>
        [CustomResourceFilter]
        [CustomActionFilter]
        [CustomResultFilter]
        [HttpGet("all-filters")]
        public IActionResult GetWithAllFilters()
        {
            return Ok("This action applies Resource, Action, and Result filters.");
        }

        /// <summary>
        /// Endpoint that applies only the Resource filter.
        /// </summary>
        /// <returns>A message indicating the Resource filter applied.</returns>
        [CustomResourceFilter]
        [HttpGet("resource-filter-only")]
        public IActionResult GetWithResourceFilter()
        {
            return Ok("This action applies only the Resource filter.");
        }

        /// <summary>
        /// Endpoint that applies only the Action filter.
        /// </summary>
        /// <returns>A message indicating the Action filter applied.</returns>
        [CustomActionFilter]
        [HttpGet("action-filter-only")]
        public IActionResult GetWithActionFilter()
        {
            return Ok("This action applies only the Action filter.");
        }

        /// <summary>
        /// Endpoint that applies only the Result filter.
        /// </summary>
        /// <returns>A message indicating the Result filter applied.</returns>
        [CustomResultFilter]
        [HttpGet("result-filter-only")]
        public IActionResult GetWithResultFilter()
        {
            return Ok("This action applies only the Result filter.");
        }

        /// <summary>
        /// Endpoint that does not apply any custom filters.
        /// </summary>
        /// <returns>A message indicating no filters applied.</returns>
        [HttpGet("no-filters")]
        public IActionResult GetWithoutFilters()
        {
            return Ok("This action does not apply any custom filters.");
        }
    }
}