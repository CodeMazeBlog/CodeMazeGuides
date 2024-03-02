using Microsoft.EntityFrameworkCore;

namespace VirtualKeywordInEFCore.Models
{
    public class DataContextLazyLoading : DbContext
    {
        public DataContextLazyLoading() : base()
        {
            //this.ChangeTracker.LazyLoadingEnabled = false;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer($"Server=(localdb)\\mssqllocaldb;Database=LibraryLazy.db;Trusted_Connection=True;MultipleActiveResultSets=true")
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
