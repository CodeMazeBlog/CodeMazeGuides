namespace SwitchCaseExpression;

public static class Program
{
    private static readonly List<int> pleasantTemperatures = [20, 22, 24];

    public static bool In<T>(this T val, params T[] vals) => vals.Contains(val);

    static void Main()
    {
        Console.WriteLine(SubMultipleCaseResults(22));
        Console.WriteLine(SubMultipleCaseWithRangePattern(100));
        Console.WriteLine(SubMultipleCaseWithGuard(100));
        Console.WriteLine(SubMultipleCaseWithExtension(22));
        Console.WriteLine(SubMultipleCaseWithListValues(22));
        Console.WriteLine(SubMultipleCaseWithOrPattern(22));
    }

    public static string SubMultipleCaseResults(int switchTemp)
    {
        var result = string.Empty;

        switch (switchTemp)
        {
            case 20:
            case 22:
            case 24:
                result = "It is a pleasant day";
                break;
            case 30:
                result = "It is hot today";
                break;
            case 35:
                result = "It is very hot today";
                break;
            default:
                result = "No weather report";
                break;
        }

        return result;
    }

    public static string SubMultipleCaseWithRangePattern(int value)
    {
        switch (value)
        {
            case >= 50 and <= 150:
                return "The value is between 50 and 150";
            case > 150 and <= 200:
                return "The value is between 150 and 200";
            default:
                return "The number is not within the given range.";
        }
    }

    public static string SubMultipleCaseWithGuard(int value)
    {
        switch (value)
        {
            case >= 50 and <= 150 when value % 2 == 0:
                return "An even value between 50 and 150";
            case >= 50 and <= 150:
                return "An odd value between 50 and 150";
            default:
                return "The number is not within the given range.";
        }
    }

    public static string SubMultipleCaseWithExtension(int tempValue)
    {
        var result = tempValue switch
        {
            var x when x.In(20, 22, 24) => "It is a pleasant day",
            30 => "It is hot today",
            35 => "It is very hot today",
            _ => "No weather report.",
        };

        return result;
    }

    public static string SubMultipleCaseWithListValues(int tempValue)
    {
        var newResult = tempValue switch
        {
            var x when pleasantTemperatures.Contains(x) => "It is a pleasant day",
            30 => "It is hot today",
            35 => "It is very hot today",
            _ => "No weather report",
        };

        return newResult;
    }

    public static string SubMultipleCaseWithOrPattern(int tempValue) => tempValue switch
    {
        20 or 22 or 24 => "It is a pleasant day",
        30 => "It is hot today",
        35 => "It is very hot today",
        > 35 => "Heat wave condition",
        _ => "No weather report."
    };
}
