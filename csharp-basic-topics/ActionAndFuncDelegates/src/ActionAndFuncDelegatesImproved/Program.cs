using ActionAndFuncDelegates;

// Instantiate delegates
var addValues = new Func<int, int, double>(MyMathOperations.AddTwoNumbers);
var subtractValues = new Func<int, int, double>(MyMathOperations.SubtractTwoNumbers);
var writeOutput = new Action<string>(MyOutputOperations.WriteOutput);

// Invoke delegates
writeOutput($"{addValues(20, 10)}");
writeOutput($"{subtractValues(20, 10)}");
