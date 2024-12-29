using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI_Separate_Demo.Models
{
    /// <summary>
    /// Represents a product with basic attributes.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Gets or sets the unique identifier for the product.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the price of the product.
        /// </summary>
        public decimal Price { get; set; }
    }
}