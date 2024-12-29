using System;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Filters;

public class BasicAuthenticationFilter : Attribute, IAuthenticationFilter
{
    public bool AllowMultiple => false;

    public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
    {
        var authHeader = context.Request.Headers.Authorization;

        if (authHeader == null || authHeader.Scheme != "Basic")
        {
            context.ErrorResult = new AuthenticationFailureResult("Missing Authentication header", context.Request);
            return;
        }

        var credentials = Encoding.UTF8.GetString(Convert.FromBase64String(authHeader.Parameter)).Split(':');
        if (credentials.Length != 2 || !ValidateUser(credentials[0], credentials[1]))
        {
            context.ErrorResult = new AuthenticationFailureResult("Invalid username or password", context.Request);
            return;
        }

        // Set the principal to indicate the user is authenticated
        var identity = new GenericIdentity(credentials[0]);
        string[] roles = { "Admin","Manager" };
        context.Principal = new GenericPrincipal(identity,roles);
    
    }

    public async Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
    {
        // Add WWW-Authenticate header for challenges
        context.Result = new AddChallengeOnUnauthorizedResult("Basic realm=\"SecureAPI\"", context.Result);
    }

    private bool ValidateUser(string username, string password)
    {
        // Replace with database or other user validation logic
        return username == "admin" && password == "password";
    }
}

public class AuthenticationFailureResult : IHttpActionResult
{
    private readonly string _reasonPhrase;
    private readonly HttpRequestMessage _request;

    public AuthenticationFailureResult(string reasonPhrase, HttpRequestMessage request)
    {
        _reasonPhrase = reasonPhrase;
        _request = request;
    }

    public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
    {
        var response = _request.CreateResponse(HttpStatusCode.Unauthorized, new { Message = _reasonPhrase });
        response.RequestMessage = _request;
        return Task.FromResult(response);
    }
}

public class AddChallengeOnUnauthorizedResult : IHttpActionResult
{
    private readonly string _challenge;
    private readonly IHttpActionResult _innerResult;

    public AddChallengeOnUnauthorizedResult(string challenge, IHttpActionResult innerResult)
    {
        _challenge = challenge;
        _innerResult = innerResult;
    }

    public async Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
    {
        var response = await _innerResult.ExecuteAsync(cancellationToken);
        if (response.StatusCode == HttpStatusCode.Unauthorized)
        {
            response.Headers.WwwAuthenticate.Add(new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", _challenge));
        }
        return response;
    }
}
