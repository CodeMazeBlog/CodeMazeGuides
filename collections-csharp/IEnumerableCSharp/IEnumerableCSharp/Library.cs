using System.Collections;

namespace IEnumerableCSharp
{
    public class Library : IEnumerable
    {
        private readonly Book[] _books;

        public Library(Book[] books)
        {
            _books = new Book[books.Length];

            for (int i = 0; i < books.Length; i++)
            {
                _books[i] = books[i];
            }
        }

        public BookEnumerator GetEnumerator() => new BookEnumerator(_books);
        
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        
    }
}
