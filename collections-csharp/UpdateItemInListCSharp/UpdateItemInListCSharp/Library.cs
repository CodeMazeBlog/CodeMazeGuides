using UpdateItemInListCSharp.Models;

namespace UpdateItemInListCSharp;

public class Library
{
    public List<Book> Books { get; set; }

    public Library()
    {
        Books =
        [
            new("Harry Potter and the Philosopher's Stone", "J.K. Rowling", "978-0439708180", false),
            new("Harry Potter and the Chamber of Secrets", "J.K. Rowling", "978-0439064873", false),
            new("Harry Potter and the Goblet of Fire", "J.K. Rowling", "978-0439139601", false),
            new("Harry Potter and the Order of the Phoenix", "J.K. Rowling", "978-0439358071", false),
            new("Harry Potter and the Half-Blood Prince", "J.K. Rowling", "978-0439785969", false)
        ];
    }

    public Book AddBook(string title, string author, string isbn, bool isCheckedOut)
    {
        var book = new Book(title, author, isbn, isCheckedOut);

        Books.Add(book);

        return book;
    }

    public void CheckoutBookUsingFind(string isbn)
    {
        var bookToCheckout = Books.Find(b => b.ISBN == isbn);
        if (bookToCheckout is not null)
        {
            bookToCheckout.IsCheckedOut = true;
        }
    }

    public void CheckoutBookUsingFindIndex(string isbn)
    {
        var index = Books.FindIndex(b => b.ISBN == isbn);
        if (index != -1)
        {
            Books[index].IsCheckedOut = true;
        }
    }

    public void CheckoutBookUsingFirstOrDefault(string isbn)
    {
        var bookToCheckout = Books.FirstOrDefault(b => b.ISBN == isbn);
        if (bookToCheckout is not null)
        {
            bookToCheckout.IsCheckedOut = true;
        }
    }

    public void CheckoutBookUsingForeach(string isbn)
    {
        foreach (var book in Books)
        {
            if (book.ISBN == isbn)
            {
                book.IsCheckedOut = true;
            }
        }
    }

    public void CheckoutBookUsingIndexOf(Book book)
    {
        var index = Books.IndexOf(book);
        if (index > -1)
        {
            Books[index].IsCheckedOut = true;
        }
    }

    public void CheckoutBookUsingSingleOrDefault(string isbn)
    {
        var bookToCheckout = Books.SingleOrDefault(b => b.ISBN == isbn);
        if (bookToCheckout is not null)
        {
            bookToCheckout.IsCheckedOut = true;
        }
    }
}
