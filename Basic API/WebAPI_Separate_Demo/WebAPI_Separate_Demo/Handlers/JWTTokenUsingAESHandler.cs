using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

/// <summary>
/// Helper class for generating and managing JWT tokens.
/// </summary>
public static class JwtTokenHelper
{
    /// <summary>
    /// The secret key used for signing JWT tokens.
    /// </summary>
    private static readonly string SecretKey = "135791357913579135791357913579135790";

    /// <summary>
    /// Generates a JWT token for the specified username with an optional expiration time.
    /// </summary>
    /// <param name="username">The username to include in the token.</param>
    /// <param name="expireMinutes">The number of minutes after which the token expires. Default is 30 minutes.</param>
    /// <returns>The generated JWT token as a string.</returns>
    public static string GenerateToken(string username, int expireMinutes = 30)
    {
        var symmetricKey = Encoding.UTF8.GetBytes(SecretKey);
        var tokenHandler = new JwtSecurityTokenHandler();

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, username)
            }),
            Expires = DateTime.UtcNow.AddMinutes(expireMinutes),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(symmetricKey),
                SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    /// <summary>
    /// Encrypts a JWT token using AES encryption.
    /// </summary>
    /// <param name="token">The JWT token to encrypt.</param>
    /// <returns>The encrypted token as a string.</returns>
    public static string EncryptToken(string token)
    {
        return AesEncryptionHandler.Encrypt(token);
    }

    /// <summary>
    /// Decrypts an encrypted JWT token.
    /// </summary>
    /// <param name="encryptedToken">The encrypted JWT token to decrypt.</param>
    /// <returns>The original JWT token as a string.</returns>
    public static string DecryptToken(string encryptedToken)
    {
        return AesEncryptionHandler.Decrypt(encryptedToken);
    }
}
