using BenchmarkDotNet.Attributes;

namespace SortListByProperty;

[MemoryDiagnoser]
public class SortBenchmarks
{
    private readonly Sort _sort = new();
    private List<Book> _originalList = [];
    private List<Book> _books = [];

    [GlobalSetup]
    public void GlobalSetup()
    {
        _originalList = GenerateBooks();
    }

    // Every invocation sorts a fresh, unsorted copy of the same generated list.
    // Without this, the in-place benchmarks would sort an already sorted list
    // on every invocation after the first one.
    [IterationSetup]
    public void IterationSetup()
    {
        _books = new List<Book>(_originalList);
    }

    [Benchmark]
    public List<Book> SortByTitleUsingLinq()
    {
        return _sort.SortByTitleUsingLinq(_books);
    }

    [Benchmark]
    public List<Book> SortByPagesUsingLinq()
    {
        return _books.OrderBy(x => x.Pages).ToList();
    }

    [Benchmark]
    public List<Book> SortByPagesDescendingUsingLinq()
    {
        return _sort.SortByPagesDescendingUsingLinq(_books);
    }

    [Benchmark]
    public void SortByPagesIComparable()
    {
        _books.Sort();
    }

    [Benchmark]
    public void SortByTitleIComparer()
    {
        _books.Sort(new SortBookByTitle());
    }

    [Benchmark]
    public void SortByTitleComparisonDelegate()
    {
        var comparer = new Comparison<Book>(Sort.CompareBooks);

        _books.Sort(comparer);
    }

    public static List<Book> GenerateBooks()
    {
        var books = new List<Book>();

        for (int i = 0; i < 1000; i++)
        {
            var book = new Book
            {
                Title = DataGenerator.GenerateString(10),
                Author = DataGenerator.GenerateString(15),
                Pages = DataGenerator.GenerateNumber(100, 1000)
            };

            books.Add(book);
        }

        return books;
    }
}
