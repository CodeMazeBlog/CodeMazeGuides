using System;

// Action delegate with single parameter
Action<int> substructTwo = (num) => Console.WriteLine(num - 2);
substructTwo(50);

// Action delegate with Multiple parameter
Action<string, string> displayCaps = (wordOne, wordTwo) => Console.WriteLine(string.Concat(wordOne, wordTwo).ToUpper());
displayCaps("This", "Rocks");