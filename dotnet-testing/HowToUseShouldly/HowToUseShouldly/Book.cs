namespace HowToUseShouldly;

public class Book
{
    public string Title { get; init; }

    private int _numEditions;
    public int NumEditions
    {
        get => _numEditions;
    }

    private string _text;
    public string Text
    {
        get => _text;
    }

    private IList<string> _authors;
    public IList<string> Authors
    {
        get => _authors.ToList();
    }

    public Book(string title, string text, IList<string> authors)
    {
        Title = title;
        _numEditions = 1;
        _text = text;
        _authors = new List<string>(authors);
    }

    public IDictionary<string, int> GetBagOfWords()
    {
        var bow = new Dictionary<string, int>();

        foreach (var word in Text.Split(' '))
        {
            if (!bow.TryAdd(word, 1))
                bow[word]++;
        }

        return bow;
    }

    public void PublishNewEdition()
    {
        _numEditions++;
    }

    public void AddAuthor(string author)
    {
        if (_authors.Contains(author))
            throw new ArgumentException($"{author} already present");

        _authors.Add(author);
    }

    public void AddChapter(string chapter)
    {
        _text += Environment.NewLine + chapter;
    }
}
