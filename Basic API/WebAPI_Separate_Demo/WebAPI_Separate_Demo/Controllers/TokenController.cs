using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Web.Http;
using Microsoft.IdentityModel.Tokens;

namespace JwtDemo.Controllers
{
   
    public class TokenController : ApiController
    {
        private const string SecretKey = "my-256-bit-secret-key-12345678901234567890123456789012";
        private const string Issuer = "my-issuer";
        private const string Audience = "my-audience";

        /// <summary>
        /// Generates a JWT token for the given username and role.
        /// </summary>
        /// <param name="username">The username for the token.</param>
        /// <param name="role">The role for the token.</param>
        /// <returns>A JWT token.</returns>
        [HttpPost]
        [Route("api/token/generate")]
        public IHttpActionResult GenerateToken(string username, string role)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(role))
                return BadRequest("Username and role are required.");

            var key = Encoding.UTF8.GetBytes(SecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, role)
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                Issuer = Issuer,
                Audience = Audience,
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new { Token = tokenString });
        }
    }
}
