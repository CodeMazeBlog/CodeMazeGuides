using App.DataAccess;
var itemRepository = new ItemRepository();
var allItems = await itemRepository.GetAllItems();
var allElectronicItems = await itemRepository.GetAllElectronicItems();
var allClothingItems = await itemRepository.GetAllClothingItems();

foreach (var item in allItems)
{
    Console.WriteLine($"Item: {item.Description} - {item.Price}");
}

foreach (var item in allElectronicItems)
{
    Console.WriteLine($"Electronic Item: {item.Description} - {item.Price} - {item.Manufacturer}");
}

foreach (var item in allClothingItems)
{
    Console.WriteLine($"Clothing Item: {item.Description} - {item.Price} - {item.Color}");
}
