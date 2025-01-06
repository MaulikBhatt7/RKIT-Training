using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LINQDemo.Models
{
    /// <summary>
    /// Represents a City entity with its ID and name.
    /// </summary>
    public class City
    {
        /// <summary>
        /// Gets or sets the unique identifier for the city.
        /// </summary>
        public int CityId { get; set; }

        /// <summary>
        /// Gets or sets the name of the city.
        /// </summary>
        public string CityName { get; set; }
    }
}
