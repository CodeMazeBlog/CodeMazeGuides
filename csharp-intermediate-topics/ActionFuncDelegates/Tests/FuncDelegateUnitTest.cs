namespace Tests;

public class FunctDelegateUnitTest
{
    [Fact]
    public void WhenCallingRun_ThenNotException()
    {
        var del = new ActionFuncDelegates.FuncDelegate();
        var result = del.Run();
        Assert.Equal(16.5, result);
    }
}