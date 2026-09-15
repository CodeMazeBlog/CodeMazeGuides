using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class RepositoryContext : DbContext
    {
        // DbContextOptions<RepositoryContext>, not the non-generic DbContextOptions:
        // that is what AddDbContext<RepositoryContext> supplies, and the non-generic form
        // fails the moment a second DbContext is registered.
        public RepositoryContext(DbContextOptions<RepositoryContext> options)
            : base(options)
        {
        }

        public DbSet<Owner> Owners => Set<Owner>();
        public DbSet<Account> Accounts => Set<Account>();
    }
}
