using CreatingMultipleResorcesWithPOST.Models;
using Microsoft.EntityFrameworkCore;

namespace CreatingMultipleResorcesWithPOST.Infrastructure
{
    public class ApiContext : DbContext
    {
        public virtual DbSet<BookModel> BookModels { get; set; }

        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookModel>(entity =>
                entity.Property(p => p.Isbn).IsRequired()
            );
        }
    }
}
