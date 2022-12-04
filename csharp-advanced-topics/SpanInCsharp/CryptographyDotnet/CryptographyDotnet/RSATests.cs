using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CryptographyDotnet
{
    [TestClass]
    public class RSATests
    {
        [TestMethod]
        public void WhenUsingRSA_ThenDataIsEncrypted()
        {
            var dataStr = "This is corporate research! Dont read me!";
            var data = Encoding.ASCII.GetBytes(dataStr);

            GenerateKeys(2048, out var publicKey, out var privateKey);

            var encryptedData = Encrypt(data, publicKey);

            Assert.AreNotEqual(data, encryptedData);
        }

        [TestMethod]
        public void GivenSameInput_WhenUsingRSA_ThenDataIsEncryptedDifferentlyEachTime()
        {
            var dataStr = "This is corporate research! Dont read me!";
            var data = Encoding.ASCII.GetBytes(dataStr);

            GenerateKeys(2048, out var publicKey, out var privateKey);

            var encryptedData = Encrypt(data, publicKey);

            GenerateKeys(2048, out var publicKey2, out var privateKey2);

            var encryptedData2 = Encrypt(data, publicKey2);

            Assert.AreNotEqual(encryptedData, encryptedData2);
        }

        [TestMethod]
        public void GivenSameInputAndSameKey_WhenUsingRSA_ThenDataIsEncryptedDifferentlyEachTime()
        {
            var dataStr = "This is corporate research! Dont read me!";
            var data = Encoding.ASCII.GetBytes(dataStr);

            GenerateKeys(2048, out var publicKey, out var privateKey);

            var encryptedData = Encrypt(data, publicKey);

            var encryptedData2 = Encrypt(data, publicKey);

            Assert.AreNotEqual(encryptedData, encryptedData2);
        }

        [TestMethod]
        public void WhenEncryptingWithRSA_ThenDataIsRecoverable()
        {
            var dataStr = "This is corporate research! Dont read me!";
            var data = Encoding.ASCII.GetBytes(dataStr);

            GenerateKeys(2048, out var publicKey, out var privateKey);

            var encryptedData = Encrypt(data, publicKey);
            var decryptedData = Decrypt(encryptedData, privateKey);

            CollectionAssert.AreEqual(data, decryptedData);
            Assert.AreEqual(dataStr, Encoding.ASCII.GetString(decryptedData));
        }

        [TestMethod]
        public void GivenKeySizeTooSmall_WhenCreatingRSAKeys_ThenExceptionIsThrown()
        {
            var dataStr = "This is corporate research! Dont read me!";
            var data = Encoding.ASCII.GetBytes(dataStr);

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