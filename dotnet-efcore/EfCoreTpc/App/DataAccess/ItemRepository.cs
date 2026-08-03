using App.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace App.DataAccess;

public class ItemRepository
{
    public async Task<List<Item>> GetAllItems()
    {
        await using var context = new WebShopDbContext();
        
        return await context.Items.ToListAsync();
    }

    public async Task<List<ElectronicItem>> GetAllElectronicItems()
    {
        await using var context = new WebShopDbContext();
        
        return await context.Items.OfType<ElectronicItem>().ToListAsync();
    }

    public async Task<List<ClothingItem>> GetAllClothingItems()
    {
        await using var context = new WebShopDbContext();
        
        return await context.Items.OfType<ClothingItem>().ToListAsync();
    }

    public async Task<bool> InsertClothingItem(ClothingItem item)
    {
        await using var context = new WebShopDbContext();
        await context.Items.AddAsync(item);
        
        return await context.SaveChangesAsync() > 0;
    }

    public async Task<bool> InsertElectronicItem(ElectronicItem item)
    {
        await using var context = new WebShopDbContext();
        await context.Items.AddAsync(item);
        
        return await context.SaveChangesAsync() > 0;
    }
}
