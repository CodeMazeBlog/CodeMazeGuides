namespace Tests;

public class PredicateDelegateUnitTest
{
    [Fact]
    public void WhenCallingRun_ThenNotException()
    {
        var del = new ActionFuncDelegates.PredicateDelegate();
        var result = del.Run();
        Assert.True(result);
    }
}