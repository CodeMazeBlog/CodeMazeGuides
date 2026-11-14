using DynamicTypeInCSharp.Models;

namespace DynamicTypeInCSharp.Factories;

public class LoggerFactory
{
    public static Logger GetLogger()
    {
        return new Logger();
    }
}
