using ActionAndFuncDelegatesInCsharp;

namespace Tests;

public class FuncDelegateUnitTest
{
    [Fact]
    public void WhenFuncIsInvoke_ThenShouldReturnCorrectMessage()
    {
        var message = FuncDelegate.Func();
        
        Assert.True(message is "Store is closed" or "Store is open");
    }
    
    [Fact]
    public void WhenPassingArgumentToFuncParameters_ThenShouldReturnCorrectValue()
    {
        var result = FuncDelegate.FuncParameters(2,3);
        
        Assert.Equal(5, result);
    }
}