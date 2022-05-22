using FuncAndActionDelegatesInCsharp.Func;
using Xunit;

namespace Tests;

[Collection("Seq")]
public class FuncDelegateUnitTest
{
    [Fact]
    public void BeforeUsingFuncDelegate_ShouldPrintExpectedOutput()
    {
        var output = new StringWriter();
        Console.SetOut(output);

        Console.WriteLine(nameof(BeforeUsingFuncDelegate));
        var beforeFunc = new BeforeUsingFuncDelegate();
        beforeFunc.SendEmails();

        var outputString = output.ToString();
        Assert.Contains("Welcome Email sent to user1@example.com", outputString);
        Assert.Contains("Welcome Email sent to user2@example.com", outputString);
        Assert.Contains("Sent Welcome Email to all users", outputString);
        Assert.Contains("SignUp Email not sent to user1@example.com", outputString);
        Assert.Contains("SignUp Email not sent to user2@example.com", outputString);
        Assert.Contains("SignUp Email not sent to all users", outputString);
    }

    [Fact]
    public void AfterUsingFuncDelegate_ShouldPrintExpectedOutput()
    {
        var output = new StringWriter();
        Console.SetOut(output);

        Console.WriteLine(nameof(AfterUsingFuncDelegate));
        var beforeFunc = new AfterUsingFuncDelegate();
        beforeFunc.SendEmails();

        var outputString = output.ToString();
        Assert.Contains("Welcome Email sent to user1@example.com", outputString);
        Assert.Contains("Welcome Email sent to user2@example.com", outputString);
        Assert.Contains("Sent Welcome Email to all users", outputString);
        Assert.Contains("SignUp Email not sent to user1@example.com", outputString);
        Assert.Contains("SignUp Email not sent to user2@example.com", outputString);
        Assert.Contains("SignUp Email not sent to all users", outputString);
    }
}