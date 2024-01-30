using System.Runtime.CompilerServices;
using ILogger = Serilog.ILogger;

namespace Api;

public static class LoggerExtensions
{
    // In such a case, the Here extension method will not be able to correctly determine the class name.
    // It will return the file name instead, which might not be the same as the class name if there are multiple classes in the file.
    // Unfortunately, there's no built-in way in .NET to get the class name of the caller.
    // The CallerMemberName attribute can get the method name, and the CallerFilePath attribute can get the file path,
    // but there's no CallerClassName attribute.
    public static ILogger Here(this ILogger logger, [CallerFilePath] string filePath = "",
        [CallerMemberName] string memberName = "")
    {
        var className = Path.GetFileNameWithoutExtension(filePath);
        return logger.ForContext("ClassName", className).ForContext("MethodName", memberName);
    }
}