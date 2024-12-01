using GlobalQueryFilters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddDbContext<SoftDeleteDbContext>(options => options.UseInMemoryDatabase("GlobalQueryFilters"));
services.AddDbContext<NavPropDbContext>(options => options.UseInMemoryDatabase("GlobalQueryFilters"));

var serviceProvider = services.BuildServiceProvider();

var dbContext = serviceProvider.GetRequiredService<SoftDeleteDbContext>();

var entity = new SoftDeleteEntity();
dbContext.SoftDeleteEntities.Add(entity);
await dbContext.SaveChangesAsync();

Console.WriteLine($"New entity added with id: {entity.Id}");

var entityToDelete = await dbContext.SoftDeleteEntities
    .FirstOrDefaultAsync(e => e.Id == entity.Id);

Console.WriteLine($"Entity queried from DB: {entityToDelete!.Id}");

entityToDelete.IsDeleted = true;
await dbContext.SaveChangesAsync();

Console.WriteLine("Entity soft deleted");

var entityAfterDelete = await dbContext.SoftDeleteEntities.FirstOrDefaultAsync(e => e.Id == entity.Id);
Console.WriteLine($"Entity queried from DB after soft delete: {entityAfterDelete?.Id.ToString() ?? "null"}");


// Disabling Global Query Filters

var entityAfterDeleteWithDisabledQueryFilter = await dbContext.SoftDeleteEntities
    .IgnoreQueryFilters()
    .FirstOrDefaultAsync(e => e.Id == entity.Id);

Console.WriteLine("Entity queried from DB after soft delete with disabled query filter: " +
    entityAfterDeleteWithDisabledQueryFilter?.Id.ToString() ?? "null");


// Filtered Required Navigation Properties

var navPropDbContext = serviceProvider.GetRequiredService<NavPropDbContext>();

var child = new ChildEntity();
var parent = new ParentEntity([child]);
navPropDbContext.ParentEntities.Add(parent);
await navPropDbContext.SaveChangesAsync();

Console.WriteLine($"New parent added with id: {parent.Id}");
Console.WriteLine($"New child added with id: {child.Id}");

parent.IsDeleted = true;
await navPropDbContext.SaveChangesAsync();

Console.WriteLine("Parent soft deleted");

var childAfterParentDelete = await navPropDbContext.Children
    .Include(c => c.Parent)
    .FirstOrDefaultAsync(c => c.Id == child.Id);

Console.WriteLine($"Child queried after parent is soft deleted: {childAfterParentDelete?.Id.ToString() ?? "null"}");
