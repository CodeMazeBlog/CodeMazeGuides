using BenchmarkDotNet.Attributes;

namespace ComparingTheForEachMethodAndForeachStatement;

[MemoryDiagnoser(true)]
public class IterationBenchmark
{
    private const int MinPrice = 10;
    private const int MaxPrice = 100;
    private List<int> _prices = new();
    private List<Product> _products = new();

    [GlobalSetup]
    public void Setup()
    {
        for (int i = 0; i < 1000; i++)
        {
            var price = Random.Shared.Next(MinPrice, MaxPrice);

            _prices.Add(price);
            _products.Add(new Product(price));
        }
    }

    [Benchmark]
    public int GetTotalOfIntListWithForEachMethod()
    {
        int total = 0;

        _prices.ForEach(x => total += x);

        return total;
    }

    [Benchmark]
    public int GetTotalOfIntListWithForeachStatement()
    {
        int total = 0;

        foreach (var price in _prices)
        {
            total += price;
        }

        return total;
    }

    [Benchmark]
    public int GetTotalOfProductsListWithForEachMethod()
    {
        int total = 0;

        _products.ForEach(x => total += x.Price);

        return total;
    }

    [Benchmark]
    public int GetTotalOfProductsListWithForeachStatement()
    {
        int total = 0;

        foreach (var product in _products)
        {
            total += product.Price;
        }

        return total;
    }
}
