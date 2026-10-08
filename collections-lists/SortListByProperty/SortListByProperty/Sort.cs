namespace SortListByProperty;

public class Sort
{
    public List<Book> SortByTitleUsingLinq(List<Book> originalList)
    {
        return originalList.OrderBy(x => x.Title).ToList();
    }

    public List<Book> SortByAuthorAndPagesUsingLinq(List<Book> originalList)
    {
        return originalList.OrderBy(x => x.Author).ThenBy(x => x.Pages).ToList();
    }

    public List<Book> SortByPagesDescendingUsingLinq(List<Book> originalList)
    {
        return originalList.OrderByDescending(x => x.Pages).ToList();
    }

    public static int CompareBooks(Book x, Book y)
    {
        return x.Title.CompareTo(y.Title);
    }
}
