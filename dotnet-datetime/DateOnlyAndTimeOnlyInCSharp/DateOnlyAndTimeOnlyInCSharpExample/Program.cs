namespace DateOnlyAndTimeOnlyInCSharpExample;

public class Program
{
    public static void Main()
    {
        DemonstrateDateOnly();
        DemonstrateTimeOnly();
        DemonstrateFromDateTime();
        DemonstrateBasicOperators();
    }

    public static void DemonstrateDateOnly()
    {
        var dateOnly = new DateOnly(2022, 1, 1);
        var dateTime = new DateTime(2022, 1, 1);
        Console.WriteLine(dateOnly);
        Console.WriteLine(dateTime);

        var addDays = dateOnly.AddDays(1);
        var addMonths = dateOnly.AddMonths(1);
        var addYears = dateOnly.AddYears(1);


        Console.WriteLine(addDays);
        Console.WriteLine(addMonths);
        Console.WriteLine(addYears);

        if (DateOnly.TryParse("2022/01/01", out DateOnly result))
        {
            Console.WriteLine($"Parsed DateOnly: {result}");
        }
    }

    public static void DemonstrateTimeOnly()
    {
        var sevenAM = new TimeOnly(7, 0);
        var elevenAM = new TimeOnly(11, 0);
        var onePM = new TimeOnly(13, 0);

        Console.WriteLine(elevenAM.IsBetween(sevenAM, onePM));

        var elevenPM = new TimeOnly(23, 0);
        var oneAM = new TimeOnly(1, 0);
        var twoAM = new TimeOnly(2, 0);
        Console.WriteLine(oneAM.IsBetween(elevenPM, twoAM));

        var addHours = oneAM.AddHours(1);
        var addMinutes = oneAM.AddMinutes(5);
        var addSeconds = oneAM.Add(TimeSpan.FromSeconds(1));

    }

    public static void DemonstrateFromDateTime()
    {
        var dateTime = new DateTime(2022, 1, 1, 11, 30, 0);

        var dateOnly = DateOnly.FromDateTime(dateTime);
        var timeOnly = TimeOnly.FromDateTime(dateTime);

        Console.WriteLine(dateOnly);
        Console.WriteLine(timeOnly);
    }

    public static void DemonstrateBasicOperators()
    {
        var firstOfJan = new DateOnly(2022, 1, 1);
        var secondOfJan = new DateOnly(2022, 1, 2);

        if (secondOfJan > firstOfJan)
        {
            Console.WriteLine($"{secondOfJan} is after {firstOfJan}");
        }

        var oneAm = new TimeOnly(1, 0);
        var twoAm = new TimeOnly(2, 0);
        if (oneAm < twoAm)
        {
            Console.WriteLine($"{oneAm} is before {twoAm}");
        }
    }
}