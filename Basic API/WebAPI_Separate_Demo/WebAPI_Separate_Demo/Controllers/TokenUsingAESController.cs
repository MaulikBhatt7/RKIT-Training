using System.Web.Http;

public class TokenUsingAESController : ApiController
{
    [HttpGet]
    [Route("api/aes-token/generate")]
    public IHttpActionResult GenerateToken(string username)
    {
        var token = JwtTokenHelper.GenerateToken(username);
        var encryptedToken = JwtTokenHelper.EncryptToken(token);

        return Ok(new
        {
            Token = token,
            EncryptedToken = encryptedToken
        });
    }

    [HttpGet]
    [Route("api/aes-token/decrypt")]
    public IHttpActionResult DecryptToken(string encryptedToken)
    {
        var decryptedToken = JwtTokenHelper.DecryptToken(encryptedToken);
        return Ok(new
        {
            EncryptedToken = encryptedToken,
            DecryptedToken = decryptedToken
        });
    }
}
