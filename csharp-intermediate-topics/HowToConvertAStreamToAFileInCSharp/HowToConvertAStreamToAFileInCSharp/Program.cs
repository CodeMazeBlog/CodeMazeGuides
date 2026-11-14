using BenchmarkDotNet.Running;
using HowToConvertAStreamToAFileInCSharp;

var directory = AppContext.BaseDirectory;
var sourceFile = Path.Combine(directory, "Files", "source.png");
var destinationPath = Path.Combine(directory, "Files");

using var fileStream = new FileStream(sourceFile, FileMode.Open, FileAccess.Read);
using var memoryStream = new MemoryStream();
fileStream.CopyTo(memoryStream);

Console.WriteLine($"Position after loading: {memoryStream.Position} of {memoryStream.Length}");

using (var noRewindFile = File.Create(Path.Combine(destinationPath, "NoRewind.png")))
{
    memoryStream.CopyTo(noRewindFile);
    Console.WriteLine($"Bytes written without rewinding: {noRewindFile.Length}");
}

memoryStream.Position = 0;
using (var rewindFile = File.Create(Path.Combine(destinationPath, "Rewind.png")))
{
    memoryStream.CopyTo(rewindFile);
    Console.WriteLine($"Bytes written after rewinding: {rewindFile.Length}");
    Console.WriteLine($"Position after CopyTo: source {memoryStream.Position}, destination {rewindFile.Position}");
}

ConvertAStreamToAFileInCSharp.CopyToFile(memoryStream, Path.Combine(destinationPath, "CopyTo.png"));
await ConvertAStreamToAFileInCSharp.CopyToFileAsync(memoryStream, Path.Combine(destinationPath, "CopyToAsync.png"));
ConvertAStreamToAFileInCSharp.WriteToFileStream(memoryStream, Path.Combine(destinationPath, "WriteTo.png"));
ConvertAStreamToAFileInCSharp.WriteByteToFileStream(memoryStream, Path.Combine(destinationPath, "WriteByte.png"));
ConvertAStreamToAFileInCSharp.WriteAllBytesFile(memoryStream, Path.Combine(destinationPath, "WriteAllBytes.png"));

BenchmarkRunner.Run<ConvertAStreamToAFileInCSharpBenchmark>(args: args);
