// See https://aka.ms/new-console-template for more information
using FuncActionDelegateSample;

Func<int, int, int> Operation;

Action<string, string> Print;

var funcDelegate = new FuncActionDelegate();

Operation = funcDelegate.Subtract;
Console.WriteLine(Operation(4,8));

Print = funcDelegate.PrintFullName;
Print("Code", "Maze");





