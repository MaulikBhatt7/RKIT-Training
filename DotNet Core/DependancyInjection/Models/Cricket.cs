using DependancyInjection.Services;
using System;

namespace DependancyInjection.Models
{
    /// <summary>
    /// The Cricket class implements the ICricket interface.
    /// </summary>
    public class Cricket : ICricket
    {
        /// <summary>
        /// Implements the Play method from the ICricket interface.
        /// </summary>
        public void Play()
        {
            // This message will be printed when the Play method is called.
            Console.WriteLine("Hello From Cricket!");
        }
    }
}