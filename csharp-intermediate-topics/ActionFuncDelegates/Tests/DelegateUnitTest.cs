namespace Tests;

public class DelegateUnitTest
{
    [Fact]
    public void WhenCallingRun_ThenReturnSum()
    {
        var del = new ActionFuncDelegates.Delegate();
        var sum = del.Run();
        Assert.Equal(15, sum);
    }

    [Fact]
    public void WhenCallingActionRun_ThenNotException()
    {
        var del = new ActionFuncDelegates.Delegate();
        var ex = Record.Exception(() => del.ActionRun());
        Assert.Null(ex);
    }

    [Fact]
    public void WhenCallingFuncRun_ThenNotException()
    {
        var del = new ActionFuncDelegates.Delegate();
        var ex = Record.Exception(() => del.FuncRun());
        Assert.Null(ex);
    }

    [Fact]
    public void WhenCallingPredicateRun_ThenNotException()
    {
        var del = new ActionFuncDelegates.Delegate();
        var ex = Record.Exception(() => del.PredicateRun());
        Assert.Null(ex);
    }
}