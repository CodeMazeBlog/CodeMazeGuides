using BenchmarkDotNet.Running;
using BenchmarkRunner;

BenchmarkSwitcher.FromAssembly(typeof(DeleteElementsFromAnArrayBenchmark).Assembly).Run(args);
