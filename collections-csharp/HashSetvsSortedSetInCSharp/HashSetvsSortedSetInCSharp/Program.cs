using BenchmarkDotNet.Running;
using HashSetvsSortedSetInCSharp;

var summary = BenchmarkRunner.Run<Operations>(args: args);
