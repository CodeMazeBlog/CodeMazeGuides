namespace ActionAndFuncDelegatesInCSharp;

public class ActionExamples
{
    public static void LogString(string value)
    {
        Console.WriteLine($"Logging string: \"{value}\"");
    }

    public static void MethodReferenceExample(string value)
    {
        Action<string> action = new Action<string>(LogString);
        action(value); // Logging string: "Sample value" 
    }

    public static Action<string> uppercaseString = delegate(string word)
    {
        string modifiedWord = word.ToUpper();
        Console.WriteLine($"Original word: {word}. Modified word: {modifiedWord}.");
    };

    public static void AnonymousMethodExample(string word)
    {
        uppercaseString(word); // Original word: CodeMaze. Modified word: CODEMAZE.
    }

    public static Action<int> printSquare = (int number) =>
    {
        int square = number * number;
        Console.WriteLine($"Square of {number} is {square}.");
    };

    public static void LambdaExpressionExample(int number)
    {
        printSquare(number); // Square of 5 is 25.
    }
}