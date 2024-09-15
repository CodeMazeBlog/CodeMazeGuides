using BouncyCastleCryptography.SymmetricEncryption;

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
    public void GivenSecretData_WhenBlowfishEncrypting_ThenDataIsEncrypted()
    {
        var input = "Hello, Bouncy Castle!";
        var password = "mysecretpassword";

        var encryptedBytes = BlowfishEncryptor.BlowfishEncrypt(input, password, out byte[] iv);

        var encryptedString = Convert.ToBase64String(encryptedBytes);

        Assert.IsNotNull(encryptedBytes);
        Assert.AreNotEqual(input, encryptedString);
    }

    [TestMethod]
    public void GivenSecretData_WhenBlowfishEncrypting_ThenDataCanBeDecrypted()
    {
        var input = "Hello, Bouncy Castle!";
        var password = "mysecretpassword";

        var encryptedBytes = BlowfishEncryptor.BlowfishEncrypt(input, password, out byte[] iv);

        var myDecryptedStr = BlowfishEncryptor.BlowfishDecrypt(encryptedBytes, password, iv);

        Assert.IsNotNull(myDecryptedStr);
        Assert.AreEqual(input, myDecryptedStr);
    }
}