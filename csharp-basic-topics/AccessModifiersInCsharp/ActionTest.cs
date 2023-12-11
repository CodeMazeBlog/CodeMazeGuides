using System;
public class PrintMessageTests
{
    public void TestPrintMessageAction()
    {
        string expectedMessage = "Action delegate called!";
        string actualMessage = "";

        Action printMessage = () =>
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Action delegate called!");
            actualMessage = sb.ToString();
        };

        printMessage.Invoke();

        Assert.AreEqual(expectedMessage, actualMessage);
    }
}


public class ButtonClickEventHandlerTests
{
    public void TestButtonClickEvent()
    {
        string expectedMessage = "Button clicked!";
        string actualMessage = "";

        Button mockButton = new Button();

        mockButton.Click += () =>
        {
            actualMessage = "Button clicked!";
        };

        mockButton.PerformClick();

        Assert.AreEqual(expectedMessage, actualMessage);
    }
}

public class LogMessageTests
{
    public void TestLogMessageAction()
    {
        string expectedLogMessage = "Log message from Action delegate";
        string actualLogMessage = "";

        Action logAction = () => LogMessage("Log message from Action delegate");
        logAction.Invoke();

        actualLogMessage = GetLogMessage();

        Assert.AreEqual(expectedLogMessage, actualLogMessage);
    }

    private string GetLogMessage()
    {
        return "Log message from Action delegate";
    }
}
