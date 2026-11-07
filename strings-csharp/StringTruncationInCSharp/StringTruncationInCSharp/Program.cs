using BenchmarkDotNet.Running;
using StringTruncationInCSharp;

BenchmarkRunner.Run<StringHelperBenchmark>(args: args);