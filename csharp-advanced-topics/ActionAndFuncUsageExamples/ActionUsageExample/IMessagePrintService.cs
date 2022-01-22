namespace ActionUsageExample
{
    public interface IMessagePrintService
    {
        public void WriteToConsole(string message);
        public void WriteToDebugOutput(string message);
    }
}
