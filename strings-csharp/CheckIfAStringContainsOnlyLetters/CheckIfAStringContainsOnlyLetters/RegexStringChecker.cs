using System.Text.RegularExpressions;

namespace CheckIfAStringContainsOnlyLetters;

public static class RegexStringChecker
{
    public static bool IsOnlyLetters(string text)
    {
        return Regex.IsMatch(text, @"^[\p{L}]+$");
    }

    public static bool IsOnlyAciiLetters(string text)
    {
        return Regex.IsMatch(text, @"^[a-zA-Z]+$");
    }
}
