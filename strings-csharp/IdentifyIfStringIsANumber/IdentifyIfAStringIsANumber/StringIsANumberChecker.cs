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
        return double.TryParse(stringValue, NumberStyles.Float | NumberStyles.AllowThousands,
            CultureInfo.InvariantCulture, out _);
    }

    public static bool UsingRegex(string stringValue)
    {
        const string pattern = @"^-?[0-9]+(?:\.[0-9]+)?$";
        var regex = new Regex(pattern);

        return regex.IsMatch(stringValue);
    }
    
    [GeneratedRegex(@"^-?[0-9]+(?:\.[0-9]+)?$")] 
    private static partial Regex IsDigitRegex();
    
    public static bool UsingCompiledRegex(string stringValue)
    {
        return IsDigitRegex().IsMatch(stringValue);
    }

    public static bool UsingCharIsDigit(string stringValue)
    {
        return !string.IsNullOrEmpty(stringValue) && stringValue.All(char.IsAsciiDigit);
    }

    public static bool UsingCharIsDigitWithForeach(string stringValue)
    {
        if (string.IsNullOrEmpty(stringValue))
            return false;

        foreach (var c in stringValue)
        {
            if (!char.IsAsciiDigit(c))
                return false;
        }
        return true;
    }

    public static bool UsingCharIsBetween09(string stringValue)
    {
        if (string.IsNullOrEmpty(stringValue))
            return false;

        foreach (var c in stringValue)
        {
            if (c is < '0' or > '9')
                return false;
        }
        return true;
    }
}