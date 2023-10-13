using ActionAndFuncDelegatesInCSharp;



Action<string> greet = ActionDelegate.greet;

// Use the Action delegate to greet two different people
greet("John");
greet("Alice");

//Use the function delegate to add two digit
Func<int, int, int> add = FuncDelegate.add;
int result = add(5, 3);
Console.WriteLine($"sum = {result}");
