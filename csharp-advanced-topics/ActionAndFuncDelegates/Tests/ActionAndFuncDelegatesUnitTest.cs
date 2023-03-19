namespace Tests;

public class ActionAndFuncDelegatesUnitTest
{

    #region Action Delegates Unit Tests
    [Fact]
    public void WhenActionDelegatesInitializedWithoutParams_ThenDelegateInvocation()
    {
        Action actionDelegate = Program.SayHelloToTheWorld;
        var invocationList = actionDelegate.GetInvocationList();

        Assert.Equal(1, invocationList.Length);
    }

    [Fact]
    public void WhenActionDelegatesInitializedWithParams_ThenDelegateInvocation()
    {
        Action<string, string> actionDelegateWithParams = Program.ShowYourParameters;
        var invocationList = actionDelegateWithParams.GetInvocationList();

        Assert.Equal(1, invocationList.Length);

    }

    [Fact]
    public void WhenActionDelegatesInitializedWithAnonMethod_ThenDelegateInvocation()
    {
        Action<int> actionDelegateWithAnonMethod = Program.GetActionAnonMethod();
        var invocationList = actionDelegateWithAnonMethod.GetInvocationList();

        Assert.Equal(1, invocationList.Length);

    }

    [Fact]
    public void WhenActionDelegatesInitializedWithLambdaAnnotation_ThenDelegateInvocation()
    {
        Action actionDelegateWithLambda = Program.GetActionLambdaStatement();
        var invocationList = actionDelegateWithLambda.GetInvocationList();

        Assert.Equal(1, invocationList.Length);

    }
    #endregion

    #region Func Delegates Unit Tests
    [Fact]
    public void WhenFuncDelegatesInitializedWithoutParams_ThenDelegateInvocation()
    {
        Func<string> funcDelegateWithoutParams = Program.SayHelloWorld;
        var helloString = funcDelegateWithoutParams();

        Assert.Equal("Hello, World!", helloString);
    }

    [Fact]
    public void WhenFuncDelegatesInitializedWithParams_ThenDelegateInvocation()
    {
        string testString = "test String";
        Func<string, int> funcDelegateWithParams = Program.GetCharacterCount;
        var stringLength = funcDelegateWithParams(testString);

        Assert.Equal(testString.Length, stringLength);
    }

    [Fact]
    public void WhenFuncDelegatesInitializedWithAnonMethod_ThenDelegateInvocation()
    {
        Func<int, string> funcDelegateWithAnonMethod = Program.GetFuncAnonMethod();
        var invocationList = funcDelegateWithAnonMethod.GetInvocationList();

        Assert.Equal(1, invocationList.Length);

    }

    [Fact]
    public void WhenFuncDelegatesInitializedWithLambdaAnnotation_ThenDelegateInvocation()
    {
        Func<string> funcDelegateWithLambda = Program.GetFuncLambdaStatement();
        var invocationList = funcDelegateWithLambda.GetInvocationList();

        Assert.Equal(1, invocationList.Length);

    }
    #endregion
}