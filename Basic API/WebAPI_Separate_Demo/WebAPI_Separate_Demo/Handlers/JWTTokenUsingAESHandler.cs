using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

public static class JwtTokenHelper
{
    private static readonly string SecretKey = "135791357913579135791357913579135790"; 

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

    public static string EncryptToken(string token)
    {
        return AesEncryptionHandler.Encrypt(token);
    }

    public static string DecryptToken(string encryptedToken)
    {
        return AesEncryptionHandler.Decrypt(encryptedToken);
    }
}
