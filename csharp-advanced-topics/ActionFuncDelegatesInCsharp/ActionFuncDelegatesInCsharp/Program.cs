// Action<T> Delegates examples -> Methods that takes parameters but returns nothing (void type)

Console.WriteLine("\n***************** Action<> Delegate Methods ***************\n");

// First way of initialization
Action<string> delegateName1 = ActionMethods.MethodName1;
ActionMethods.MethodName1("Version 1: Initialization of Action delegate");

// Second way of initialization
Action<string> delegateName2 = new Action<string>(ActionMethods.MethodName2);
ActionMethods.MethodName2("Version 2: Initialization of Action delegate");


// Func<T> Delegates examples : Methods that takes parameters and returns a value
Console.WriteLine("\n**************** Func<> Delegate Methods *****************\n");

// First way of initialization
Func<int, int, string> addition1 = FuncMethods.DisplayAddition;

// Second way of initialization
Func<int, int, int> addition2 = new Func<int, int, int>(FuncMethods.Addition);
Func<string, string, string> completeName = new Func<string, string, string>(FuncMethods.ShowCompleteName);

string additionPrint = addition1(5, 6);
Console.WriteLine(additionPrint);

int addition = addition2(3, 4);
Console.WriteLine(addition);

string completeNamePrint = completeName("Code", "Maze");
Console.WriteLine(completeNamePrint);