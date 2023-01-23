// See https://aka.ms/new-console-template for more information
public class DelegateImplementationProvider
{
    readonly IDateTimeProvider _dateTimeProvider;
    readonly IConsoleWrapper _consoleWrapper;
    public DelegateImplementationProvider(IDateTimeProvider dateTimeProvider, IConsoleWrapper uIImplementor)
    {
        _dateTimeProvider = dateTimeProvider;
        _consoleWrapper = uIImplementor;
    }
    public DateTime PrintWithColor(ConsoleColor color, String msg)
    {
        var logDate = _dateTimeProvider.GetDateTimeUTC();
        _consoleWrapper.SetColor(color);
        _consoleWrapper.WriteText($"{logDate} {msg}");
        return logDate;
    }
}
