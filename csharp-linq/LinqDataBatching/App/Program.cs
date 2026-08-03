using App;
using static System.Console;

// Run the BenchmarkDotNet benchmarks
DataBatchingBenchmarks.RunBenchmarks();

// Create a list of integers
var data = Enumerable.Range(0, 10000).ToList();

// Call each of the batching methods
var traditionalBatches = data.BatchByTraditional(100);
var linqBatches = data.BatchByLinq(100);
var chunkBatches = data.BatchByChunk(100);

// Print the batch by each method
WriteLine("Traditional method batches:");
foreach (var batch in traditionalBatches)
{
    WriteLine(string.Join(", ", batch));
}

WriteLine("LINQ method batches:");
foreach (var batch in linqBatches)
{
    WriteLine(string.Join(", ", batch));
}

WriteLine("Chunk method batches:");
var listData = chunkBatches.ToList();
foreach (var batch in listData)
{
    WriteLine(string.Join(", ", batch));
}

// Print the number of batches created by each method
WriteLine($"Traditional method created {traditionalBatches.Count} batches");
WriteLine($"LINQ method created {linqBatches.Count} batches");
WriteLine($"Chunk method created {listData.Count} batches");