using GlobalQueryFilters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddDbContext<SoftDeleteDbContext>(options => options.UseInMemoryDatabase("GlobalQueryFilters"));

var serviceProvider = services.BuildServiceProvider();

var dbContext = serviceProvider.GetRequiredService<SoftDeleteDbContext>();

var entity = new SoftDeleteEntity();
dbContext.SoftDeleteEntities.Add(entity);
await dbContext.SaveChangesAsync();

Console.WriteLine($"New entity added with id: {entity.Id}");

var entityToDelete = await dbContext.SoftDeleteEntities.FirstOrDefaultAsync(e => e.Id == entity.Id);
Console.WriteLine($"Entity queried from DB: {entityToDelete!.Id}");

entityToDelete.IsDeleted = true;
await dbContext.SaveChangesAsync();

Console.WriteLine("Entity soft deleted");

var entityAfterDelete = await dbContext.SoftDeleteEntities.FirstOrDefaultAsync(e => e.Id == entity.Id);
Console.WriteLine($"Entity queried from DB after soft delete: {entityAfterDelete?.Id.ToString() ?? "null"}");

var entityAfterDeleteWithDisabledQueryFilter = await dbContext.SoftDeleteEntities
    .IgnoreQueryFilters()
    .FirstOrDefaultAsync(e => e.Id == entity.Id);

Console.WriteLine($"Entity queried from DB after soft delete with disabled query filter: {entityAfterDeleteWithDisabledQueryFilter?.Id.ToString() ?? "null"}");
