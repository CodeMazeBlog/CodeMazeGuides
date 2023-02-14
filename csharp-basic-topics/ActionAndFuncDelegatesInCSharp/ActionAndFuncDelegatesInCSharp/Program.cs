using ActionAndFuncDelegatesInCSharp.CustomDelegate;
using ActionAndFuncDelegatesInCSharp.Func;
using ActionAndFuncDelegatesInCSharp.Action;

Console.WriteLine("With Custom Delegate");
Console.WriteLine(CustomDelegate.GetValueFromCustomDelegate());
Console.WriteLine("-------------------------------------------");
Console.WriteLine("With Func");
Console.WriteLine(FuncMethod.GetValueFromFuncLambda());
Console.WriteLine(FuncMethod.GetValueFromFunc());
Console.WriteLine("-------------------------------------------");
Console.WriteLine("With Action");
ActionMethod.GetValueFromActionLambda();
ActionMethod.GetValueFromAction();
