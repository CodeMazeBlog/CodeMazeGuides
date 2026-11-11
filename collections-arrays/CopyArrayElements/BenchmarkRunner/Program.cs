using BenchmarkDotNet.Running;
using BenchmarkRunner;

BenchmarkSwitcher.FromAssembly(typeof(ElementCopierBenchmark).Assembly).Run(args);
