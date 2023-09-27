namespace ActionFuncDelegatesInCsharp
{
    // Define a class that has a method that takes an Action delegate as a callback.
    public class Logger
    {
        // Invoke the logMessageDelegate delegate.
        public void LogMessage(string message, Action<string> logMessageDelegate)
        {
            logMessageDelegate.Invoke(message);
        }
    }

    public class ExecuteLogger
    {
        public void Execute()
        {
            // Create a new Logger object.
            Logger logger = new Logger();

            // Create an Action delegate that logs a message to the console.
            Action<string> logMessageDelegate = (message) => Console.WriteLine(message);


            // Log a message.
            logger.LogMessage("Action Delegates!", logMessageDelegate);
        }

    }
}
