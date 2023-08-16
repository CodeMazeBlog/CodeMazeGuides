using BenchmarkDotNet.Running;
using StringFormattableString;

var summary = BenchmarkRunner.Run<FormattableStringsMethods>();