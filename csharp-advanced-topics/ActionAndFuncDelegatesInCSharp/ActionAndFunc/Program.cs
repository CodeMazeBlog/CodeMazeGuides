// See https://aka.ms/new-console-template for more information

using ActionAndFunc;

Console.WriteLine("------------------------Action Delegate-----------------------");

var actionDelegate = new ActionDelegate();
var result = actionDelegate.ExecuteActionDelegate("Yohan");
Console.WriteLine(result);


Console.WriteLine("------------------------Func Delegate-----------------------");

var funcDelegate = new FuncDelegate();
var sumResult = funcDelegate.ExecuteFuncDelegate(3,5);
Console.WriteLine(sumResult);
