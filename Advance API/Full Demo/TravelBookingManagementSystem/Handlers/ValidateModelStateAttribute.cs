using System.Linq;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace TravelBookingManagementSystem.Handlers
{
    /// <summary>
    /// Attribute to validate the model state before the action method is executed.
    /// </summary>
    public class ValidateModelStateAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// Method that gets invoked before the action method is called.
        /// </summary>
        /// <param name="actionContext">The action context.</param>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            // Check if the model state is valid
            if (!actionContext.ModelState.IsValid)
            {
                // Extract the validation errors from the model state
                var errors = actionContext.ModelState
                    .Where(e => e.Value.Errors.Count > 0)
                    .Select(e => new
                    {
                        Field = e.Key, // The field that has validation errors
                        Errors = e.Value.Errors.Select(err => err.ErrorMessage).ToList() // List of error messages for the field
                    }).ToList();

                // Return a BadRequest response with the validation errors
                actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, errors);
            }

            // Call the base method to allow the action to proceed if the model state is valid
            base.OnActionExecuting(actionContext);
        }
    }
}