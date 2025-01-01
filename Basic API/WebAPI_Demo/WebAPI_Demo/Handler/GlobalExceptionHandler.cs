using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace GlobalExceptionDemo
{
    /// <summary>
    /// A custom exception handler that handles unhandled exceptions globally.
    /// </summary>
    public class GlobalExceptionHandler : ExceptionHandler
    {
        /// <summary>
        /// Handles exceptions by creating a custom response with the exception details.
        /// </summary>
        /// <param name="context">The context containing the exception details.</param>
        public override void Handle(ExceptionHandlerContext context)
        {
            // Create a custom response with error message and exception details
            var response = new
            {
                Message = "An unexpected error occurred. Please try again later.",
                Error = context.Exception.Message, // Optional: For debugging (remove in production)
                ExceptionType = context.Exception.GetType().Name
            };

            // Set the result to a custom error message response
            context.Result = new ErrorMessageResult(context.Request, response);
        }
    }

    /// <summary>
    /// A custom IHttpActionResult that returns an error message as a response.
    /// </summary>
    public class ErrorMessageResult : IHttpActionResult
    {
        private readonly HttpRequestMessage _request;
        private readonly object _response;

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorMessageResult"/> class.
        /// </summary>
        /// <param name="request">The HTTP request message.</param>
        /// <param name="response">The response object containing error details.</param>
        public ErrorMessageResult(HttpRequestMessage request, object response)
        {
            _request = request;
            _response = response;
        }

        /// <summary>
        /// Executes the result asynchronously, returning an HTTP response with the error details.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous operation, with the HTTP response message as the result.</returns>
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            // Create the HTTP response message with status code 500 (Internal Server Error)
            var message = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(_response)),
                ReasonPhrase = "Internal Server Error",
                RequestMessage = _request
            };

            // Return the response message asynchronously
            return Task.FromResult(message);
        }
    }
}
