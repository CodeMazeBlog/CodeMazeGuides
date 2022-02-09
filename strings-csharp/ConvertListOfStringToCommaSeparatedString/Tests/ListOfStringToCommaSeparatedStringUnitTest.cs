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
            SimpleList list = new SimpleList();

            // Act
            string result = list.ConvertListOfStringsToCommaSeparatedString();

            // Assert
            Assert.Equal("Hello,From,Code Maze", result);
        }

        [Fact]
        public void WhenJoinIsCalledWithCommaOnComplexList_ThenItReturnsCommaSeparatedString()
        {
            // Arrange
            ComplexList complexList = new ComplexList();

            // Act
            string result = complexList.ConvertListOfStringsToCommaSeparatedString();

            // Assert
            Assert.Equal("Sarah,Eric", result);
        }
    }
}
