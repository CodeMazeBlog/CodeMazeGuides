using DirectoryAndDirectoryInfo;

var path = Path.Combine(Path.GetTempPath(), "CM-Demos");

// Create a directory, then ask for the same one again
var newDirectory = Directory.CreateDirectory(path);
File.WriteAllText(Path.Combine(path, "notes.txt"), "Keep me");

var sameDirectory = Directory.CreateDirectory(path);
Console.WriteLine($"{sameDirectory.Name} exists: {sameDirectory.Exists}");
Console.WriteLine($"Files kept: {Directory.GetFiles(path).Length}");

// Delete without the recursive flag
try
{
    Directory.Delete(path);
}
catch (IOException ex)
{
    Console.WriteLine($"{ex.GetType().Name}: the directory is not empty");
}

// Create subdirectories
var directory = new DirectoryInfo(path);
var subDirectory = directory.CreateSubdirectory("SubFolder");

// Move a directory
var sourceDirectory = new DirectoryInfo(path);
var destDirectory = Path.Combine(Path.GetTempPath(), "CM-Demos-Moved");

sourceDirectory.MoveTo(destDirectory);

Console.WriteLine(sourceDirectory.Name);
Console.WriteLine(sourceDirectory.GetFiles().Length);
Console.WriteLine(Directory.Exists(path));

Console.WriteLine(subDirectory.Exists);

// Enumerate directories
var directoryInfo = new DirectoryInfo(destDirectory);
foreach (var subdirectory in directoryInfo.EnumerateDirectories())
{
    Console.WriteLine(subdirectory.Name);
}

// Directory traversal check
var uploads = Path.Combine(destDirectory, "SubFolder");
foreach (var userInput in new[] { "report.txt", "../notes.txt", "../SubFolder2/report.txt" })
{
    var resolved = SafePaths.ResolveInside(uploads, userInput);
    Console.WriteLine($"{userInput} -> {(resolved is null ? "rejected" : "allowed")}");
}

// Directory security (Windows only)
if (OperatingSystem.IsWindows())
{
    var identity = $@"{Environment.UserDomainName}\{Environment.UserName}";
    new DirectorySecurityAndPermissions().GrantFullControl(destDirectory, identity);
}

Directory.Delete(destDirectory, true);
