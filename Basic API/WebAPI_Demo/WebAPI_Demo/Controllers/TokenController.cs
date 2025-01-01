using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Web.Http;
using Microsoft.IdentityModel.Tokens;
using WebAPI_Demo.Models;

namespace JwtAuthenticationDemo.Controllers
{
    /// <summary>
    /// Controller responsible for generating JWT tokens.
    /// </summary>
    public class TokenController : ApiController
    {
        /// <summary>
        /// Generates a JWT token for an authenticated user.
        /// </summary>
        /// <param name="login">The login model containing the username and password.</param>
        /// <returns>
        /// An HTTP response containing the generated JWT token if authentication is successful.
        /// Otherwise, returns an unauthorized response.
        /// </returns>
        [HttpPost]
        [Route("api/token")]
        public IHttpActionResult GenerateToken([FromBody] LoginModel login)
        {
            // Validate user credentials
            if (login == null || (login.Username != "user" && login.Username != "admin") || login.Password != "password")
            {
                return Unauthorized();
            }

            // Assign role based on the username
            var role = login.Username == "admin" ? "Admin" : "User";

            // Create security key and signing credentials
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("my-256-bit-secret-key-12345678901234567890123456789012"));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Define claims for the JWT token
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, login.Username),
                new Claim(ClaimTypes.Role, role)
            };

            // Create the JWT token
            var jwtToken = new JwtSecurityToken(
                issuer: "my-issuer",
                audience: "my-audience",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: signingCredentials
            );

            // Serialize the token
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenString = tokenHandler.WriteToken(jwtToken);

            // Return the token in the response
            return Ok(new { Token = tokenString });
        }
    }
}
