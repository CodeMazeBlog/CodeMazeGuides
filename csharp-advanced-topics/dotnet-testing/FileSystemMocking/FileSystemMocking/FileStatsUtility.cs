using System.IO.Abstractions;
using System.Text;
using System.Text.RegularExpressions;

namespace FileSystemMocking;
public class FileStatsUtility
{
    private IFileSystem _fileSystem;

    public FileStatsUtility(IFileSystem fileSystem) 
    {
        _fileSystem = fileSystem;
    }

    public void WriteFileStats(string filePath, string outFilePath)
    {
        var fileContent = _fileSystem.File.ReadAllText(filePath, Encoding.UTF8);
        var fileBytes = _fileSystem.FileInfo.FromFileName(filePath).Length;
        var fileWords = this.CountWords(fileContent);
        var fileLines = this.CountLines(fileContent);

        var fileStats = $"{fileLines} {fileWords} {fileBytes}";

        _fileSystem.File.AppendAllText(outFilePath, fileStats);
    }

    private int CountLines(string text) => Regex.Matches(text, Environment.NewLine).Count + 1;

    private int CountWords(string text) => Regex.Matches(text, @"\s+").Count + 1;
}
