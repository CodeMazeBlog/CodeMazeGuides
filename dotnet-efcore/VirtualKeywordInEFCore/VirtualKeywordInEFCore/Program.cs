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
            DataSeeder.SeedWhitoutLazy(contextWithoutLazyLoading);
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
            Author_lazy author_lazy;
            author_lazy = contextLazy.Authors_lazy.AsNoTracking().First(a => a.FullName == "Holly JACKSON");

            if (author_lazy is not null)
            {
                Console.WriteLine($"Author Name: {author_lazy.FullName}");                
                Console.WriteLine($"{author_lazy.FullName}'s Books number: {author_lazy.Books?.Count}");
                Console.WriteLine($"{nameof(Author_lazy)} datatype: {author_lazy.GetType()}");
                Console.WriteLine($"{nameof(Book_lazy)} datatype: {author_lazy.Books?.First().GetType()}");

                foreach (var book_lazy in author_lazy.Books)
                {
                    Console.WriteLine($"Book Title: {book_lazy.Title}");
                }
            }
        }
    }
}
