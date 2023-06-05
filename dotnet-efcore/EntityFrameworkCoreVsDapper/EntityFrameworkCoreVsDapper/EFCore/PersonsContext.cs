using EntityFrameworkCoreVsDapper.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCoreVsDapper.EFCore
{
    public class PersonsContext : DbContext
    {
        public DbSet<Person> Persons{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //ADD THE CONNECTION STRING TO YOUR DATABASE HERE
            optionsBuilder.UseSqlServer("");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }
    }
}
