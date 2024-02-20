namespace LazyLoadingVsEagerLoadingEF;
public static class Seeder
{
    public static void SeedData(DataContext context)
    {
        context.Database.EnsureCreated();

        if (context.Authors.Any())
        {
            Console.WriteLine("Database already seeded.");
            return;
        }

        var authors = new List<Author>
        {
            new Author { Name = "J.K. Rowling", Books = new List<Book>
                {
                    new Book { Title = "Harry Potter and the Philosopher's Stone" },
                    new Book { Title = "Harry Potter and the Chamber of Secrets" }
                }
            },
            new Author { Name = "George R.R. Martin", Books = new List<Book>
                {
                    new Book
                    {
                        Title = "A Game of Thrones",
                        Reviews = new List<Review>
                        {
                            new Review { ReviewText = "Epic and unpredictable." },
                            new Review { ReviewText = "Characters that stay with you." }
                        }
                    },
                    new Book
                    {
                        Title = "A Clash of Kings",
                        Reviews = new List<Review>
                        {
                            new Review { ReviewText = "A masterpiece of political intrigue." },
                            new Review { ReviewText = "Couldn't put it down." }
                        }
                    }
                }
            }
        };

        context.Authors.AddRange(authors);
        context.SaveChanges();

        Console.WriteLine("Database seeded successfully.");
    }
}
