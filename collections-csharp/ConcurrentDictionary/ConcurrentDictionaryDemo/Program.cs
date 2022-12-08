using System.Collections.Concurrent;

var data = new Dictionary<int, int>(10);

Parallel.ForEach(Enumerable.Range(0, 20), n =>
{
    for (int i = 0; i < 100; i++)
    {
        var k = i % 10;
        if (!data.TryGetValue(k, out int val))
        {
            val = 1;
        }
        data[k] = val + 1;
    }
});

foreach (var entry in data)
{
    Console.WriteLine($"{entry.Key}\t{entry.Value}");
}

Console.WriteLine(new string('=', 20));

var cData = new ConcurrentDictionary<int, int>();

Parallel.ForEach(Enumerable.Range(0, 20), n =>
{
    for (int i = 0; i < 100; i++)
    {
        var k = i % 10;
        cData.AddOrUpdate(k, key => 1, (key, val) => val + 1);
    }
});

foreach (var entry in cData)
{
    Console.WriteLine($"{entry.Key}\t{entry.Value}");
}
