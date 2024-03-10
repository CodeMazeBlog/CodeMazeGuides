namespace UpdateItemInListCSharp.Models
{
    public class Library
    {
        public List<Book> Books { get; set; }

        public Library()
        {
            Books =
                [
                new("J.K. Rowling", "978-0439708180", false, "Harry Potter and the Philosopher's Stone"),
                new("J.K. Rowling", "978-0439064873", false, "Harry Potter and the Chamber of Secrets"),
                new("J.K. Rowling", "978-0439139601", false, "Harry Potter and the Goblet of Fire"),
                new("J.K. Rowling", "978-0439358071", false, "Harry Potter and the Order of the Phoenix"),
                new("J.K. Rowling", "978-0439785969", false, "Harry Potter and the Half-Blood Prince")
            ];
        }

        public Book AddBook(string author, string isbn, bool isCheckedOut, string title)
        {
            var book = new Book(author, isbn, isCheckedOut, title); Books.Add(book);
            return book;
        }

        public void CheckoutBookFind(string isbn)
        {
            var bookToCheckout = Books.Find(b => b.ISBN == isbn);
            if (bookToCheckout != null)
            {
                bookToCheckout.IsCheckedOut = true;
            }
        }

        public void CheckoutBookFindIndex(string isbn)
        {
            var index = Books.FindIndex(b => b.ISBN == isbn);
            if (index != -1)
            {
                Books[index].IsCheckedOut = true;
            }
        }

        public void CheckoutBookFirstOrDefault(string isbn)
        {
            var bookToCheckoutFirstOrDefault = Books.FirstOrDefault(b => b.ISBN == isbn);
            if (bookToCheckoutFirstOrDefault != null)
            {
                bookToCheckoutFirstOrDefault.IsCheckedOut = true;
            }
        }

        public void CheckoutBookForeach(string isbn)
        {
            foreach (var bookItem in Books)
            {
                if (bookItem.ISBN == isbn)
                {
                    bookItem.IsCheckedOut = true;
                }
            }
        }

        public void CheckoutBookIndexOf(Book book)
        {
            var index = Books.IndexOf(book);
            if (index > -1)
            {
                Books[index].IsCheckedOut = true;
            }
        }

        public void CheckoutBookSingleOrDefault(string isbn)
        {
            var bookToCheckoutSingleOrDefault = Books.SingleOrDefault(b => b.ISBN == isbn);
            if (bookToCheckoutSingleOrDefault != null)
            {
                bookToCheckoutSingleOrDefault.IsCheckedOut = true;
            }
        }
    }
}
