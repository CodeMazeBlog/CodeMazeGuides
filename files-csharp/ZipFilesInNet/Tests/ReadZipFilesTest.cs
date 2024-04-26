using ZipFilesInNet;

namespace Tests
{
    [TestClass]
    public class ReadZipFilesTest
    {
        [TestMethod]
        [DataRow("multi-folder.zip", 10)]
        [DataRow("multi-file.zip", 2)]
        [DataRow("single-file.zip", 1)]
        public void GivenZipFile_WhenListContent_ThenExpectedNumberOfLinesShouldExists(
            string zipFile, int expectedNumberOfLines)
        {
            Assert.IsTrue(expectedNumberOfLines == CountOutputLines(zipFile));
        }

        private int CountOutputLines(string zipName)
        {
            var reader = new ReadZipFiles();

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            reader.ListAllFilesInZipUsingName(zipName);

            var output = stringWriter.ToString();

            return output.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }
}
