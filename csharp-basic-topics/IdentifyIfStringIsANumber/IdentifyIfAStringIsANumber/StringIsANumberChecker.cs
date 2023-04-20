using System.Text.RegularExpressions;

namespace IdentifyIfAStringIsANumber;

public class StringIsANumberChecker
{
    public static bool IntTryParse(string value)
    {
        return int.TryParse(value, out _);
    }

    public static bool DoubleTryParse(string value)
    {
        return double.TryParse(value, out _);
    }

    public static bool UsingRegex(string value)
    {
        var pattern = @"^-?\d+(?:\.\d+)?$";

        var regex = new Regex(pattern);
        return regex.IsMatch(value);
    }

    public static bool UsingCharIsDigit(string value)
    {
        return value.All(char.IsDigit);
    }
}