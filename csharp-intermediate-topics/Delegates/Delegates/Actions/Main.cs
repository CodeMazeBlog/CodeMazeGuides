namespace Delegates.Actions;

public sealed class Main
{
    public void LogWithAction()
    {
        Action<string> logAction = s => Console.WriteLine($"Message: {s}");
        logAction("Hello World!");
    }
    
    public void LogWithDelegate()
    {
        LogDelegate logDelegate = s => Console.WriteLine($"Message: {s}");
        logDelegate("Hello World!");
    }
}