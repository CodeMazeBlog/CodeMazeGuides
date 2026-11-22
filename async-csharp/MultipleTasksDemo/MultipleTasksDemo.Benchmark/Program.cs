using BenchmarkDotNet.Running;
using MultipleTasksDemo.Benchmark;

BenchmarkSwitcher.FromAssembly(typeof(MultipleApiExecutorBenchmark).Assembly).Run(args);
