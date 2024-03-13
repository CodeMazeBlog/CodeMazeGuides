using ActionAndFuncDelegatesInCSharp;
using Xunit;

namespace Tests;

public class SquareUnitTest
{
    [Fact]
    public void GivenANumber_WhenSquareIsCalled_ThenCorrectSquareIsReturned()
    {
        // Arrange
        var testNumber = 7;
        var expectedSquare = 49;

        // Act
        var result = Program.Square(testNumber);

        // Assert
        Assert.Equal(expectedSquare, result);
    }   
}
