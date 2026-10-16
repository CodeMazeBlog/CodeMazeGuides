Console.WriteLine($"{DateTime.Now.ToLongTimeString()}: Start");

await foreach (var item in FetchItems())
{
    Console.WriteLine($"{DateTime.Now.ToLongTimeString()}: {item}");
}

Console.WriteLine($"{DateTime.Now.ToLongTimeString()}: End");

static async IAsyncEnumerable<int> FetchItems()
{
    for (int i = 1; i <= 10; i++)
    {
        await Task.Delay(1000);
        yield return i;
    }
}
