using Delegates.After;
using Delegates.Before;

var text = "Code Maze";

Console.WriteLine("Brfore:");
WithoutDelegates.PrintInUpperCase(text);
WithoutDelegates.PrintInLowerCase(text);

Console.WriteLine();
Console.WriteLine("After:");

Func<string, string> operation = x => x.ToUpper();
Action<string> print = x => Console.WriteLine("Print in Upper Case: {0}", x);
WithDelegates.PrintProcessedText(text, print, operation);

operation = x => x.ToLower();
print = x => Console.WriteLine("Print in Lower Case: {0}", x);
WithDelegates.PrintProcessedText(text, print, operation);