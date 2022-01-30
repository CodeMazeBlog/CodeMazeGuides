using ActionsAndFuncsInCsharp.Examples;

// delegate example
Console.WriteLine("Running Delegate example");
var delegateExample = new DelegateExample();

delegateExample.RunExample();


// Action example
Console.WriteLine("Running Action example");
var actionExample = new ActionExample();

actionExample.RunExample();

// Func example
Console.WriteLine("Running Func example");
var funcExample = new FuncExample();

funcExample.RunExample(1, 2);


Console.WriteLine("Examples complete");
Console.ReadKey();
