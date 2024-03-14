using ActionAndFuncDelegatesInCsharp.Action;
using ActionAndFuncDelegatesInCsharp.Func;

#region Action delegate
ActionDelegate actionDelegate = new ActionDelegate();
actionDelegate.PrintNumber(1000);

Action<int> PrintNumber = actionDelegate.PrintNumberNamedMethod;
PrintNumber(1000);
#endregion

#region Func delegate
FuncDelegate funcDelegate = new FuncDelegate();
var sum = funcDelegate.Sum(10, 50);
Console.WriteLine("Sum is: " + sum);

Func<int, int, int> Sum = funcDelegate.SumTwoNumbers;
var sum2 = Sum(30, 2);
Console.WriteLine("Sum is: " + sum2);
#endregion