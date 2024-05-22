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
    public class BlowfishEncryptor
    {
        public static byte[] BlowfishEncrypt(string input, string password, out byte[] iv)
        {
            var inputBytes = Encoding.UTF8.GetBytes(input);

            var random = new SecureRandom();
            iv = new byte[8]; // Blowfish uses an 8-byte (64-bit) IV
            random.NextBytes(iv);

            var cipher = CipherUtilities.GetCipher("Blowfish/CBC/PKCS7Padding");

            var keyBytes = Encoding.UTF8.GetBytes(password);
            var keyParam = new KeyParameter(keyBytes);

            cipher.Init(true, new ParametersWithIV(keyParam, iv));

            return cipher.DoFinal(inputBytes);
        }

        public static string BlowfishDecrypt(byte[] encryptedBytes, string password, byte[] iv)
        {
            var cipher = CipherUtilities.GetCipher("Blowfish/CBC/PKCS7Padding");

            var keyBytes = Encoding.UTF8.GetBytes(password);
            var keyParam = new KeyParameter(keyBytes);

            cipher.Init(false, new ParametersWithIV(keyParam, iv));

            var plainBytes = cipher.DoFinal(encryptedBytes);

            return Encoding.UTF8.GetString(plainBytes);
        }
    }
}
