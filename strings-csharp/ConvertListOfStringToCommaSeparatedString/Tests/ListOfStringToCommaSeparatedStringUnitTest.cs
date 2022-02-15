using Xunit;
using ConvertListOfStringToCommaSeparatedString;

namespace Tests
{
    public class ListOfStringToCommaSeparatedStringUnitTest
    {
        [Fact]
        public void WhenJoinIsCalledWithCommaOnSimpleList_ThenItReturnsCommaSeparatedString()
        {
            // Arrange
            var list = new SimpleList();

            // Act
            var result = list.ConvertListOfStringsToCommaSeparatedString();

            // Assert
            Assert.Equal("Hello,From,Code Maze", result);
        }

        [Fact]
        public void WhenJoinIsCalledWithCommaOnComplexList_ThenItReturnsCommaSeparatedString()
        {
            // Arrange
            var complexList = new ComplexList();

            // Act
            var result = complexList.ConvertListOfStringsToCommaSeparatedString();

            // Assert
            Assert.Equal("Sarah,Eric", result);
        }
    }
}
