using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace FiltersDemo.Filters
{
    /// <summary>
    /// Custom result filter to execute code before and after the action result.
    /// </summary>
    public class CustomResultFilter : Attribute, IResultFilter
    {
        /// <summary>
        /// Code to execute before the action result is executed.
        /// </summary>
        /// <param name="context">The context of the result executing.</param>
        public void OnResultExecuting(ResultExecutingContext context)
        {
            // Log or perform an action before the action result executes.
            Console.WriteLine("OnResultExecuting");
        }

        /// <summary>
        /// Code to execute after the action result is executed.
        /// </summary>
        /// <param name="context">The context of the result executed.</param>
        public void OnResultExecuted(ResultExecutedContext context)
        {
            // Log or perform an action after the action result executes.
            Console.WriteLine("OnResultExecuted");
        }
    }
}