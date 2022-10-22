using ActionAndFuncDelegatesInCSharp;

namespace Tests;

public class ActionUnitTest
{
    [Fact]
    public void GivenAnActionPointingToANamedMethod_WhenInvoking_ThenTheNamedMethodShouldBeCalled()
    {
        var isLogged = ActionDelegate.LogUsingActionReferringANamedMethod();
        
        Assert.True(isLogged);
    }
    
    [Fact]
    public void GivenAnActionPointingToAnAnonymousMethod_WhenInvoking_ThenTheAnonymousMethodShouldBeCalled()
    {
        var isLogged = ActionDelegate.LogUsingActionReferringAnAnonymousMethod();
        
        Assert.True(isLogged);
    }

    [Fact]
    public void GivenAnActionPointingToALambdaExpression_WhenInvoking_ThenTheLambdaExpressionShouldBeCalled()
    {
        var isLogged = ActionDelegate.LogUsingActionReferringALambdaExpression();
        
        Assert.True(isLogged);
    }
    
    [Fact]
    public void GivenAnAction_WhenCallingUsingInvoke_ThenTheReferencedMethodShouldBeCalled()
    {
        var isLogged = ActionDelegate.CallingActionUsingInvoke();
        
        Assert.True(isLogged);
    }
    
    [Fact]
    public void GivenAMulticastDelegateFormedUsingActions_WhenInvoking_EachActionShouldBeCalled()
    {
        var (isLogConsoleInvoked, isLogDbInvoked) = ActionDelegate.FormingMulticastDelegateUsingActions();
        
        Assert.True(isLogConsoleInvoked);
        Assert.True(isLogDbInvoked);
    }
}