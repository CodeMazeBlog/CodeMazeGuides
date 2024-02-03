using System.Runtime.CompilerServices;
using ILogger = Serilog.ILogger;

namespace Api;

public static class LoggerExtensions
{
    public static ILogger Here<T>(this ILogger logger, [CallerMemberName] string memberName = "")
    {
        var className = typeof(T).Name;

        return logger.ForContext("ClassName", className).ForContext("MethodName", memberName);
    }
}