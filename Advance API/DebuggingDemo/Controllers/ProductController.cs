using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web.Http;
using DebuggingDemo.Models;

namespace DebuggingDemo.Controllers
{
    /// <summary>
    /// Controller to manage product-related operations.
    /// Supports CRUD operations using static data for demonstration.
    /// </summary>
    public class ProductsController : ApiController
    {
        /// <summary>
        /// Static list of products simulating a data store.
        /// </summary>
        private static List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 1500 },
            new Product { Id = 2, Name = "Smartphone", Price = 800 },
            new Product { Id = 3, Name = "Tablet", Price = 400 }
        };

        /// <summary>
        /// Retrieves the list of all products.
        /// </summary>
        /// <returns>HTTP 200 OK with the list of products.</returns>
        [HttpGet]

        public IHttpActionResult Get()
        {
            return Ok(products);
        }

        /// <summary>
        /// Retrieves a specific product by its ID.
        /// </summary>
        /// <param name="id">The ID of the product to retrieve.</param>
        /// <returns>HTTP 200 OK with the product or 404 Not Found if the product does not exist.</returns>
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
#if DEBUG
            Debug.WriteLine(product.Id);

            if (product == null)
                return NotFound();
#endif
            return Ok(product);
        }

        /// <summary>
        /// Adds a new product to the list.
        /// </summary>
        /// <param name="newProduct">The product to add.</param>
        /// <returns>HTTP 201 Created with the new product or 400 Bad Request for invalid input.</returns>
        [HttpPost]
        public IHttpActionResult Post([FromBody] Product newProduct)
        {
            if (newProduct == null)
                return BadRequest("Invalid product data.");

            newProduct.Id = products.Count + 1;
            products.Add(newProduct);

            return Created($"api/products/{newProduct.Id}", newProduct);
        }

        /// <summary>
        /// Updates an existing product by its ID.
        /// </summary>
        /// <param name="id">The ID of the product to update.</param>
        /// <param name="updatedProduct">The updated product data.</param>
        /// <returns>HTTP 204 No Content or 404 Not Found if the product does not exist.</returns>
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody] Product updatedProduct)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound();

            if (updatedProduct == null)
                return BadRequest("Invalid product data.");

            product.Name = updatedProduct.Name;
            product.Price = updatedProduct.Price;

            return StatusCode(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Deletes a product by its ID.
        /// </summary>
        /// <param name="id">The ID of the product to delete.</param>
        /// <returns>HTTP 204 No Content or 404 Not Found if the product does not exist.</returns>
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound();

            products.Remove(product);

            return StatusCode(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Partially updates a product by its ID.
        /// </summary>
        /// <param name="id">The ID of the product to update.</param>
        /// <param name="updates">Key-value pairs of the fields to update.</param>
        /// <returns>HTTP 200 OK with the updated product or 404 Not Found if the product does not exist.</returns>
        [HttpPatch]
        public IHttpActionResult Patch(int id, [FromBody] Dictionary<string, object> updates)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound();

            if (updates == null || updates.Count == 0)
                return BadRequest("Invalid updates.");

            foreach (var update in updates)
            {
                if (update.Key.ToLower() == "name" && update.Value is string)
                    product.Name = update.Value.ToString();
                else if (update.Key.ToLower() == "price" && decimal.TryParse(update.Value.ToString(), out var price))
                    product.Price = price;
            }

            return Ok(product);
        }
    }
}
