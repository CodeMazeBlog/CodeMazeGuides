namespace BenchmarkAcrossDifferentDotNETVersions;

public class BookService
{
    public static List<Book> GetBooks()
        => new()
        {
            new() { Title = "Measuring Time", Author = "Helon Habila", Publisher = "W. W. Norton & Company" },
            new() { Title = "Americanah", Author = "Chimamanda Adichie", Publisher = "Alfred Knopf" },
            new() { Title = "Things Fall Apart", Author = "Chinua Achebe", Publisher = "William Heinemann Ltd." }
        };
}