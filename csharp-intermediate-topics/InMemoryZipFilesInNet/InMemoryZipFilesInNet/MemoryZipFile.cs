using System.IO.Compression;

namespace InMemoryZipFilesInNet;

public static class MemoryZipFile
{
    public static MemoryStream Create(string content)
    {
        var stream = new MemoryStream();
        using (var archive = new ZipArchive(stream, ZipArchiveMode.Create, true))
        {
            var fileName = $"FileInsideZip.txt";

            using var inZipFile = archive.CreateEntry(fileName).Open();
            using var fileStreamWriter = new StreamWriter(inZipFile);
            fileStreamWriter.Write(content);
        }

        _ = stream.Seek(0, SeekOrigin.Begin);
        return stream;
    }
}
