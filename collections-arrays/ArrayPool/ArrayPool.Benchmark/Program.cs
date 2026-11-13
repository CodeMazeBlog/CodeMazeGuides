using ArrayPool.Benchmark;
using BenchmarkDotNet.Running;

BenchmarkSwitcher.FromAssembly(typeof(Benchmark).Assembly).Run(args);
