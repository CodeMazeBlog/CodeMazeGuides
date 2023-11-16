public class Delegate
{
    string logMessage = "The operation finished in 1.1 sec";

    //Declaration of a delegate.
    public delegate void ConsoleLoggingProvider(string logMessage);

    //Logger
    public void InformationLevelConsoleLogger(string information)
        => Console.Write($"Additional information: {information}\r\n");

    public void InvokeSimpleDelegate()
    {
        ConsoleLoggingProvider logger = InformationLevelConsoleLogger;

        //Two ways of invocation
        logger.Invoke(logMessage);
        logger(logMessage);

    }
}