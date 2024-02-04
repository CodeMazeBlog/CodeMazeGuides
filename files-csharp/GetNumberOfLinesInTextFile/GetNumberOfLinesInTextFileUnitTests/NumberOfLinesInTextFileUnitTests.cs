using GetNumberOfLinesInTextFile;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GetNumberOfLinesInTextFileUnitTests
{
    [TestClass]
    public class NumberOfLinesInTextFileUnitTests
    {
        private const string FILE_NAME = "Sample.txt";

        [TestMethod]
        public void GivenFileName_WhenCountingLinesUsingReadAllLinesMethod_ThenReturnCorrectNumberOfLines()
        {
            int result = FileHelper.CountLinesUsingReadAllLinesMethod(FILE_NAME);

            Assert.AreEqual(7, result, "The method should return the correct number of lines in the file.");
        }

        [TestMethod]
        public void GivenFileName_WhenCountingLinesUsingStreamRider_ThenReturnCorrectNumberOfLines()
        {
            int result = FileHelper.CountLinesUsingStreamReader(FILE_NAME);

            Assert.AreEqual(7, result, "The method should return the correct number of lines in the file.");
        }

        [TestMethod]
        public void GivenFileName_WhenCountingLinesUsingReadLinesMethod_ThenReturnCorrectNumberOfLines()
        {
            int result = FileHelper.CountLinesUsingReadLinesMethod(FILE_NAME);

            Assert.AreEqual(7, result, "The method should return the correct number of lines in the file.");
        }
    }
}