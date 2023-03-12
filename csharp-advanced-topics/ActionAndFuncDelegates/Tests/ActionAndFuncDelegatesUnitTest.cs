namespace Tests;

public class ActionAndFuncDelegatesUnitTest
{

    #region Action Delegates Unit Tests
    [Fact]
    public void WhenActionDelegatesInitializedWithoutParams_ThenDelegateInvocation()
    {
        Action actionDelegate = SayHelloToTheWorld;
        var invocationList = actionDelegate.GetInvocationList();

        Assert.Equal(1, invocationList.Length);
    }

    [Fact]
    public void WhenActionDelegatesInitializedWithParams_ThenDelegateInvocation()
    {
        Action<string, string> actionDelegateWithParams = ShowYourParameters;
        var invocationList = actionDelegateWithParams.GetInvocationList();

        Assert.Equal(1, invocationList.Length);

    }

    [Fact]
    public void WhenActionDelegatesInitializedWithAnonMethod_ThenDelegateInvocation()
    {
        Action<int> actionDelegateWithAnonMethod = delegate (int param) { Console.WriteLine("Hello there, you send us " + param + " stars"); };
        var invocationList = actionDelegateWithAnonMethod.GetInvocationList();

        Assert.Equal(1, invocationList.Length);

    }

    [Fact]
    public void WhenActionDelegatesInitializedWithLambdaAnnotation_ThenDelegateInvocation()
    {
        Action actionDelegateWithLambda = () =>
        {
            Console.Write("I am inside lambda statement");
        };
        var invocationList = actionDelegateWithLambda.GetInvocationList();

        Assert.Equal(1, invocationList.Length);

    }
    #endregion

    #region Func Delegates Unit Tests
    [Fact]
    public void WhenFuncDelegatesInitializedWithoutParams_ThenDelegateInvocation()
    {
        Func<string> funcDelegateWithoutParams = SayHelloWorld;
        var helloString = SayHelloWorld();

        Assert.Equal("Hello, World!", helloString);
    }

    [Fact]
    public void WhenFuncDelegatesInitializedWithParams_ThenDelegateInvocation()
    {
        string testString = "test String";
        Func<string, int> funcDelegateWithParams = GetCharacterCount;
        var stringLength = GetCharacterCount(testString);

        Assert.Equal(testString.Length, stringLength);
    }

    [Fact]
    public void WhenFuncDelegatesInitializedWithAnonMethod_ThenDelegateInvocation()
    {
        Func<int, string> funcDelegateWithAnonMethod = delegate (int param)
        {
            return "Hello there, you send us " + param + " stars";
        };
        var invocationList = funcDelegateWithAnonMethod.GetInvocationList();

        Assert.Equal(1, invocationList.Length);

    }

    [Fact]
    public void WhenFuncDelegatesInitializedWithLambdaAnnotation_ThenDelegateInvocation()
    {
        Func<string> funcDelegateWithLambda = () =>
        {
            return "I am inside the lambda statement";
        };
        var invocationList = funcDelegateWithLambda.GetInvocationList();

        Assert.Equal(1, invocationList.Length);

    }
    #endregion

    #region Methods
    public static void SayHelloToTheWorld()
    {
        Console.WriteLine("Hello, World!");
    }
    public static void ShowYourParameters(string firstParameter, string secondParamter)
    {
        Console.WriteLine("First Parameter: " + firstParameter + ", Second Paramter: " + secondParamter);
    }
    public static string SayHelloWorld()
    {
        return "Hello, World!";
    }
    public static int GetCharacterCount(string theBigWord)
    {
        return theBigWord.Length;
    }
    #endregion
}