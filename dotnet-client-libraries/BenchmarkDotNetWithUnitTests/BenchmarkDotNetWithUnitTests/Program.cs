using BenchmarkDotNet.Running;
using BenchmarkDotNetWithUnitTests;

var summary = BenchmarkRunner.Run<StringConcatBenchmarks>();