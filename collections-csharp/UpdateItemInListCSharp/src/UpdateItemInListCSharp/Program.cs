using BenchmarkDotNet.Running;
using UpdateItemInListCSharp.Models;

namespace UpdateItemInListCSharp;

public class Program
{
    public static void Main(string[] args)
    {
        // Uncomment to run benchmarks
        //var summary = BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);

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
