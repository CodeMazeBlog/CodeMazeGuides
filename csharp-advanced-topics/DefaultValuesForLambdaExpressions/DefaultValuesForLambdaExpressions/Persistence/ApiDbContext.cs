using DefaultValuesForLambdaExpressions.Models;
using Microsoft.EntityFrameworkCore;

namespace DefaultValuesForLambdaExpressions.Persistence;

public class ApiDbContext : DbContext
{
    public virtual DbSet<TodoItem> TodoItems { get; set; } = null!;

    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }
}
