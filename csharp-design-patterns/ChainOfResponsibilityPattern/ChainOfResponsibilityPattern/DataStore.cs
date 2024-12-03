namespace ChainOfResponsibilityPattern;

public class DataStore
{
    private static readonly List<Book> _books =
    [
        new("BookA", false),
        new("BookB", false),
        new("BookC", true)
    ];

    private static readonly List<User> _users =
    [
        new("UserA", false, 10),
        new("UserB", false, 20),
        new("UserC", true, 30)
    ];

    public static Book? FindBook(string Name) => _books.FirstOrDefault(b => b.Name == Name);

    public static User? FindUser(string Name) => _users.FirstOrDefault(b => b.Name == Name);
}