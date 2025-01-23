using Microsoft.AspNetCore.Mvc;

namespace RoutingDemo.Controllers
{
    /// <summary>
    /// Controller to handle value-related actions.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        /// <summary>
        /// Gets a list of values.
        /// </summary>
        /// <returns>An array of strings representing values.</returns>
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            // Return a list of values.
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// Gets a value by its ID.
        /// </summary>
        /// <param name="id">The ID of the value.</param>
        /// <returns>A string representing the value.</returns>
        // GET api/<ValuesController>/5
        [HttpGet("{id:int:min(1):max(100)}")] // Restricts ID to be between 1 and 100.
        public string Get(int id)
        {
            // Return a value based on the ID.
            return "value";
        }

        /// <summary>
        /// Posts a new value.
        /// </summary>
        /// <param name="value">The value to post.</param>
        // POST api/<ValuesController>
        [HttpPost]
        [Route("~/api/myPost")] // Custom route for the POST method.
        public void Post([FromBody] string value)
        {
            // Logic to handle the posted value.
        }

        /// <summary>
        /// Updates a value by its ID.
        /// </summary>
        /// <param name="id">The ID of the value to update.</param>
        /// <param name="value">The new value.</param>
        // PUT api/<ValuesController>/5
        [HttpPut("{id?}")] // Optional ID parameter.
        public void Put(int id, [FromBody] string value)
        {
            // Logic to update the value based on the ID.
        }

        /// <summary>
        /// Deletes a value by its ID.
        /// </summary>
        /// <param name="id">The ID of the value to delete.</param>
        // DELETE api/<ValuesController>/5
        [HttpDelete("{id=1}")] // Default ID value is 1.
        public void Delete(int id)
        {
            // Logic to delete the value based on the ID.
        }
    }
}