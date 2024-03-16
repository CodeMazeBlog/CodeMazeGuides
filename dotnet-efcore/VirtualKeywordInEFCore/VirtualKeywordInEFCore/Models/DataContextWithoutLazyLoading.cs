using Microsoft.EntityFrameworkCore;


namespace VirtualKeywordInEFCore.Models
{
    public class DataContextWithoutLazyLoading : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("DataSource=Library.db");

            base.OnConfiguring(options);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasOne(s => s.Author)
                .WithMany(g => g.Books)
                .HasForeignKey(s => s.AuthorId);
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
