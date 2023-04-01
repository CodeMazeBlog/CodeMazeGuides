using ActionFuncDelegates;

namespace Tests;

public class ActionFuncDelegateUnitTest
{    
    [Fact]
    public void WhenGivenAnInteger_ThenReturnAnInteger()
    {
        var example = new ExampleDelegate();
        Assert.Equal(9, example.TestDelegate(3));
    }

    [Fact]
    public void WhenPassedAnIntegerAndString_ThenReturnAString()
    {
        var example = new ActionFuncExample();
        Assert.Equal("Tomie is 40 years old", example.TestFuncDelegate(40, "Tomie"));
    }
}
