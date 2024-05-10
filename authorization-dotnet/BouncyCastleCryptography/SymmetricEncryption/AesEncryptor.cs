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
    public static class AesEncryptor
    {
        public static byte[] AesEncrypt(string input, out byte[] iv, out byte[] key)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);

            // Generate a random 128-bit key
            key = new byte[16];
            SecureRandom random = new SecureRandom();
            random.NextBytes(key);

            // Generate a random 128-bit initialization vector (IV)
            iv = new byte[16];
            random.NextBytes(iv);

            // Create AES cipher with CBC mode
            var cipher = CipherUtilities.GetCipher("AES/CBC/PKCS7Padding");

            cipher.Init(true, new ParametersWithIV(new KeyParameter(key), iv));

            return cipher.DoFinal(inputBytes);
        }

        public static string AesDecrypt(byte[] key, byte[] iv, byte[] encryptedBytes)
        {
            var cipher = CipherUtilities.GetCipher("AES/CBC/PKCS7Padding");
            cipher.Init(false, new ParametersWithIV(new KeyParameter(key), iv));

            // Decrypt the encrypted data
            byte[] decryptedBytes = cipher.DoFinal(encryptedBytes);

            string decryptedString = Encoding.UTF8.GetString(decryptedBytes);

            return decryptedString;
        }
    }
}
