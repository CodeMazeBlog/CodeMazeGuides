var file1 = FileUtils.Batch1.HelloWorld;
var file2 = FileUtils.Batch2.HelloWorld;

Console.WriteLine($"{nameof(FileComparer.CompareByNameAndSize)}: {FileComparer.CompareByNameAndSize(file1, file2)}");
Console.WriteLine($"{nameof(FileComparer.CompareByBytes)}: {FileComparer.CompareByBytes(file1, file2)}");
Console.WriteLine($"{nameof(FileComparer.CompareByChecksum)}: {FileComparer.CompareByChecksum(file1, file2)}");

var result = FileComparer.ComputeDiff(file1, file2);
foreach (var diff in result)
{
    Console.WriteLine($"{diff.Type}: {diff.Text}");
}