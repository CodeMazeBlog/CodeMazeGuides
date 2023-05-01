using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Security.Cryptography;
using System.Text;

namespace CryptographyDotnet
{
    [TestClass]
    public class RSATests
    {
        public string dataStr = "This is corporate research! Dont read me!";
        public byte[] data = { };

        [TestInitialize]
        public void Initilialize()
        {
            data = Encoding.UTF8.GetBytes(dataStr);
        }

        [TestMethod]
        public void WhenUsingRSA_ThenDataIsEncrypted()
        {
            var keyLength = 2048;

            GenerateKeys(keyLength, out var publicKey, out var privateKey);

            var encryptedData = Encrypt(data, publicKey);

            var hashAsString = Convert.ToHexString(encryptedData);

            Assert.AreNotEqual(data, encryptedData);
        }

        [TestMethod]
        public void GivenSameInput_WhenUsingRSA_ThenDataIsEncryptedDifferentlyEachTime()
        {
            var keyLength = 2048;

            GenerateKeys(keyLength, out var publicKey, out var privateKey);

            var encryptedData = Encrypt(data, publicKey);

            GenerateKeys(keyLength, out var publicKey2, out var privateKey2);

            var encryptedData2 = Encrypt(data, publicKey2);

            Assert.AreNotEqual(encryptedData, encryptedData2);
        }

        [TestMethod]
        public void GivenSameInputAndSameKey_WhenUsingRSA_ThenDataIsEncryptedDifferentlyEachTime()
        {
            var keyLength = 2048;

            GenerateKeys(keyLength, out var publicKey, out var privateKey);

            var encryptedData = Encrypt(data, publicKey);

            var encryptedData2 = Encrypt(data, publicKey);

            Assert.AreNotEqual(encryptedData, encryptedData2);
        }

        [TestMethod]
        public void WhenEncryptingWithRSA_ThenDataIsRecoverable()
        {
            var keyLength = 2048;

            GenerateKeys(keyLength, out var publicKey, out var privateKey);

            var encryptedData = Encrypt(data, publicKey);
            var decryptedData = Decrypt(encryptedData, privateKey);

            CollectionAssert.AreEqual(data, decryptedData);
            Assert.AreEqual(dataStr, Encoding.ASCII.GetString(decryptedData));
        }

        [TestMethod]
        public void GivenKeySizeTooSmall_WhenCreatingRSAKeys_ThenExceptionIsThrown()
        {
            Assert.ThrowsException<CryptographicException>(() => {
                GenerateKeys(128, out var publicKey, out var privateKey);
            });
        }

        public void GenerateKeys(int keyLength, out RSAParameters publicKey, out RSAParameters privateKey)
        {
            using (var rsa = RSA.Create())
            {
                rsa.KeySize = keyLength;
                publicKey = rsa.ExportParameters(includePrivateParameters: false);
                privateKey = rsa.ExportParameters(includePrivateParameters: true);
            }
        }

        public byte[] Encrypt(byte[] data, RSAParameters publicKey)
        {
            using (var rsa = RSA.Create())
            {
                rsa.ImportParameters(publicKey);

                var result = rsa.Encrypt(data, RSAEncryptionPadding.OaepSHA256);
                return result;
            }
        }

        public byte[] Decrypt(byte[] data, RSAParameters privateKey)
        {
            using (var rsa = RSA.Create())
            {
                rsa.ImportParameters(privateKey);
                return rsa.Decrypt(data, RSAEncryptionPadding.OaepSHA256);
            }
        }
    } 
}