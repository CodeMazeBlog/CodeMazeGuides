using Xunit;

namespace FileToByteArray.Test
{
    public class ConvertToByteArrayTest
    {
        const string TestFilePath = "TestFiles/CodeMazeTest.pdf";

        [Fact]
        public void WhenConvertToByteArray_ThenReturnsCorrectByteArray()
        {
            // Arrange
            var expected = File.ReadAllBytes(TestFilePath);

            // Act
            var result = Program.ConvertToByteArray(TestFilePath);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void WhenConvertToByteArrayChunked_ThenReturnsCorrectByteArray()
        {
            // Arrange
            var expected = File.ReadAllBytes(TestFilePath);

            // Act
            var result = Program.ConvertToByteArrayChunked(TestFilePath);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}