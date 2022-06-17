using System;
// See https://aka.ms/new-console-template for more information

// Simple Func delegates with single parameters
Func<string> greetings = () => "Hello World";
Console.WriteLine(greetings());