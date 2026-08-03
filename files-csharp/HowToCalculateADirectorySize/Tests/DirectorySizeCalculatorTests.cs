using HowToCalculateADirectorySize;

namespace Tests
{
    public class DirectorySizeCalculatorTests
    {
        private readonly string _resourceFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Shared");
        

        [Fact]
        public void WhenDirectoryInfoIsPassed_ReturnDirectorySize()
        {
            //Arrange
            var directoryInfo = new DirectoryInfo(_resourceFolderPath);
            long size;

            //Act
            size = DirectorySizeCalculator.GetSizeWithRecursion(directoryInfo);

            //Assert
            Assert.True(size > 0);
        }

        [Fact]
        public void WhenDirectoryInfoIsPassedToParallelProcess_ReturnDirectorySize()
        {
            // Arrange
            var directoryInfo = new DirectoryInfo(_resourceFolderPath);

            // Act
            long size = DirectorySizeCalculator.GetSizeByParallelProcessing(directoryInfo);

            // Assert
            Assert.True(size > 0);
        }
    }
}