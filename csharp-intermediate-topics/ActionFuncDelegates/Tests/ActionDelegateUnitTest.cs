namespace Tests;

public class ActionDelegateUnitTest
{
  [Fact]
  public void WhenCallingRun_ThenNotException()
  {
    var del = new ActionFuncDelegates.ActionDelegate();
    var ex = Record.Exception(() => del.Run());
    Assert.Null(ex);
  }
}