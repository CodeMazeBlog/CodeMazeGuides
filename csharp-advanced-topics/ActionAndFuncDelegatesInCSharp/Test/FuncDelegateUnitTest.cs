using ActionAndFunc;

namespace TestProject1;

public class FuncDelegateUnitTest
{
    [Theory]
    [InlineData(2, 3, 5)] // Test case 1: 2 + 3 = 5
    [InlineData(0, 0, 0)] // Test case 2: 0 + 0 = 0
    [InlineData(-1, 1, 0)] // Test case 3: -1 + 1 = 0
    public void ExecuteFuncDelegate_ShouldReturnCorrectResult(int num1, int num2, int expected)
    {
        // Arrange
        var funcDelegate = new FuncDelegate();

        // Act
        var result = funcDelegate.ExecuteFuncDelegate(num1, num2);

        // Assert
        Assert.Equal(expected, result);
    } 
}