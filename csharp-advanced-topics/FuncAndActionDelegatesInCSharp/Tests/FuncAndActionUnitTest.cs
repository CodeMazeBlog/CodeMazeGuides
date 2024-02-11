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

    public static string GetNotification(string notification)
    {
        Func<string, string> notify
            = (string message) => message == "build project" ? "building" : "unkown notification";
        return notify(notification);
    }

    [TestMethod]
    public void WhenNotifying_ThenWritesCorrectMessageToConsole()
    {
        string expectedMessage = "Received message: 'build project'";
        TextWriter oldOut = Console.Out;

        using (StringWriter stringWriter = new StringWriter())
        {
            Console.SetOut(stringWriter);
            SendNotification();

            string actualConsoleOutput = stringWriter.ToString().Trim();
            Assert.AreEqual(expectedMessage, actualConsoleOutput);
        }

        Console.SetOut(oldOut);
    }

    [TestMethod]
    public void WhenNotifying_ThenReceiveResult()
    {
        string expectedMessage = "building";

        // known notification
        string result = GetNotification("build project");
        Assert.AreEqual(expectedMessage, result);

        // unknown notification
        expectedMessage = "unkown notification";
        result = GetNotification("C# supports Generics");
        Assert.AreEqual(expectedMessage, result);
    }
}
