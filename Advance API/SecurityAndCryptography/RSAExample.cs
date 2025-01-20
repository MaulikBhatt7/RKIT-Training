using System;
using System.Security.Cryptography;
using System.Text;

namespace SecurityAndCryptography
{
    /// <summary>
    /// A class that demonstrates RSA encryption and decryption using OAEP with SHA-256 padding.
    /// </summary>
    public class RSAExample
    {
        /// <summary>
        /// Encrypts the given plaintext using RSA encryption with the specified RSA object.
        /// </summary>
        /// <param name="plaintext">The plaintext to encrypt.</param>
        /// <param name="rsa">The RSA instance used for encryption.</param>
        /// <returns>The encrypted text as a Base64-encoded string.</returns>
        public string Encrypt(string plaintext, RSA objRSA)
        {
            // Convert the plaintext into byte array using UTF8 encoding.
            byte[] objPlaintextBytes = Encoding.UTF8.GetBytes(plaintext);

            // Encrypt the plaintext using the provided RSA object and OAEP with SHA-256 padding.
            byte[] objEncryptedBytes = objRSA.Encrypt(objPlaintextBytes, RSAEncryptionPadding.OaepSHA256);

            // Return the encrypted data as a Base64 string.
            return Convert.ToBase64String(objEncryptedBytes);
        }

        /// <summary>
        /// Decrypts the given ciphertext using RSA decryption with the specified RSA object.
        /// </summary>
        /// <param name="ciphertext">The ciphertext to decrypt (Base64-encoded).</param>
        /// <param name="rsa">The RSA instance used for decryption.</param>
        /// <returns>The decrypted plaintext as a string.</returns>
        public string Decrypt(string ciphertext, RSA objRSA)
        {
            // Convert the Base64 encoded ciphertext into a byte array.
            byte[] objCiphertextBytes = Convert.FromBase64String(ciphertext);

            // Decrypt the ciphertext using the provided RSA object and OAEP with SHA-256 padding.
            byte[] objDecryptedBytes = objRSA.Decrypt(objCiphertextBytes, RSAEncryptionPadding.OaepSHA256);

            // Convert the decrypted byte array into a UTF-8 string and return it.
            return Encoding.UTF8.GetString(objDecryptedBytes);
        }
    }
}
