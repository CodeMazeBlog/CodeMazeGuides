using Microsoft.EntityFrameworkCore;
using TestcontainersForDotNetAndDocker.Domain;

namespace TestcontainersForDotNetAndDocker.Database
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<Cat> Cats { get; set; }
    }
}
