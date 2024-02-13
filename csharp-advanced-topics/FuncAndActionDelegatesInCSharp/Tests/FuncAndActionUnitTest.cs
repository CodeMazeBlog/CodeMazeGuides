using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests;

[TestClass]
public class FuncAndActionUnitTest
{
    [TestMethod]
    public void WhenNotifying_ThenWritesCorrectMessageToConsole()
    {
        var expectedMessage = "Received message: 'build project'";
        TextWriter oldOut = Console.Out;

        using (var stringWriter = new StringWriter())
        {
            Console.SetOut(stringWriter);
            ActionDelegate.Program.SendNotification();

            var actualConsoleOutput = stringWriter.ToString().Trim();
            Assert.AreEqual(expectedMessage, actualConsoleOutput);
        }

        Console.SetOut(oldOut);
    }

    [TestMethod]
    public void WhenNotifying_ThenReceiveResult()
    {
        var expectedMessage = "building";

        // known notification
        string result = FuncDelegate.Program.GetNotification();
        Assert.AreEqual(expectedMessage, result);
    }
}
