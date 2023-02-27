namespace test_act_and_func;
public class ActAndFuncUnitTest
{
    [Fact]
    public void WhenFuncsWorkingCorrectly_ThenNumberReturned()
    {
        Assert.Equal(11, new _Func.Funcs().FuncMethod());
    }
       public void WhenDelegatesNotWorking_ThenFailMessageReturned()
    {
      try
    {
        _Delegate.Delegates funcAndAction = new _Delegate.Delegates();
        funcAndAction.DelegateMethod();
        funcAndAction.MultiDelegateMethod(4,5);
        return; // indicates success
    }
    catch (System.Exception ex)
    {
        Assert.Fail(ex.Message);
    }
    }
    public void WhenActionsNotWorking_ThenFailMessageReturned()
    {
      try
    {
        _Action.Actions action = new _Action.Actions();
        action.ActionMethod();
        action.ActionMethod2();
        return; // indicates success
    }
    catch (System.Exception ex)
    {
        Assert.Fail(ex.Message);
    }
    }
}