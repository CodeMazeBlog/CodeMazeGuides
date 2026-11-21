using BenchmarkDotNet.Running;
using BenchmarkRunner;

BenchmarkSwitcher.FromAssembly(typeof(ArrayConverterBenchmark).Assembly).Run(args);
