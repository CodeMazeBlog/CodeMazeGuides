namespace SaveListToFileInCSharp;

public class ListToFileWriter
{
    public void WriteToFileWithStreamWriter(string path, List<string> animals)
    {
        using var sw = new StreamWriter(path);
        foreach (var animal in animals)
        {
            sw.WriteLine(animal);
        }
    }

    public async Task WriteToFileWithStreamWriterAsync(string path, List<string> animals)
    {
        await using var sw = new StreamWriter(path);
        foreach (var animal in animals)
        {
            await sw.WriteLineAsync(animal);
        }
    }

    public void AppendToFileWithStreamWriter(string path, List<string> animals)
    {
        using var sw = new StreamWriter(path, append: true);
        foreach (var animal in animals)
        {
            sw.WriteLine(animal);
        }
    }
}
