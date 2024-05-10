using BouncyCastleCryptography.AsymmetricEncryption;
using Org.BouncyCastle.Crypto;


namespace BouncyCastleCryptographyTests
{
    [TestClass]
    public class AsymmetricEncryptionUnitTests
    {
        [TestMethod]
        public void GivenSecretData_WhenRsaEncrypting_ThenDataSignatureIsProduced()
        {
            string input = "Hello, Bouncy Castle!";

            AsymmetricCipherKeyPair keyPair = RsaEncryptor.GenerateRsaKeyPair();

            byte[] encryptedBytes = RsaEncryptor.RsaEncrypt(input, keyPair.Public);

            string decryptedString = RsaEncryptor.RsaDecrypt(encryptedBytes, keyPair.Private);

            Console.WriteLine("Decrypted data: " + decryptedString);

            Assert.IsNotNull(encryptedBytes);

            Assert.AreEqual(input, decryptedString);
        }

        [TestMethod]
        public void GivenSecretData_WhenRsaEncrypting_ThenDataSignatureCanBeVerified()
        {
            string input = "Hello, Bouncy Castle!";

            AsymmetricCipherKeyPair keyPair = DsaEncryptor.GenerateDsaKeyPair();

            byte[] signature = DsaEncryptor.DsaSign(input, keyPair.Private);

            bool isSignatureValid = DsaEncryptor.DsaVerify(input, signature, keyPair.Public);

            Console.WriteLine("Signature verification result: " + isSignatureValid);

            Assert.IsNotNull(signature);
            Assert.IsTrue(isSignatureValid);
        }
    }
}
