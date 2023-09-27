namespace ActionDelegateInCsharp
{
    public class Logger
    {
        // Invoke the logMessageDelegate delegate.
        public void LogMessage(string message, Action<string> logMessageDelegate)
        {
            logMessageDelegate.Invoke(message);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
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