using Microsoft.EntityFrameworkCore;
using PreventSQLInjectionAttacks.Models;

namespace PreventSQLInjectionAttacks.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
    }
}
