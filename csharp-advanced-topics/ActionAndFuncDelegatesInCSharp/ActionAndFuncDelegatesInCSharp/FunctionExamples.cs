namespace ActionAndFuncDelegatesInCSharp;

public class FunctionExamples
{
    public static Func<double, int, double> Power = (double number,
            int power)
        => Math.Pow(number, power);

    public static void MethodReferenceExample(double number,
        int power)
    {
        Func<double, int, double> func = new Func<double, int, double>(Power);
        var result = func(number, power);
        Console.WriteLine($"Result of the operation is: {result:0.00}"); // 35.94 } 
    }

    public static void AnonymousMethodExample(TimeProvider? timeProvider = default)
    {
        var currentYear = (timeProvider ?? TimeProvider.System).GetUtcNow().Year;

        Func<string, int, string> getPersonYearsMessage = delegate(string name,
            int birthYear)
        {
            if (birthYear > currentYear)
                throw new ArgumentException("Birth year cannot be bigger than current year.");

            var yearsOld = currentYear - birthYear;
            var nameCapitalized = name[..1].ToUpper() + name[1..].ToLower();

            var message = $"{nameCapitalized} is {yearsOld} years old.";
            return message;
        };
        string message = getPersonYearsMessage("danny", 2003); // Danny is 20 years old.
        Console.WriteLine(message);
    }

    public static void LambdaExpressionExample(TimeProvider? provider = default)
    {
        var currentHour = (provider ?? TimeProvider.System).GetUtcNow().Hour;

        var greeter = (string name) =>
        {
            var message = currentHour switch
            {
                < 12 => "Good morning", < 18 => "Good afternoon", < 24 => "Good evening", _ => string.Empty
            };
            return $"{message}, {name}!";
        };

        var greetingMessage = greeter("Jack");
        Console.WriteLine(greetingMessage); // Good afternoon, Jack!
    }
}