using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using TravelBookingManagementSystem.Security;

namespace TravelBookingManagementSystem.Handlers
{
    /// <summary>
    /// Handler for creating and validating JWT tokens.
    /// </summary>
    public class JwtHandler
    {
        // Secret key for signing the JWT tokens (store securely)
        private static string SecretKey = "d41fe5f117b57539c498afa905a7307c26e5afce4cb54b849b92aba912c7f340";
        private static string Issuer = "yourIssuer"; // JWT token issuer
        private static string Audience = "yourAudience"; // JWT token audience
        private static string AESKey = "1234567890123456"; // 16-byte AES key for encryption (must match key length requirement)
        private static string AESIV = "6543210987654321"; // 16-byte AES IV for encryption

        // AESEncyption instance for encryption and decryption
        private static readonly AESEncyption aesEncryption = new AESEncyption();

        /// <summary>
        /// Generates a JWT token for a user.
        /// </summary>
        /// <param name="username">The username of the user.</param>
        /// <param name="userID">The user ID.</param>
        /// <param name="role">The role of the user.</param>
        /// <returns>A JWT token as a string.</returns>
        public static string GenerateToken(string username, int userID, string role)
        {
            // Create security key and credentials
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            // Define the claims for the token
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, role),
                new Claim(ClaimTypes.NameIdentifier, userID.ToString())
            };

            // Create token descriptor with claims and expiration time
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(1),
                Issuer = Issuer,
                Audience = Audience,
                SigningCredentials = credentials
            };

            // Create the JWT token
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwt = tokenHandler.WriteToken(token);

            // Encrypt the JWT token
            return aesEncryption.Encrypt(jwt, AESKey, AESIV);
        }

        /// <summary>
        /// Validates a JWT token and extracts the claims.
        /// </summary>
        /// <param name="encryptedToken">The encrypted JWT token.</param>
        /// <returns>A ClaimsPrincipal containing the claims from the token.</returns>
        public static ClaimsPrincipal ValidateToken(string encryptedToken)
        {
            try
            {
                // Decrypt the token
                var decryptedToken = aesEncryption.Decrypt(encryptedToken, AESKey, AESIV);

                // Define token validation parameters
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
                    ClockSkew = TimeSpan.Zero // No clock skew allowed
                };

                // Validate the token and return the claims principal
                return tokenHandler.ValidateToken(decryptedToken, parameters, out var validatedToken);
            }
            catch (Exception)
            {
                return null; // Return null if validation fails
            }
        }

        /// <summary>
        /// Extracts the user ID and role from a JWT token.
        /// </summary>
        /// <param name="encryptedToken">The encrypted JWT token.</param>
        /// <returns>A tuple containing the user ID and role.</returns>
        public static (int UserId, string Role) GetUserIdAndRoleFromToken(string encryptedToken)
        {
            try
            {
                // Decrypt the token
                var decryptedToken = aesEncryption.Decrypt(encryptedToken, AESKey, AESIV);

                // Read the token and extract claims
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

                // Return the user ID and role
                return (int.Parse(userIdClaim.Value), roleClaim.Value);
            }
            catch (Exception ex)
            {
                throw new UnauthorizedAccessException("Invalid token.", ex);
            }
        }
    }
}