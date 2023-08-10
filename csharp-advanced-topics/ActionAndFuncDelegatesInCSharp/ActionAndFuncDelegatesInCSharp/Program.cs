using ActionAndFuncDelegatesInCSharp;
using static ActionAndFuncDelegatesInCSharp.DelegateService;
using static ActionAndFuncDelegatesInCSharp.FuncAndActionService;

var delegateService = new DelegateService();
var d1 = new DelegateMethod(delegateService.DisplayResult);
var delegateResult = d1(3, 5);
Console.WriteLine($"Delegate method result: {delegateResult}");

var funcAndActionService = new FuncAndActionService();
var func = new Func<int, int, int>(CalculateValue);
var funcResult = func(2, 5);
Console.WriteLine($"Func method result: {funcResult}");

Console.Write($"Action method result:");
var action = new Action<int>(PrintValue);
action(123);