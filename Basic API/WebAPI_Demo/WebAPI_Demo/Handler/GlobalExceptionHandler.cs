using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace GlobalExceptionDemo
{
    public class GlobalExceptionHandler : ExceptionHandler
    {
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

    public class ErrorMessageResult : IHttpActionResult
    {
        private readonly HttpRequestMessage _request;
        private readonly object _response;

        public ErrorMessageResult(HttpRequestMessage request, object response)
        {
            _request = request;
            _response = response;
        }

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
