using CSharpActionFuncApp;

int result;
var delegateInAction = new DelegatesInAction();
result = delegateInAction.ActionDelegateInAction(10, 10);
Console.WriteLine($"Addition using ActionDelegate = {result}");

result = delegateInAction.ActionDelegateInActionUsingAnotherWay(10, 20);
Console.WriteLine($"Addition using ActionDelegateAnotherway = {result}");

result = delegateInAction.FuncDelegateInAction(20, 20);
Console.WriteLine($"Sum using FuncDelegate = {result}");

result = delegateInAction.FuncDelegateInActionUsingAnotherWay(20, 30);
Console.WriteLine($"Sum using FuncDelegateAnotherWay = {result}");

Console.ReadKey();
