using UpdateItemInListCSharp.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        var library = new Library();
        var book = library.AddBook("J.K. Rowling", "978-0545010221", false, "Harry Potter and the Deathly Hallows");

        library.CheckoutBookFind("978-0545010221");
        library.CheckoutBookFindIndex("978-0545010221");
        library.CheckoutBookFirstOrDefault("978-0545010221");
        library.CheckoutBookForeach("978-0545010221");
        library.CheckoutBookSingleOrDefault("978-0545010221");
        library.CheckoutBookIndexOf(book);
    }
}
