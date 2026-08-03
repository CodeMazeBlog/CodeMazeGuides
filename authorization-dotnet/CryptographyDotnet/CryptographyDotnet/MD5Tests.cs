using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CryptographyDotnet
{
    [TestClass]
    public class MD5Tests
    {
        [TestMethod]
        public async Task WhenHashingSameValue_ThenHashesAreEqual()
        {
            var strStreamOne = new MemoryStream(Encoding.UTF8.GetBytes("This is my pasword! Dont read me!"));

            byte[] hashOne;
            using (var hasher = MD5.Create())
            {
                hashOne = await hasher.ComputeHashAsync(strStreamOne);
            }

            var strStreamTwo = new MemoryStream(Encoding.UTF8.GetBytes("This is my pasword! Dont read me!"));
            byte[] hashTwo;
            using (var hasher = MD5.Create())
            {
                hashTwo = await hasher.ComputeHashAsync(strStreamTwo);
            }

            CollectionAssert.AreEqual(hashOne, hashTwo);
        }

        [TestMethod]
        public async Task WhenUsingMD5_ThenDataIsHashed()
        {
            var strStreamOne = new MemoryStream(Encoding.UTF8.GetBytes("This is my pasword! Dont read me!"));

            byte[] hashOne;
            using (var hasher = MD5.Create())
            {
                hashOne = await hasher.ComputeHashAsync(strStreamOne);
            }

            Assert.AreEqual(16, hashOne.Length);
            Assert.AreNotEqual("This is my pasword! Dont read me!", Encoding.ASCII.GetString(hashOne));
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