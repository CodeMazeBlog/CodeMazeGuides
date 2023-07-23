namespace AccessModifiersInCsharp
{
    class DerivedLogger : Logger
    {
        public string LogMessageFromDerivedClass(string message)
        {
            return $"Derived Log: {LogMessage(message)}";
        }
    }
}
