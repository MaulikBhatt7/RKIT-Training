using System;
using System.Security.Cryptography;
using System.Text;

namespace SecurityAndCryptography
{
    /// <summary>
    /// A class that demonstrates SHA-256 hashing.
    /// </summary>
    public class SHA256Example
    {
        /// <summary>
        /// Computes the SHA-256 hash of the provided data.
        /// </summary>
        /// <param name="data">The data to hash.</param>
        /// <returns>The computed hash as a Base64-encoded string.</returns>
        public string ComputeHash(string data)
        {
            // Create a new instance of SHA256.
            using (SHA256 objSHA256 = SHA256.Create())
            {
                // Convert the input data into a byte array using UTF-8 encoding.
                byte[] objDataBytes = Encoding.UTF8.GetBytes(data);

                // Compute the hash for the byte array.
                byte[] objHashBytes = objSHA256.ComputeHash(objDataBytes);

                // Return the hash as a Base64-encoded string.
                return Convert.ToBase64String(objHashBytes);
            }
        }
    }
}
