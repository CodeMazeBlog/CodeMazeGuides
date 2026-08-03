using Microsoft.EntityFrameworkCore;

namespace VirtualKeywordInEFCore.Models
{
    public class DataContextLazyLoading : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("DataSource=LibraryLazy.db")     
                .UseLazyLoadingProxies();

            base.OnConfiguring(options);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookLazy>()
                .HasOne(s => s.Author)
                .WithMany(g => g.Books)
                .HasForeignKey(s => s.AuthorId);
        }

        public DbSet<AuthorLazy> AuthorsLazy { get; set; }
        public DbSet<BookLazy> BooksLazy { get; set; }
    }
}
