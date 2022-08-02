namespace WhatsNewInCSharp10;

public record Article(string Author, string Title)
{
    public sealed override string ToString()
    {
        return $"{Author}: {Title}";
    }
}
