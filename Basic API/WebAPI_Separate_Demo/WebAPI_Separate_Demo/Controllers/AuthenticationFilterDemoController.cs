using System.Threading;
using System.Web.Http;

/// <summary>
/// Controller to demonstrate the usage of basic authentication filter.
/// </summary>
[BasicAuthenticationFilter]
public class AuthenticationFilterDemoController : ApiController
{
    /// <summary>
    /// Gets secure data for authenticated users.
    /// </summary>
    /// <returns>
    /// An HTTP response containing a success message and the name of the authenticated user.
    /// </returns>
    [HttpGet]
    [Route("api/authentication-filter-demo")]
    public IHttpActionResult GetSecureData()
    {
        return Ok(new { Message = "You are authenticated!", User = Thread.CurrentPrincipal.Identity.Name });
    }
}
