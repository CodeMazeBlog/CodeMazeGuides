Console.WriteLine("---");

var del = new ActionFuncDelegates.Delegate();
var sum = del.Run();
Console.WriteLine($"Sum: {sum}");

Console.WriteLine("---");

del.ActionRun();
var actionDel = new ActionFuncDelegates.ActionDelegate();
actionDel.Run();

Console.WriteLine("---");

del.FuncRun();
var funcDel = new ActionFuncDelegates.FuncDelegate();
funcDel.Run();

Console.WriteLine("---");

del.PredicateRun();
var predDel = new ActionFuncDelegates.PredicateDelegate();
predDel.Run();