using BenchmarkDotNet.Running;
using BenchmarkRunner;

BenchmarkSwitcher.FromAssembly(typeof(StringReverseBenchmark).Assembly).Run(args);
