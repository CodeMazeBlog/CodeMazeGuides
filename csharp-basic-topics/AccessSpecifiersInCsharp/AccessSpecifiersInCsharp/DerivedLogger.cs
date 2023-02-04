namespace AccessSpecifiersInCsharp
{
    class DerivedLogger : Logger
    {
        public string LogMessageFromDerivedClass(string message)
        {
            return string.Format($"Derived Log: {LogMessage(message)}");
        }
    }
}
