using System.Threading;

namespace RunCodeInNewThreadConsoleApplication;

public static class ThreadInfo
{
    public static string Log()
    {
        return $"Thread [{Thread.CurrentThread.ManagedThreadId}] ThreadPool: {Thread.CurrentThread.IsThreadPoolThread}:";
    }
}