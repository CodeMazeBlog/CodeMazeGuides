using ActionAndFuncDelegatesInCSharp;

namespace Tests;

public class HandleFuncDelegateTests
{
    [Fact]
    public void Add_ReturnsCorrectResult()
    {
        // Act
        var result = HandleFuncDelegate.Add(10, 30);

        // Assert
        Assert.Equal(40, result);
    }
}
