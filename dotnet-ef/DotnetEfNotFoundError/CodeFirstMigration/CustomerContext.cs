using Microsoft.EntityFrameworkCore;

namespace CodeFirstMigration
{
    //CustomerContext class to automatically initialize DbContext instance
    public class CustomerContext: DbContext
    {
        public DbSet<Customer>? Customers { get; set; }

        //configure database

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=DotnetEfNotFoundErrorDb;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasKey(x => x.Id);
        }
    }
}
