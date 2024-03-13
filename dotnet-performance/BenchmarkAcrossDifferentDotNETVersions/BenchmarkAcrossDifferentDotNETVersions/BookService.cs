namespace BenchmarkAcrossDifferentDotNETVersions;

public record Book(string Title, string Author, string Publisher);

public class BookService
{
    public static List<Book> GetBooks()
        => new()
        {
            new("Measuring Time", "Helon Habila", "W. W. Norton & Company"),
            new("Americanah", "Chimamanda Adichie", "Alfred Knopf"),
            new("Things Fall Apart", "Chinua Achebe", "William Heinemann Ltd.")
        };
}