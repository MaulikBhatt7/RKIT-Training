using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

/// <summary>
/// Provides methods for encrypting and decrypting strings using AES encryption.
/// </summary>
public static class AesEncryptionHandler
{
    /// <summary>
    /// The encryption key used for AES encryption. Must be 32 characters for AES-256.
    /// </summary>
    private static readonly string Key = "13579135791357913579135791357900";

    /// <summary>
    /// The initialization vector (IV) used for AES encryption. Must be 16 characters.
    /// </summary>
    private static readonly string IV = "1357913579135790";

    /// <summary>
    /// Encrypts the specified plain text using AES encryption.
    /// </summary>
    /// <param name="plainText">The plain text to be encrypted.</param>
    /// <returns>A base64 encoded string representing the encrypted data.</returns>
    public static string Encrypt(string plainText)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = Encoding.UTF8.GetBytes(Key);
            aes.IV = Encoding.UTF8.GetBytes(IV);

            using (MemoryStream ms = new MemoryStream())
            using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
            {
                using (StreamWriter writer = new StreamWriter(cs))
                {
                    writer.Write(plainText);
                }
                return Convert.ToBase64String(ms.ToArray());
            }
        }
    }

    /// <summary>
    /// Decrypts the specified cipher text using AES encryption.
    /// </summary>
    /// <param name="cipherText">The base64 encoded string representing the encrypted data.</param>
    /// <returns>The decrypted plain text.</returns>
    public static string Decrypt(string cipherText)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = Encoding.UTF8.GetBytes(Key);
            aes.IV = Encoding.UTF8.GetBytes(IV);

            using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(cipherText)))
            using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read))
            {
                using (StreamReader reader = new StreamReader(cs))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}
