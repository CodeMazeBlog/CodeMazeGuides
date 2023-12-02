using ActionInCsharp;

namespace Tests;

public class ActionUnitTest
{
    [Fact]
    public void WhenStatusIsChanged_ThenCounterMustBeIncremented()
    {
        var counter = 0;
        var foo = new Foo();

        foo.SetStatus(Status.InProgress, (status) => counter++);

        Assert.Equal(1, counter);
    }

    [Fact]
    public void WhenStatusIsNotChanged_ThenCounterMustNotBeIncremented()
    {
        var counter = 0;
        var foo = new Foo();

        foo.SetStatus(Status.Unknown, (status) => counter++);

        Assert.Equal(0, counter);
    }
}
