using System.Text.RegularExpressions;

namespace HowToValidateGuid;

public partial class GuidHelper
{
    [GeneratedRegex("^[0-9A-Fa-f]{8}-[0-9A-Fa-f]{4}-[0-9A-Fa-f]{4}-[0-9A-Fa-f]{4}-[0-9A-Fa-f]{12}$")]
    private static partial Regex GuidValidatorRegex();

    public static bool ValidateWithRegex(string input)
    {
        return GuidValidatorRegex().IsMatch(input);
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
