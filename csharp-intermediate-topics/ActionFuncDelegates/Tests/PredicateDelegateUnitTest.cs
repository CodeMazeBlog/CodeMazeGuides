namespace Tests;

public class PredicateDelegateUnitTest
{
  [Fact]
  public void WhenCallingRun_ThenNotException()
  {
    var del = new ActionFuncDelegates.PredicateDelegate();
    var ex = Record.Exception(() => del.Run());
    Assert.Null(ex);
  }
}