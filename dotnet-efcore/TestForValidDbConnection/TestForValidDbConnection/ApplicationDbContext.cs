namespace TestForValidDbConnection;

using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext(DbContextOptions Options) : DbContext(Options)
{ 
}