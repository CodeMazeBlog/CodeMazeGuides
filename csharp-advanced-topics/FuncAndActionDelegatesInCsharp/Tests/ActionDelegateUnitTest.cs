using FuncAndActionDelegatesInCsharp.Action;
using Xunit;
namespace Tests;

[Collection("Seq")]
public class ActionDelegateUnitTest
{
    [Fact]
    public void BeforeUsingActionDelegate_ShouldPrintExpectedOutput()
    {
        var output = new StringWriter();
        Console.SetOut(output);

        Console.WriteLine(nameof(BeforeUsingActionDelegate));
        var beforeAction = new BeforeUsingActionDelegate();
        beforeAction.SendEmails();

        var outputString = output.ToString();
        Assert.Contains("Sent Welcome Email to user1@example.com", outputString);
        Assert.Contains("Sent Welcome Email to user2@example.com", outputString);
        Assert.Contains("SignUp Email not sent to user1@example.com", outputString);
        Assert.Contains("SignUp Email not sent to user2@example.com", outputString);
    }


    [Fact]
    public void AfterUsingActionDelegate_ShouldPrintExpectedOutput()
    {
        var output = new StringWriter();
        Console.SetOut(output);

        Console.WriteLine(nameof(AfterUsingActionDelegate));
        var beforeAction = new AfterUsingActionDelegate();
        beforeAction.SendEmails();

        var outputString = output.ToString();
        Assert.Contains("Sent Welcome Email to user1@example.com", outputString);
        Assert.Contains("Sent Welcome Email to user2@example.com", outputString);
        Assert.Contains("SignUp Email not sent to user1@example.com", outputString);
        Assert.Contains("SignUp Email not sent to user2@example.com", outputString);
    }
}