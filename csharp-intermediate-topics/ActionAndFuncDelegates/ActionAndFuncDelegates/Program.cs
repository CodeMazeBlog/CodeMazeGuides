using ActionAndFuncDelegates;

void WriteToConsole(string message)
{
    message.Trim();
    Console.WriteLine("Delegate is writing to the console...");
    Console.WriteLine(message);
}

DelegateClass.Writers = WriteToConsole;
DelegateClass.Execute("Hello, World!");