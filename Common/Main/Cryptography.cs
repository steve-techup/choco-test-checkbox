using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.Win32;

namespace Caretag_Class.Caretag_Common
{
    public class Cryptography
    {
        public static string Encrypt(string plainText)
        {
            var initVectorBytes = Encoding.ASCII.GetBytes(Function_Module.initVector);
            var saltValueBytes = Encoding.ASCII.GetBytes(Function_Module.saltValue);
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            // Dim password As New PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations)
            var password = new Rfc2898DeriveBytes(Function_Module.passPhrase, saltValueBytes, Function_Module.passwordIterations);
            var keyBytes = password.GetBytes(Function_Module.keySize / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC };
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

        public static string Decrypt(string cipherText)
        {
            var initVectorBytes = Encoding.ASCII.GetBytes(Function_Module.initVector);
            var saltValueBytes = Encoding.ASCII.GetBytes(Function_Module.saltValue);

            // Convert our ciphertext into a byte array.
            var cipherTextBytes = Convert.FromBase64String(cipherText);
            // First, we must create a password, from which the key will be derived. This password will be generated from the specified 58.  
            // passphrase and salt value. The password will be created using the specified hash algorithm. Password creation can be done in60.
            // several iterations

            // Dim password As New PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations)
            var password = new Rfc2898DeriveBytes(Function_Module.passPhrase, saltValueBytes, Function_Module.passwordIterations);


            // Use the password to generate pseudo-random bytes for the encryption key. Specify the size of the key in bytes (instead of bits).
            var keyBytes = password.GetBytes(Function_Module.keySize / 8);
            // Create uninitialized Rijndael encryption object.It is reasonable to set encryption mode to Cipher Block Chaining (CBC). Use default options for other symmetric key parameters

            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC };
            // Generate decryptor from the existing key bytes and initialization vector. Key size will be defined based on the number of the key bytes  
            var decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
            // Define memory stream which will be used to hold encrypted data.
            var memoryStream = new MemoryStream(cipherTextBytes);
            // Define cryptographic stream (always use Read mode for encryption).
            var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            // Since at this point we don't know what the size of decrypted data will be, allocate the buffer long enough to hold ciphertext .
            // plaintext is never longer than ciphertext.    
            var plainTextBytes = new byte[cipherTextBytes.Length];
            // Start decrypting.        

            long decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);

            // Close both streams    
            memoryStream.Close();
            cryptoStream.Close();
            // Convert decrypted data into a string.  Let us assume that the original plaintext string was UTF8-encoded.
            string plainText = Encoding.UTF8.GetString(plainTextBytes, 0, (int)decryptedByteCount);
            // Return decrypted string.
            return plainText;
        }

        public static bool Check_Login_Verif(ref bool Use_ActiveD, ref bool Use_Login)
        {
            bool Check_Login_VerifRet = default;
            Check_Login_VerifRet = true;
            try
            {
                string To_Check = SQLUtil.LookUpInDataBase("SystemInfo", " ID > 0", "Login_Verification");
                if (To_Check.Length < 11)
                {
                    bool argUse_ActiveD = true;
                    bool argUse_Login = false;
                    Do_Update_Verification(ref argUse_ActiveD, ref argUse_Login);
                    To_Check = SQLUtil.LookUpInDataBase("SystemInfo", " ID > 0", "Login_Verification");
                }

                // Dim Part_1 As String = To_Check.Substring(0, 2)
                // Dim Using_Login As String = To_Check.Substring(2, 1)
                // Dim Part_2 As String = To_Check.Substring(3, 2)
                string Check_Ciffer = To_Check.Substring(5, 1);
                // Dim Part_3 As String = To_Check.Substring(6, 3)
                string Using_ActiveD = To_Check.Substring(9, 1);
                string Part_4 = To_Check.Substring(10, 1);
                if (!((Check_Ciffer ?? "") == (Part_4 ?? "")))
                {
                    throw new Exception("The Login Verification is Altered ! ");
                }

                // Active Directory is primary
                string To_Check_Active = SQLUtil.LookUpInDataBase("SystemInfo", " ID > 0", "Use_ActiveDirectory");
                if (To_Check_Active == "True")
                {
                    if (!(Using_ActiveD == "1"))
                    {
                        Use_ActiveD = true;
                        Use_Login = false;
                        if (!Do_Update_Verification(ref Use_ActiveD, ref Use_Login))
                        {
                            throw new Exception("Write  Verification Failed TRUE !");
                        }

                        return Check_Login_VerifRet;
                    }
                }
                else if (!(Using_ActiveD == "0"))
                {
                    Use_ActiveD = false;
                    Use_Login = true;
                    if (!Do_Update_Verification(ref Use_ActiveD, ref Use_Login))
                    {
                        throw new Exception("Write  Verification Failed FALSE !");
                    }

                    return Check_Login_VerifRet;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(" Issue .... {0}{1}", Constants.vbCrLf, ex.Message), "Check_Login_Verif", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Check_Login_VerifRet = false;
            }

            return Check_Login_VerifRet;
        }

        public static bool Do_Update_Verification(ref bool Use_ActiveD, ref bool Use_Login)
        {
            bool Do_Update_VerificationRet = default;
            try
            {
                // The Format Part_1= two number -- Use_Login -- Part2=two numbers -- Check Ciffer -- Part3=Three Numbers -- Use ActiveD -- Part4=One Numbers

                string Part_1 = GetRandom(10, 99).ToString();
                string Part_2 = GetRandom(10, 99).ToString();
                string Part_3 = GetRandom(100, 999).ToString();
                string Part_4 = GetRandom(1, 9).ToString();
                string Using_Login = Convert.ToInt32(Use_Login).ToString();
                string Using_ActiveD = Convert.ToInt32(Use_ActiveD).ToString();
                string Check_Ciffer = Part_4;
                string Final_Number = Part_1 + Using_Login + Part_2 + Check_Ciffer + Part_3 + Using_ActiveD + Part_4;
                SQLUtil.UpdateToDatabase("SystemInfo", " Login_Verification ='" + Final_Number + "' WHERE ID > 0");
                SQLUtil.UpdateToDatabase("SystemInfo", " Use_Login ='" + Use_Login + "' WHERE ID > 0");
                SQLUtil.UpdateToDatabase("SystemInfo", " Use_ActiveDirectory ='" + Use_ActiveD + "' WHERE ID > 0");
                Do_Update_VerificationRet = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(" Issue .... {0}{1}", Constants.vbCrLf, ex.Message), "Do_Update_Verification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Do_Update_VerificationRet = false;
            }

            return Do_Update_VerificationRet;
        }

        private static readonly Random Generator = new();
        // Making Generator static, we preserve the same instance i.e., do not create new instances with the same seed over and over between calls
        public static int GetRandom(int Min, int Max)
        {
            return Generator.Next(Min, Max);
        }
    }
}