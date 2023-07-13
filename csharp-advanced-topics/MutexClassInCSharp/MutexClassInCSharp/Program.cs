namespace MutexClassInCSharp;

public static class Program
{
    private static void Main(string[] args)
    {
        string fileName = args.FirstOrDefault() ?? "numbers.txt";
        WriteNumbers(fileName);
    }

    public static void WriteNumbers(string fileName)
    {
        using Mutex mutex = new Mutex(initiallyOwned: false, "Global\\numbers_output");

        try
        {
            mutex.WaitOne();
        }
        catch (AbandonedMutexException)
        {
            File.WriteAllText(fileName, string.Empty);
        }

        try
        {
            for (int number = 1; number <= 50; number++)
            {
                File.AppendAllText(fileName, $"{number} ");
                Thread.Sleep(100);
            }
        }
        finally
        {
            mutex.ReleaseMutex();
        }
    }
}
