using ActionAndFuncDelegates;

void WriteToConsole(string message)
{
    Console.WriteLine("Delegate is writing to the console...");
    Console.WriteLine(message);
}

void WriteToDb(string message)
{
    Console.WriteLine("Delegate is writing to the database...");

    // Database logic...
}

DelegateClass.Writers = WriteToConsole;
DelegateClass.Writers += WriteToDb;
DelegateClass.Execute("Hello, World!");