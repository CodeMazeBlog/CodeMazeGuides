using GlobalQueryFilters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddDbContext<SoftDeleteDbContext>(options =>
{
    options.UseSqlServer("Server=localhost,1433;Database=CodeMaze;User Id=sa;Password=Aa332667&;Trusted_Connection=False;Encrypt=False");
});

var serviceProvider = services.BuildServiceProvider();

var dbContext = serviceProvider.GetRequiredService<SoftDeleteDbContext>();

var child = new Child();
var entity = new SoftDeleteEntity([child]);
dbContext.SoftDeleteEntities.Add(entity);
await dbContext.SaveChangesAsync();

Console.WriteLine($"New parent added with id: {entity.Id}");
Console.WriteLine($"New child added with id: {child.Id}");

entity.IsDeleted = true;
await dbContext.SaveChangesAsync();

Console.WriteLine("Parent soft deleted");

var childAfterParentDelete = await dbContext.Children
    .Include(c => c.Parent)
    .FirstOrDefaultAsync(c => c.Id == child.Id);
Console.WriteLine($"Child queried from DB after parent is soft deleted: {childAfterParentDelete?.Id.ToString() ?? "null"}");