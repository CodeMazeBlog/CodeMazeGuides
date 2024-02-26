using HowToCalculateADirectorySize;

namespace Tests
{
    public class DirectorySizeCalculatorTests
    {
        [Fact]
        public void WhenDirectoryInfoIsPassed_ReturnDirectorySize()
        {
            //Arrange
            DirectoryInfo directoryInfo = new DirectoryInfo(@"C:\Users\racho\Desktop\Nothing");
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
            DirectoryInfo directoryInfo = new DirectoryInfo(@"C:\Users\racho\Desktop\Nothing");

            // Act
            long size = DirectorySizeCalculator.GetSizeByParallelProcessing(directoryInfo);

            // Assert
            Assert.True(size > 0);
        }
    }
}