using System.Globalization;
using System.Text.RegularExpressions;

namespace IdentifyIfAStringIsANumber;

public partial class StringIsANumberChecker
{
    public static bool IntTryParse(string stringValue)
    {
        return int.TryParse(stringValue, out _);
    }

    public static bool DoubleTryParse(string stringValue)
    {
        return double.TryParse(stringValue, NumberStyles.Any, CultureInfo.InvariantCulture, out _);
    }

    public static bool UsingRegex(string stringValue)
    {
        var pattern = @"^-?\d+(?:\.\d+)?$";
        var regex = new Regex(pattern);

        return regex.IsMatch(stringValue);
    }
    
    [GeneratedRegex(@"^-?\d+(?:\.\d+)?$")] 
    private static partial Regex IsDigitRegex();
    
    public static bool UsingCompiledRegex(string stringValue)
    {
        return IsDigitRegex().IsMatch(stringValue);
    }

    public static bool UsingCharIsDigit(string stringValue)
    {
        return stringValue.All(char.IsDigit);
    }

    public static bool UsingCharIsDigitWithForeach(string stringValue)
    {
        foreach (var c in stringValue)
        {
            if (!char.IsDigit(c))
                return false;
        }
        return true;
    }

    public static bool UsingCharIsBetween09(string stringValue)
    {
        foreach (var c in stringValue)
        {
            if (c is < '0' or > '9')
                return false;
        }
        return true;
    }
}