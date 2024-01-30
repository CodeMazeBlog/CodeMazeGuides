using Microsoft.EntityFrameworkCore;

namespace LazyLoadingVsEagerLoadingEF;

internal class Program
{
    static void Main(string[] args)
    {
        using var context = new DataContext();

        Seeder.SeedData(context);
        var random = new Random();
        var authorId = random.Next(1, 3);

        Console.WriteLine("Lazy Loading Example:");

        var authorLazyLoading = context.Authors.FirstOrDefault(a => a.AuthorId == authorId);

        Console.WriteLine($"Author Name: {authorLazyLoading.Name}");

        // Lazy Loading
        foreach (var book in authorLazyLoading.Books.ToList())
        {
            Console.WriteLine($"Book Title: {book.Title}");
        }

        Console.WriteLine("\nEager Loading Example:");

        // Eager Loading
        var authorEagerLoading = context.Authors
            .Include(a => a.Books)
            .FirstOrDefault(a => a.AuthorId == authorId);

        Console.WriteLine($"Author Name: {authorEagerLoading.Name}");

        foreach (var book in authorEagerLoading.Books)
        {
            Console.WriteLine($"Book Title: {book.Title}");
        }
    }
}
