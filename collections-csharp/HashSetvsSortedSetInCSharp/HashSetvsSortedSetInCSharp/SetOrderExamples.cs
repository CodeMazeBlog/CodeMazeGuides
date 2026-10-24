namespace HashSetvsSortedSetInCSharp;

public record Book(string Title, int Year);

public static class SetOrderExamples
{
    public static void PrintHashSetAndSortedSetOrder()
    {
        var hashSet = new HashSet<int> { 1, 2, 3, 4, 5 };
        hashSet.Remove(2);
        hashSet.Add(6);

        Console.WriteLine(string.Join(", ", hashSet));

        var sortedSet = new SortedSet<int> { 5, 1, 4, 2, 3 };
        sortedSet.Remove(2);
        sortedSet.Add(6);

        Console.WriteLine(string.Join(", ", sortedSet));
    }

    public static OrderedDictionary<string, bool> TrackPagesInVisitOrder()
    {
        var visited = new OrderedDictionary<string, bool>();
        visited.TryAdd("home", true);
        visited.TryAdd("pricing", true);
        visited.TryAdd("home", true);
        visited.TryAdd("docs", true);

        Console.WriteLine(string.Join(", ", visited.Keys));

        return visited;
    }

    public static SortedSet<Book> SortBooksByYear()
    {
        var byYear = Comparer<Book>.Create((a, b) => a.Year.CompareTo(b.Year));

        var sortedBooks = new SortedSet<Book>(byYear)
        {
            new("Dune", 1965),
            new("The Moon Is a Harsh Mistress", 1966),
            new("Flowers for Algernon", 1966)
        };

        Console.WriteLine(sortedBooks.Count);

        return sortedBooks;
    }

    public static HashSet<Book> BooksInHashSet()
    {
        return
        [
            new("Dune", 1965),
            new("The Moon Is a Harsh Mistress", 1966),
            new("Flowers for Algernon", 1966)
        ];
    }
}
