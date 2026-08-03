namespace StackInCSharp;

public class Page
{
    public Page(string title, DateTime lastUpdateTime)
    {
        Title = title;
        LastUpdateTime = lastUpdateTime;
    }

    public string Title { get; set; }

    public DateTime LastUpdateTime { get; set; }
}