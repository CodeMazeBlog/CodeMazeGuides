Action<int, int> printSumOfSquares = (a, b) => Console.WriteLine((a * a) + (b * b));
printSumOfSquares(3, 3);

static void TakeActionAndPrintSumOfSquares(Action<int, int> action)
{
    action(7, 14);
}
TakeActionAndPrintSumOfSquares(printSumOfSquares);

static string characterCount(string word)
{
    int count = word.Length;
    return $"There are {count} characters in the word {word}";
}
Func<string, string> TakeActionAndCountCharacters = characterCount;
Console.WriteLine(TakeActionAndCountCharacters("Hello"));
