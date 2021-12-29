namespace ActionAndFuncDelegatesInCsharp;

public class Program
{
    static int IncrementByTwo(int number) => number + 2;

    static int IncrementByThree(int number) => number + 3;

    static void DisplayScore(int number) => Console.WriteLine($"{number}");

    static void DisplayScoreWithExplanation(int number)
        => Console.WriteLine($"The team has scored {number} points");

    static void Main(string[] args)
    {
        Console.WriteLine("\nInitialise new counter and show the score with both normal and fancy implementations");
        var counter = new BasketballCounter();
        counter.ShowScore(DisplayScore);
        counter.ShowScore(DisplayScoreWithExplanation);

        Console.WriteLine("\nA two-pointer has been scored, show score with normal implementation");
        counter.UpdateScore(IncrementByTwo);
        counter.ShowScore(DisplayScore);

        Console.WriteLine("\nA three-pointer has been scored, show score with fancy implementation");
        counter.UpdateScore(IncrementByThree);
        counter.ShowScore(DisplayScoreWithExplanation);

        Console.ReadLine();
    }
}