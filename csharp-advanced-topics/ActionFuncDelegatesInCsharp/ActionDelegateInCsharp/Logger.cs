public class Logger
{
    // Invoke the logMessageDelegate delegate.
    public void LogMessage(string message, Action<string> logMessageDelegate)
    {
        logMessageDelegate.Invoke(message);
    }
}

