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

            var encryptedData = AesEncryptor.AesEncrypt(input, out byte[] iv, out byte[] key);

            string encryptedString = Convert.ToBase64String(encryptedData);

            Assert.IsNotNull(encryptedData);
            Assert.AreNotEqual(input, encryptedString);
        }

        [TestMethod]
        public void GivenSecretData_WhenAesEncrypting_ThenDataCanBeDecrypted()
        {
            string input = "Hello, Bouncy Castle!";

            var encryptedData = AesEncryptor.AesEncrypt(input, out byte[] iv, out byte[] key);

            Assert.IsNotNull(encryptedData);

            var myDecryptedStr = AesEncryptor.AesDecrypt(key, iv, encryptedData);

            Assert.IsNotNull(myDecryptedStr);
            Assert.AreEqual(input, myDecryptedStr);
        }

        [TestMethod]
        public void GivenSecretData_WhenTripleDesEncrypting_ThenDataIsEncrypted()
        {
            string input = "Hello, Bouncy Castle!";

            var myStr = TripleDesEncryptor.TripleDesEncrypt(input, out byte[] iv, out byte[] key);

            Assert.IsNotNull(myStr);
        }

        [TestMethod]
        public void GivenSecretData_WhenTripleDesEncrypting_ThenDataCanBeDecrypted()
        {
            string input = "Hello, Bouncy Castle!";

            var encryptedBytes = TripleDesEncryptor.TripleDesEncrypt(input, out byte[] iv, out byte[] key);

            Assert.IsNotNull(encryptedBytes);

            IBufferedCipher cipher = CipherUtilities.GetCipher("DESede/CBC/PKCS7Padding");

            var myDecryptedStr = TripleDesEncryptor.TripleDesDecrypt(key, iv, encryptedBytes);

            Assert.IsNotNull(myDecryptedStr);
            Assert.AreEqual(input, myDecryptedStr);
        }
    }
}
