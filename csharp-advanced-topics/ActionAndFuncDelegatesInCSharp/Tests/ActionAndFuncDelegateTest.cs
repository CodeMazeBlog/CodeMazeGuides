namespace Tests;

public class ActionAndFuncDelegateTest
{
    [Fact]
    public void GivenMessage_WhenUpdateUIWithMessageCalled_ThenUpdatesTextProperty()
    {
        var actionDelegate = new ActionDelegates();
        var input = "Hello, World!";

        actionDelegate.UpdateUIWithMessage(input);
    }


    [Fact]
    public void GivenTwoNumbers_WhenMultiplyCalled_ThenReturnsCorrectProduct()
    {
        var x = 5;
        var y = 4;
        var expected = 20;

        var result = FuncDelegates.multiply(x, y);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void GivenANegativeNumber_WhenMultiplyCalled_ThenReturnsCorrectProduct()
    {
        var x = -5;
        var y = 4;
        var expected = -20;

        var result = FuncDelegates.multiply(x, y);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void GivenZero_WhenMultiplyCalled_ThenReturnsZero()
    {
        var x = 0;
        var y = 5;
        var expected = 0;

        var result = FuncDelegates.multiply(x, y);

        Assert.Equal(expected, result);
    }
}