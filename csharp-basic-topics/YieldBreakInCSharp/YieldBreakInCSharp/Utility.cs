namespace YieldBreakInCSharp;

public static class Utility
{
    private static readonly Random random = new();

    public static IEnumerable<int> GenerateRandomYears()
    {
        int year;
        while (true)
        {
            year = random.Next(1900, 2023);
            yield return year;

            if (year % 4 == 0)
            {
                Console.WriteLine($"{Environment.NewLine}Encountered Leap Year:{year}");
                yield break;
            }
        }
    }

    public static IEnumerable<int> GenerateRandomYearsWithBreak()
    {
        int year;
        while (true)
        {
            year = random.Next(1900, 2023);
            yield return year;

            if (year % 4 == 0)
            {
                Console.WriteLine($"{Environment.NewLine}Encountered Leap Year:{year}");
                break;
            }
        }

        Console.WriteLine("GenerateRandomYears method executed successfully.");
    }
}
