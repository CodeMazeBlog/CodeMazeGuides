// Action<T> Delegates examples -> Methods that takes parameters but returns nothing (void type)
static void MethodName1(string message)
{
    Console.WriteLine(message);
}

static void MethodName2(string message)
{
    Console.WriteLine(message);
}


Console.WriteLine("\n***************** Action<> Delegate Methods ***************\n");

// First way of initialization
Action<string> delegateName1 = MethodName1;
MethodName1("Version 1: Initialization of Action delegate");

// Second way of initialization
Action<string> delegateName2 = new Action<string>(MethodName2);
MethodName2("Version 2: Initialization of Action delegate");


// Func<T> Delegates examples : Methods that takes parameters and returns a value
static int Addition(int x, int y)
{
    return x + y;
}

static string DisplayAddition(int a, int b)
{
    return $"Addition of {a} and {b} is {a + b}";
}
static string ShowCompleteName(string firstName, string lastName)
{
    return $"Author of this Article is {firstName} {lastName}";
}


Console.WriteLine("\n**************** Func<> Delegate Methods *****************\n");

// First way of initialization
Func<int, int, string> addition1 = DisplayAddition;

// Second way of initialization
Func<int, int, int> addition2 = new Func<int, int, int>(Addition);
Func<string, string, string> completeName = new Func<string, string, string>(ShowCompleteName);

int addition = addition2(3, 4);
Console.WriteLine(addition);

string additionPrint = addition1(5, 6);
Console.WriteLine(additionPrint);

string completeNamePrint = completeName("Code", "Maze");
Console.WriteLine(completeNamePrint);