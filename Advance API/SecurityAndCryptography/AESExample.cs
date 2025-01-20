using System.Security.Cryptography;
using System.Text;

namespace SecurityAndCryptography
{
    /// <summary>
    /// A class that demonstrates AES encryption and decryption.
    /// </summary>
    public class AESExample
    {
        /// <summary>
        /// Encrypts the given plaintext using AES encryption with the specified key and IV.
        /// </summary>
        /// <param name="plaintext">The plaintext to encrypt.</param>
        /// <param name="key">The encryption key (must be 16, 24, or 32 bytes long).</param>
        /// <param name="iv">The initialization vector (must be 16 bytes long).</param>
        /// <returns>The encrypted text as a Base64-encoded string.</returns>
        public string Encrypt(string plaintext, string key, string iv)
        {
            // Convert the key, IV, and plaintext into byte arrays.
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] ivBytes = Encoding.UTF8.GetBytes(iv);
            byte[] plaintextBytes = Encoding.UTF8.GetBytes(plaintext);

            // Create an AES object for encryption.
            using (Aes objAes = Aes.Create())
            {
                objAes.Key = keyBytes;  // Set the encryption key.
                objAes.IV = ivBytes;    // Set the initialization vector.
                objAes.Padding = PaddingMode.PKCS7; // Use PKCS7 padding.

                // Create an encryptor object.
                using (ICryptoTransform objEncryptor = objAes.CreateEncryptor(objAes.Key, objAes.IV))
                {
                    // Perform encryption and return the result as a Base64 string.
                    byte[] encryptedBytes = PerformCryptography(plaintextBytes, objEncryptor);
                    return Convert.ToBase64String(encryptedBytes);
                }
            }
        }

        /// <summary>
        /// Decrypts the given ciphertext using AES decryption with the specified key and IV.
        /// </summary>
        /// <param name="ciphertext">The ciphertext to decrypt (Base64-encoded).</param>
        /// <param name="key">The decryption key (must be 16, 24, or 32 bytes long).</param>
        /// <param name="iv">The initialization vector (must be 16 bytes long).</param>
        /// <returns>The decrypted plaintext as a string.</returns>
        public string Decrypt(string ciphertext, string key, string iv)
        {
            // Convert the key, IV, and ciphertext into byte arrays.
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] ivBytes = Encoding.UTF8.GetBytes(iv);
            byte[] ciphertextBytes = Convert.FromBase64String(ciphertext);

            // Create an AES object for decryption.
            using (Aes objAes = Aes.Create())
            {
                objAes.Key = keyBytes;  // Set the decryption key.
                objAes.IV = ivBytes;    // Set the initialization vector.
                objAes.Padding = PaddingMode.PKCS7; // Use PKCS7 padding.

                // Create a decryptor object.
                using (ICryptoTransform objDecryptor = objAes.CreateDecryptor(objAes.Key, objAes.IV))
                {
                    // Perform decryption and return the result as a UTF-8 string.
                    byte[] decryptedBytes = PerformCryptography(ciphertextBytes, objDecryptor);
                    return Encoding.UTF8.GetString(decryptedBytes);
                }
            }
        }

        /// <summary>
        /// Performs encryption or decryption using the provided ICryptoTransform.
        /// </summary>
        /// <param name="data">The input data to encrypt or decrypt.</param>
        /// <param name="transform">The ICryptoTransform object for encryption or decryption.</param>
        /// <returns>The resulting byte array after the cryptographic operation.</returns>
        private static byte[] PerformCryptography(byte[] data, ICryptoTransform transform)
        {
            // Use a memory stream to process the cryptographic transformation.
            using (MemoryStream objMemoryStream = new MemoryStream())
            using (CryptoStream objCryptoStream = new CryptoStream(objMemoryStream, transform, CryptoStreamMode.Write))
            {
                // Write the data to the crypto stream.
                objCryptoStream.Write(data, 0, data.Length);
                objCryptoStream.FlushFinalBlock(); // Finalize the cryptographic operation.

                // Return the transformed data as a byte array.
                return objMemoryStream.ToArray();
            }
        }
    }
}
