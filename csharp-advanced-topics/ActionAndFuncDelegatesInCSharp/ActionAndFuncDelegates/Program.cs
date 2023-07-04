//Executing Action delegates
ActionDelegateInCSharp actionDelegate = new();

Console.WriteLine("Executing Action Delegates");
actionDelegate.ExecuteWithoutParameter();
actionDelegate.ExecuteWithParameter(); 

//Executing  Action delegates using Anonymous Method
Console.WriteLine("\nExecuting Action Delegates using Anonymous Methods");
actionDelegate.ExecuteWithoutParameterUsingAnonymousMethod();
actionDelegate.ExecuteWithParameterUsingAnonymousMethod();

//Executing  Action delegates using Lambda expressions
Console.WriteLine("\nExecuting Action Delegates using Lambda expressions");
actionDelegate.ExecuteWithoutParameterUsingLambdaExpressions();
actionDelegate.ExecuteWithParameterUsingLambdaExpressions();

//------------End of Action Delegates-----------

//Executing Func Delegate
FuncDelegateInCSharp funcDelegate = new();

Console.WriteLine("\nExecuting Func Delegates");
funcDelegate.ExecuteWithoutParameter();
funcDelegate.ExecuteWithParameter();

//calling Func delegates using Anonymous Method
Console.WriteLine("\nExecuting Func Delegates using Anonymous Method");
funcDelegate.ExecuteWithoutParameterUsingAnonymousMethod();
funcDelegate.ExecuteWithParameterUsingAnonymousMethod();

//calling Func delegates using Lambda Expression
Console.WriteLine("\nExecuting Func Delegates using Lambda Expression");
funcDelegate.ExecuteWithoutParameterUsingLambdaExpressions();
funcDelegate.ExecuteWithParameterUsingLambdaExpressions();


