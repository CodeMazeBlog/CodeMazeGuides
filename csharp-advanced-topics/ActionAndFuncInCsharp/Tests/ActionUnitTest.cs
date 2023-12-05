using ActionInCsharp;

namespace Tests;

public class ActionUnitTest
{
    private readonly Order _order = new();

    [Fact]
    public void WhenStatusIsChanged_ThenCounterMustBeIncremented()
    {
        var counter = 0;

        _order.SetStatus(OrderStatus.InProgress, (status) => counter++);

        Assert.Equal(1, counter);
    }

    [Fact]
    public void WhenStatusIsNotChanged_ThenCounterMustNotBeIncremented()
    {
        var counter = 0;

        _order.SetStatus(OrderStatus.Unknown, (status) => counter++);

        Assert.Equal(0, counter);
    }
}
