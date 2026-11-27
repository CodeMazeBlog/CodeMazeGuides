using Microsoft.Extensions.Logging;

namespace LoggingAPI;

public sealed class InMemoryLoggerProvider : ILoggerProvider
{
    public List<string> Messages { get; } = [];

    public ILogger CreateLogger(string categoryName) => new InMemoryLogger(categoryName, Messages);

    public void Dispose() { }
}

public sealed class InMemoryLogger(string categoryName, List<string> messages) : ILogger
{
    public IDisposable? BeginScope<TState>(TState state) where TState : notnull => null;

    public bool IsEnabled(LogLevel logLevel) => logLevel != LogLevel.None;

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state,
        Exception? exception, Func<TState, Exception?, string> formatter)
    {
        if (!IsEnabled(logLevel))
            return;

        messages.Add($"{logLevel}: {categoryName}: {formatter(state, exception)}");
    }
}
