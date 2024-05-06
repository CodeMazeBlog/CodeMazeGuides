using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BouncyCastleCryptography.SymmetricEncryption
{
    public static class AesEncrypter
    {
        public static string AesEncrypt(string input, out byte[] ivBytes, out byte[] keyBytes, out byte[] encryptedBytes, out IBufferedCipher cipher)
        {
            // Convert the input string to bytes
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);

            // Generate a random 128-bit key
            keyBytes = new byte[16];
            SecureRandom random = new SecureRandom();
            random.NextBytes(keyBytes);

            // Generate a random 128-bit IV (initialization vector)
            ivBytes = new byte[16];
            random.NextBytes(ivBytes);

            // Create AES cipher with CBC mode
            cipher = CipherUtilities.GetCipher("AES/CBC/PKCS7Padding");

            // Initialize the cipher with the key and IV
            cipher.Init(true, new ParametersWithIV(new KeyParameter(keyBytes), ivBytes));

            // Encrypt the input data
            encryptedBytes = cipher.DoFinal(inputBytes);

            // Convert the encrypted bytes to a Base64 string for easier display
            string encryptedBase64 = Convert.ToBase64String(encryptedBytes);

            // Print the encrypted data
            Console.WriteLine("Encrypted data: " + encryptedBase64);

            return encryptedBase64;
        }

        public static string AesDecrypt(IBufferedCipher cipher, byte[] key, byte[] iv, byte[] encryptedBytes)
        {
            // Initialize the cipher for decryption
            cipher.Init(false, new ParametersWithIV(new KeyParameter(key), iv));

            // Decrypt the encrypted data
            byte[] decryptedBytes = cipher.DoFinal(encryptedBytes);

            // Convert the decrypted bytes back to a string
            string decryptedString = System.Text.Encoding.UTF8.GetString(decryptedBytes);

            // Print the decrypted data
            Console.WriteLine("Decrypted data: " + decryptedString);

            return decryptedString;
        }
    }
}
