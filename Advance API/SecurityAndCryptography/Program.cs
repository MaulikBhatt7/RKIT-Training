using System;
using System.Security.Cryptography;

namespace SecurityAndCryptography
{
    /// <summary>
    /// A class that demonstrates various encryption and hashing algorithms.
    /// </summary>
    public class SecurityAndCryptography
    {
        public static void Main(string[] args)
        {
            // Sample plaintext, key, and IV for encryption algorithms
            string objPlaintext = "Hello From MB!";
            string objKey = "9685743217896541"; // 16 characters for 128-bit key
            string objIV = "7865418965324789";  // 16 characters for IV

            // Displaying the options for the user
            Console.WriteLine("1 - AES Example");
            Console.WriteLine("2 - Rijndael Example");
            Console.WriteLine("3 - DES Example");
            Console.WriteLine("4 - RSA Example");
            Console.WriteLine("5 - SHA256 Example");

            // Read the user's choice
            int objChoice = Convert.ToInt32(Console.ReadLine());

            // Switch based on user choice
            switch (objChoice)
            {
                case 1:
                    // AES Encryption and Decryption
                    AESExample objAESExample = new AESExample();
                    string objEncryptedByAES = objAESExample.Encrypt(objPlaintext, objKey, objIV);
                    Console.WriteLine($"Encrypted: {objEncryptedByAES}");
                    string objDecryptedByAES = objAESExample.Decrypt(objEncryptedByAES, objKey, objIV);
                    Console.WriteLine($"Decrypted: {objDecryptedByAES}");
                    break;

                case 2:
                    // Rijndael Encryption and Decryption
                    RijndaelExample objRijndaelExample = new RijndaelExample();
                    string objEncryptedByRijndael = objRijndaelExample.Encrypt(objPlaintext, objKey, objIV);
                    Console.WriteLine($"Encrypted: {objEncryptedByRijndael}");
                    string objDecryptedByRijndael = objRijndaelExample.Decrypt(objEncryptedByRijndael, objKey, objIV);
                    Console.WriteLine($"Decrypted: {objDecryptedByRijndael}");
                    break;

                case 3:
                    // DES Encryption and Decryption (8-character key and IV)
                    string objKey8Char = "98745215";
                    string objIV8Char = "98745612";
                    DESExample objDESExample = new DESExample();
                    string objEncryptedByDES = objDESExample.Encrypt(objPlaintext, objKey8Char, objIV8Char);
                    Console.WriteLine($"Encrypted: {objEncryptedByDES}");
                    string objDecryptedByDES = objDESExample.Decrypt(objEncryptedByDES, objKey8Char, objIV8Char);
                    Console.WriteLine($"Decrypted: {objDecryptedByDES}");
                    break;

                case 4:
                    // RSA Encryption and Decryption (2048-bit key)
                    using (RSA objRSA = RSA.Create(2048))
                    {
                        RSAExample objRSAExample = new RSAExample();
                        // Encrypt
                        string objEncryptedByRSA = objRSAExample.Encrypt(objPlaintext, objRSA);
                        Console.WriteLine($"Encrypted: {objEncryptedByRSA}");

                        // Decrypt
                        string objDecryptedByRSA = objRSAExample.Decrypt(objEncryptedByRSA, objRSA);
                        Console.WriteLine($"Decrypted: {objDecryptedByRSA}");
                    }
                    break;

                case 5:
                    // SHA256 Hashing
                    SHA256Example objSHA256Example = new SHA256Example();
                    string objHash = objSHA256Example.ComputeHash(objPlaintext);
                    Console.WriteLine($"SHA-256 Hash: {objHash}");
                    break;

                default:
                    // Invalid choice handling
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }
    }
}
