Console.WriteLine($"{DateTime.Now.ToLongTimeString()}: Start");

foreach (var item in await FetchItems())
{
    Console.WriteLine($"{DateTime.Now.ToLongTimeString()}: {item}");
}

Console.WriteLine($"{DateTime.Now.ToLongTimeString()}: End");

static async Task<IEnumerable<int>> FetchItems()
{
    List<int> Items = new List<int>();
    for (int i = 1; i <= 10; i++)
    {
        await Task.Delay(1000);
        Items.Add(i);
    }

    return Items;
}
