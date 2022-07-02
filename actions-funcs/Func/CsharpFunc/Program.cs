// See https://aka.ms/new-console-template for more information

// Simple Func delegates with single parameters
Func<string> greetings = () => "Hello World!";
Console.WriteLine(greetings());

// Func delegate with bool return type and multiple parameters
Func<string, string, bool> checkInput = (wordOne, wordTwo) =>
wordOne.Equals(wordTwo);
Console.WriteLine(checkInput("CodeMaze", "CodeMaze"));

// Func delegates Closures
Func<int, int> customMultiple = multipleBy();
Console.WriteLine(customMultiple(8));
Func<int, int> multipleBy()
{
    var num = 7;
    return n => n * num;
}