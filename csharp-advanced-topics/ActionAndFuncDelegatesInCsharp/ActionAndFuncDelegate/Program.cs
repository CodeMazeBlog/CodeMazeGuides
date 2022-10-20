// See https://aka.ms/new-console-template for more information


//Action section
using ActionAndFuncDelegate.Actions;
using ActionAndFuncDelegate.Functions;

var actionExample = new ActionExample();
Console.WriteLine("Action section");

actionExample.RunWithParams(5, 5);

actionExample.RunWithoutParams();

Console.WriteLine();

//Func section
FuncExample funcExample = new FuncExample();
Console.WriteLine("Func section");

int sumResultWithParameters = funcExample.RunWithParams(5, 5);
Console.WriteLine($"Sum result(with parameters): {sumResultWithParameters}");

int sumResultWithoutParameters = funcExample.RunWithoutParams();
Console.WriteLine($"Sum result(no parameters): {sumResultWithoutParameters}");
