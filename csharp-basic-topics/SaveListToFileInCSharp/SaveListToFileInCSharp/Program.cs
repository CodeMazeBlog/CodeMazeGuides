namespace SaveListToFileInCSharp;

public class Program
{
    public static async Task Main()
    {
        var tempPath = Path.GetTempPath();
        var fileName = "CodeMazeAnimals.txt";
        var path = Path.Combine(tempPath, fileName);

        var fileWriter = new ListToFileWriter();

        var animals = new List<string> { "Dog", "Cat", "Parrot" };
        fileWriter.WriteToFileWithStreamWriter(path, animals);

        await fileWriter.WriteToFileWithStreamWriterAsync(path, animals);

        var newAnimals = new List<string> { "Hamster" };
        fileWriter.AppendToFileWithStreamWriter(path, animals);

        fileWriter.WriteToFileWithFileClass(path, animals);
        fileWriter.AppendToFileWithFileClass(path, newAnimals);

        await fileWriter.WriteToFileWithFileClassAsync(path, animals);
        await fileWriter.AppendToFileWithFileClassAsync(path, newAnimals);
    }
}