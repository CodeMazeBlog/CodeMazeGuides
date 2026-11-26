namespace YieldBreakInCSharp;

public static class Utility
{
    public static IEnumerable<int> GenerateRandomYears()
    {
        int year;
        while (true)
        {
            year = Random.Shared.Next(1900, 2023);
            yield return year;

            if (DateTime.IsLeapYear(year))
            {
                Console.WriteLine($"{Environment.NewLine}Encountered Leap Year:{year}");
                yield break;
            }
        }
    }

    public static IEnumerable<int> GenerateRandomYearsWithUnreachableCode()
    {
        int year;
        while (true)
        {
            year = Random.Shared.Next(1900, 2023);
            yield return year;

            if (DateTime.IsLeapYear(year))
            {
                Console.WriteLine($"{Environment.NewLine}Encountered Leap Year:{year}");
                yield break;
            }
        }

        Console.WriteLine("GenerateRandomYears() method executed successfully.");
    }

    public static IEnumerable<int> GenerateRandomYearsWithBreak()
    {
        int year;
        while (true)
        {
            year = Random.Shared.Next(1900, 2023);
            yield return year;

            if (DateTime.IsLeapYear(year))
            {
                Console.WriteLine($"{Environment.NewLine}Encountered Leap Year:{year}");
                break;
            }
        }

        Console.WriteLine("GenerateRandomYears() method executed successfully.");
    }

    public static IEnumerable<int> GenerateRandomYearsWithCleanup()
    {
        try
        {
            int year;
            while (true)
            {
                year = Random.Shared.Next(1900, 2023);
                yield return year;

                if (DateTime.IsLeapYear(year))
                {
                    Console.WriteLine($"{Environment.NewLine}Encountered Leap Year:{year}");
                    yield break;
                }
            }
        }
        finally
        {
            Console.WriteLine("The finally block ran.");
        }
    }
}
