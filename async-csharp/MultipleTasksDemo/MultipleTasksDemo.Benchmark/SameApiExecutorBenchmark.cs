using BenchmarkDotNet.Attributes;
using MultipleTasksDemo.Client;

namespace MultipleTasksDemo.Benchmark
{
    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class SameApiExecutorBenchmark
    {
        private Executor _executor = new(new EmployeeApiFacade());
        private readonly Guid[] _employeeIds = new[]
        {
            new Guid("7119e779-3054-493c-8cf7-c617b4aa0f4e"),
            new Guid("cbb9c89f-3718-43d9-8763-b3fa3765bcea"),
            new Guid("165bcfa8-3a4f-4850-a681-bc496616f830")
        };

        [Benchmark(Baseline = true)]
        public async Task ExecuteUsingNormalForEach()
        {
            await _executor.ExecuteUsingNormalForEach(_employeeIds);
        }

        [Benchmark]
        public void ExecuteUsingParallelForeach()
        {
             _executor.ExecuteUsingParallelForeach(_employeeIds);
        }

        [Benchmark]
        public async Task ExecuteUsingParallelForeachAsync()
        {
            await _executor.ExecuteUsingParallelForeachAsync(_employeeIds);
        }
    }
}
