using BenchmarkDotNet.Running;
using MultipleTasksDemo.Benchmark;

//BenchmarkRunner.Run<MultipleApiExecutorBenchmark>();

BenchmarkRunner.Run<SameApiExecutorBenchmark>();
