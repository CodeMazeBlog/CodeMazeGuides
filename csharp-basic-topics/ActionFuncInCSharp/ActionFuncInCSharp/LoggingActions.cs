using System.Text.Json;

namespace ActionFuncInCSharp
{
    public static class LoggingActions
    {
        public static Action<object> LogObjectsToConsole => 
            obj => Console.WriteLine($"{obj.GetType().Name}: {JsonSerializer.Serialize(obj)}");
    }
}
