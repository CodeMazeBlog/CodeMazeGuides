namespace ActionAndFuncDelegatesInCSharp
{
    public class Loggers
    {
        public void LogMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void LogMessageWithTimeStamp(string message)
        {
            Console.WriteLine($"{DateTime.Now} - {message}");
        }
    }
}
