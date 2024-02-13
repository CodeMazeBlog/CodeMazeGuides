using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests;

[TestClass]
public class FuncAndActionUnitTest
{
    public static void SendNotification()
    {
        Action<string> notify
            = (string message) => Console.WriteLine($"Received message: '{message}'");
        notify("build project");
    }

    [TestMethod]
    public void WhenNotifying_ThenWritesCorrectMessageToConsole()
    {
        var expectedMessage = "Received message: 'build project'";
        TextWriter oldOut = Console.Out;

        using (var stringWriter = new StringWriter())
        {
            Console.SetOut(stringWriter);
            SendNotification();

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
        string result = FuncDelegate.Program.Notify();
        Assert.AreEqual(expectedMessage, result);
    }
}
