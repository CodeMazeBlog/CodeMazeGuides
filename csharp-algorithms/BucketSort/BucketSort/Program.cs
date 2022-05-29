using BenchmarkDotNet.Running;
using BucketSort;

var summary = BenchmarkRunner.Run<BucketSortMethods>();
