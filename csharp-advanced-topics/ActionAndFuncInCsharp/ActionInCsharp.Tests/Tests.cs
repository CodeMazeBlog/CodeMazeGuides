namespace ActionInCsharp.Tests;

public class Tests
{
    [Fact]
    public void WhenStatusIsChanged_ThenStatusChangedActionMustBeInvoked()
    {
        var counter = 0;
        var foo = new Foo();

        foo.SetStatus(Status.InProgress, (status) => counter++);

        Assert.Equal(1, counter);
    }

    [Fact]
    public void WhenStatusIsNotChanged_ThenStatusChangedActionMustNotBeInvoked()
    {
        var counter = 0;
        var foo = new Foo();
;
        foo.SetStatus(Status.Unknown, (status) => counter++);

        Assert.Equal(0, counter);
    }
}
