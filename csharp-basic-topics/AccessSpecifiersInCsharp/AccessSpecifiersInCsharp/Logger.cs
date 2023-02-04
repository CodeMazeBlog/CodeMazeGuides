namespace AccessSpecifiersInCsharp
{
    internal class Logger
    {
        protected internal string LogMessage(string message)
        {
            return string.Format($"Logged at {DateTime.Now}, Message: {message}");
        }
    }
}
