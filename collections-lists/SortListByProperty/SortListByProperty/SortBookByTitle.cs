namespace SortListByProperty
{
    public class SortBookByTitle : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            if (x == null)
                return -1;

            if (y == null)
                return 1;

            return x.Title.CompareTo(y.Title);
        }
    }
}
