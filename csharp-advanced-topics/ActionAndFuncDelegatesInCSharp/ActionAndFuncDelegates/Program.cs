using ActionAndFuncDelegates.Logic;

ActionDelegateInCSharp actionDelegate = new(new Counter(10));

//Executing Action delegates
Console.WriteLine("Executing Action Delegates");
actionDelegate.ExecuteWithoutParameter();
Console.WriteLine($"without parameter: {actionDelegate.counter.Count}");

actionDelegate.ExecuteWithParameter();
Console.WriteLine($"with parameter: {actionDelegate.counter.Count}");


//Executing  Action delegates using Anonymous Method
Console.WriteLine("\nExecuting Action Delegates using Anonymous Methods");
actionDelegate.ExecuteWithoutParameterUsingAnonymousMethod();
Console.WriteLine($"without parameter using anonymous method: {actionDelegate.counter.Count}");

actionDelegate.ExecuteWithParameterUsingAnonymousMethod();
Console.WriteLine($"with parameter using anonymous method: {actionDelegate.counter.Count}");

//Executing  Action delegates using Lambda expressions
Console.WriteLine("\nExecuting Action Delegates using Lambda expressions");
actionDelegate.ExecuteWithoutParameterUsingLambdaExpressions();
Console.WriteLine($"without parameter using lambda expressions: {actionDelegate.counter.Count}");

actionDelegate.ExecuteWithParameterUsingLambdaExpressions();
Console.WriteLine($"with parameter using lambda expressions: {actionDelegate.counter.Count}");

//------------End of Action Delegates-----------


FuncDelegateInCSharp funcDelegate = new(new Counter(20));

//Executing Func Delegate
Console.WriteLine("\nExecuting Func Delegates");
Console.WriteLine($"without parameter: {funcDelegate.ExecuteWithoutParameter()}");
Console.WriteLine($"with parameter: {funcDelegate.ExecuteWithParameter()}");

//calling Func delegates using Anonymous Method
Console.WriteLine("\nExecuting Func Delegates using Anonymous Method");
Console.WriteLine($"without parameter using anonymous method: {funcDelegate.ExecuteWithoutParameterUsingAnonymousMethod()}");
Console.WriteLine($"with parameter using anonymous method: {funcDelegate.ExecuteWithParameterUsingAnonymousMethod()}");

//calling Func delegates using Lambda Expression
Console.WriteLine("\nExecuting Func Delegates using Lambda Expression");
Console.WriteLine($"without parameter using lambda expressions: {funcDelegate.ExecuteWithoutParameterUsingLambdaExpressions()}");
Console.WriteLine($"with parameter using lambda expressions: {funcDelegate.ExecuteWithParameterUsingLambdaExpressions()}");


