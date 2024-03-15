namespace MutexClassInCSharp;

public static class Program
{
    private static void Main(string[] args)
    {
        var fileName = args.FirstOrDefault() ?? "numbers.txt";
        WriteNumbers(fileName);
    }

    public static void WriteNumbers(string fileName)
    {
        using var mutex = new Mutex(initiallyOwned: false, "Global\\numbers_output");

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
            for (var number = 1; number <= 50; number++)
            {
                File.AppendAllText(fileName, $"{number} ");
                // Sleep only for 1ms to speed up testing; article specifies 100ms.
                Thread.Sleep(1);
            }
        }
        finally
        {
            mutex.ReleaseMutex();
        }
    }
}
