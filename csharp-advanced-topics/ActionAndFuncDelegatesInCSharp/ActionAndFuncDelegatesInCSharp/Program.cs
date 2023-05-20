// Define an Action delegate that takes two int parameters
Action<int, int> printSumOfSquares = (a, b) => Console.WriteLine((a * a) + (b * b));
//Invoke method
printSumOfSquares(3, 3);

//Define a method that takes an Action delegate as a parameter
static void TakeActionAndPrintSumOfSquares(Action<int, int> action)
{
    action(7, 14);
}
//pass in our printSumOfSquares action as a parameter
TakeActionAndPrintSumOfSquares(printSumOfSquares);

//Func Delegates
//Define a method that returns the number of characters in a string
static string characterCount(string word)
{
    int count = word.Length;
    return $"There are {count} characters in the word {word}";
}
//Invoke the method
Func<string, string> TakeActionAndCountCharacters = characterCount;
Console.WriteLine(TakeActionAndCountCharacters("Hello"));