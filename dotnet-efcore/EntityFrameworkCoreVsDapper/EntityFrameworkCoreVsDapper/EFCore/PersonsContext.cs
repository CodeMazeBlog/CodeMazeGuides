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
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-VM6E980;User ID=sa;Password=P@ssw0rd;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Database=EntityFrameworkVsDapperDB");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }
    }
}
