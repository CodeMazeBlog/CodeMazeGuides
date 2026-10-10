using BouncyCastleCryptography.Hashing;

namespace BouncyCastleCryptographyTests;

[TestClass]
public class HashingUnitTests
{
    [TestMethod]
    public void GivenSecretData_WhenMd5IsUsed_ThenSecretIsHashed()
    {
        var secretValue = "This is my password! Dont read me!";

        var hash = Md5Hasher.Md5Hash(secretValue);

        Assert.IsNotNull(hash);
    }

    [TestMethod]
    public void GivenSecretData_WhenMd5HashingMultipleTimes_ThenResultIsDeterministic()
    {
        var secretValue = "This is my password! Dont read me!";

        var hash = Md5Hasher.Md5Hash(secretValue);

        var hash2 = Md5Hasher.Md5Hash(secretValue);

        CollectionAssert.AreEqual(hash, hash2);
    }

    [TestMethod]
    public void GivenSecretData_WhenShaIsUsed_ThenSecretIsHashed()
    {
        var secretValue = "This is my password! Dont read me!";

        var hash = ShaHasher.ShaHash(secretValue);

        Assert.IsNotNull(hash);
    }

    [TestMethod]
    public void GivenSecretData_WhenShaHashingMultipleTimes_ThenResultIsDeterministic()
    {
        var secretValue = "This is my password! Dont read me!";

        var hash = ShaHasher.ShaHash(secretValue);

        var hash2 = ShaHasher.ShaHash(secretValue);

        CollectionAssert.AreEqual(hash, hash2);
    }

    [TestMethod]
    public void GivenSecretData_WhenMd5IsUsed_ThenHashMatchesKnownValue()
    {
        var secretValue = "This is my password! Dont read me!";

        var hash = Md5Hasher.Md5Hash(secretValue);

        Assert.AreEqual("l5aMGrOOPOxm6i6cRK/sqA==", Convert.ToBase64String(hash));
    }

    [TestMethod]
    public void GivenSecretData_WhenShaIsUsed_ThenHashMatchesKnownValue()
    {
        var secretValue = "This is my password! Dont read me!";

        var hash = ShaHasher.ShaHash(secretValue);

        Assert.AreEqual("SSNYFZG3vQSGtXqZVaSZry4QBm4uueLwegd/gd6H8ns=", Convert.ToBase64String(hash));
    }
}