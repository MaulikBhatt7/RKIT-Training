using AuthDemo.Filters;
using System.Web.Http;

namespace AuthDemo.Controllers
{
    [BasicAuthentication]
    public class SecureController : ApiController
    {
        [HttpGet]
        [Route("api/secure/data")]
        public IHttpActionResult GetSecureData()
        {
            var username = System.Threading.Thread.CurrentPrincipal.Identity.Name;
            return Ok($"Hello, {username}. This is secure data.");
        }
    }
}
