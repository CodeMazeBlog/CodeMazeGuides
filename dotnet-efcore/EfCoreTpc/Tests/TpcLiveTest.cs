using App.DataAccess;
using App.DomainModels;

namespace Tests;

public class TpcLiveTest
{
    private readonly ItemRepository _itemRepository = new();

    [Fact]
    public async Task WhenSelectingItems_ThenAllClothingAndElectronicItemsAreReturned()
    {
        var items = await _itemRepository.GetAllItems();

        // Verify that the items list contains both clothing and electronic items
        Assert.Contains(items, i => i is ClothingItem);
        Assert.Contains(items, i => i is ElectronicItem);
    }

    [Fact]
    public async Task WhenSelectingElectronicItems_ThenOnlyElectronicItemsAreReturned()
    {
        var items = await _itemRepository.GetAllElectronicItems();

        // Verify that the items list contains only electronic items
        Assert.DoesNotContain(items, i => i is ClothingItem);
    }

    [Fact]
    public async Task WhenSelectingClothingItems_ThenOnlyClothingItemsAreReturned()
    {
        var items = await _itemRepository.GetAllClothingItems();

        // Verify that the items list contains only clothing items
        Assert.DoesNotContain(items, i => i is ElectronicItem);
    }

    [Fact]
    public async Task WhenInsertingElectronicItem_ThenItemIsInserted()
    {
        var item = new ElectronicItem()
        {
            Id = Guid.NewGuid(),
            Description = "Test",
            Manufacturer = "Test",
            Model = "Test",
            Price = 100
        };

        var result = await _itemRepository.InsertElectronicItem(item);

        Assert.True(result);
    }

    [Fact]
    public async Task WhenInsertingClothingItem_ThenItemIsInserted()
    {
        var item = new ClothingItem()
        {
            Id = Guid.NewGuid(),
            Description = "Test",
            Color = "Test",
            Material = "Test",
            Price = 100,
            Size = "Test"
        };

        var result = await _itemRepository.InsertClothingItem(item);

        Assert.True(result);
    }
}
