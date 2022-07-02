// See https://aka.ms/new-console-template for more information

// Basic Action with no parameters 
Action greetings = () => Console.WriteLine("Hello, World!");
greetings();

// Action delegate with single parameter
Action<int> substructTwo = (num) => Console.WriteLine(num - 2);
substructTwo(50);

// Action delegate with Multiple parameter
Action<string, string> caps = (wOne, wTwo) => Console.WriteLine(string.Concat(wOne, wTwo).ToUpper());
caps("This", "Rocks");