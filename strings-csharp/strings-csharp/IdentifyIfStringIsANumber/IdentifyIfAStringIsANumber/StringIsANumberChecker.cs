using System.Text.RegularExpressions;

namespace IdentifyIfAStringIsANumber;

public class StringIsANumberChecker
{
    public static bool IntTryParse(string stringValue)
    {
        return int.TryParse(stringValue, out _);
    }

    public static bool DoubleTryParse(string stringValue)
    {
        return double.TryParse(stringValue, out _);
    }

    public static bool UsingRegex(string stringValue)
    {
        var pattern = @"^-?\d+(?:\.\d+)?$";
        var regex = new Regex(pattern);

        return regex.IsMatch(stringValue);
    }

    public static bool UsingCharIsDigit(string stringValue)
    {
        return stringValue.All(char.IsDigit);
    }
}