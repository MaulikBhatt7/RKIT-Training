using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvanceDemo
{
    /// <summary>
    /// Represents a person with an ID, name, and age.
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Gets or sets the unique identifier for the person.
        /// </summary>
        public int PersonID { get; set; }

        /// <summary>
        /// Gets or sets the name of the person.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the age of the person.
        /// </summary>
        public int Age { get; set; }
    }
}
