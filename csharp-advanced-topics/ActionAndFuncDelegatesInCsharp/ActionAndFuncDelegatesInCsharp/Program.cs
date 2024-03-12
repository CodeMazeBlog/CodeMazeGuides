using ActionAndFuncDelegatesInCsharp.Action;
using ActionAndFuncDelegatesInCsharp.Func;

#region Action delegate
ActionDelegate actionDelegate = new ActionDelegate();
actionDelegate.Action_PrintNumber(1000);

Action<int> ActionUsingNamedMethod = actionDelegate.Action_NamedMethod_Example;
ActionUsingNamedMethod(1000);
#endregion

#region Func delegate
FuncDelegate funcDelegate = new FuncDelegate();
var sum = funcDelegate.Func_Sum(10, 50);
Console.WriteLine("Sum is: " + sum);

Func<int, int, int> funcUsingNamedMethod = funcDelegate.Func_NamedMethod_Example;
var sum2 = funcUsingNamedMethod(30, 2);
Console.WriteLine("Sum is: " + sum2);
#endregion