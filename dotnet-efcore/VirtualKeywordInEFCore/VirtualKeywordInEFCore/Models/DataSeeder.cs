namespace VirtualKeywordInEFCore.Models
{
    public class DataSeeder
    {
        public static void SeedWithoutLazy(DataContextWithoutLazyLoading contextWithoutLazyLoading)
        {
            contextWithoutLazyLoading.Database.EnsureCreated();

            if (contextWithoutLazyLoading.Authors.Any())
            {
                return;
            }

            var authors = new List<Author>
            {
                new () { FullName = "Lucy FOLEY", Books = new List<Book>
                            {
                                new () { Title = "The Hunting Party", AuthorId = 1 },
                                new () { Title = "The Guest List", AuthorId = 1 },
                                new () { Title = "The PARIS Apartment", AuthorId = 1 },
                                new () { Title = "The Book of Lost and Found", AuthorId = 1 }
                            }
                },
                new () { FullName = "Colleen HOOVER", Books = new List<Book>
                            {
                                new () { Title = "Ugly Love", AuthorId = 2 },
                                new () { Title = "November 9", AuthorId = 2 },
                                new () { Title = "Too Late", AuthorId = 2 },
                                new () { Title = "Never Never", AuthorId = 2 },
                                new () { Title = "Confess", AuthorId = 2 },
                                new () { Title = "Verity", AuthorId = 2 },
                                new () { Title = "Losing Hope", AuthorId = 2 },
                                new () { Title = "Layla", AuthorId = 2 }
                            }
                }
            };

            contextWithoutLazyLoading.AddRange(authors);
            contextWithoutLazyLoading.SaveChanges();
        }

        public static void SeedLazy(DataContextLazyLoading contextLazy)
        {
            contextLazy.Database.EnsureCreated();
            if (contextLazy.AuthorsLazy.Any())
            {
                return;
            }

            var authorsLazy = new List<AuthorLazy>
            {
                new () { FullName = "Holly JACKSON" }
            };

            var booksLazy = new List<BookLazy>
            {
                new () { Title = "A Good Girl's Guide to Murder", AuthorId = 1 },
                new () { Title = "Good Girl, Bad Blood", AuthorId = 1 },
                new () { Title = "As Good As Dead", AuthorId = 1 },
                new () { Title = "Five Survive", AuthorId = 1 }
            };

            contextLazy.AddRange(authorsLazy);
            contextLazy.AddRange(booksLazy);
            contextLazy.SaveChanges();
        }
    }
}
