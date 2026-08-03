namespace WhatsNewInCSharp10;

[InterpolatedStringHandler]
public ref struct CustomInterpolatedStringHandler
{
    StringBuilder builder;

    public CustomInterpolatedStringHandler(int literalLength, int formattedCount)
    {
        builder = new StringBuilder(literalLength);
    }

    public void AppendLiteral(string s)
    {
        builder.Append(s);
    }

    public void AppendFormatted<T>(T t)
    {
        if (t is string)
        {
            var s = t?.ToString() ?? string.Empty;
            var notToken = "not ";
            var index = s.IndexOf(notToken);

            builder.Append(index < 0 ? s : s.Remove(index, notToken.Length));
        }
        else
        {
            builder.Append(t?.ToString());
        }
    }

    public string GetFormattedText() => builder.ToString();
}

