public class Delegate
{
    private const string _logMessage = "The operation finished in 1.1 sec";

    public delegate void ConsoleLoggingProvider(string logMessage);

    public void InformationLevelConsoleLogger(string information)
        => Console.Write($"Additional information: {information}\r\n");

    public void InvokeSimpleDelegate()
    {
        ConsoleLoggingProvider logger = InformationLevelConsoleLogger;

        logger.Invoke(_logMessage);
        logger(_logMessage);
    }
}