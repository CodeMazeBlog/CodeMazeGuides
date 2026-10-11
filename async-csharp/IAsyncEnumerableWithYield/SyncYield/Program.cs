Console.WriteLine($"{DateTime.Now.ToLongTimeString()}: Start");

foreach (var item in FetchItems())
{
    Console.WriteLine($"{DateTime.Now.ToLongTimeString()}: {item}");
}

Console.WriteLine($"{DateTime.Now.ToLongTimeString()}: End");

static IEnumerable<int> FetchItems()
{
    for (int i = 1; i <= 10; i++)
    {
        Thread.Sleep(1000);
        yield return i;
    }
}
