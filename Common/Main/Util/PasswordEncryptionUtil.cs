//using com.caen.RFIDLibrary;

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Caretag_Class.Forms
{
    public static class PasswordEncryptionUtil
    {
        // ****************************************************************************************************************************
        public static string passPhrase = "FeivelInTheSky";
        public static string saltValue = "KnowledgeHub";
        public static int passwordIterations = 2;
        public static string initVector = "@1B2c3D4e5F6g7H8";
        public static int keySize = 256;
        // ****************************************************************************************************************************


        public static string Decrypt(string cipherText)
        {
            var initVectorBytes = Encoding.ASCII.GetBytes(initVector);
            var saltValueBytes = Encoding.ASCII.GetBytes(saltValue);

            // Convert our ciphertext into a byte array.
            var cipherTextBytes = Convert.FromBase64String(cipherText);

            // First, we must create a password, from which the key will be derived. This password will be generated from the specified 58.  
            // passphrase and salt value. The password will be created using the specified hash algorithm. Password creation can be done in60.
            // several iterations

            // Dim password As New PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations)
            var password = new Rfc2898DeriveBytes(passPhrase, saltValueBytes, passwordIterations);


            // Use the password to generate pseudo-random bytes for the encryption key. Specify the size of the key in bytes (instead of bits).
            var keyBytes = password.GetBytes(keySize / 8);
            // Create uninitialized Rijndael encryption object.It is reasonable to set encryption mode to Cipher Block Chaining (CBC). Use default options for other symmetric key parameters

            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC };
            // Generate decryptor from the existing key bytes and initialization vector. Key size will be defined based on the number of the key bytes  
            var decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
            // Define memory stream which will be used to hold encrypted data.
            var memoryStream = new MemoryStream(cipherTextBytes);
            // Define cryptographic stream (always use Read mode for encryption).
            var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            // Since at this point we don't know what the size of decrypted data will be, allocate the buffer long enough to hold cipher-text .
            // plaintext is never longer than ciphertext.    
            var plainTextBytes = new byte[cipherTextBytes.Length];
            // Start decrypting.        

            long decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);

            // Close both streams    
            memoryStream.Close();
            cryptoStream.Close();
            // Convert decrypted data into a string.  Let us assume that the original plain-text string was UTF8-encoded.
            string plainText = Encoding.UTF8.GetString(plainTextBytes, 0, (int)decryptedByteCount);
            // Return decrypted string.
            return plainText;
        }

        /// <summary>
        /// Used for encrypting passwords salted with a guid. 
        /// </summary>
        /// <param name="plaintext"></param>
        /// <param name="guid"></param>
        /// <returns></returns>
        public static string EncryptWithGuid(string plaintext, Guid guid)
        {
            return EncryptWithGuid(plaintext, guid.ToString());
        }
        
        /// <summary>
        /// Used for encrypting passwords salted with a guid. 
        /// </summary>
        /// <param name="plaintext"></param>
        /// <param name="guid"></param>
        /// <returns></returns>
        public static string EncryptWithGuid(string plaintext, string guid)
        {
            return Encrypt(plaintext.Trim() + guid);
        }

        /// <summary>
        /// Encrypts a string using salted symmetric encryption.
        /// Legacy.
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        public static string Encrypt(string plainText)
        {
            var initVectorBytes = Encoding.ASCII.GetBytes(initVector);
            var saltValueBytes = Encoding.ASCII.GetBytes(saltValue);
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            var password = new Rfc2898DeriveBytes(passPhrase, saltValueBytes, passwordIterations);
            var keyBytes = password.GetBytes(keySize / 8);
            var symmetricKey = new RijndaelManaged { Mode = CipherMode.CBC };
            var encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
            var memoryStream = new MemoryStream();
            var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
            cryptoStream.FlushFinalBlock();
            var cipherTextBytes = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            string cipherText = Convert.ToBase64String(cipherTextBytes);
            return cipherText;
        }

    }
}