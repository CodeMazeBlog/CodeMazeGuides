using ByteArrayToFile;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Text;

namespace ByteArrayToFileTest
{
    [TestClass]
    public class ByteArrayToFileUnitTest
    {
        const string Data = "Byte Array To File Test";
        readonly byte[] _dataInBytes = Encoding.UTF8.GetBytes(Data);
        readonly string _filePath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());

        [TestCleanup]
        public void DeleteFile() => File.Delete(_filePath);

        [TestMethod]
        public void GivenBinaryWriter_WhenSavingByteArray_ThenLoadCorrectData()
        {
            ByteArrayToFileConverter.SaveByteArrayToFileWithBinaryWriter(_dataInBytes, _filePath);

            Assert.AreEqual(Data, File.ReadAllText(_filePath));
        }

        [TestMethod]
        public void GivenBinaryWriter_WhenSavingShorterArrayOverLongerFile_ThenFileIsTruncated()
        {
            var longer = Encoding.UTF8.GetBytes("This is a test of the OpenWrite method");
            var shorter = Encoding.UTF8.GetBytes("Second run");

            ByteArrayToFileConverter.SaveByteArrayToFileWithBinaryWriter(longer, _filePath);
            ByteArrayToFileConverter.SaveByteArrayToFileWithBinaryWriter(shorter, _filePath);

            Assert.AreEqual(shorter.Length, new FileInfo(_filePath).Length);
            Assert.AreEqual("Second run", File.ReadAllText(_filePath));
        }

        [TestMethod]
        public void GivenFileStream_WhenSavingByteArray_ThenLoadCorrectData()
        {
            ByteArrayToFileConverter.SaveByteArrayToFileWithFileStream(_dataInBytes, _filePath);

            Assert.AreEqual(Data, File.ReadAllText(_filePath));
        }

        [TestMethod]
        public void GivenStaticFileMethod_WhenSavingByteArray_ThenLoadCorrectData()
        {
            ByteArrayToFileConverter.SaveByteArrayToFileWithStaticMethod(_dataInBytes, _filePath);

            Assert.AreEqual(Data, File.ReadAllText(_filePath));
        }
    }
}
