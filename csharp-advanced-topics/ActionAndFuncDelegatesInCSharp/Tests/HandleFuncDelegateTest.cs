using ActionAndFuncDelegatesInCSharp;

namespace Tests;

public class HandleFuncDelegateTest
{
    [Fact]
    public void Add_WhenGivenTwoNumbers_ThenReturnTheirSum()
    {
        // Act
        var result = HandleFuncDelegate.Add(10, 30);

        // Assert
        Assert.Equal(40, result);
    }
}
