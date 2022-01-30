// See https://aka.ms/new-console-template for more information
using ActionAndFuncInCSharp;

Console.WriteLine("Action Examples");
var actionExamples = new ExamplesForAction();
actionExamples.ActionPointsToArgumentlessMethod();
actionExamples.ActionPointsToMethodWithArguments();
actionExamples.ActionPointsToLambda();


Console.WriteLine("Func Examples");
var funcExmaples = new ExamplesForFunc();
funcExmaples.FuncPointsToArgumentlessMethod();
funcExmaples.FuncPointsToMethodWithArguments();
funcExmaples.FuncPointsToLambda();
await funcExmaples.FuncPointsToAsyncMethod();