using System.Collections;

namespace IEnumerableCSharp
{
    public class BookEnumerator : IEnumerator
    {
        private readonly Book[] _books;
        private int _index = -1;

        public BookEnumerator(Book[] books)
        {
            _books = books;
        }

        public Book Current
        {
            get
            {
                return _books[_index];
            }
        }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            _index++;
            return _index < _books.Length;
        }

        public void Reset()
        {
            _index = -1;
        }
    }
}
