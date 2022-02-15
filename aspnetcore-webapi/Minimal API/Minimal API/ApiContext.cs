using Microsoft.EntityFrameworkCore;

namespace Minimal_API
{
    public class ApiContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }

        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        { }
    }
}
