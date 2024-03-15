using Microsoft.EntityFrameworkCore;
using VirtualKeywordInEFCore.Models;

namespace VirtualKeywordInEFCore
{
    public class Program
    {
        static void Main()
        {
            LoadData();

            LoadDataWithLazyLoading();
        }

        public static void LoadData()
        {
            Console.WriteLine("No Lazy Loading:");

            using var contextWithoutLazyLoading = new DataContextWithoutLazyLoading();
            DataSeeder.SeedWithoutLazy(contextWithoutLazyLoading);
            Author author;
            author = contextWithoutLazyLoading.Authors.AsNoTracking().First(a => a.FullName == "Lucy FOLEY");

            if (author is not null)
            {
                Console.WriteLine($"Author Name: {author.FullName}");
                Console.WriteLine($"{author.FullName}'s Books number: {author.Books.Count}");

                foreach (var book in author.Books)
                {
                    Console.WriteLine($"Book Title: {book.Title}");
                }
            }
        }

        public static void LoadDataWithLazyLoading()
        {
            Console.WriteLine("\nLazy Loading using Proxies:");

            using var contextLazy = new DataContextLazyLoading();
            DataSeeder.SeedLazy(contextLazy);
            AuthorLazy authorLazy;
            authorLazy = contextLazy.AuthorsLazy.AsNoTracking().First(a => a.FullName == "Holly JACKSON");

            if (authorLazy is not null)
            {
                Console.WriteLine($"Author Name: {authorLazy.FullName}");                
                Console.WriteLine($"{authorLazy.FullName}'s Books number: {authorLazy.Books?.Count}");
                Console.WriteLine($"{nameof(AuthorLazy)} datatype: {authorLazy.GetType()}");
                Console.WriteLine($"{nameof(BookLazy)} datatype: {authorLazy.Books?.First().GetType()}");

                foreach (var bookLazy in authorLazy.Books)
                {
                    Console.WriteLine($"Book Title: {bookLazy.Title}");
                }
            }
        }
    }
}
