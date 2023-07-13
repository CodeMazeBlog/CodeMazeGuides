const string fileName = "numbers.txt";

using Mutex mutex = new Mutex(initiallyOwned: false, "Global\\numbers_output", out bool mutexWasCreated);

mutex.WaitOne();

for (int number = 1; number <= 50; number++)
{
    File.AppendAllText(fileName, $"{number} ");
    Thread.Sleep(100);
}

mutex.ReleaseMutex();

// This class is for allowing the test project to access this assembly.
public class AssemblyAccessor { }
