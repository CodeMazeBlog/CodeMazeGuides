using HowToCalculateADirectorySize;

namespace Tests
{
    public class DirectorySizeCalculatorTests
    {
        private static string _testDirectoryPath = @"C:\Public\CM-Demos\Test";
        private static string _fileName = "example.txt";

        private static string _filePath = Path.Combine(_testDirectoryPath, _fileName);


        public DirectorySizeCalculatorTests()
        {
            Directory.CreateDirectory(_testDirectoryPath);
            File.Create(_filePath).Close();

            using StreamWriter writer = new (_filePath);
            writer.WriteLine("Hello, this is some content in the file.");
            writer.WriteLine("You can add more lines as needed.");
        }

        [Fact]
        public void WhenDirectoryInfoIsPassed_ReturnDirectorySize()
        {
            //Arrange
            DirectoryInfo directoryInfo = new DirectoryInfo(_testDirectoryPath);
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
            DirectoryInfo directoryInfo = new DirectoryInfo(_testDirectoryPath);

            // Act
            long size = DirectorySizeCalculator.GetSizeByParallelProcessing(directoryInfo);

            // Assert
            Assert.True(size > 0);
        }
    }
}