using BenchmarkDotNet.Running;
using EFInserts_EFCore6;

if ((Environment.GetEnvironmentVariable("runBenchmark") ?? "false") == "true")
{
    var summary = BenchmarkRunner.Run<TestModel>();
    Console.WriteLine(summary);
}
else
{
    var testModel = new TestModel()
    {
        BatchSize = 3
    };
    testModel.RunEachMethod();    
}