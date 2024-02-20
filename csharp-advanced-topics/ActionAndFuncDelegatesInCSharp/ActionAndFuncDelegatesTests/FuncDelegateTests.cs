using ActionAndFuncDelegates;
using Xunit;

public class FuncDelegatesTests
{
    [Fact]
    public void TestPerformAddition()
    {
        // Arrange
        int a = 5;
        int b = 7;

        // Act
        int result = FuncDelegates.PerformAddition(a, b);

        // Assert
        Assert.Equal(a+b, result);
    }
}
