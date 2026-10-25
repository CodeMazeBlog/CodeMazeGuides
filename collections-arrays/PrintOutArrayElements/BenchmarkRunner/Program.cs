using BenchmarkRunner;

// In-process: the default out-of-process host keeps every line the benchmarks print and runs out of memory.
string[] benchmarkArgs = args.Any(a => a is "--inProcess" or "-i") ? args : [.. args, "--inProcess"];

BenchmarkDotNet.Running.BenchmarkRunner.Run<ElementPrinterBenchmark>(args: benchmarkArgs);
