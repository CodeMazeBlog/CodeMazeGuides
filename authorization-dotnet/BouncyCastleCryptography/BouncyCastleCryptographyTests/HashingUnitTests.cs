using BouncyCastleCryptography.Hashing;
using System.Collections;

namespace BouncyCastleCryptographyTests
{
    [TestClass]
    public class HashingUnitTests
    {
        [TestMethod]
        public void GivenSecretData_WhenMd5IsUsed_ThenSecretIsHashed()
        {
            var secretValue = "This is my pasword! Dont read me!";

            var hash = Md5Hasher.Md5Hash(secretValue);

            Assert.IsNotNull(hash);
        }

        [TestMethod]
        public void GivenSecretData_WhenMd5HashingMultipleTimes_ThenResultIsDeterministic()
        {
            var secretValue = "This is my pasword! Dont read me!";

            var hash = Md5Hasher.Md5Hash(secretValue);

            var hash2 = Md5Hasher.Md5Hash(secretValue);

            CollectionAssert.AreEqual(hash, hash2);
        }

        [TestMethod]
        public void GivenSecretData_WhenShaIsUsed_ThenSecretIsHashed()
        {
            var secretValue = "This is my pasword! Dont read me!";

            var hash = ShaHasher.ShaHash(secretValue);

            Assert.IsNotNull(hash);
        }

        [TestMethod]
        public void GivenSecretData_WhenShaHashingMultipleTimes_ThenResultIsDeterministic()
        {
            var secretValue = "This is my pasword! Dont read me!";

            var hash = ShaHasher.ShaHash(secretValue);

            var hash2 = ShaHasher.ShaHash(secretValue);

            CollectionAssert.AreEqual(hash, hash2);
        }
    }
}