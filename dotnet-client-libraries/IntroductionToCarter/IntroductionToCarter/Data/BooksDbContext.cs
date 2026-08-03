using IntroductionToCarter.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace IntroductionToCarter.Data;

public class BooksDbContext(DbContextOptions<BooksDbContext> options)
    : DbContext(options)
{
    public virtual DbSet<Book> Books { get; set; }
}
