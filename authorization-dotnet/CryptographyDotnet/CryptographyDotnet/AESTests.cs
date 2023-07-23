using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CryptographyDotnet
{
    [TestClass]
    public class AESTests
    {
        public string dataStr = "This is corporate research! Dont read me!";
        public byte[] data = { };

        [TestInitialize]
        public void Initilialize()
        {
            data = Encoding.UTF8.GetBytes(dataStr);
        }

        [TestMethod]
        public void WhenUsingAES_ThenDataIsEncrypted()
        {
            var key = GenerateAESKey();

            var encryptedData = Encrypt(data, key, out var iv);

            Assert.AreNotEqual(data, encryptedData);
        }

        [TestMethod]
        public void GivenSameInput_WhenUsingAES_ThenDataIsEncryptedDifferentlyEachTime()
        {
            var key = GenerateAESKey();

            var encryptedData = Encrypt(data, key, out var iv);

            var dataStr2 = "This is corporate research! Dont read me!";
            var data2 = Encoding.UTF8.GetBytes(dataStr2);
            var key2 = GenerateAESKey();

            var encryptedData2 = Encrypt(data2, key2, out var iv2);

            Assert.AreNotEqual(encryptedData, encryptedData2);
        }

        [TestMethod]
        public void GivenSameInputAndSameKey_WhenUsingAES_ThenDataIsEncryptedDifferentlyEachTime()
        {
            var key = GenerateAESKey();

            var encryptedData = Encrypt(data, key, out var iv);

            var dataStr2 = "This is corporate research! Dont read me!";
            var data2 = Encoding.UTF8.GetBytes(dataStr2);

            var encryptedData2 = Encrypt(data2, key, out var iv2);

            Assert.AreNotEqual(encryptedData, encryptedData2);
        }

        [TestMethod]
        public void WhenEncryptingWithAES_ThenDataIsRecoverable()
        {
            var key = GenerateAESKey();

            var encryptedData = Encrypt(data, key, out var iv);
            var decryptedData = Decrypt(encryptedData, key, iv);


            CollectionAssert.AreEqual(data, decryptedData);
            Assert.AreEqual(dataStr, Encoding.UTF8.GetString(decryptedData));
        }

        [TestMethod]
        public void GivenWrongKeySize_WhenEncryptingWithAES_ThenExceptionIsThrown()
        {
            Assert.ThrowsException<CryptographicException>(() => {
                Encrypt(data, new byte[] { 1, 2, 3 }, out var iv);
            });
        }

        public static byte[] Encrypt(byte[] data, byte[] key, out byte[] iv)
        {
            using (var aes = Aes.Create())
            {
                aes.Mode = CipherMode.CBC; // better security
                aes.Key = key;
                aes.GenerateIV(); // IV = Initialization Vector

                using (var encryptor = aes.CreateEncryptor())
                {
                    iv = aes.IV;
                    return encryptor.TransformFinalBlock(data, 0, data.Length);
                }
            }
        }

        public static byte[] Decrypt(byte[] data, byte[] key, byte[] iv)
        {
            using (var aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;
                aes.Mode = CipherMode.CBC; // same as for encryption

                using (var decryptor = aes.CreateDecryptor())
                {
                    return decryptor.TransformFinalBlock(data, 0, data.Length);
                }
            }
        }

        public static byte[] GenerateAESKey()
        {
            var rnd = RandomNumberGenerator.Create();
            var b = new byte[16];
            rnd.GetNonZeroBytes(b);

            return b;
        }
    }
}
