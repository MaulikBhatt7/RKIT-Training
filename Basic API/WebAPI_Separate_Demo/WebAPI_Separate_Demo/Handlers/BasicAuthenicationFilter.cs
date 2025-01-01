using System;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Filters;

/// <summary>
/// Custom filter for implementing basic authentication in a Web API.
/// </summary>
public class BasicAuthenticationFilter : Attribute, IAuthenticationFilter
{
    /// <summary>
    /// Gets a value indicating whether the filter allows multiple instances.
    /// </summary>
    public bool AllowMultiple => false;

    /// <summary>
    /// Authenticates the incoming request by validating the Authorization header.
    /// </summary>
    /// <param name="context">The HTTP authentication context.</param>
    /// <param name="cancellationToken">A cancellation token for the task.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
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
        string[] roles = { "Admin", "Manager" };
        context.Principal = new GenericPrincipal(identity, roles);
    }

    /// <summary>
    /// Challenges unauthorized requests by adding a WWW-Authenticate header.
    /// </summary>
    /// <param name="context">The HTTP authentication challenge context.</param>
    /// <param name="cancellationToken">A cancellation token for the task.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
    {
        // Add WWW-Authenticate header for challenges
        context.Result = new AddChallengeOnUnauthorizedResult("Basic realm=\"SecureAPI\"", context.Result);
    }

    /// <summary>
    /// Validates the username and password for authentication.
    /// Replace this with a database or other validation logic.
    /// </summary>
    /// <param name="username">The username provided in the request.</param>
    /// <param name="password">The password provided in the request.</param>
    /// <returns>True if the credentials are valid; otherwise, false.</returns>
    private bool ValidateUser(string username, string password)
    {
        // Replace with database or other user validation logic
        return username == "admin" && password == "password";
    }
}

/// <summary>
/// Represents an authentication failure result for HTTP requests.
/// </summary>
public class AuthenticationFailureResult : IHttpActionResult
{
    private readonly string _reasonPhrase;
    private readonly HttpRequestMessage _request;

    /// <summary>
    /// Initializes a new instance of the <see cref="AuthenticationFailureResult"/> class.
    /// </summary>
    /// <param name="reasonPhrase">The reason phrase to be included in the response.</param>
    /// <param name="request">The original HTTP request.</param>
    public AuthenticationFailureResult(string reasonPhrase, HttpRequestMessage request)
    {
        _reasonPhrase = reasonPhrase;
        _request = request;
    }

    /// <summary>
    /// Executes the result by creating an unauthorized HTTP response.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token for the task.</param>
    /// <returns>A task that represents the HTTP response message.</returns>
    public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
    {
        var response = _request.CreateResponse(HttpStatusCode.Unauthorized, new { Message = _reasonPhrase });
        response.RequestMessage = _request;
        return Task.FromResult(response);
    }
}

/// <summary>
/// Adds a WWW-Authenticate challenge header to unauthorized HTTP responses.
/// </summary>
public class AddChallengeOnUnauthorizedResult : IHttpActionResult
{
    private readonly string _challenge;
    private readonly IHttpActionResult _innerResult;

    /// <summary>
    /// Initializes a new instance of the <see cref="AddChallengeOnUnauthorizedResult"/> class.
    /// </summary>
    /// <param name="challenge">The challenge string to be added to the WWW-Authenticate header.</param>
    /// <param name="innerResult">The inner result to be executed.</param>
    public AddChallengeOnUnauthorizedResult(string challenge, IHttpActionResult innerResult)
    {
        _challenge = challenge;
        _innerResult = innerResult;
    }

    /// <summary>
    /// Executes the result by adding the challenge header to the response.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token for the task.</param>
    /// <returns>A task that represents the HTTP response message.</returns>
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
