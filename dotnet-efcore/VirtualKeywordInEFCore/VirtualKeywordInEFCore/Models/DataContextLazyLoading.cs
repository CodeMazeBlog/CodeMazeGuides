using Microsoft.EntityFrameworkCore;

namespace VirtualKeywordInEFCore.Models
{
    public class DataContextLazyLoading : DbContext
    {
        public DataContextLazyLoading() : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("DataSource=LibraryLazy.db")     
                .UseLazyLoadingProxies();

            base.OnConfiguring(options);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book_lazy>()
                .HasOne<Author_lazy>(s => s.Author)
                .WithMany(g => g.Books)
                .HasForeignKey(s => s.AuthorId);
        }

        public DbSet<Author_lazy> Authors_lazy { get; set; }
        public DbSet<Book_lazy> Books_lazy { get; set; }
    }
}
