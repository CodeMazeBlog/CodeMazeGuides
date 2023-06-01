namespace Tests;

[TestClass]
public class ActionTests
{
    // Define the methods being tested
    private static void MethodName1(string message)
    {
        Console.WriteLine(message);
    }

    private static void MethodName2(string message)
    {
        Console.WriteLine(message);
    }

    [TestMethod]
    public void GivenMessage_WhenInvokingMethodName1_ThenWriteExpectedMessageToConsole()
    {
        // Arrange
        string expectedMessage = "Test Message";
        string actualOutput = "";

        // Act
        Action<string> delegateName1 = MethodName1;
        delegateName1.Invoke(expectedMessage);

        // Capture the console output
        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);
            MethodName1(expectedMessage);
            actualOutput = sw.ToString().Trim();
        }

        // Assert
        Assert.AreEqual(expectedMessage, actualOutput);
    }

    [TestMethod]
    public void GivenMessage_WhenInvokingMethodName2_ThenWriteExpectedMessageToConsole()
    {
        // Arrange
        string expectedMessage = "Test Message";
        string actualOutput = "";

        // Act
        Action<string> delegateName2 = new Action<string>(MethodName2);
        delegateName2.Invoke(expectedMessage);

        // Capture the console output
        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);
            MethodName2(expectedMessage);
            actualOutput = sw.ToString().Trim();
        }

        // Assert
        Assert.AreEqual(expectedMessage, actualOutput);
    }
}