using ActionAndFuncDelegates;

Console.WriteLine("== USING DELEGATES ==");
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

Console.WriteLine("\r\n== USING ACTION<> ==");

void AddTwo(int number)
{
    Console.WriteLine($"Action has added 2 to the number {number}: {number + 2}");
}

void SubtractTwo(int number)
{
    Console.WriteLine($"Action has subtracted 2 from the number {number}: {number - 2}");
}

ActionClass.Manipulator += AddTwo;
ActionClass.Manipulator += SubtractTwo;
ActionClass.Execute(10);

Console.WriteLine("\r\n== USING FUNC<> ==");

int AddTwoAndReturn(int number)
{
    Console.Write($"Func<> is adding 2 to the number {number}: ");
    return number + 2;
}

FuncClass.Manipulate += AddTwoAndReturn;
FuncClass.Execute(10);