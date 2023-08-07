// See https://aka.ms/new-console-template for more information

using App;
using BenchmarkDotNet.Running;

var summary = BenchmarkRunner.Run<UTF8Benchmarks>();
