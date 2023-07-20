using DelegateExamples;
using System;

Console.WriteLine("Action Delegate Example:");
DelegateExamplesManager.ActionExample();

// Add a separator between the examples
Console.WriteLine("\n---------------------------------------\n");

Console.WriteLine("Func Delegate Example:");
DelegateExamplesManager.FuncExample();

// Wait for the user to press a key to exit
Console.WriteLine("\nPress any key to exit...");
Console.ReadKey();