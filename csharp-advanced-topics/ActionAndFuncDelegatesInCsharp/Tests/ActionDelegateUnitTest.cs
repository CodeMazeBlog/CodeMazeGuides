
namespace Tests;

using ActionAndFuncDelegatesInCsharp;

public class ActionDelegateUnitTest
{
    
    [Fact]
    public void WhenDelegateIsInvoke_ThenShouldUpdateMessageProperty()
    {
       ActionDelegate.DelegateOperator();
       
       Assert.Equal("Hello World",ActionDelegate.Message);
    }
    
    [Fact]
    public void WhenActionIsInvoke_ThenShouldUpdateMessageProperty()
    {
        ActionDelegate.Action();
       
        Assert.Equal("Hello World",ActionDelegate.Message);
    }
    
    [Fact]
    public void WhenGenericActionIsInvoke_ThenShouldUpdateMessageProperty()
    {
        ActionDelegate.GenericAction();
       
        Assert.Equal("Hello World",ActionDelegate.Message);
    } 
        
    [Fact]
    public void WhenActionWithAnonymousMethodIsInvoke_ThenShouldUpdateMessageProperty()
    {
        ActionDelegate.ActionWithAnonymousMethod();
       
        Assert.Equal("Success message",ActionDelegate.Message);
    } 
    
    [Fact]
    public void WhenActionWithLambdaExpressionIsInvoke_ThenShouldUpdateMessageProperty()
    {
        ActionDelegate.ActionWithLambdaExpression();
       
        Assert.Equal("Success message",ActionDelegate.Message);
    } 
}