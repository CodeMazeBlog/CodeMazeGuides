using BenchmarkDotNet.Running;
using GetFirstNCharactersOfAString;

BenchmarkSwitcher
    .FromAssembly(typeof(FirstNCharactersOfStringGetterBenchmark).Assembly)
    .Run(args);
