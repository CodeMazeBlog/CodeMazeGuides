var firstFilePath = FileUtils.Batch1.HelloWorld;
var secondFilePath = FileUtils.Batch2.HelloWorld;

Console.WriteLine($"CompareByNameAndSize: {FileComparer.CompareByNameAndSize(firstFilePath, secondFilePath, StringComparison.OrdinalIgnoreCase)}");
Console.WriteLine($"CompareByBytes: {FileComparer.CompareByBytes(firstFilePath, secondFilePath)}");
Console.WriteLine($"CompareByChecksum: {FileComparer.CompareByChecksum(firstFilePath, secondFilePath)}");

var result = FileComparer.ComputeDiff(firstFilePath, secondFilePath);
foreach (var diff in result)
{
    Console.WriteLine($"{diff.Type}: {diff.Text}");
}