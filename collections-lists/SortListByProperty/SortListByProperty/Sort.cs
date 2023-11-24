using BenchmarkDotNet.Attributes;

namespace SortListByProperty
{
    public class Sort
    {
        [ArgumentsSource(nameof(GenerateBooks))]
        [Benchmark]
        public List<Book> SortByTitleUsingLinq(List<Book> originalList)
        {
            return originalList.OrderBy(x => x.Title).ToList();
        }

        public List<Book> SortByAuthorAndPagesUsingLinq(List<Book> originalList)
        {
            return originalList.OrderBy(x => x.Author).ThenBy(x => x.Pages).ToList();
        }

        [ArgumentsSource(nameof(GenerateBooks))]
        [Benchmark]
        public void SortByTitleIComparable(List<Book> originalList)
        {
            originalList.Sort();
        }

        [ArgumentsSource(nameof(GenerateBooks))]
        [Benchmark]
        public void SortByTitleIComparer(List<Book> originalList)
        {
            originalList.Sort(new SortBookByTitle());
        }

        [ArgumentsSource(nameof(GenerateBooks))]
        [Benchmark]
        public void SortByTitleComparisonDelegate(List<Book> originalList)
        {
            var comparer = new Comparison<Book>(Sort.CompareBooks);

            originalList.Sort(comparer);
        }

        public static int CompareBooks(Book x, Book y)
        {
            return x.Title.CompareTo(y.Title);
        }

        public IEnumerable<List<Book>> GenerateBooks()
        {
            var data = new List<List<Book>>();
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

            data.Add(books);

            return data;
        }
    }
}
