using BenchmarkDotNet.Running;
using DataTableToJsonTests;

var summary = BenchmarkRunner.Run<DataTableToJsonTestsMethods>();
