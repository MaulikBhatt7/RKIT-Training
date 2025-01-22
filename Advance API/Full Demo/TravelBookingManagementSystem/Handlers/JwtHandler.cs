using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using TravelBookingManagementSystem.Security;

namespace TravelBookingManagementSystem.Handlers
{
    public class JwtHandler
    {
        private static string SecretKey = "d41fe5f117b57539c498afa905a7307c26e5afce4cb54b849b92aba912c7f340"; // Store securely
        private static string Issuer = "yourIssuer";
        private static string Audience = "yourAudience";
        private static string AESKey = "1234567890123456"; // 16-byte AES key (must match key length requirement)
        private static string AESIV = "6543210987654321"; // 16-byte AES IV

        private static readonly AESEncyption aesEncryption = new AESEncyption();

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
                Expires = DateTime.UtcNow.AddDays(1),
                Issuer = Issuer,
                Audience = Audience,
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwt = tokenHandler.WriteToken(token);

            // Encrypt the JWT token
            return aesEncryption.Encrypt(jwt, AESKey, AESIV);
        }

        // Method to validate JWT token and extract claims
        public static ClaimsPrincipal ValidateToken(string encryptedToken)
        {
            try
            {
                // Decrypt the token
                var decryptedToken = aesEncryption.Decrypt(encryptedToken, AESKey, AESIV);

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
                    ClockSkew = TimeSpan.Zero
                };

                return tokenHandler.ValidateToken(decryptedToken, parameters, out var validatedToken);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static (int UserId, string Role) GetUserIdAndRoleFromToken(string encryptedToken)
        {
            try
            {
                // Decrypt the token
                var decryptedToken = aesEncryption.Decrypt(encryptedToken, AESKey, AESIV);

                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                var jsonToken = tokenHandler.ReadToken(decryptedToken) as JwtSecurityToken;

                if (jsonToken == null)
                {
                    throw new UnauthorizedAccessException("Invalid JWT token.");
                }
                var userIdClaim = jsonToken.Claims.FirstOrDefault(c => c.Type == "nameid");
                if (userIdClaim == null)
                {
                    throw new UnauthorizedAccessException("User ID not found in the token.");
                }

                var roleClaim = jsonToken.Claims.FirstOrDefault(c => c.Type == "role");
                if (roleClaim == null)
                {
                    throw new UnauthorizedAccessException("Role not found in the token.");
                }

                return (int.Parse(userIdClaim.Value), roleClaim.Value);
            }
            catch (Exception ex)
            {
                throw new UnauthorizedAccessException("Invalid token.", ex);
            }
        }
    }
}
