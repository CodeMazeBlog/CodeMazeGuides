public static class Extensions
{
    public static int GetWordCount(this string input)
    {
        return input.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;
    }

    public static int GetCharCount(this string input)
    {
        return input.Replace(" ", "").Length;
    }
}
