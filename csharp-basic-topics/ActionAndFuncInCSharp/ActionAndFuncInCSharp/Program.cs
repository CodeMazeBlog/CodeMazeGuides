// See https://aka.ms/new-console-template for more information
using ActionAndFuncInCSharp;

Console.WriteLine("Action Examples");
var actionExamples = new ExamplesForAction();
actionExamples.RunExamples();


Console.WriteLine("Func Examples");
var funcExmaples = new ExamplesForFunc();
await funcExmaples.RunExamples();