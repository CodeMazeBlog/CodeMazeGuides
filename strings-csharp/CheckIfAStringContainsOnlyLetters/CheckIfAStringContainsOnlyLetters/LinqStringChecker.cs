namespace CheckIfAStringContainsOnlyLetters;

public static class LinqStringChecker
{
    public static bool IsOnlyLetters(string text)
    {
        return text.All(char.IsLetter);
    }

    public static bool IsOnlyAsciiLetters(string text)
    {
        return text.All(char.IsAsciiLetter);
    }
}
