using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

public class CustomExceptionFilter : ExceptionFilterAttribute
{
    /// <summary>
    /// Handles exceptions thrown during the execution of an action, creating a custom response.
    /// </summary>
    /// <param name="context">
    /// The context of the action where the exception occurred, including the exception details.
    /// </param>
    public override void OnException(HttpActionExecutedContext context)
    {
        // Create a custom response
        var response = new
        {
            Message = "An unexpected error occurred. Please try again later.",
            Error = context.Exception.Message
        };

        // Set the response with a 500 Internal Server Error and the custom error message
        context.Response = context.Request.CreateResponse(HttpStatusCode.InternalServerError, response);
    }
}
