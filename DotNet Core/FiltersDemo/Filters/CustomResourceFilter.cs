using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace FiltersDemo.Filters
{
    /// <summary>
    /// Custom resource filter to execute code before and after an action method.
    /// </summary>
    public class CustomResourceFilter : Attribute, IResourceFilter
    {
        /// <summary>
        /// Code to execute before the action method is called.
        /// </summary>
        /// <param name="context">The context of the resource executing.</param>
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            // Log or perform an action before the action method executes.
            Console.WriteLine("OnResourceExecuting");
        }

        /// <summary>
        /// Code to execute after the action method is called.
        /// </summary>
        /// <param name="context">The context of the resource executed.</param>
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            // Log or perform an action after the action method executes.
            Console.WriteLine("OnResourceExecuted");
        }
    }
}