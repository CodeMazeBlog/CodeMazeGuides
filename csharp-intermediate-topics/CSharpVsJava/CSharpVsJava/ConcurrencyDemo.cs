using System.Diagnostics;

namespace CSharpVsJava;

public static class ConcurrencyDemo
{
    public static async Task RunAsync()
    {
        var stopwatch = Stopwatch.StartNew();

        var stock = await Task.WhenAll(Enumerable.Range(1, 10_000).Select(GetStockAsync));

        Console.WriteLine($"{stock.Length:N0} stock checks in {stopwatch.ElapsedMilliseconds:N0} ms");
    }

    private static async Task<int> GetStockAsync(int productId)
    {
        await Task.Delay(TimeSpan.FromSeconds(1)); // stands in for a database or HTTP call
        return productId % 7;
    }
}
