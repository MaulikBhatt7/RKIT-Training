using DependancyInjection.Services;
using System;

namespace DependancyInjection.Models
{
    /// <summary>
    /// The School class implements the IEducation interface.
    /// </summary>
    public class School : IEducation
    {
        /// <summary>
        /// Implements the Teach method from the IEducation interface.
        /// </summary>
        public void Teach()
        {
            // This message will be printed when the Teach method is called.
            Console.WriteLine("Hello From School!");
        }
    }
}