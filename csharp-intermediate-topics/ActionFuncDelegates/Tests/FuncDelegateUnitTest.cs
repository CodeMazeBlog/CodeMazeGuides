namespace Tests;

public class FunctDelegateUnitTest
{
  [Fact]
  public void WhenCallingRun_ThenNotException()
  {
    var del = new ActionFuncDelegates.FuncDelegate();
    var ex = Record.Exception(() => del.Run());
    Assert.Null(ex);
  }
}