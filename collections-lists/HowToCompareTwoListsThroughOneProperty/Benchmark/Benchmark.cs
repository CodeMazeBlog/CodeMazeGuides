using BenchmarkDotNet.Attributes;
using HowToCompareTwoListsThroughOneProperty.Methods;
using HowToCompareTwoListsThroughOneProperty.Models;

namespace Benchmark;

[MemoryDiagnoser]
[RankColumn]
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
        return Methods.ForEachMethod(_customers, _orders);
    }

    [Benchmark]
    public List<Customer> WhereAnyMethodBenchmark()
    {
        return Methods.WhereAnyMethod(_customers, _orders);
    }

    [Benchmark]
    public List<Customer> JoinMethodBenchmark()
    {
        return Methods.JoinMethod(_customers, _orders);
    }

    [Benchmark]
    public List<Customer> HashSetMethodBenchmark()
    {
        return Methods.HashSetMethod(_customers, _orders);
    }

    [Benchmark]
    public List<Customer> JoinListMethodBenchmark()
    {
        return Methods.JoinListMethod(_customers, _orders);
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