using BouncyCastleCryptography.AsymmetricEncryption;
using Org.BouncyCastle.Crypto;


namespace BouncyCastleCryptographyTests;

[TestClass]
public class AsymmetricEncryptionUnitTests
{
    [TestMethod]
    public void GivenSecretData_WhenRsaEncrypting_ThenDataIsDecrypted()
    {
        string input = "Hello, Bouncy Castle!";

        var keyPair = RsaEncryptor.GenerateRsaKeyPair();

        var encryptedBytes = RsaEncryptor.RsaEncrypt(input, keyPair.Public);

        string decryptedString = RsaEncryptor.RsaDecrypt(encryptedBytes, keyPair.Private);

        Assert.IsNotNull(encryptedBytes);
        Assert.AreEqual(input, decryptedString);
    }

    [TestMethod]
    public void GivenSecretData_WhenRsaEncrypting_ThenDataSignatureISProducedAndCanBeVerified()
    {
        var input = "Hello, Bouncy Castle!";

        var keyPair = DsaEncryptor.GenerateDsaKeyPair();

        var signature = DsaEncryptor.DsaSign(input, keyPair.Private);

        bool isSignatureValid = DsaEncryptor.DsaVerify(input, signature, keyPair.Public);

        Assert.IsNotNull(signature);
        Assert.IsTrue(isSignatureValid);
    }
}
