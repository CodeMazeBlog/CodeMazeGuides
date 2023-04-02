using System;

// Action delegate
static void PrintMessage(string message)
{
    Console.WriteLine(message);
}

Action<string> print = PrintMessage;
print("Hello, World!");

// Func delegate
static int Add(int a, int b)
{
    return a + b;
}

Func<int, int, int> add = Add;
int result = add(3, 4);
Console.WriteLine(result);

// Delegates in LINQ Queries
List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
List<int> filteredNumbers = numbers.Where(n => n > 5).ToList();

foreach (var number in filteredNumbers)
{
    Console.WriteLine(number);
}

List<string> words = new List<string> { "hello", "world", "goodbye" };
List<int> lengths = words.Select(s => s.Length).ToList();

foreach (var wordLength in lengths)
{
    Console.WriteLine(wordLength);
}