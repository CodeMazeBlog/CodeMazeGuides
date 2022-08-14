namespace Tests;

public class DelegateUnitTest
{    
  [Fact]
  public void WhenCallingRun_ThenNotException()
  {
    var del = new ActionFuncDelegates.Delegate();
    var ex = Record.Exception(() => del.Run());
    Assert.Null(ex);
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