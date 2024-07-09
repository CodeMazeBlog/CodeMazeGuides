using System.Reflection;
using BenchmarkDotNet.Running;
using HowToConvertAStreamToAFileInCSharp;

var directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
if (!Directory.Exists(directory))
{ 
    return; 
}

var sourceFile = Path.Combine([directory, "Files", "source.png"]);
var destinationPath = Path.Combine([directory, "Files"]);

using var fileStream = new FileStream(sourceFile, FileMode.Open, FileAccess.Read);
using var memoryStream = new MemoryStream();
fileStream.CopyTo(memoryStream);

ConvertAStreamToAFileInCSharp.CopyToFile(memoryStream, Path.Combine([destinationPath, "CopyTo.png"]));
ConvertAStreamToAFileInCSharp.WriteToFileStream(memoryStream, Path.Combine([destinationPath, "WriteTo.png"]));
ConvertAStreamToAFileInCSharp.WriteByteToFileStream(memoryStream, Path.Combine([destinationPath, "WriteByte.png"]));
ConvertAStreamToAFileInCSharp.WriteAllBytesFile(memoryStream, Path.Combine([destinationPath, "WriteAllBytes.png"]));

ConvertAStreamToAFileInCSharpBenchmark.Stream = memoryStream;
ConvertAStreamToAFileInCSharpBenchmark.DestinationPath = destinationPath;

BenchmarkRunner.Run<ConvertAStreamToAFileInCSharpBenchmark>();
