using BenchmarkDotNet.Running;
using GetFirstNCharactersOfAString;

var getter = new FirstNCharactersOfStringGetter();
var str = getter.UseForLoop();
BenchmarkRunner.Run<FirstNCharactersOfStringGetterBenchmark>();