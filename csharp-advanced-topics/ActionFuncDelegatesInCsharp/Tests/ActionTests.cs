namespace Tests;

[TestClass]
public class ActionTests
{
    [TestMethod]
    public void GivenMessage_WhenInvokingMethodName1_ThenAssignExpectedMessageToActual()
    {
        // Arrange
        string expected = "Version 1: Initialization of Action delegate";
        string? actual = null;

        // Act
        Action<string> delegateName1 = ActionMethods.MethodName1;
        delegateName1 += (s) => actual = s;
        delegateName1.Invoke("Version 1: Initialization of Action delegate");

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void GivenEmptyMessage_WhenInvokingMethodName2_ThenWriteExpectedMessageToActual()
    {
        // Arrange
        string expected = "Version 2: Initialization of Action delegate";
        string? actual = null;

        // Act
        Action<string> delegateName2 = new Action<string>(ActionMethods.MethodName2);
        delegateName2 += (s) => actual = s;
        delegateName2.Invoke("Version 2: Initialization of Action delegate");

        // Assert
        Assert.AreEqual(expected, actual);
    }
}