public class ActionDelegate
{
    public void Error(string message)
          => Console.WriteLine(message);

    public void Information(Action<string> logger, string message)
          => logger(message);

    public void Warning(Action logger)
          => logger();
}

