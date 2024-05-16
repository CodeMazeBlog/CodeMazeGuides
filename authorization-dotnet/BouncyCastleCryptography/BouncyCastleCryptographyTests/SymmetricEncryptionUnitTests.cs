using BouncyCastleCryptography.SymmetricEncryption;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;

namespace BouncyCastleCryptographyTests;

[TestClass]
public class SymmetricEncryptionUnitTests
{
    [TestMethod]
    public void GivenSecretData_WhenAesEncrypting_ThenDataIsEncrypted()
    {
        var input = "Hello, Bouncy Castle!";

        var encryptedData = AesEncryptor.AesEncrypt(input, out byte[] iv, out byte[] key);

        var encryptedString = Convert.ToBase64String(encryptedData);

        Assert.IsNotNull(encryptedData);
        Assert.AreNotEqual(input, encryptedString);
    }

    [TestMethod]
    public void GivenSecretData_WhenAesEncrypting_ThenDataCanBeDecrypted()
    {
        var input = "Hello, Bouncy Castle!";

        var encryptedData = AesEncryptor.AesEncrypt(input, out byte[] iv, out byte[] key);

        Assert.IsNotNull(encryptedData);

        var myDecryptedStr = AesEncryptor.AesDecrypt(key, iv, encryptedData);

        Assert.IsNotNull(myDecryptedStr);
        Assert.AreEqual(input, myDecryptedStr);
    }

    [TestMethod]
    public void GivenSecretData_WhenTripleDesEncrypting_ThenDataIsEncrypted()
    {
        var input = "Hello, Bouncy Castle!";

        var encryptedBytes = TripleDesEncryptor.TripleDesEncrypt(input, out byte[] iv, out byte[] key);

        var encryptedString = Convert.ToBase64String(encryptedBytes);

        Assert.IsNotNull(encryptedBytes);
        Assert.AreNotEqual(input, encryptedString);
    }

    [TestMethod]
    public void GivenSecretData_WhenTripleDesEncrypting_ThenDataCanBeDecrypted()
    {
        var input = "Hello, Bouncy Castle!";

        var encryptedBytes = TripleDesEncryptor.TripleDesEncrypt(input, out byte[] iv, out byte[] key);

        Assert.IsNotNull(encryptedBytes);

        var myDecryptedStr = TripleDesEncryptor.TripleDesDecrypt(key, iv, encryptedBytes);

        Assert.IsNotNull(myDecryptedStr);
        Assert.AreEqual(input, myDecryptedStr);
    }
}