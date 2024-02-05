namespace CheckIfAStringContainsOnlyLetters;

public static class NativeStringChecker
{
    public static bool IsOnlyAsciiLettersByPatternMatching(string text)
    {
        foreach (var item in text)
        {
            if (item is >= 'A' and <= 'Z' or >= 'a' and <= 'z')
                continue;
            else
                return false;
        }
        return true;
    }

    public static bool IsOnlyAsciiLettersBySwitchCase(string text)
    {
        foreach (var item in text)
        {
            switch (item)
            {
                case >= 'A' and <= 'Z':
                case >= 'a' and <= 'z':
                    continue;
                default:
                    return false;
            }
        }
        return true;
    }
}
