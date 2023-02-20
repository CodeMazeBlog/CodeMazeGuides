// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

//Example of Action delegate
static void PrintMessage() 
{ 
    Console.WriteLine("Hello, world!"); 
}
static void ExecuteAction(Action action) 
{ 
    action(); 
}
ExecuteAction(PrintMessage);

//Example of Func delegates
static int AddNumbers(int a, int b) 
{ 
    return a + b; 
}
static void ExecuteFunc(Func<int, int, int> func) 
{ 
    int result = func(10, 20); 
    Console.WriteLine("Result = " + result); 
}

ExecuteFunc(AddNumbers);