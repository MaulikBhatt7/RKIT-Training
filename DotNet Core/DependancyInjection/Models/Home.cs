using DependancyInjection.Services;
using System;

namespace DependancyInjection.Models
{
    /// <summary>
    /// The Home class implements the IHome interface.
    /// </summary>
    public class Home : IHome
    {
        /// <summary>
        /// Implements the Greet method from the IHome interface.
        /// </summary>
        public void Greet()
        {
            // This message will be printed when the Greet method is called.
            Console.WriteLine("Hello From Home!");
        }
    }
}