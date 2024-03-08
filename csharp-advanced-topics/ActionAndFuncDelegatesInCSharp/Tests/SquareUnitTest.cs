using Xunit;

namespace Tests;

public class SquareUnitTest
{
    [Fact]
    public void GivenANumber_WhenSquareIsCalled_ThenCorrectSquareIsReturned()
    {
        // Arrange
        int testNumber = 7;
        int expectedSquare = 49;

        // Act
        int result = Square(testNumber);

        // Assert
        Assert.Equal(expectedSquare, result);
    }

    private static int Square(int number)
    {
        return number * number;
    }
}
