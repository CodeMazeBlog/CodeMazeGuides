using BouncyCastleCryptography.AsymmetricEncryption;
using Org.BouncyCastle.Crypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BouncyCastleCryptographyTests
{
    public class AsymmetricEncryptionUnitTests
    {
        [TestMethod]
        public void rsaEncrypt()
        {
            string input = "Hello, Bouncy Castle!";

            // Generate RSA key pair
            AsymmetricCipherKeyPair keyPair = RsaEncrypter.GenerateRsaKeyPair();

            // Encrypt the input data using the public key
            byte[] encryptedBytes = RsaEncrypter.RsaEncrypt(input, keyPair.Public);

            // Decrypt the encrypted data using the private key
            string decryptedString = RsaEncrypter.RsaDecrypt(encryptedBytes, keyPair.Private);

            // Print the decrypted data
            Console.WriteLine("Decrypted data: " + decryptedString);

            Assert.IsNotNull(encryptedBytes);

            Assert.AreEqual(input, decryptedString);
        }

        [TestMethod]
        public void DsaSign()
        {
            // Input data to be signed
            string input = "Hello, Bouncy Castle!";

            // Generate DSA key pair
            AsymmetricCipherKeyPair keyPair = DsaEncrypter.GenerateDsaKeyPair();

            // Sign the message using the private key
            byte[] signature = DsaEncrypter.DsaSign(input, keyPair.Private);

            // Verify the signature using the public key
            bool isSignatureValid = DsaEncrypter.DsaVerify(input, signature, keyPair.Public);

            // Print the result
            Console.WriteLine("Signature verification result: " + isSignatureValid);

            Assert.IsNotNull(signature);
            Assert.IsTrue(isSignatureValid);
        }
    }
}
