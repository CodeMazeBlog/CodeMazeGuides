using ByteArrayToFile;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Text;

namespace ByteArrayToFileTest
{
    [TestClass]
    public class ByteArrayToFileUnitTest
    {
        const string _data = "Byte Array To File Test";
        readonly byte[] _dataInBytes = Encoding.UTF8.GetBytes(_data);

        [TestMethod]
        public void GivenBinaryWriter_WhenSavingByteArray_ThenLoadCorrectData()
        {
            string filePath = "./binary-writer-file.txt";
            ByteArrayToFileConverter.SaveByteArrayToFileWithBinaryWriter(_dataInBytes, filePath);

            Assert.AreEqual(_data, File.ReadAllText(filePath));
        }
        
        [TestMethod]
        public void GivenFileStream_WhenSavingByteArray_ThenLoadCorrectData()
        {
            string filePath = "./filestream-file.txt";
            ByteArrayToFileConverter.SaveByteArrayToFileWithFileStream(_dataInBytes, filePath);

            Assert.AreEqual(_data, File.ReadAllText(filePath));
        }
        
        [TestMethod]
        public void GivenStaticFileMethod_WhenSavingByteArray_ThenLoadCorrectData()
        {
            string filePath = "./static-method-file.txt";
            ByteArrayToFileConverter.SaveByteArrayToFileWithStaticMethod(_dataInBytes, filePath);

            Assert.AreEqual(_data, File.ReadAllText(filePath));
        }
    }
}