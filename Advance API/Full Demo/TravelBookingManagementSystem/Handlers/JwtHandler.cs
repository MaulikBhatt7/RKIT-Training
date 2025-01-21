using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.SqlServer.Server;


namespace TravelBookingManagementSystem.Handlers
{
    public class JwtHandler
    {
        private static string SecretKey = "d41fe5f117b57539c498afa905a7307c26e5afce4cb54b849b92aba912c7f340"; // Store securely
        private static string Issuer = "yourIssuer";
        private static string Audience = "yourAudience";

        // Method to create JWT token
        public static string GenerateToken(string username, int userID, string role)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, role),
                new Claim(ClaimTypes.NameIdentifier, userID.ToString())
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(1), // Token expiration (1 day)
                Issuer = Issuer,
                Audience = Audience,
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        // Method to validate JWT token and extract claims
        public static ClaimsPrincipal ValidateToken(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(SecretKey);
                var parameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Issuer,
                    ValidAudience = Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ClockSkew = TimeSpan.Zero // Optional: remove clock skew allowance
                };

                var principal = tokenHandler.ValidateToken(token, parameters, out var validatedToken);
                return principal; // Return the claims principal
            }
            catch (Exception)
            {
                return null; // If token is invalid, return null
            }
        }


        public static int GetUserIdFromToken(string token)
        {
            JwtSecurityTokenHandler objJwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var jsonToken = objJwtSecurityTokenHandler.ReadToken(token) as JwtSecurityToken;

            if (jsonToken == null)
            {
                throw new UnauthorizedAccessException("Invalid JWT token.");
            }

            Console.WriteLine("Token Claims:");
            foreach (var claim in jsonToken.Claims)
            {
                Console.WriteLine($"Claim Type: {claim.Type}, Claim Value: {claim.Value}");
            }

            // Get the userId claim from the token
            var userIdClaim = jsonToken?.Claims.FirstOrDefault(c => c.Type == "nameid");



            if (userIdClaim != null)
            {
                return int.Parse(userIdClaim.Value);  // Return the UserId as an integer
            }

            throw new UnauthorizedAccessException("User ID not found in the token.");
        }
    }
}
