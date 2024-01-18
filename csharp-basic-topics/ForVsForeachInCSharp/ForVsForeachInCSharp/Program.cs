using BenchmarkDotNet.Running;
using ForVsForeachInCSharp;

BenchmarkDotNet.Reports.Summary summary = BenchmarkRunner.Run<ForVsForeachExamples>();
