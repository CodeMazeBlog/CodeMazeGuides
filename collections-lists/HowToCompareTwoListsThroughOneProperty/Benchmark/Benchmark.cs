using BenchmarkDotNet.Attributes;
using HowToCompareTwoListsThroughOneProperty.Methods;
using HowToCompareTwoListsThroughOneProperty.Models;

namespace Benchmark;

[MemoryDiagnoser]
[RankColumn]
[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
public class BenchmarkMethods
{
    private List<Customer>? _customers;
    private List<Order>? _orders;

    [GlobalSetup]
    public void GlobalSetup()
    {
        var numberOfCustomers = 10000;
        var numberOfOrders = 500000;

        _customers = GenerateRandomCustomers(numberOfCustomers).ToList();
        _orders = GenerateRandomOrders(numberOfOrders, _customers).ToList();
    }

    [Benchmark]
    public List<Customer> ForEachMethodBenchmark()
    {
        return ListCompareMethods.ForEachMethod(_customers, _orders);
    }

    [Benchmark]
    public List<Customer> WhereAnyMethodBenchmark()
    {
        return ListCompareMethods.WhereAnyMethod(_customers, _orders);
    }

    [Benchmark]
    public List<Customer> JoinMethodBenchmark()
    {
        return ListCompareMethods.JoinMethod(_customers, _orders);
    }

    [Benchmark]
    public List<Customer> HashSetMethodBenchmark()
    {
        return ListCompareMethods.HashSetMethod(_customers, _orders);
    }

    [Benchmark]
    public List<Customer> JoinListMethodBenchmark()
    {
        return ListCompareMethods.JoinListMethod(_customers, _orders);
    }

    private static IEnumerable<Customer> GenerateRandomCustomers(int count)
    {
        return Enumerable.Range(1, count)
            .Select(i => new Customer
            {
                Id = i,
                Firstname = $"CustomerFirstname{i}",
                Surname = $"CustomerSurname{i}"                    
            });
    }

    private static IEnumerable<Order> GenerateRandomOrders(int count, List<Customer> customers)
    {
        var random = new Random();

        return Enumerable.Range(1, count)
            .Select(i => new Order
            {
                OrderId = i,
                CustomerId = random.Next(1, customers.Count + 1)
            });
    }
}