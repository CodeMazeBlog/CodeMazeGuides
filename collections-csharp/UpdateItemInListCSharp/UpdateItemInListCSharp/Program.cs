using BenchmarkDotNet.Running;
using UpdateItemInListCSharp;
using UpdateItemInListCSharp.Models;

// Uncomment to run benchmarks
//var summary = BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);

var library = new Library();
library.AddBook("Harry Potter and the Deathly Hallows", "J.K. Rowling", "978-0545010221", false);

library.CheckoutBookUsingFind("978-0545010221");
library.CheckoutBookUsingFindIndex("978-0545010221");
library.CheckoutBookUsingFirstOrDefault("978-0545010221");
library.CheckoutBookUsingForeach("978-0545010221");
library.CheckoutBookUsingSingleOrDefault("978-0545010221");

var book = library.Books.Last();
var newBook = new Book(book.Title, book.Author, book.ISBN, book.IsCheckedOut);
library.CheckoutBookUsingIndexOf(newBook);
