using BenchmarkDotNet.Attributes;
using UpdateItemInListCSharp.Models;

namespace UpdateItemInListCSharp;

[MemoryDiagnoser(true)]
[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class BenchmarkTester
{
    private Library _library = null!;
    private Book _newBook = null!;

    [GlobalSetup]
    public void GlobalSetup()
    {
        _library = new Library();
        var book = _library.Books.Last();
        _newBook = new Book(book.Title, book.Author, book.ISBN, book.IsCheckedOut);
    }

    [Benchmark]
    public void CheckoutBookUsingFind()
    {
        _library.CheckoutBookUsingFind("978-0439708180");
    }

    [Benchmark]
    public void CheckoutBookUsingFindIndex()
    {
        _library.CheckoutBookUsingFindIndex("978-0439708180");
    }

    [Benchmark]
    public void CheckoutBookUsingFirstOrDefault()
    {
        _library.CheckoutBookUsingFirstOrDefault("978-0439708180");
    }

    [Benchmark]
    public void CheckoutBookUsingForeach()
    {
        _library.CheckoutBookUsingForeach("978-0439708180");
    }

    [Benchmark]
    public void CheckoutBookUsingIndexOf()
    {
        _library.CheckoutBookUsingIndexOf(_newBook);
    }

    [Benchmark]
    public void CheckoutBookUsingSingleOrDefault()
    {
        _library.CheckoutBookUsingSingleOrDefault("978-0439708180");
    }
}
