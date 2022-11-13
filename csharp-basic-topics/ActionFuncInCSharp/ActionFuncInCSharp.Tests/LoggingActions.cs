using System.Text.Json;

namespace ActionFuncInCSharp.Tests
{
    public static class LoggingActions
    {
        public static Action<object> LogObjectsToConsole => 
            obj => Console.WriteLine($"{obj.GetType().Name}: {JsonSerializer.Serialize(obj)}");
    }
}
