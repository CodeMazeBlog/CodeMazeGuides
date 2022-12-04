using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CryptographyDotnet
{
    [TestClass]
    public class SHATests
    {
        //TODO review test naming rules
        [TestMethod]
        public async Task WhenHashingSameValue_ThenHashesAreEqual()
        {
            var strStreamOne = new MemoryStream(Encoding.ASCII.GetBytes("This is my pasword! Dont read me!"));

            byte[] hashOne;
            using (var sha256 = SHA256.Create())
            {
                hashOne = await sha256.ComputeHashAsync(strStreamOne);
            }

            var strStreamTwo = new MemoryStream(Encoding.ASCII.GetBytes("This is my pasword! Dont read me!"));
            byte[] hashTwo;
            using (var sha256 = SHA256.Create())
            {
                hashTwo = await sha256.ComputeHashAsync(strStreamTwo);
            }

            CollectionAssert.AreEqual(hashOne, hashTwo);
        }

        [TestMethod]
        public async Task WhenUsingSHA256_ThenDataIsHashed()
        {
            var strStreamOne = new MemoryStream(Encoding.ASCII.GetBytes("This is my pasword! Dont read me!"));

            byte[] hashOne;
            using (var sha256 = SHA256.Create())
            {
                hashOne = await sha256.ComputeHashAsync(strStreamOne);
            }

            Assert.AreEqual(32, hashOne.Length);
            Assert.AreNotEqual("This is my pasword! Dont read me!", Encoding.ASCII.GetString(hashOne));
        }

        [TestMethod]
        public async Task WhenUsingSHA384_ThenDataIsHashed()
        {
            var strStreamOne = new MemoryStream(Encoding.ASCII.GetBytes("This is my pasword! Dont read me!"));

            byte[] hashOne;
            using (var sha256 = SHA384.Create())
            {
                hashOne = await sha256.ComputeHashAsync(strStreamOne);
            }

            Assert.AreEqual(48, hashOne.Length);
            Assert.AreNotEqual("This is my pasword! Dont read me!", Encoding.ASCII.GetString(hashOne));
        }

        [TestMethod]
        public async Task WhenUsingSHA512_ThenDataIsHashed()
        {
            var strStreamOne = new MemoryStream(Encoding.ASCII.GetBytes("This is my pasword! Dont read me!"));

            byte[] hashOne;
            using (var sha256 = SHA512.Create())
            {
                hashOne = await sha256.ComputeHashAsync(strStreamOne);
            }

            Assert.AreEqual(64, hashOne.Length);
            Assert.AreNotEqual("This is my pasword! Dont read me!", Encoding.ASCII.GetString(hashOne));
        }

        [TestMethod]
        public async Task WhenUsingHMACSHA256_ThenDataIsHashed()
        {
            var strStreamOne = new MemoryStream(Encoding.ASCII.GetBytes("This is my pasword! Dont read me!"));

            byte[] hashOne;
            byte[] key = Encoding.ASCII.GetBytes("superSecretH4shKey1!");
            using (var hmac = new HMACSHA256(key))
            {
                hashOne = await hmac.ComputeHashAsync(strStreamOne);
            }

            Assert.AreEqual(32, hashOne.Length);
            Assert.AreNotEqual("This is my pasword! Dont read me!", Encoding.ASCII.GetString(hashOne));
        }

        [TestMethod]
        public async Task WhenDifferentKeysWithHMACSHA256_ThenDataIsHashedDifferently()
        {
            var strStreamOne = new MemoryStream(Encoding.ASCII.GetBytes("This is my pasword! Dont read me!"));

            byte[] hashOne;
            byte[] key = Encoding.ASCII.GetBytes("superSecretH4shKey1!");
            using (var hmac = new HMACSHA256(key))
            {
                hashOne = await hmac.ComputeHashAsync(strStreamOne);
            }

            var strStreamTwo = new MemoryStream(Encoding.ASCII.GetBytes("This is my pasword! Dont read me!"));

            byte[] hashTwo;
            byte[] keyTwo = Encoding.ASCII.GetBytes("superDup3rSecretH4shKey1!");
            using (var hmac = new HMACSHA256(keyTwo))
            {
                hashTwo = await hmac.ComputeHashAsync(strStreamTwo);
            }

            Assert.AreEqual(32, hashOne.Length);
            Assert.AreEqual(32, hashTwo.Length);
            Assert.AreNotEqual("This is my pasword! Dont read me!", Encoding.ASCII.GetString(hashOne));
            Assert.AreNotEqual("This is my pasword! Dont read me!", Encoding.ASCII.GetString(hashTwo));
            Assert.AreNotEqual(Encoding.ASCII.GetString(hashOne), Encoding.ASCII.GetString(hashTwo));
        }

        public static Stream GenerateStreamFromString(byte[] data)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(data);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
    }
}