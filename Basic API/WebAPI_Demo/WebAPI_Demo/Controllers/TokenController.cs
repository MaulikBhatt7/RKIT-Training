using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Web.Http;
using Microsoft.IdentityModel.Tokens;

namespace JwtAuthenticationDemo.Controllers
{
    public class TokenController : ApiController
    {
        // POST api/token
        [HttpPost]
        [Route("api/token")]
        public IHttpActionResult GenerateToken([FromBody] LoginModel login)
        {
            if (login == null || (login.Username != "user" && login.Username != "admin") || login.Password != "password")
            {
                return Unauthorized();
            }

            var role = login.Username == "admin" ? "Admin" : "User";

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("my-256-bit-secret-key-12345678901234567890123456789012"));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, login.Username),
                new Claim(ClaimTypes.Role, role)
            };

            var jwtToken = new JwtSecurityToken(
                issuer: "my-issuer",
                audience: "my-audience",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: signingCredentials
            );

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenString = tokenHandler.WriteToken(jwtToken);

            return Ok(new { Token = tokenString });
        }
    }

    // Model for Login
    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
