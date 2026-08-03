using BenchmarkDotNet.Running;
using ListExistsInAnotherCSharp;

var summary = BenchmarkRunner.Run<CompareListsMethods>();