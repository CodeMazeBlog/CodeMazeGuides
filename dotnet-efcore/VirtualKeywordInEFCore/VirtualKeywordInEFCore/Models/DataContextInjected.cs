using Microsoft.EntityFrameworkCore;

namespace VirtualKeywordInEFCore.Models
{
    public class DataContextInjected : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("DataSource=LibraryInjected.db");

            base.OnConfiguring(options);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuthorInjected>()
                .HasMany(a => a.Books)
                .WithOne()
                .HasForeignKey(b => b.AuthorInjectedId);
        }

        public DbSet<AuthorInjected> AuthorsInjected { get; set; }
        public DbSet<BookInjected> BooksInjected { get; set; }
    }
}
