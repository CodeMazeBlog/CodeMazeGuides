namespace Tests;

public class ActionDelegateUnitTest
{
    [Fact]
    public void WhenCallingRun_ThenCheckMsgLength()
    {
        var del = new ActionFuncDelegates.ActionDelegate();
        var length = del.Run();
        Assert.Equal(26, length);
    }
}