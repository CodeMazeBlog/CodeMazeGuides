using System.IO.Abstractions;
using System.Text;
using System.Text.RegularExpressions;

namespace FileSystemMocking;
public class LinuxUtility
{
    private IFileSystem fileSystem;

    public LinuxUtility(IFileSystem fileSystem) 
    {
        this.fileSystem = fileSystem;
    }

    public void Wc(string filePath, string outFilePath)
    {
        var fileContent = this.fileSystem.File.ReadAllText(filePath, Encoding.UTF8);
        var fileBytes = this.fileSystem.FileInfo.FromFileName(filePath).Length;
        var fileWords = this.CountWords(fileContent);
        var fileLines = this.CountLines(fileContent);

        var fileStats = $"{fileLines} {fileWords} {fileBytes}";

        this.fileSystem.File.AppendAllText(outFilePath, fileStats);
    }

    private int CountLines(string text) => text.Count(c => c == '\n') + 1;

    private int CountWords(string text) => Regex.Matches(text, @"\s+").Count + 1;
}
