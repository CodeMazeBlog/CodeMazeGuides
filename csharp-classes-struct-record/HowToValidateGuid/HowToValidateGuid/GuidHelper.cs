using System.Text.RegularExpressions;

namespace HowToValidateGuid;

public class GuidHelper
{
    public static bool ValidateWithRegex(string input)
    {
        const string pattern = @"^[0-9A-F]{8}-[0-9A-F]{4}-[0-9A-F]{4}-[0-9A-F]{4}-[0-9A-F]{12}$";

        return Regex.IsMatch(input, pattern, RegexOptions.IgnoreCase);
    }

    public static bool ValidateWithGuidParse(string input)
    {
        try
        {
            Guid.Parse(input);
        }
        catch (FormatException)
        {
            return false;
        }

        return true;
    }

    public static bool ValidateWithGuidParseExact(string input, string format)
    {
        try
        {
            Guid.ParseExact(input, format);
        }
        catch (FormatException)
        {
            return false;
        }

        return true;
    }

    public static bool ValidateWithGuidTryParse(string input)
    {
        return Guid.TryParse(input, out Guid _);
    }

    public static bool ValidateWithGuidTryParseExact(string input, string format)
    {
        return Guid.TryParseExact(input, format, out Guid _);
    }

    public static bool ValidateWithNewGuid(string input)
    {
        try
        {
            var _ = new Guid(input);
        }
        catch (FormatException)
        {
            return false;
        }

        return true;
    }
}
