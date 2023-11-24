using BenchmarkDotNet.Attributes;

namespace TheForEachMethodAndForeachStatement;

[MemoryDiagnoser(true)]
public class IterationBenchmark
{
    private const int MinPrice = 10;
    private const int MaxPrice = 100;
    private readonly List<int> _prices = new();
    private readonly List<Product> _products = new();

    [GlobalSetup]
    public void Setup()
    {
        for (int i = 0; i < 10_000; i++)
        {
            var price = Random.Shared.Next(MinPrice, MaxPrice);

            _prices.Add(price);
            _products.Add(new Product(price));
        }
    }

    [Benchmark]
    public void GetTotalOfIntListWithForEachMethod()
    {
        Iterators.GetTotalOfIntListWithForEachMethod(_prices);
    }

    [Benchmark]
    public void GetTotalOfIntListWithForeachStatement()
    {
        Iterators.GetTotalOfIntListWithForeachStatement(_prices);
    }

    [Benchmark]
    public void GetTotalOfProductsListWithForEachMethod()
    {
        Iterators.GetTotalOfProductsListWithForEachMethod(_products);
    }

    [Benchmark]
    public void GetTotalOfProductsListWithForeachStatement()
    {
        Iterators.GetTotalOfProductsListWithForeachStatement(_products);
    }
}
