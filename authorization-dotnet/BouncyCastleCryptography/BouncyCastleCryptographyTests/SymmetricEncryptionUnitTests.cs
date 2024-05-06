using BouncyCastleCryptography.SymmetricEncryption;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BouncyCastleCryptographyTests
{
    public class SymmetricEncryptionUnitTests
    {
        [TestMethod]
        public void GivenSecretData_WhenAesEncrypting_ThenDataIsEncrypted()
        {
            string input = "Hello, Bouncy Castle!";

            var encryptedData = AesEncrypter.AesEncrypt(input, out byte[] iv, out byte[] key, out byte[] encryptedBytes, out var cipher);

            Assert.IsNotNull(encryptedData);
            Assert.AreNotEqual(input, encryptedData);
        }

        [TestMethod]
        public void GivenSecretData_WhenAesEncrypting_ThenDataCanBeDecrypted()
        {
            string input = "Hello, Bouncy Castle!";

            var myStr = AesEncrypter.AesEncrypt(input, out byte[] iv, out byte[] key, out byte[] encryptedBytes, out var cipher);

            Assert.IsNotNull(myStr);

            var myDecryptedStr = AesEncrypter.AesDecrypt(cipher, key, iv, encryptedBytes);

            Assert.IsNotNull(myDecryptedStr);
            Assert.AreEqual(input, myDecryptedStr);
        }

        [TestMethod]
        public void GivenSecretData_WhenTripleDesEncrypting_ThenDataIsEncrypted()
        {
            string input = "Hello, Bouncy Castle!";

            var myStr = TripleDesEncrypter.TripleDesEncrypt(input, out byte[] iv, out byte[] key, out byte[] encryptedBytes);

            Assert.IsNotNull(myStr);
        }

        [TestMethod]
        public void GivenSecretData_WhenTripleDesEncrypting_ThenDataCanBeDecrypted()
        {
            string input = "Hello, Bouncy Castle!";

            var myStr = TripleDesEncrypter.TripleDesEncrypt(input, out byte[] iv, out byte[] key, out byte[] encryptedBytes);

            Assert.IsNotNull(myStr);

            IBufferedCipher cipher = CipherUtilities.GetCipher("DESede/CBC/PKCS7Padding");

            var myDecryptedStr = TripleDesEncrypter.TripleDesDecrypt(cipher, key, iv, encryptedBytes);

            Assert.IsNotNull(myDecryptedStr);
            Assert.AreEqual(input, myDecryptedStr);
        }
    }
}
