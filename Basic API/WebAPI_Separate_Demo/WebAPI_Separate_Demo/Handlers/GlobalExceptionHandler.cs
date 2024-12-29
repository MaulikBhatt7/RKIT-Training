using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace GlobalExceptionDemo
{
    /// <summary>
    /// Global exception handler that handles unhandled exceptions across the API.
    /// </summary>
    public class GlobalExceptionHandler : ExceptionHandler
    {
        /// <summary>
        /// Handles the exception and creates a custom response.
        /// </summary>
        /// <param name="context">
        /// The context that contains details about the exception and the HTTP request.
        /// </param>
        public override void Handle(ExceptionHandlerContext context)
        {
            // Create a custom response
            var response = new
            {
                Message = "An unexpected error occurred. Please try again later.",
                Error = context.Exception.Message, // Optional: For debugging (remove in production)
                ExceptionType = context.Exception.GetType().Name
            };

            // Set the response
            context.Result = new ErrorMessageResult(context.Request, response);
        }
    }

    /// <summary>
    /// Represents the custom error response result.
    /// </summary>
    public class ErrorMessageResult : IHttpActionResult
    {
        private readonly HttpRequestMessage _request;
        private readonly object _response;

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorMessageResult"/> class.
        /// </summary>
        /// <param name="request">
        /// The HTTP request message that caused the error.
        /// </param>
        /// <param name="response">
        /// The custom response data to be returned to the client.
        /// </param>
        public ErrorMessageResult(HttpRequestMessage request, object response)
        {
            _request = request;
            _response = response;
        }

        /// <summary>
        /// Executes the asynchronous operation to generate the HTTP response with the error message.
        /// </summary>
        /// <param name="cancellationToken">
        /// The cancellation token that can be used to cancel the operation.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation. The result is an <see cref="HttpResponseMessage"/> with the error content.
        /// </returns>
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var message = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(_response)),
                ReasonPhrase = "Internal Server Error",
                RequestMessage = _request
            };

            return Task.FromResult(message);
        }
    }
}
