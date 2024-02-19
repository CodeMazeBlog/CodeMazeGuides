namespace Tests;

using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class UnitTests
{
    [TestMethod]
    public void GivenAMessage_WhenFuncIsCalled_ThenMessageCapitalised()
    {
        var messsage = "Happy Coding";
        Func<string, string> funcWithParameter = ActionAndFuncDelegatesInCsharp.Program.CapitaliseMessage;
        
        var capitalised = funcWithParameter(messsage);

        Assert.AreEqual(messsage.ToUpperInvariant(), capitalised);
    }

    [TestMethod]
    public void GivenAnAction_WhenActionIsCalled_ThenNoFailure()
    {
        Action actionWithoutParameters = ActionAndFuncDelegatesInCsharp.Program.Print;
        actionWithoutParameters();

        Assert.IsNotNull(actionWithoutParameters);
    }

    [TestMethod]
    public void GivenAListWithMessages_WhenFuncsAreApplied_ThenListIsModified()
    {
        var messages = new List<string>() { "Happy", "Coding", "with", "CodeMaze" };
        messages = messages
                    .Where(m => m.Length > 4)
                    .Select(m => m.ToUpperInvariant())
                    .ToList();

        Assert.AreEqual(3, messages.Count);
        Assert.IsTrue(messages.Contains("HAPPY"));
        Assert.IsTrue(messages.Contains("CODING"));
        Assert.IsTrue(messages.Contains("CODEMAZE"));
    }
}