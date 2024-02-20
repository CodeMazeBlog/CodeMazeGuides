// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using SwitchVsIfElsePerformanceTests;

var summary = BenchmarkRunner.Run<SwitchVsIfElseBenchmarkTests>();