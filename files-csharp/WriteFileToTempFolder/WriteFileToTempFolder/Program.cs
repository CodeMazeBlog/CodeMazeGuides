using WriteFileToTempFolder;

var tempFile = Path.Combine(Path.GetTempPath(), "text.txt");
Console.WriteLine($"Creating temp file: '{tempFile}'");
TempFileCreator.CreateTempFile(tempFile);

Console.WriteLine($"Reading temp file contents: '{tempFile}'");
var tempFileContent = File.ReadAllText(tempFile);
Console.WriteLine(tempFileContent);
File.Delete(tempFile);

Console.WriteLine();

tempFile = Path.GetTempFileName();
Console.WriteLine($"Temp file '{tempFile}' exists? {File.Exists(tempFile)}");
TempFileCreator.CreateTempFile(tempFile);

Console.WriteLine($"Reading temp file contents: '{tempFile}'");
tempFileContent = File.ReadAllText(tempFile);
Console.WriteLine(tempFileContent);
File.Delete(tempFile);

Console.WriteLine();

var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
tempFile = Path.Combine(appDataPath, "text.txt");
Console.WriteLine($"Creating temp file: '{tempFile}'");
TempFileCreator.CreateTempFile(tempFile);

Console.WriteLine($"Reading temp file contents: '{tempFile}'");
tempFileContent = File.ReadAllText(tempFile);
Console.WriteLine(tempFileContent);
File.Delete(tempFile);

Console.WriteLine();

var tempDirectory = Directory.CreateTempSubdirectory("codemaze-");
tempFile = Path.Combine(tempDirectory.FullName, "text.txt");
Console.WriteLine($"Creating temp file: '{tempFile}'");
TempFileCreator.CreateTempFile(tempFile);

Console.WriteLine(File.ReadAllText(tempFile));
tempDirectory.Delete(recursive: true);

Console.WriteLine();

tempFile = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
var options = new FileStreamOptions
{
    Mode = FileMode.CreateNew,
    Access = FileAccess.ReadWrite,
    Options = FileOptions.DeleteOnClose
};

using (var stream = new FileStream(tempFile, options))
{
    stream.Write("Hello from CodeMaze!"u8);
    Console.WriteLine($"Temp file '{tempFile}' exists? {File.Exists(tempFile)}");
}

Console.WriteLine($"Temp file '{tempFile}' exists? {File.Exists(tempFile)}");
