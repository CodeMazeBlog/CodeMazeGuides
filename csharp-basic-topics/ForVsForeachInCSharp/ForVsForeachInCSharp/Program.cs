using BenchmarkDotNet.Running;
using ForVsForeachInCSharp;

var summary = BenchmarkRunner.Run<ForVsForeachExamples>();
