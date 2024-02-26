using HowToCalculateADirectorySize;

namespace Tests
{
    public class DirectorySizeCalculatorTests
    {
        //add a valid directory path
        string testDirectory = "";

        [Fact]
        public void WhenDirectoryInfoIsPassed_ReturnDirectorySize()
        {
            //Arrange
            DirectoryInfo directoryInfo = new DirectoryInfo(testDirectory);
            long size;

            //Act
            size = DirectorySizeCalculator.GetSizeWithRecursion(directoryInfo);

            //Assert
            if (testDirectory != null || testDirectory == "")
                Assert.True(size > 0);
        }

        [Fact]
        public void WhenDirectoryInfoIsPassedToParallelProcess_ReturnDirectorySize()
        {
            // Arrange
            DirectoryInfo directoryInfo = new DirectoryInfo(testDirectory);

            // Act
            long size = DirectorySizeCalculator.GetSizeByParallelProcessing(directoryInfo);

            // Assert
            if (testDirectory != null || testDirectory == "")
                Assert.True(size > 0);
        }
    }
}