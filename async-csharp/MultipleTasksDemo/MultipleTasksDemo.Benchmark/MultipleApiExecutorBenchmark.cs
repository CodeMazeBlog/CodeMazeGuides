using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using MultipleTasksDemo.Client;

namespace MultipleTasksDemo.Benchmark;

[InProcess]
[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class MultipleApiExecutorBenchmark
{
    private readonly Executor _executor = new(new EmployeeApiFacade());
    private readonly Guid _id = new("7119e779-3054-493c-8cf7-c617b4aa0f4e");

    [Benchmark(Baseline = true)]
    public async Task<EmployeeProfile> ExecuteInSequence()
    {
        return await _executor.ExecuteInSequence(_id);
    }

    [Benchmark]
    public async Task<EmployeeProfile> ExecuteInParallel()
    {
        return await _executor.ExecuteInParallel(_id);
    }
}
