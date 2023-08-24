using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CryptographyDotnet
{
    [TestClass]
    public class DSATests
    {
        public DSA? dsa;
        public string dataStr = "This is corporate research! Dont read me!";
        public byte[] data = {};

        [TestInitialize]
        public void Initilialize()
        {
            dsa = DSA.Create();
            data = Encoding.UTF8.GetBytes(dataStr);
        }

        [TestCleanup]
        public void Dispose()
        {
            dsa.Dispose();
        }

        [TestMethod]
        public void WhenUsingDSA_ThenDataIsSigned()
        {
            var signedData = Sign(data);

            Assert.AreNotEqual(data, signedData);
            Assert.AreEqual(64, signedData.Length);
        }

        [TestMethod]
        public void GivenSameInput_WhenUsingDSA_ThenDataIsSignedDifferentlyEachTime()
        {
            var signedData = Sign(data);
            var signedData2 = Sign(data);

            CollectionAssert.AreNotEqual(signedData, signedData2);
        }

        [TestMethod]
        public void WhenSigningWithDSA_ThenDataIsVerifiable()
        {
            var signedData = Sign(data);
            var signatureVerified = VerifySignature(data, signedData);

            Assert.IsTrue(signatureVerified);
            Assert.AreEqual(64, signedData.Length);
            Assert.AreNotEqual(data, signedData);

            Dispose();
        }

        [TestMethod]
        public void WhenSigningWithDSA_ThenDifferentDataIsNotVerified()
        {
            var dataStr2 = "This is a different string!";
            var data2 = Encoding.UTF8.GetBytes(dataStr2);

            var signedData = Sign(data);
            var signatureVerified = VerifySignature(data2, signedData);

            Assert.IsFalse(signatureVerified);
            Assert.AreEqual(64, signedData.Length);
            Assert.AreNotEqual(data, signedData);
        }

        public byte[] Sign(byte[] data)
        {
            if(dsa is null)
                throw new NullReferenceException(nameof(dsa));

            var result = dsa.SignData(data, HashAlgorithmName.SHA256);

            return result;
        }

        public bool VerifySignature(byte[] data, byte[] signedData)
        {
            if (dsa is null)
                throw new NullReferenceException(nameof(dsa));

            return dsa.VerifyData(data, signedData, HashAlgorithmName.SHA256);
        }
    } 
}