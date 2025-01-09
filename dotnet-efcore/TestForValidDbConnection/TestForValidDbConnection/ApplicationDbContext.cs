using Microsoft.EntityFrameworkCore;

namespace TestForValidDbConnection;

public class ApplicationDbContext(DbContextOptions Options) : DbContext(Options)
{ 
}