using System;
// See https://aka.ms/new-console-template for more information

// Func delegate with bool return type and multiple parameters
Func<string, string, bool> checkInput = (wordOne, wordTwo) => wordOne.Equals(wordTwo);
Console.WriteLine(checkInput("CodeMaze", "CodeMaze"));