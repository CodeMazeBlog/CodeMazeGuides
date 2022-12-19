//dotnet run -p ExampleAppBenchmark/ExampleAppBenchmark.csproj -c Release
using ExampleAppBenchmark;
using BenchmarkDotNet.Running;

BenchmarkRunner.Run<TaskAndValueTaskBenchmark>();