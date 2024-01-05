using WriteFileToTempFolder;

var tempFile = Path.Combine(Path.GetTempPath(),"text.txt");
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

var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
tempFile = Path.Combine(appDataPath, "text.txt");
Console.WriteLine($"Creating temp file: '{tempFile}'");
TempFileCreator.CreateTempFile(tempFile);

Console.WriteLine($"Reading temp file contents: '{tempFile}'");
tempFileContent = File.ReadAllText(tempFile);
Console.WriteLine(tempFileContent);
File.Delete(tempFile);