public static class ActionDelegate
{
    public static void Error(string message)
          => Console.WriteLine(message);

    public static void Information(Action<string> logger, string message)
          => logger(message);

    public static void Warning(Action logger)
          => logger();
}

