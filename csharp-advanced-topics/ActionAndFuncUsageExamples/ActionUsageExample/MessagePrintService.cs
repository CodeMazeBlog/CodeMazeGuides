using System.Diagnostics;

namespace ActionUsageExample
{
    public class MessagePrintService : IMessagePrintService
    {
        public void WriteToConsole(string message)
        {
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine($"Message: {message}");
            Console.WriteLine("-----------------------------------------------------");
        }

        public void WriteToDebugOutput(string message)
        {
            Debug.WriteLine("-----------------------------------------------------");
            Debug.WriteLine($"Message: {message}");
            Debug.WriteLine("-----------------------------------------------------");
        }
    }
}
