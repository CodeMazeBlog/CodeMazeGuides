using EntityFrameworkCoreVsDapper.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace EntityFrameworkCoreVsDapper.EFCore
{
    public class PersonsContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["PersonsDB"].ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }
    }
}
