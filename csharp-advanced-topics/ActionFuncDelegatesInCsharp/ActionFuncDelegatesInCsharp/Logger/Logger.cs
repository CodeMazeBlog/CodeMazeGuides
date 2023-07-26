namespace ActionFuncDelegatesInCsharp.Logger
{
    public class DelegateLogger : ILogger
    {
        public void Log(string message, params object[] args)
        {
            Console.WriteLine(message, args);
        }
    }
}
