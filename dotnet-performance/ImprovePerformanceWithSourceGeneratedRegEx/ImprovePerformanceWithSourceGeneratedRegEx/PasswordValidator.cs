using System.Text.RegularExpressions;

namespace ImprovePerformanceWithSourceGeneratedRegEx;

public static partial class PasswordValidator
{
    public static bool ValidatePasswordWithRegularRegEx(string password)
    {
        var regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$");

        return regex.IsMatch(password);
    }

    public static bool ValidatePasswordWithStaticRegEx(string password)
        => Regex.IsMatch(
            password,
            @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$");

    public static bool ValidatePasswordWithCompiledRegEx(string password)
        => Regex.IsMatch(
            password,
            @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$",
            RegexOptions.Compiled);

    public static bool ValidatePasswordWithNewCompiledRegEx(string password)
    {
        var regex = new Regex(
            @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$",
            RegexOptions.Compiled);

        return regex.IsMatch(password);
    }

    public static bool ValidatePasswordWithSourceGeneratedRegEx(string password)
        => PasswordRegEx().IsMatch(password);

    public static bool ValidatePasswordWithSourceGeneratedRegExProperty(string password)
        => PasswordRegExProperty.IsMatch(password);

    [GeneratedRegex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$")]
    private static partial Regex PasswordRegEx();

    [GeneratedRegex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$")]
    private static partial Regex PasswordRegExProperty { get; }
}
