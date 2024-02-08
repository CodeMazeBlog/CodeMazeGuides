using GetNumberOfLinesInTextFile;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GetNumberOfLinesInTextFileUnitTests
{
    [TestClass]
    public class NumberOfLinesInTextFileUnitTests
    {
        private const string FileName = "Sample.txt";

        [TestMethod]
        public void GivenFileName_WhenCountingLinesUsingReadAllLinesMethod_ThenReturnCorrectNumberOfLines()
        {
            var result = FileHelper.CountLinesUsingReadAllLinesMethod(FileName);

            Assert.AreEqual(7, result, "The method should return the correct number of lines in the file.");
        }

        [TestMethod]
        public void GivenFileName_WhenCountingLinesUsingStreamRider_ThenReturnCorrectNumberOfLines()
        {
            var result = FileHelper.CountLinesUsingStreamReader(FileName);

            Assert.AreEqual(7, result, "The method should return the correct number of lines in the file.");
        }

        [TestMethod]
        public void GivenFileName_WhenCountingLinesUsingReadLinesMethod_ThenReturnCorrectNumberOfLines()
        {
            var result = FileHelper.CountLinesUsingReadLinesMethod(FileName);

            Assert.AreEqual(7, result, "The method should return the correct number of lines in the file.");
        }
    }
}