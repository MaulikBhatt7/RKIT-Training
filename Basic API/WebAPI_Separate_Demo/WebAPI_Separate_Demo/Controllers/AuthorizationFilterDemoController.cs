using System.Threading;
using System.Web;
using System.Web.Http;

/// <summary>
/// Controller to demonstrate the usage of an authorization filter for role-based access control.
/// </summary>
[BasicAuthenticationFilter]
public class AuthorizationFilterDemoController : ApiController
{
    /// <summary>
    /// Gets secure data for authorized users with the "Admin" role.
    /// </summary>
    /// <returns>
    /// An HTTP response containing a success message and the name of the authorized user.
    /// </returns>
    [HttpGet]
    [Route("api/authorization")]
    [RoleAuthorizationFilter("Admin")]
    public IHttpActionResult GetAdminData()
    {
        return Ok(new { Message = "You are authorized!", User = HttpContext.Current.User.Identity.Name });
    }
}
