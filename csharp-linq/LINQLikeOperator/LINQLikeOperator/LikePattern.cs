namespace LINQLikeOperator;

public static class LikePattern
{
    public static string Escape(string term) =>
        term.Replace(@"\", @"\\")
            .Replace("%", @"\%")
            .Replace("_", @"\_")
            .Replace("[", @"\[");
}
