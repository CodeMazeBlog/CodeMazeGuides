using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a list of names
        List<string> names = new List<string> { "Alice", "Bob", "Charlie" };

        // Define an Action delegate that takes a string and prints a greeting
        Action<string> greet = name => Console.WriteLine($"Hello, {name}!");

        // Iterate over each name in the list and apply the Action delegate
        names.ForEach(greet);
    }
}
