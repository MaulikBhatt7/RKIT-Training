using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace FiltersDemo.Filters
{
    /// <summary>
    /// Custom action filter to execute code before and after an action method.
    /// </summary>
    public class CustomActionFilter : Attribute, IActionFilter
    {
        /// <summary>
        /// Code to execute before the action method is called.
        /// </summary>
        /// <param name="context">The context of the action executing.</param>
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Log or perform an action before the action method executes.
            Console.WriteLine("OnActionExecuting");
        }

        /// <summary>
        /// Code to execute after the action method is called.
        /// </summary>
        /// <param name="context">The context of the action executed.</param>
        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Log or perform an action after the action method executes.
            Console.WriteLine("OnActionExecuted");
        }
    }
}