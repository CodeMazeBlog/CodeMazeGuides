using System.Text.RegularExpressions;

namespace ImprovePerformanceWithSourceGeneratedRegEx;

public static partial class PasswordValidator
{
    public static bool ValidatePasswordWithRegularRegEx(string password)
    {
        var regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$");

        return regex.IsMatch(password);
    }

    public static bool ValidatePasswordWithCompiledRegEx(string password)
        => Regex.IsMatch(
            password,
            @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$",
            RegexOptions.Compiled);


    public static bool ValidatePasswordWithSourceGeneratedRegEx(string password)
        => PasswordRegEx().IsMatch(password);

    [GeneratedRegex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$")]
    private static partial Regex PasswordRegEx();
}
