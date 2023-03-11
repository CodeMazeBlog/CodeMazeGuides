namespace AccessModifiersInCsharp
{
    internal class Logger
    {
        protected internal string LogMessage(string message)
        {
            return $"Logged at {DateTime.Now}, Message: {message}";
        }
    }
}
