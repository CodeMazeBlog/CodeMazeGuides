namespace SortListByProperty
{
    public class Book : IComparable<Book>
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Pages { get; set; }

        public int CompareTo(Book other)
        {
            if (other == null)
                return 1;

            if (this.Pages > other.Pages)
                return 1;
            else if (this.Pages < other.Pages)
                return -1;
            else
                return 0;
        }
    }
}
